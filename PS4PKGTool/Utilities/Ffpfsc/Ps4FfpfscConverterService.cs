#nullable enable
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OrbisPkgTool.Sfo;
using PS4PKGTool.Core.Diagnostics;
using PS4PKGTool.Utilities.Ffpfsc.Engine;
using PS4PKGTool.Utilities.PkgInspection;
using PS4PKGTool.Utilities.PkgMeta;

namespace PS4PKGTool.Utilities.Ffpfsc;

/// <summary>
/// Single-PKG PS4 → FFPFSC converter. Pipeline (mirrors the SadykovIV
/// ps4ffpsc flow adapted for in-process OrbisPkgTool extraction):
/// <list type="number">
/// <item>Extract the PKG into a temp work directory (Image0/ + Sc0/).</item>
/// <item>Restructure: move Sc0 system files into Image0/sce_sys/ (the PS5
/// dump layout that ShadowMountPlus expects; npbind.dat, trophy/, etc.).</item>
/// <item>Project param.sfo → sce_sys/param.json (localized titles, en-US
/// fallback, userDefinedParam mirror).</item>
/// <item>Repair the sce_sys/npbind.dat SHA-1 footer on the temp copy only.</item>
/// <item>Build the FFPFSC container: exFAT image (deterministic MkPFS layout)
/// → PFSC compression → unsigned PS5-profile PFS wrapper, inner name
/// <c>TITLE_ID.exfat</c>.</item>
/// <item>Verify the container (structure + every PFSC block decodes).</item>
/// </list>
/// The PKG source file is only ever opened read-only.
/// </summary>
public sealed class Ps4FfpfscConverterService
{
    private const int TotalSteps = 6;

    /// <summary>
    /// Converts a single PS4 PKG into a <c>.ffpfsc</c> image for
    /// ShadowMountPlus. Returns (succeeded, message, result); on failure the
    /// message carries the user-facing reason and the work directory is
    /// cleaned unless <c>KeepWorkDirectory</c> is set.
    /// </summary>
    public async Task<(bool Succeeded, string Message, FfpfscConvertResult? Result)> ConvertAsync(
        FfpfscConvertOptions options,
        IProgress<FfpfscConvertProgress>? progress = null,
        CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(options);

        string workRoot = Path.Combine(
            Path.GetFullPath(options.WorkParentDirectory),
            "ffpfsc_" + Guid.NewGuid().ToString("N"));
        string extracted = Path.Combine(workRoot, "extracted");

        try
        {
            // ── Step 1: extract ─────────────────────────────────────────
            string pkgFileName = Path.GetFileName(options.PkgPath);
            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.Extracting, 1, TotalSteps,
                CurrentFile: pkgFileName));
            var extractor = new PkgExtractionService(options.Passcode);
            // Bridge the per-file extraction progress into the converter's
            // FfpfscConvertProgress so the dialog shows "Extracting 1/345: <file>".
            var fileProgress = progress is null
                ? null
                : new Progress<(int Current, int Total, string File)>(p =>
                    progress.Report(new FfpfscConvertProgress(
                        FfpfscConvertStages.Extracting, 1, TotalSteps,
                        ItemsProcessed: p.Current + 1, ItemsTotal: p.Total,
                        CurrentFile: p.File)));
            var (succeeded, message) = await extractor.ExtractFullAsync(options.PkgPath, extracted, null, ct, fileProgress, logCompletion: false)
                .ConfigureAwait(false);
            if (!succeeded)
                return (false, "Extraction failed: " + message, null);

            string image0 = Path.Combine(extracted, "Image0");
            if (!Directory.Exists(image0))
                return (false, "The package does not contain an application image (no game data to convert).", null);

            // ── Step 2: restructure Sc0 → Image0/sce_sys ────────────────
            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.Restructuring, 2, TotalSteps));
            RestructureSc0IntoSceSys(extracted, ct);

            // ── Step 3: project param.json ──────────────────────────────
            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.ProjectingParamJson, 3, TotalSteps));
            string sfoPath = Path.Combine(image0, "sce_sys", "param.sfo");
            if (!File.Exists(sfoPath))
                return (false, "The package does not contain sce_sys/param.sfo — cannot derive title metadata.", null);
            ParamSfo sfo = ParamSfo.Parse(File.ReadAllBytes(sfoPath));
            string titleId = (sfo.GetString("TITLE_ID") ?? "").Trim();
            if (titleId.Length != 9)
                return (false, $"Invalid TITLE_ID in param.sfo: '{titleId}' (expected a 9-character CUSA/XXXX id).", null);

            string titleName = ParamJsonProjector.ChooseTitle(sfo);
            string jsonPath = Path.Combine(image0, "sce_sys", "param.json");
            byte[]? existingJson = File.Exists(jsonPath) ? File.ReadAllBytes(jsonPath) : null;
            byte[] projected = ParamJsonProjector.Build(titleId, titleName, sfo, existingJson);
            File.WriteAllBytes(jsonPath, projected);

            // ── Step 4: npbind footer repair (temp copy only) ───────────
            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.RepairingNpbind, 4, TotalSteps));
            bool npbindRepaired = false;
            try { npbindRepaired = NpbindFooterRepair.TryRepairInPlace(image0); }
            catch (InvalidDataException) { /* structurally-bad npbind is a soft failure — PS4-only, not required by the console */ }

            // ── Step 5: build the FFPFSC container ──────────────────────
            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.Building, 5, TotalSteps));
            var buildOptions = new FfpfscBuildOptions
            {
                InnerFileName = titleId + ".exfat",
                OverwriteExisting = true,
                Compression = new PfscCompressionOptions(),
            };
            var pfscProgress = progress is null
                ? null
                : new Progress<FfpfscProgress>(value => progress.Report(new FfpfscConvertProgress(
                    FfpfscConvertStages.Building, 5, TotalSteps,
                    value.BytesProcessed, value.TotalBytes)));
            FfpfscBuildResult build = await FfpfscImage.CreateFromDirectoryAsync(image0, options.OutputPath,
                buildOptions, null, pfscProgress, ct).ConfigureAwait(false);

            // ── Step 6: verify ──────────────────────────────────────────
            FfpfscVerificationResult? verification = null;
            if (options.VerifyAfterBuild)
            {
                progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.Verifying, 6, TotalSteps));
                var verifyProgress = progress is null
                    ? null
                    : new Progress<FfpfscProgress>(value => progress.Report(new FfpfscConvertProgress(
                        FfpfscConvertStages.Verifying, 6, TotalSteps,
                        value.BytesProcessed, value.TotalBytes)));
                verification = await FfpfscImage.VerifyAsync(options.OutputPath, null, verifyProgress, ct)
                    .ConfigureAwait(false);
            }

            var result = new FfpfscConvertResult(
                build.OutputPath,
                build.InnerFileName,
                build.SourceLength,
                build.ContainerLength,
                build.PfscBlockCount,
                build.CompressedBlockCount,
                build.PayloadSavingsPercent,
                verification,
                npbindRepaired);

            progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.Done, TotalSteps, TotalSteps));
            return (true, "", result);
        }
        catch (OperationCanceledException)
        {
            return (false, "Cancelled", null);
        }
        catch (Exception ex)
        {
            return (false, "Conversion failed: " + ex.Message, null);
        }
        finally
        {
            // Always clean up the work directory unless the caller asked to
            // keep it, regardless of which path returned (success, early
            // failure, cancellation, or an unhandled exception).
            if (!options.KeepWorkDirectory)
            {
                progress?.Report(new FfpfscConvertProgress(FfpfscConvertStages.CleaningUp, TotalSteps, TotalSteps));
                TryDeleteDirectory(workRoot);
            }
        }
    }

    /// <summary>
    /// Moves every file from the extracted <c>Sc0/</c> layer into
    /// <c>Image0/sce_sys/</c> (same restructure as the merge service: the PS5
    /// dump layout keeps all system files in one sce_sys directory).
    /// Existing destinations are overwritten. An absent Sc0 is not an error.
    /// </summary>
    private static void RestructureSc0IntoSceSys(string extracted, CancellationToken ct)
    {
        string sc0 = Path.Combine(extracted, "Sc0");
        string sceSys = Path.Combine(extracted, "Image0", "sce_sys");
        if (!Directory.Exists(sc0)) return;
        Directory.CreateDirectory(sceSys);
        foreach (string file in Directory.GetFiles(sc0, "*", SearchOption.AllDirectories))
        {
            ct.ThrowIfCancellationRequested();
            string destination = Path.Combine(sceSys, Path.GetRelativePath(sc0, file));
            Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
            File.Move(file, destination, overwrite: true);
        }
        TryDeleteDirectory(sc0);
    }

    private static void TryDeleteDirectory(string path)
    {
        try
        {
            if (Directory.Exists(path))
                Directory.Delete(path, recursive: true);
        }
        catch (IOException ex)
        {
            // A failed cleanup (e.g. over a full or flaky SMB share) leaves an
            // orphaned multi-GB temp tree. Log it instead of swallowing it so
            // the operator can reclaim the space manually.
            CoreLog.Warn($"FFPFSC: failed to delete work directory {path}: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            CoreLog.Warn($"FFPFSC: failed to delete work directory {path}: {ex.Message}");
        }
    }
}

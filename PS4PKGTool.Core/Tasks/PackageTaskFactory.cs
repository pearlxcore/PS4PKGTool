using System.Text.Json;
using PS4PKGTool.Utilities.PkgInspection;
using PS4PKGTool.Utilities.TaskQueue;
using OrbisPkgTool;
using OrbisPkgTool.Pfs;
using OrbisPkgTool.Pkg;
using PS4PKGTool.Utilities.Ffpfsc;

namespace PS4PKGTool.Core.Tasks;

public interface IPackageTaskFactory
{
    QueuedPackageTask CreateFullExtraction(string packagePath, string outputDirectory, string? displayName = null, Guid? id = null, PersistedQueueTask? saved = null, ExtractLayout layout = ExtractLayout.Merged);
    QueuedPackageTask? Restore(PersistedQueueTask saved);
    QueuedPackageTask CreateMerge(PkgMergeRequest request, string displayName, Guid? id = null, PersistedQueueTask? saved = null);
    QueuedPackageTask CreateFfpfsc(FfpfscConvertOptions options, string displayName, Guid? id = null, PersistedQueueTask? saved = null);
}

/// <summary>Constructs queue tasks from reusable package operations; no UI ownership.</summary>
public sealed class PackageTaskFactory(IPackageExtractionService? extractionService = null) : IPackageTaskFactory
{
    private readonly IPackageExtractionService _extractionService = extractionService ?? new PkgExtractionService();

    public QueuedPackageTask CreateFullExtraction(string packagePath, string outputDirectory, string? displayName = null, Guid? id = null, PersistedQueueTask? saved = null, ExtractLayout layout = ExtractLayout.Merged)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packagePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(outputDirectory);
        var task = new QueuedPackageTask("Full Extract", displayName ?? $"Extract: {Path.GetFileName(packagePath)}", packagePath, outputDirectory,
            async (queued, cancellationToken) =>
            {
                var progress = new Progress<(int Current, int Total, string CurrentFile)>(p =>
                {
                    string file = layout == ExtractLayout.Merged ? DumpLayout.MapToLogical(p.CurrentFile) : p.CurrentFile;
                    queued.Report(new QueueTaskProgress("Extracting PKG", 1, 1, CurrentItems: p.Current + 1, TotalItems: p.Total, CurrentFile: file));
                });
                var stage = new Progress<string>(message => queued.Log($"Extract: {message}"));
                var result = await _extractionService.ExtractFullAsync(packagePath, outputDirectory, stage, cancellationToken, progress, logCompletion: true, layout: layout).ConfigureAwait(false);
                queued.Log(result.Succeeded ? "Extract finished." : "Extract failed: " + result.Message);
                return new QueueTaskExecutionResult(result.Succeeded, result.Message, outputDirectory);
            }, JsonSerializer.Serialize(new ExtractionTaskPayload { OutputDirectory = outputDirectory, Layout = layout }), id);
        if (saved is not null) task.RestoreState(saved);
        return task;
    }

    public QueuedPackageTask? Restore(PersistedQueueTask saved)
    {
        if (saved.Type != "Full Extract") return null;
        if (string.IsNullOrWhiteSpace(saved.Payload)) return null;
        try
        {
            var payload = JsonSerializer.Deserialize<ExtractionTaskPayload>(saved.Payload);
            return payload is null ? null : CreateFullExtraction(saved.Source, payload.OutputDirectory, saved.DisplayName, saved.Id, saved, payload.Layout);
        }
        catch (JsonException) { return null; }
    }

    public QueuedPackageTask CreateMerge(PkgMergeRequest request, string displayName, Guid? id = null, PersistedQueueTask? saved = null)
    {
        ArgumentNullException.ThrowIfNull(request); ArgumentException.ThrowIfNullOrWhiteSpace(displayName);
        var task = new QueuedPackageTask("Merge PKG", displayName, request.BasePkgPath, request.OutputPkgPath, async (queued, ct) =>
        {
            string? lastStage = null;
            var progress = new Progress<PkgMergeProgress>(p =>
            {
                queued.Report(new QueueTaskProgress(p.Stage, p.Step, p.TotalSteps, p.CurrentBytes, p.TotalBytes, p.CurrentItem + 1, p.TotalItems, p.CurrentFile));
                // Stage changes only: per-file progress would flood the log tab.
                if (!string.Equals(p.Stage, lastStage, StringComparison.Ordinal))
                {
                    lastStage = p.Stage;
                    queued.Log($"Merge: {p.Stage}" + (p.TotalSteps > 0 ? $" (step {p.Step}/{p.TotalSteps})" : ""));
                }
            });
            queued.Log($"Merge started: {request.BasePkgPath} + {request.UpdatePkgPath}");
            try
            {
                var result = await Task.Run(() => new PkgMergeService().Merge(request with { Progress = progress, CancellationToken = ct }), ct).ConfigureAwait(false);
                queued.Log($"Merge finished: {result.OutputPkgPath} ({result.OutputSize / 1e9:F2} GB, {result.Elapsed.TotalSeconds:F0}s)");
                return new QueueTaskExecutionResult(true, "Merged PKG created.", result.OutputPkgPath);
            }
            catch (OperationCanceledException)
            {
                queued.Log("Merge cancelled.");
                throw;
            }
            catch (Exception ex)
            {
                queued.Log("Merge failed: " + ex.Message);
                throw;
            }
        }, JsonSerializer.Serialize(new MergeTaskPayload(request.BasePkgPath, request.UpdatePkgPath, request.OutputPkgPath, null, null, request.ValidateAfterBuild, request.PfscMode, request.WorkerCount, request.WorkDirectory, request.KeepWorkDirectory, request.CleanupWorkDirectoryOnFailure, request.Title, request.TitleId, request.ContentId, request.SkipDiskSpaceCheck)), id); if (saved is not null) task.RestoreState(saved); return task;
    }

    public QueuedPackageTask CreateFfpfsc(FfpfscConvertOptions options, string displayName, Guid? id = null, PersistedQueueTask? saved = null)
    {
        ArgumentNullException.ThrowIfNull(options); ArgumentException.ThrowIfNullOrWhiteSpace(displayName);
        var task = new QueuedPackageTask("PKG → FFPFSC", displayName, options.PkgPath, options.OutputPath, async (queued, ct) =>
        {
            string? lastStage = null;
            var progress = new Progress<FfpfscConvertProgress>(p =>
            {
                queued.Report(new QueueTaskProgress(p.Stage, p.CurrentStep, p.TotalSteps, p.BytesProcessed, p.TotalBytes, p.ItemsProcessed, p.ItemsTotal, p.CurrentFile));
                if (!string.Equals(p.Stage, lastStage, StringComparison.Ordinal))
                {
                    lastStage = p.Stage;
                    queued.Log($"FFPFSC: {p.Stage}");
                }
            });
            var result = await new Ps4FfpfscConverterService().ConvertAsync(options, progress, ct).ConfigureAwait(false);
            queued.Log(result.Succeeded
                ? "FFPFSC finished: " + (result.Result?.OutputPath ?? options.OutputPath)
                : "FFPFSC failed: " + result.Message);
            return new QueueTaskExecutionResult(result.Succeeded, result.Message, result.Result?.OutputPath ?? options.OutputPath);
        }, JsonSerializer.Serialize(options with { Passcode = null }), id); if (saved is not null) task.RestoreState(saved); return task;
    }

    // No primary constructor: System.Text.Json uses the parameterless constructor
    // and init properties, so an older payload without Layout keeps the default
    // (Merged) instead of silently falling back to Raw.
    private sealed record ExtractionTaskPayload
    {
        public string OutputDirectory { get; init; } = string.Empty;
        public ExtractLayout Layout { get; init; } = ExtractLayout.Merged;
    }
    private sealed record MergeTaskPayload(string BasePkgPath, string UpdatePkgPath, string? OutputPkgPath, string? BasePasscode, string? UpdatePasscode, bool ValidateAfterBuild, PfscMode PfscMode, int WorkerCount, string? WorkDirectory, bool KeepWorkDirectory, bool CleanupWorkDirectoryOnFailure, string? Title, string? TitleId, string? ContentId, bool SkipDiskSpaceCheck);
}

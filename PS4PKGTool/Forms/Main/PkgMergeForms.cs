using DarkUI.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace PS4PKGTool
{
    internal sealed record PkgMergePackage(string Path, string Title, string TitleId, string Version, string Category);

    internal sealed record PkgMergeOptions(string OutputPath, string WorkParentDirectory,
        bool ValidateAfterBuild, int WorkerCount, bool IgnoreDiskSpaceCheck);

    internal sealed partial class PkgMergeOptionsForm : DarkForm
    {
        private readonly long _basePkgSize;
        private readonly long _patchPkgSize;

        public PkgMergeOptions? Options { get; private set; }

        public PkgMergeOptionsForm(PkgMergePackage basePkg, PkgMergePackage patchPkg)
        {
            InitializeComponent();

            txtBaseGame.Text = basePkg.Path;
            txtUpdate.Text = patchPkg.Path;
            txtTitleId.Text = basePkg.TitleId;
            txtVersions.Text = $"Base: {basePkg.Version}    Update: {patchPkg.Version}";
            _outputPath.Text = "";
            _workParent.Text = DefaultWorkParent();

            _basePkgSize = GetFileSize(basePkg.Path);
            _patchPkgSize = GetFileSize(patchPkg.Path);
            UpdateSpaceWarning(this, EventArgs.Empty);
        }

        private static long GetFileSize(string path)
        {
            try { return new FileInfo(path).Length; }
            catch { return 0; }
        }

        /// <summary>
        /// Prefer the configured PKG extraction temp directory so the Settings
        /// override also drives the merge's extraction dumps and build temp.
        /// </summary>
        private static string DefaultWorkParent()
            => PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.ResolveTempRoot();

        private void UpdateSpaceWarning(object? sender, EventArgs e)
        {
            try
            {
                string work = _workParent.Text.Trim();
                if (string.IsNullOrWhiteSpace(work) || _basePkgSize <= 0)
                {
                    lblSpaceWarning.Text = "";
                    return;
                }

                // The work drive holds BOTH the extracted dumps and the
                // builder's streaming temp (inner.pfs + inner.pfsc + outer.pfs).
                // The build peak is ~3.45x the inner PFS, plus the merged dump
                // (~1x) already on the work drive. estInner is proxied with the
                // combined PKG sizes; the builder re-checks the real packaged
                // sizes and aborts with the exact numbers before writing.
                // Kept in sync with PfsFormat.TempDiskMultiplier.
                const double TempDiskMultiplier = 3.2;
                long estInner = _basePkgSize + _patchPkgSize;
                long buildTemp = (long)(estInner * TempDiskMultiplier) + estInner / 4;
                long output = estInner / 4 + estInner;
                long needed = buildTemp + output;
                long free = PS4PKGTool.Utilities.PS4PKGToolHelper.DiskSpaceHelper.GetAvailableFreeSpace(work);
                if (free < 0)
                {
                    lblSpaceWarning.Text = "";
                    return;
                }

                string freeText = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.RoundBytes(free);
                string needText = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.RoundBytes(needed);
                if (free < needed)
                {
                    lblSpaceWarning.ForeColor = System.Drawing.Color.OrangeRed;
                    lblSpaceWarning.Text = $"Low disk space: only {freeText} free on the work drive, but ~{needText} is estimated to be needed.";
                }
                else
                {
                    lblSpaceWarning.ForeColor = System.Drawing.Color.Silver;
                    lblSpaceWarning.Text = $"{freeText} free · ~{needText} estimated needed.";
                }
            }
            catch
            {
                lblSpaceWarning.Text = "";
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e) => BrowseOutput();

        private void btnBrowseWork_Click(object sender, EventArgs e) => BrowseWorkLocation();

        private void btnMerge_Click(object sender, EventArgs e) => Confirm();

        private void BrowseOutput()
        {
            string output = _outputPath.Text.Trim();
            string initialDirectory = string.IsNullOrWhiteSpace(output)
                ? Path.GetDirectoryName(txtBaseGame.Text)
                : Path.GetDirectoryName(output);
            string fileName = string.IsNullOrWhiteSpace(output)
                ? Path.GetFileNameWithoutExtension(txtBaseGame.Text) + "_merged.pkg"
                : Path.GetFileName(output);

            using var dialog = new SaveFileDialog
            {
                Filter = "PS4 Package (*.pkg)|*.pkg",
                FileName = fileName,
                InitialDirectory = string.IsNullOrWhiteSpace(initialDirectory) ? Environment.CurrentDirectory : initialDirectory
            };
            if (dialog.ShowDialog(this) == DialogResult.OK) _outputPath.Text = dialog.FileName;
        }

        private void BrowseWorkLocation()
        {
            using var dialog = new FolderBrowserDialog { InitialDirectory = _workParent.Text };
            if (dialog.ShowDialog(this) == DialogResult.OK) _workParent.Text = dialog.SelectedPath;
        }

        private void Confirm()
        {
            string output = _outputPath.Text.Trim();
            string workParent = _workParent.Text.Trim();
            if (string.IsNullOrWhiteSpace(output) || !output.EndsWith(".pkg", StringComparison.OrdinalIgnoreCase))
            {
                ShowWarning("Choose an output PKG filename.", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(workParent))
            {
                ShowWarning("Choose a work location.", false);
                return;
            }

            try
            {
                workParent = Path.GetFullPath(workParent);
                Directory.CreateDirectory(workParent);
            }
            catch (Exception ex)
            {
                ShowWarning("The work location could not be created:\n" + ex.Message, false);
                return;
            }

            Options = new PkgMergeOptions(output, workParent, _validate.Checked, (int)_workers.Value, _ignoreDiskSpace.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

}

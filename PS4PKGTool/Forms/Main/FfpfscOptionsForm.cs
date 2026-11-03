#nullable enable
using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PS4PKGTool.Utilities.Ffpfsc;

namespace PS4PKGTool.Forms.Main
{
    /// <summary>
    /// Options dialog for the single-PKG PS4 → FFPFSC conversion. Mirrors the
    /// layout of <see cref="PkgMergeOptionsForm"/> but adapted for one PKG.
    /// </summary>
    internal sealed partial class FfpfscOptionsForm : DarkForm
    {
        private readonly long _pkgSize;
        private readonly bool _isBatch;

        public FfpfscConvertOptions? Options { get; private set; }

        public FfpfscOptionsForm(string pkgPath, string title, string titleId, string version)
        {
            InitializeComponent();

            _txtSource.Text = pkgPath;
            _txtTitle.Text = title;
            _txtTitleId.Text = titleId;
            _txtVersion.Text = version;

            _outputPath.Text = "";
            _workParent.Text = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.ResolveTempRoot();

            _pkgSize = GetFileSize(pkgPath);
            UpdateSpaceWarning(this, EventArgs.Empty);
        }

        public FfpfscOptionsForm(IReadOnlyList<string> pkgPaths)
        {
            if (pkgPaths == null || pkgPaths.Count == 0)
                throw new ArgumentException("At least one PKG path is required.", nameof(pkgPaths));

            InitializeComponent();
            _isBatch = true;
            _txtSource.Text = $"{pkgPaths.Count} PKGs selected";
            _txtTitle.Text = "Multiple PKGs";
            _txtTitleId.Text = "Multiple";
            _txtVersion.Text = "Multiple";
            _lblSource.Text = "Sources";
            _lblOutput.Text = "Output folder";
            _outputPath.Text = Path.GetDirectoryName(pkgPaths[0]) ?? "";
            _workParent.Text = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.ResolveTempRoot();
            _pkgSize = pkgPaths.Sum(GetFileSize);
            UpdateSpaceWarning(this, EventArgs.Empty);
        }

        private static long GetFileSize(string path)
        {
            try { return new FileInfo(path).Length; }
            catch { return 0; }
        }

        private void UpdateSpaceWarning(object? sender, EventArgs e)
        {
            try
            {
                string work = _workParent.Text.Trim();
                if (string.IsNullOrWhiteSpace(work) || _pkgSize <= 0)
                {
                    _lblSpaceWarning.Text = "";
                    return;
                }

                long needed = _pkgSize * 2;
                long free = PS4PKGTool.Utilities.PS4PKGToolHelper.DiskSpaceHelper.GetAvailableFreeSpace(work);
                if (free < 0)
                {
                    _lblSpaceWarning.Text = "";
                    return;
                }

                string freeText = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.RoundBytes(free);
                string needText = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.RoundBytes(needed);
                if (free < needed)
                {
                    _lblSpaceWarning.ForeColor = System.Drawing.Color.OrangeRed;
                    _lblSpaceWarning.Text = $"Low disk space: only {freeText} free on the work drive, but ~{needText} is estimated to be needed.";
                }
                else
                {
                    _lblSpaceWarning.ForeColor = System.Drawing.Color.Silver;
                    _lblSpaceWarning.Text = $"{freeText} free · ~{needText} estimated needed.";
                }
            }
            catch
            {
                _lblSpaceWarning.Text = "";
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            if (_isBatch)
            {
                using var folderDialog = new FolderBrowserDialog { InitialDirectory = _outputPath.Text };
                if (folderDialog.ShowDialog(this) == DialogResult.OK)
                    _outputPath.Text = folderDialog.SelectedPath;
                return;
            }

            string output = _outputPath.Text.Trim();
            string initialDirectory = string.IsNullOrWhiteSpace(output)
                ? Path.GetDirectoryName(_txtSource.Text)
                : Path.GetDirectoryName(output);
            string fileName = string.IsNullOrWhiteSpace(output)
                ? Path.GetFileNameWithoutExtension(_txtSource.Text) + ".ffpfsc"
                : Path.GetFileName(output);

            using var dialog = new SaveFileDialog
            {
                Filter = "FFPFSC image (*.ffpfsc)|*.ffpfsc|All Files (*.*)|*.*",
                FileName = fileName,
                InitialDirectory = string.IsNullOrWhiteSpace(initialDirectory) ? Environment.CurrentDirectory : initialDirectory
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
                _outputPath.Text = dialog.FileName;
        }

        private void btnBrowseWork_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog { InitialDirectory = _workParent.Text };
            if (dialog.ShowDialog(this) == DialogResult.OK)
                _workParent.Text = dialog.SelectedPath;
        }

        private void btnConvert_Click(object sender, EventArgs e) => Confirm();

        private void Confirm()
        {
            string output = _outputPath.Text.Trim();
            string workParent = _workParent.Text.Trim();
            if (string.IsNullOrWhiteSpace(output) || (!_isBatch && !output.EndsWith(".ffpfsc", StringComparison.OrdinalIgnoreCase)))
            {
                ShowWarning(_isBatch ? "Choose an output folder." : "Choose an output .ffpfsc filename.", false);
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
                if (_isBatch)
                {
                    output = Path.GetFullPath(output);
                    Directory.CreateDirectory(output);
                }
            }
            catch (Exception ex)
            {
                ShowWarning("The work location could not be created:\n" + ex.Message, false);
                return;
            }

            Options = new FfpfscConvertOptions(
                PkgPath: _txtSource.Text.Trim(),
                OutputPath: output,
                WorkParentDirectory: workParent,
                VerifyAfterBuild: _validate.Checked,
                KeepWorkDirectory: false);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

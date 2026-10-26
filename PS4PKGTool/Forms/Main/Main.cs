using ByteSizeLib;
using ClosedXML.Excel;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using GitHubUpdate;
using Irony;
using Newtonsoft.Json;
using PS4_Trophy_xdpx;
using PS4PKGTool.Util;
using PS4PKGTool.Util.Constants;
using PS4PKGTool.Utilities.Constants;
using PS4PKGTool.Utilities.PkgInspection;
using PS4PKGTool.Utilities.PkgMeta;
using PS4PKGTool.Utilities.PS4PKGToolHelper;
using PS4PKGTool.Utilities.Settings;
using PS4PKGTool.Utilities.Shadps4;
using PS4PKGTool.Utilities.TrophyMetadata;
using PS4PKGTool.Utilities.Ffpfsc;
using PS4PKGTool.Utilities.TaskQueue;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethodInvoker = System.Windows.Forms.MethodInvoker;
using OrbisPkgTool.Pkg;
using TRPViewer;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.Backport;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.Entry;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Bitmap = System.Drawing.Bitmap;
using Entry = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.Entry;
using ListView = System.Windows.Forms.ListView;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using TreeView = PS4PKGTool.Utilities.PS4PKGToolHelper.Helper.TreeView;

namespace PS4PKGTool
{
    public partial class Main : DarkUI.Forms.DarkForm
    {
        private const string DefaultOrbisPasscode = PkgFileListingService.DefaultPasscode;
        private MemoryMappedFile pkgFile;
        private dynamic send_pkg_json;
        private string TEMPFILENAMESENDPKG;
        private bool renameBackFile;
        internal static string filenameDLC;
        private static string ApplicationVersion { get; set; }
        private readonly List<string> ExcludedDirectoryList = new List<string>() { "System Volume Information", "$RECYCLE.BIN", "$Recycle.Bin" };

        // Filter state for tree/list view filtering (tabPage7)
        private ListViewItem _upItem;
        private readonly List<ListViewItem> _allItems = new();
        private bool _populating;
        private bool _filtering;
        private TreeNode _currentNode;
        private readonly Dictionary<string, long> _fileSizes = new();   // PKG path → file size

        /// <summary>
        /// Clears the file-browser tree, list view, and all filter state.
        /// MUST be used instead of bare Nodes.Clear() - the filter state
        /// (rootNodes/_currentNode/_allItems) references nodes that throw
        /// InvalidOperationException on FullPath once detached from the tree.
        /// </summary>
        private void ClearFileBrowser()
        {
            Interlocked.Increment(ref _previewVersion);
            ResetMainProgressBar();
            PKGTreeView.Nodes.Clear();
            listView1.Items.Clear();
            rootNodes = null;
            _currentNode = null;
            _allItems.Clear();
            _upItem = null;
            _populating = false;
            _filtering = false;
            // Reset the viewer pane
            txtPreview.Visible = false;
            txtHexPreview.Visible = false;
            picPreview.Visible = false;
            picPreview.Image?.Dispose();
            picPreview.Image = null;
            lblFileViewerInfo.Text = "Select a file to preview it.";
            if (btnExportTextures != null) btnExportTextures.Enabled = false;
            if (btnExportTreeView != null) btnExportTreeView.Enabled = false;
            _previewEntryPath = null;
            _previewIsUnityFile = false;
            _pathMap = new PS4PKGTool.Utilities.PkgInspection.PkgPathMap();
            _pkgEntries = new List<PkgFileEntry>();
            _treeRootName = string.Empty;
            _fileSizes.Clear();
            _pkgDirectories.Clear();
            CleanupContainerBrowse();
        }

        private void ResetMainProgressBar()
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;
        }
        private int _trophyLoadVersion;
        private readonly ConcurrentDictionary<string, SemaphoreSlim> _trophyExtractionLocks = new(StringComparer.OrdinalIgnoreCase);
        private HashSet<string> _pkgDirectories = new();   // paths that are directories (from orbis D lines)
        // Logical (flattened) <-> raw entry resolver and the full entry list for the current listing.
        private PkgPathMap _pathMap = new();
        private List<PkgFileEntry> _pkgEntries = new();
        // Name of the single synthetic root folder the flattened tree is shown under
        // (e.g. the Title ID). Empty when no wrapper is used.
        private string _treeRootName = string.Empty;
        private int _glvGroupHeaderIndex = -1;   // group header row index last right-clicked in GLV
        private List<string> _glvContextGroupPaths = new();
        private ToolStripMenuItem? _glvGroupTitleMenu;
        private readonly ConcurrentQueue<string> _pendingLogLines = new();
        private bool _glvCollapseDone;
        private string _glvColumnSignature = string.Empty;
        private readonly int _pkgListTabTopGap;
        private readonly int _pkgListTabBottomGap;
        private bool _pkgListLayoutInitialized;
        private bool _packageOperationsEnabled;
        private readonly TaskQueueService _taskQueue = new();

        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("user32.dll")]
        private static extern bool ChangeWindowMessageFilter(uint msg, uint flags);

        private byte[] old_byte;

        public static string GetApplicationVersion()
        {
            // Get the entry assembly (usually represents the current application)
            Assembly entryAssembly = Assembly.GetEntryAssembly();

            // Get the custom attribute for the AssemblyInformationalVersionAttribute
            // This attribute should be set in the project's Properties/AssemblyInfo.cs file
            AssemblyInformationalVersionAttribute versionAttribute =
                entryAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            // Retrieve and return the version string
            return versionAttribute?.InformationalVersion ?? "Version information not available";
        }

        public Main()
        {
            InitializeComponent();

            // The WinForms designer must only construct the controls from
            // Main.Designer.cs. Runtime services access files, timers, shell
            // integration, and queue workers, which are not available in the
            // designer host process.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            InitializeTaskQueue();
            ThemeManager.ThemeChanged += Main_ThemeChanged;
            // Start with package-dependent actions disabled. A successful PKG
            // load enables them, while Launch Empty keeps this state intact.
            SetOperationMenusEnabled(false);
            _logFlushTimer.Start();
            // Preserve the visual spacing set in Main.Designer.cs when the
            // filter group changes height at runtime (for example, when its
            // filter controls reflow after the maximized form becomes wider).
            _pkgListTabTopGap = Math.Max(0, subTabControl.Top - grpFilter.Bottom);
            _pkgListTabBottomGap = Math.Max(0, tabPage1.ClientSize.Height - subTabControl.Bottom);
            _pkgListLayoutInitialized = true;
            // Crossing monitors with a different DPI re-runs DarkLabel's font
            // height pass, which re-queues its grow after this form-level
            // event — align only once that queued work has drained, hence the
            // nested invoke.
            DpiChanged += (s, e) => BeginInvoke(() => BeginInvoke(AlignFilterRowLabels));

            // Tag-bind image/icon extraction menu items for data-driven dispatch
            globalExtractImagesAndIconToolStripMenuItem1.Tag = $"{ImageIconExtractionType.ALL}|{PKGSelectionType.ALL}";
            globalExtractImagesAndIconToolStripMenuItem2.Tag = $"{ImageIconExtractionType.ALL}|{PKGSelectionType.ALL}";
            globalExtractImageOnlyToolStripMenuItem1.Tag     = $"{ImageIconExtractionType.IMAGE}|{PKGSelectionType.ALL}";
            globalExtractImageOnlyToolStripMenuItem2.Tag     = $"{ImageIconExtractionType.IMAGE}|{PKGSelectionType.ALL}";
            globalExtractIconOnlyToolStripMenuItem1.Tag      = $"{ImageIconExtractionType.ICON}|{PKGSelectionType.ALL}";
            globalExtractIconOnlyToolStripMenuItem2.Tag      = $"{ImageIconExtractionType.ICON}|{PKGSelectionType.ALL}";
            selectedExtractImagesAndIconToolStripMenuItem1.Tag = $"{ImageIconExtractionType.ALL}|{PKGSelectionType.SELECTED}";
            selectedExtractImagesAndIconToolStripMenuItem2.Tag = $"{ImageIconExtractionType.ALL}|{PKGSelectionType.SELECTED}";
            selectedExtractImageOnlyToolStripMenuItem1.Tag     = $"{ImageIconExtractionType.IMAGE}|{PKGSelectionType.SELECTED}";
            selectedExtractImageOnlyToolStripMenuItem2.Tag     = $"{ImageIconExtractionType.IMAGE}|{PKGSelectionType.SELECTED}";
            selectedExtractIconOnlyToolStripMenuItem1.Tag      = $"{ImageIconExtractionType.ICON}|{PKGSelectionType.SELECTED}";
            selectedExtractIconOnlyToolStripMenuItem2.Tag      = $"{ImageIconExtractionType.ICON}|{PKGSelectionType.SELECTED}";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            PKGGridView.ScrollBars = ScrollBars.Vertical;
            darkDataGridView2.ScrollBars = ScrollBars.Vertical;
            TrophyGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TrophyGridView.ScrollBars = ScrollBars.Vertical;

            this.ActiveControl = null;  //this = form
            toolStripProgressBar1.MarqueeAnimationSpeed = 30;

            // Bypass UIPI: allow drag-drop from Explorer when running as admin
            try { ChangeWindowMessageFilter(0x0233, 1); ChangeWindowMessageFilter(0x0049, 1); } catch (Exception ex) { Logger.LogWarning("UIPI bypass failed (non-critical): " + ex.Message); }

            // Wire drag-drop on the form and all child controls
            WireAllControls(this);

            ApplicationVersion = GetApplicationVersion();

            BalanceListViewColumns();

            // Filter textbox for tree/list view (built-in clear ✕ button)
            // Load treeview file-type icons from embedded resources
            try
            {
                var icons = new (string key, Bitmap bmp)[]
                {
                    ("folder",       Properties.Resources.tv_folder),
                    ("document",     Properties.Resources.tv_document),
                    ("image",        Properties.Resources.tv_image),
                    ("config",       Properties.Resources.tv_config),
                    ("binary",       Properties.Resources.tv_binary),
                    ("folder-open",  Properties.Resources.tv_folder_open),
                    ("audio",        Properties.Resources.tv_audio),
                    ("file-unknown", Properties.Resources.tv_file_unknown),
                    ("package",      Properties.Resources.tv_package),
                    ("video",        Properties.Resources.tv_video),
                    ("code",         Properties.Resources.tv_code),
                };
                foreach (var (key, bmp) in icons)
                    imageList1.Images.Add(key, new Bitmap(bmp));
            }
            catch (Exception ex) { Logger.LogWarning($"Icon load: {ex.Message}"); }

            // Collapse GLV groups on initial population (control must be visible first),
            // then keep the currently selected PKG visible by re-expanding its group.
            // GLV filter removed - the Table tab's tbSearchGame controls both views
            // via PopulateGroupedView() which rebuilds from the DGV's filtered DefaultView.

            groupedListView.GroupHeaderClicked += (headerIdx, groupName, args) =>
            {
                _glvGroupHeaderIndex = headerIdx;
                contextMenuGLV.Show(Cursor.Position);
            };
            // Keep the captured paths until the next Opening event. WinForms may
            // close a context menu before it invokes the selected item's Click
            // handler; clearing here made every GLV action see an empty group.
            // Opening always replaces this list with the current group.

            Logger.OnLog += Logger_OnLog;
        }

        private void Logger_OnLog(string line)
        {
            if (_tbLogBox == null || IsDisposed) return;
            string text = Logger.NormalizeNewlines(line).TrimEnd('\r', '\n');
            _pendingLogLines.Enqueue(text);
        }

        private void GroupedViewRefreshTimer_Tick(object sender, EventArgs e)
        {
            _groupedViewRefreshTimer.Stop();
            PopulateGroupedView();
        }

        private void LogFlushTimer_Tick(object sender, EventArgs e) => FlushPendingLogLines();

        private void Main_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
                e.Effect = DragDropEffects.Copy;
        }

        private void PKGGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) => e.Cancel = true;

        private void PKGGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var hit = PKGGridView.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0 || hit.RowIndex >= PKGGridView.Rows.Count)
                return;

            if (!PKGGridView.Rows[hit.RowIndex].Selected)
            {
                PKGGridView.ClearSelection();
                PKGGridView.Rows[hit.RowIndex].Selected = true;
            }
            PKGGridView.CurrentCell = PKGGridView.Rows[hit.RowIndex].Cells[hit.ColumnIndex >= 0 ? hit.ColumnIndex : 0];
            UpdateOfficialUpdateMenuState();
        }

        private void TbFilterTreeView_SearchTextChanged(object sender, EventArgs e) => ApplyFilter();

        private void SubTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_glvCollapseDone || subTabControl.SelectedTab != tabPageGroup || groupedListView == null)
                return;

            _glvCollapseDone = true;
            BeginInvoke((MethodInvoker)delegate
            {
                groupedListView.CollapseAll();
                if (!string.IsNullOrEmpty(PKG.SelectedPKGFilename))
                    groupedListView.SelectFilePath(PKG.SelectedPKGFilename);
            });
        }

        private void BtnGroupExpand_Click(object sender, EventArgs e)
        {
            if (btnGroupExpand.Text == "Expand All")
            {
                groupedListView.ExpandAll();
                btnGroupExpand.Text = "Collapse All";
            }
            else
            {
                groupedListView.CollapseAll();
                btnGroupExpand.Text = "Expand All";
            }
        }

        private void CbGroupBy_SelectedIndexChanged(object sender, EventArgs e) => PopulateGroupedView();

        private void ContextMenuGLV_Opening(object sender, CancelEventArgs e)
        {
            bool titleIdGrouping = string.Equals(GroupByColumn, "Title ID", StringComparison.Ordinal);
            foreach (ToolStripItem item in _glvTitleIdOnlyMenuItems)
                item.Visible = titleIdGrouping;

            if (!titleIdGrouping)
            {
                _glvContextGroupPaths.Clear();
                return;
            }

            _glvContextGroupPaths = ResolveGlvContextGroupPaths();
            if (_glvShadps4UninstallMenu != null)
            {
                _glvShadps4UninstallMenu.Visible = _glvContextGroupPaths
                    .Select(GetGridRowForPath)
                    .Where(row => row != null)
                    .Any(row => row!.DataBoundItem is DataRowView dataRowView
                        && IsBaseGameRow(dataRowView.Row)
                        && IsShadps4Installed(dataRowView.Row));
            }
            if (_glvGroupTitleMenu == null)
                return;

            string titleId = _glvContextGroupPaths
                .Select(path => GetGridRowForPath(path)?.Cells[PkgColumns.TitleId].Value?.ToString())
                .FirstOrDefault(value => !string.IsNullOrWhiteSpace(value)) ?? "Group";
            _glvGroupTitleMenu.Text = $"{titleId} ({_glvContextGroupPaths.Count} PKG)";
        }

        private void contextMenuPKGGridView_Opening(object sender, CancelEventArgs e)
        {
            DataRow? row = GetSelectedGridRow();
            toolStripMenuItemShadps4Uninstall.Visible = row != null
                && IsBaseGameRow(row)
                && IsShadps4Installed(row);
        }

        private static bool IsBaseGameRow(DataRow row)
            => (row[PkgColumns.Category]?.ToString() ?? "").Contains(PKGCategory.GAME);

        private static bool IsShadps4Installed(DataRow row)
            => row.Table.Columns.Contains(PkgColumns.Shadps4Installed)
                && row[PkgColumns.Shadps4Installed] is true;

        private void FlushPendingLogLines()
        {
            if (_tbLogBox == null || IsDisposed || _pendingLogLines.IsEmpty) return;
            try
            {
                var batch = new StringBuilder();
                int count = 0;
                while (count++ < 500 && _pendingLogLines.TryDequeue(out string queuedLine))
                    batch.AppendLine(queuedLine);
                if (batch.Length == 0) return;

                _tbLogBox.AppendText(batch.ToString());
                if (_tbLogBox.Text.Length > 50000)
                    _tbLogBox.Text = _tbLogBox.Text.Substring(_tbLogBox.Text.Length - 40000);
            }
            catch { /* best-effort: textbox can disappear while the form closes */ }
        }

        private void Shadps4Launcher_Terminated(object? sender, Shadps4TerminationReport report)
        {
            // The watcher reports from a thread-pool thread - marshal to the
            // UI thread and silently abandon delivery when the form is gone
            // (same discipline as Logger_OnLog).
            try
            {
                if (IsDisposed || !IsHandleCreated) return;
                BeginInvoke((Action)(() =>
                {
                    var feedback = BuildGameFeedbackContext(report);
                    Shadps4TerminationUi.ShowIfNeeded(report, feedback);
                }));
            }
            catch { /* best-effort: form gone - termination report abandoned */ }
        }

        /// <summary>
        /// Resolves the game's title/version from the grid and the active
        /// core/launcher display names for the post-session feedback form.
        /// Null when the target is unknown (feedback is skipped).
        /// </summary>
        private GameFeedbackContext? BuildGameFeedbackContext(Shadps4TerminationReport report)
        {
            string titleId = report.Target ?? "";
            if (string.IsNullOrWhiteSpace(titleId)) return null;

            string title = "", version = "";
            DataTable? dt = (PKGGridView.DataSource as DataTable)
                ?? (PKGGridView.DataSource as DataView)?.Table;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.Equals(row[PkgColumns.TitleId]?.ToString(), titleId, StringComparison.OrdinalIgnoreCase))
                        continue;
                    title = row[PkgColumns.Title]?.ToString() ?? "";
                    version = row[PkgColumns.AppVersion]?.ToString() ?? "";
                    break;
                }
            }

            // The installed game's own param.sfo is the authoritative source
            // for name and version - the grid values only fill gaps.
            string installDir = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(installDir))
            {
                string sfoPath = Path.Combine(installDir, titleId, "sce_sys", "param.sfo");
                var info = ParamSfoReader.ReadGameInfo(sfoPath);
                if (info != null)
                {
                    if (!string.IsNullOrWhiteSpace(info.Value.Title)) title = info.Value.Title;
                    if (!string.IsNullOrWhiteSpace(info.Value.AppVersion)) version = info.Value.AppVersion;
                }
            }

            var coreSetting = Shadps4ActiveCore.Parse(appSettings_.Shadps4ActiveCore ?? "");
            string coreId = coreSetting.Source == Shadps4ComponentSource.Managed ? coreSetting.Value : "";

            return new GameFeedbackContext(
                titleId, title, version,
                Shadps4Compat.Lookup(titleId, appSettings_.Shadps4Os),
                Shadps4SetupDisplay.ComponentDisplayName(appSettings_.Shadps4ActiveCore, Shadps4Component.Core, appSettings_.Shadps4ManagedRoot),
                Shadps4SetupDisplay.ComponentDisplayName(appSettings_.Shadps4ActiveLauncher, Shadps4Component.QtLauncher, appSettings_.Shadps4ManagedRoot),
                Shadps4Compat.OsDisplay(appSettings_.Shadps4Os),
                Shadps4SetupDisplay.EmulatorVersion(appSettings_.Shadps4ActiveCore, appSettings_.Shadps4ManagedRoot),
                Shadps4ExitStatus.IsErrorStatus(report.Category) ? report.LogTail ?? "" : "",
                report.LogPath,
                (long)report.Runtime.TotalSeconds,
                report.Category.ToString(),
                unchecked((int)report.ExitCode),
                string.IsNullOrEmpty(report.StatusName) ? null : report.StatusName,
                coreId,
                Shadps4SetupDisplay.ShortBuildCommit(coreId),
                report.CoreVersion,
                "LaunchSession");
        }

        private string GroupByColumn =>
            cbGroupBy.SelectedItem?.ToString() ?? "Category";

        private void LogToTextBox(string logMessage)
        {
            //if (tbLog.InvokeRequired)
            //{
            //    // If the call is not on the UI thread, invoke it on the UI thread
            //    Invoke(new Action<string>(LogToTextBox), logMessage);
            //}
            //else
            //{
            //    // Append the log message to the TextBox
            //    tbLog.AppendText(logMessage + Environment.NewLine);
            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThemeManager.ThemeChanged -= Main_ThemeChanged;
            Logger.LogInformation("App closing.");
            _groupedViewRefreshTimer.Stop();
            _logFlushTimer.Stop();
            DisposeMainFileListingSession();
            Tool.KillNodeJS();
            //try
            //{
            //    if (Directory.Exists(WorkingDirectory))
            //    {
            //        Directory.Delete(WorkingDirectory, recursive: true);
            //    }
            //}
            //catch { }
            SettingsManager.SaveSettings(appSettings_, SettingFilePath);
            Application.Exit();
        }

        private static bool IsIgnorable(string dir)
        {
            string[] ignorableFolders = { "System Volume Information", "$RECYCLE.BIN", "$Recycle.Bin" };
            return ignorableFolders.Any(folder => dir.EndsWith(folder));
        }

        private void PKGListGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BGM.isBGMPlaying = false;
                BGM.At9Player.Stop();

                PKG.SelectedPKGFilename = "";

                if (PKGGridView.SelectedCells.Count > 0)
                {
                    GetSelectedPKGPath();

                    // Mirror the selection into the grouped view (DGV → GLV sync)
                    if (groupedListView != null && !string.IsNullOrEmpty(PKG.SelectedPKGFilename))
                        groupedListView.SelectFilePath(PKG.SelectedPKGFilename);

                    if (PKG.isDeletingPkg)
                        SelectFirstRowPkg();

                    LoadPKGDetails();
                }

                UpdateOfficialUpdateMenuState();
                UpdatePackageActionButtonStates();
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"ERROR: Selection changed: {ex.Message}");
                Logger.LogError($"Error on selection change: {ex.Message}");
            }
        }

        private void UpdateOfficialUpdateMenuState()
        {
            bool canOpen = false;
            try
            {
                if (PKGGridView.SelectedRows.Count == 1)
                {
                    string pkgType = PKGGridView.SelectedRows[0].Cells[8].Value?.ToString() ?? "";
                    canOpen = pkgType == PKGCategory.GAME || pkgType == PKGCategory.PATCH;
                }
            }
            catch (Exception ex) { Logger.LogWarning("Error reading PKG type from grid: " + ex.Message); }
            downloadOfficialUpdateToolStripMenuItem1.Enabled = canOpen;
            if (downloadOfficialUpdateToolStripMenuItem2 != null)
                downloadOfficialUpdateToolStripMenuItem2.Enabled = canOpen;
        }

        private bool _wasMaximized;

        /// <summary>Restoring from maximized lands on the minimum width (1150).</summary>
        private void Main_Resize(object sender, EventArgs e)
        {
            if (_wasMaximized && WindowState == FormWindowState.Normal)
                Width = 1150;
            _wasMaximized = WindowState == FormWindowState.Maximized;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Logger.LogInformation("App started.");
            // The form-level DPI scale pass resizes AutoSize children (e.g.
            // the filter checkboxes) without a follow-up layout, leaving them
            // doubled at high DPI — force the flow panel to re-measure once
            // the scaling has fully settled.
            flpFilter.PerformLayout();
            BeginInvoke(() =>
            {
                flpFilter.PerformLayout();
                // Labels are centered on their combos after the DPI scale
                // pass has fully settled (see AlignFilterRowLabels).
                AlignFilterRowLabels();

                // Hidden tab pages can keep stale anchoring after the DPI
                // scale + maximize ordering — the Grouped list ends up stuck
                // at its design width. Setting its correct bounds once heals
                // the anchor info; it tracks resizes from there. It fills
                // the page below the Group-by row (design Y=30).
                int glvTop = (int)Math.Round(30f * groupedListView.DeviceDpi / 96f);
                groupedListView.Bounds = new Rectangle(
                    0, glvTop,
                    tabPageGroup.ClientSize.Width,
                    Math.Max(0, tabPageGroup.ClientSize.Height - glvTop));
            });
            try
            {
                SetupFilterChecklists();
                WindowState = FormWindowState.Maximized;
                this.Text = "PS4 PKG Tool " + ApplicationVersion;
                await Task.Run(() =>
            {
                Logger.LogInformation("Selected directory: ");

                foreach (var folder in appSettings_.PkgDirectories)
                {
                    Logger.LogInformation(folder);
                }

                Logger.LogInformation("Checking Node.js and server module...");

                bool isNodeJsInstalled = NodeJsHttpServer.IsSoftwareInstalled("Node.js");
                appSettings_.NodeJsInstalled = isNodeJsInstalled;
                Logger.LogInformation(isNodeJsInstalled ? "Node.js installed." : "Node.js not installed.");

                bool isHttpServerModuleInstalled = Directory.Exists(NodeJsHttpServer.HttpServerModulePath);
                appSettings_.HttpServerInstalled = isHttpServerModuleInstalled;
                Logger.LogInformation(isHttpServerModuleInstalled ? "Module installed." : "Module not installed.");

                this.Invoke((MethodInvoker)delegate
                {
                    this.Enabled = false;

                    // If BGM playing, stop it (with timeout safety)
                    int bgmAttempts = 0;
                    while (BGM.isBGMPlaying && bgmAttempts++ < 10)
                    {
                        BGM.isBGMPlaying = false;
                        try { BGM.At9Player.Stop(); } catch { break; }
                    }

                    // Note: missing directory warnings are shown in PostPkgLoad after scan completes,
                    // so we don't show them here to avoid double prompts.

                    // Update UI
                    PKGGridView.Enabled = false;
                    darkDataGridView2.Enabled = false;

                    Logger.LogInformation("Scanning PKG...");

                    if (Helper.LaunchEmpty)
                    {
                        Logger.LogInformation("Launch Empty - skipping PKG scan.");
                        this.Invoke((MethodInvoker)(() =>
                        {
                            this.Enabled = true;
                            PKGGridView.Enabled = true;
                            darkDataGridView2.Enabled = true;
                            SetOperationMenusEnabled(false);
                            toolStripStatusLabel2.Text = "Ready (empty)";
                        }));
                    }
                    else
                    {
                        LoadPKGGridView();
                    }
                    //LoadPKGListView();
                });
            });
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"FATAL: App startup failed: {ex.Message}");
                Logger.LogError($"Form1_Load crashed: {ex}");
                AppMessageBox.Show("Fatal Error", $"Startup failed:\n{ex.Message}",
                    AppMessageType.Error, AppMessageButtons.OK);
            }
        }

        private BackgroundWorker _detailWorker;
        private int _detailLoadVersion;
        private PkgFileListingSession _mainFileListingSession;
        private string _mainFileListingPath = string.Empty;
        private int _mainFileListingVersion;
        private readonly Dictionary<string, SortOrder> _colSortDir = new();

        private void LoadPKGDetails()
        {
            if (!File.Exists(PKG.SelectedPKGFilename))
            {
                SelectFirstRowPkg();
                if (string.IsNullOrEmpty(PKG.SelectedPKGFilename)) return;
            }

            // Invalidate any in-flight load - a stale completion must never clobber the UI.
            int loadVersion = Interlocked.Increment(ref _detailLoadVersion);
            Interlocked.Increment(ref _trophyLoadVersion);
            ClearTrophyDetails();
            _detailWorker?.CancelAsync();
            var worker = new BackgroundWorker { WorkerSupportsCancellation = true };
            _detailWorker = worker;
            string pkgPath = PKG.SelectedPKGFilename; // capture for closure

            // File listing is intentionally manual. Clear a previous package's
            // browser session without disturbing a manually loaded listing when
            // SelectionChanged fires again for the same row.
            if (!string.Equals(_mainFileListingPath, pkgPath, StringComparison.OrdinalIgnoreCase))
            {
                DisposeMainFileListingSession();
                ClearFileBrowser();
                PKGTreeView.Enabled = true;
                listView1.Enabled = true;
            }

            // Show loading indicator
            toolStripStatusLabel2.Text = "Loading PKG details...";

            worker.DoWork += (_, args) =>
            {
                if (worker.CancellationPending) { args.Cancel = true; return; }
                args.Result = PkgMetadataReader.ReadQuick(pkgPath);
            };

            worker.RunWorkerCompleted += (_, args) =>
            {
                if (loadVersion != _detailLoadVersion) return; // stale - a newer load started
                if (args.Cancelled) return;
                if (args.Error != null || args.Result == null)
                {
                    string message = args.Error?.Message ?? "No package metadata was returned.";
                    Logger.LogError($"Failed to load PKG details for {pkgPath}: {message}");
                    ClearSelectedPkgDetails();
                    // Keep the selected path available to context operations and
                    // retries even though its detail panels were cleared.
                    PKG.SelectedPKGFilename = pkgPath;
                    toolStripStatusLabel2.Text = "Failed to load PKG details.";
                    ShowError("Failed to load PKG details:\n" + message, false);
                    return;
                }
                var ps4Pkg = (PkgMetadata)args.Result;

                UpdateFormTitle(ps4Pkg.PS4_Title, ps4Pkg.PKG_Type.ToString());
                PKG.CurrentPKGTitle = ps4Pkg.PS4_Title;
                PKG.CurrentPKGType = ps4Pkg.PKG_Type.ToString();

                int selCount = PKGGridView.SelectedRows.Count;
                GroupActionTitleStripMenuItem.Text = selCount > 1 ? "Group Action" : ps4Pkg.PS4_Title;
                toolStripMenuItem2.Text = selCount > 1 ? "Group Action" : ps4Pkg.PS4_Title;

                RpiUninstallBasePKGToolStripMenuItem1.Enabled = true;
                RpiUninstallBasePKGToolStripMenuItem2.Enabled = true;
                RpiUninstallPatchPKGToolStripMenuItem1.Enabled = true;
                RpiUninstallPatchPKGToolStripMenuItem2.Enabled = true;
                RpiUninstallDlcPKGToolStripMenuItem1.Enabled = true;
                RpiUninstallDlcPKGToolStripMenuItem2.Enabled = true;
                RpiUninstallThemePKGToolStripMenuItem1.Enabled = true;
                RpiUninstallThemePKGToolStripMenuItem2.Enabled = true;

                string pkgType = ps4Pkg.PKG_Type.ToString();
                if (pkgType == PKGCategory.GAME)
                {
                    RpiUninstallDlcPKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallDlcPKGToolStripMenuItem2.Enabled = false;
                    RpiUninstallThemePKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallThemePKGToolStripMenuItem2.Enabled = false;
                }
                else if (pkgType == PKGCategory.PATCH)
                {
                    RpiUninstallDlcPKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallDlcPKGToolStripMenuItem2.Enabled = false;
                    RpiUninstallThemePKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallThemePKGToolStripMenuItem2.Enabled = false;
                }
                else if (pkgType == PKGCategory.ADDON)
                {
                    RpiUninstallBasePKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallBasePKGToolStripMenuItem2.Enabled = false;
                    RpiUninstallPatchPKGToolStripMenuItem1.Enabled = false;
                    RpiUninstallPatchPKGToolStripMenuItem2.Enabled = false;
                }

                ShowPackageIcon(ps4Pkg);
                UpdateParamInfoGrid(ps4Pkg);
                // Clear artwork from the previous package while the larger
                // PIC/TRP entries load in the background.
                LoadBackgroundImages(ps4Pkg);
                LoadHeaderInfo(ps4Pkg);
                LoadPKGEntriesAsync(pkgPath, loadVersion);
                LoadPubToolInfo(ps4Pkg);

                if (appSettings_.PlayBgm) PlayBGM(pkgPath);
                toolStripStatusLabel2.Text = "...";

                LoadDeferredPackageAssets(pkgPath, loadVersion, ps4Pkg.Icon != null);
            };

            worker.RunWorkerAsync();
        }

        private List<string> ResolveGlvContextGroupPaths()
        {
            if (_glvGroupHeaderIndex >= 0)
                return groupedListView.GetGroupFilePaths(_glvGroupHeaderIndex);

            string path = groupedListView?.SelectedFilePath ?? "";
            int groupIndex = string.IsNullOrEmpty(path) ? -1 : groupedListView.FindGroupForPath(path);
            return groupIndex >= 0 ? groupedListView.GetGroupFilePaths(groupIndex) : new List<string>();
        }

        private void RunWithGlvGroupSelection(Action action)
        {
            if (!SelectGridRowsForPaths(_glvContextGroupPaths))
            {
                ShowError("No PKG group selected.", false);
                return;
            }
            action();
        }

        private void RunWithGlvCategorySelection(string category, Action action)
        {
            var matchingPaths = _glvContextGroupPaths
                .Where(path => string.Equals(GetGridRowForPath(path)?.Cells[PkgColumns.Category].Value?.ToString(), category, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (matchingPaths.Count == 0)
            {
                ShowWarning(category == PKGCategory.GAME ? "This group has no base game PKG." : "This group has no update PKG.", false);
                return;
            }

            // The shadPS4 actions work on one PKG. For several updates, use the highest App Version.
            string selectedPath = matchingPaths
                .OrderByDescending(path => GlvAppVersionRank(GetGridRowForPath(path)?.Cells[PkgColumns.AppVersion].Value?.ToString()))
                .First();
            if (!SelectGridRowsForPaths(new[] { selectedPath })) return;
            action();
        }

        private DataGridViewRow? GetGridRowForPath(string path)
            => PKGGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(row =>
                !row.IsNewRow && string.Equals(GetGridRowPkgPath(row), path, StringComparison.OrdinalIgnoreCase));

        private static string GetGridRowPkgPath(DataGridViewRow row)
            => Path.Combine(row.Cells[PkgColumns.Directory].Value?.ToString() ?? "",
                row.Cells[PkgColumns.Filename].Value?.ToString() ?? "");

        private static decimal GlvAppVersionRank(string? appVersion)
            => WorkflowGuards.ParseCombinedAppVersion(appVersion);

        private bool SelectGridRowsForPaths(IEnumerable<string> paths)
        {
            var wanted = new HashSet<string>(paths, StringComparer.OrdinalIgnoreCase);
            if (wanted.Count == 0) return false;
            PKGGridView.ClearSelection();
            DataGridViewRow? first = null;
            foreach (DataGridViewRow row in PKGGridView.Rows)
            {
                if (row.IsNewRow || !wanted.Contains(GetGridRowPkgPath(row))) continue;
                row.Selected = true;
                first ??= row;
            }
            if (first == null) return false;
            PKGGridView.CurrentCell = first.Cells[0];
            return true;
        }

        private void GlvMergeBaseAndLatestUpdate()
        {
            var bases = _glvContextGroupPaths.Where(path => string.Equals(GetGridRowForPath(path)?.Cells[PkgColumns.Category].Value?.ToString(), PKGCategory.GAME, StringComparison.OrdinalIgnoreCase)).ToList();
            var updates = _glvContextGroupPaths.Where(path => string.Equals(GetGridRowForPath(path)?.Cells[PkgColumns.Category].Value?.ToString(), PKGCategory.PATCH, StringComparison.OrdinalIgnoreCase)).ToList();
            if (bases.Count != 1 || updates.Count == 0)
            {
                ShowWarning("This group needs one base game PKG and at least one update PKG to merge.", false);
                return;
            }
            string update = updates.OrderByDescending(path => GlvAppVersionRank(GetGridRowForPath(path)?.Cells[PkgColumns.AppVersion].Value?.ToString())).First();
            if (!SelectGridRowsForPaths(new[] { bases[0], update })) return;
            MergeSelectedBaseAndUpdate_Click(mergeSelectedBaseAndUpdateToolStripMenuItem, EventArgs.Empty);
        }

        /// <summary>
        /// Loads entries which may be large (background images and trophy data)
        /// after the selected package's title, SFO and ICON0 have been shown.
        /// </summary>
        private async void LoadDeferredPackageAssets(string pkgPath, int loadVersion, bool iconAlreadyShown)
        {
            try
            {
                PkgMetadata pkg = await Task.Run(() => PkgMetadataReader.ReadArtwork(pkgPath));
                if (loadVersion != _detailLoadVersion)
                    return;

                // Some packages only have an icon in their trophy archive.
                if (!iconAlreadyShown)
                    ShowPackageIcon(pkg);

                LoadBackgroundImages(pkg);
                LoadTrophyInfo(pkg, pkgPath);
            }
            catch (Exception ex)
            {
                if (loadVersion == _detailLoadVersion)
                    Logger.LogWarning("Deferred package artwork load failed: " + ex.Message);
            }
        }

        private void UpdateFormTitle(string pkgTitle, string pkgType)
        {
            string category = pkgType switch
            {
                PKGCategory.GAME => "Game",
                PKGCategory.PATCH => "Patch",
                PKGCategory.ADDON => "Addon",
                PKGCategory.APP => "App",
                PKGCategory.UNKNOWN => "Unknown",
                _ => pkgType
            };
            this.Text = $"PS4 PKG Tool {ApplicationVersion} - Viewing [{category}] \"{pkgTitle}\"";
        }

        private OfficialUpdateForm _officialUpdateForm;

        private void OpenOfficialUpdateForm()
        {
            try
            {
                if (PKGGridView.SelectedRows.Count != 1)
                {
                    ShowInformation("Please select a single PKG.", false);
                    return;
                }

                DataGridViewRow row = PKGGridView.SelectedRows[0];
                string pkgType = row.Cells[8].Value?.ToString() ?? "";
                if (pkgType != PKGCategory.GAME && pkgType != PKGCategory.PATCH)
                {
                    ShowInformation("Official updates are only available for Game and Patch PKGs.", false);
                    return;
                }

                string filename = row.Cells[0].Value?.ToString();
                string directory = row.Cells[13].Value?.ToString();
                if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(directory))
                {
                    ShowError("Could not determine PKG path.", false);
                    return;
                }

                string pkgPath = Path.Combine(directory, filename);
                if (!File.Exists(pkgPath))
                {
                    ShowError("Selected PKG file not found.", false);
                    return;
                }

                string titleId = row.Cells[PkgColumns.TitleId].Value?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(titleId))
                {
                    ShowError("Could not read PKG title ID.", false);
                    return;
                }

                if (_officialUpdateForm == null || _officialUpdateForm.IsDisposed)
                    _officialUpdateForm = new OfficialUpdateForm();

                _officialUpdateForm.SetLogCallback(Logger.LogInformation);
                _officialUpdateForm.LoadUpdate(titleId, pkgType, appSettings_.OfficialUpdateDownloadDirectory);
                _officialUpdateForm.Show();
                _officialUpdateForm.BringToFront();
            }
            catch (Exception ex)
            {
                Logger.LogError("Error opening official update form: " + ex.Message);
                ShowError("Error opening official update form: " + ex.Message, true);
            }
        }

        private void DownloadOfficialUpdate_Click(object sender, EventArgs e)
        {
            OpenOfficialUpdateForm();
        }

        private void LoadPubToolInfo(PkgMetadata pkg)
        {
            try
            {
                string pubToolInfo = pkg.SfoTables
                    .Where(item => item.Name == "PUBTOOLINFO")
                    .Select(item => item.Value)
                    .FirstOrDefault();
                IReadOnlyList<PkgInspectionField> fields = PkgBuildInfoParser.Parse(pubToolInfo);

                DataTable dtPubtool = new DataTable();
                foreach (PkgInspectionField field in fields)
                    dtPubtool.Columns.Add(field.Name);

                if (fields.Count > 0)
                {
                    var row = dtPubtool.NewRow();
                    for (int i = 0; i < fields.Count; i++)
                        row[i] = fields[i].Value;
                    dtPubtool.Rows.Add(row);
                }

                darkDataGridView4.DataSource = dtPubtool;
            }
            catch (Exception ex) { Logger.LogWarning("Error loading pub-tool info: " + ex.Message); }
        }

        private void LoadHeaderInfo(PkgMetadata pkg)
        {
            try
            {
                // The legacy grid showed PS4_Struct.DisplayType/DisplayValue;
                // PkgHeaderDump reproduces those 46 rows from the raw header.
                byte[] headerBytes = ReadHeaderBytes(PKG.SelectedPKGFilename);
                var rows = PkgHeaderDump.Rows(pkg.Header, headerBytes);

                DataTable dtHeader = new DataTable();
                dtHeader.Columns.Add("Type");
                dtHeader.Columns.Add("Value");

                foreach (var (type, value) in rows)
                {
                    dtHeader.Rows.Add(type, value);
                }

                dgvHeader.DataSource = dtHeader;
            }
            catch (Exception ex) { Logger.LogWarning("Error loading header info: " + ex.Message); }
        }

        /// <summary>Reads the 0x1100-byte header window PkgHeaderDump needs.</summary>
        private static byte[] ReadHeaderBytes(string pkgPath)
        {
            using var file = new FileStream(pkgPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var buffer = new byte[PkgHeaderDump.HeaderBytes];
            int read = 0;
            while (read < buffer.Length)
            {
                int n = file.Read(buffer, read, buffer.Length - read);
                if (n <= 0) break;
                read += n;
            }
            Array.Resize(ref buffer, read);
            return buffer;
        }

        private sealed record PkgEntriesLoadResult(
            DataTable Table,
            Dictionary<string, string> EntryNames,
            Dictionary<string, string> EncryptedEntryNames);

        private async void LoadPKGEntriesAsync(string pkgPath, int loadVersion)
        {
            dgvEntryList.DataSource = null;
            dgvEntryList.Rows.Clear();
            dgvEntryList.ScrollBars = ScrollBars.Vertical;

            try
            {
                PkgEntriesLoadResult result = await Task.Run(() => BuildPkgEntries(pkgPath));
                if (loadVersion != _detailLoadVersion
                    || !string.Equals(pkgPath, PKG.SelectedPKGFilename, StringComparison.OrdinalIgnoreCase))
                    return;

                Entry.EntryIdNameDictionary.Clear();
                foreach (var item in result.EntryNames)
                    Entry.EntryIdNameDictionary[item.Key] = item.Value;
                Entry.EncryptedEntryOffsetNameDictionary.Clear();
                foreach (var item in result.EncryptedEntryNames)
                    Entry.EncryptedEntryOffsetNameDictionary[item.Key] = item.Value;

                dgvEntryList.DataSource = result.Table;
                foreach (DataGridViewColumn column in dgvEntryList.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                if (loadVersion == _detailLoadVersion)
                    Logger.LogError($"Failed to load PKG entries: {ex.Message}.");
            }
        }

        private static PkgEntriesLoadResult BuildPkgEntries(string pkgPath)
        {
            var table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Offset");
            table.Columns.Add("Size");
            table.Columns.Add("Flags 1");
            table.Columns.Add("Flags 2");
            table.Columns.Add("Encrypted?");

            var entryNames = new Dictionary<string, string>();
            var encryptedEntryNames = new Dictionary<string, string>();
            using var pkgReader = new OrbisPkgTool.PkgReader(pkgPath);
            int index = 0;
            foreach (var meta in pkgReader.Entries)
            {
                string entryName = ((LegacyEntryId)meta.Id).ToString();
                entryNames[$"{index++,-6}"] = entryName;
                if (meta.IsEncrypted)
                    encryptedEntryNames[$"0x{meta.DataOffset:X8}"] = entryName;

                var finalSize = ByteSizeLib.ByteSize.FromBytes(Convert.ToDouble(meta.DataSize));
                table.Rows.Add(entryName, $"0x{meta.DataOffset:X}", finalSize,
                    $"0x{meta.Flags1:X}", $"0x{meta.Flags2:X}", meta.IsEncrypted.ToString());
            }
            return new PkgEntriesLoadResult(table, entryNames, encryptedEntryNames);
        }

        private void LoadBackgroundImages(PkgMetadata pkg)
        {
            try
            {
                ClearPictureBox(pbPIC0, hide: true);
                ClearPictureBox(pbPIC1, hide: true);
                pbPIC0.Click -= pictureBox_click;
                pbPIC1.Click -= pictureBox_click;

                if (pkg.PKG_Type.ToString() == PKGCategory.GAME || pkg.PKG_Type.ToString() == PKGCategory.PATCH)
                {
                    if (pkg.Pic0 != null)
                    {
                        pbPIC0.Click += pictureBox_click;
                        pbPIC0.Visible = true;
                        pbPIC0.SizeMode = PictureBoxSizeMode.StretchImage;
                        ReplacePictureBoxImage(pbPIC0, Helper.Bitmap.BytesToBitmap(pkg.Pic0));
                        Helper.Bitmap.Pic0 = pbPIC0.Image;
                    }
                    else
                    {
                        pbPIC0.Click -= pictureBox_click;
                        pbPIC0.Visible = false;
                        ClearPictureBox(pbPIC0, hide: true);
                    }

                    if (pkg.Pic1 != null)
                    {
                        if (old_byte == pkg.Pic1)
                        {
                            pbPIC1.Click -= pictureBox_click;
                            pbPIC1.Visible = false;
                            ClearPictureBox(pbPIC1, hide: true);
                        }
                        else
                        {
                            old_byte = pkg.Pic1;
                            pbPIC1.Click += pictureBox_click;
                            pbPIC1.Visible = true;
                            pbPIC1.SizeMode = PictureBoxSizeMode.StretchImage;
                            ReplacePictureBoxImage(pbPIC1, Helper.Bitmap.BytesToBitmap(pkg.Pic1));
                            Helper.Bitmap.Pic1 = pbPIC1.Image;
                        }
                    }
                    else
                    {
                        pbPIC1.Click -= pictureBox_click;
                        pbPIC1.Visible = false;
                        ClearPictureBox(pbPIC1, hide: true);
                    }
                }
            }
            catch (Exception ex) { Logger.LogWarning("Error displaying package icons: " + ex.Message); }
        }

        private async Task<string> EnsureTrophyFileExtractedAsync(
            string pkgPath,
            PkgMetadata pkg)
        {
            string outputPath = Path.Combine(Trophy.TrophyTempFolder, pkg.Content_ID + "_" + pkg.PKG_Type + ".TRP");
            if (File.Exists(outputPath)) return outputPath;

            SemaphoreSlim extractionLock = _trophyExtractionLocks.GetOrAdd(outputPath, _ => new SemaphoreSlim(1, 1));
            await extractionLock.WaitAsync().ConfigureAwait(false);
            try
            {
                if (File.Exists(outputPath)) return outputPath;
                bool extracted = await Task.Run(() => TryExtractTrophyFile(pkgPath, outputPath, pkg)).ConfigureAwait(false);
                return extracted ? outputPath : null;
            }
            finally { extractionLock.Release(); }
        }

        private static bool TryExtractTrophyFile(
            string pkgPath,
            string outputPath,
            PkgMetadata pkg)
        {
            Tool.CreateDirectoryIfNotExists(Trophy.TrophyTempFolder);
            string temporaryPath = outputPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                // Stream the encrypted trophy entry directly to disk. Keeping a
                // full TRP byte[] in package metadata made large trophy sets
                // unnecessarily expensive when changing selection.
                using (var reader = new OrbisPkgTool.PkgReader(pkgPath, DefaultOrbisPasscode))
                    reader.ExtractEntryToFile(OrbisPkgTool.Pkg.PkgEntryIds.Trophy00Trp, temporaryPath);

                if (new FileInfo(temporaryPath).Length == 0)
                    throw new InvalidDataException("Extracted trophy archive is empty.");
                File.Move(temporaryPath, outputPath, overwrite: true);
                Logger.LogInformation("Trophy extracted: " + pkg.PS4_Title + " -> " + outputPath);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error extracting trophy data from PKG: " + pkgPath, ex);
                return false;
            }
            finally
            {
                if (File.Exists(temporaryPath))
                    try { File.Delete(temporaryPath); } catch { }
            }
        }

        private async void LoadTrophyInfo(PkgMetadata pkg, string pkgPath)
        {
            int loadVersion = Interlocked.Increment(ref _trophyLoadVersion);
            try
            {
                ClearTrophyDetails();

                string trophyFile = await EnsureTrophyFileExtractedAsync(pkgPath, pkg);
                if (loadVersion != _trophyLoadVersion) return;
                if (trophyFile == null)
                {
                    Logger.LogWarning("Trophy metadata unavailable because no extractable TRP was found for " + pkg.PS4_Title + " (" + pkg.Content_ID + ").");
                    return;
                }

                var service = new TrophyMetadataService();
                string cachePath = Path.Combine(AppDataDirectory, "TrophyMetadata", "np-communication-ids.json");
                var cache = new NpCommunicationIdCache(cachePath);
                string npCommunicationId = null;
                if (cache.TryGet(pkg.Content_ID, out string cachedId))
                {
                    npCommunicationId = cachedId;
                    Logger.LogInformation("Using cached NP Communication ID for " + pkg.Content_ID + ": " + cachedId);
                }

                TRPReader legacyReader = null;
                TrophyMetadataResult result = await Task.Run(() =>
                {
                    legacyReader = new TRPReader { ThrowError = false };
                    legacyReader.Load(trophyFile);
                    return service.Read(trophyFile, npCommunicationId);
                });
                if (loadVersion != _trophyLoadVersion) return;

                Trophy.trophy = legacyReader;
                PopulateTrophyGrid(result);
                Logger.LogInformation(result.StatusMessage + (result.NpCommunicationId == null ? string.Empty : " NP Communication ID: " + result.NpCommunicationId));
            }
            catch (Exception ex)
            {
                Logger.LogError("Error in LoadTrophyInfo", ex);
            }
        }

        private void PopulateTrophyGrid(TrophyMetadataResult result)
        {
            var table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Image", typeof(Image));
            table.Columns.Add("Grade", typeof(string));
            table.Columns.Add("Hidden", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Group", typeof(string));
            table.Columns.Add("File", typeof(string));
            table.Columns.Add("Size", typeof(string));
            table.Columns.Add("Offset", typeof(string));

            var reader = new PS4PKGTool.Utilities.TrophyMetadata.TrpReader();
            var detector = new TrophyResourceDetector();
            var pngEntries = new Dictionary<string, TrpEntry>(StringComparer.OrdinalIgnoreCase);
            foreach (TrpEntry entry in result.Archive.Entries)
            {
                if (!entry.Name.EndsWith(".PNG", StringComparison.OrdinalIgnoreCase)) continue;
                byte[] bytes = reader.ReadEntry(result.Archive, entry);
                if (detector.Detect(bytes, entry) != TrophyResourceKind.Png) continue;
                pngEntries[entry.Name] = entry;
                Trophy.TrophyFilenameToExtractList.Add(entry.Name);
                Trophy.ImageToExtractList.Add(ImageFromDetachedBytes(bytes));
            }

            if (result.Trophies.Count > 0)
            {
                foreach (TrophyInfo trophy in result.Trophies.OrderBy(item => item.Id))
                {
                    pngEntries.TryGetValue(trophy.IconEntryName, out TrpEntry iconEntry);
                    Image image = trophy.IconData == null ? null : ResizeTrophyImage(ImageFromDetachedBytes(trophy.IconData));
                    table.Rows.Add(
                        trophy.Id.ToString("000"), image, trophy.Grade.ToString(), trophy.IsHidden ? "Yes" : "No",
                        trophy.Name, trophy.Description, trophy.GroupName, trophy.IconEntryName,
                        iconEntry == null ? string.Empty : RoundBytes(iconEntry.Size),
                        iconEntry == null ? string.Empty : "0x" + iconEntry.Offset.ToString("X"));
                }
            }
            else
            {
                foreach ((string name, TrpEntry entry) in pngEntries)
                {
                    byte[] bytes = reader.ReadEntry(result.Archive, entry);
                    Match idMatch = Regex.Match(name, @"^TROP(?<id>\d{3})\.PNG$", RegexOptions.IgnoreCase);
                    table.Rows.Add(idMatch.Success ? idMatch.Groups["id"].Value : string.Empty,
                        ResizeTrophyImage(ImageFromDetachedBytes(bytes)), "Unknown", "Unknown", "Metadata unavailable",
                        result.StatusMessage, "Unknown", name, RoundBytes(entry.Size), "0x" + entry.Offset.ToString("X"));
                }
            }

            TrophyGridView.DataSource = table;
            foreach (DataGridViewColumn column in TrophyGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            TrophyGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private static Image ImageFromDetachedBytes(byte[] bytes)
        {
            using var stream = new MemoryStream(bytes, writable: false);
            using Image source = Image.FromStream(stream, useEmbeddedColorManagement: false, validateImageData: true);
            return new Bitmap(source);
        }

        private static Image ResizeTrophyImage(Image source)
        {
            using (source)
                return Trophy.ResizeImage(source, Math.Max(1, source.Width / 2), Math.Max(1, source.Height / 2));
        }

        //private void LoadTrophies(PkgMetadata pkg)
        //{
        //    try
        //    {
        //        TrophyGridView.DataSource = null;
        //        TrophyGridView.Rows.Clear();

        //        DataTable trophyDataTable = new DataTable();

        //        // Add columns to the DataTable if needed
        //        trophyDataTable.Columns.Add("Image", typeof(Image));  // Example column, adjust as needed
        //        trophyDataTable.Columns.Add("Name", typeof(string));
        //        trophyDataTable.Columns.Add("Size", typeof(string));
        //        trophyDataTable.Columns.Add("Offset", typeof(string));

        //        if (pkg.Trophy_File != null)
        //        {
        //            BackgroundWorker bgwTrophy = new BackgroundWorker();
        //            bgwTrophy.WorkerSupportsCancellation = true;
        //            bgwTrophy.DoWork += (s, e) =>
        //            {
        //                try
        //                {
        //                    Logger.LogError("Loading trophies for " + pkg.PS4_Title + "..");

        //                    List<string> idEntryList = new List<string>();
        //                    List<string> nameEntryList = new List<string>();

        //                    using (var file = File.OpenRead(PKG.SelectedPKGFilename))
        //                    {
        //                        var pkgReader = new PkgReader(file);
        //                        var pkgData = pkgReader.ReadPkg();
        //                        var i = 0;

        //                        foreach (var meta in pkgData.Metas.Metas)
        //                        {
        //                            idEntryList.Add($"{i++,-6}");
        //                            nameEntryList.Add($"{meta.id}");
        //                        }

        //                        idEntryList.ToArray();
        //                        nameEntryList.ToArray();
        //                    }

        //                    string path = Trophy.TrophyTempFolder;
        //                    Directory.CreateDirectory(path);

        //                    var numbersAndWords = idEntryList.Zip(nameEntryList, (n, w) => new { id = n, name = w });
        //                    foreach (var nw in numbersAndWords)
        //                    {
        //                        if (nw.name == "TROPHY__TROPHY00_TRP")
        //                        {
        //                            var pkgPath = PKG.SelectedPKGFilename;
        //                            var idx = int.Parse(nw.id);
        //                            var name = nw.name;
        //                            Trophy.outPath = Path.Combine(path, name.Replace("_SHA", ".SHA").Replace("_DAT", ".DAT").Replace("_SFO", ".SFO").Replace("_XML", ".XML").Replace("_SIG", ".SIG").Replace("_PNG", ".PNG").Replace("_JSON", ".JSON").Replace("_DDS", ".DDS").Replace("_TRP", ".TRP").Replace("_AT9", ".AT9"));

        //                            using (var pkgFile = File.OpenRead(pkgPath))
        //                            {
        //                                var pkgReader = new PkgReader(pkgFile);
        //                                var pkgData = pkgReader.ReadPkg();
        //                                if (idx < 0 || idx >= pkgData.Metas.Metas.Count)
        //                                {
        //                                    return;
        //                                }
        //                                using (var outFile = File.Create(Trophy.outPath))
        //                                {
        //                                    var meta = pkgData.Metas.Metas[idx];
        //                                    outFile.SetLength(meta.DataSize);
        //                                    if (meta.Encrypted)
        //                                    {
        //                                        // Decrypt encrypted bytes if needed
        //                                    }
        //                                    new SubStream(pkgFile, meta.DataOffset, meta.DataSize).CopyTo(outFile);
        //                                }
        //                            }
        //                        }
        //                    }



        //                    if (File.Exists(Trophy.outPath))
        //                    {
        //                        Trophy.trophy = new TRPReader();
        //                        Trophy.trophy.Load(Trophy.outPath);

        //                        if (!Trophy.trophy.IsError)
        //                        {


        //                            foreach (var current in Trophy.trophy.TrophyList)
        //                            {
        //                                if (current.Name.ToUpper().EndsWith(".PNG"))
        //                                {
        //                                    var imageBytes = Trophy.trophy.ExtractFileToMemory(current.Name);
        //                                    Image image = Helper.Bitmap.BytesToImage(imageBytes);
        //                                    Image resize = Trophy.ResizeImage(image, image.Width / 2, image.Height / 2);

        //                                    trophyDataTable.Rows.Add(resize, current.Name, RoundBytes(current.Size), "0x" + current.Offset);
        //                                }
        //                                Application.DoEvents();
        //                            }

        //                            TrophyGridView.DataSource = trophyDataTable;
        //                            TrophyGridView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                            TrophyGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                            TrophyGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                            TrophyGridView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //                            TrophyGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                            TrophyGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                            TrophyGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                        }
        //                    }
        //                }
        //                catch { }
        //            };
        //            bgwTrophy.RunWorkerCompleted += (s, e) =>
        //            {

        //            };
        //            bgwTrophy.RunWorkerAsync();
        //        }
        //        else
        //        {
        //            Logger.LogError(pkg.PS4_Title + " has no trophy.");
        //        }
        //    }
        //    catch { }
        //}


        private void PlayBGM(string selectedPkgFilename)
        {
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.DoWork += (s, e) =>
            {
                try
                {
                    BGM.PlayAt9(selectedPkgFilename);
                }
                catch (Exception ex) { Logger.LogWarning("BGM playback failed: " + ex.Message); }
            };
            bgw.RunWorkerCompleted += (s, e) =>
            {

            };
            bgw.RunWorkerAsync();
        }

        private void ShowPackageIcon(PkgMetadata pkg)
        {
            darkLabel1.Text = "";

            if (pkg.Icon != null)
            {
                pictureBox1.Visible = true;
                label3.Text = "";
                ReplacePictureBoxImage(pictureBox1, Helper.Bitmap.BytesToBitmap(pkg.Icon));
            }
            else
            {
                ClearPictureBox(pictureBox1, hide: true);
                label3.Visible = true;
                label3.Text = "Image not available";
            }

            darkLabel1.Text = pkg.PS4_Title;
        }


        private void UpdateParamInfoGrid(PkgMetadata pkg)
        {
            DataTable dg2 = new DataTable();
            dg2.Columns.Add("PARAM");
            dg2.Columns.Add("VALUE");

            for (int i = 0; i < pkg.SfoTables.Count; i++)
            {
                dg2.Rows.Add(pkg.SfoTables[i].Name, pkg.SfoTables[i].Value);
            }

            darkDataGridView2.DataSource = dg2;
            darkDataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            darkDataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void pictureBox_click(object sender, EventArgs e)
        {
            if (!(sender is PictureBox pictureBox)) return;

            if (pictureBox == null)
                return;

            contextMenuBackgroundImage.Show(pictureBox, pictureBox.PointToClient(Cursor.Position));
        }

        /// <summary>
        /// Return PKG directory of selected/all PKG from gridview
        /// </summary>
        /// <param name="selectionType"></param>
        /// <returns></returns>
        private List<string> GetSelectedPKGDirectoryList(string selectionType, bool sortAddon = false)
        {
            var list = new List<string>();
            try
            {
                IEnumerable<DataGridViewRow> rowsToProcess = null;

                if (selectionType == PKGSelectionType.SELECTED)
                {
                    if (PKGGridView.SelectedRows.Count == 0) return list;
                    rowsToProcess = PKGGridView.SelectedRows.Cast<DataGridViewRow>();
                }
                else if (selectionType == PKGSelectionType.ALL)
                {
                    if (PKGGridView.Rows.Count == 0) return list;
                    rowsToProcess = PKGGridView.Rows.Cast<DataGridViewRow>();
                }

                if (rowsToProcess == null) return list;

                if (sortAddon)
                {
                    rowsToProcess = rowsToProcess.OrderByDescending(row => row.Cells[8].Value);
                }

                foreach (DataGridViewRow row in rowsToProcess)
                {
                    if (row.Cells[0].Value == null || row.Cells[13].Value == null) continue;
                    string filename = row.Cells[0].Value.ToString();
                    string path = row.Cells[13].Value.ToString();
                    string pkgPath = Path.Combine(path, filename);
                    list.Add(pkgPath);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error getting PKG list: {ex.Message}");
            }
            return list;
        }

        private void ImageIconExtractor(string imageType, List<string> pkgFilesList, string outputDirectory, bool respectiveExtract)
        {
            int countPkg = 0;
            int total = pkgFilesList.Count;
            int batchSize = 10;
            foreach (string pkgPath in pkgFilesList)
            {
                try
                {
                    string pkgName = Path.GetFileNameWithoutExtension(pkgPath);
                    string finalPath = respectiveExtract
                        ? $"{outputDirectory}\\{pkgName}\\"
                        : outputDirectory;

                    Directory.CreateDirectory(finalPath);

                    byte[] icon = null, pic0 = null, pic1 = null;
                    switch (imageType)
                    {
                        case ImageIconExtractionType.ALL:
                            icon = PkgImageReader.ReadIcon0Png(pkgPath);
                            pic0 = PkgImageReader.ReadPic0Png(pkgPath);
                            pic1 = PkgImageReader.ReadPic1Png(pkgPath);
                            break;
                        case ImageIconExtractionType.ICON:
                            icon = PkgImageReader.ReadIcon0Png(pkgPath);
                            break;
                        case ImageIconExtractionType.IMAGE:
                            pic0 = PkgImageReader.ReadPic0Png(pkgPath);
                            pic1 = PkgImageReader.ReadPic1Png(pkgPath);
                            break;
                    }

                    string baseFileName = respectiveExtract ? "" : pkgName + "_";
                    if (icon != null) SavePng(icon, Path.Combine(finalPath, $"{baseFileName}ICON.PNG"));
                    if (pic0 != null) SavePng(pic0, Path.Combine(finalPath, $"{baseFileName}PIC0.PNG"));
                    if (pic1 != null) SavePng(pic1, Path.Combine(finalPath, $"{baseFileName}PIC1.PNG"));
                }
                catch (Exception a)
                {
                    Helper.Bitmap.FailExtractImageList += Path.GetFileNameWithoutExtension(pkgPath) + " : " + a.Message + "\n";
                }
                countPkg++;
                if (countPkg % batchSize == 0 || countPkg == total)
                {
                    int current = countPkg;
                    int max = total;
                    this.Invoke((MethodInvoker)delegate
                    {
                        toolStripProgressBar1.Minimum = 0;
                        toolStripProgressBar1.Maximum = 100;
                        toolStripProgressBar1.Value = (int)(100.0 * current / max);
                        toolStripStatusLabel2.Text = $"Saving artwork.. ({current}/{max})";
                    });
                }
            }
        }

        private void SavePng(byte[] imageBytes, string filePath)
        {
            using (var ms = new MemoryStream(imageBytes))
            using (var bmp = Image.FromStream(ms))
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L);
                var pngCodec = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Png.Guid);
                bmp.Save(filePath, pngCodec, encoderParams);
            }
        }

        private void ImageIconPostExtraction()
        {
            if (!string.IsNullOrEmpty(Helper.Bitmap.FailExtractImageList))
            {
                Logger.LogInformation("Artwork extraction completed with errors.");
                ShowWarning("Some PKG fail to extract : \n\n" + Helper.Bitmap.FailExtractImageList, false);
                Logger.LogWarning("Some PKG fail to extract : \n\n" + Helper.Bitmap.FailExtractImageList);
            }
            else
            {
                Logger.LogInformation("Artwork saved successfully.");
                ShowInformation("Artwork saved.", true);
            }

            toolStripStatusLabel2.Text = "... ";
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            toolStripProgressBar1.Value = 0;
            this.Enabled = true;
        }

        private void MorePKGTool(string type, DataTable dataTable = null, string excelFilename = null)
        {
            this.Invoke((MethodInvoker)delegate { this.Enabled = false; });
            PkgMetadata PS4_PKG = PkgMetadataReader.Read(PKG.SelectedPKGFilename);

            switch (type)
            {
                case "ENTRY":
                    // Code for the "ENTRY" button
                    break;

                case "TROPHY":
                    // Code for the "TROPHY" button
                    break;

                case "EXPORT":
                    try
                    {
                        int rows = dataTable?.Rows.Count ?? 0;
                        Logger.LogInformation($"Exporting {rows} PKG(s) to Excel...");
                        this.Invoke((MethodInvoker)delegate { toolStripStatusLabel2.Text = "Exporting PKG list.. "; });
                        var wb = new XLWorkbook();
                        wb.Worksheets.Add(dataTable, "PS4 PKG");
                        wb.SaveAs(excelFilename);
                        Logger.LogInformation($"Exported {rows} PKG(s) to \"{excelFilename}\".");
                        this.Invoke((Action)(() => ShowInformation($"PKG list exported.", false)));
                    }
                    catch (Exception s)
                    {
                        Logger.LogInformation($"ERROR: Export failed: {s.Message}");
                        this.Invoke((Action)(() => ShowError(s.Message, true)));
                    }
                    break;
            }
            this.Invoke((MethodInvoker)delegate { this.Enabled = true; }); // re-enable on every exit path (ADDON/ENTRY/TROPHY leaves the form disabled otherwise)
        }

        private void CopyContentID()
        {
            var ids = new List<string>();
            foreach (DataGridViewRow row in PKGGridView.SelectedRows)
            {
                string cid = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(cid)) ids.Add(cid);
            }
            if (ids.Count == 0) { ShowError("No PKG file selected.", false); return; }
            Clipboard.SetText(string.Join("\n", ids));
            ShowInformation($"{ids.Count} Content ID(s) copied to clipboard.", true);
        }

        private void CopyTitle()
        {
            var titles = new List<string>();
            foreach (DataGridViewRow row in PKGGridView.SelectedRows)
            {
                string title = row.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(title)) titles.Add(title);
            }
            if (titles.Count == 0) { ShowError("No PKG file selected.", false); return; }
            Clipboard.SetText(string.Join("\n", titles));
            ShowInformation($"{titles.Count} Title(s) copied to clipboard.", true);
        }

        private void CopyFilename()
        {
            var filenames = new List<string>();
            foreach (DataGridViewRow row in PKGGridView.SelectedRows)
            {
                string fn = row.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(fn)) filenames.Add(fn);
            }
            if (filenames.Count == 0) { ShowError("No PKG file selected.", false); return; }
            Clipboard.SetText(string.Join("\n", filenames));
            ShowInformation($"{filenames.Count} Filename(s) copied to clipboard.", true);
        }

        private void RefreshPkgList()
        {
            mainTabControl.SelectedIndex = 0;
            Logger.LogInformation("Refreshing PKG list..");
            Logger.LogInformation("Refreshing PKG list...");

            // Clear existing data
            PKGGridView.DataSource = null;
            darkDataGridView2.DataSource = null;
            FinalizePkgProcess = true;

            // Keep existing source (manifest vs directory), just re-scan
            Helper.LaunchEmpty = false;

            this.Enabled = false;
            PKGGridView.Enabled = false;
            darkDataGridView2.Enabled = false;
            LoadPKGGridView();
        }

        private void toolStripMenuItem78_Click(object sender, EventArgs e)
        {
            DialogResult dialog = DialogResultYesNo("Are you sure you wish to exit?");
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// File → Load Manifest From: load a library snapshot without changing saved directories.
        /// </summary>
        private void loadFromManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Load PKG Manifest",
                Filter = "PKG manifest (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = Path.GetDirectoryName(ManifestHelper.ManifestFilePath),
                FileName = Path.GetFileName(ManifestHelper.ManifestFilePath),
                CheckFileExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            var manifest = ManifestHelper.LoadManifest(dialog.FileName);
            if (manifest == null)
            {
                ShowWarning("The selected manifest could not be loaded.", false);
                return;
            }

            if (manifest.SchemaVersion != 1)
            {
                ShowWarning("The selected manifest uses an unsupported format.", false);
                return;
            }

            var (validEntries, removed) = ManifestHelper.FilterValidEntries(manifest.Entries);
            if (validEntries.Count == 0)
            {
                ShowWarning("No accessible PKG entries were found in the selected manifest.", false);
                return;
            }

            var dt = ManifestHelper.BuildDataTableFromManifest(validEntries);
            var pkgPaths = ManifestHelper.BuildPkgPathList(validEntries);
            PKG.VerifiedPs4PkgList = pkgPaths;
            PKG.pkgCount = pkgPaths.Count;
            PKG.game = validEntries.Count(entry => entry.Category == "Game");
            PKG.patch = validEntries.Count(entry => entry.Category == "Patch");
            PKG.addon = validEntries.Count(entry => entry.Category == "Addon");
            PKG.app = validEntries.Count(entry => entry.Category == "App");
            PKG.unknown = validEntries.Count(entry => entry.Category == "Unknown");
            PKG.official = validEntries.Count(entry => entry.PkgType == "Official");
            PKG.fake = validEntries.Count(entry => entry.PkgType == "Fake");

            Helper.LoadFromManifest = false;
            ResetAllFilters();
            ApplyShadps4Status(dt);
            PKGGridView.DataSource = dt;
            HideFilterColumns();
            UpdateDataGridViewColumnVisibility();
            SetDataGridViewCellStyle();
            PopulateGroupedView();
            SetOperationMenusEnabled(true);
            labelDisplayTotalPKG.Text = $"Displaying {pkgPaths.Count} PS4 PKG";
            toolStripStatusLabel2.Text = "Manifest loaded.";

            Logger.LogInformation($"Manifest loaded from {dialog.FileName}: {validEntries.Count} entries" +
                (removed > 0 ? $", {removed} unavailable entries skipped" : ""));
            string message = $"Loaded {validEntries.Count} PKG entries from the manifest.";
            if (removed > 0)
                message += $"\n{removed} unavailable entries were skipped.";
            ShowInformation(message, true);
        }

        /// <summary>
        /// File → Load from saved directory: force a full rescan of the configured PKG
        /// directories (picks up newly added files), regardless of the current source.
        /// Mirrors the "Scan from directory" startup mode.
        /// </summary>
        private void loadFromDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Loading PKG list from saved directories..");
            Helper.LoadFromManifest = false;
            RefreshPkgList();
        }

        /// <summary>
        /// File → Save Manifest As: export the current library snapshot.
        /// </summary>
        private void saveManifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = PKGGridView.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowWarning("Nothing to save, the PKG list is empty.", false);
                return;
            }
            using var dialog = new SaveFileDialog
            {
                Title = "Save PKG Manifest",
                Filter = "PKG manifest (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = Path.GetDirectoryName(ManifestHelper.ManifestFilePath),
                FileName = Path.GetFileName(ManifestHelper.ManifestFilePath),
                AddExtension = true,
                DefaultExt = "json",
                OverwritePrompt = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            ManifestHelper.SaveManifest(dt, PKG.VerifiedPs4PkgList, dialog.FileName);
            ShowInformation("Manifest saved.", true);
        }

        /// <summary>
        /// File → Empty list: clear the current library view. PKG files and the cached manifest are not touched.
        /// </summary>
        private void emptyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResultYesNo("Clear the current PKG list?\n\nPKG files and the cached manifest will not be deleted.") != DialogResult.Yes)
                return;

            Logger.LogInformation("Emptying PKG list..");
            Helper.LoadFromManifest = false;
            _detailWorker?.CancelAsync();                       // invalidate in-flight detail loads
            DisposeMainFileListingSession();                    // cancel the selected PKG file list
            Interlocked.Increment(ref _trophyLoadVersion);      // invalidate in-flight trophy loads
            PKG.SelectedPKGFilename = "";
            PKG.VerifiedPs4PkgList.Clear();
            PKG.EntryIdList.Clear();
            PKG.EntryNameList.Clear();
            PKG.pkgCount = 0;
            PKG.game = 0;
            PKG.patch = 0;
            PKG.addon = 0;
            PKG.app = 0;
            PKG.unknown = 0;
            PKG.official = 0;
            PKG.fake = 0;
            PKG.unlockerAddon = 0;
            _fileSizes.Clear();
            _pkgDirectories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            ClearFileBrowser();
            PKGTreeView.Enabled = true;
            listView1.Enabled = true;
            ClearSelectedPkgDetails();
            groupedListView?.Clear();
            InitializeEmptyGrid();
            labelDisplayTotalPKG.Text = "Displaying 0 PS4 PKG";
            toolStripStatusLabel2.Text = "Ready (empty)";
            Logger.LogInformation("PKG list emptied.");
        }

        /// <summary>Resets the selected-PKG details when the library becomes empty.</summary>
        private void ClearSelectedPkgDetails()
        {
            PKG.SelectedPKGFilename = null;
            darkLabel1.Text = "";
            label3.Text = "";

            ClearPictureBox(pictureBox1, hide: true);
            ClearPictureBox(pbPIC0, hide: true);
            ClearPictureBox(pbPIC1, hide: true);

            ClearDetailGrid(darkDataGridView2);
            ClearTrophyDetails();
            ClearDetailGrid(dgvEntryList);
            ClearDetailGrid(darkDataGridView4);
            ClearDetailGrid(dgvHeader);
            ClearDetailGrid(dgvUpdate);
            this.Text = "PS4 PKG Tool " + ApplicationVersion;
        }

        private static void ClearPictureBox(PictureBox pictureBox, bool hide)
        {
            Image image = pictureBox.Image;
            pictureBox.Image = null;
            if (hide) pictureBox.Visible = false;
            if (ReferenceEquals(Helper.Bitmap.Pic0, image)) Helper.Bitmap.Pic0 = null;
            if (ReferenceEquals(Helper.Bitmap.Pic1, image)) Helper.Bitmap.Pic1 = null;
            image?.Dispose();
        }

        private static void ReplacePictureBoxImage(PictureBox pictureBox, Image image)
        {
            Image previous = pictureBox.Image;
            pictureBox.Image = image;
            if (!ReferenceEquals(previous, image))
                previous?.Dispose();
        }

        private static void ClearDetailGrid(DarkDataGridView grid)
        {
            var images = new HashSet<Image>(ReferenceEqualityComparer.Instance);
            foreach (DataGridViewRow row in grid.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.Value is Image image)
                        images.Add(image);
            grid.DataSource = null;
            grid.Rows.Clear();
            foreach (Image image in images)
                image.Dispose();
        }

        private void ClearTrophyDetails()
        {
            ClearDetailGrid(TrophyGridView);
            foreach (Image image in Trophy.ImageToExtractList)
                image?.Dispose();
            Trophy.ImageToExtractList.Clear();
            Trophy.TrophyFilenameToExtractList.Clear();
        }

        private void toolStripMenuItem160_Click(object sender, EventArgs e)
        {
            Tool.OpenWebLink("https://ko-fi.com/pearlxcore");
        }

        private async void toolStripMenuItem158_Click(object sender, EventArgs e)
        {
            if (!await Task.Run(() => Tool.CheckForInternetConnection()))
            {
                ShowWarning("No internet connection detected. Cannot check for updates.", false);
                return;
            }

            try
            {
                Logger.LogInformation("Checking for latest PS4 PKG Tool..");
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var checker = new UpdateChecker("pearlxcore", "PS4-PKG-Tool", "v" + ApplicationVersion);

                UpdateType update = await checker.CheckUpdate();

                if (update == UpdateType.None)
                {
                    ShowInformation("The program is up to date.", true);
                }
                else
                {
                    var result = new UpdateNotifyDialog(checker).ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        Tool.OpenWebLink("https://github.com/pearlxcore/PS4-PKG-Tool/releases");
                    }
                }
            }
            catch (Exception ex)
            {
                // GitHubUpdate throws on API errors, rate limits (60 req/hr unauthenticated),
                // or malformed release tags - never let that crash the app.
                Logger.LogError("Update check failed: " + ex.Message);
                ShowWarning("Could not check for updates. Please try again later.\n\n" + ex.Message, false);
            }
        }

        private void toolStripMenuItem159_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm(ApplicationVersion))
            {
                about.ShowDialog();
            }
        }

        /// <summary>Delegates to the shared format source of truth (also used by the Mini Viewer and the Explorer shell integration).</summary>
        private string GetRenameFormat(int formatIndex)
            => PkgRenameFormats.GetFormat(formatIndex, appSettings_.RenameCustomName);

        private void RenamePkg_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            // Detect format index and scope from the menu item field name
            // Names follow: rename{All|Selected}Pkg{N}ToolStripMenuItem{1|2}
            string name = clickedMenuItem.Name;
            bool isAll = name.StartsWith("renameAllPkg", StringComparison.Ordinal);
            string selectionType = isAll ? PKGSelectionType.ALL : PKGSelectionType.SELECTED;

            // Extract format number from name (between "Pkg" and "ToolStripMenuItem")
            int pkgIdx = name.IndexOf("Pkg", StringComparison.Ordinal) + 3;
            int toolIdx = name.IndexOf("ToolStripMenuItem", StringComparison.Ordinal);
            if (pkgIdx < 3 || toolIdx < 0 || !int.TryParse(name.Substring(pkgIdx, toolIdx - pkgIdx), out int fmtNum))
                return;

            // Format 12 = Rename by Install Priority (handled by RenamePKGByPriority)
            if (fmtNum == 12)
            {
                if (Shadps4Manager.IsInstallationActive)
                {
                    ShowWarning("A shadPS4 installation is in progress.", false);
                    return;
                }
                var priorityList = GetSelectedPKGDirectoryList(selectionType);
                if (priorityList.Count == 0) { ShowError("No PKG files to rename.", false); return; }
                var priorityConfirm = DialogResultYesNo(
                    $"Rename {priorityList.Count} PKG file{(priorityList.Count == 1 ? "" : "s")} by install priority?\n\n" +
                    "Files will be grouped by Title ID and renamed with sequence prefixes:\n" +
                    "  00 - Base -> 01 - Update\n\nAdd-on and App PKGs are skipped.\n\nContinue?");
                if (priorityConfirm == DialogResult.No) return;
                Logger.LogInformation($"Rename by priority: {priorityList.Count} PKG(s)...");
                var priorityBg = new BackgroundWorker { WorkerReportsProgress = true };
                priorityBg.DoWork += (_, _) => RenamePKGByPriority(priorityList, priorityBg);
                priorityBg.ProgressChanged += (_, e) =>
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                    toolStripProgressBar1.Maximum = 100;
                    toolStripProgressBar1.Value = e.ProgressPercentage;
                    toolStripStatusLabel2.Text = e.UserState?.ToString() ?? "...";
                };
                priorityBg.RunWorkerCompleted += (_, _) =>
                {
                    try
                    {
                        if (PKG.CountFailRename > 0)
                            ShowWarning(PKG.CountFailRename + " PKG failed to rename by priority. See program log to view the errors.", false);
                        else
                            ShowInformation("PKG rename by priority done.", true);
                        Logger.LogInformation($"Rename by priority: done.");
                        SaveManifestAfterScan();
                        // GLV cells updated in-place by UpdatePKGFilename during rename
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Priority rename completion failed: " + ex.Message);
                    }
                    finally
                    {
                        // Always restore the form and menus - otherwise the GLV context menu
                        // stays disabled after this operation.
                        toolStripStatusLabel2.Text = "...";
                        toolStripProgressBar1.Value = 0;
                        this.Enabled = true;
                        SetOperationMenusEnabled(true);
                    }
                };
                this.Invoke((Action)(() => this.Enabled = false));
                priorityBg.RunWorkerAsync();
                return;
            }

            string format;
            if (fmtNum == 11)
            {
                if (string.IsNullOrEmpty(appSettings_.RenameCustomName))
                { ShowError("Set custom name format in settings.", true); return; }
                format = appSettings_.RenameCustomName;
            }
            else
            {
                format = GetRenameFormat(fmtNum);
                if (format == null) return;
            }

            // Warn if a filter is active for "All" rename
            if (isAll)
            {
                var dv = (PKGGridView.DataSource as DataTable)?.DefaultView;
                if (dv != null && !string.IsNullOrEmpty(dv.RowFilter))
                {
                    var result = DialogResultYesNo(
                        "A filter is currently active. Rename All will affect ALL PKGs including those hidden by the filter.\n\nContinue?");
                    if (result == DialogResult.No) return;
                }
            }

            var pkgList = GetSelectedPKGDirectoryList(selectionType);
            if (pkgList.Count == 0) { ShowError("No PKG files to rename.", false); return; }

            // Build preview example for confirmation
            string previewName = format
                .Replace("{TITLE}", "{Title}")
                .Replace("{TITLE_ID}", "CUSA00000")
                .Replace("{APP_VERSION}", "1.00")
                .Replace("{VERSION}", "1.00")
                .Replace("{CATEGORY}", "Game")
                .Replace("{CONTENT_ID}", "xxxxx")
                .Replace("{CONTENT_ID2}", "xxxxx")
                .Replace("{REGION}", "EU")
                .Replace("{SYSTEM_VERSION}", "9.00");

            var confirmResult = DialogResultYesNo(
                $"Rename {pkgList.Count} PKG file{(pkgList.Count == 1 ? "" : "s")}?\n\nFormat: {format}\nExample: {previewName}.pkg");
            if (confirmResult == DialogResult.No) return;

            RenamePKG(format, pkgList);
        }

        private void ExportPKGToExcel_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            // global
            if (clickedMenuItem == globalExportPKGListToExcelToolStripMenuItem1 || clickedMenuItem == globalExportPKGListToExcelToolStripMenuItem2)
            {
                InitializedExportPKGToExcel(GenerateDatatableFromSelectedPKG(PKGSelectionType.ALL));
            }

            // selected
            if (clickedMenuItem == selectedExportPKGListToExcelToolStripMenuItem1 || clickedMenuItem == selectedExportPKGListToExcelToolStripMenuItem2)
            {
                InitializedExportPKGToExcel(GenerateDatatableFromSelectedPKG(PKGSelectionType.SELECTED));
            }
        }

        private void InitializedExportPKGToExcel(DataTable dataTable = null)
        {
            if (ShowSaveFileDialog("Export PKG List to Excel", "*.xlsx|*.xlsx", out SaveFileDialog sfd))
            {
                string excelFilename = sfd.FileName;
                var bg = new BackgroundWorker();
                bg.DoWork += delegate
                {
                    MorePKGTool("EXPORT", dataTable, excelFilename);
                };
                bg.RunWorkerCompleted += delegate
                {
                    toolStripStatusLabel2.Text = "... ";
                    this.Enabled = true;
                };
                bg.RunWorkerAsync();
            }
        }

        private void CopyTitleID()
        {
            var ids = new List<string>();
            foreach (DataGridViewRow row in PKGGridView.SelectedRows)
            {
                string tid = row.Cells[2].Value?.ToString();
                if (!string.IsNullOrEmpty(tid)) ids.Add(tid);
            }
            if (ids.Count == 0) { ShowError("No PKG file selected.", false); return; }
            Clipboard.SetText(string.Join("\n", ids));
            ShowInformation($"{ids.Count} Title ID(s) copied to clipboard.", true);
        }

        private void CopyID_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == copyTitleIdtoolStripMenuItem1 || clickedMenuItem == copyTitleIdtoolStripMenuItem2)
            {
                CopyTitleID();
            }
            if (clickedMenuItem == copyContentIdtoolStripMenuItem1 || clickedMenuItem == copyContentIdtoolStripMenuItem2)
            {
                CopyContentID();
            }
            if (clickedMenuItem == copyTitleToolStripMenuItem1 || clickedMenuItem == copyTitleToolStripMenuItem2)
            {
                CopyTitle();
            }
            if (clickedMenuItem == copyFilenameToolStripMenuItem1 || clickedMenuItem == copyFilenameToolStripMenuItem2)
            {
                CopyFilename();
            }
        }

        private void ViewPKGExplorer_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == viewPkgExplorerStripMenuItem1 || clickedMenuItem == viewPkgExplorerStripMenuItem2)
            {
                ViewPKGInExplorer();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel5.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        #region ImageIconExtractor
        private void InitializedImageIconExtractor(string imageType, string selectionType)
        {
            DialogResult extractionDialog = DialogResultYesNoCancel("Create subfolder for each PKG?");

            if (extractionDialog == DialogResult.Cancel)
                return;

            var respectiveExtract = (extractionDialog == DialogResult.Yes);

            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                Logger.LogInformation("Saving artwork..");
                toolStripStatusLabel2.Text = "Saving artwork..";
                var outputDirectory = fbd.SelectedPath;
                var pkgList = GetSelectedPKGDirectoryList(selectionType);
                Logger.LogInformation($"Save artwork: {pkgList.Count} PKG(s)");
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = 100;
                toolStripProgressBar1.Value = 0;
                var backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += (s, e) =>
                {
                    ImageIconExtractor(imageType, pkgList, outputDirectory, respectiveExtract);
                };
                backgroundWorker.RunWorkerCompleted += (s, e) =>
                {
                    ImageIconPostExtraction();
                };
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void ExtractImageIcon_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is string tag)
            {
                var parts = tag.Split('|');
                InitializedImageIconExtractor(parts[0], parts[1]);
            }
        }
        #endregion ImageIconExtractor

        #region PKGScanning
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            OpenPKGDirectorySettings();
        }

        private void OpenPKGDirectorySettings()
        {
            OpenProgramSettings();
        }

        private void managePS4PKGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPKGDirectorySettings();
        }

        static bool IsExcluded(List<string> exludedDirList, string target)
        {
            return exludedDirList.Any(d => new DirectoryInfo(target).Name.Equals(d));
        }

        private bool IsRootDirectory(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.Parent == null;
        }

        public static void autoResizeColumns(ListView lv)
        {
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.ColumnHeaderCollection cc = lv.Columns;
            for (int i = 0; i < cc.Count; i++)
            {
                int colWidth = TextRenderer.MeasureText(cc[i].Text, lv.Font).Width + 10;
                if (colWidth > cc[i].Width)
                {
                    cc[i].Width = colWidth;
                }
            }
        }


        private void PKGGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void WireAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Form) continue; // already wired separately
                c.AllowDrop = true;
                c.DragEnter += PKGGridView_DragEnter;
                c.DragOver += (s, ev) => { if (ev.Data.GetDataPresent(DataFormats.FileDrop)) ev.Effect = DragDropEffects.Copy; };
                c.DragDrop += PKGGridView_DragDrop;
                WireAllControls(c);
            }
        }

        private void PKGGridView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = null;
            try { files = (string[])e.Data.GetData(DataFormats.FileDrop); } catch (Exception ex) { Logger.LogWarning("Drag-drop data retrieval failed: " + ex.Message); }
            if (files == null || files.Length == 0) return;

            // Collect valid folder paths first.
            var folders = new List<string>();
            foreach (string path in files)
            {
                string folderPath = path;
                if (File.Exists(path))
                {
                    if (Path.GetExtension(path).ToUpperInvariant() != ".PKG") continue;
                    folderPath = Path.GetDirectoryName(path);
                }
                else if (!Directory.Exists(folderPath))
                    continue;
                if (!folders.Contains(folderPath, StringComparer.OrdinalIgnoreCase))
                    folders.Add(folderPath);
            }

            if (folders.Count == 0) return;

            // One dialog for all folders - recursive + add-to-directories options.
            using (var prompt = new DropFolderPrompt(folders))
            {
                prompt.ShowDialog();
                if (!prompt.Confirmed) return;

                if (prompt.AddToDirectories)
                {
                    foreach (var f in prompt.FolderPaths)
                    {
                        if (!appSettings_.PkgDirectories.Any(d =>
                            string.Equals(d, f, StringComparison.OrdinalIgnoreCase)))
                        {
                            appSettings_.PkgDirectories.Add(f);
                        }
                    }
                    SettingsManager.SaveSettings(appSettings_, SettingFilePath);
                }

                // Scan sequentially (shared DataTable, no race).
                var pending = new Queue<string>(prompt.FolderPaths);
                var first = pending.Dequeue();
                ScanDroppedFolder(first, prompt.ScanRecursively, pending);
            }
        }

        private void ScanDroppedFolder(string folderPath, bool recursive,
            Queue<string> pending = null)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Enabled = false;
                PKGGridView.Enabled = false;
                darkDataGridView2.Enabled = false;
                SetOperationMenusEnabled(false);
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Value = 0;
            });

            DataTable scanDt = null;
            int addedCount = 0;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, args) =>
            {
                var scan = PkgDirectoryScanner.Scan(folderPath, recursive, ExcludedDirectoryList,
                    includeImmediateChildrenWhenNonRecursive: false);
                var pkgFiles = scan.Files.ToList();
                foreach (var issue in scan.Issues)
                    Logger.LogWarning($"Could not scan '{issue.Path}': {issue.Message}");

                int totalFiles = pkgFiles.Count;
                this.Invoke((MethodInvoker)delegate
                {
                    toolStripProgressBar1.Maximum = totalFiles;
                });

                if (totalFiles == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        toolStripStatusLabel2.Text = $"No PKG files found in {folderPath}.";
                    });
                    return;
                }

                DataTable dt = PKGGridView.DataSource as DataTable;
                if (dt == null)
                {
                    dt = PkgColumns.CreateSchema();
                    this.Invoke((MethodInvoker)delegate { PKGGridView.DataSource = dt; });
                }
                // Detach DataTable from DGV while adding rows on background thread to prevent STA exceptions
                scanDt = dt;
                this.Invoke((MethodInvoker)delegate { PKGGridView.DataSource = null; });

                // ── Pre-compute loop-invariant data ────────────────
                var verRegex2 = new Regex(@"^0+(?=\d+\.)", RegexOptions.Compiled);
                var imgCvt2 = new ImageConverter();
                var regionIconCache = new Dictionary<string, byte[]>
                {
                    [PKGRegion.EU] = (byte[])imgCvt2.ConvertTo(Properties.Resources.eu, typeof(byte[])),
                    [PKGRegion.US] = (byte[])imgCvt2.ConvertTo(Properties.Resources.us, typeof(byte[])),
                    [PKGRegion.UK] = (byte[])imgCvt2.ConvertTo(Properties.Resources.us, typeof(byte[])),
                    [PKGRegion.JAPAN] = (byte[])imgCvt2.ConvertTo(Properties.Resources.jp, typeof(byte[])),
                    [PKGRegion.HONG_KONG] = (byte[])imgCvt2.ConvertTo(Properties.Resources.hk, typeof(byte[])),
                    [PKGRegion.ASIA] = (byte[])imgCvt2.ConvertTo(Properties.Resources.asia, typeof(byte[])),
                    [PKGRegion.KOREA] = (byte[])imgCvt2.ConvertTo(Properties.Resources.kr, typeof(byte[])),
                };
                bool chkBackport2 = File.Exists(Backport.BackportInfoFile);
                var backportCache2 = chkBackport2 ? Backport.LoadCache() : null;
                dynamic ps5BcCache2 = null;
                bool usePs5Bc2 = appSettings_.psvr_neo_ps5bc_check && File.Exists(Ps5BcJsonFile);
                if (usePs5Bc2) { try { ps5BcCache2 = JsonConvert.DeserializeObject(File.ReadAllText(Ps5BcJsonFile)); } catch { usePs5Bc2 = false; } }
                // HashSet for O(1) duplicate detection
                var existingSet = new HashSet<string>(PKG.VerifiedPs4PkgList, StringComparer.OrdinalIgnoreCase);

                int processed = 0;
                foreach (string pkgFile in pkgFiles)
                {
                    processed++;
                    if (processed % 10 == 0 || processed == totalFiles)
                    {
                        int p = processed, t = totalFiles;
                        this.Invoke((MethodInvoker)delegate { toolStripStatusLabel2.Text = $"Loading PS4 PKG.. ({p}/{t})"; toolStripProgressBar1.Increment(10); });
                    }
                    // O(1) duplicate check
                    if (!existingSet.Add(pkgFile)) continue;

                    try
                    {
                        PkgMetadata ps4Pkg = PkgMetadataReader.ReadMetadataOnly(pkgFile);
                        string pkgAppVersion = verRegex2.Replace(ps4Pkg.APP_VER, "");
                        string pkgMinFirmware = ps4Pkg.PKG_Type.ToString() == PKGCategory.ADDON ? "NA" : "";
                        string pkgSdkVersion = "";
                        string pkgVersion = "";
                        foreach (var t in ps4Pkg.SfoTables)
                        {
                            if (t.Name == "SYSTEM_VER")
                                pkgMinFirmware = PkgSystemVersion.Format(t.Value);
                            if (t.Name == "PUBTOOLINFO")
                                pkgSdkVersion = PkgBuildInfoParser.Parse(t.Value)
                                    .FirstOrDefault(field => field.Name == "PS4 SDK Version")?.Value ?? "";
                            if (t.Name == "VERSION") pkgVersion = verRegex2.Replace(t.Value, "");
                        }
                        if (!string.IsNullOrWhiteSpace(pkgSdkVersion))
                            pkgMinFirmware = PkgSystemVersion.FormatSdkVersion(pkgSdkVersion);
                        pkgAppVersion = (pkgAppVersion == string.Empty) ? "NA" : pkgAppVersion;

                        string pkgFileName = Path.GetFileName(pkgFile);
                        string pkgDirectoryName = Path.GetDirectoryName(pkgFile);
                        string pkgSize = ByteSize.FromBytes(new System.IO.FileInfo(pkgFile).Length).ToString();
                        string pkgState = ps4Pkg.PKGState.ToString();
                        string pkgType = ps4Pkg.PKG_Type.ToString();

                        byte[] pkgRegionIcon = null;
                        regionIconCache.TryGetValue(ps4Pkg.Region, out pkgRegionIcon);

                        string psVr = "", neoEnable = "", ps5bc = "";
                        if (usePs5Bc2 && ps5BcCache2 != null && pkgType == PKGCategory.GAME)
                        {
                            foreach (var item in ps5BcCache2)
                            {
                                if (item.npTitleIdshort == ps4Pkg.TITLEID)
                                {
                                    string psvr = item.psVr, neo = item.neoEnable, pbc = item.ps5bc;
                                    psVr = (psvr == "1" || psvr == "2") ? "Yes" : (psvr == "0") ? "No" : (psvr != "null") ? "NA" : "";
                                    neoEnable = (neo == "1") ? "Yes" : (neo == "0") ? "No" : (neo != "null") ? "NA" : "";
                                    ps5bc = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(pbc.Replace("_", " ").ToLower());
                                }
                            }
                        }
                        else if (usePs5Bc2) { psVr = neoEnable = ps5bc = "-"; }

                        // Backport check
                        string pkgIsBackported = (backportCache2 != null && backportCache2.TryGetValue(pkgFile, out var bp2)) ? bp2 : "No";

                        // Columns assigned by name (never positionally) so a
                        // new column in PkgColumns cannot shift data.
                        var row = dt.NewRow();
                        row[PkgColumns.Filename] = pkgFileName;
                        row[PkgColumns.Title] = ps4Pkg.PS4_Title;
                        row[PkgColumns.TitleId] = ps4Pkg.TITLEID;
                        row[PkgColumns.ContentId] = ps4Pkg.SfoContentId;
                        row[PkgColumns.Region] = pkgRegionIcon;
                        row[PkgColumns.SystemVersion] = pkgMinFirmware;
                        row[PkgColumns.AppVersion] = pkgVersion + $" [{pkgAppVersion}]";
                        row[PkgColumns.PkgType] = pkgState;
                        row[PkgColumns.Category] = pkgType;
                        row[PkgColumns.Size] = pkgSize;
                        row[PkgColumns.Psvr] = psVr;
                        row[PkgColumns.Ps4ProEnhanced] = neoEnable;
                        row[PkgColumns.Ps5Bc] = ps5bc;
                        row[PkgColumns.Directory] = pkgDirectoryName;
                        row[PkgColumns.Backported] = pkgIsBackported;
                        row[PkgColumns.LatestUpdate] = "NA";
                        row[PkgColumns.Shadps4] = ""; // filled by ApplyShadps4Status
                        row[PkgColumns.RegionName] = ps4Pkg.Region;
                        row[PkgColumns.SystemVersionNum] = PkgColumns.ParseSystemVersionNum(pkgMinFirmware);
                        dt.Rows.Add(row);

                        // Update type counts
                        switch (ps4Pkg.PKG_Type.ToString())
                        {
                            case PKGCategory.GAME: PKG.game++; break;
                            case PKGCategory.PATCH: PKG.patch++; break;
                            case PKGCategory.APP: PKG.app++; break;
                            case PKGCategory.ADDON: PKG.addon++; break;
                            default: PKG.unknown++; break;
                        }
                        PKG.pkgCount++;
                        addedCount++;
                        lock (PKG.VerifiedPs4PkgList)
                            PKG.VerifiedPs4PkgList.Add(pkgFile); // keep the verified list in sync with the grid
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to process dropped PKG {pkgFile}: {ex.Message}");
                    }
                }
                ApplyShadps4Status(scanDt);

                int finalAdded = addedCount;
                this.Invoke((MethodInvoker)delegate
                {
                    toolStripProgressBar1.Value = 0;
                    toolStripStatusLabel2.Text = $"Added {finalAdded} PKG(s) from {folderPath}. Total: {dt.Rows.Count}";
                    labelDisplayTotalPKG.Text = $"Displaying {dt.Rows.Count} PS4 PKG";
                });

                Logger.LogInformation($"Dropped folder scan complete: {finalAdded} new PKGs from {folderPath}.");
            };
            bw.RunWorkerCompleted += (s, args) =>
            {
                // Consume the one-shot BGM flag so a subsequent directory scan
                // doesn't fire BGM extraction at the wrong time (the flag was
                // set during app startup and drag-drop never consumed it).
                FinalizePkgProcess = false;

                if (args.Error != null)
                    Logger.LogError($"Dropped folder scan failed for {folderPath}: {args.Error}");

                // Reattach even when every candidate failed to parse.
                if (scanDt != null)
                    PKGGridView.DataSource = scanDt;

                this.Enabled = true;
                PKGGridView.Enabled = true;
                darkDataGridView2.Enabled = true;

                if (addedCount == 0)
                {
                    SetOperationMenusEnabled(PKGGridView.Rows.Count > 0);
                    toolStripProgressBar1.Value = 0;
                }
                else
                {
                    Logger.LogInformation($"Drag-drop scan done. Folder: {folderPath}");
                    SetOperationMenusEnabled(true);
                    try
                    {
                        UpdateDataGridViewColumnVisibility();
                        SaveManifestAfterScan();
                        PopulateGroupedView();
                        PKGGridView.Sort(PKGGridView.Columns[0], ListSortDirection.Ascending);
                        if (appSettings_.AutoFetchUpdate) FetchAllUpdateVersions();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Post-scan refresh failed: " + ex.Message);
                    }
                    GetDrivesFreeSpace();
                    labelDisplayTotalPKG.Text = $"Displaying {PKGGridView.Rows.Count} PS4 PKG";
                    SetBackgroundMusicVolume();
                    SetDataGridViewCellStyle();
                    toolStripStatusLabel2.Text = "... ";
                    toolStripProgressBar1.Value = 0;
                }

                // Always continue, including after an empty, inaccessible, or
                // invalid first folder.
                if (pending != null && pending.Count > 0)
                    ScanDroppedFolder(pending.Dequeue(), recursive, pending);
            };
            bw.RunWorkerAsync();
        }

        private void LoadPKGGridView()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                #region loadPkgProcess
                this.Invoke((MethodInvoker)delegate
                {
                    PKG.SelectedPKGFilename = null;
                    pictureBox1.Image = null;
                    darkLabel1.Text = "";
                });

                PKG.VerifiedPs4PkgList.Clear();
                PKG.EntryIdList.Clear();
                PKG.EntryNameList.Clear();
                //PKG.totalPkg = 0;
                PKG.pkgCount = 0;
                PKG.game = 0;
                PKG.patch = 0;
                PKG.app = 0;
                PKG.unknown = 0;
                PKG.addon = 0;
                this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Value = 0; });

                // Load from manifest cache if available (fast startup, no PKG reading)
                if (Helper.LoadFromManifest && ManifestHelper.ManifestExists())
                {
                    try
                    {
                        var manifest = ManifestHelper.LoadManifest();
                        if (manifest != null && ManifestHelper.ValidateManifest(manifest, appSettings_).IsValid)
                        {
                            var (validEntries, removed) = ManifestHelper.FilterValidEntries(manifest.Entries);
                            Logger.LogInformation($"Manifest loaded: {validEntries.Count} entries" + (removed > 0 ? $", {removed} removed" : ""));
                            var dt = ManifestHelper.BuildDataTableFromManifest(validEntries);
                            var pkgPaths = ManifestHelper.BuildPkgPathList(validEntries);

                            PKG.VerifiedPs4PkgList = pkgPaths;
                            PKG.pkgCount = pkgPaths.Count;
                            PKG.game = validEntries.Count(e => e.Category == "Game");
                            PKG.patch = validEntries.Count(e => e.Category == "Patch");
                            PKG.addon = validEntries.Count(e => e.Category == "Addon");
                            PKG.app = validEntries.Count(e => e.Category == "App");
                            PKG.unknown = validEntries.Count(e => e.Category == "Unknown");
                            PKG.official = validEntries.Count(e => e.PkgType == "Official");
                            PKG.fake = validEntries.Count(e => e.PkgType == "Fake");

                            ApplyShadps4Status(dt);
                            this.Invoke((MethodInvoker)delegate
                            {
                                PKGGridView.DataSource = dt;
                                HideFilterColumns();
                            });
                            return; // Skip directory scan - PostPkgLoad runs in RunWorkerCompleted
                        }
                        else
                        {
                            Logger.LogInformation("Manifest invalid or expired. Falling back to directory scan.");
                            ManifestHelper.DeleteManifest();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to load manifest: {ex.Message}. Falling back to directory scan.");
                    }
                }

                var pkgFileSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var PkgDirectoryList = appSettings_.PkgDirectories;
                foreach (var directory in PkgDirectoryList.Where(Directory.Exists))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        toolStripStatusLabel2.Text = "Scanning directory.. " + "(" + directory + ") ";
                    });
                    var scan = PkgDirectoryScanner.Scan(
                        directory, appSettings_.ScanRecursive, ExcludedDirectoryList);
                    foreach (string pkgFile in scan.Files)
                        pkgFileSet.Add(pkgFile);
                    foreach (var issue in scan.Issues)
                        Logger.LogWarning($"Could not scan '{issue.Path}': {issue.Message}");
                }

                List<string> PkgFileList = pkgFileSet
                    .OrderBy(path => path, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                // datatable for gridview control
                DataTable dttemp = PkgColumns.CreateSchema();

                // Validate headers per file. A file disappearing or becoming
                // locked during a scan must not abort the remaining library.
                var headerVerifiedPaths = new List<string>();
                foreach (var item in PkgFileList)
                {
                    try
                    {
                        byte[] bufferA = PKG.GetPkgHeaderBuffer(item);
                        if (PKG.CompareBytes(bufferA, PKG.PkgHeader) || PKG.CompareBytes(bufferA, PKG.PkgHeader1) ||
                            PKG.CompareBytes(bufferA, PKG.PkgHeader2) || PKG.CompareBytes(bufferA, PKG.PkgHeader3) ||
                            PKG.CompareBytes(bufferA, PKG.PkgHeader4))
                            headerVerifiedPaths.Add(item);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogWarning($"Could not validate PKG header '{item}': {ex.Message}");
                    }
                }

                this.Invoke((MethodInvoker)delegate
                {
                    toolStripProgressBar1.Visible = true;
                    //toolStripProgressBar1.Maximum = PKG.totalPkg;
                    toolStripProgressBar1.Maximum = headerVerifiedPaths.Count;
                });

                Logger.LogInformation($"Scanning {headerVerifiedPaths.Count} PKGs from directories...");
                // ── Pre-compute loop-invariant data ────────────────
                var verRegex = new Regex(@"^0+(?=\d+\.)", RegexOptions.Compiled);
                var imageCvt = new ImageConverter();
                // Pre-convert all region icons once
                var regionIcons = new Dictionary<string, byte[]>
                {
                    [PKGRegion.EU] = (byte[])imageCvt.ConvertTo(Properties.Resources.eu, typeof(byte[])),
                    [PKGRegion.US] = (byte[])imageCvt.ConvertTo(Properties.Resources.us, typeof(byte[])),
                    [PKGRegion.UK] = (byte[])imageCvt.ConvertTo(Properties.Resources.us, typeof(byte[])),
                    [PKGRegion.JAPAN] = (byte[])imageCvt.ConvertTo(Properties.Resources.jp, typeof(byte[])),
                    [PKGRegion.HONG_KONG] = (byte[])imageCvt.ConvertTo(Properties.Resources.hk, typeof(byte[])),
                    [PKGRegion.ASIA] = (byte[])imageCvt.ConvertTo(Properties.Resources.asia, typeof(byte[])),
                    [PKGRegion.KOREA] = (byte[])imageCvt.ConvertTo(Properties.Resources.kr, typeof(byte[])),
                };
                bool checkBackport = File.Exists(Backport.BackportInfoFile);
                var backportCache = checkBackport ? Backport.LoadCache() : null;
                // Cache PS5 BC JSON once (not per PKG)
                dynamic ps5BcJsonCache = null;
                bool usePs5Bc = appSettings_.psvr_neo_ps5bc_check && File.Exists(Ps5BcJsonFile);
                if (usePs5Bc)
                {
                    try { ps5BcJsonCache = JsonConvert.DeserializeObject(File.ReadAllText(Ps5BcJsonFile)); }
                    catch { usePs5Bc = false; }
                }

                // Bulk load: suppress index/constraint maintenance during insert
                dttemp.BeginLoadData();

                int metadataProcessed = 0;
                // A path becomes verified only after its metadata and grid row
                // were both created successfully.
                foreach (var pkg in headerVerifiedPaths)
                {
                    metadataProcessed++;
                    if (metadataProcessed % 10 == 0 || metadataProcessed == headerVerifiedPaths.Count)
                    {
                        darkStatusStrip1.Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabel2.Text = $"Loading PS4 PKG.. ({metadataProcessed}/{headerVerifiedPaths.Count}) ";
                            toolStripProgressBar1.Value = Math.Min(metadataProcessed, toolStripProgressBar1.Maximum);
                        });
                    }
                    PkgMetadata ps4Pkg;
                    try
                    {
                        ps4Pkg = PkgMetadataReader.ReadMetadataOnly(pkg);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to read PKG, skipping: {Path.GetFileName(pkg)} - {ex.Message}");
                        continue;
                    }
                    
                    string pkgVersion = "";
                    string pkgAppVersion = verRegex.Replace(ps4Pkg.APP_VER, "");
                    string pkgTitleId = ps4Pkg.TITLEID;
                    string pkgFileName = Path.GetFileName(pkg);
                    string pkgDirectoryName = Path.GetDirectoryName(pkg);
                    string psVr = "";
                    string neoEnable = "";
                    string ps5bc = "";
                    string pkgSystemVersion = "";
                    string pkgSdkVersion = "";
                    byte[] pkgRegionIcon = null;
                    string pkgState = ps4Pkg.PKGState.ToString();
                    string pkgType = ps4Pkg.PKG_Type.ToString();

                    // get pkg's minimum system fw + version
                    foreach (var t in ps4Pkg.SfoTables)
                    {
                        if (t.Name == "SYSTEM_VER")
                            pkgSystemVersion = PkgSystemVersion.Format(t.Value);
                        if (t.Name == "PUBTOOLINFO")
                            pkgSdkVersion = PkgBuildInfoParser.Parse(t.Value)
                                .FirstOrDefault(field => field.Name == "PS4 SDK Version")?.Value ?? "";
                        if (t.Name == "VERSION")
                            pkgVersion = verRegex.Replace(t.Value, "");
                    }
                    if (!string.IsNullOrWhiteSpace(pkgSdkVersion))
                        pkgSystemVersion = PkgSystemVersion.FormatSdkVersion(pkgSdkVersion);

                    // get pkg full size
                    long fileSizeBytes = new System.IO.FileInfo(pkg).Length;
                    string pkgSize = ByteSize.FromBytes(fileSizeBytes).ToString();

                    // backward compatible info (cached JSON)
                    if (usePs5Bc && ps5BcJsonCache != null)
                    {
                        if (pkgType == PKGCategory.GAME)
                        {
                            foreach (var item in ps5BcJsonCache)
                            {
                                if (item.npTitleIdshort == ps4Pkg.TITLEID)
                                {
                                    string psvr = item.psVr;
                                    string neo = item.neoEnable;
                                    string ps5bc_ = item.ps5bc;
                                    psVr = (psvr == "1" || psvr == "2") ? "Yes" : (psvr == "0") ? "No" : (psvr != "null") ? "NA" : "";
                                    neoEnable = (neo == "1") ? "Yes" : (neo == "0") ? "No" : (neo != "null") ? "NA" : "";
                                    ps5bc = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(ps5bc_.Replace("_", " ").ToLower());
                                }
                            }
                        }
                        else { psVr = neoEnable = ps5bc = "-"; }
                    }

                    // get region icon (pre-computed)
                    var region = ps4Pkg.Region;
                    regionIcons.TryGetValue(region, out pkgRegionIcon);

                    // check if pkg is backported (cached file existence)
                    string pkgIsBackported = (backportCache != null && backportCache.TryGetValue(pkg, out var bp)) ? bp : "No";


                    // add items to datatable
                    string pkgMinFirmware = ps4Pkg.PKG_Type.ToString() == PKGCategory.ADDON ? "NA" : $"{pkgSystemVersion}";
                    pkgAppVersion = (pkgAppVersion == string.Empty) ? "NA" : pkgAppVersion;
                    // Columns assigned by name (never positionally) so a
                    // new column in PkgColumns cannot shift data.
                    var row = dttemp.NewRow();
                    row[PkgColumns.Filename] = pkgFileName;
                    row[PkgColumns.Title] = ps4Pkg.PS4_Title;
                    row[PkgColumns.TitleId] = pkgTitleId;
                    row[PkgColumns.ContentId] = ps4Pkg.SfoContentId;
                    row[PkgColumns.Region] = pkgRegionIcon;
                    row[PkgColumns.SystemVersion] = pkgMinFirmware;
                    row[PkgColumns.AppVersion] = pkgVersion + $" [{pkgAppVersion}]";
                    row[PkgColumns.PkgType] = pkgState;
                    row[PkgColumns.Category] = pkgType;
                    row[PkgColumns.Size] = pkgSize;
                    row[PkgColumns.Psvr] = psVr;
                    row[PkgColumns.Ps4ProEnhanced] = neoEnable;
                    row[PkgColumns.Ps5Bc] = ps5bc;
                    row[PkgColumns.Directory] = pkgDirectoryName;
                    row[PkgColumns.Backported] = pkgIsBackported;
                    row[PkgColumns.LatestUpdate] = "NA";
                    row[PkgColumns.Shadps4] = ""; // filled by ApplyShadps4Status
                    row[PkgColumns.RegionName] = region;
                    row[PkgColumns.SystemVersionNum] = PkgColumns.ParseSystemVersionNum(pkgMinFirmware);
                    dttemp.Rows.Add(row);
                    lock (PKG.VerifiedPs4PkgList)
                        PKG.VerifiedPs4PkgList.Add(pkg);

                    switch (ps4Pkg.PKG_Type.ToString())
                    {
                        case PKGCategory.GAME: PKG.game++; break;
                        case PKGCategory.PATCH: PKG.patch++; break;
                        case PKGCategory.APP: PKG.app++; break;
                        case PKGCategory.ADDON: PKG.addon++; break;
                        default: PKG.unknown++; break;
                    }

                    switch (ps4Pkg.PKGState.ToString())
                    {
                        case PKGState.OFFICIAL: PKG.official++; break;
                        case PKGState.FAKE: PKG.fake++; break;
                        case PKGState.ADDON_UNLOCKER: PKG.unlockerAddon++; break;
                    }

                    PKG.pkgCount++;
                }
                dttemp.EndLoadData();
                ApplyShadps4Status(dttemp);

                // Set DataSource ONCE after loop - NOT inside every iteration
                darkStatusStrip1.Invoke((MethodInvoker)delegate
                {
                    PKGGridView.SuspendLayout();
                    PKGGridView.DataSource = dttemp;
                    for (int i = 10; i <= 12; i++) // PSVR, PS4 Pro Enhanced, PS5 BC (col 9 is Size - keep it)
                        PKGGridView.Columns[i].Visible = appSettings_.psvr_neo_ps5bc_check;
                    HideFilterColumns();
                    foreach (DataGridViewColumn column in PKGGridView.Columns)
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    PKGGridView.ResumeLayout();
                });
                #endregion loadPkgProcess1
            };
            bw.RunWorkerCompleted += (_, args) =>
            {
                if (args.Error != null)
                {
                    Logger.LogError("PKG directory scan failed: " + args.Error);
                    ShowError("The PKG scan stopped unexpectedly:\n" + args.Error.Message, false);
                }
                PostPkgLoad();
            };
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Wraps a DataRow with a FilePath property so the GLV can extract
        /// the PKG path on selection change.
        /// </summary>
        private class GlvItem
        {
            public DataRow Row { get; }
            public string Path => FilePath;
            public string FilePath => System.IO.Path.Combine(
                Row["Directory"]?.ToString() ?? "",
                Row["Filename"]?.ToString() ?? "");
            public GlvItem(DataRow row) { Row = row; }
        }

        private void PopulateGroupedView()
        {
            try
            {
                if (groupedListView == null) return;

                var dt = PKGGridView.DataSource as DataTable;
                if (dt == null || dt.DefaultView.Count == 0)
                {
                    groupedListView.Clear();
                    darkLabelGroupCount.Text = "";
                    UpdatePackageActionButtonStates();
                    return;
                }

                // Respect the DGV's active RowFilter so the GLV mirrors what the table shows -
                // otherwise GLV selection can target rows hidden by the filter and never focus them.
                var visibleRows = dt.DefaultView.Cast<DataRowView>().Select(v => v.Row).ToList();

                // Build column list based on DGV visibility settings
                var glvColumns = GetGlvColumns();
                string columnSignature = string.Join("\u001f", glvColumns.Select(column => column.Item1));
                if (!string.Equals(_glvColumnSignature, columnSignature, StringComparison.Ordinal))
                {
                    groupedListView.DefineColumns(glvColumns.ToArray());
                    _glvColumnSignature = columnSignature;
                }

                var items = visibleRows
                    .Select(r => new GlvItem(r))
                    .OrderBy(i => i.Row["Filename"]?.ToString() ?? "", StringComparer.OrdinalIgnoreCase)
                    .ToList();

                string groupCol = GroupByColumn;
                groupedListView.SetGroups(
                    items,
                    item =>
                    {
                        // Empty keys (e.g. PKGs without a shadPS4 compatibility
                        // status) render as a blank header "▼  (N)" at the very
                        // top - name the bucket so it is understandable.
                        string key = item.Row[groupCol]?.ToString() ?? "";
                        return string.IsNullOrWhiteSpace(key) ? "Unknown" : key;
                    },
                    item => BuildGlvRowData(item),
                    presentationFunc: BuildGlvCellPresentation
                );

                darkLabelGroupCount.Text = items.Count > 0 ? $"({items.Count})" : "";
                UpdatePackageActionButtonStates();
                // Groups start expanded; collapse on first tab switch to Group
            }
            catch (Exception ex)
            {
                // A GLV refresh failure must never break the enclosing operation's completion
                // (which would leave the form and the GLV context menu disabled).
                Logger.LogWarning("Failed to refresh grouped view: " + ex.Message);
            }
        }

        private static List<(string, int)> GetGlvColumns()
        {
            // DarkGroupedListView treats width 0 as Fill mode. Give each column
            // a starting width instead, so user-resized widths are retained.
            var cols = new List<(string, int)> { ("Filename", 180), ("Title", 220) };
            if (appSettings_.pkgtitleIdColumn) cols.Add(("Title ID", 100));
            if (appSettings_.pkgcontentIdColumn) cols.Add(("Content ID", 260));
            if (appSettings_.pkgregionColumn) cols.Add(("Region", 85));
            if (appSettings_.pkgminimumFirmwareColumn) cols.Add((PkgColumns.SystemVersion, 110));
            if (appSettings_.pkgversionColumn) cols.Add(("Version [App Version]", 140));
            if (appSettings_.pkgTypeColumn) cols.Add(("PKG Type", 90));
            if (appSettings_.pkgcategoryColumn) cols.Add(("Category", 90));
            if (appSettings_.pkgsizeColumn) cols.Add(("Size", 95));
            if (appSettings_.psvr_neo_ps5bc_check) { cols.Add(("PSVR", 65)); cols.Add(("PS4 Pro Enhanced", 125)); cols.Add(("PS5 BC", 80)); }
            if (appSettings_.pkgDirectoryColumn) cols.Add(("Directory", 240));
            if (appSettings_.pkgBackportColumn) cols.Add(("Backported", 90));
            if (appSettings_.AutoFetchUpdate) cols.Add(("Latest Update", 105));
            if (appSettings_.Shadps4Check) cols.Add(($"ShadPS4 ({Shadps4Compat.OsDisplay(appSettings_.Shadps4Os)})", 130));
            return cols;
        }

        private static string[] BuildGlvRowData(GlvItem item)
        {
            string Cell(string name) => item.Row[name]?.ToString() ?? "";
            var data = new List<string> { Cell("Filename"), Cell("Title") };
            if (appSettings_.pkgtitleIdColumn) data.Add(Cell("Title ID"));
            if (appSettings_.pkgcontentIdColumn) data.Add(Cell("Content ID"));
            if (appSettings_.pkgregionColumn) data.Add(item.Row[PkgColumns.RegionName]?.ToString() ?? "");
            if (appSettings_.pkgminimumFirmwareColumn) data.Add(Cell(PkgColumns.SystemVersion));
            if (appSettings_.pkgversionColumn) data.Add(Cell("Version [App Version]"));
            if (appSettings_.pkgTypeColumn) data.Add(Cell("PKG Type"));
            if (appSettings_.pkgcategoryColumn) data.Add(Cell("Category"));
            if (appSettings_.pkgsizeColumn) data.Add(Cell("Size"));
            if (appSettings_.psvr_neo_ps5bc_check) { data.Add(Cell("PSVR")); data.Add(Cell("PS4 Pro Enhanced")); data.Add(Cell("PS5 BC")); }
            if (appSettings_.pkgDirectoryColumn) data.Add(Cell("Directory"));
            if (appSettings_.pkgBackportColumn) data.Add(Cell("Backported"));
            if (appSettings_.AutoFetchUpdate) data.Add(Cell("Latest Update"));
            if (appSettings_.Shadps4Check) data.Add(Cell("ShadPS4"));
            return data.ToArray();
        }

        private static string GetRegionString(DataRow row)
        {
            var icon = row["Region"] as byte[];
            if (icon == null || icon.Length == 0) return "";
            // Use cached lookup - region icons are static resources
            if (_regionLookup == null)
            {
                var cvt = new System.Drawing.ImageConverter();
                _regionLookup = new Dictionary<byte[], string>(ByteArrayComparer.Instance)
                {
                    [(byte[])cvt.ConvertTo(Properties.Resources.eu, typeof(byte[]))] = "EU",
                    [(byte[])cvt.ConvertTo(Properties.Resources.us, typeof(byte[]))] = "US",
                    [(byte[])cvt.ConvertTo(Properties.Resources.jp, typeof(byte[]))] = "JAPAN",
                    [(byte[])cvt.ConvertTo(Properties.Resources.hk, typeof(byte[]))] = "HONG_KONG",
                    [(byte[])cvt.ConvertTo(Properties.Resources.asia, typeof(byte[]))] = "ASIA",
                    [(byte[])cvt.ConvertTo(Properties.Resources.kr, typeof(byte[]))] = "KOREA",
                };
            }
            return _regionLookup.TryGetValue(icon, out var name) ? name : "";
        }

        private static DarkGroupedListViewCellPresentation BuildGlvCellPresentation(GlvItem item, string columnName)
        {
            string category = item.Row[PkgColumns.Category]?.ToString() ?? "";
            Color? foreColor = null;
            Color? backColor = null;

            if (appSettings_.PkgColorLabel)
            {
                switch (category)
                {
                    case PKGCategory.PATCH:
                        foreColor = appSettings_.PatchPkgForeColor;
                        backColor = appSettings_.PatchPkgBackColor;
                        break;
                    case PKGCategory.GAME:
                        foreColor = appSettings_.GamePkgForeColor;
                        backColor = appSettings_.GamePkgBackColor;
                        break;
                    case PKGCategory.ADDON:
                        foreColor = appSettings_.AddonPkgForeColor;
                        backColor = appSettings_.AddonPkgBackColor;
                        break;
                    case PKGCategory.APP:
                        foreColor = appSettings_.AppPkgForeColor;
                        backColor = appSettings_.AppPkgBackColor;
                        break;
                }
            }

            if (columnName == PkgColumns.Region)
            {
                Image regionIcon = GetGlvRegionIcon(item.Row[PkgColumns.RegionName]?.ToString());
                if (regionIcon != null)
                {
                    return new DarkGroupedListViewCellPresentation
                    {
                        Image = regionIcon,
                        ForeColor = foreColor,
                        BackColor = backColor
                    };
                }
            }

            if (columnName.StartsWith(PkgColumns.Shadps4, StringComparison.Ordinal))
            {
                string status = item.Row[PkgColumns.Shadps4]?.ToString() ?? "";
                bool installed = item.Row.Table.Columns.Contains(PkgColumns.Shadps4Installed)
                    && item.Row[PkgColumns.Shadps4Installed] is true;
                if (!string.IsNullOrWhiteSpace(status) || installed)
                {
                    Color statusColor = string.IsNullOrWhiteSpace(status)
                        ? Color.FromArgb(113, 190, 84)
                        : Shadps4Compat.StatusColor(status);
                    return new DarkGroupedListViewCellPresentation
                    {
                        Text = string.IsNullOrWhiteSpace(status)
                            ? "[Installed]"
                            : "● " + status + (installed ? " [Installed]" : ""),
                        ForeColor = statusColor,
                        SelectionForeColor = statusColor,
                        BackColor = backColor
                    };
                }
            }

            return foreColor.HasValue || backColor.HasValue
                ? new DarkGroupedListViewCellPresentation { ForeColor = foreColor, BackColor = backColor }
                : null;
        }

        private static Image GetGlvRegionIcon(string region) => region switch
        {
            PKGRegion.EU => Properties.Resources.eu,
            PKGRegion.US => Properties.Resources.us,
            PKGRegion.UK => Properties.Resources.us,
            PKGRegion.JAPAN => Properties.Resources.jp,
            PKGRegion.HONG_KONG => Properties.Resources.hk,
            PKGRegion.ASIA => Properties.Resources.asia,
            PKGRegion.KOREA => Properties.Resources.kr,
            _ => null
        };

        private static Dictionary<byte[], string> _regionLookup;

        private class ByteArrayComparer : IEqualityComparer<byte[]>
        {
            public static readonly ByteArrayComparer Instance = new();
            public bool Equals(byte[] a, byte[] b) => a != null && b != null && a.SequenceEqual(b);
            public int GetHashCode(byte[] a) { if (a == null) return 0; int h = 0; for (int i = 0; i < Math.Min(a.Length, 16); i++) h = (h * 31) ^ a[i]; return h; }
        }

        private void GroupedListView_SelectedItemChanged(object sender, EventArgs e)
        {
            string filePath = groupedListView?.SelectedFilePath;
            if (string.IsNullOrEmpty(filePath))
            {
                Logger.LogInformation("GLV selection: SelectedFilePath is null/empty");
                return;
            }
            if (!File.Exists(filePath))
            {
                Logger.LogInformation($"GLV selection: file not found: {filePath}");
                return;
            }

            // Select the same PKG in the DataGridView to trigger detail loading
            var dt = PKGGridView.DataSource as DataTable;
            if (dt == null)
            {
                Logger.LogInformation("GLV selection: DataSource is null");
                return;
            }

            // Find the row index matching this file path
            for (int i = 0; i < PKGGridView.Rows.Count; i++)
            {
                var row = PKGGridView.Rows[i];
                if (row.Cells[0].Value == null || row.Cells[13].Value == null) continue;
                string dir = row.Cells[13].Value.ToString();
                string fn = row.Cells[0].Value.ToString();
                string rowPath = System.IO.Path.Combine(dir, fn);

                if (string.Equals(rowPath, filePath, StringComparison.OrdinalIgnoreCase))
                {
                    PKGGridView.ClearSelection();
                    PKGGridView.Rows[i].Selected = true;
                    PKGGridView.CurrentCell = PKGGridView.Rows[i].Cells[0];
                    return;
                }
            }
            Logger.LogInformation($"GLV selection: no grid row matches '{filePath}'");
        }

        // ── GLV context menu helpers ─────────────────────────

        private List<string> GetGLVTargetPaths()
        {
            // Group header right-click → all files in that group
            if (_glvGroupHeaderIndex >= 0)
            {
                int idx = _glvGroupHeaderIndex;
                _glvGroupHeaderIndex = -1;
                var paths = groupedListView.GetGroupFilePaths(idx);
                return paths;
            }

            // Multi-select → selected rows
            var selected = groupedListView.GetSelectedFilePaths();
            if (selected.Count > 0)
                return selected;

            // Single right-click on an item row → SelectedFilePath is already set
            // by CellMouseClick (but row wasn't "selected" in the DataGridView sense)
            var single = groupedListView.SelectedFilePath;
            if (!string.IsNullOrEmpty(single))
                return new List<string> { single };

            return new List<string>();
        }

        private void GlvCopyContentId()
        {
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            var ids = paths.Select(p => { var r = PkgMetadataReader.ReadMetadataOnly(p); return r.SfoContentId; });
            Clipboard.SetText(string.Join("\n", ids));
            ShowInformation($"{paths.Count} Content ID(s) copied.", true);
        }

        private void GlvViewInExplorer()
        {
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            foreach (var p in paths) Process.Start("explorer.exe", "/select," + p);
        }

        private void GlvViewChangeInfo()
        {
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            PKG.SelectedPKGFilename = paths[0];
            ViewUpdateChangelog();
            string changeInfoFile = AppDataDirectory + "changeinfo.xml";
            if (File.Exists(changeInfoFile))
            {
                try
                {
                    string data = File.ReadAllText(changeInfoFile);
                    File.Delete(changeInfoFile);
                    using (var viewer = new PKGChangeInfoViewer(data)) { viewer.ShowDialog(); }
                }
                catch (Exception ex) { ShowError("Error viewing change info: " + ex.Message, true); }
            }
        }

        private void GlvDeletePkg()
        {
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            var confirm = DialogResultYesNo(
                $"{paths.Count} PKG file{(paths.Count == 1 ? "" : "s")} will be permanently deleted.\n\nContinue?");
            if (confirm != DialogResult.Yes) return;
            Logger.LogInformation($"Delete: {paths.Count} PKG(s)");
            PKG.isDeletingPkg = true;
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripStatusLabel2.Text = "Deleting...";
            foreach (var p in paths)
            {
                try { File.Delete(p); }
                catch (Exception ex) { Logger.LogError($"Failed to delete {p}: {ex.Message}"); }
            }
            Logger.LogInformation($"Delete completed: {paths.Count} PKG(s)");
            PKG.isDeletingPkg = false;
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            RefreshPkgList();
        }

        private void GlvRenameByPriority()
        {
            if (Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A shadPS4 installation is in progress.", false);
                return;
            }
            // Always target the whole group - right-click an item or a header,
            // the entire group gets renamed by install priority.
            if (_glvGroupHeaderIndex < 0 && !string.IsNullOrEmpty(groupedListView?.SelectedFilePath))
                _glvGroupHeaderIndex = groupedListView.FindGroupForPath(groupedListView.SelectedFilePath);
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            var confirm = DialogResultYesNo(
                $"Rename {paths.Count} PKG file{(paths.Count == 1 ? "" : "s")} by install priority?\n\n" +
                "Files will be grouped by Title ID and renamed with sequence prefixes:\n" +
                "  00 - Base -> 01 - Update\n\nAdd-on and App PKGs are skipped.\n\nContinue?");
            if (confirm != DialogResult.Yes) return;
            var bg = new BackgroundWorker { WorkerReportsProgress = true };
            bg.DoWork += (_, _) => RenamePKGByPriority(paths, bg);
            bg.ProgressChanged += (_, e) =>
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Maximum = 100;
                toolStripProgressBar1.Value = e.ProgressPercentage;
                toolStripStatusLabel2.Text = e.UserState?.ToString() ?? "...";
            };
            bg.RunWorkerCompleted += (_, _) =>
            {
                try
                {
                    if (PKG.CountFailRename > 0)
                        ShowWarning(PKG.CountFailRename + " PKG failed to rename by priority. See program log to view the errors.", false);
                    else
                        ShowInformation("PKG rename by priority done.", true);
                    SaveManifestAfterScan();
                    // GLV cells updated in-place by UpdatePKGFilename during rename.
                }
                catch (Exception ex)
                {
                    Logger.LogError("GLV priority rename completion failed: " + ex.Message);
                }
                finally
                {
                    toolStripStatusLabel2.Text = "...";
                    toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                    toolStripProgressBar1.Value = 0;
                    this.Enabled = true;
                    SetOperationMenusEnabled(true);
                }
            };
            this.Enabled = false;
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel2.Text = "Renaming by install priority...";
            bg.RunWorkerAsync();
        }

        private void GlvExtractImages()
        {
            var paths = GetGLVTargetPaths();
            if (paths.Count == 0) { ShowError("No PKG selected.", false); return; }
            using var fbd = new FolderBrowserDialog { Description = "Select output folder for artwork" };
            if (fbd.ShowDialog() != DialogResult.OK) return;
            Logger.LogInformation($"Save artwork: {paths.Count} PKG(s) to {fbd.SelectedPath}");
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            var bg = new BackgroundWorker();
            bg.DoWork += (_, _) =>
            {
                ImageIconExtractor(ImageIconExtractionType.ICON, paths, fbd.SelectedPath, false);
            };
            bg.RunWorkerCompleted += (_, _) =>
            {
                Logger.LogInformation("Artwork saved successfully.");
                ShowInformation($"Artwork saved to {fbd.SelectedPath}", true);
                toolStripStatusLabel2.Text = "...";
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Value = 0;
            };
            toolStripStatusLabel2.Text = "Saving artwork...";
            bg.RunWorkerAsync();
        }

        private void FetchAllUpdateVersions()
        {
            if (PKGGridView.DataSource is not DataTable sourceTable) return;
            var titleIds = sourceTable.Rows.Cast<DataRow>()
                .Where(row => string.Equals(row[PkgColumns.Category]?.ToString(), PKGCategory.GAME, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(row[PkgColumns.Category]?.ToString(), PKGCategory.PATCH, StringComparison.OrdinalIgnoreCase))
                .Select(row => row[PkgColumns.TitleId]?.ToString() ?? "")
                .Where(titleId => !string.IsNullOrWhiteSpace(titleId))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var bg = new BackgroundWorker();
            bg.DoWork += (s, e) =>
            {
                var latestByTitleId = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (string titleId in titleIds)
                {
                    try
                    {
                        string latestValue;
                        var updateInfo = OrbisPkgTool.Psn.UpdateCheck.CheckForUpdate(titleId);
                        if (updateInfo != null && updateInfo.Tag?.Package?.ManifestUrl != null)
                            latestValue = updateInfo.Tag.Package.Version ?? "No Update";
                        else
                            latestValue = "No Update";

                        latestByTitleId[titleId] = latestValue;
                    }
                    catch (Exception ex) { Logger.LogWarning("Update check failed for Title ID " + titleId + ": " + ex.Message); }
                }
                if (latestByTitleId.Count == 0) return;
                this.Invoke((Action)(() =>
                {
                    if (PKGGridView.DataSource is DataTable currentTable)
                    {
                        foreach (DataRow row in currentTable.Rows)
                        {
                            string titleId = row[PkgColumns.TitleId]?.ToString() ?? "";
                            if (latestByTitleId.TryGetValue(titleId, out string latestValue))
                                row[PkgColumns.LatestUpdate] = latestValue;
                        }
                    }
                    PopulateGroupedView();
                }));
            };
            bg.RunWorkerAsync();
        }

        /// <summary>
        /// Fills the "ShadPS4" column from the local compatibility cache
        /// (by Title ID + the selected OS, column-name based - index-safe).
        /// No-op when the check is disabled or the cache is missing.
        /// </summary>
        private static void ApplyShadps4Status(DataTable dt)
        {
            try
            {
                if (dt == null || !dt.Columns.Contains(PkgColumns.TitleId)) return;
                ApplyShadps4InstalledStatus(dt);
                if (!appSettings_.Shadps4Check || !dt.Columns.Contains(PkgColumns.Shadps4)) return;
                foreach (DataRow row in dt.Rows)
                {
                    string tid = row[PkgColumns.TitleId]?.ToString() ?? "";
                    if (string.IsNullOrEmpty(tid)) continue;
                    string status = Shadps4Compat.Lookup(tid, appSettings_.Shadps4Os);
                    if (!string.IsNullOrEmpty(status))
                        row[PkgColumns.Shadps4] = status;
                }
            }
            catch (Exception ex) { Logger.LogWarning("Failed to apply shadPS4 status: " + ex.Message); }
        }

        /// <summary>Marks Title IDs with a validated game folder in the configured local shadPS4 library.</summary>
        private static void ApplyShadps4InstalledStatus(DataTable dt)
        {
            if (!dt.Columns.Contains(PkgColumns.Shadps4Installed)) return;

            var installedTitleIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string library = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(library) && Directory.Exists(library))
            {
                try
                {
                    foreach (string directory in Directory.EnumerateDirectories(library))
                    {
                        if (Path.GetFileName(directory).StartsWith(".ps4pkgtool-", StringComparison.OrdinalIgnoreCase) ||
                            !File.Exists(Path.Combine(directory, "eboot.bin")))
                            continue;

                        string sfoPath = Path.Combine(directory, "sce_sys", "param.sfo");
                        if (!File.Exists(sfoPath)) continue;

                        // The shadPS4 library folder is normally named after the Title ID,
                        // but it is not a contractual identifier. Read the installed game's
                        // actual Title ID from param.sfo, just as the manager does.
                        var sfo = OrbisPkgTool.Sfo.ParamSfo.Parse(File.ReadAllBytes(sfoPath));
                        string titleId = sfo.GetString("TITLE_ID")?.Trim() ?? "";
                        if (!string.IsNullOrWhiteSpace(titleId)) installedTitleIds.Add(titleId);
                    }
                }
                catch (Exception ex) { Logger.LogWarning("Failed to read shadPS4 install library: " + ex.Message); }
            }

            foreach (DataRow row in dt.Rows)
            {
                string titleId = row[PkgColumns.TitleId]?.ToString()?.Trim() ?? "";
                row[PkgColumns.Shadps4Installed] = installedTitleIds.Contains(titleId);
            }
        }

        /// <summary>
        /// Fills PSVR, PS4 Pro Enhanced, and PS5 BC from the downloaded local
        /// compatibility data without requiring a complete PKG re-read.
        /// </summary>
        private static void ApplyPs5BcStatus(DataTable dt)
        {
            try
            {
                if (dt == null || !File.Exists(Ps5BcJsonFile) ||
                    !dt.Columns.Contains(PkgColumns.TitleId) ||
                    !dt.Columns.Contains(PkgColumns.Category) ||
                    !dt.Columns.Contains(PkgColumns.Psvr) ||
                    !dt.Columns.Contains(PkgColumns.Ps4ProEnhanced) ||
                    !dt.Columns.Contains(PkgColumns.Ps5Bc))
                    return;

                var entries = JsonConvert.DeserializeObject<List<Ps5BcStatusEntry>>(
                    File.ReadAllText(Ps5BcJsonFile)) ?? new List<Ps5BcStatusEntry>();
                var statuses = entries
                    .Where(entry => !string.IsNullOrWhiteSpace(entry.NpTitleIdShort))
                    .GroupBy(entry => entry.NpTitleIdShort, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

                foreach (DataRow row in dt.Rows)
                {
                    if (!string.Equals(row[PkgColumns.Category]?.ToString(), PKGCategory.GAME, StringComparison.OrdinalIgnoreCase))
                    {
                        row[PkgColumns.Psvr] = "-";
                        row[PkgColumns.Ps4ProEnhanced] = "-";
                        row[PkgColumns.Ps5Bc] = "-";
                        continue;
                    }

                    string titleId = row[PkgColumns.TitleId]?.ToString() ?? "";
                    if (!statuses.TryGetValue(titleId, out Ps5BcStatusEntry entry))
                        continue;

                    row[PkgColumns.Psvr] = entry.PsVr is "1" or "2" ? "Yes" : entry.PsVr == "0" ? "No" : entry.PsVr != "null" ? "NA" : "";
                    row[PkgColumns.Ps4ProEnhanced] = entry.NeoEnable == "1" ? "Yes" : entry.NeoEnable == "0" ? "No" : entry.NeoEnable != "null" ? "NA" : "";
                    row[PkgColumns.Ps5Bc] = string.IsNullOrWhiteSpace(entry.Ps5Bc)
                        ? ""
                        : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entry.Ps5Bc.Replace("_", " ").ToLower());
                }
            }
            catch (Exception ex) { Logger.LogWarning("Failed to apply PS5 BC status: " + ex.Message); }
        }

        private sealed class Ps5BcStatusEntry
        {
            [JsonProperty("npTitleIdshort")]
            public string NpTitleIdShort { get; set; } = "";

            [JsonProperty("psVr")]
            public string PsVr { get; set; } = "";

            [JsonProperty("neoEnable")]
            public string NeoEnable { get; set; } = "";

            [JsonProperty("ps5bc")]
            public string Ps5Bc { get; set; } = "";
        }

        private void PostPkgLoad()
        {
            if (PKG.VerifiedPs4PkgList.Count == 0)
            {
                PKGGridView.DataSource = null;
                darkDataGridView2.DataSource = null;
                SetOperationMenusEnabled(false);

                if (Helper.LoadFromManifest)
                {
                    var result = DialogResultYesNo(
                        "Manifest loaded but no PKG files are currently accessible.\n\n" +
                        "The PKG files may be on a network drive or external storage\n" +
                        "that is not currently connected.\n\n" +
                        "Would you like to scan directories instead?");
                    if (result == DialogResult.Yes)
                    {
                        Helper.LoadFromManifest = false;
                        Helper.LaunchEmpty = false;
                        RefreshPkgList();
                        return;
                    }
                }
                else
                {
                    var missingDirs = GetMissingDirectories();
                    if (missingDirs.Count > 0)
                    {
                        var result = DialogResultYesNo(
                            "No PKG files found. Some configured directories do not exist:\n" +
                            string.Join("\n", missingDirs) +
                            "\n\nWould you like to open Program Settings to reconfigure?");
                        if (result == DialogResult.Yes)
                            OpenPKGDirectorySettings();
                    }
                    else
                    {
                        ShowInformation("No PKG files found in the configured directories.", true);
                    }
                }
            }
            else
            {
                SetOperationMenusEnabled(true);
                FinalizePkgLoadingProcess();
                UpdateDataGridViewColumnVisibility();
                SetBackgroundMusicVolume();
                SetDataGridViewCellStyle();
                PopulateGroupedView();
                SaveManifestAfterScan();
                if (appSettings_.AutoFetchUpdate) FetchAllUpdateVersions();
            }
            //PKGListGridView.SelectionChanged += PKGListGridView_SelectionChanged;
            toolStripStatusLabel2.Text = "... ";
            toolStripProgressBar1.Value = 0;
            PKGGridView.Enabled = true;
            darkDataGridView2.Enabled = true;
            this.Enabled = true;
        }

        /// <summary>
        /// Disables or enables operation menus/buttons based on whether PKGs are loaded.
        /// </summary>
        private void SetOperationMenusEnabled(bool enabled)
        {
            void ApplyState()
            {
                _packageOperationsEnabled = enabled;
                // File->Manage
                if (managePS4PKGToolStripMenuItem != null) managePS4PKGToolStripMenuItem.Enabled = enabled;
                // Status bar
                // TabPage7 buttons
                // All context menus
                if (contextMenuPKGGridView != null) contextMenuPKGGridView.Enabled = enabled;
                if (contextMenuGLV != null) contextMenuGLV.Enabled = enabled;
                if (contextMenuTrophy != null) contextMenuTrophy.Enabled = enabled;
                if (contextMenuEntry != null) contextMenuEntry.Enabled = enabled;
                if (contextMenuOfficialUpdate != null) contextMenuOfficialUpdate.Enabled = enabled;
                if (contextMenuBackgroundImage != null) contextMenuBackgroundImage.Enabled = enabled;
                if (contextMenuExtractNode != null) contextMenuExtractNode.Enabled = enabled;
                if (contextMenuExtractListView != null) contextMenuExtractListView.Enabled = enabled;
                // GLV controls
                if (cbGroupBy != null) cbGroupBy.Enabled = enabled;
                // TreeView filter controls
                if (tbFilterTreeView != null) tbFilterTreeView.Enabled = enabled;
                // Table tab filter controls
                if (tbSearchGame != null) tbSearchGame.Enabled = enabled;
                UpdatePackageActionButtonStates();
            }

            if (IsHandleCreated && InvokeRequired)
                Invoke((MethodInvoker)ApplyState);
            else
                ApplyState();
        }

        /// <summary>
        /// Applies the specific requirement for every DarkButton on the main
        /// form. This keeps empty, selected, filtered, and preview states in sync.
        /// </summary>
        private void UpdatePackageActionButtonStates()
        {
            DataTable table = PKGGridView?.DataSource as DataTable;
            bool hasPackages = _packageOperationsEnabled && table != null && table.Rows.Count > 0;
            bool hasSelectedPackage = hasPackages && PKGGridView.SelectedRows.Count > 0 &&
                !string.IsNullOrWhiteSpace(PKG.SelectedPKGFilename);
            bool hasVisiblePackages = hasPackages && table.DefaultView.Count > 0;

            if (btnExtractFullPKG != null)
                btnExtractFullPKG.Enabled = hasSelectedPackage;
            if (extractSelectedFullPkgToolStripMenuItem != null)
                extractSelectedFullPkgToolStripMenuItem.Enabled = hasSelectedPackage;
            if (btnViewPKGData != null)
                btnViewPKGData.Enabled = hasSelectedPackage;
            if (btnExportTreeView != null)
                btnExportTreeView.Enabled = hasSelectedPackage && PKGTreeView.Nodes.Count > 0;
            if (btnExportTextures != null)
            {
                bool hasActiveContainer = _containerSource != null && _containerDetection != null;
                bool browsingContainer = hasActiveContainer &&
                    assetListView != null && assetListView.Visible;
                bool exportingPreviewedUnityFile = !hasActiveContainer && _previewIsUnityFile &&
                    !string.IsNullOrWhiteSpace(_previewEntryPath);
                btnExportTextures.Visible = browsingContainer || exportingPreviewedUnityFile;
                btnExportTextures.Enabled = hasSelectedPackage &&
                    (browsingContainer ? CanExportContainerTextures() : exportingPreviewedUnityFile);
            }
            if (btnFilterClear != null)
                btnFilterClear.Enabled = hasPackages && !_filterState.IsEmpty;
            if (btnGroupExpand != null)
            {
                btnGroupExpand.Enabled = hasVisiblePackages;
                if (!hasVisiblePackages)
                    btnGroupExpand.Text = "Expand All";
            }
            if (btnAssetBack != null)
                btnAssetBack.Enabled = hasSelectedPackage && btnAssetBack.Visible &&
                    _containerSource != null && _containerDetection != null;
        }

        /// <summary>
        /// Returns configured PKG directories that do not exist on disk.
        /// </summary>
        private List<string> GetMissingDirectories()
        {
            var missing = new List<string>();
            if (appSettings_?.PkgDirectories != null)
            {
                foreach (string dir in appSettings_.PkgDirectories)
                {
                    if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                        missing.Add(dir);
                }
            }
            return missing;
        }

        private void InitializeEmptyGrid()
        {
            PKGGridView.DataSource = null;
            PKGGridView.Rows.Clear();
            darkDataGridView2.DataSource = null;
            darkDataGridView2.Rows.Clear();
            SetOperationMenusEnabled(false);
        }

        private void SaveManifestAfterScan()
        {
            var dt = PKGGridView.DataSource as DataTable;
            if (dt != null)
            {
                ManifestHelper.SaveManifest(dt, PKG.VerifiedPs4PkgList);
            }
        }

        private void SetDataGridViewCellStyle()
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    PKGGridView.Sort(PKGGridView.Columns[0], ListSortDirection.Ascending);

                    // Set header cell alignment
                    for (int columnIndex = 0; columnIndex < PKGGridView.Columns.Count; columnIndex++)
                    {
                        PKGGridView.Columns[columnIndex].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Set cell alignment
                    for (int columnIndex = 1; columnIndex <= 14; columnIndex++)
                    {
                        PKGGridView.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                catch
                {
                }
            });
        }

        private static void SetBackgroundMusicVolume()
        {
            if (!appSettings_.PlayBgm)
            {
                int newVolume = 0; // Set 0 to unmute
                uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
                waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);
            }
            else
            {
                int newVolume = 65535; // Set 65535 to unmute
                uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));
                waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);
            }
        }

        /// <summary>The two hidden filter columns (Region Name, Required Firmware (Num)) are never shown in the grid.</summary>
        private void HideFilterColumns()
        {
            try
            {
                if (PKGGridView.Columns.Contains(PkgColumns.RegionName))
                    PKGGridView.Columns[PkgColumns.RegionName].Visible = false;
                if (PKGGridView.Columns.Contains(PkgColumns.SystemVersionNum))
                    PKGGridView.Columns[PkgColumns.SystemVersionNum].Visible = false;
                if (PKGGridView.Columns.Contains(PkgColumns.Shadps4Installed))
                    PKGGridView.Columns[PkgColumns.Shadps4Installed].Visible = false;
            }
            catch { }
        }

        private void UpdateDataGridViewColumnVisibility()
        {
            try
            {
                // Launch Empty has no bound PKG table yet, so its columns do
                // not exist until the first scan finishes.
                if (PKGGridView.Columns.Count < 16)
                    return;

                PKGGridView.Columns[1].Visible = true; // Title always visible
                PKGGridView.Columns[2].Visible = appSettings_.pkgtitleIdColumn;
                PKGGridView.Columns[3].Visible = appSettings_.pkgcontentIdColumn;
                PKGGridView.Columns[4].Visible = appSettings_.pkgregionColumn;
                PKGGridView.Columns[5].Visible = appSettings_.pkgminimumFirmwareColumn;
                PKGGridView.Columns[6].Visible = appSettings_.pkgversionColumn;
                PKGGridView.Columns[7].Visible = appSettings_.pkgTypeColumn;
                PKGGridView.Columns[8].Visible = appSettings_.pkgcategoryColumn;
                PKGGridView.Columns[9].Visible = appSettings_.pkgsizeColumn;
                PKGGridView.Columns[10].Visible = appSettings_.psvr_neo_ps5bc_check;
                PKGGridView.Columns[11].Visible = appSettings_.psvr_neo_ps5bc_check;
                PKGGridView.Columns[12].Visible = appSettings_.psvr_neo_ps5bc_check;
                PKGGridView.Columns[13].Visible = appSettings_.pkgDirectoryColumn;
                PKGGridView.Columns[14].Visible = appSettings_.pkgBackportColumn;
                PKGGridView.Columns[15].Visible = appSettings_.AutoFetchUpdate;
                if (PKGGridView.Columns.Count > 16)
                    PKGGridView.Columns[16].Visible = appSettings_.Shadps4Check;
                HideFilterColumns();
                // The header reflects the OS the statuses are shown for
                // (internal column name stays "ShadPS4" for all OSes).
                if (appSettings_.Shadps4Check && PKGGridView.Columns.Contains(PkgColumns.Shadps4))
                    PKGGridView.Columns[PkgColumns.Shadps4].HeaderText = $"ShadPS4 ({Shadps4Compat.OsDisplay(appSettings_.Shadps4Os)})";
                // The compat filter needs the column's data to exist - when the
                // shadPS4 check is off, clear any active compat condition.
                if (!appSettings_.Shadps4Check && _filterState.CompatStatuses.Count > 0)
                {
                    _filterState.CompatStatuses.Clear();
                    ApplyFilters();
                }
            }
            catch (Exception ex) { Logger.LogWarning("Error updating column visibility: " + ex.Message); }
        }

      
        private void FinalizePkgLoadingProcess()
        {
            if (FinalizePkgProcess)
            {
                FinalizePkgProcess = false;
                BackgroundWorker bgw = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                bgw.DoWork += (s, a) =>
                {
                    Logger.LogInformation("Extracting PKG background music..");
                    BGM.ExtractBgm();
                };
                bgw.RunWorkerCompleted += (s, a) =>
                {
                    BGM.extractAt9Done = true;
                };
                bgw.RunWorkerAsync();
                GetDrivesFreeSpace();
                labelDisplayTotalPKG.Text = $"Displaying {PKGGridView.Rows.Count} PS4 PKG";
                Logger.LogInformation($"Loading PKG done. {PKGGridView.Rows.Count} PKG found.");
            }
        }

        private void GetDrivesFreeSpace()
        {
            Logger.LogInformation("Checking hard disk free space..");
            try
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    long freeSpace = drive.TotalFreeSpace;
                    long totalSpace = drive.TotalSize;
                    double freeSpaceGB = ByteSize.FromBytes(freeSpace).GigaBytes;
                    double totalSpaceGB = ByteSize.FromBytes(totalSpace).GigaBytes;

                    string formattedFreeSpace = $"{freeSpaceGB:F2} GB";
                    string formattedTotalSpace = $"{totalSpaceGB:F2} GB";

                    Logger.LogInformation($"[{drive}] Free Space: {formattedFreeSpace}/{formattedTotalSpace}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("An error occurred while getting hard disk free space: " + ex.Message);
            }
        }
        #endregion PKGScanning

        #region PKGGridViewFiltering

        private void GridViewFilterPKG_Click(object sender, EventArgs e)
        {
            // Records the type selection; the effective filter is built by
            // ApplyFilters() so type/compat/search COMPOSE instead of
            // overwriting each other.
            string text = sender.ToString();
            _filterState.Categories.Clear();
            if (text.Contains(PKGCategory.GAME))
                _filterState.Categories.Add(PKGCategory.GAME);
            else if (text.Contains(PKGCategory.PATCH))
                _filterState.Categories.Add(PKGCategory.PATCH);
            else if (text.Contains(PKGCategory.ADDON))
                _filterState.Categories.Add(PKGCategory.ADDON);
            else if (text.Contains(PKGCategory.APP))
                _filterState.Categories.Add(PKGCategory.APP);
            else if (text.Contains(PKGCategory.UNKNOWN))
                _filterState.Categories.Add("Unknown");
            ApplyFilters();
        }

        /// <summary>
        /// The ONE place the grid's RowFilter is assembled: PKG type filter
        /// AND compatibility filter AND search filter. Column visibility does
        /// not matter here - the DataTable columns exist regardless of the
        /// DataGridView presentation state.
        /// </summary>
        private void ApplyFilters()
        {
            try
            {
                var dt = PKGGridView.DataSource as DataTable;
                if (dt == null) return;
                _filterState.SearchText = tbSearchGame?.SearchText ?? "";
                dt.DefaultView.RowFilter = PkgFilter.BuildExpression(_filterState);
                ScheduleGroupedViewRefresh();
                RefreshFilterBar();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error applying filter: {ex.Message}");
                ShowError($"Error applying filter: {ex.Message}", true);
            }
        }

        // ── filter bar ──

        /// <summary>
        /// Populates the four aspect combos (Category / Region / Type /
        /// ShadPS4) and wires each to its filter-state list, exactly like the
        /// DarkUI TestApp usage: CheckedItemsChanged re-applies the filter
        /// live; the closed box shows the checked values comma-separated.
        /// </summary>
        private void SetupFilterChecklists()
        {
            WireCheckedCombo(ccbCategory, _filterState.Categories);
            WireCheckedCombo(ccbRegion, _filterState.Regions);
            WireCheckedCombo(ccbType, _filterState.PkgTypes);
            WireCheckedCombo(ccbShadps4, _filterState.CompatStatuses);
        }

        private void chkShadps4Installed_CheckedChanged(object sender, EventArgs e)
        {
            _filterState.Shadps4InstalledOnly = chkShadps4Installed.Checked;
            ApplyFilters();
        }

        /// <summary>Live filter wiring for one aspect combo.</summary>
        private void WireCheckedCombo(DarkUI.Controls.DarkCheckedComboBox combo, List<string> state)
        {
            combo.CheckedItemsChanged += (_, _) =>
            {
                // While SyncCombo drives the combos, the state list is already
                // the source of truth. Refilling it from the combo's remaining
                // checked items mid-sync would make every later index look
                // "in sync" and only ONE item could ever be unchecked per pass
                // (the Clear button cleared one tag per click).
                if (_syncingFilterCombos) return;
                state.Clear();
                state.AddRange(combo.CheckedItems.Cast<string>());
                ApplyFilters();
            };
        }

        /// <summary>
        /// Reflects the filter state back into a combo (Clear button, chip
        /// removal). The guard suppresses the live refill so a state-side
        /// clear unchecks all items in this single pass.
        /// </summary>
        private void SyncCombo(DarkUI.Controls.DarkCheckedComboBox combo, List<string> state)
        {
            _syncingFilterCombos = true;
            try
            {
                for (int i = 0; i < combo.Items.Count; i++)
                {
                    bool on = state.Contains((string)combo.Items[i]);
                    if (combo.GetItemChecked(i) != on) combo.SetItemChecked(i, on);
                }
            }
            finally
            {
                _syncingFilterCombos = false;
            }
        }

        private void tbFilterSysVer_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbFilterSysVer.Text.Trim(),
                System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double v))
            {
                _filterState.MinSystemVersion = v;
            }
            else
            {
                _filterState.MinSystemVersion = null;
            }
            ApplyFilters();
        }

        /// <summary>Rebuilds the active-filter chips and the match counter after a filter change.</summary>
        private bool _syncingFilterCombos;

        private void RefreshFilterBar()
        {
            try
            {
                // Mirror the state back into the combos (Clear / chip removal)
                SyncCombo(ccbCategory, _filterState.Categories);
                SyncCombo(ccbRegion, _filterState.Regions);
                SyncCombo(ccbType, _filterState.PkgTypes);
                SyncCombo(ccbShadps4, _filterState.CompatStatuses);
                if (chkShadps4Installed.Checked != _filterState.Shadps4InstalledOnly)
                    chkShadps4Installed.Checked = _filterState.Shadps4InstalledOnly;

                // DarkChipsPanel (DarkUI): chips reconcile diff-style (DarkUI
                // TestApp pattern); only chips that actually changed are
                // added/removed, never clear + rebuild the whole row (which
                // flashed on every change). Desired set: (text, remove action)
                // in display order; × on a chip removes that condition.
                var desired = new List<(string Text, Action Remove)>();
                foreach (string c in _filterState.Categories)
                    desired.Add((c, () => { _filterState.Categories.Remove(c); ApplyFilters(); }));
                foreach (string r in _filterState.Regions)
                    desired.Add((r, () => { _filterState.Regions.Remove(r); ApplyFilters(); }));
                if (_filterState.MinSystemVersion is double min)
                    desired.Add(($"≥ {min:0.##}", () => { _filterState.MinSystemVersion = null; tbFilterSysVer.Text = ""; ApplyFilters(); }));
                foreach (string t in _filterState.PkgTypes)
                    desired.Add((t, () => { _filterState.PkgTypes.Remove(t); ApplyFilters(); }));
                foreach (string s in _filterState.CompatStatuses)
                    desired.Add((s, () => { _filterState.CompatStatuses.Remove(s); ApplyFilters(); }));
                if (_filterState.Shadps4InstalledOnly)
                    desired.Add(("ShadPS4 Installed", () => { _filterState.Shadps4InstalledOnly = false; ApplyFilters(); }));
                if (!string.IsNullOrWhiteSpace(_filterState.SearchText))
                    desired.Add(($"\"{_filterState.SearchText.Trim()}\"", () => { tbSearchGame.Text = ""; tbSearchGame.SearchText = ""; ApplyFilters(); }));

                // Remove chips whose filter is no longer active.
                foreach (DarkChip chip in flowChips.Controls.OfType<DarkChip>().ToList())
                {
                    if (desired.All(d => d.Text != chip.Text))
                    {
                        flowChips.Controls.Remove(chip);
                        chip.Dispose();
                    }
                }

                // Add chips for newly active filters, then fix display order
                // (new chips append at the end; order must follow `desired`).
                foreach (var (text, remove) in desired)
                {
                    if (flowChips.Controls.OfType<DarkChip>().All(c => c.Text != text))
                        flowChips.Controls.SetChildIndex(flowChips.AddChip(text, (_, _) => remove()), desired.FindIndex(d => d.Text == text));
                }

                if (PKGGridView.DataSource is DataTable dt)
                {
                    int visible = dt.DefaultView.Count;
                    int total = dt.Rows.Count;
                    lblFilterCount.Text = visible == total ? "" : $"matches {visible} / {total}";
                    // GLV tab indicator (option 2): the filter applies to the
                    // grouped view too - say so there.
                    bool active = !_filterState.IsEmpty;
                    lblGlvFilterHint.Text = active ? $"filtered: {visible} / {total}" : "";
                }
                UpdatePackageActionButtonStates();
            }
            catch (Exception ex)
            {
                Logger.LogWarning("Filter bar refresh failed: " + ex.Message);
            }
        }

        /// <summary>Filter bar Clear button: resets every aspect and the search.</summary>
        /// <summary>
        /// Responsive filter layout: the flow panel spans the groupbox width
        /// and its height is measured from the wrapped content (one line when
        /// maximized, wrapped lines otherwise); the chips row sits below and
        /// the groupbox height follows the content. AutoSize is NOT used:
        /// GrowOnly never shrinks, so a wrap at a narrow width would stick.
        /// </summary>
        private void grpFilter_Resize(object sender, EventArgs e)
        {
            if (!_pkgListLayoutInitialized)
                return;

            flpFilter.Width = grpFilter.ClientSize.Width - 16;
            flpFilter.Height = flpFilter.GetPreferredSize(new Size(flpFilter.Width, 0)).Height;
            RepositionFilterRows();
            AlignFilterRowLabels();
        }

        private void RepositionFilterRows()
        {
            flowChips.Width = grpFilter.ClientSize.Width - 16 - lblFilterCount.Width - 8;
            flowChips.Top = flpFilter.Bottom + 8;
            lblFilterCount.Top = flowChips.Top + 3;
            grpFilter.Height = flowChips.Bottom + 8;
            // Keep the PKG-list sub-tab glued below the filter group: it has
            // a fixed designer Top and would leave a gap when the groupbox
            // shrinks to one line on maximize.
            subTabControl.Top = grpFilter.Bottom + _pkgListTabTopGap;
            // Preserve the same bottom inset as the right-side Param.sfo
            // section rather than pushing the nested tab control lower when
            // the form is maximized.
            subTabControl.Height = Math.Max(0,
                tabPage1.ClientSize.Height - subTabControl.Top - _pkgListTabBottomGap);
        }

        /// <summary>
        /// Centers each filter label on the control it annotates. DarkLabel
        /// grows its height to fit the scaled font (DarkUI ApplyDpiHeight),
        /// so the designer height no longer matches: the flow panel places
        /// each child at its own Margin.Top, and the label's top margin (5
        /// design units) then leaves the vertically-centered text visibly
        /// low beside its combo (measured ~6 px at 200%, ~9 px at 175%).
        /// Encode the centering in the margin itself — the value the flow
        /// panel re-applies on every relayout — so alignment survives
        /// resizes; recompute here because it depends on the current,
        /// font-grown heights. The AutoSize checkbox in the same row hugs
        /// its font and needs no help.
        /// </summary>
        private void AlignFilterRowLabels()
        {
            if (!_pkgListLayoutInitialized)
                return;
            AlignLabelToControl(lblCategory, ccbCategory);
            AlignLabelToControl(lblRegion, ccbRegion);
            AlignLabelToControl(lblFilterSysVer, tbFilterSysVer);
            AlignLabelToControl(lblType, ccbType);
            AlignLabelToControl(lblShadps4, ccbShadps4);
        }

        private static void AlignLabelToControl(Control label, Control neighbor)
        {
            // Flow rows position every child at its own Margin.Top; center the
            // label on the neighbor within that scheme. Margins are scaled by
            // WinForms on DPI changes, and this pass re-runs after those, so a
            // device-pixel value here stays correct.
            int top = neighbor.Top + (neighbor.Height - label.Height) / 2;
            if (label.Margin.Top != top)
                label.Margin = new Padding(label.Margin.Left, top, label.Margin.Right, label.Margin.Bottom);
        }

        /// <summary>Shows the current window width (helper for layout tuning).</summary>
        private void btnShowWindowWidth_Click(object sender, EventArgs e)
        {
            AppMessageBox.Show("Window Width",
                $"Current window width: {this.Width} px\nClient width: {this.ClientSize.Width} px",
                AppMessageType.Info, AppMessageButtons.OK);
        }

        private void btnFilterClear_Click(object sender, EventArgs e) => ResetAllFilters();

        private void btnGlvFilterClear_Click(object sender, EventArgs e) => ResetAllFilters();

        /// <summary>Clears every filter condition (aspects, sysver, search) and re-applies.</summary>
        private void ResetAllFilters()
        {
            _filterState.Categories.Clear();
            _filterState.Regions.Clear();
            _filterState.MinSystemVersion = null;
            _filterState.PkgTypes.Clear();
            _filterState.CompatStatuses.Clear();
            _filterState.Shadps4InstalledOnly = false;
            _filterState.SearchText = "";
            tbFilterSysVer.Text = "";
            tbSearchGame.Text = "";
            tbSearchGame.SearchText = "";
            ApplyFilters();
        }

        #endregion PKGGridViewFiltering

        #region Shadps4Integration

        private Shadps4Environment GetShadps4Environment()
            => Shadps4EnvironmentResolver.Resolve(appSettings_.Shadps4ExecutablePath);

        private DataRow? GetSelectedGridRow()
        {
            if (PKGGridView.CurrentRow?.DataBoundItem is DataRowView drv)
                return drv.Row;
            return null;
        }

        private static string GetRowPkgPath(DataRow row)
        {
            string dir = row[PkgColumns.Directory]?.ToString() ?? "";
            string file = row[PkgColumns.Filename]?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(file)) return "";
            return string.IsNullOrWhiteSpace(dir) ? file : Path.Combine(dir, file);
        }

        private void toolStripMenuItemShadps4Configure_Click(object sender, EventArgs e)
        {
            // shadPS4 paths now live in the manager's Settings tab.
            OpenShadps4Manager(Shadps4Manager.SettingsTabIndex);
        }

        /// <summary>Tools > shadPS4 Manager (menu bar entry).</summary>
        private void toolStripMenuItemShadps4Manager_Click(object sender, EventArgs e) => OpenShadps4Manager();

        /// <summary>PKG context menu: shadPS4 > Open shadPS4 Manager.</summary>
        private void toolStripMenuItemShadps4OpenManager_Click(object sender, EventArgs e) => OpenShadps4Manager();

        /// <summary>
        /// Opens the shadPS4 Manager hub (overview, games, builds, saves,
        /// settings). The manager owns all shadPS4 operational tasks; Program
        /// Settings only keeps the compatibility database section.
        /// </summary>
        private Shadps4Manager? _shadps4Manager;

        private void OpenShadps4Manager(int initialTabIndex = 0, Shadps4Manager.InstallRequest? installRequest = null)
        {
            // Single-instance, modeless: installs run inside the manager while
            // this window stays usable. A closed manager is recreated; a live
            // one is restored (if minimized), focused and handed the request.
            if (_shadps4Manager == null || _shadps4Manager.IsDisposed)
            {
                _shadps4Manager = new Shadps4Manager(appSettings_,
                    installRequest != null ? Shadps4Manager.GamesTabIndex : initialTabIndex,
                    installRequest);
                _shadps4Manager.Disposed += (_, _) => _shadps4Manager = null;
                _shadps4Manager.Show(this);
                return;
            }

            if (_shadps4Manager.WindowState == FormWindowState.Minimized)
                _shadps4Manager.WindowState = FormWindowState.Normal;
            _shadps4Manager.Activate();
            _shadps4Manager.BringToFront();

            if (installRequest != null)
                _shadps4Manager.RequestInstall(installRequest);
            else if (initialTabIndex != 0)
                _shadps4Manager.ShowTab(initialTabIndex);
        }

        /// <summary>Opens the first-run setup wizard (install recommended / specific version / adopt existing).</summary>
        private void toolStripMenuItemShadps4InstallSetup_Click(object sender, EventArgs e)
        {
            using var wizard = new Shadps4SetupWizard(appSettings_);
            wizard.ShowDialog(this);
            if (wizard.Tag as string == "use-existing")
            {
                OpenShadps4Manager(Shadps4Manager.SettingsTabIndex);
                return;
            }
            // After a successful install the wizard persists the active
            // core/launcher itself; just refresh any cached state.
            Logger.LogInformation("shadPS4 setup wizard closed.");
        }

        /// <summary>Resolves managed build ids against the installed store (hook for the active-core model).</summary>
        private string? ResolveManagedShadps4Build(string buildId)
            => new Shadps4ManagedBuilds(appSettings_.Shadps4ManagedRoot).ResolveManagedExecutable(buildId);

        private void toolStripMenuItemShadps4Launch_Click(object sender, EventArgs e)
        {
            var row = GetSelectedGridRow();
            if (row == null) { ShowWarning("Select a PKG in the grid first.", false); return; }

            string titleId = row[PkgColumns.TitleId]?.ToString() ?? "";

            // Launch uses ONLY the explicitly configured Active Core. A core
            // discovered on disk (e.g. in a parent folder) is never selected
            // automatically - a real incident happened when an old parent-folder
            // core was used and the game crashed.
            string activeCore = appSettings_.Shadps4ActiveCore ?? "";
            string? corePath = Shadps4ActiveCore.ResolveExecutable(activeCore, ResolveManagedShadps4Build, out string? error);
            if (corePath == null)
            {
                var envForCandidate = GetShadps4Environment();
                string? candidate = envForCandidate.CoreExePath;
                if (!string.IsNullOrWhiteSpace(candidate) && File.Exists(candidate))
                {
                    // External candidate - explicit approval only.
                    var adopt = AppMessageBox.Show("shadPS4",
                        $"{error}\n\n" +
                        $"External shadPS4 core detected:\n{candidate}\n\n" +
                        "This core was not verified as belonging to the selected QtLauncher build.\n\n" +
                        "Adopt This Core?",
                        AppMessageType.Warning, AppMessageButtons.YesNoCancel);
                    if (adopt != DialogResult.Yes) return;
                    appSettings_.Shadps4ActiveCore = Shadps4ActiveCore.ForAdopted(candidate);
                    SettingsManager.SaveSettings(appSettings_, SettingFilePath);
                    corePath = candidate;
                }
                else
                {
                    var setup = AppMessageBox.Show("shadPS4",
                        $"{error}\n\nOpen Program Settings to select or install shadPS4?",
                        AppMessageType.Warning, AppMessageButtons.YesNo);
                    if (setup == DialogResult.Yes) OpenProgramSettings();
                    return;
                }
            }

            var env = GetShadps4Environment();
            var launchEnv = new Shadps4Environment
            {
                CoreExePath = corePath,
                InstallDirectories = env.InstallDirectories,
            };
            // Games installed into the tool's OWN install directory (which
            // shadPS4's config does not know) are found via the launcher's
            // extra-search dirs and booted by path.
            var extraSearchDirs = new List<string>();
            string toolInstallDir = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(toolInstallDir)) extraSearchDirs.Add(toolInstallDir);
            var launcher = new Shadps4Launcher();
            launcher.Terminated += Shadps4Launcher_Terminated;
            var (status, message) = launcher.LaunchInstalledTitle(launchEnv, titleId, extraSearchDirs);
            switch (status)
            {
                case Shadps4LaunchStatus.Started:
                    // No success dialog - the status bar already says the
                    // game is running.
                    break;
                case Shadps4LaunchStatus.GameNotFound:
                    // Installing into the library is the supported path.
                    // Offer that path directly for the PKG the user tried to launch.
                    var installChoice = AppMessageBox.Show("shadPS4",
                        message + "\n\nInstall this PKG to the configured shadPS4 library now?",
                        AppMessageType.Warning, AppMessageButtons.YesNo);
                    if (installChoice == DialogResult.Yes)
                        BeginShadps4Install(row);
                    break;
                default:
                    ShowWarning(message, false);
                    break;
            }
        }

        /// <summary>
        /// Opens the Qt launcher (the shadPS4 settings UI) without a game.
        /// Uses ONLY the explicitly configured launcher - no silent fallback
        /// to a discovered one.
        /// </summary>
        private void toolStripMenuItemShadps4OpenLauncher_Click(object sender, EventArgs e)
        {
            string activeLauncher = appSettings_.Shadps4ActiveLauncher ?? "";
            string? launcherPath = Shadps4ActiveCore.ResolveExecutable(activeLauncher, ResolveManagedShadps4Build, out string? error);
            if (launcherPath == null)
            {
                var env = GetShadps4Environment();
                string? candidate = env.LauncherExePath;
                if (!string.IsNullOrWhiteSpace(candidate) && File.Exists(candidate))
                {
                    var adopt = AppMessageBox.Show("shadPS4",
                        $"{error}\n\n" +
                        $"A QtLauncher was detected:\n{candidate}\n\n" +
                        "Adopt This Launcher?",
                        AppMessageType.Warning, AppMessageButtons.YesNoCancel);
                    if (adopt != DialogResult.Yes) return;
                    appSettings_.Shadps4ActiveLauncher = Shadps4ActiveCore.ForAdopted(candidate);
                    SettingsManager.SaveSettings(appSettings_, SettingFilePath);
                    launcherPath = candidate;
                }
                else
                {
                    var setup = AppMessageBox.Show("shadPS4",
                        $"{error}\n\nOpen Program Settings to select or install the Qt launcher?",
                        AppMessageType.Warning, AppMessageButtons.YesNo);
                    if (setup == DialogResult.Yes) OpenProgramSettings();
                    return;
                }
            }

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = launcherPath,
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(launcherPath) ?? "",
                };
                Process.Start(psi);
                ShowInformation("shadPS4 QtLauncher opened.", false);
            }
            catch (Exception ex)
            {
                ShowError($"Failed to open the shadPS4 QtLauncher:\n{ex.Message}", false);
            }
        }

        private void toolStripMenuItemShadps4Install_Click(object sender, EventArgs e)
            => BeginShadps4Install();

        private void toolStripMenuItemShadps4Uninstall_Click(object sender, EventArgs e)
        {
            DataRow? row = GetSelectedGridRow();
            if (row == null || !IsBaseGameRow(row) || !IsShadps4Installed(row))
            {
                ShowWarning("Select an installed base game first.", false);
                return;
            }

            if (_taskQueue.Tasks.Any(task => task.Type == "ShadPS4 Install"
                && task.Status is QueueTaskStatus.Running or QueueTaskStatus.Cancelling)
                || Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A shadPS4 installation is in progress. Wait for it to finish before uninstalling a game.", false);
                return;
            }

            string titleId = row[PkgColumns.TitleId]?.ToString()?.Trim() ?? "";
            string title = row[PkgColumns.Title]?.ToString()?.Trim() ?? titleId;
            if (!TryFindInstalledShadps4Game(titleId, out string gamePath))
            {
                RefreshShadps4InstalledFilterState();
                ShowWarning($"{titleId} is no longer installed in the configured shadPS4 library.", false);
                return;
            }

            if (Shadps4Launcher.IsEmulatorRunning())
            {
                var runningWarning = AppMessageBox.Show("shadPS4",
                    "shadPS4 is currently running.\n\nDeleting a game while the emulator is using it may fail or leave inconsistent files.\n\nContinue?",
                    AppMessageType.Warning, AppMessageButtons.YesNo);
                if (runningWarning != DialogResult.Yes) return;
            }

            var confirmation = AppMessageBox.Show("Uninstall game",
                $"Uninstall '{title}' ({titleId})?\n\n" +
                $"This permanently deletes the installed game folder:\n{gamePath}\n\n" +
                "This cannot be undone.",
                AppMessageType.Warning, AppMessageButtons.YesNo);
            if (confirmation != DialogResult.Yes) return;

            try
            {
                Directory.Delete(gamePath, true);
                Logger.LogInformation($"Shadps4: uninstalled {titleId} from {gamePath}");
                NotifyShadps4ManagerOfQueuedInstall();
                RefreshShadps4InstalledFilterState();
                ShowInformation($"'{title}' has been uninstalled from shadPS4.", true);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Shadps4: failed to uninstall {titleId}: {ex.Message}");
                ShowError("Uninstall failed:\n" + ex.Message, false);
            }
        }

        private bool TryFindInstalledShadps4Game(string titleId, out string gamePath)
        {
            gamePath = "";
            string library = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(titleId) || string.IsNullOrWhiteSpace(library) || !Directory.Exists(library))
                return false;

            string libraryPath = Path.TrimEndingDirectorySeparator(Path.GetFullPath(library));
            try
            {
                foreach (string candidate in Directory.EnumerateDirectories(libraryPath))
                {
                    if (Path.GetFileName(candidate).StartsWith(".ps4pkgtool-", StringComparison.OrdinalIgnoreCase)
                        || !File.Exists(Path.Combine(candidate, "eboot.bin")))
                        continue;

                    string sfoPath = Path.Combine(candidate, "sce_sys", "param.sfo");
                    if (!File.Exists(sfoPath)) continue;
                    string installedTitleId = OrbisPkgTool.Sfo.ParamSfo.Parse(File.ReadAllBytes(sfoPath)).GetString("TITLE_ID")?.Trim() ?? "";
                    if (!string.Equals(titleId, installedTitleId, StringComparison.OrdinalIgnoreCase)) continue;

                    string resolvedPath = Path.TrimEndingDirectorySeparator(Path.GetFullPath(candidate));
                    if (string.Equals(Path.GetDirectoryName(resolvedPath), libraryPath, StringComparison.OrdinalIgnoreCase))
                    {
                        gamePath = resolvedPath;
                        return true;
                    }
                }
            }
            catch (Exception ex) { Logger.LogWarning("Failed to inspect shadPS4 library before uninstall: " + ex.Message); }
            return false;
        }

        private void BeginShadps4Install(DataRow onlyRow = null)
        {
            var rows = onlyRow != null
                ? new List<DataRow> { onlyRow }
                : PKGGridView.SelectedRows.Cast<DataGridViewRow>()
                    .Select(selectedRow => new
                    {
                        Row = (selectedRow.DataBoundItem as DataRowView)?.Row,
                        selectedRow.Index
                    })
                    .Where(item => item.Row != null)
                    .OrderBy(item => (item.Row![PkgColumns.Category]?.ToString() ?? "").Contains(PKGCategory.GAME) ? 0 : 1)
                    .ThenBy(item => item.Index)
                    .Select(item => item.Row!)
                    .ToList();
            if (rows.Count == 0) { ShowWarning("Select one or more PKGs in the grid first.", false); return; }

            if (Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A direct shadPS4 installation is in progress. Wait for it to finish before adding installs to the queue.", false);
                return;
            }

            var selectedBaseTitleIds = rows
                .Where(row => (row[PkgColumns.Category]?.ToString() ?? "").Contains(PKGCategory.GAME))
                .Select(row => row[PkgColumns.TitleId]?.ToString() ?? "")
                .Where(titleId => !string.IsNullOrWhiteSpace(titleId))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);
            var requests = new List<Shadps4Manager.InstallRequest>();
            foreach (DataRow row in rows)
            {
                string category = row[PkgColumns.Category]?.ToString() ?? "";
                bool isGame = category.Contains(PKGCategory.GAME);
                bool isPatch = category.Contains(PKGCategory.PATCH);
                string titleId = row[PkgColumns.TitleId]?.ToString() ?? "";
                Logger.LogInformation($"Shadps4InstallUI: install requested for {titleId} (category '{category}', isPatch={isPatch})");
                if (!isGame && !isPatch)
                {
                    Logger.LogWarning("Shadps4InstallUI: rejected - not a base game or patch");
                    ShowWarning($"{titleId} is not a base game or update PKG. DLC/addon installation is not supported yet.", false);
                    continue;
                }

                string pkgPath = GetRowPkgPath(row);
                if (string.IsNullOrWhiteSpace(pkgPath) || !File.Exists(pkgPath))
                {
                    Logger.LogWarning($"Shadps4InstallUI: PKG missing on disk: {pkgPath}");
                    ShowWarning($"PKG file not found on disk:\n{pkgPath}", false);
                    continue;
                }

                Shadps4Manager.InstallRequest? request = PrepareShadps4Install(
                    row, pkgPath, isPatch, selectedBaseTitleIds.Contains(titleId));
                if (request is not null)
                    requests.Add(request);
            }

            // Do not enqueue while confirmation dialogs are still being shown.
            // With Auto Start on, tasks must only begin after this batch is fully approved.
            foreach (Shadps4Manager.InstallRequest request in requests)
            {
                EnqueueShadps4Install(request);
                Logger.LogInformation($"Shadps4InstallUI: queued {request.TitleId} into {request.Library}");
            }
        }

        /// <summary>
        /// Searches every known game location (shadPS4's configured libraries
        /// and the tool's own install directory) for the base game of a patch,
        /// excluding the current install target. Returns the folder path or null.
        /// </summary>
        private string? FindBaseGameLocation(string titleId, string excludeDir)
        {
            var env = GetShadps4Environment();
            var dirs = new List<string>(env.InstallDirectories);
            string toolDir = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(toolDir)) dirs.Add(toolDir);

            foreach (string d in dirs)
            {
                if (string.IsNullOrWhiteSpace(d) || !Directory.Exists(d)) continue;
                if (string.Equals(d.TrimEnd('\\', '/'), excludeDir.TrimEnd('\\', '/'), StringComparison.OrdinalIgnoreCase)) continue;
                string candidate = Path.Combine(d, titleId);
                if (Directory.Exists(candidate) && File.Exists(Path.Combine(candidate, "eboot.bin")))
                {
                    Logger.LogInformation($"Shadps4InstallUI: base game for {titleId} found at {candidate}");
                    return candidate;
                }
            }
            return null;
        }

        /// <summary>
        /// Transactional install into a shadPS4 library (staging folder inside
        /// the library, validation, same-volume rename). Existing installations
        /// are never overwritten without explicit approval; a running shadPS4
        /// triggers an extra warning for replacement installs.
        /// Patches (update PKGs) MERGE into the existing game folder instead of
        /// replacing it - same-named files are overwritten, base files remain.
        /// The target folder comes from the user's shadPS4 install-directory
        /// setting (auto-filled from shadPS4's own config in Program Settings)
        /// and can be changed per install - nothing is hardcoded.
        /// </summary>
        private Shadps4Manager.InstallRequest? PrepareShadps4Install(DataRow row, string pkgPath, bool isPatch, bool baseSelectedInBatch)
        {
            string titleId = row[PkgColumns.TitleId]?.ToString() ?? "";
            string title = row[PkgColumns.Title]?.ToString() ?? "";
            // Tracks whether a Yes/No dialog already approved the install, so
            // the final confirmation is only asked when nothing else did.
            bool confirmed = false;

            // No known shadPS4 compatibility status: warn (this dialog doubles
            // as the install confirmation for this path).
            string compat = row[PkgColumns.Shadps4]?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(compat))
            {
                var compatChoice = AppMessageBox.Show("shadPS4",
                    $"No shadPS4 compatibility status is known for {title} ({titleId}).\n\n" +
                    "The game may not run in the emulator. Continue with the installation?",
                    AppMessageType.Warning, AppMessageButtons.YesNo);
                if (compatChoice != DialogResult.Yes) return null;
                confirmed = true;
            }

            // Install straight into the configured directory - the folder
            // dialog appears only when none is configured (or the configured
            // one no longer exists).
            string library = appSettings_.Shadps4InstallDirectory?.Trim() ?? "";
            if (string.IsNullOrEmpty(library) || !Directory.Exists(library))
            {
                using var fbd = new FolderBrowserDialog
                {
                    Description = "Choose the shadPS4 game install folder.",
                    ShowNewFolderButton = true,
                };
                if (fbd.ShowDialog() != DialogResult.OK) return null;
                library = fbd.SelectedPath;
            }

            string finalDir = Path.Combine(library, titleId);

            // A patch without a base game cannot boot - it only updates the
            // base's files. Warn (but do not block) when no base is detected
            // in the target folder; if the base exists in ANOTHER library,
            // say where so the user can install the patch there instead.
            bool hasBase = Directory.Exists(finalDir)
                && File.Exists(Path.Combine(finalDir, "eboot.bin"));
            if (isPatch && !hasBase && !baseSelectedInBatch)
            {
                string? baseLocation = FindBaseGameLocation(titleId, library);
                string message = baseLocation != null
                    ? $"The base game for {titleId} was found in another library:\n{baseLocation}\n\n" +
                      "This install target has no base game, so the patch alone cannot boot.\n\n" +
                      "Cancel and install the patch into the library that contains the base game?"
                    : $"No base game detected for {titleId} in\n{library}\n\n" +
                      "A patch alone cannot boot, it only updates the base game's files, which are not installed yet.\n\n" +
                      "Install the patch anyway?";

                var warnBase = AppMessageBox.Show("shadPS4", message,
                    AppMessageType.Warning, AppMessageButtons.YesNo);
                if (warnBase != DialogResult.Yes) return null;
                confirmed = true;
            }

            bool replace = false;
            if (Directory.Exists(finalDir))
            {
                string installedVer = ParamSfoReader.ReadAppVersion(Path.Combine(finalDir, "sce_sys", "param.sfo")) ?? "unknown";
                string selectedVer = row[PkgColumns.AppVersion]?.ToString() ?? "unknown";

                if (Shadps4Launcher.IsEmulatorRunning())
                {
                    var warn = AppMessageBox.Show("shadPS4",
                        "shadPS4 is currently running.\n\nModifying an installed game while the emulator is using it may fail or leave inconsistent files.\n\nContinue?",
                        AppMessageType.Warning, AppMessageButtons.YesNo);
                    if (warn != DialogResult.Yes) return null;
                }

                if (isPatch)
                {
                    // Updates merge into the existing dump - files in the patch
                    // overwrite the base's, everything else stays untouched.
                    var mergeChoice = AppMessageBox.Show("shadPS4",
                        $"Game already installed\n\nInstalled version: {installedVer}\nThis patch: {selectedVer}\n\nThe patch will be merged into the existing installation. Continue?",
                        AppMessageType.Info, AppMessageButtons.YesNo);
                    if (mergeChoice != DialogResult.Yes) return null;
                    confirmed = true;
                }
                else
                {
                    var replaceChoice = AppMessageBox.Show("shadPS4",
                        $"Game already installed\n\nInstalled version: {installedVer}\nSelected PKG: {selectedVer}\n\nReplace the existing installation?",
                        AppMessageType.Info, AppMessageButtons.YesNo);
                    if (replaceChoice != DialogResult.Yes) return null;
                    replace = true;
                    confirmed = true;
                }
            }

            // Ask anyway when no earlier dialog approved the install (e.g. a
            // game with a known compatibility status installing into a fresh
            // folder - the common case still deserves a confirmation).
            if (!confirmed)
            {
                var go = AppMessageBox.Show("shadPS4",
                    $"Install {title} ({titleId}) into\n{library}?",
                    AppMessageType.Info, AppMessageButtons.YesNo);
                if (go != DialogResult.Yes) return null;
            }

            // All safety decisions are complete. The caller queues the completed
            // batch only after every selected PKG has passed its dialogs.
            string requestVersion = row[PkgColumns.AppVersion]?.ToString() ?? "";
            string requestInstalledVersion = Directory.Exists(finalDir)
                ? (ParamSfoReader.ReadAppVersion(Path.Combine(finalDir, "sce_sys", "param.sfo")) ?? "")
                : "";

            return new Shadps4Manager.InstallRequest(
                pkgPath, titleId, title, isPatch, library, replace,
                requestVersion, requestInstalledVersion);
        }

        #endregion Shadps4Integration

        #region PKGBasicOperation_Copy_Rename_Delete_ViewExplorer
        #region PKG_Copy_delete_View
        private void ViewPKGInExplorer()
        {
            var pkgList = GetSelectedPKGDirectoryList(PKGSelectionType.SELECTED);
            pkgList.ForEach(pkg => Logger.LogInformation($"Opening {pkg} PKG file in Explorer.."));
            pkgList.ForEach(pkg => Process.Start("explorer.exe", "/select," + pkg));
        }

        private void OpenTempDirectory()
        {
                Process.Start("explorer.exe", Helper.UserDataDirectory);
        }

        private void DeletePkg()
        {
            if (Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A shadPS4 installation is in progress.", false);
                return;
            }
            var pkgList = GetSelectedPKGDirectoryList(PKGSelectionType.SELECTED);
            DialogResult dialog = DialogResultYesNo("PKG file will be permanently deleted. This operation cannot be undone. Are you sure you want to continue?");

            if (dialog == DialogResult.Yes)
            {
                Logger.LogInformation($"Delete: {pkgList.Count} PKG(s)");
                PKG.isDeletingPkg = true;
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripStatusLabel2.Text = "Deleting...";
                var failures = new List<string>();
                try
                {
                    foreach (var pkg in pkgList)
                    {
                        try
                        {
                            string fullPkgPath = Path.GetFullPath(pkg);
                            File.Delete(fullPkgPath);
                            Logger.LogInformation($"\"{fullPkgPath}\" deleted.");

                            var matchingRow = PKGGridView.Rows.Cast<DataGridViewRow>()
                                .FirstOrDefault(row => !row.IsNewRow
                                    && string.Equals(GetGridRowPkgPath(row), fullPkgPath, StringComparison.OrdinalIgnoreCase));
                            if (matchingRow != null)
                                PKGGridView.Rows.Remove(matchingRow);

                            lock (PKG.VerifiedPs4PkgList)
                                PKG.VerifiedPs4PkgList.RemoveAll(path =>
                                    string.Equals(path, fullPkgPath, StringComparison.OrdinalIgnoreCase));
                        }
                        catch (Exception ex)
                        {
                            failures.Add(Path.GetFileName(pkg) + ": " + ex.Message);
                            Logger.LogError($"Failed to delete \"{pkg}\": {ex.Message}");
                        }
                    }

                    PKG.SelectedPKGFilename = ""; // Reset
                    labelDisplayTotalPKG.Text = "Displaying " + PKG.VerifiedPs4PkgList.Count.ToString() + " PS4 PKG";
                    PopulateGroupedView(); // remove deleted entries from the grouped view
                    if (failures.Count == 0)
                        ShowInformation(pkgList.Count == 1 ? "PKG file deleted." : $"{pkgList.Count} PKG files deleted.", true);
                    else
                        ShowWarning($"Deleted {pkgList.Count - failures.Count} of {pkgList.Count} PKG files.\n\n" +
                            string.Join("\n", failures), false);
                }
                finally
                {
                    PKG.isDeletingPkg = false;
                    toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                    toolStripProgressBar1.Value = 0;
                    toolStripStatusLabel2.Text = "...";
                }
            }
        }

        private void DeletePKG_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == deletePKGtoolStripMenuItem1 || clickedMenuItem == deletePkgtoolStripMenuItem2)
            {
                DeletePkg();
            }
        }

        #endregion PKG_Copy_delete_View

        #region renamePKG

        private void CheckForDuplicatePKG_Click(object sender, EventArgs args)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            Logger.LogInformation("Checking for duplicate PKG..");
            if (clickedMenuItem == checkForDuplicatePKGToolStripMenuItem1 ||  clickedMenuItem == checkForDuplicatePKGToolStripMenuItem2)
            {
                var result = FindDuplicatePKG();
                if (result.Count == 0)
                {
                    ShowInformation("No duplicate PKG detected.", true);
                }
                else
                {
                    ShowWarning($"Found {result.Count} duplicate PKG file(s):\n\n{string.Join("\n", result)}", true);
                }
            }
        }

        private List<string> FindDuplicatePKG()
        {
            // Key: filename + size - same name AND same size = duplicate
            var map = new Dictionary<string, List<string>>();
            var dupGroups = new List<List<string>>();

            foreach (DataGridViewRow row in PKGGridView.Rows)
            {
                string fn = row.Cells[0].Value?.ToString() ?? "";
                string sz = row.Cells[9].Value?.ToString() ?? ""; // Size column
                string dir = row.Cells[13].Value?.ToString() ?? "";
                string key = $"{fn}|{sz}"; // filename + size = reliable duplicate check
                string path = string.IsNullOrEmpty(dir) ? fn : Path.Combine(dir, fn);

                if (map.TryGetValue(key, out var list))
                {
                    list.Add(path);
                }
                else
                {
                    var newList = new List<string> { path };
                    map[key] = newList;
                    dupGroups.Add(newList);
                }
            }

            var result = dupGroups.Where(g => g.Count > 1).SelectMany(g => g).ToList();
            Logger.LogInformation($"Duplicate check: {result.Count} file(s) in {dupGroups.Count(g => g.Count > 1)} group(s).");
            return result;
        }

        private void UpdatePKGFilename(string newPkgName, string sourcePkg, string targetPkg)
        {
            string pkgFileName_ = Path.GetFileName(sourcePkg);
            string directoryName = Path.GetDirectoryName(sourcePkg);

            // The grid scan runs on the UI thread; the file move itself stays
            // on the calling worker so rename loops never block the UI on disk I/O.
            DataGridViewRow matchedRow = null;
            PKGGridView.Invoke((Action)(() =>
            {
                foreach (DataGridViewRow row in PKGGridView.Rows)
                {
                    string cell0 = row.Cells[0].Value?.ToString();
                    string cell12 = row.Cells[13].Value?.ToString();

                    if (string.Equals(cell0, pkgFileName_, StringComparison.OrdinalIgnoreCase)
                        && string.Equals(cell12, directoryName, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedRow = row;
                        return;
                    }
                }
            }));

            if (matchedRow != null)
            {
                File.Move(sourcePkg, targetPkg);
                UpdateVerifiedPkgPath(sourcePkg, targetPkg);
                string newFileName = newPkgName + ".pkg";
                PKGGridView.Invoke((Action)(() =>
                {
                    matchedRow.Cells[0].Value = newFileName;
                }));
                // Update the GLV cell in-place (no full rebuild, no selection loss).
                // Use targetPkg - after the DGV cell update above, GlvItem.FilePath
                // is recomputed from the DataRow and equals the new path, not sourcePkg.
                groupedListView?.Invoke((Action)(() =>
                    groupedListView.UpdateCellForPath(targetPkg, 0, newFileName)));
                return;
            }
            // Row not found - the grid may have been refreshed since this rename started.
            // Try the File.Move anyway so the file on disk is still renamed.
            if (File.Exists(sourcePkg) && !File.Exists(targetPkg))
            {
                File.Move(sourcePkg, targetPkg);
                UpdateVerifiedPkgPath(sourcePkg, targetPkg);
            }
        }

        private void ScheduleGroupedViewRefresh()
        {
            _groupedViewRefreshTimer.Stop();
            _groupedViewRefreshTimer.Start();
        }

        private static void UpdateVerifiedPkgPath(string sourcePkg, string targetPkg)
        {
            lock (PKG.VerifiedPs4PkgList)
            {
                int index = PKG.VerifiedPs4PkgList.FindIndex(path =>
                    string.Equals(path, sourcePkg, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                    PKG.VerifiedPs4PkgList[index] = targetPkg;
            }
        }

        #region RenameAllPkg

        #endregion RenameAllPkg

        #region RenameSelectedPKG

        #endregion RenameSelectedPKG
        #endregion renamePKG
        #endregion PKGBasicOperation_Copy_Rename_Delete_ViewExplorer

        #region PKGSender
        private void DisableControls_PkgSender()
        {
            //status bar - file
            managePS4PKGToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem1.Enabled = false;

            //contextmenu
            toolStripMenuItem111.Enabled = false;
            toolStripMenuItem3.Enabled = false;
            globalExportPKGListToExcelToolStripMenuItem2.Enabled = false;
            deletePkgtoolStripMenuItem2.Enabled = false;
            toolStripMenuItem133.Enabled = false;
            toolStripMenuItem127.Enabled = false;
            viewPkgExplorerStripMenuItem2.Enabled = false;
            RpiCheckPkgInstalledtoolStripMenuItem2.Enabled = false;
            toolStripMenuItem21.Enabled = false;
        }

        private void EnableControls_PkgSender()
        {
            //status bar - file
            managePS4PKGToolStripMenuItem.Enabled = true;
            exitToolStripMenuItem1.Enabled = true;

            //contextmenu
            toolStripMenuItem111.Enabled = true;
            toolStripMenuItem3.Enabled = true;
            globalExportPKGListToExcelToolStripMenuItem2.Enabled = true;
            deletePkgtoolStripMenuItem2.Enabled = true;
            toolStripMenuItem133.Enabled = true;
            toolStripMenuItem127.Enabled = true;
            viewPkgExplorerStripMenuItem2.Enabled = true;
            RpiCheckPkgInstalledtoolStripMenuItem2.Enabled = true;
            toolStripMenuItem21.Enabled = true;
        }

        private void InitializePKGSender()
        {
            if (RpiSendPkgtoolStripMenuItem2.Text == "Send PKG to PS4")
            {
                DisableTabPages(mainTabControl, "tabPage1");
                DisableControls(darkMenuStrip1);
                DisableControls_PkgSender();

                PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
                
                Logger.LogInformation("Sending " + read.PS4_Title + " to PS4..");

                // Update 'Settings.PKG.SelectedPKGFilename'
                GetSelectedPKGPath();

                PKGSENDER.taskMonitorIsCancelling = false;

                // Check if pkg installed
                if (read.PKG_Type.ToString() == PKGCategory.GAME || read.PKG_Type.ToString() == PKGCategory.PATCH)
                {
                    // Check if pkg exists for game pkg
                    PKGSENDER.JSON.CHECKAPPEXISTS.baseAppExist = true;

                    dynamic appExistsJson = null;
                    appExistsJson = PKGSENDER.CheckIfPkgInstalled(read);
                    if (appExistsJson == null)
                    {
                        ShowError("An error occurred while trying to communicate with PS4. Launch/restart Remote Package Installer application on PS4 and don't minimize it.", true);
                        EnableControls_PkgSender();
                        EnableTabPages(mainTabControl);
                        EnableControls(darkMenuStrip1);
                        return;
                    }

                    PKGSENDER.JSON.CHECKAPPEXISTS.status = appExistsJson.status.ToString();

                    if (PKGSENDER.JSON.CHECKAPPEXISTS.status == "success")
                    {
                        PKGSENDER.JSON.CHECKAPPEXISTS.exists = appExistsJson.exists.ToString();
                        if (PKGSENDER.JSON.CHECKAPPEXISTS.exists == "true")
                        {
                            if (read.PKG_Type.ToString() == PKGCategory.GAME)
                            {
                                ShowInformation("PKG already installed.", true);
                                EnableControls_PkgSender();
                                EnableTabPages(mainTabControl);
                                EnableControls(darkMenuStrip1);
                                return;
                            }
                        }
                        else
                        {
                            if (read.PKG_Type.ToString() == PKGCategory.PATCH)
                            {
                                PKGSENDER.JSON.CHECKAPPEXISTS.baseAppExist = false;
                            }
                        }
                    }
                }

                if (read.PKG_Type.ToString() == PKGCategory.ADDON)
                {
                    PKGSENDER.JSON.CHECKAPPEXISTS.baseAppExist = true;
                }

                toolStripMenuItem18.Text = "Remote PKG Installer | Status : Running";
                RpiSendPkgtoolStripMenuItem2.Text = "Stop Current Operation";
                toolStripMenuItem16.Text = "Remote PKG Installer | Status : Running";
                RpiSendPkgtoolStripMenuItem1.Text = "Stop Current Operation";
                toolStripStatusLabel2.Text = "Sending " + read.PS4_Title + " to PS4..";
                SendPKG();
            }
            else
            {
                Logger.LogInformation("Cancelling operation..");
                // Cancel current operation
                if (PKGSENDER.isPreparing)
                {
                    ShowWarning("Cannot cancel operation while preparing.", true);
                    return;
                }

                dynamic stopTaskJson = null;
                stopTaskJson = PKGSENDER.StopTask();
                if (stopTaskJson == null)
                {
                    ShowError("An error occurred while trying to communicate with PS4. Launch/restart Remote Package Installer application on PS4 and don't minimize it.", true);
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    return;
                }

                PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
                
                PKGSENDER.JSON.STOPTASK.status = stopTaskJson.status.ToString();
                if (PKGSENDER.JSON.STOPTASK.status == "success")
                {
                    // If stopping success, uninstall stopped game 
                    dynamic uninstallAppJson = null;
                    uninstallAppJson = PKGSENDER.UninstallGame(read);
                    if (uninstallAppJson == null)
                    {
                        ShowError("An error occurred while trying to communicate with PS4. Launch/restart Remote Package Installer application on PS4 and don't minimize it.", true);
                        EnableControls_PkgSender();
                        EnableTabPages(mainTabControl);
                        EnableControls(darkMenuStrip1);
                        return;
                    }

                    PKGSENDER.JSON.UNINTSALLAPP.status = uninstallAppJson.status.ToString();

                    // Cancel running background workers
                    PKGSENDER.MonitorPkgSenderTaskBackgroundWorker.CancelAsync();
                    SendPKG();
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    darkStatusStrip1.Invoke((MethodInvoker)delegate
                    {
                        toolStripStatusLabel2.Text = "...";
                        toolStripProgressBar1.Value = 0;
                    });

                    ShowInformation("Operation stopped.", true);
                }
                else
                {
                    ShowError("Failed to stop current operation.", true);
                }
            }
        }

        private async Task CheckIfAppInstalledOnPS4()
        {
            PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
            
            Logger.LogInformation("Checking if base PKG installed on PS4 (" + read.PS4_Title + ")..");

            DisableTabPages(mainTabControl, "tabPage1");
            DisableControls(darkMenuStrip1);
            DisableControls_PkgSender();

            dynamic app_exists_json = null;

            try
            {
                app_exists_json = await PKGSENDER.CheckIfPkgInstalled(read);
                if (app_exists_json == null)
                {
                    ShowError("An error occurred while trying to communicate with PS4. Launch/restart Remote Package Installer application on PS4 and don't minimize it.", true);
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    return;
                }

                PKGSENDER.JSON.CHECKAPPEXISTS.status = app_exists_json.status.ToString();

                if (PKGSENDER.JSON.CHECKAPPEXISTS.status == "success")
                {
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    PKGSENDER.JSON.CHECKAPPEXISTS.exists = app_exists_json.exists.ToString();
                    if (PKGSENDER.JSON.CHECKAPPEXISTS.exists == "true")
                    {
                        ShowInformation("PKG already installed.", true);
                    }
                    else
                    {
                        ShowInformation("PKG is not installed.", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("An error occurred: " + ex.Message, true);
            }
        }

        private void SendPKG()
        {
            var bg = new BackgroundWorker();
            bg.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                renameBackFile = false;
                var currentPkgFile = PKG.SelectedPKGFilename;
                send_pkg_json = null;
                PKGSENDER.pkgSendDone = false;
                PKGSENDER.pkgSendStopped = false;
                PKGSENDER.JSON.SENDPKG.status = "";
                PKGSENDER.JSON.SENDPKG.task_id = "";
                PKGSENDER.JSON.SENDPKG.title = "";
                PKGSENDER.JSON.SENDPKG.title_id = "";

                // Kill server if running
                Tool.KillNodeJS();

                PkgMetadata read = PkgMetadataReader.Read(currentPkgFile);
                                var tempFilename = read.Content_ID + "_" + read.PKG_Type.ToString() + "_Send_To_PS4.pkg";

                // Get directory
                var directory = Path.GetDirectoryName(currentPkgFile);

                // Get original filename
                var originalName = Path.GetFileName(currentPkgFile);

                // Rename to temp filename
                if (currentPkgFile != directory + @"\" + tempFilename)
                {
                    File.Move(currentPkgFile, directory + @"\" + tempFilename);
                }

                // Update filename in gridview
                PKGGridView.Invoke((Action)(() =>
                {
                    foreach (DataGridViewCell cell in PKGGridView.SelectedCells)
                    {
                        int selectedRowIndex = cell.RowIndex;
                        DataGridViewRow selectedRow = PKGGridView.Rows[selectedRowIndex];
                        selectedRow.Cells[0].Value = tempFilename;
                    }
                }));

                TEMPFILENAMESENDPKG = directory + @"\" + tempFilename;
                PKG.SelectedPKGFilename = TEMPFILENAMESENDPKG;

                // Run server
                PKGSENDER.RunServer(directory);

                // Send pkg
                send_pkg_json = PKGSENDER.SendPKG(tempFilename);
                if (send_pkg_json == null)
                {
                    this.Invoke((Action)(() =>
                    {
                        ShowError("An error occurred while trying to communicate with PS4. Launch/restart Remote Package Installer application on PS4 and don't minimize it.", true);
                        EnableControls_PkgSender();
                        EnableTabPages(mainTabControl);
                        EnableControls(darkMenuStrip1);
                        toolStripMenuItem18.Text = "Remote PKG Installer | Status : Idle";
                        RpiSendPkgtoolStripMenuItem2.Text = "Send PKG to PS4";
                        toolStripMenuItem16.Text = "Remote PKG Installer | Status : Idle";
                        RpiSendPkgtoolStripMenuItem1.Text = "Send PKG to PS4";
                        toolStripStatusLabel2.Text = "...";
                        toolStripProgressBar1.Value = 0;
                    }));
                    return;
                }

                PKGSENDER.JSON.SENDPKG.status = send_pkg_json.status.ToString();

                if (PKGSENDER.JSON.SENDPKG.status == "success")
                {
                    PKGSENDER.JSON.SENDPKG.status = send_pkg_json.status.ToString();
                    PKGSENDER.JSON.SENDPKG.task_id = send_pkg_json.task_id.ToString();
                    PKGSENDER.JSON.SENDPKG.title = send_pkg_json.title.ToString();
                    PKGSENDER.JSON.SENDPKG.title_id = read.TITLEID.ToUpper();
                    PKGSENDER.MonitorPkgSenderTaskBackgroundWorker = new BackgroundWorker();
                    PKGSENDER.MonitorPkgSenderTaskBackgroundWorker.WorkerSupportsCancellation = true;
                    MonitorPKGSenderTask(PKGSENDER.MonitorPkgSenderTaskBackgroundWorker);
                }
                else if (PKGSENDER.JSON.SENDPKG.status != "fail")
                {
                    PKGSENDER.JSON.SENDPKG.error = send_pkg_json.error.ToString();
                    this.Invoke((Action)(() =>
                    {
                        ShowError("Operation failed : \n\nStatus : " + PKGSENDER.JSON.SENDPKG.status + "\n" + PKGSENDER.JSON.SENDPKG.error, true);
                        toolStripMenuItem18.Text = "Remote PKG Installer | Status : Idle";
                        RpiSendPkgtoolStripMenuItem2.Text = "Send PKG to PS4";
                        toolStripMenuItem16.Text = "Remote PKG Installer | Status : Idle";
                        RpiSendPkgtoolStripMenuItem1.Text = "Send PKG to PS4";
                        toolStripStatusLabel2.Text = "...";
                        toolStripProgressBar1.Value = 0;
                        EnableControls_PkgSender();
                        EnableTabPages(mainTabControl);
                        EnableControls(darkMenuStrip1);
                    }));
                    return;
                }

                while (true)
                {
                    if (bg.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (PKGSENDER.pkgSendStopped)
                    {
                        break;
                    }

                    if (renameBackFile)
                    {
                        break;
                    }
                }

                // Update original filename in gridview
                PKGGridView.Invoke((Action)(() =>
                {
                    foreach (DataGridViewRow row in PKGGridView.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(tempFilename))
                        {
                            row.Cells[0].Value = originalName;
                        }
                    }
                }));

                // Rename original filename
                File.Move(TEMPFILENAMESENDPKG, currentPkgFile);
                PKG.SelectedPKGFilename = currentPkgFile;
            };
            bg.RunWorkerCompleted += delegate
            {
            };
            bg.RunWorkerAsync();
        }

        private async void Rpi_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            try
            {
                Logger.LogInformation("Checking RPI requirement..");
                var CheckRequirement = PKGSENDER.CheckRequirement();
                if (CheckRequirement != "OK")
                {
                    ShowError(CheckRequirement, true);
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    return;
                }

                if (clickedMenuItem == RpiCheckPkgInstalledtoolStripMenuItem1 || clickedMenuItem == RpiCheckPkgInstalledtoolStripMenuItem2)
                {
                    await CheckIfAppInstalledOnPS4();
                }
                if (clickedMenuItem == RpiSendPkgtoolStripMenuItem1 || clickedMenuItem == RpiSendPkgtoolStripMenuItem2)
                {
                    InitializePKGSender();
                }
                if (clickedMenuItem == RpiUninstallBasePKGToolStripMenuItem1 || clickedMenuItem == RpiUninstallBasePKGToolStripMenuItem2)
                {
                    UninstallBasePkgFromPs4();
                }
                if (clickedMenuItem == RpiUninstallPatchPKGToolStripMenuItem1 || clickedMenuItem == RpiUninstallPatchPKGToolStripMenuItem2)
                {
                    UninstallPatchPkgFromPs4();
                }
                if (clickedMenuItem == RpiUninstallDlcPKGToolStripMenuItem1 || clickedMenuItem == RpiUninstallDlcPKGToolStripMenuItem2)
                {
                    UninstallDlcPkgFromPs4();
                }
                if (clickedMenuItem == RpiUninstallThemePKGToolStripMenuItem1 || clickedMenuItem == RpiUninstallThemePKGToolStripMenuItem2)
                {
                    UninstallThemePkgFromPs4();
                }
            }
            catch (Exception ex)
            {
                // RPI commands run through BackgroundWorkers/async calls whose
                // failures surface here - never let one crash the whole app.
                Logger.LogError("Remote Package Installer command failed", ex);
                ShowError("An error occurred: " + ex.Message, true);
                EnableControls_PkgSender();
                EnableTabPages(mainTabControl);
                EnableControls(darkMenuStrip1);
            }
        }

        private void MonitorPKGSenderTask(BackgroundWorker bg)
        {
            bg.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                dynamic taskProgressJson = null;

                darkStatusStrip1.Invoke((MethodInvoker)delegate
                {
                    toolStripStatusLabel2.Text = "Preparing download..";
                    Logger.LogInformation("Preparing download..");
                    darkStatusStrip1.Refresh();
                });

                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        PKGSENDER.isPreparing = true;

                        // Monitor task progress
                        taskProgressJson = PKGSENDER.GetTaskProgress();
                        if (taskProgressJson == null)
                        {
                            // Handle the null case
                        }

                        PKGSENDER.JSON.MONITORTASK.packagePreparingTotal = Convert.ToInt32(taskProgressJson.preparing_percent.ToString());

                        if (PKGSENDER.JSON.MONITORTASK.packagePreparingTotal == 100)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        // Handle exceptions
                    }
                }

                PKGSENDER.isPreparing = false;

                taskProgressJson = PKGSENDER.GetTaskProgress();
                if (taskProgressJson == null)
                {
                    // Handle the null case
                }

                PKGSENDER.JSON.MONITORTASK.packageFilesizeTotal = taskProgressJson.length.ToString();
                PKGSENDER.JSON.MONITORTASK.packageTransferredTotal = taskProgressJson.transferred.ToString();
                PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal = taskProgressJson.rest_sec_total.ToString();
                darkStatusStrip1.Invoke((MethodInvoker)delegate
                {
                    toolStripProgressBar1.Maximum = Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal);
                });
                int totalRemainTime = Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal);
                int increment = 0;

                for (long i = Convert.ToInt64(PKGSENDER.JSON.MONITORTASK.packageTransferredTotal); i < Convert.ToInt64(PKGSENDER.JSON.MONITORTASK.packageFilesizeTotal); i++)
                {
                    try
                    {
                        PKGSENDER.isPreparing = false;

                        if (bg.CancellationPending)
                        {
                            e.Cancel = true;
                            PKGSENDER.taskMonitorIsCancelling = false;
                            break;
                        }

                        if (PKGSENDER.taskMonitorIsCancelling)
                        {
                            PKGSENDER.taskMonitorIsCancelling = false;
                            break;
                        }

                        taskProgressJson = PKGSENDER.GetTaskProgress();
                        if (taskProgressJson == null)
                        {
                            // Handle the null case
                        }

                        if (taskProgressJson.status.ToString() == "fail")
                        {
                            PKGSENDER.pkgSendStopped = true;
                            break;
                        }

                        PKGSENDER.JSON.MONITORTASK.packageFilesizeTotal = taskProgressJson.length.ToString();
                        PKGSENDER.JSON.MONITORTASK.packageTransferredTotal = taskProgressJson.transferred.ToString();
                        PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal = taskProgressJson.rest_sec_total.ToString();

                        long transferredTotal = Convert.ToInt64(PKGSENDER.JSON.MONITORTASK.packageTransferredTotal);
                        long filesizeTotal = Convert.ToInt64(PKGSENDER.JSON.MONITORTASK.packageFilesizeTotal);
                        var packageTransferredTotalFormatted = ByteSize.FromBytes(transferredTotal).ToString();
                        var packageFilesizeTotalFormatted = ByteSize.FromBytes(filesizeTotal).ToString();

                        if (Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal) == 0)
                        {
                            darkStatusStrip1.Invoke((MethodInvoker)delegate
                            {
                                toolStripProgressBar1.Value = 0;
                            });
                            break;
                        }

                        increment = totalRemainTime - Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal);

                        darkStatusStrip1.Invoke((MethodInvoker)delegate
                        {
                            toolStripProgressBar1.Increment(increment);
                            toolStripStatusLabel2.Text = $"Installing.. ({packageTransferredTotalFormatted}/{packageFilesizeTotalFormatted})";
                            Logger.LogInformation($"Installing.. ({packageTransferredTotalFormatted}/{packageFilesizeTotalFormatted})");
                            darkStatusStrip1.Refresh();
                        });

                        totalRemainTime = Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal);
                    }
                    catch
                    {
                        // Handle exceptions
                    }
                }

                if (Convert.ToInt32(PKGSENDER.JSON.MONITORTASK.TimeRemainingTotal) == 0)
                {
                    PKGSENDER.pkgSendDone = true;
                }

            };
            bg.ProgressChanged += delegate (object sender, ProgressChangedEventArgs progressChangedEventArgs)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    darkStatusStrip1.Invoke((MethodInvoker)delegate
                    {
                        toolStripStatusLabel2.Text = progressChangedEventArgs.UserState.ToString();
                        toolStripProgressBar1.Value = progressChangedEventArgs.ProgressPercentage;
                        darkStatusStrip1.Refresh();
                    });
                });
            };
            bg.RunWorkerCompleted += delegate
            {
                this.Invoke((MethodInvoker)delegate
                {
                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    toolStripStatusLabel2.Text = "...";
                    toolStripProgressBar1.Value = 0;

                    if (PKGSENDER.pkgSendStopped || PKGSENDER.taskMonitorIsCancelling)
                    {
                        ShowError("Operation stopped.", true);
                    }

                    if (PKGSENDER.pkgSendDone)
                    {
                        if (!PKGSENDER.JSON.CHECKAPPEXISTS.baseAppExist)
                        {
                            ShowInformation("Patch PKG sent to PS4. Manually install it after base PKG is installed : Notifications -> Downloads", true);
                        }
                        else
                        {
                            ShowInformation("PKG installed.", true);
                        }
                    }

                    renameBackFile = true;

                    // Kill the server if it is running.
                    // killNodeJS();

                    toolStripMenuItem18.Text = "Remote PKG Installer | Status : Idle";
                    RpiSendPkgtoolStripMenuItem2.Text = "Send PKG to PS4";
                    toolStripMenuItem16.Text = "Remote PKG Installer | Status : Idle";
                    RpiSendPkgtoolStripMenuItem1.Text = "Send PKG to PS4";
                });
            };
            bg.RunWorkerAsync();
        }

        private void UninstallDlcPkgFromPs4()
        {
            DisableTabPages(mainTabControl, "tabPage1");
            DisableControls(darkMenuStrip1);
            DisableControls_PkgSender();

            PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
            
            Logger.LogInformation("Uninstalling addon PKG (" + read.PS4_Title + ")..");

            // Uninstall installed addon pkg

            dynamic uninstall_patch_json = null;

            uninstall_patch_json = PKGSENDER.UninstallAddonTheme(read);
            if (uninstall_patch_json == null)
            {
                ShowError("An error occurred while trying to communicate with the PS4. Launch/restart the Remote Package Installer application on the PS4 and do not minimize it.", true);
                EnableControls_PkgSender();
                EnableTabPages(mainTabControl);
                EnableControls(darkMenuStrip1);
                return;
            }

            EnableControls_PkgSender();
            EnableTabPages(mainTabControl);
            EnableControls(darkMenuStrip1);
            PKGSENDER.JSON.UNINTSALLADDON.status = uninstall_patch_json.status.ToString();

            if (PKGSENDER.JSON.UNINTSALLADDON.status == "success")
            {
                ShowInformation("PKG uninstalled.", true);
            }
            else
            {
                ShowError("Uninstall failed.", true);
            }
        }

        private void UninstallThemePkgFromPs4()
        {
            DisableTabPages(mainTabControl, "tabPage1");
            DisableControls(darkMenuStrip1);
            DisableControls_PkgSender();

            PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
            
            Logger.LogInformation("Uninstalling theme PKG (" + read.PS4_Title + ")..");

            // Uninstall installed theme pkg

            dynamic uninstall_theme_json = null;

            uninstall_theme_json = PKGSENDER.UninstallAddonTheme(read);
            if (uninstall_theme_json == null)
            {
                ShowError("An error occurred while trying to communicate with the PS4. Launch/restart the Remote Package Installer application on the PS4 and do not minimize it.", true);
                EnableControls_PkgSender();
                EnableTabPages(mainTabControl);
                EnableControls(darkMenuStrip1);
                return;
            }

            PKGSENDER.JSON.UNINTSALLTHEME.status = uninstall_theme_json.status.ToString();

            EnableControls_PkgSender();
            EnableTabPages(mainTabControl);
            EnableControls(darkMenuStrip1);

            if (PKGSENDER.JSON.UNINTSALLTHEME.status == "success")
            {
                ShowInformation("PKG uninstalled.", true);
            }
            else
            {
                ShowError("Uninstall failed.", true);
            }
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            UninstallDlcPkgFromPs4();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            UninstallThemePkgFromPs4();
        }

        private void UninstallBasePkgFromPs4()
        {
            DisableTabPages(mainTabControl, "tabPage1");
            DisableControls(darkMenuStrip1);
            DisableControls_PkgSender();

            PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
                        Logger.LogInformation("Uninstalling base PKG (" + read.PS4_Title + ")..");

            // Check if pkg is installed

            dynamic app_exists_json = null;

            app_exists_json = PKGSENDER.CheckIfPkgInstalled(read);
            if (app_exists_json == null)
            {
                ShowError("An error occurred while trying to communicate with the PS4. Launch/restart the Remote Package Installer application on the PS4 and do not minimize it.", true);
                EnableControls_PkgSender();
                EnableTabPages(mainTabControl);
                EnableControls(darkMenuStrip1);
                return;
            }

            PKGSENDER.JSON.CHECKAPPEXISTS.status = app_exists_json.status.ToString();

            if (PKGSENDER.JSON.CHECKAPPEXISTS.status == "success")
            {
                PKGSENDER.JSON.CHECKAPPEXISTS.exists = app_exists_json.exists.ToString();
                if (PKGSENDER.JSON.CHECKAPPEXISTS.exists == "false")
                {
                    ShowInformation("PKG is not installed.", true);
                }
                else
                {
                    // Uninstall installed pkg

                    dynamic uninstall_app_json = null;
                    uninstall_app_json = PKGSENDER.UninstallGame(read);
                    if (uninstall_app_json == null)
                    {
                        ShowError("An error occurred while trying to communicate with the PS4. Launch/restart the Remote Package Installer application on the PS4 and do not minimize it.", true);
                        EnableControls_PkgSender();
                        EnableTabPages(mainTabControl);
                        EnableControls(darkMenuStrip1);
                        return;
                    }

                    EnableControls_PkgSender();
                    EnableTabPages(mainTabControl);
                    EnableControls(darkMenuStrip1);
                    PKGSENDER.JSON.UNINTSALLAPP.status = uninstall_app_json.status.ToString();

                    if (PKGSENDER.JSON.UNINTSALLAPP.status == "success")
                    {
                        ShowInformation("PKG uninstalled.", true);
                    }
                    else
                    {
                        ShowError("Uninstall failed.", true);
                    }
                }
            }
        }

        private void UninstallPatchPkgFromPs4()
        {
            DisableTabPages(mainTabControl, "tabPage1");
            DisableControls(darkMenuStrip1);
            DisableControls_PkgSender();

            PkgMetadata read = PkgMetadataReader.Read(PKG.SelectedPKGFilename);
            
            Logger.LogInformation("Uninstalling patch PKG (" + read.PS4_Title + ")..");

            // Uninstall installed patch pkg

            dynamic uninstall_patch_json = null;

            uninstall_patch_json = PKGSENDER.UninstallPatch(read);
            if (uninstall_patch_json == null)
            {
                ShowError("An error occurred while trying to communicate with the PS4. Launch/restart the Remote Package Installer application on the PS4 and do not minimize it.", true);
                EnableControls_PkgSender();
                EnableTabPages(mainTabControl);
                EnableControls(darkMenuStrip1);
                return;
            }

            PKGSENDER.JSON.UNINTSALLPATCH.status = uninstall_patch_json.status.ToString();

            EnableControls_PkgSender();
            EnableTabPages(mainTabControl);
            EnableControls(darkMenuStrip1);

            if (PKGSENDER.JSON.UNINTSALLPATCH.status == "success")
            {
                ShowInformation("PKG uninstalled.", true);
            }
            else
            {
                ShowError("Uninstall failed.", true);
            }
        }
        #endregion PKGSender


        private void OpenProgramSettings()
        {
            Logger.LogInformation("Opening Program Settings..");

            ProgramSetting form = new ProgramSetting();
            form.ShowDialog();
            this.BringToFront();

            UpdatePKGColorLabel();

            if (form.Refresh)
            {
                RefreshPkgList();
            }
            else
            {
                #region checkGridHideUnhide
                UpdateDataGridViewColumnVisibility();
                SetBackgroundMusicVolume();
                // Fill shadPS4 statuses immediately after a download/toggle/OS
                // change - BEFORE PopulateGroupedView so the grouped view sees
                // the refreshed statuses.
                if (appSettings_.psvr_neo_ps5bc_check && PKGGridView.DataSource is DataTable ps5BcDt)
                    ApplyPs5BcStatus(ps5BcDt);
                if (appSettings_.Shadps4Check && PKGGridView.DataSource is DataTable shadDt)
                    ApplyShadps4Status(shadDt);
                PopulateGroupedView(); // reflect column-visibility changes in the grouped view
                #endregion checkGridHideUnhide
            }
        }

        private void ExtractTrophyIcon()
        {
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                Logger.LogInformation("Extracting trophy icon..");
                string failExtract = "";

                if (Trophy.TrophyFilenameToExtractList.Count > 1)
                {
                    var trophyInfo = Trophy.TrophyFilenameToExtractList.Zip(Trophy.ImageToExtractList, (name, image) => new { Name = name, Image = image });

                    foreach (var info in trophyInfo)
                    {
                        try
                        {
                            using (Bitmap tempImage = new Bitmap(Helper.Bitmap.BytesToImage(Trophy.trophy.ExtractFileToMemory(info.Name))))
                            {
                                tempImage.Save(Path.Combine(fbd.SelectedPath, info.Name), ImageFormat.Png);
                            }
                        }
                        catch (Exception ex)
                        {
                            failExtract += ex.Message + "\n";
                        }
                    }

                    if (string.IsNullOrEmpty(failExtract))
                    {
                        ShowInformation("Trophy icons extracted.", true);
                    }
                    else
                    {
                        ShowError("Some trophy icons failed to extract.", true);
                        //Logger.LogError(failExtract);
                    }
                }
                else
                {
                    ShowError("Error occured when trying to extract trophy icons.", true);
                }
            }
        }

        private void ExtractTrophyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractTrophyIcon();
        }

        private void ContextMenuBackgroundImage_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            // save image
            if (clickedMenuItem == saveImageToolStripMenuItem && flatTabControlBgi.SelectedTab == tabPagePic0)
            {
                SaveBackgroundImage(pbPIC0);
            }
            if (clickedMenuItem == saveImageToolStripMenuItem && flatTabControlBgi.SelectedTab == tabPagePic1)
            {
                SaveBackgroundImage(pbPIC1);
            }

            // set image as background 
            if (clickedMenuItem == SetImageAsDesktopBackgroundToolStripMenuItem && flatTabControlBgi.SelectedTab == tabPagePic0)
            {
                SetImageAsDesktopBackground(pbPIC0);
            }
            if (clickedMenuItem == SetImageAsDesktopBackgroundToolStripMenuItem && flatTabControlBgi.SelectedTab == tabPagePic1)
            {
                SetImageAsDesktopBackground(pbPIC1);
            }
        }

        private void SaveBackgroundImage(PictureBox pb)
        {
            try
            {
                if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
                {
                    using (Bitmap tempImage = new Bitmap(pb.Image))
                    {
                        string pic = pb.Name == "pbPIC0" ? "PIC0" : "PIC1";
                        string filePath = Path.Combine(fbd.SelectedPath, $"{PKG.CurrentPKGTitle}_{pic}.PNG");
                        tempImage.Save(filePath, ImageFormat.Png);
                        ShowInformation("Background image saved.", false);
                        Logger.LogInformation($"Background image saved to \"{fbd.SelectedPath}\".");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Failed to save background image: {ex.Message}", true);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        private void SetImageAsDesktopBackground(PictureBox pb)
        {
            try
            {
                if (pb.Image == null)
                    return;

                using (Bitmap tempImage = new Bitmap(pb.Image))
                {
                    string savedImagePath = Path.Combine(AppDataDirectory, "Wallpaper");
                    Directory.CreateDirectory(savedImagePath);
                    string imagePath = Path.Combine(savedImagePath, "Wallpaper.JPG");

                    tempImage.Save(imagePath, ImageFormat.Jpeg);

                    SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, imagePath, SPIF_UPDATEINIFILE);
                    Logger.LogInformation("Image set as desktop background.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("An error occurred: " + ex.Message);
            }
        }


        private void darkDataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            this.TrophyGridView.ClearSelection();
        }

        private void ExtractDecryptedEntry()
        {
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                PkgMetadata PS4_PKG = PkgMetadataReader.Read(PKG.SelectedPKGFilename);

                Logger.LogInformation("Extracting decrypted items..");
                //load pkg file
                string itemIndex = "";
                var IO = new EndianIO(PKG.SelectedPKGFilename, EndianType.BigEndian, true);
                long file_length = IO.Length;
                if (file_length < 0x1C)
                {
                    IO.Close();
                    return;
                }

                //set output path for extracted files
                string path2pkg = Path.GetDirectoryName(PKG.SelectedPKGFilename);
                string fullpkgpath = Path.GetFullPath(PKG.SelectedPKGFilename);
                string pkgbasename = Path.GetFileNameWithoutExtension(PKG.SelectedPKGFilename);
                string pkgfilename = Path.GetFileName(PKG.SelectedPKGFilename);
                string outputpath = fbd.SelectedPath; // Path.Combine(path2pkg, pkgbasename);
                // textBox1.AppendText("\r\n\r\npath2pkg:   " + path2pkg);     //  C:\Downloads\ps4packages\
                // textBox1.AppendText("\r\nfullpkgpath:   " + fullpkgpath);   //  C:\Downloads\ps4packages\Up1018...V0100.pkg
                // textBox1.AppendText("\r\npkgbasename:   " + pkgbasename);   //  Up1018...V0100
                // textBox1.AppendText("\r\npkgfilename:   " + pkgfilename);   //  Up1018...V0100.pkg
                //textBox1.AppendText("\r\n\r\noutput path:\r\n" + outputpath); //  C:\Downloads\ps4packages\Up1018...V0100 
                Tool.CreateDirectoryIfNotExists(outputpath);

                //read and decrypt part 1 of key seed
                if (file_length < (0x2400 + 0x100))
                {
                    IO.Close();
                    return;
                }
                IO.SeekTo(0x2400);
                byte[] data = Entry.Decrypt(IO.In.ReadBytes(256));
                for (int j = 0; j < data.Length; j++)
                {

                }

                //read file entry table
                uint entry_count = IO.In.SeekNReadUInt32(0x10);
                if (entry_count == 0 || entry_count > 1_000_000) { IO.Close(); return; }
                uint file_table_offset = IO.In.SeekNReadUInt32(0x18);
                uint padded_size;

                uint strtab_count = 0;
                uint strtab_offset = 0;
                uint strtab_size = 0;

                if (file_length < (long)file_table_offset + (0x20L * entry_count))
                {
                    IO.Close();
                    return;
                }
                IO.SeekTo(file_table_offset);
                PackageEntry[] entry = new PackageEntry[entry_count];
                for (int i = 0; i < entry_count; i++)
                {
                    entry[i].type = IO.In.ReadUInt32();
                    entry[i].unk1 = IO.In.ReadUInt32();
                    entry[i].flags1 = IO.In.ReadUInt32();
                    entry[i].flags2 = IO.In.ReadUInt32();
                    entry[i].offset = IO.In.ReadUInt32();
                    entry[i].size = IO.In.ReadUInt32();
                    entry[i].padding = IO.In.ReadBytes(8);

                    //set key index, encryption flag, string table properties
                    entry[i].key_index = ((entry[i].flags2 & 0xF000) >> 12);
                    entry[i].is_encrypted = ((entry[i].flags1 & 0x80000000) != 0) ? true : false;
                    if (entry[i].unk1 != 0) strtab_count++;
                    if (entry[i].type == 0x200)
                    {
                        strtab_offset = entry[i].offset;
                        strtab_size = entry[i].size;
                    }
                }

                //read strtab
                if (file_length < (long)strtab_offset + strtab_size)
                {
                    IO.Close();
                    return;
                }
                string[] entry_name = new string[entry_count];
                if (strtab_count > 0)
                {
                    IO.SeekTo(strtab_offset);
                    byte[] string_table = IO.In.ReadBytes(strtab_size);
                    for (int i = 0; i < entry_count - 1; i++)
                    {
                        if (entry[i].unk1 != 0x00)
                        { //has strtab entry
                            entry_name[i] = System.Text.Encoding.UTF8.GetString(string_table, Convert.ToInt32(entry[i].unk1), (Convert.ToInt32(entry[i + 1].unk1) - 1) - Convert.ToInt32(entry[i].unk1));
                        }
                        else
                        {
                            entry_name[i] = "";
                        }
                    }
                    if (entry[entry_count - 1].unk1 != 0x00)
                    {
                        entry_name[entry_count - 1] = System.Text.Encoding.UTF8.GetString(string_table, Convert.ToInt32(entry[entry_count - 1].unk1), (Convert.ToInt32(strtab_size) - 1) - Convert.ToInt32(entry[entry_count - 1].unk1));
                    }
                    else
                    {
                        entry_name[entry_count - 1] = "";
                    }
                }
                else
                {
                    for (int i = 0; i < entry_count; i++) entry_name[i] = "";
                }

                var errorExtract = new Dictionary<string, string>();

                for (int i = 0; i < entry_count; i++)
                {
                    string savepath;
                    string savename;
                    string extrasavepath;

                    if (file_length < (long)entry[i].offset + entry[i].size)
                    {
                        IO.Close();
                        return;
                    }

                    if (entry[i].is_encrypted != false)
                    {
                        //print file attributes


                        //combine file entry and rsa decrypted data to form key seed
                        byte[] entry_data = new byte[0x40];
                        Array.Copy(entry[i].ToArray(), entry_data, 0x20);
                        Array.Copy(data, 0, entry_data, 0x20, 0x20);

                        //use sha256 to transform seed into aes iv and key
                        byte[] iv = new byte[0x10], key = new byte[0x10];
                        byte[] hash = Sha256(entry_data, 0, entry_data.Length);
                        Array.Copy(hash, 0, iv, 0, 0x10);
                        Array.Copy(hash, 0x10, key, 0, 0x10);

                        //output aes key and iv for current file


                        //read and decrypt current file
                        IO.In.BaseStream.Position = entry[i].offset;
                        if ((entry[i].size % 16) != 0)
                            padded_size = entry[i].size + (16 - (entry[i].size % 16));
                        else padded_size = entry[i].size;

                        //decrypt file
                        byte[] file_data = DecryptAes(key, iv, IO.In.ReadBytes(padded_size));

                        var entryOffset = $"0x{entry[i].offset:X8}";
                        if (!EncryptedEntryOffsetNameDictionary.TryGetValue(entryOffset, out var entryName))
                        {
                            entryName = $"entry_{i:D4}_{entryOffset}.bin";
                        }

                        try
                        {
                            if (entry[i].size > int.MaxValue)
                                throw new InvalidDataException("The decrypted entry is too large to hold in memory.");

                            savepath = Path.Combine(outputpath, entryName);
                            Array.Resize(ref file_data, checked((int)entry[i].size));
                            File.WriteAllBytes(savepath, file_data);
                        }
                        catch (Exception a)
                        {
                            errorExtract[entryName] = a.Message;
                        }

                    }
                }
                IO.Close();
                if (errorExtract.Count > 0)
                {
                    ShowWarning("Failed to extract some entries. See logs.", false);
                    Logger.LogWarning($"Failed to extract some entries:\n{string.Join("\n", errorExtract)}");
                }
                else
                {
                    ShowInformation("All decrypted entries extracted.", true);
                }
            }
        }

        private void ExtractDecryptedEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractDecryptedEntry();
        }

        private void ExtractAllEntry()
        {
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                Logger.LogInformation("Extracting PKG entries..");

                try
                {
                    List<string> encryptedEntries = new List<string>();
                    Dictionary<string, string> failedEntries = new Dictionary<string, string>();
                    var pkgPath = PKG.SelectedPKGFilename;

                    using (var pkgReader = new OrbisPkgTool.PkgReader(pkgPath))
                    using (var pkgFile = File.OpenRead(pkgPath))
                    {
                        var entries = pkgReader.Entries;

                        foreach (var entry in EntryIdNameDictionary)
                        {
                            var name = entry.Value;
                            try
                            {
                                var idx = int.Parse(entry.Key);
                                if (idx < 0 || idx >= entries.Count)
                                {
                                    failedEntries[name] = "Entry number is out of range.";
                                    continue;
                                }

                                var outName = name.Replace("_SHA", ".SHA").Replace("_DAT", ".DAT").Replace("_SFO", ".SFO").Replace("_XML", ".XML").Replace("_SIG", ".SIG").Replace("_PNG", ".PNG").Replace("_JSON", ".JSON").Replace("_DDS", ".DDS").Replace("_TRP", ".TRP").Replace("_AT9", ".AT9");
                                var outPath = Path.Combine(fbd.SelectedPath, outName);
                                var meta = entries[idx];

                                using (var outFile = File.Create(outPath))
                                {
                                    outFile.SetLength(meta.DataSize);
                                    if (meta.IsEncrypted)
                                    {
                                        encryptedEntries.Add(name);
                                    }

                                    // Raw copy; encrypted entries stay encrypted (legacy behavior).
                                    pkgFile.Position = meta.DataOffset;
                                    var buffer = new byte[81920];
                                    long remaining = meta.DataSize;
                                    while (remaining > 0)
                                    {
                                        int n = pkgFile.Read(buffer, 0, (int)Math.Min(buffer.Length, remaining));
                                        if (n <= 0) break;
                                        outFile.Write(buffer, 0, n);
                                        remaining -= n;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                failedEntries[name] = ex.Message;
                                Logger.LogError($"Error extracting {name} : {ex.Message}");
                            }
                        }
                    }

                    if (failedEntries.Count > 0)
                    {
                        ShowWarning("Failed to extract some entries. See logs.", false);
                        Logger.LogWarning($"Failed to extract some entries:\n{string.Join("\n", failedEntries.Select(item => $"{item.Key}: {item.Value}"))}");
                    }
                    else if (encryptedEntries.Count > 0)
                    {
                        ShowWarning("All entries extracted. Encrypted entries were saved as encrypted bytes.", false);
                        Logger.LogWarning($"Encrypted entries were saved without decryption:\n{string.Join("\n", encryptedEntries)}");
                    }
                    else
                    {
                        ShowInformation($"All entries extracted.", true);
                    }
                }
                catch (Exception a)
                {
                    ShowError(a.Message, true);
                }
            }
        }

        private void ExtractAllEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractAllEntry();
        }

        private void dgvEntryList_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvEntryList.ClearSelection();
        }

        private void dgvHeader_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvHeader.ClearSelection();
        }

        private void EnsureMainFileListing(
            string pkgPath, bool forceReload = false, bool reportErrors = false)
        {
            if (string.IsNullOrWhiteSpace(pkgPath) || !File.Exists(pkgPath))
                return;

            bool samePackage = string.Equals(
                _mainFileListingPath, pkgPath, StringComparison.OrdinalIgnoreCase);
            if (!forceReload && samePackage && _mainFileListingSession != null)
                return;

            DisposeMainFileListingSession();
            ClearFileBrowser();

            int listingVersion = Interlocked.Increment(ref _mainFileListingVersion);
            var session = new PkgFileListingSession(
                pkgPath, DefaultOrbisPasscode, new PkgFileListingService());
            _mainFileListingPath = pkgPath;
            _mainFileListingSession = session;

            _ = LoadMainFileListingAsync(
                session, pkgPath, listingVersion, reportErrors);
        }

        private async Task LoadMainFileListingAsync(
            PkgFileListingSession session,
            string pkgPath,
            int listingVersion,
            bool reportErrors)
        {
            Logger.LogInformation($"Listing PKG files: {Path.GetFileName(pkgPath)}");
            PKGTreeView.Enabled = false;
            listView1.Enabled = false;
            toolStripStatusLabel2.Text = "Listing PKG files...";
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            try
            {
                PkgFileListingResult result = await session.LoadAsync(CancellationToken.None);
                if (!IsCurrentMainFileListing(session, pkgPath, listingVersion))
                    return;

                if (!result.Succeeded)
                {
                    string message = result.ErrorMessage ?? "Package files could not be listed.";
                    Logger.LogError("View PKG list failed: " + message);
                    toolStripStatusLabel2.Text = "PKG files unavailable.";
                    if (reportErrors)
                        ShowError(message, true);
                    return;
                }

                string rootName = Path.GetFileNameWithoutExtension(pkgPath);
                try
                {
                    PkgMetadata meta = PkgMetadataReader.ReadQuick(pkgPath);
                    if (!string.IsNullOrWhiteSpace(meta?.TITLEID)) rootName = meta.TITLEID;
                    else if (!string.IsNullOrWhiteSpace(meta?.PS4_Title)) rootName = meta.PS4_Title;
                }
                catch { /* fall back to the file name */ }

                PopulateMainFileTree(result, rootName);
                Logger.LogInformation("PKG file list loaded.");

                // The single game-folder root is pre-selected so the middle list
                // view is ready before the user opens the File Browser tab.
                if (PKGTreeView.Nodes.Count > 0)
                {
                    rootNodes = new List<TreeNode>();
                    foreach (TreeNode rootNode in PKGTreeView.Nodes)
                        rootNodes.Add(rootNode);
                    TreeNode initial = rootNodes.FirstOrDefault(n => n.Nodes.Count > 0) ?? PKGTreeView.Nodes[0];
                    PKGTreeView.SelectedNode = initial;
                    TreeView.currentNode = initial;
                    PKG.NodeFullPath = NodeLogicalPath(initial);
                    PopulateListView();
                    listView1.RefreshLayout();
                    listView1.Refresh();
                }
            }
            catch (OperationCanceledException)
            {
                // Selecting another package or closing the form cancels this session.
            }
            catch (ObjectDisposedException)
            {
                // The selected package changed while its listing was running.
            }
            catch (Exception ex)
            {
                if (!IsCurrentMainFileListing(session, pkgPath, listingVersion))
                    return;

                Logger.LogError($"View PKG list failed for {pkgPath}: {ex}");
                toolStripStatusLabel2.Text = "PKG files unavailable.";
                if (reportErrors)
                    ShowError($"Failed to list PKG files:\n{ex.Message}", true);
            }
            finally
            {
                if (IsCurrentMainFileListing(session, pkgPath, listingVersion))
                {
                    PKGTreeView.Enabled = true;
                    listView1.Enabled = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                    toolStripProgressBar1.Value = 0;
                    if (toolStripStatusLabel2.Text == "Listing PKG files...")
                        toolStripStatusLabel2.Text = "...";
                }
            }
        }

        private bool IsCurrentMainFileListing(
            PkgFileListingSession session, string pkgPath, int listingVersion) =>
            !IsDisposed &&
            !Disposing &&
            listingVersion == _mainFileListingVersion &&
            ReferenceEquals(session, _mainFileListingSession) &&
            string.Equals(pkgPath, _mainFileListingPath, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(pkgPath, PKG.SelectedPKGFilename, StringComparison.OrdinalIgnoreCase);

        private void DisposeMainFileListingSession()
        {
            Interlocked.Increment(ref _mainFileListingVersion);
            PkgFileListingSession session = _mainFileListingSession;
            _mainFileListingSession = null;
            _mainFileListingPath = string.Empty;
            session?.Dispose();
        }

        private void PopulateMainFileTree(PkgFileListingResult listing, string rootName)
        {
            PKGTreeView.BeginUpdate();
            try
            {
                PKGTreeView.Nodes.Clear();
                PKGTreeView.PathSeparator = @"/";
                PKGTreeView.ImageList = imageList1;
                _fileSizes.Clear();
                _pathMap = listing.PathMap;
                _pkgEntries = listing.Entries.ToList();
                _pkgDirectories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (PkgFileEntry entry in listing.Entries)
                {
                    if (entry.IsDirectory)
                        _pkgDirectories.Add(entry.FullPath);
                    else
                        _fileSizes[entry.FullPath] = entry.Size;
                }

                // Show the flattened package as ONE game folder (like a decrypted
                // dump / shadPS4 library folder) instead of the raw layer roots.
                _treeRootName = string.IsNullOrWhiteSpace(rootName) ? "Game" : rootName;
                TreeNode wrapper = PKGTreeView.Nodes.Add(_treeRootName, _treeRootName);
                wrapper.ImageIndex = 0;
                wrapper.SelectedImageIndex = 0;
                foreach (PkgFileNode root in listing.Roots)
                    AddMainFileNode(wrapper.Nodes, root);
                wrapper.Expand();
            }
            finally
            {
                PKGTreeView.EndUpdate();
            }
            toolStripStatusLabel2.Text = "...";
            UpdatePackageActionButtonStates();
        }

        /// <summary>
        /// The logical (flattened) path for a tree node, with the synthetic
        /// single-root wrapper removed. Extraction/preview use this so the
        /// wrapper name never leaks into PKG entry lookups.
        /// </summary>
        private string NodeLogicalPath(TreeNode? node)
        {
            if (node == null) return string.Empty;
            string full = node.FullPath;
            if (_treeRootName.Length > 0)
            {
                if (full.Equals(_treeRootName, StringComparison.Ordinal))
                    return string.Empty;
                if (full.StartsWith(_treeRootName + "/", StringComparison.Ordinal))
                    full = full[(_treeRootName.Length + 1)..];
            }
            return full.TrimStart('/');
        }

        private void AddMainFileNode(TreeNodeCollection collection, PkgFileNode model)
        {
            TreeNode node = collection.Add(model.FullPath, model.Name);
            int icon = model.IsDirectory ? 0 : IconFor(model.Name);
            node.ImageIndex = icon;
            node.SelectedImageIndex = icon;
            if (model.IsDirectory)
                _pkgDirectories.Add(model.FullPath);
            foreach (PkgFileNode child in model.Children)
                AddMainFileNode(node.Nodes, child);
        }

        private void extractToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PKGTreeView.SelectedNode == null) return;
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                string extractLocation = fbd.SelectedPath;
                string path = NodeLogicalPath(PKGTreeView.SelectedNode);
                // If it's a directory, add trailing slash
                if (PKGTreeView.SelectedNode.Nodes.Count > 0 && !path.EndsWith("/"))
                    path += "/";
                ExtractSelectedPKGData(new List<string> { path }, extractLocation, preserveStructure: true);
            }
        }

        private void KillProcess(string processName)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                        Logger.LogInformation($"{processName} killed.");
                    }
                    catch (Exception ex)
                    {
                        // Handle any exception that occurred during process termination
                        Logger.LogError($"Error while killing process {processName}: {ex.Message}");
                    }
                }
            }
            catch
            {

            }

        }

        private BackgroundWorker _selectedExtractWorker;
        // Cancels the in-process PkgReader extraction (Stop Extract button).
        private CancellationTokenSource _extractionCts;
        // Set on the UI thread when Stop Extract is clicked; read by the workers after orbis dies.
        // BackgroundWorker.CancellationPending has no memory barrier, so it can read stale false -
        // this volatile flag is the reliable stop signal.
        private volatile bool _extractionStopRequested;

        /// <summary>
        /// During extraction only the Stop Extract button (and the status strip, which hosts
        /// the progress bar) stay enabled - everything else is disabled so no other operation
        /// can run or disturb the progress display.
        /// </summary>
        private void SetExtractionUiEnabled(bool enabled)
        {
            foreach (Control c in Controls)
            {
                if (c is StatusStrip) continue; // keep the progress bar visible
                if (c is System.Windows.Forms.TabControl tabs)
                {
                    foreach (TabPage page in tabs.TabPages)
                    {
                        if (page.Name == "tabPage7")
                        {
                            // File-browser tab stays reachable (it hosts the stop button);
                            // its other controls are toggled individually.
                            SetControlsEnabledRecursive(page, enabled, btnExtractFullPKG);
                        }
                        else
                        {
                            page.Enabled = enabled;
                        }
                    }
                    continue;
                }
                if (c != btnExtractFullPKG)
                    c.Enabled = enabled;
            }
        }

        /// <summary>
        /// Toggles every control under parent except keepEnabled and its ancestor chain
        /// (a disabled parent would disable the kept control too). Ancestors are still
        /// recursed into, so their OTHER children (e.g. the file-browser buttons that
        /// share panel6 with the stop button) get toggled.
        /// </summary>
        private static void SetControlsEnabledRecursive(Control parent, bool enabled, Control keepEnabled)
        {
            foreach (Control c in parent.Controls)
            {
                bool keep = (c == keepEnabled || IsAncestorOf(keepEnabled, c));
                if (c.HasChildren)
                    SetControlsEnabledRecursive(c, enabled, keepEnabled);
                if (!keep)
                    c.Enabled = enabled;
            }
        }

        private static bool IsAncestorOf(Control child, Control candidate)
        {
            for (Control p = child.Parent; p != null; p = p.Parent)
                if (p == candidate) return true;
            return false;
        }

        private void ExtractSelectedPKGData(List<string> nodeList, string extractLocation, bool preserveStructure = false)
        {
            var bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            _selectedExtractWorker = bgw;
            this.Invoke((Action)(() => btnExtractFullPKG.Text = "Stop Extract"));
            this.Invoke((Action)(() => SetExtractionUiEnabled(false))); // lock the app during extraction
            _extractionCts = new CancellationTokenSource();
            CancellationToken ct = _extractionCts.Token;
            int successCount = 0, failCount = 0;
            bgw.DoWork += (_, args) =>
            {
                this.Invoke((Action)(() =>
                {
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    toolStripProgressBar1.MarqueeAnimationSpeed = 30;
                }));
                string in_path = PKG.SelectedPKGFilename;
                try
                {
                    using var reader = new OrbisPkgTool.PkgReader(in_path, DefaultOrbisPasscode);
                    var (files, dirs) = PkgSelection.Resolve(_pkgEntries, nodeList, preserveStructure);
                    foreach (string dirRel in dirs)
                        Directory.CreateDirectory(PkgSelection.SafeDestination(extractLocation, dirRel));

                    foreach (var target in files)
                    {
                        if (_extractionStopRequested || bgw.CancellationPending)
                        {
                            args.Cancel = true;
                            break;
                        }
                        ct.ThrowIfCancellationRequested();

                        string out_path = PkgSelection.SafeDestination(extractLocation, target.DestRel);
                        string? outDir = Path.GetDirectoryName(out_path);
                        if (!string.IsNullOrEmpty(outDir))
                            Directory.CreateDirectory(outDir);

                        Logger.LogInformation($"Extracting {target.Logical} ({in_path})..");
                        this.Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabel2.Text = $"Extracting {target.Logical} ({in_path})..";
                        });

                        try
                        {
                            // Exact destination (no Image0/Sc0 prefix); the logical
                            // path already encodes the flattened structure.
                            reader.ExtractFileTo(target.Real, out_path);
                            successCount++;
                            Logger.LogInformation($"File extracted to \"{out_path}\"");
                        }
                        catch (Exception ex)
                        {
                            failCount++;
                            Logger.LogError($"Extraction failed for \"{target.Logical}\": {ex.Message}");
                            this.Invoke(() => ShowError($"Extraction failed:\n{ex.Message}", true));
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    args.Cancel = true;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Extraction failed: {ex.Message}");
                    this.Invoke(() => ShowError($"Extraction failed:\n{ex.Message}", true));
                }
            };
            bgw.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs e)
            {
                _selectedExtractWorker = null;
                SetExtractionUiEnabled(true); // unlock the app (covers cancel/error/success)
                this.Invoke((Action)(() =>
                {
                    btnExtractFullPKG.Text = "Extract full PKG";
                    toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                    toolStripProgressBar1.Value = 0;
                }));
                toolStripStatusLabel2.Text = $"...";
                if (e.Cancelled)
                {
                    ShowInformation("Extraction cancelled.", true);
                }
                else if (e.Error != null)
                {
                    Logger.LogError($"Extraction failed: {e.Error.Message}");
                    ShowError($"Extraction failed:\n{e.Error.Message}", true);
                }
                else
                {
                    // Report actual successes, not just how many were queued -
                    // per-entry failures already surfaced their own dialog.
                    string summary = failCount == 0
                        ? $"Extraction complete: {successCount} item(s) extracted."
                        : $"Extraction finished: {successCount} extracted, {failCount} failed.";
                    Logger.LogInformation($"Extraction complete: {successCount} succeeded, {failCount} failed (of {nodeList.Count})");
                    ShowInformation(summary, false);
                }
            };
            _extractionStopRequested = false; // new extraction starts clean
            bgw.RunWorkerAsync();
        }

        /// <summary>
        /// Synchronous version of ExtractSelectedPKGData for drag-drop. Opens the
        /// PKG read-only and extracts each entry into the temp drag folder.
        /// </summary>
        private void ExtractFilesSync(List<string> nodeList, string extractLocation, bool preserveStructure)
        {
            string inPath = PKG.SelectedPKGFilename;
            using var reader = new OrbisPkgTool.PkgReader(inPath, DefaultOrbisPasscode);
            var (files, dirs) = PkgSelection.Resolve(_pkgEntries, nodeList, preserveStructure);
            foreach (string dirRel in dirs)
                Directory.CreateDirectory(PkgSelection.SafeDestination(extractLocation, dirRel));

            foreach (var target in files)
            {
                string out_path = PkgSelection.SafeDestination(extractLocation, target.DestRel);
                string? outDir = Path.GetDirectoryName(out_path);
                if (!string.IsNullOrEmpty(outDir))
                    Directory.CreateDirectory(outDir);

                try
                {
                    reader.ExtractFileTo(target.Real, out_path); // exact dest, flattened
                }
                catch (Exception ex) { Logger.LogWarning($"Drag-drop extract failed for {target.Logical}: {ex.Message}"); }
            }
        }

        private void PKGTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var node = PKGTreeView.GetNodeAt(e.Location);
                if (node != null) PKGTreeView.SelectedNode = node;
                contextMenuExtractNode.Show(PKGTreeView, e.Location);
            }
        }

        private void PKGTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is not TreeNode node) return;

            if (node.Nodes.Count > 0) return; // directories disabled
            var nodeList = new List<string> { NodeLogicalPath(node) };

            // Short temp root - see ExtractFullPKG: deep AppData paths + long PKG paths exceed MAX_PATH.
            string dragDir = CreateOrbisTempDir("d");

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExtractFilesSync(nodeList, dragDir, preserveStructure: true);

                var extractedFiles = Directory.GetFiles(dragDir, "*", SearchOption.AllDirectories).ToList();
                if (extractedFiles.Count == 0) return;

                var data = new DataObject();
                data.SetData(DataFormats.FileDrop, extractedFiles.ToArray());
                DoDragDrop(data, DragDropEffects.Copy);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                try { Directory.Delete(dragDir, true); } catch (Exception ex) { Logger.LogWarning("Failed to clean drag temp dir: " + ex.Message); }
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Collect paths same as CtxExtractFolder_Click
            var nodeList = new List<string>();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (item.Text == "...") continue;
                if (item.Tag is not TreeNodeInfo info || info.Node == null) continue;
                bool isDir = info.Node.Nodes.Count > 0;
                if (isDir) continue; // drag-drop for directories disabled
                nodeList.Add(NodeLogicalPath(info.Node));
            }
            if (nodeList.Count == 0) return;

            // Short temp root - see ExtractFullPKG: deep AppData paths + long PKG paths exceed MAX_PATH.
            string dragDir = CreateOrbisTempDir("d");

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExtractFilesSync(nodeList, dragDir, preserveStructure: true);

                var extractedFiles = Directory.GetFiles(dragDir, "*", SearchOption.AllDirectories).ToList();
                if (extractedFiles.Count == 0) return;

                var data = new DataObject();
                data.SetData(DataFormats.FileDrop, extractedFiles.ToArray());
                DoDragDrop(data, DragDropEffects.Copy);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                try { Directory.Delete(dragDir, true); } catch (Exception ex) { Logger.LogWarning("Failed to clean drag temp dir: " + ex.Message); }
            }
        }

        private void PKGTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Helper.TreeView.Nodename = e.Node.Text;
        }

        private void darkDataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            this.darkDataGridView4.ClearSelection();
        }

        private string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        private void DisableTabPages(Control con, string name)
        {
            foreach (Control tab in mainTabControl.TabPages)
            {
                if (tab.Name != name)
                {
                    tab.Enabled = false;
                }
            }
        }

        private void EnableTabPages(Control con)
        {
            foreach (Control tab in mainTabControl.TabPages)
            {
                tab.Enabled = true;
            }
        }

        private void DisableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = false;
            }
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
            }
        }

        private void btnViewPKGData_Click(object sender, EventArgs e)
        {
            tbPasscode.Text = DefaultOrbisPasscode;
            PKG.Passcode = DefaultOrbisPasscode;

            Logger.LogInformation($"View PKG files: {Path.GetFileName(PKG.SelectedPKGFilename)}");
            EnsureMainFileListing(
                PKG.SelectedPKGFilename, forceReload: true, reportErrors: true);
        }

        /// <summary>
        /// Exports all decodeable textures of the currently previewed Unity .assets
        /// entry as PNGs. Re-extracts the entry + .resS companion to a temp dir,
        /// runs the framework exporter, reports the count.
        /// </summary>
        private void btnExportTextures_Click(object sender, EventArgs e)
        {
            if (_containerSource != null && _containerDetection != null && assetListView.Visible)
            {
                ExportContainerTextures();
                return;
            }

            string entryPath = _previewEntryPath ?? "";
            if (string.IsNullOrEmpty(entryPath) || string.IsNullOrEmpty(PKG.SelectedPKGFilename))
            {
                ShowWarning("No PKG entry to export from.", false);
                return;
            }

            using var fbd = new FolderBrowserDialog { Description = "Choose the folder for the exported texture PNGs" };
            if (fbd.ShowDialog() != DialogResult.OK) return;
            string outDir = fbd.SelectedPath;

            var bg = new BackgroundWorker();
            bg.DoWork += (_, _) =>
            {
                string tempDir = CreateOrbisTempDir("e");
                try
                {
                    string extracted = ExtractSingleEntryForPreview(PKG.SelectedPKGFilename, entryPath, tempDir);
                    if (string.IsNullOrEmpty(extracted)) return;

                    // Unity does not always name the stream after the .assets
                    // file. Stage every sibling stream, as the preview path does.
                    ExtractUnityStreamCompanions(PKG.SelectedPKGFilename, entryPath, tempDir);

                    var source = new Assets.IO.FileAssetSource(extracted, "PKG entry",
                        rel => ResolveUnityStreamCompanion(tempDir, rel));
                    var detection = _assetService.Detect(source);
                    if (detection == null) return;
                    var descriptor = _assetService.InspectAsync(source, detection).GetAwaiter().GetResult();

                    int before = Directory.GetFiles(outDir, "*.png").Length;
                    new Assets.Unity.UnityTextureExporter()
                        .ExportConvertedAsync(source, descriptor, outDir, CancellationToken.None)
                        .GetAwaiter().GetResult();
                    int count = Directory.GetFiles(outDir, "*.png").Length - before;

                    this.Invoke((MethodInvoker)delegate
                    {
                        ShowInformation($"Exported {count} texture PNG(s) to {outDir}.", true);
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ShowError("Texture export failed: " + ex.Message, false);
                    });
                }
                finally
                {
                    try { Directory.Delete(tempDir, true); } catch { }
                }
            };
            bg.RunWorkerCompleted += (_, _) =>
            {
                ResetMainProgressBar();
                toolStripStatusLabel2.Text = "...";
                this.Enabled = true;
            };
            this.Enabled = false;
            toolStripStatusLabel2.Text = "Exporting textures...";
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = true;
            bg.RunWorkerAsync();
        }

        /// <summary>
        /// Exports every decodable texture in the currently visible container list.
        /// Unity Texture2D objects and directly previewable image entries are
        /// converted to PNG. Other container entries are skipped.
        /// </summary>
        private void ExportContainerTextures()
        {
            var children = _containerChildren.ToList();
            if (children.Count == 0 || !CanExportContainerTextures())
            {
                string reason = _containerDetection?.Format == Assets.Handlers.UnrealPakHandler.FormatId
                    ? "This Unreal PAK has no directly decodable image entries. Its .uasset/.uexp texture payloads cannot be exported as PNG yet."
                    : "This container has no decodable texture entries to export.";
                ShowWarning(reason, false);
                return;
            }

            using var fbd = new FolderBrowserDialog { Description = "Choose the folder for the exported texture PNGs" };
            if (fbd.ShowDialog() != DialogResult.OK) return;
            string outDir = fbd.SelectedPath;

            var bg = new BackgroundWorker();
            bg.DoWork += (_, _) =>
            {
                int exported = 0;
                int skipped = 0;
                try
                {
                    Directory.CreateDirectory(outDir);
                    var unityExporter = new Assets.Unity.UnityTextureExporter();
                    for (int index = 0; index < children.Count; index++)
                    {
                        var child = children[index];
                        try
                        {
                            string outputPath = Path.Combine(outDir, BuildContainerTextureFileName(child.Name, index));
                            if (child is Assets.Containers.UnityObjectAssetSource unityChild)
                            {
                                if (unityChild.Object.ClassId != 28)
                                {
                                    skipped++;
                                    continue;
                                }

                                var descriptor = new Assets.Models.AssetDescriptor
                                {
                                    Name = child.Name,
                                    Format = Assets.Handlers.UnitySerializedFileHandler.FormatId,
                                    Size = child.Length,
                                    Capabilities = Assets.Abstractions.AssetCapabilities.ExportConverted,
                                };
                                unityExporter.ExportConvertedAsync(child, descriptor, outputPath, CancellationToken.None)
                                    .GetAwaiter().GetResult();
                                exported++;
                                continue;
                            }

                            var detection = _assetService.Detect(child);
                            if (detection == null)
                            {
                                skipped++;
                                continue;
                            }
                            var preview = _assetService.TryPreviewAsync(child, detection).GetAwaiter().GetResult();
                            if (preview?.Texture == null)
                            {
                                skipped++;
                                continue;
                            }

                            Assets.Export.PngExport.Write(preview.Texture, outputPath);
                            exported++;
                        }
                        catch (Assets.Errors.AssetException)
                        {
                            skipped++;
                        }
                        catch (InvalidDataException)
                        {
                            skipped++;
                        }
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (exported == 0)
                        {
                            ShowWarning("No decodable textures were exported. This container may use an unsupported texture format or external payloads.", false);
                            return;
                        }

                        string skippedText = skipped > 0 ? $" Skipped {skipped} non-decodable entry(s)." : "";
                        ShowInformation($"Exported {exported} texture PNG(s) to {outDir}.{skippedText}", true);
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ShowError("Texture export failed: " + ex.Message, false);
                    });
                }
            };
            bg.RunWorkerCompleted += (_, _) =>
            {
                ResetMainProgressBar();
                toolStripStatusLabel2.Text = "...";
                this.Enabled = true;
                UpdatePackageActionButtonStates();
            };
            this.Enabled = false;
            toolStripStatusLabel2.Text = "Exporting container textures...";
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = true;
            bg.RunWorkerAsync();
        }

        private bool CanExportContainerTextures()
        {
            foreach (Assets.Abstractions.IAssetSource child in _containerChildren)
            {
                if (child is Assets.Containers.UnityObjectAssetSource unityChild && unityChild.Object.ClassId == 28)
                    return true;

                string extension = Path.GetExtension(child.Name);
                if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".gif", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".dds", StringComparison.OrdinalIgnoreCase)
                    || extension.Equals(".gnf", StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private static string BuildContainerTextureFileName(string name, int index)
        {
            string stem = Path.GetFileNameWithoutExtension(name);
            if (string.IsNullOrWhiteSpace(stem)) stem = "texture";
            char[] invalid = Path.GetInvalidFileNameChars();
            stem = new string(stem.Select(c => invalid.Contains(c) ? '_' : c).ToArray());
            return $"{index + 1:D4}_{stem}.png";
        }

        private void btnExportTreeView_Click(object sender, EventArgs e)
        {
            if (PKGTreeView.Nodes.Count == 0) { ShowError("No data to export.", false); return; }
            using var sfd = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "txt",
                FileName = Path.GetFileNameWithoutExtension(PKG.SelectedPKGFilename ?? "export") + "_file_list.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                var sb = new System.Text.StringBuilder();
                // Root level: just the folder names, then their content
                foreach (TreeNode root in PKGTreeView.Nodes)
                {
                    sb.AppendLine(root.Text + "/");
                    WriteTree(sb, root, "", true);
                }
                File.WriteAllText(sfd.FileName, sb.ToString());
                ShowInformation("Tree exported.", true);
            }
            catch (Exception ex) { ShowError("Export failed: " + ex.Message, false); }
        }

        /// <summary>
        /// Writes a folder's children using box-drawing tree characters.
        /// Directories get a trailing "/"; files are plain. Example:
        /// ├── sce_sys/
        /// │   └── param.sfo
        /// └── eboot.bin
        /// </summary>
        private static void WriteTree(System.Text.StringBuilder sb, TreeNode folder, string indent, bool isLast)
        {
            var children = folder.Nodes.Cast<TreeNode>()
                .OrderBy(n => n.Nodes.Count > 0 ? 0 : 1)   // dirs first
                .ThenBy(n => n.Text, StringComparer.OrdinalIgnoreCase)
                .ToList();

            for (int i = 0; i < children.Count; i++)
            {
                var child = children[i];
                bool last = i == children.Count - 1;
                sb.Append(indent).Append(last ? "└── " : "├── ")
                  .Append(child.Text).Append(child.Nodes.Count > 0 ? "/" : "").AppendLine();
                WriteTree(sb, child, indent + (last ? "    " : "│   "), last);
            }
        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            // Keep user-adjusted column widths when the file browser is resized.
        }

        /// <summary>
        /// Splits the list view width equally across columns, leaving room for
        /// the vertical scrollbar so the last column (Size) is never clipped.
        /// </summary>
        private void BalanceListViewColumns()
        {
            if (listView1.Columns.Count == 0 || listView1.Width <= 0) return;
            int avail = listView1.Width - SystemInformation.VerticalScrollBarWidth;
            int per = avail / listView1.Columns.Count;
            for (int i = 0; i < listView1.Columns.Count; i++)
                listView1.Columns[i].Width = per;
            // last column absorbs the remainder
            listView1.Columns[listView1.Columns.Count - 1].Width += avail - per * listView1.Columns.Count;
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Intentionally left empty: DarkListView columns are user-resizable.
        }

        private void CheckForPatchesMissingBasePKG_Click(object sender, EventArgs args)
        {
            var table = (PKGGridView.DataSource as DataTable)
                ?? (PKGGridView.DataSource as DataView)?.Table;
            if (table == null)
            {
                ShowInformation("No PKG files are loaded.", true);
                return;
            }

            // A patch belongs to its base game by TITLE_ID. Only "Game" is a
            // valid base here: App, Addon, and other Patch rows are excluded.
            var baseTitleIds = new HashSet<string>(
                table.AsEnumerable()
                    .Where(row => string.Equals(row.Field<string>(PkgColumns.Category), PKGCategory.GAME,
                        StringComparison.OrdinalIgnoreCase))
                    .Select(row => row.Field<string>(PkgColumns.TitleId)?.Trim())
                    .Where(titleId => !string.IsNullOrWhiteSpace(titleId))
                    .Select(titleId => titleId!),
                StringComparer.OrdinalIgnoreCase);

            var patches = table.AsEnumerable()
                .Where(row => string.Equals(row.Field<string>(PkgColumns.Category), PKGCategory.PATCH,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            var missing = patches
                .Select(row => new MissingBasePatch(
                    row.Field<string>(PkgColumns.Filename) ?? "",
                    row.Field<string>(PkgColumns.Title) ?? "",
                    row.Field<string>(PkgColumns.TitleId)?.Trim() ?? "",
                    row.Field<string>(PkgColumns.AppVersion) ?? "",
                    row.Field<string>(PkgColumns.Directory) ?? ""))
                // Do not report a package with no Title ID as a missing base;
                // it cannot be matched reliably and needs separate metadata diagnosis.
                .Where(patch => !string.IsNullOrWhiteSpace(patch.TitleId)
                    && !baseTitleIds.Contains(patch.TitleId))
                .OrderBy(patch => patch.TitleId, StringComparer.OrdinalIgnoreCase)
                .ThenBy(patch => patch.Version, StringComparer.OrdinalIgnoreCase)
                .ToList();

            Logger.LogInformation($"Missing base scan: checked {patches.Count} patch PKG(s), found {missing.Count} without a loaded base game.");
            if (missing.Count == 0)
            {
                ShowInformation($"All {patches.Count} patch PKG(s) have a matching base game PKG loaded.", true);
                return;
            }

            using var results = new MissingBasePkgResultsForm(patches.Count, missing);
            results.ShowDialog(this);
        }

        private void MergeSelectedBaseAndUpdate_Click(object sender, EventArgs e)
        {
            var selected = PKGGridView.SelectedRows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new PkgMergePackage(
                    Path.Combine(row.Cells[PkgColumns.Directory].Value?.ToString() ?? "", row.Cells[PkgColumns.Filename].Value?.ToString() ?? ""),
                    row.Cells[PkgColumns.Title].Value?.ToString() ?? "",
                    row.Cells[PkgColumns.TitleId].Value?.ToString() ?? "",
                    row.Cells[PkgColumns.AppVersion].Value?.ToString() ?? "",
                    row.Cells[PkgColumns.Category].Value?.ToString() ?? ""))
                .ToList();

            if (selected.Count != 2)
            {
                ShowWarning("Select exactly two PKGs: one base Game and one Patch.", true);
                return;
            }

            var basePackages = selected.Where(pkg => string.Equals(pkg.Category, PKGCategory.GAME, StringComparison.OrdinalIgnoreCase)).ToList();
            var patchPackages = selected.Where(pkg => string.Equals(pkg.Category, PKGCategory.PATCH, StringComparison.OrdinalIgnoreCase)).ToList();
            if (basePackages.Count != 1 || patchPackages.Count != 1)
            {
                ShowWarning("Select exactly one base Game PKG and one Patch PKG.", true);
                return;
            }
            var basePkg = basePackages[0];
            var patchPkg = patchPackages[0];
            if (!string.Equals(basePkg.TitleId, patchPkg.TitleId, StringComparison.OrdinalIgnoreCase))
            {
                ShowWarning("The selected base and update have different Title IDs.", true);
                return;
            }
            if (!File.Exists(basePkg.Path) || !File.Exists(patchPkg.Path))
            {
                ShowWarning("One or both selected PKG files no longer exist.", true);
                return;
            }

            using var optionsForm = new PkgMergeOptionsForm(basePkg, patchPkg);
            if (optionsForm.ShowDialog(this) != DialogResult.OK || optionsForm.Options == null) return;
            var options = optionsForm.Options;
            var request = new OrbisPkgTool.PkgMergeRequest
            {
                BasePkgPath = basePkg.Path,
                UpdatePkgPath = patchPkg.Path,
                OutputPkgPath = options.OutputPath,
                WorkDirectory = options.WorkParentDirectory,
                ValidateAfterBuild = options.ValidateAfterBuild,
                WorkerCount = options.WorkerCount,
                PfscMode = OrbisPkgTool.Pkg.PfscMode.Compressed,
                CleanupWorkDirectoryOnFailure = true
            };

            EnqueueMerge(request, $"{basePkg.TitleId} base + {patchPkg.Version}");
            Logger.LogInformation($"PKG merge queued: {basePkg.Path} + {patchPkg.Path}");
        }

        /// <summary>
        /// Context-menu handler: converts one or more selected PS4 PKGs into
        /// independent .ffpfsc images for ShadowMountPlus.
        /// </summary>
        private void ConvertSelectedToFfpfsc_Click(object sender, EventArgs e)
        {
            var selected = PKGGridView.SelectedRows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToList();
            if (selected.Count == 0)
            {
                ShowWarning("Select one or more PKGs to convert to FFPFSC.", true);
                return;
            }

            var sources = selected.Select(row => new
            {
                Path = Path.Combine(row.Cells[PkgColumns.Directory].Value?.ToString() ?? "",
                    row.Cells[PkgColumns.Filename].Value?.ToString() ?? ""),
                Title = row.Cells[PkgColumns.Title].Value?.ToString() ?? "",
                TitleId = row.Cells[PkgColumns.TitleId].Value?.ToString() ?? "",
                Version = row.Cells[PkgColumns.AppVersion].Value?.ToString() ?? ""
            }).ToList();
            if (sources.Any(source => !File.Exists(source.Path)))
            {
                ShowWarning("One or more selected PKG files no longer exist.", true);
                return;
            }

            using var optionsForm = sources.Count == 1
                ? new Forms.Main.FfpfscOptionsForm(sources[0].Path, sources[0].Title, sources[0].TitleId, sources[0].Version)
                : new Forms.Main.FfpfscOptionsForm(sources.Select(source => source.Path).ToList());
            if (optionsForm.ShowDialog(this) != DialogResult.OK || optionsForm.Options == null) return;

            if (sources.Count == 1)
            {
                EnqueueFfpfsc(optionsForm.Options, $"Convert: {Path.GetFileName(sources[0].Path)}");
                Logger.LogInformation($"FFPFSC conversion queued: {sources[0].Path}");
                return;
            }

            var outputPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var source in sources)
            {
                string outputStem = Path.GetFileNameWithoutExtension(source.Path);
                string outputPath = Path.Combine(optionsForm.Options.OutputPath, outputStem + ".ffpfsc");
                int collisionIndex = 2;
                while (!outputPaths.Add(outputPath))
                {
                    string suffix = string.IsNullOrWhiteSpace(source.TitleId)
                        ? collisionIndex.ToString()
                        : source.TitleId + " " + collisionIndex;
                    outputPath = Path.Combine(optionsForm.Options.OutputPath, outputStem + " (" + suffix + ").ffpfsc");
                    collisionIndex++;
                }

                EnqueueFfpfsc(optionsForm.Options with { PkgPath = source.Path, OutputPath = outputPath },
                    $"Convert: {Path.GetFileName(source.Path)}");
                Logger.LogInformation($"FFPFSC conversion queued: {source.Path}");
            }
        }

        private void ExtractSelectedFullPkg_Click(object sender, EventArgs e)
        {
            var sources = PKGGridView.SelectedRows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => Path.Combine(row.Cells[PkgColumns.Directory].Value?.ToString() ?? "",
                    row.Cells[PkgColumns.Filename].Value?.ToString() ?? ""))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            if (sources.Count == 0)
            {
                ShowWarning("Select one or more PKGs to extract.", true);
                return;
            }
            if (sources.Any(path => !File.Exists(path)))
            {
                ShowWarning("One or more selected PKG files no longer exist.", true);
                return;
            }
            if (!ShowFolderBrowserDialog(out FolderBrowserDialog folder)) return;

            var outputDirectories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string pkgPath in sources)
            {
                string outputStem = PkgExtractionService.SanitizeFolderName(Path.GetFileNameWithoutExtension(pkgPath));
                string outputDirectory = Path.Combine(folder.SelectedPath, outputStem);
                int collisionIndex = 2;
                while (!outputDirectories.Add(outputDirectory))
                {
                    outputDirectory = Path.Combine(folder.SelectedPath, outputStem + " (" + collisionIndex + ")");
                    collisionIndex++;
                }

                EnqueueFullExtraction(pkgPath, outputDirectory);
                Logger.LogInformation($"Full extraction queued: {pkgPath} -> {outputDirectory}");
            }
        }


        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
                {
                    List<string> nodeList = new List<string>();
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        if (item.Tag is TreeNodeInfo info && info.Path != "...")
                        {
                            string path = info.Node != null ? NodeLogicalPath(info.Node) : info.Path;
                            bool isDir = info.Node != null && info.Node.Nodes.Count > 0;
                            nodeList.Add(isDir ? path + "/" : path);
                        }
                    }

                    if (nodeList.Count > 0)
                    {
                        string extractLocation = fbd.SelectedPath;
                        ExtractSelectedPKGData(nodeList, extractLocation);
                    }
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);

                // Check if the clicked item is not null and its text value is not "..."
                if (clickedItem != null && clickedItem.Text != "...")
                {
                    contextMenuExtractListView.Show(listView1, e.Location);
                }
            }
        }

        private void ViewUpdateChangelog()
        {
            string origPath = PKG.SelectedPKGFilename;
            try
            {
                // In-process extraction of Sc0/changeinfo/changeinfo.xml. The
                // PKG is opened read-only - no spawn, no ASCII staging.
                byte[] changeInfoBytes;
                using (var reader = new OrbisPkgTool.PkgReader(origPath, DefaultOrbisPasscode))
                {
                    changeInfoBytes = reader.ExtractEntryBytes("Sc0/changeinfo/changeinfo.xml");
                }
                File.WriteAllBytes(AppDataDirectory + "changeinfo.xml", changeInfoBytes);
            }
            catch (FileNotFoundException)
            {
                ShowInformation("Change info not available.", true);
            }
            catch (Exception ex)
            {
                ShowError("An error occurred while viewing the update changelog: " + ex.Message, true);
            }
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            OpenProgramSettings();
        }

        private void ViewPatchChangelog_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Viewing patch PKG changelog..");

            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == viewPkgChangeInfotoolStripMenuItem1 || clickedMenuItem == viewPkgChangeInfotoolStripMenuItem2)
            {
                ViewUpdateChangelog();

                string changeInfoFile = AppDataDirectory + "changeinfo.xml";
                if (File.Exists(changeInfoFile))
                {
                    try
                    {
                        string changeInfoData = File.ReadAllText(changeInfoFile);
                        File.Delete(changeInfoFile);
                        using (PKGChangeInfoViewer updateChangelog = new PKGChangeInfoViewer(changeInfoData))
                        {
                            updateChangelog.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("An error occurred while viewing the update changelog: " + ex.Message, true);
                    }
                }
            }
        }

        private TreeNode SearchFileInTreeView(string p_sSearchTerm, TreeNodeCollection p_Nodes)
        {
            foreach (TreeNode node in p_Nodes)
            {
                if (node.Name == p_sSearchTerm) // Use the 'Name' property for comparison
                    return node;

                if (node.Nodes.Count > 0)
                {
                    TreeNode child = SearchFileInTreeView(p_sSearchTerm, node.Nodes);
                    if (child != null)
                        return child;
                }
            }

            return null;
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PKGTreeView.ExpandAll();
        }

      
        private void collapseAllNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PKGTreeView.CollapseAll();
        }

        private void CtxExpandNode_Click(object sender, EventArgs e)
        {
            if (PKGTreeView.SelectedNode != null)
                PKGTreeView.SelectedNode.Expand();
        }

        private void CtxCollapseNode_Click(object sender, EventArgs e)
        {
            if (PKGTreeView.SelectedNode != null)
                PKGTreeView.SelectedNode.Collapse();
        }

        private void CtxExtractFolder_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                List<string> nodeList = new List<string>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    if (item.Text == "...") continue;
                    if (item.Tag is not TreeNodeInfo info || info.Node == null) continue;
                    bool isDir = info.Node.Nodes.Count > 0;
                    nodeList.Add(isDir ? NodeLogicalPath(info.Node) + "/" : NodeLogicalPath(info.Node));
                }
                ExtractSelectedPKGData(nodeList, fbd.SelectedPath, preserveStructure: true);
            }
        }

        private void CtxCopyPath_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var paths = listView1.SelectedItems.Cast<ListViewItem>()
                .Select(i => ((TreeNodeInfo)i.Tag).Path).Where(p => p != "...");
            Clipboard.SetText(string.Join(Environment.NewLine, paths));
        }

        private void CtxCopyName_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var names = listView1.SelectedItems.Cast<ListViewItem>()
                .Select(i => i.Text).Where(n => n != "...");
            Clipboard.SetText(string.Join(Environment.NewLine, names));
        }

        private void RenamePKG(string namingFormat, List<string> pkgList)
        {
            if (Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A shadPS4 installation is in progress.", false);
                return;
            }

            var bg = new BackgroundWorker();
            bg.DoWork += delegate
            {
                int countPkg = 0;
                int lastInvoked = 0;
                this.Invoke((Action)(() => this.Enabled = false));
                PKG.pkgCount = 0;
                this.Invoke((Action)(() => toolStripProgressBar1.Maximum = pkgList.Count));
                PKG.CountFailRename = 0;
                PKG.ListFailRename = "";
                Logger.LogInformation($"Rename: {pkgList.Count} PKG(s) to {namingFormat} format");
                Logger.LogInformation($"Renaming PKG file to {namingFormat} format..");
                foreach (var pkg in pkgList)
                {
                    string targetPkgName = null;
                    try
                    {
                        string destinationFolder = Path.GetDirectoryName(pkg) + @"\";
                        string newPkgName = "";
                        string sourcePkg = "";
                        string targetPkg = "";
                        (newPkgName, sourcePkg, targetPkg) = PS4PKGTool.Utilities.PkgRename.PkgRenameService.GetNewPKGName(pkg, destinationFolder, namingFormat);
                        targetPkgName = Path.GetFileName(targetPkg);
                        UpdatePKGFilename(newPkgName, sourcePkg, targetPkg);
                        countPkg++;

                        if (countPkg % 10 == 0 || countPkg == pkgList.Count)
                        {
                            var current = countPkg;
                            var increment = countPkg - lastInvoked;
                            lastInvoked = countPkg;
                            PKGGridView.Invoke((Action)(() =>
                            {
                                toolStripStatusLabel2.Text = $"Renaming PKG.. ({current}/{pkgList.Count})";
                                toolStripProgressBar1.Increment(increment);
                            }));
                        }
                    }
                    catch (Exception a)
                    {
                        PKG.CountFailRename++;
                        PKG.ListFailRename += $"{Path.GetFileName(pkg)} → {targetPkgName ?? "?"} : {a.Message}\n";
                    }
                }
            };
            bg.RunWorkerCompleted += delegate
            {
                try
                {
                    if (PKG.CountFailRename > 0)
                    {
                        Logger.LogInformation($"Rename completed with {PKG.CountFailRename} failure(s).");
                        ShowWarning(PKG.CountFailRename + " PKG failed to rename. See program log to view the errors.", false);
                        Logger.LogWarning(PKG.CountFailRename + " PKG failed to rename:");
                        Logger.LogWarning(PKG.ListFailRename);
                    }
                    else
                    {
                        Logger.LogInformation("Rename completed successfully.");
                        ShowInformation("PKG rename done.", true);
                    }

                    SaveManifestAfterScan();
                    // GLV cells are updated in-place by UpdatePKGFilename -
                    // no full rebuild needed, selection and group state are preserved.
                }
                catch (Exception ex)
                {
                    Logger.LogError("Rename completion failed: " + ex.Message);
                }
                finally
                {
                    PKGGridView.Invoke((Action)(() =>
                    {
                        toolStripStatusLabel2.Text = "...";
                        toolStripProgressBar1.Value = 0;
                        this.Enabled = true;
                    }));
                    SetOperationMenusEnabled(true); // never leave the GLV context menu disabled
                }
            };
            bg.RunWorkerAsync();
        }

        /// <summary>
        /// Determines install-priority order for a PKG type string.
        /// Game (Base) -> Patch (Update) -> Addon -> App -> Other.
        /// </summary>
        private static int GetCategoryPriority(string pkgType)
        {
            return pkgType switch
            {
                "Game" => 0,
                "Patch" => 1,
                _ => 99
            };
        }

        /// <summary>
        /// Renames PKGs grouped by Title ID with sequence prefixes so that
        /// alphabetical sort matches the correct install priority:
        /// Base game -> Updates (sorted by version) -> Addons/DLC.
        /// </summary>
        private void RenamePKGByPriority(List<string> pkgList, BackgroundWorker progressWorker = null)
        {
            Logger.LogInformation($"Rename by priority started: {pkgList.Count} file(s)");
            PKG.CountFailRename = 0;
            PKG.ListFailRename = "";
            int totalRenamed = 0;
            int total = pkgList.Count;
            int processed = 0;

            // Group PKGs by Title ID so we can order each game's files together
            var groups = new Dictionary<string, List<(string path, string title, string appVer, string pkgType)>>(
                StringComparer.OrdinalIgnoreCase);

            foreach (var pkg in pkgList)
            {
                processed++;
                progressWorker?.ReportProgress((int)(100.0 * processed / total), $"Reading PKG {processed}/{total}...");
                try
                {
                    var readPkg = PkgMetadataReader.ReadMetadataOnly(pkg);
                    string pkgType = readPkg.PKG_Type.ToString();
                    if (pkgType != "Game" && pkgType != "Patch")
                    {
                        Logger.LogInformation($"Priority rename: skipping {Path.GetFileName(pkg)} ({pkgType}).");
                        continue;
                    }
                    string titleId = readPkg.TITLEID;
                    if (string.IsNullOrEmpty(titleId))
                    {
                        titleId = "UNKNOWN_TITLEID";
                        Logger.LogWarning($"PKG has no Title ID, using '{titleId}': {Path.GetFileName(pkg)}");
                    }

                    if (!groups.ContainsKey(titleId))
                        groups[titleId] = new List<(string, string, string, string)>();

                    groups[titleId].Add((pkg, readPkg.PS4_Title, readPkg.APP_VER, readPkg.PKG_Type.ToString()));
                }
                catch (Exception ex)
                {
                    PKG.CountFailRename++;
                    PKG.ListFailRename += Path.GetFileName(pkg) + " : " + ex.Message + "\n";
                    Logger.LogError($"Failed to read PKG for priority rename: {pkg}: {ex.Message}");
                }
            }

            // Process each group sorted by install priority
            int renameDone = 0;
            foreach (var kvp in groups)
            {
                var sorted = kvp.Value
                    .OrderBy(x => GetCategoryPriority(x.pkgType))
                    .ThenBy(x => GlvAppVersionRank(x.appVer))
                    .ToList();

                for (int i = 0; i < sorted.Count; i++)
                {
                    var (path, title, appVer, pkgType) = sorted[i];
                    renameDone++;
                    progressWorker?.ReportProgress((int)(100.0 * renameDone / total), $"Renaming {renameDone}/{total}...");

                    string targetPkg = null;
                    try
                    {
                        string tag = pkgType == "Game" ? "Base" : "Update";
                        string seq = $"{i:D2}";
                        string sanitizedTitle = title.SanitizeFileName();
                        string newName = $"{sanitizedTitle} [{kvp.Key}] {seq} - {tag}";

                        // Append version number for patches/updates
                        if (pkgType == "Patch" && !string.IsNullOrEmpty(appVer) && appVer != "0")
                            newName += $" v{appVer}";

                        newName += ".pkg";

                        string dir = Path.GetDirectoryName(path);
                        targetPkg = Path.Combine(dir, newName);

                        if (string.Equals(path, targetPkg, StringComparison.OrdinalIgnoreCase))
                            continue; // already has this name

                        UpdatePKGFilename(Path.GetFileNameWithoutExtension(newName), path, targetPkg);
                        totalRenamed++;
                    }
                    catch (Exception ex)
                    {
                        PKG.CountFailRename++;
                        string targetName = targetPkg == null ? "?" : Path.GetFileName(targetPkg);
                        PKG.ListFailRename += $"{Path.GetFileName(path)} → {targetName} : {ex.Message}\n";
                        Logger.LogError($"Failed to rename by priority: {path}: {ex.Message}");
                    }
                }
            }

            if (PKG.CountFailRename > 0)
                Logger.LogWarning($"Priority rename completed with {PKG.CountFailRename} failure(s):\n{PKG.ListFailRename}");
            else
                Logger.LogInformation($"Priority rename completed: {totalRenamed} PKG(s) renamed.");
        }

        private void GetSelectedPKGPath()
        {
            try
            {
                foreach (DataGridViewCell cell in PKGGridView.SelectedCells)
                {
                    int selectedRowIndex = cell.RowIndex;
                    if (selectedRowIndex < 0 || selectedRowIndex >= PKGGridView.Rows.Count) continue;
                    DataGridViewRow selectedRow = PKGGridView.Rows[selectedRowIndex];
                    if (selectedRow.Cells[0].Value == null || selectedRow.Cells[13].Value == null) continue;
                    PKG.SelectedPKGFilename = $"{selectedRow.Cells[13].Value}\\{selectedRow.Cells[0].Value}";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error getting PKG path: {ex.Message}");
            }
        }

        private void SelectFirstRowPkg()
        {
            try
            {
                if (PKGGridView.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = PKGGridView.Rows[0];
                    if (firstRow.Cells[0].Value != null && firstRow.Cells[13].Value != null)
                    {
                        string valueColumn0 = firstRow.Cells[0].Value.ToString();
                        string valueColumn12 = firstRow.Cells[13].Value.ToString();
                        PKG.SelectedPKGFilename = Path.Combine(valueColumn12, valueColumn0);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error selecting first row: {ex.Message}");
            }
        }

        private struct PkgMoveInfo
        {
            public string FilePath;
            public string FileName;
            public string Title;
            public string TitleId;
            public string Category;
            public string PkgState;
            public string Region;
        }

        private static PkgMoveInfo GetPkgMoveInfo(DataGridViewRow row)
        {
            var info = new PkgMoveInfo();
            info.FileName = row.Cells[0].Value?.ToString() ?? "";
            info.Title = row.Cells[1].Value?.ToString() ?? "";
            info.TitleId = row.Cells[2].Value?.ToString() ?? "";
            info.Region = GetRegionString(((DataRowView)row.DataBoundItem).Row);
            info.PkgState = row.Cells[7].Value?.ToString() ?? "";
            info.Category = row.Cells[8].Value?.ToString() ?? "";
            string dir = row.Cells[13].Value?.ToString() ?? "";
            info.FilePath = Path.Combine(dir, info.FileName);
            return info;
        }

        private void MovePkg_Click(object sender, EventArgs e)
        {
            if (Shadps4Manager.IsInstallationActive)
            {
                ShowWarning("A shadPS4 installation is in progress.", false);
                return;
            }
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            string moveBy;
            if (clickedMenuItem == movePkgTypeToolStripMenuItem1 || clickedMenuItem == movePkgTypeToolStripMenuItem2)
                moveBy = "Type";
            else if (clickedMenuItem == movePkgCategoryToolStripMenuItem1 || clickedMenuItem == movePkgCategoryToolStripMenuItem2)
                moveBy = "Category";
            else if (clickedMenuItem == movePkgRegionToolStripMenuItem1 || clickedMenuItem == movePkgRegionToolStripMenuItem2)
                moveBy = "Region";
            else if (clickedMenuItem == movePkgTitleToolStripMenuItem1 || clickedMenuItem == movePkgTitleToolStripMenuItem2)
                moveBy = "Title";
            else if (clickedMenuItem == movePkgSingleFolderToolStripMenuItem1 || clickedMenuItem == movePkgSingleFolderToolStripMenuItem2)
                moveBy = "flat";
            else if (clickedMenuItem == moveByPkgTitleIdToolStripMenuItem)
                moveBy = "Title Id";
            else
                return;

            int total = PKGGridView.Rows.Count;
            if (total == 0)
            {
                ShowError("No PKG files to move.", false);
                return;
            }

            if (!ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
                return;

            string confirmMessage = moveBy == "flat"
    ? $"Move {total} PKG(s) directly into:\n\n{fbd.SelectedPath}\n\nNo subfolders will be created.\n\nProceed?"
    : moveBy == "Title"
        ? $"Move {total} PKG(s) into subfolders under:\n\n{fbd.SelectedPath}\n\nGrouped by: {moveBy}\n\nA combined \"Base + Update\" main folder (grouped by title) and an \"Addon\" main folder (grouped by Title ID) are created.\n\nProceed?"
        : $"Move {total} PKG(s) into subfolders under:\n\n{fbd.SelectedPath}\n\nGrouped by: {moveBy}\n\nProceed?";
            var result = DialogResultYesNo(confirmMessage);
            if (result != DialogResult.Yes)
                return;

            MovePKG(moveBy, fbd.SelectedPath);
        }

        private void MovePKG(string moveBy, string outputFolder)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += delegate
            {
                this.Invoke((MethodInvoker)delegate { this.Enabled = false; });
                PKG.pkgCount = 0;
                PKG.CountFailMove = 0;
                PKG.ListFailMove = "";
                int total = 0;
                this.Invoke((MethodInvoker)delegate
                {
                    total = PKGGridView.Rows.Count;
                    toolStripProgressBar1.Maximum = total;
                });
                Logger.LogInformation($"Move PKG by {moveBy}: {total} PKG(s) → {outputFolder}");

                for (int i = 0; i < total; i++)
                {
                    try
                    {
                        PKG.pkgCount++;
                        this.Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabel2.Text = $"Moving PKG.. ({PKG.pkgCount}/{total})";
                            toolStripProgressBar1.Increment(1);
                        });

                        // Row data must be read on the UI thread (grid access).
                        var info = new PkgMoveInfo();
                        bool hasFilename = false;
                        PKGGridView.Invoke((Action)(() =>
                        {
                            var row = PKGGridView.Rows[i];
                            hasFilename = row.Cells[0].Value != null;
                            if (hasFilename)
                                info = GetPkgMoveInfo(row);
                        }));
                        if (!hasFilename) continue;

                        string dest = null;

                        switch (moveBy.ToLowerInvariant())
                        {
                            case "category":
                                dest = GetCategoryDest(info, outputFolder);
                                break;
                            case "type":
                                dest = GetTypeDest(info, outputFolder);
                                break;
                            case "region":
                                dest = GetRegionDest(info, outputFolder);
                                break;
                            case "title":
                                dest = GetTitleDest(info, outputFolder);
                                break;
                            case "title id":
                                dest = Path.Combine(outputFolder, info.TitleId);
                                break;
                            case "flat":
                                dest = outputFolder;
                                break;
                        }

                        if (string.IsNullOrEmpty(dest))
                        {
                            PKG.CountFailMove++;
                            string reason = moveBy == "region" ? $"Unknown region: {info.Region}" : $"Unknown {moveBy}";
                            Logger.LogWarning($"Move skipped: {info.FileName} - {reason}");
                            PKG.ListFailMove += $"{info.FileName} : {reason}\n";
                            continue;
                        }

                        Logger.LogInformation($"  {info.FileName} → {dest}");
                        Tool.CreateDirectoryIfNotExists(dest);
                        string newPath = Path.Combine(dest, info.FileName);
                        File.Move(info.FilePath, newPath);
                    }
                    catch (Exception ex)
                    {
                        PKG.CountFailMove++;
                        string name = "";
                        try
                        {
                            int rowIndex = i;
                            PKGGridView.Invoke((Action)(() =>
                            {
                                name = Path.GetFileNameWithoutExtension(PKGGridView.Rows[rowIndex].Cells[0].Value?.ToString() ?? "");
                            }));
                        }
                        catch { /* best-effort: grid may not be accessible */ }
                        Logger.LogError($"Move failed: {name} - {ex.Message}");
                        PKG.ListFailMove += $"{name} : {ex.Message}\n";
                    }
                }
            };

            backgroundWorker.RunWorkerCompleted += delegate
            {
                if (PKG.CountFailMove > 0)
                {
                    Logger.LogWarning($"Move completed with {PKG.CountFailMove} failure(s):");
                    Logger.LogWarning(PKG.ListFailMove);
                    ShowWarning($"{PKG.CountFailMove} PKG failed to move. See program log for details.", false);
                }
                else
                {
                    Logger.LogInformation("Move completed successfully.");
                    ShowInformation("PKG moved to new directories. The destination was not added to saved directories.", true);
                }

                toolStripStatusLabel2.Text = "Refreshing PKG list.. ";
                LoadPKGGridView();
            };

            backgroundWorker.RunWorkerAsync();
        }

        private static string GetCategoryDest(PkgMoveInfo info, string outputFolder)
        {
            switch (info.Category)
            {
                case PKGCategory.GAME: return Path.Combine(outputFolder, "GAME");
                case PKGCategory.PATCH: return Path.Combine(outputFolder, "PATCH");
                case PKGCategory.ADDON: return Path.Combine(outputFolder, "ADDON");
                case PKGCategory.APP: return Path.Combine(outputFolder, "APP");
                default: return null;
            }
        }

        private static string GetTypeDest(PkgMoveInfo info, string outputFolder)
        {
            switch (info.PkgState)
            {
                case "Official": return Path.Combine(outputFolder, "OFFICIAL");
                case "Fake": return Path.Combine(outputFolder, "FAKE");
                case "Addon_Unlocker": return Path.Combine(outputFolder, "ADDON UNLOCKER");
                default: return null;
            }
        }

        private static string GetRegionDest(PkgMoveInfo info, string outputFolder)
        {
            var regionFolders = new Dictionary<string, string>
            {
                { PKGRegion.EU, "EU" },
                { PKGRegion.US, "US" },
                { PKGRegion.JAPAN, "JAPAN" },
                { PKGRegion.HONG_KONG, "HONG KONG" },
                { PKGRegion.ASIA, "ASIA" },
                { PKGRegion.KOREA, "KOREA" }
            };

            if (regionFolders.TryGetValue(info.Region, out string folder))
                return Path.Combine(outputFolder, folder);

            Logger.LogWarning($"Unknown region '{info.Region}' - moving to OTHER");
            return Path.Combine(outputFolder, "OTHER");
        }

        private string GetTitleDest(PkgMoveInfo info, string outputFolder)
        {
            // Games and patches share one main folder (grouped by title inside it);
            // add-ons get their own main folder grouped by Title ID - their only reliable
            // attribute (titles are often repacked/unreliable).
            // Original filenames are preserved, so files never collide within a folder.
            string mainFolder;
            switch (info.Category)
            {
                case PKGCategory.GAME:
                case PKGCategory.PATCH:
                    mainFolder = "Base + Update";
                    break;
                case PKGCategory.ADDON:
                    mainFolder = "Addon";
                    break;
                case PKGCategory.APP:
                    mainFolder = "App";
                    break;
                default: return null; // unknown category - skip
            }

            if (info.Category == PKGCategory.ADDON)
                return Path.Combine(outputFolder, mainFolder, string.IsNullOrEmpty(info.TitleId) ? "UNKNOWN_TITLEID" : info.TitleId);

            string safeTitle = info.Title.SanitizeFileName();
            if (string.IsNullOrEmpty(safeTitle))
                safeTitle = string.IsNullOrEmpty(info.TitleId) ? "UNKNOWN_TITLEID" : info.TitleId;
            return Path.Combine(outputFolder, mainFolder, safeTitle);
        }

        private void PKGListGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // shadPS4 column: colored compatibility status plus the local library marker.
            if (e.RowIndex >= 0 && e.RowIndex < PKGGridView.Rows.Count
                && PKGGridView.Columns[e.ColumnIndex].Name == PkgColumns.Shadps4)
            {
                string status = e.Value?.ToString() ?? "";
                bool installed = PKGGridView.Rows[e.RowIndex].Cells[PkgColumns.Shadps4Installed].Value is true;
                e.Value = string.IsNullOrWhiteSpace(status)
                    ? (installed ? "[Installed]" : "")
                    : "● " + status + (installed ? " [Installed]" : "");
                e.CellStyle.ForeColor = string.IsNullOrWhiteSpace(status)
                    ? Color.FromArgb(113, 190, 84)
                    : Shadps4Compat.StatusColor(status);
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                return;
            }

            // Apply color label to this specific row only (not the entire grid)
            if (appSettings_.PkgColorLabel && e.RowIndex >= 0 && e.RowIndex < PKGGridView.Rows.Count)
            {
                var row = PKGGridView.Rows[e.RowIndex];
                if (row.Cells[8].Value == null) return;
                string category = row.Cells[8].Value.ToString();
                Color fore, back;
                switch (category)
                {
                    case PKGCategory.PATCH:
                        fore = appSettings_.PatchPkgForeColor;
                        back = appSettings_.PatchPkgBackColor;
                        break;
                    case PKGCategory.GAME:
                        fore = appSettings_.GamePkgForeColor;
                        back = appSettings_.GamePkgBackColor;
                        break;
                    case PKGCategory.ADDON:
                        fore = appSettings_.AddonPkgForeColor;
                        back = appSettings_.AddonPkgBackColor;
                        break;
                    case PKGCategory.APP:
                        fore = appSettings_.AppPkgForeColor;
                        back = appSettings_.AppPkgBackColor;
                        break;
                    default:
                        return;
                }
                e.CellStyle.ForeColor = fore;
                e.CellStyle.BackColor = back;
            }
        }

        private void UpdatePKGColorLabel()
        {
            if (appSettings_.PkgColorLabel)
            {
                foreach (DataGridViewRow row in PKGGridView.Rows)
                {
                    if (row.IsNewRow || row.Cells[8].Value == null) continue;
                    string category = row.Cells[8].Value.ToString();

                    switch (category)
                    {
                        case PKGCategory.PATCH:
                            row.DefaultCellStyle.ForeColor = appSettings_.PatchPkgForeColor;
                            row.DefaultCellStyle.BackColor = appSettings_.PatchPkgBackColor;
                            break;
                        case PKGCategory.GAME:
                            row.DefaultCellStyle.ForeColor = appSettings_.GamePkgForeColor;
                            row.DefaultCellStyle.BackColor = appSettings_.GamePkgBackColor;
                            break;
                        case PKGCategory.ADDON:
                            row.DefaultCellStyle.ForeColor = appSettings_.AddonPkgForeColor;
                            row.DefaultCellStyle.BackColor = appSettings_.AddonPkgBackColor;
                            break;
                        case PKGCategory.APP:
                            row.DefaultCellStyle.ForeColor = appSettings_.AppPkgForeColor;
                            row.DefaultCellStyle.BackColor = appSettings_.AppPkgBackColor;
                            break;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in PKGGridView.Rows)
                {
                    var isOdd = (row.Index % 2 != 0);
                    row.DefaultCellStyle = GetCellStyle(isFocused: false, isOdd, isHeader: false);
                }
            }

            // Row styles override the DarkDataGridView defaults, so their
            // selection colors must follow a live theme change as well.
            foreach (DataGridViewRow row in PKGGridView.Rows)
            {
                if (row.IsNewRow) continue;
                row.DefaultCellStyle.SelectionBackColor = Colors.BlueSelection;
                row.DefaultCellStyle.SelectionForeColor = Colors.LightText;
            }
        }

        /// <summary>
        /// The main package grid owns row-level styles for alternating rows and
        /// optional category labels. Reapply only those visuals when a theme is
        /// selected, without reloading, sorting, or changing the selection.
        /// </summary>
        private void Main_ThemeChanged(object sender, EventArgs e)
        {
            if (IsDisposed || Disposing || !IsHandleCreated)
                return;

            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)(() => Main_ThemeChanged(sender, e)));
                return;
            }

            UpdatePKGColorLabel();
            PKGGridView.Invalidate();
        }

        private static DataGridViewCellStyle GetCellStyle(bool isFocused, bool isOdd, bool isHeader)
        {
            return new DataGridViewCellStyle
            {
                BackColor = (isHeader ? Colors.DarkBackground : (isOdd ? Colors.GreyBackground : Colors.HeaderBackground)),
                ForeColor = Colors.LightText,
                SelectionBackColor = ((isFocused && isHeader) ? Colors.DarkBackground : Colors.BlueSelection),
                SelectionForeColor = Colors.LightText
            };
        }

        private void PKGListGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (PKGGridView.DataSource is not DataTable dataTable) return;
                if (e.ColumnIndex < 0 || e.ColumnIndex >= PKGGridView.Columns.Count) return;
                var selectedPaths = PKGGridView.SelectedRows.Cast<DataGridViewRow>()
                    .Where(row => !row.IsNewRow)
                    .Select(GetGridRowPkgPath)
                    .ToList();

                string colName = PKGGridView.Columns[e.ColumnIndex].Name;
                if (string.IsNullOrEmpty(colName)) return;

                // Region column (byte[]) needs special handling
                if (colName == "Region")
                {
                    PKGGridView.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Automatic;
                    return;
                }

                // Size / Required Firmware / Version - numerical sort
                // Title ID - alphanumeric (CUSA00010 after CUSA00002)
                // ShadPS4 - semantic rank (Playable > In-Game > Menus > Boots > Nothing > unknown)
                if (colName == PkgColumns.Size || colName == PkgColumns.SystemVersion || colName == PkgColumns.AppVersion
                    || colName == PkgColumns.TitleId || colName == PkgColumns.Shadps4)
                {
                    SortOrder numPrev = _colSortDir.GetValueOrDefault(colName, SortOrder.None);
                    SortOrder numNext = numPrev == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                    _colSortDir[colName] = numNext;
                    Func<DataRow, double> key = colName switch
                    {
                        PkgColumns.Size => r => ParseSizeToBytes(r[PkgColumns.Size]?.ToString()),
                        PkgColumns.SystemVersion => r => ParseVersion(r[PkgColumns.SystemVersion]?.ToString() ?? ""),
                        PkgColumns.Shadps4 => r => Shadps4Compat.StatusRank(r[PkgColumns.Shadps4]?.ToString() ?? ""),
                        _ => r => ParseAppVersion(r[PkgColumns.AppVersion]?.ToString() ?? "")
                    };
                    var sorted = dataTable.Rows.Cast<DataRow>().ToList();
                    if (colName == PkgColumns.TitleId)
                        sorted.Sort((a, b) => NaturalCompare(
                            a[PkgColumns.TitleId]?.ToString() ?? "", b[PkgColumns.TitleId]?.ToString() ?? ""));
                    else
                        sorted = sorted.OrderBy(r => key(r)).ToList();
                    if (numNext == SortOrder.Descending) sorted.Reverse();
                    var newTable = dataTable.Clone();
                    foreach (var r in sorted) newTable.Rows.Add(r.ItemArray);
                    PKGGridView.DataSource = newTable;
                    ScrollToTop();
                    UpdateDataGridViewColumnVisibility();
                    ApplyFilters();
                    SelectGridRowsForPaths(selectedPaths);
                    PKGGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = numNext;
                    return;
                }

                // All other columns: alphabetical sort with explicit DataSource swap
                SortOrder prev = _colSortDir.GetValueOrDefault(colName, SortOrder.None);
                SortOrder next = prev == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                _colSortDir[colName] = next;

                var sortedRows = dataTable.Rows.Cast<DataRow>()
                    .OrderBy(r => r[colName]?.ToString() ?? "", StringComparer.OrdinalIgnoreCase)
                    .ToList();
                if (next == SortOrder.Descending) sortedRows.Reverse();
                var sortedTable = dataTable.Clone();
                foreach (var r in sortedRows) sortedTable.Rows.Add(r.ItemArray);
                PKGGridView.DataSource = sortedTable;
                ScrollToTop();
                UpdateDataGridViewColumnVisibility();
                ApplyFilters();
                SelectGridRowsForPaths(selectedPaths);
                PKGGridView.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = next;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error sorting column: {ex.Message}");
                ShowError($"Error sorting column: {ex.Message}", true);
            }
        }

        private void ScrollToTop()
        {
            if (PKGGridView.Rows.Count > 0)
            {
                PKGGridView.Rows[0].Selected = true;
                PKGGridView.CurrentCell = PKGGridView.Rows[0].Cells[0];
                try { PKGGridView.FirstDisplayedScrollingRowIndex = 0; } catch (Exception ex) { Logger.LogWarning("Failed to scroll grid to top: " + ex.Message); }
            }
        }

        private static int NaturalCompare(string a, string b)
        {
            // Alphanumeric: split into text/number chunks, compare segment by segment
            if (a == null) a = ""; if (b == null) b = "";
            int ia = 0, ib = 0;
            while (ia < a.Length && ib < b.Length)
            {
                if (char.IsDigit(a[ia]) && char.IsDigit(b[ib]))
                {
                    // Extract numeric chunks
                    long na = 0, nb = 0;
                    while (ia < a.Length && char.IsDigit(a[ia])) { na = na * 10 + (a[ia] - '0'); ia++; }
                    while (ib < b.Length && char.IsDigit(b[ib])) { nb = nb * 10 + (b[ib] - '0'); ib++; }
                    if (na != nb) return na.CompareTo(nb);
                }
                else
                {
                    if (a[ia] != b[ib]) return a[ia].CompareTo(b[ib]);
                    ia++; ib++;
                }
            }
            return a.Length.CompareTo(b.Length);
        }

        private static double ParseVersion(string ver)
        {
            // "4.50" -> 4.5, "11.00" -> 11.0
            if (string.IsNullOrEmpty(ver) || ver == "NA") return -1;
            if (double.TryParse(ver, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double v)) return v;
            return -1;
        }

        private static double ParseAppVersion(string ver)
        {
            // "1.00 [1.00]" -> extract first number, or "NA" -> -1
            if (string.IsNullOrEmpty(ver) || ver == "NA") return -1;
            int space = ver.IndexOf(' ');
            string num = space > 0 ? ver.Substring(0, space) : ver;
            if (double.TryParse(num, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double v)) return v;
            return -1;
        }

        private static long ParseSizeToBytes(string sizeStr)
        {
            if (string.IsNullOrEmpty(sizeStr)) return 0;
            try
            {
                var parts = sizeStr.Split(' ');
                if (parts.Length != 2) return 0;
                double val = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                string unit = parts[1].ToUpperInvariant();
                return unit switch
                {
                    "B" or "BYTES" => (long)val,
                    "KB" => (long)(val * 1024),
                    "MB" => (long)(val * 1024 * 1024),
                    "GB" => (long)(val * 1024 * 1024 * 1024),
                    "TB" => (long)(val * 1024L * 1024 * 1024 * 1024),
                    _ => 0
                };
            }
            catch (Exception ex) { Logger.LogWarning("Error parsing size string '" + sizeStr + "': " + ex.Message); return 0; }
        }

        private void btnExtractFullPKG_Click(object sender, EventArgs e)
        {
            string pkgPath = PKG.SelectedPKGFilename;
            if (string.IsNullOrWhiteSpace(pkgPath) || !File.Exists(pkgPath))
            {
                ShowWarning("Select a PKG before adding a full extraction task.", false);
                return;
            }
            if (!ShowFolderBrowserDialog(out FolderBrowserDialog folder)) return;
            string outputDirectory = Path.Combine(folder.SelectedPath, Path.GetFileNameWithoutExtension(pkgPath));
            EnqueueFullExtraction(pkgPath, outputDirectory);
            Logger.LogInformation($"Full extraction queued: {pkgPath} -> {outputDirectory}");
        }

        /// <summary>
        /// Generate and return datatable of selected/all PKG from gridview
        /// </summary>
        /// <param name="pKGSelectionType"></param>
        /// <returns></returns>
        private DataTable GenerateDatatableFromSelectedPKG(string pKGSelectionType)
        {
            // Create a new DataTable
            DataTable selectedPKGDatatable = new DataTable();

            // Add columns to the DataTable
            foreach (DataGridViewColumn column in PKGGridView.Columns)
            {
                selectedPKGDatatable.Columns.Add(column.HeaderText);
            }

            // Find Region column by name (not hardcoded index)
            int regionColIdx = -1;
            foreach (DataGridViewColumn col in PKGGridView.Columns)
                if (col.Name == "Region") { regionColIdx = col.Index; break; }

            if (pKGSelectionType == PKGSelectionType.ALL)
            {
                foreach (DataGridViewRow row in PKGGridView.Rows)
                {
                    DataRow dataRow = selectedPKGDatatable.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        var cell = row.Cells[i];
                        if (i == regionColIdx && cell.Value is byte[] icon)
                            dataRow[i] = ConvertImageToRegion(icon);
                        else if (cell.Value is byte[])
                            dataRow[i] = "";
                        else
                            dataRow[i] = cell.Value;
                    }
                    selectedPKGDatatable.Rows.Add(dataRow);
                }
            }
            else
            {
                foreach (DataGridViewRow row in PKGGridView.SelectedRows)
                {
                    DataRow dataRow = selectedPKGDatatable.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        var cell = row.Cells[i];
                        if (i == regionColIdx && cell.Value is byte[] icon)
                            dataRow[i] = ConvertImageToRegion(icon);
                        else if (cell.Value is byte[])
                            dataRow[i] = "";
                        else
                            dataRow[i] = cell.Value;
                    }
                    selectedPKGDatatable.Rows.Add(dataRow);
                }
            }

            return selectedPKGDatatable;
        }

        public static string ConvertImageToRegion(byte[] regionIcon)
        {
            var imageConverter = new ImageConverter();

            Dictionary<byte[], string> regionMapping = new Dictionary<byte[], string>
    {
        { (byte[])imageConverter.ConvertTo(Properties.Resources.eu, typeof(byte[])), PKGRegion.EU },
        { (byte[])imageConverter.ConvertTo(Properties.Resources.us, typeof(byte[])), PKGRegion.US },
        { (byte[])imageConverter.ConvertTo(Properties.Resources.jp, typeof(byte[])), PKGRegion.JAPAN },
        { (byte[])imageConverter.ConvertTo(Properties.Resources.hk, typeof(byte[])), "HONG KONG" },
        { (byte[])imageConverter.ConvertTo(Properties.Resources.asia, typeof(byte[])), PKGRegion.ASIA },
        { (byte[])imageConverter.ConvertTo(Properties.Resources.kr, typeof(byte[])), PKGRegion.KOREA }
    };

            foreach (var kvp in regionMapping)
            {
                if (Utils.ByteArraysEqual(regionIcon, kvp.Key))
                {
                    return kvp.Value;
                }
            }

            return string.Empty;
        }

        private void TbSearchGame_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private static int IconFor(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext)) return 4; // no extension → binary
            return ext switch
            {
                ".png" or ".jpg" or ".dds" => 2,                          // image
                ".txt" => 1,                                              // document
                ".xml" or ".json" or ".sfo" or ".ini" => 3,              // config
                ".at9" or ".ogg" or ".mp3" or ".wav" => 6,              // audio
                ".mp4" or ".avi" => 9,                                    // video
                ".pkg" => 8,                                              // package
                _ => 4,                                                   // binary (default)
            };
        }

        private void PKGTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView.currentNode = e.Node;
            PKG.NodeFullPath = NodeLogicalPath(currentNode);

            // Find all root nodes
            rootNodes = new List<TreeNode>();
            foreach (TreeNode rootNode in PKGTreeView.Nodes)
            {
                rootNodes.Add(rootNode);
            }

            PopulateListView();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selectedItem = (TreeNodeInfo)listView1.SelectedItems[0].Tag;

            if (selectedItem.Path == "...")
            {
                // Handle navigating to the parent directory or showing both root nodes
                if (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    PKG.NodeFullPath = NodeLogicalPath(currentNode);
                    PopulateListView();
                }
                else if (currentNode != null && !rootNodes.Contains(currentNode))
                {
                    currentNode = null;
                    PKG.NodeFullPath = ""; // You might want to set this to the appropriate default value
                    PopulateListView();
                }
                else
                {
                    currentNode = null;
                    PKG.NodeFullPath = ""; // You might want to set this to the appropriate default value
                    PopulateListView(true);
                }
            }
            else if (selectedItem.Node.Nodes.Count > 0) // Check if the clicked item is a directory
            {
                // Handle clicking on a directory in the ListView
                currentNode = selectedItem.Node;
                PKG.NodeFullPath = NodeLogicalPath(currentNode);
                PopulateListView();
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleListViewActivation();
        }

        private void HandleListViewActivation()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = (TreeNodeInfo)listView1.SelectedItems[0].Tag;

                if (selectedItem.Path == "...")
                {
                    // Handle navigating to the parent directory or showing both root nodes
                    if (currentNode.Parent != null)
                    {
                        currentNode = currentNode.Parent;
                        PKG.NodeFullPath = NodeLogicalPath(currentNode);
                        PopulateListView();
                    }
                    else if (currentNode != null && !rootNodes.Contains(currentNode))
                    {
                        currentNode = null;
                        PKG.NodeFullPath = ""; // You might want to set this to the appropriate default value
                        PopulateListView();
                    }
                    else
                    {
                        currentNode = null;
                        PKG.NodeFullPath = ""; // You might want to set this to the appropriate default value
                        PopulateListView(true);
                    }
                }
                else if (selectedItem.Node.Nodes.Count > 0) // Check if the clicked item is a directory
                {
                    // Handle clicking on a directory in the ListView
                    currentNode = selectedItem.Node;
                    PKG.NodeFullPath = NodeLogicalPath(currentNode);
                    PopulateListView();
                }
                else
                {
                    // Empty directories also have Nodes.Count == 0 - skip preview for them
                    bool isDirItem = listView1.SelectedItems[0].SubItems.Count > 1
                        && listView1.SelectedItems[0].SubItems[1].Text == "Directory";
                    if (!isDirItem)
                        PreviewEntry(NodeLogicalPath(selectedItem.Node));
                }
            }
        }

        private string _previewError;

        /// <summary>Builds a classic hex dump (offset + hex + ASCII) for the first maxBytes of a file.</summary>
        private static string BuildHexDump(string path, int maxBytes)
        {
            var sb = new System.Text.StringBuilder();
            byte[] data;
            using (var fs = File.OpenRead(path))
            {
                int len = (int)Math.Min(fs.Length, maxBytes);
                data = new byte[len];
                fs.Read(data, 0, len);
            }
            for (int i = 0; i < data.Length; i += 16)
            {
                sb.Append(i.ToString("X8")).Append("  ");
                for (int j = 0; j < 16; j++)
                {
                    if (i + j < data.Length)
                        sb.Append(data[i + j].ToString("X2")).Append(' ');
                    else
                        sb.Append("   ");
                    if (j == 7) sb.Append(' ');
                }
                sb.Append(' ');
                for (int j = 0; j < 16 && i + j < data.Length; j++)
                {
                    byte b = data[i + j];
                    sb.Append(b >= 32 && b < 127 ? (char)b : '.');
                }
                sb.AppendLine();
            }
            if (data.Length == 0) sb.AppendLine("(empty file)");
            return sb.ToString();
        }

        /// <summary>
        /// Preview a file entry in the viewer pane (text or image).
        /// The entry is extracted to a temp dir, rendered, and cleaned up.
        /// </summary>
        private BackgroundWorker _previewWorker;
        private int _previewVersion;
        private string? _previewEntryPath;   // PKG entry currently previewed (for export)
        private bool _previewIsUnityFile;    // last previewed entry was a Unity serialized file

        // Asset workspace: the extracted container (pak/unity) kept alive while
        // the user browses its children in the asset list.
        private Assets.Abstractions.IAssetSource? _containerSource;
        private Assets.Models.AssetDetectionResult? _containerDetection;
        private string? _containerTempDir;
        private readonly List<Assets.Abstractions.IAssetSource> _containerChildren = new();
        private static readonly Assets.AssetInspectionService _assetService = Assets.GenericAssetRegistryBuilder.Build();

        // Grid filter state: the effective RowFilter is always built by
        // ApplyFilters() from these three sources (never set directly).
        private readonly PkgFilterState _filterState = new();

        private Assets.Models.TextureData _previewTexture; // prepared on the worker thread
        private string _previewText;         // prepared on the worker thread
        private string _previewHex;          // prepared on the worker thread
        private string _previewInfo;         // info-bar text
        private string _previewSizeStr;      // "123.45 MB" for the info bar

        private void PreviewEntry(string entryPath)
        {
            // Export applies to the entry about to be previewed.
            _previewEntryPath = entryPath;
            _previewIsUnityFile = false;
            if (btnExportTextures != null) btnExportTextures.Enabled = false;
            try
            {
                if (Helper.IsOperationRunning)
                {
                    ShowWarning("Cannot preview while an operation is running.", false);
                    return;
                }
                if (_previewWorker != null && _previewWorker.IsBusy)
                {
                    lblFileViewerInfo.Text = "Preview already in progress...";
                    return;
                }
                if (string.IsNullOrEmpty(PKG.SelectedPKGFilename)) return;
                CleanupContainerBrowse(); // a new preview releases the previous container
                string pkgPath = PKG.SelectedPKGFilename;

                // Size guard - don't fully extract giant entries just to preview the head.
                // Containers (pak/bundle/psarc) are exempt: the full extraction
                // IS the point, they are browsed rather than previewed.
                string entryExt = Path.GetExtension(entryPath).ToLowerInvariant();
                bool isContainerEntry = entryExt is ".pak" or ".assets" or ".bundle" or ".unity3d" or ".psarc";
                const long maxPreviewBytes = 200L * 1024 * 1024; // 200 MB
                long entrySize = _fileSizes.GetValueOrDefault(entryPath, 0);
                if (!isContainerEntry && entrySize > maxPreviewBytes)
                {
                    string tooLarge = $"{Path.GetFileName(entryPath)} File too large to preview ({Helper.RoundBytes(entrySize)})";
                    lblFileViewerInfo.Text = tooLarge;
                    ShowWarning(tooLarge, false);
                    return;
                }

                string fname = Path.GetFileName(entryPath);
                _previewSizeStr = Helper.RoundBytes(entrySize);
                _previewTexture = null;
                _previewText = null;
                _previewHex = null;
                _previewInfo = null;

                lblFileViewerInfo.Text = $"Previewing {fname}...";
                toolStripStatusLabel2.Text = $"Previewing {fname}...";
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar1.Visible = true;

                int version = Interlocked.Increment(ref _previewVersion);
                var bg = new BackgroundWorker();
                _previewWorker = bg;
                bg.DoWork += (_, _) =>
                {
                    try
                    {
                        // Re-check: an extraction may have started while we queued.
                        if (Helper.IsOperationRunning) return;

                        string tempDir = CreateOrbisTempDir("p");
                        string extracted = ExtractSingleEntryForPreview(pkgPath, entryPath, tempDir);
                        if (string.IsNullOrEmpty(extracted)) return;

                        // Asset framework: detect -> inspect -> preview/hex. All heavy
                        // decoding happens OFF the UI thread.
                        var source = new Assets.IO.FileAssetSource(extracted, "PKG entry");
                        var detection = _assetService.Detect(source);
                        _previewIsUnityFile = detection?.Format == Assets.Handlers.UnitySerializedFileHandler.FormatId;

                        // Unity .assets files stream texture data to a .resS companion -
                        // extract it into the same temp dir and wire a resolver so
                        // streamed textures decode (PS4 builds stream everything).
                        if (detection?.Format == Assets.Handlers.UnitySerializedFileHandler.FormatId)
                        {
                            ExtractUnityStreamCompanions(pkgPath, entryPath, tempDir);
                            if (Directory.EnumerateFiles(tempDir).Any(IsUnityStreamFile))
                            {
                                source = new Assets.IO.FileAssetSource(extracted, "PKG entry",
                                    rel => ResolveUnityStreamCompanion(tempDir, rel));
                            }
                        }
                        if (detection != null)
                        {
                            var descriptor = _assetService.InspectAsync(source, detection).GetAwaiter().GetResult();
                            _previewInfo = BuildPreviewInfo(fname, descriptor);
                            bool isContainer = _assetService.IsContainer(detection);
                            if (isContainer)
                            {
                                if (version != Volatile.Read(ref _previewVersion))
                                {
                                    try { Directory.Delete(tempDir, true); } catch { }
                                    return;
                                }
                                // Unity and Unreal containers are browse-first:
                                // show their object/entry list, rather than the
                                // whole-file text/contact-sheet fallback.
                                _containerSource = source;
                                _containerDetection = detection;
                                _containerTempDir = tempDir;
                            }
                            else if (descriptor.Capabilities.HasFlag(Assets.Abstractions.AssetCapabilities.Preview))
                            {
                                var preview = _assetService.TryPreviewAsync(source, detection).GetAwaiter().GetResult();
                                if (preview?.Texture != null) _previewTexture = preview.Texture;
                                else if (preview?.Text != null) _previewText = preview.Text;
                                else _previewHex = BuildHexDump(extracted, 1 << 20);
                            }
                            else
                            {
                                _previewHex = BuildHexDump(extracted, 1 << 20);
                            }
                        }
                        else
                        {
                            _previewHex = BuildHexDump(extracted, 1 << 20);
                        }

                        // Containers (pak/unity) stay alive for the asset workspace;
                        // everything else is cleaned up here (worker thread).
                        if (detection == null || !_assetService.IsContainer(detection))
                        {
                            try { if (File.Exists(extracted)) File.Delete(extracted); } catch { }
                            try { string d = Path.GetDirectoryName(extracted); if (!string.IsNullOrEmpty(d) && Path.GetFileName(d).StartsWith("p4t_p_")) Directory.Delete(d, true); } catch { }
                        }
                    }
                    catch (Assets.Errors.UnsupportedAssetException uex)
                    {
                        // e.g. BC7 DDS: metadata + hex fallback, not a hard failure.
                        _previewError = null;
                        _previewInfo = $"{fname} ({_previewSizeStr}) - {uex.Message}";
                    }
                    catch (Exception ex)
                    {
                        _previewError = ex.Message;
                    }
                };
                bg.RunWorkerCompleted += (_, _) =>
                {
                    _previewWorker = null;
                    if (version != _previewVersion) return; // a newer preview or package load started
                    ResetMainProgressBar();
                    toolStripStatusLabel2.Text = "...";
                    UpdatePackageActionButtonStates();
                    if (_previewError != null)
                    {
                        ShowError("Preview failed: " + _previewError, false);
                        _previewError = null;
                        return;
                    }
                    // Containers are browse-first. In particular, Unity's
                    // whole-file preview is only a text summary when textures
                    // cannot be decoded, which must not hide the object list.
                    if (_containerSource != null && _containerDetection != null)
                    {
                        PopulateAssetList();
                        return;
                    }
                    try
                    {
                        RenderPreviewResult(fname, _previewSizeStr);
                    }
                    catch (Exception ex)
                    {
                        ShowError("Preview failed: " + ex.Message, false);
                    }
                };
                bg.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError("Preview error: " + ex.Message);
            }
        }

        /// <summary>Shows the prepared preview (texture/text/hex) in the viewer pane.</summary>
        private void RenderPreviewResult(string fname, string sizeStr)
        {
            assetListView.Visible = false;
            btnAssetBack.Visible = _containerSource != null && _containerDetection != null;
            UpdatePackageActionButtonStates();
            if (_previewTexture != null)
            {
                picPreview.Visible = true;
                txtPreview.Visible = false;
                txtHexPreview.Visible = false;
                picPreview.Image?.Dispose();
                picPreview.Image = TextureToBitmap(_previewTexture);
                lblFileViewerInfo.Text = _previewInfo ?? $"{fname} ({sizeStr})";
            }
            else if (_previewText != null)
            {
                txtPreview.Visible = true;
                picPreview.Visible = false;
                txtHexPreview.Visible = false;
                txtPreview.Text = _previewText;
                lblFileViewerInfo.Text = _previewInfo ?? $"{fname} ({sizeStr})";
            }
            else if (_previewHex != null)
            {
                txtHexPreview.Visible = true;
                txtPreview.Visible = false;
                picPreview.Visible = false;
                txtHexPreview.Text = _previewHex;
                lblFileViewerInfo.Text = _previewInfo ?? $"{fname} ({sizeStr}) - hex, showing first {Helper.RoundBytes(1L << 20)}";
            }
            else
            {
                ShowWarning("Preview failed: entry could not be extracted.", false);
            }
        }

        /// <summary>Re-shows the cached asset list after a child preview (no re-extraction).</summary>
        private void btnAssetBack_Click(object sender, EventArgs e)
        {
            btnAssetBack.Visible = false;
            assetListView.Visible = true;
            picPreview.Visible = false;
            txtPreview.Visible = false;
            txtHexPreview.Visible = false;
            lblFileViewerInfo.Text = $"{_containerSource?.Name}: {_containerChildren.Count} entries (double-click to preview)";
            UpdatePackageActionButtonStates();
        }

        /// <summary>Populates the asset workspace list with the container's children.</summary>
        private void PopulateAssetList()
        {
            _containerChildren.Clear();
            assetListView.Items.Clear();
            if (_containerSource == null || _containerDetection == null)
            {
                assetListView.Visible = false;
                return;
            }
            var children = _assetService.GetChildrenAsync(_containerSource, _containerDetection, 0).GetAwaiter().GetResult();
            assetListView.BeginUpdate();
            try
            {
                int shown = 0;
                foreach (var c in children)
                {
                    if (shown++ >= 2000)
                    {
                        assetListView.Items.Add(new ListViewItem(new[] { "...", "", "" }));
                        break;
                    }
                    _containerChildren.Add(c);
                    string type = c switch
                    {
                        Assets.Containers.UnityObjectAssetSource u => $"class {u.Object.ClassId}",
                        Assets.Containers.PakEntrySource p => p.Entry.Compression,
                        _ => "file",
                    };
                    assetListView.Items.Add(new ListViewItem(new[] { c.Name, type, Helper.RoundBytes(c.Length) }));
                }
            }
            finally { assetListView.EndUpdate(); }
            assetListView.Visible = true;
            picPreview.Visible = false;
            txtPreview.Visible = false;
            txtHexPreview.Visible = false;
            lblFileViewerInfo.Text = $"{_containerSource.Name}: {_containerChildren.Count} entries (double-click to preview)";
            UpdatePackageActionButtonStates();
        }

        /// <summary>Releases the extracted container and clears the asset list.</summary>
        private void CleanupContainerBrowse()
        {
            _containerSource = null;
            _containerDetection = null;
            _containerChildren.Clear();
            if (assetListView != null)
            {
                assetListView.Items.Clear();
                assetListView.Visible = false;
            }
            if (btnAssetBack != null) btnAssetBack.Visible = false;
            if (btnExportTextures != null) btnExportTextures.Visible = false;
            if (_containerTempDir != null)
            {
                try { Directory.Delete(_containerTempDir, true); } catch { }
                _containerTempDir = null;
            }
        }

        private void assetListView_DoubleClick(object sender, EventArgs e)
        {
            if (assetListView.SelectedItems.Count == 0) return;
            int idx = assetListView.SelectedItems[0].Index;
            if (idx < 0 || idx >= _containerChildren.Count) return;
            PreviewChildAsset(_containerChildren[idx]);
        }

        /// <summary>Previews a container child: unity objects decode via the handler,
        /// pak entries / other children run the generic pipeline on a temp file.</summary>
        private void PreviewChildAsset(Assets.Abstractions.IAssetSource child)
        {
            if (_previewWorker != null && _previewWorker.IsBusy)
            {
                lblFileViewerInfo.Text = "Preview already in progress...";
                return;
            }

            int version = Interlocked.Increment(ref _previewVersion);
            var bg = new BackgroundWorker();
            _previewWorker = bg;
            bg.DoWork += (_, _) =>
            {
                try
                {
                    _previewTexture = null;
                    _previewText = null;
                    _previewHex = null;
                    _previewError = null;
                    _previewInfo = null;

                    if (child is Assets.Containers.UnityObjectAssetSource unityChild)
                    {
                        var handler = new Assets.Handlers.UnitySerializedFileHandler();
                        var preview = handler.PreviewAsync(unityChild, _containerDetection!).GetAwaiter().GetResult();
                        if (preview?.Texture != null) _previewTexture = preview.Texture;
                        else if (preview?.Text != null) _previewText = preview.Text;
                        else _previewError = "No preview available for this object.";
                        _previewInfo = preview?.Info;
                        return;
                    }

                    // Keep the entry's real filename (with extension) so the
                    // text/image detectors work on the temp copy.
                    string childName = Path.GetFileName(child.Name);
                    if (string.IsNullOrEmpty(Path.GetExtension(childName))) childName += ".bin";
                    string temp = Path.Combine(_containerTempDir!, "p4t_child_" + Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + childName);
                    using (var s = child.OpenRead())
                    using (var fs = File.Create(temp))
                        s.CopyTo(fs);

                    var source = new Assets.IO.FileAssetSource(temp, "container member");
                    var detection = _assetService.Detect(source);
                    if (detection == null)
                    {
                        _previewHex = BuildHexDump(temp, 1 << 20);
                        return;
                    }
                    var descriptor = _assetService.InspectAsync(source, detection).GetAwaiter().GetResult();
                    _previewInfo = BuildPreviewInfo(child.Name, descriptor);
                    if (descriptor.Capabilities.HasFlag(Assets.Abstractions.AssetCapabilities.Preview))
                    {
                        var preview = _assetService.TryPreviewAsync(source, detection).GetAwaiter().GetResult();
                        if (preview?.Texture != null) _previewTexture = preview.Texture;
                        else if (preview?.Text != null) _previewText = preview.Text;
                        else _previewHex = BuildHexDump(temp, 1 << 20);
                    }
                    else
                    {
                        _previewHex = BuildHexDump(temp, 1 << 20);
                    }
                }
                catch (Exception ex)
                {
                    _previewError = ex.Message;
                }
            };
            bg.RunWorkerCompleted += (_, _) =>
            {
                _previewWorker = null;
                if (version != _previewVersion) return;
                ResetMainProgressBar();
                toolStripStatusLabel2.Text = "...";
                // Always offer the way back while browsing a container, even
                // when the child preview failed (e.g. an unsupported entry).
                btnAssetBack.Visible = _containerSource != null;
                UpdatePackageActionButtonStates();
                if (_previewError != null)
                {
                    ShowError("Preview failed: " + _previewError, false);
                    _previewError = null;
                    return;
                }
                try
                {
                    RenderPreviewResult(child.Name, Helper.RoundBytes(child.Length));
                }
                catch (Exception ex)
                {
                    ShowError("Preview failed: " + ex.Message, false);
                }
            };
            toolStripStatusLabel2.Text = "Previewing asset...";
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = true;
            bg.RunWorkerAsync();
        }

        /// <summary>Converts the neutral RGBA8 texture to a WinForms Bitmap (RGBA -> BGRA swap).</summary>
        private static Bitmap TextureToBitmap(Assets.Models.TextureData tex)
        {
            var bmp = new Bitmap(tex.Width, tex.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var rect = new Rectangle(0, 0, tex.Width, tex.Height);
            var bits = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                byte[] rgba = tex.Rgba8;
                byte[] bgra = new byte[rgba.Length];
                for (int i = 0; i + 3 < rgba.Length; i += 4)
                {
                    bgra[i] = rgba[i + 2];     // B
                    bgra[i + 1] = rgba[i + 1]; // G
                    bgra[i + 2] = rgba[i];     // R
                    bgra[i + 3] = rgba[i + 3]; // A
                }
                System.Runtime.InteropServices.Marshal.Copy(bgra, 0, bits.Scan0, bgra.Length);
            }
            finally
            {
                bmp.UnlockBits(bits);
            }
            return bmp;
        }

        /// <summary>Info-bar text from the descriptor: name (size) + format + key metadata.</summary>
        private static string BuildPreviewInfo(string fname, Assets.Models.AssetDescriptor d)
        {
            var sb = new System.Text.StringBuilder($"{fname} ({Helper.RoundBytes(d.Size)}) - {d.Format.ToUpperInvariant()}");
            int shown = 0;
            foreach (var kv in d.Metadata)
            {
                if (kv.Key is "Width" or "Height" or "Sample Rate" or "Channels" or "Bit Depth" or "Pixel Format")
                {
                    sb.Append(shown == 0 ? " [" : ", ").Append($"{kv.Key}={kv.Value}");
                    shown++;
                }
            }
            if (shown > 0) sb.Append(']');
            return sb.ToString();
        }

        private string ExtractSingleEntryForPreview(string pkgPath, string entryPath, string tempDir)
        {
            // In-process extraction: the PKG is opened read-only and the entry
            // is decrypted straight into tempDir. No spawn, no staging.
            // ExtractFileTo gives an EXACT destination (no Image0\ prefix), so
            // the preview lands flat and a Unity .resS companion sits next to it.
            string destPath = Path.Combine(tempDir, Path.GetFileName(entryPath));
            string realPath = _pathMap.TryResolveFile(entryPath, out string resolved) ? resolved : entryPath;
            using var reader = new OrbisPkgTool.PkgReader(pkgPath, DefaultOrbisPasscode);
            reader.ExtractFileTo(realPath, destPath);
            return File.Exists(destPath) ? destPath : "";
        }

        /// <summary>Stages Unity stream data from the selected asset's folder.
        /// Some PS4 builds leave StreamingInfo.path empty and use a shared .resS
        /// file (for example resources.assets.resS) instead of asset.assets.resS.</summary>
        private static void ExtractUnityStreamCompanions(string pkgPath, string entryPath, string tempDir)
        {
            string folder = (Path.GetDirectoryName(entryPath) ?? string.Empty).Replace('\\', '/').TrimEnd('/');
            using var reader = new OrbisPkgTool.PkgReader(pkgPath, DefaultOrbisPasscode);
            foreach (var candidate in reader.ListFiles())
            {
                if (candidate.IsDirectory || !IsUnityStreamFile(candidate.Path))
                    continue;
                string candidateLogical = DumpLayout.MapToLogical(candidate.Path);
                string candidateFolder = (Path.GetDirectoryName(candidateLogical) ?? string.Empty).Replace('\\', '/').TrimEnd('/');
                if (!string.Equals(folder, candidateFolder, StringComparison.OrdinalIgnoreCase))
                    continue;
                try { reader.ExtractFileTo(candidate.Path, Path.Combine(tempDir, Path.GetFileName(candidate.Path))); }
                catch { /* missing/corrupt optional stream is handled by the preview fallback */ }
            }
        }

        private static Assets.Abstractions.IAssetSource ResolveUnityStreamCompanion(string tempDir, string relativePath)
        {
            string requested = Path.Combine(tempDir, Path.GetFileName(relativePath));
            if (File.Exists(requested))
                return new Assets.IO.FileAssetSource(requested, "Unity .resS stream");
            string[] candidates = Directory.EnumerateFiles(tempDir)
                .Where(IsUnityStreamFile)
                .ToArray();
            return candidates.Length == 1
                ? new Assets.IO.FileAssetSource(candidates[0], "Unity .resS stream")
                : null;
        }

        // PS4 Unity games also use the older ".resource" stream extension.
        private static bool IsUnityStreamFile(string path)
            => path.EndsWith(".resS", StringComparison.OrdinalIgnoreCase)
               || path.EndsWith(".resource", StringComparison.OrdinalIgnoreCase);

        private void PopulateListView(bool showRootNodes = false)
        {
            if (_populating) return;
            _populating = true;
            try
            {
                _allItems.Clear();
                _upItem = null;
                _currentNode = currentNode;

                // "..." navigation item
                if (currentNode != null && !showRootNodes)
                {
                    TreeNodeInfo parentItem = new TreeNodeInfo
                    {
                        Node = currentNode.Parent != null ? currentNode.Parent : null,
                        Path = "..."
                    };
                    _upItem = new ListViewItem("...");
                    _upItem.Tag = parentItem;
                    _upItem.ImageIndex = 5;
                    _upItem.SubItems.Add(""); _upItem.SubItems.Add(""); _upItem.SubItems.Add("");
                }

                listView1.SmallImageList = this.imageList1;

                List<TreeNode> list;
                if (currentNode != null)
                {
                    list = currentNode.Nodes.Cast<TreeNode>().ToList();
                }
                else if (showRootNodes)
                {
                    list = rootNodes;
                }
                else
                {
                    return;
                }

                foreach (var item in list)
                {
                    string logical = NodeLogicalPath(item);
                    string dir = Path.GetDirectoryName(logical);
                    bool isDirectory = item.Nodes.Count > 0 || _pkgDirectories.Contains(logical);

                    TreeNodeInfo treeNodeInfo = new TreeNodeInfo
                    {
                        Node = item,
                        Path = logical
                    };

                    ListViewItem listViewItem = new ListViewItem(isDirectory ? "Directory" : "File");
                    listViewItem.Text = item.Text;
                    listViewItem.SubItems.Add(isDirectory ? "Directory" : Path.GetExtension(item.Text).Replace(".", ""));
                    listViewItem.SubItems.Add(dir);
                    listViewItem.SubItems.Add(isDirectory ? "" : Helper.RoundBytes(_fileSizes.GetValueOrDefault(logical, 0)));
                    listViewItem.Tag = treeNodeInfo;
                    listViewItem.ImageIndex = isDirectory ? 0 : IconFor(item.Text);

                    _allItems.Add(listViewItem);
                }

                ApplyFilter();
            }
            finally
            {
                _populating = false;
            }
        }

        // ── TreeView / ListView Filter ─────────────────────

        void ApplyFilter()
        {
            string q = tbFilterTreeView.SearchText.Trim();
            bool all = string.IsNullOrEmpty(q);
            listView1.BeginUpdate();
            listView1.Items.Clear();
            // The "..." up-folder item is navigation context, not a search match -
            // only show it when no filter is active.
            if (all && _upItem != null) listView1.Items.Add(_upItem);
            if (all)
            {
                foreach (var item in _allItems) listView1.Items.Add(item);
            }
            else
            {
                // Nodes detached from the tree (e.g. another PKG was selected)
                // throw on FullPath - nothing to filter against in that state.
                bool treeAttached = PKGTreeView.Nodes.Count > 0
                    || (rootNodes != null && rootNodes.Count > 0
                        && rootNodes[0].TreeView != null);
                if (treeAttached)
                {
                    // Search the WHOLE flattened tree (all root entries), not
                    // just the current folder - otherwise e.g. sce_sys/param.sfo
                    // is unreachable while the list is focused on another folder.
                    if (rootNodes != null && rootNodes.Count > 0)
                        foreach (TreeNode root in rootNodes) CollectMatches(root, q);
                    else if (_currentNode != null)
                        CollectMatches(_currentNode, q);
                }
            }
            listView1.EndUpdate();
        }

        void CollectMatches(TreeNode node, string query)
        {
            var children = (node.Parent == null && node.TreeView == null)
                ? (rootNodes ?? Enumerable.Empty<TreeNode>())
                : node.Nodes.Cast<TreeNode>();
            foreach (TreeNode child in children)
            {
                bool isDir = child.Nodes.Count > 0;
                string type = isDir ? "Directory" : Path.GetExtension(child.Text).Replace(".", "");
                string childLogical = NodeLogicalPath(child);
                bool matches = child.Text.Contains(query, StringComparison.OrdinalIgnoreCase)
                    || type.Contains(query, StringComparison.OrdinalIgnoreCase)
                    || childLogical.Contains(query, StringComparison.OrdinalIgnoreCase);
                if (matches)
                {
                    TreeNodeInfo info = new TreeNodeInfo { Node = child, Path = childLogical };
                    var item = new ListViewItem(isDir ? "Directory" : "File");
                    item.Text = child.Text;
                    item.SubItems.Add(type);
                    item.SubItems.Add(Path.GetDirectoryName(childLogical));
                    item.SubItems.Add(isDir ? "" : Helper.RoundBytes(_fileSizes.GetValueOrDefault(childLogical, 0)));
                    item.Tag = info;
                    item.ImageIndex = isDir ? 0 : IconFor(child.Text);
                    listView1.Items.Add(item);
                    ExpandAncestors(child);
                }
                if (isDir) CollectMatches(child, query);
            }
        }

        static void ExpandAncestors(TreeNode node)
        {
            var parent = node.Parent;
            while (parent != null) { parent.Expand(); parent = parent.Parent; }
        }

        private void settingstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProgramSettings();
        }

        private void Backport_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == setBackportedtoolStripMenuItem1 || clickedMenuItem == setBackportedToolStripMenuItem2)
            {
                if (PKGGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in PKGGridView.SelectedRows)
                    {
                        row.Cells["Backported"].Value = "Yes";
                        Logger.LogInformation($"\"{row.Cells["Filename"].Value}\" set as backported.");
                    }
                    ShowInformation("PKG set as backported.", false);
                }
            }

            if (clickedMenuItem == setRemarktoolStripMenuItem1)
            {
                if (PKGGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in PKGGridView.SelectedRows)
                    {
                        row.Cells["Backported"].Value = backportRemarkTextboxtoolStripTextBox1.Text;
                        Logger.LogInformation($"Added backport remark to \"{row.Cells["Filename"].Value}\" ({backportRemarkTextboxtoolStripTextBox1.Text}).");
                    }
                    ShowInformation("Backport remark added.", false);
                }
            }

            if (clickedMenuItem == setRemarktoolStripMenuItem2)
            {
                if (PKGGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in PKGGridView.SelectedRows)
                    {
                        row.Cells["Backported"].Value = backportRemarkTextboxtoolStripTextBox2.Text;
                        Logger.LogInformation($"Added backport remark to \"{row.Cells["Filename"].Value}\" ({backportRemarkTextboxtoolStripTextBox2.Text}).");
                    }
                    ShowInformation("Backport remark added.", false);
                }
            }

            if (clickedMenuItem == removeBackportedtoolStripMenuItem1 || clickedMenuItem == removeBackportedToolStripMenuItem2)
            {
                if (PKGGridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in PKGGridView.SelectedRows)
                    {
                        row.Cells["Backported"].Value = "No";
                        Logger.LogInformation($"Removed backport label from \"{row.Cells["Filename"].Value}\".");
                    }
                    ShowInformation("Backport remark removed.", false);
                }
            }

            Backport.SaveData(PKGGridView);
            PopulateGroupedView(); // reflect backport labels in the grouped view
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            //tbLog.SelectionStart = tbLog.Text.Length;
            //tbLog.ScrollToCaret();
        }


        // Helper method to find or create a node with a specific text
        private TreeNode FindOrCreateNode(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == text)
                {
                    return node;
                }
            }

            // If the node doesn't exist, create it
            TreeNode newNode = new TreeNode(text);
            nodes.Add(newNode);
            return newNode;
        }

        // Helper method to find or create a category node (Game, Patch, Addon, App)
        private TreeNode FindOrCreateCategoryNode(TreeNode parentNode, string categoryName)
        {
            foreach (TreeNode categoryNode in parentNode.Nodes)
            {
                if (categoryNode.Text == categoryName)
                {
                    return categoryNode;
                }
            }

            // If the category node doesn't exist, create it
            TreeNode newCategoryNode = new TreeNode(categoryName);
            parentNode.Nodes.Add(newCategoryNode);
            return newCategoryNode;
        }

        private void OpenAppDataDirectory_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedMenuItem))
                return;

            if (clickedMenuItem == openAppDataDirectoryToolStripMenuItem2)
            {
                OpenTempDirectory();
            }
        }
    }
}

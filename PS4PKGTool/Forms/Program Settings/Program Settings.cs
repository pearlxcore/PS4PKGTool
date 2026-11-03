using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using PS4PKGTool.Utilities.Settings;
using PS4PKGTool.Utilities.Shadps4;
using Color = System.Drawing.Color;
using static PS4PKGTool.Utilities.PS4PKGToolHelper.Helper;
using PS4PKGTool.Utilities.PS4PKGToolHelper;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using PS4PKGTool.Utilities.TrophyMetadata;
using DarkUI.Config;
using DarkUI.Controls;

namespace PS4PKGTool
{
    public partial class ProgramSetting : DarkUI.Forms.DarkForm
    {
        const string TITLE = "Atomic Heart";
        const string TITLE_ID = "CUSA17266";
        const string VERSION = "1.00";
        const string APP_VERSION = "1.00";
        const string CATEGORY = "Game";
        const string CONTENT_ID = "EP4133-CUSA37321_00-ATOMICHEARTGAME0";
        const string CONTENT_ID2 = "EP4133-CUSA37321_00-ATOMICHEARTGAME0-A0100-V0116";
        const string REGION = "EU";
        const string SYSTEM_VERSION = "9.50";
        private string HttpServerModulePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\npm\node_modules\http-server";
        private CancellationTokenSource trophyCacheCancellation;
        private string TrophyCachePath => Path.Combine(AppDataDirectory, "TrophyMetadata", "np-communication-ids.json");
        // Kept outside Designer.cs: the WinForms serializer has previously
        // dropped this declaration while retaining its InitializeComponent use.
        private DarkSectionPanel grpStartup;

        public bool Refresh = false;
        private bool _syncingThemeSelection;
        public ProgramSetting()
        {
            InitializeComponent();
            FormClosing += ProgramSetting_FormClosing;
            FormClosed += (_, _) => ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
            RefreshShellIntegrationStatus();
        }

        // ── File Explorer integration ────────────────────────────────────

        private void RefreshShellIntegrationStatus()
        {
            bool installed = PS4PKGTool.Shell.ShellRegistry.IsInstalled();
            lblShellIntegrationStatus.Text = "Status: " + (installed ? "Installed" : "Not installed");
            btnShellInstall.Visible = !installed;
            btnShellRemove.Visible = installed;
            appSettings_.ShellIntegrationInstalled = installed;
        }

        private void btnShellInstall_Click(object sender, EventArgs e)
        {
            PS4PKGTool.Shell.ShellRegistry.Install();
            appSettings_.ShellIntegrationInstalled = true;
            SettingsManager.SaveSettings(appSettings_, SettingFilePath);
            RefreshShellIntegrationStatus();
            MessageBoxHelper.ShowInformation(
                "File Explorer integration installed.\n\nRight-click a .pkg file and choose PS4 PKG Tool to validate, extract, rename, copy metadata or install to shadPS4.",
                false);
        }

        private void btnShellRemove_Click(object sender, EventArgs e)
        {
            PS4PKGTool.Shell.ShellRegistry.Remove();
            appSettings_.ShellIntegrationInstalled = false;
            SettingsManager.SaveSettings(appSettings_, SettingFilePath);
            RefreshShellIntegrationStatus();
            MessageBoxHelper.ShowInformation("File Explorer integration removed.", false);
        }

     
        private void ProgramSetting_Load(object sender, EventArgs e)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    darkComboBoxServerIP.Items.Add(ip.ToString());
                }
            }

            cmbTheme.Items.AddRange(ThemeManager.Presets.Select(p => p.Name).ToArray());
            cmbTheme.SelectedIndexChanged += (_, _) =>
            {
                if (!_syncingThemeSelection && cmbTheme.SelectedIndex >= 0)
                    ThemeManager.Apply(ThemeManager.Presets[cmbTheme.SelectedIndex]);
            };
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;

            #region LoadSetting
            // directory settings
            darkCheckBoxRecursive.Checked = appSettings_.ScanRecursive;
            lbPkgDirectoryList.Items.AddRange(appSettings_.PkgDirectories?.Cast<string>().ToArray() ?? Array.Empty<string>());
            tbOrbisTempDirectory.Text = appSettings_.OrbisTempDirectory;
            cbIgnoreDiskSpace.Checked = appSettings_.IgnoreDiskSpaceCheck;

            AutoSortRow.Checked = appSettings_.AutoSortRow;
            PKGColorLabeling.Checked = appSettings_.PkgColorLabel;
            ApplyPkgColorSwatches();
            tbCustomNamePattern.Text = appSettings_.RenameCustomName;

            tbPS4IP.Text = appSettings_.Ps4Ip;
            darkComboBoxServerIP.Text = appSettings_.LocalServerIp;
            labelPs5BcJsonDownloadDate.Text = (appSettings_.Ps5BcJsonLastDownloadDate == DateTime.MinValue || !File.Exists(Ps5BcJsonFile))
                ? ""
                : appSettings_.Ps5BcJsonLastDownloadDate.ToString("d MMMM yyyy", CultureInfo.InvariantCulture);

            cbPs5BcCheck.Checked = appSettings_.psvr_neo_ps5bc_check;
            cbShadps4Check.Checked = appSettings_.Shadps4Check;
            cmbShadps4Os.SelectedIndex = appSettings_.Shadps4Os switch
            {
                "linux" => 1,
                "macos" => 2,
                _ => 0, // windows (default)
            };
            labelShadps4JsonDate.Text = Shadps4Compat.LastDownload?.ToString("d MMMM yyyy", CultureInfo.InvariantCulture) ?? "Not downloaded";
            Location.Checked = appSettings_.pkgDirectoryColumn;
            Size.Checked = appSettings_.pkgsizeColumn;
            Category.Checked = appSettings_.pkgcategoryColumn;
            PkgType.Checked = appSettings_.pkgTypeColumn;
            SystemFirmware.Checked = appSettings_.pkgminimumFirmwareColumn;
            Version.Checked = appSettings_.pkgversionColumn;
            Region.Checked = appSettings_.pkgregionColumn;
            ContentId.Checked = appSettings_.pkgcontentIdColumn;
            TitleId.Checked = appSettings_.pkgtitleIdColumn;
            cbBackported.Checked = appSettings_.pkgBackportColumn;
            cbAutoFetchUpdate.Checked = appSettings_.AutoFetchUpdate;
            BGM.Checked = appSettings_.PlayBgm;
            int savedThemeIndex = ThemeManager.Presets
                .Select((theme, index) => new { theme, index })
                .Where(item => string.Equals(item.theme.Name, appSettings_.ThemeName, StringComparison.Ordinal))
                .Select(item => item.index)
                .DefaultIfEmpty(appSettings_.ThemeIndex)
                .First();
            cmbTheme.SelectedIndex = savedThemeIndex >= 0 && savedThemeIndex < ThemeManager.Presets.Count
                ? savedThemeIndex : 0;
            #endregion LoadSetting

            #region nodejs&serve
            if (Tool.IsAppInstalled("Node.js") == true)
            {
                darkLabelNodejsInstalled.Text = "✔";
                darkLabelNodejsInstalled.ForeColor = Color.Green;
                btnInstallNodejs.Enabled = false;
                appSettings_.NodeJsInstalled = true;
            }
            else
            {
                darkLabelNodejsInstalled.Text = "✘";
                darkLabelNodejsInstalled.ForeColor = Color.Red;
                btnInstallNodejs.Enabled = true;
                appSettings_.NodeJsInstalled = false;
            }

            if (Directory.Exists(HttpServerModulePath))
            {
                darkLabelserveModuleInstalled.Text = "✔";
                darkLabelserveModuleInstalled.ForeColor = Color.Green;
                btnInstalleServerModule.Enabled = false;
                appSettings_.HttpServerInstalled = true;

            }
            else
            {
                darkLabelserveModuleInstalled.Text = "✘";
                darkLabelserveModuleInstalled.ForeColor = Color.Red;
                btnInstalleServerModule.Enabled = true;
                appSettings_.HttpServerInstalled = false;
            }

            #endregion nodejs&serve

            cbPs5BcCheck.CheckedChanged += cbPs5BcCheck_CheckedChanged;
            UpdateTrophyCacheStatus();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Hide();
        }

        private void SaveSettings()
        {
            Logger.LogInformation("Saving program settings..");

            appSettings_.PlayBgm = BGM.Checked;
            appSettings_.AutoSortRow = AutoSortRow.Checked;
            appSettings_.PkgColorLabel =PKGColorLabeling.Checked;

            // fore color (stored as empty when it is only the theme default, so it keeps
            // following the active theme instead of baking a fixed colour)
            appSettings_.GamePkgForeColor = StorePkgColor(darkLabelGamePkgColorLabel.ForeColor, DefaultPkgForeColor);
            appSettings_.PatchPkgForeColor = StorePkgColor(darkLabelPatchPkgColorLabel.ForeColor, DefaultPkgForeColor);
            appSettings_.AddonPkgForeColor = StorePkgColor(darkLabelAddonPkgColorLabel.ForeColor, DefaultPkgForeColor);
            appSettings_.AppPkgForeColor = StorePkgColor(darkLabelAppPkgColorLabel.ForeColor, DefaultPkgForeColor);

            // back color
            appSettings_.GamePkgBackColor = StorePkgColor(darkLabelGamePkgColorLabel.BackColor, DefaultPkgBackColor);
            appSettings_.PatchPkgBackColor = StorePkgColor(darkLabelPatchPkgColorLabel.BackColor, DefaultPkgBackColor);
            appSettings_.AddonPkgBackColor = StorePkgColor(darkLabelAddonPkgColorLabel.BackColor, DefaultPkgBackColor);
            appSettings_.AppPkgBackColor = StorePkgColor(darkLabelAppPkgColorLabel.BackColor, DefaultPkgBackColor);

            appSettings_.RenameCustomName = tbCustomNamePattern.Text;
            appSettings_.OrbisTempDirectory = tbOrbisTempDirectory.Text.Trim();
            appSettings_.IgnoreDiskSpaceCheck = cbIgnoreDiskSpace.Checked;
            appSettings_.pkgtitleIdColumn = TitleId.Checked;
            appSettings_.pkgcontentIdColumn = ContentId.Checked;
            appSettings_.pkgregionColumn = Region.Checked;
            appSettings_.pkgversionColumn = Version.Checked;
            appSettings_.pkgminimumFirmwareColumn = SystemFirmware.Checked;
            appSettings_.pkgTypeColumn = PkgType.Checked;
            appSettings_.pkgcategoryColumn = Category.Checked;
            appSettings_.pkgsizeColumn = Size.Checked;
            appSettings_.pkgDirectoryColumn = Location.Checked;
            appSettings_.pkgBackportColumn = cbBackported.Checked;
            appSettings_.AutoFetchUpdate = cbAutoFetchUpdate.Checked;
            appSettings_.psvr_neo_ps5bc_check = cbPs5BcCheck.Checked;
            appSettings_.Shadps4Check = cbShadps4Check.Checked;
            appSettings_.Shadps4Os = cmbShadps4Os.SelectedIndex switch
            {
                1 => "linux",
                2 => "macos",
                _ => "windows",
            };
            appSettings_.ThemeIndex = cmbTheme.SelectedIndex;
            appSettings_.ThemeName = cmbTheme.SelectedIndex >= 0
                ? ThemeManager.Presets[cmbTheme.SelectedIndex].Name
                : string.Empty;

            appSettings_.LocalServerIp = darkComboBoxServerIP.Text;
            appSettings_.Ps4Ip = tbPS4IP.Text;
            appSettings_.NodeJsInstalled = Tool.IsAppInstalled("Node.js");
            appSettings_.HttpServerInstalled = (Directory.Exists(HttpServerModulePath)) ? true : false;

            var PkgDirectoryList = lbPkgDirectoryList.Items.Cast<string>().ToList();
            appSettings_.PkgDirectories = PkgDirectoryList;
            appSettings_.ScanRecursive = darkCheckBoxRecursive.Checked;

            if (labelPs5BcJsonDownloadDate.Text != "" || labelPs5BcJsonDownloadDate.Text.Length != 0)
                appSettings_.Ps5BcJsonLastDownloadDate = DateTime.Parse(labelPs5BcJsonDownloadDate.Text);

            SettingsManager.SaveSettings(appSettings_, SettingFilePath);
        }

        private void btnBrowseOrbisTempDirectory_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Choose a temporary directory for PKG working files.",
                ShowNewFolderButton = true
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                tbOrbisTempDirectory.Text = dialog.SelectedPath;
        }

        private void btnUseDefaultOrbisTempDirectory_Click(object sender, EventArgs e)
        {
            tbOrbisTempDirectory.Text = string.Empty;
        }

        private void ThemeManager_ThemeChanged(object sender, EventArgs e)
        {
            if (IsDisposed || Disposing)
                return;

            int index = ThemeManager.Presets
                .Select((theme, themeIndex) => new { theme, themeIndex })
                .Where(item => ReferenceEquals(item.theme, ThemeManager.Active))
                .Select(item => item.themeIndex)
                .DefaultIfEmpty(-1)
                .First();
            if (index < 0)
                return;

            appSettings_.ThemeIndex = index;
            appSettings_.ThemeName = ThemeManager.Active.Name;

            _syncingThemeSelection = true;
            try
            {
                if (cmbTheme.SelectedIndex != index)
                    cmbTheme.SelectedIndex = index;
            }
            finally
            {
                _syncingThemeSelection = false;
            }

            // The category header selector changes ThemeManager directly, so
            // persist its choice immediately instead of requiring Save & Close.
            SettingsManager.SaveSettings(appSettings_, SettingFilePath);
        }

        private async void btnPingPs4_Click(object sender, EventArgs e)
        {
            if (tbPS4IP.Text == string.Empty)
                return;

            Logger.LogInformation("Checking PS4 connectivity..");
            btnPingPs4.Enabled = false;
            bool isPS4Connected;
            try
            {
                string address = tbPS4IP.Text;
                isPS4Connected = await Task.Run(() => Tool.CheckForPS4Connection(address));
            }
            finally
            {
                btnPingPs4.Enabled = true;
            }

            if (isPS4Connected)
            {
                ShowInformation("PS4 detected.", true);
            }
            else
            {
                ShowError("PS4 not detected.", true);
            }
        }

        private async void btnInstallServerModule_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Installing http-server module..");
            bool nodejsInstalled = Tool.IsAppInstalled("Node.js");

            if (!nodejsInstalled)
            {
                ShowInformation("Please install Node.js before installing the serve module.", true);
                Tool.OpenWebLink("https://nodejs.org/en/download/");
                return;
            }

            this.Enabled = false;
            try
            {
                string error = await Task.Run(InstallServerModule);
                if (!string.IsNullOrEmpty(error))
                    ShowError(error, true);
                UpdateServerModuleStatus();
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private string InstallServerModule()
        {
            try
            {
                using Process server = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = "/C npm install http-server -g"
                };
                server.StartInfo = startInfo;

                if (server.Start())
                {
                    server.WaitForExit();
                    int exitCode = server.ExitCode;

                    if (exitCode == 0)
                    {
                        Logger.LogInformation("http-server package installed.");
                        appSettings_.HttpServerInstalled = (Directory.Exists(HttpServerModulePath)) ? true : false;
                    }
                    else
                    {
                        return $"An error occurred while installing http-server. Exit code: {exitCode}. Try installing http-server manually in Command Prompt.";
                    }
                }
                else
                {
                    Logger.LogError("Failed to start the process.");
                    return "Failed to start the http-server installation process.";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("An error occurred: " + ex.Message);
                return "Failed to install http-server: " + ex.Message;
            }
            return string.Empty;
        }

        private void UpdateServerModuleStatus()
        {
            btnInstalleServerModule.Enabled = !appSettings_.HttpServerInstalled;
        }

        private void btnInstallNodejs_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Installing Node.js..");
            Tool.OpenWebLink("https://nodejs.org/en/download/");
        }

        // ── PKG colour-label swatches (theme-aware) ───────────────────────

        /// <summary>Default PKG label colours: the active theme's own text/background.</summary>
        private static Color DefaultPkgForeColor => Colors.LightText;
        private static Color DefaultPkgBackColor => Colors.GreyBackground;

        /// <summary>Shows the saved PKG label colours on the preview swatches, falling back to
        /// the active theme when a colour is unset.</summary>
        private void ApplyPkgColorSwatches()
        {
            SetPkgColorSwatch(darkLabelGamePkgColorLabel, appSettings_.GamePkgForeColor, appSettings_.GamePkgBackColor);
            SetPkgColorSwatch(darkLabelPatchPkgColorLabel, appSettings_.PatchPkgForeColor, appSettings_.PatchPkgBackColor);
            SetPkgColorSwatch(darkLabelAddonPkgColorLabel, appSettings_.AddonPkgForeColor, appSettings_.AddonPkgBackColor);
            SetPkgColorSwatch(darkLabelAppPkgColorLabel, appSettings_.AppPkgForeColor, appSettings_.AppPkgBackColor);
        }

        private static void SetPkgColorSwatch(DarkLabel label, Color fore, Color back)
        {
            label.ForeColor = fore.IsEmpty ? DefaultPkgForeColor : fore;
            label.BackColor = back.IsEmpty ? DefaultPkgBackColor : back;
        }

        /// <summary>Stores a swatch colour, or <see cref="Color.Empty"/> when it is only the
        /// theme default, so the setting keeps following the theme instead of baking it in.</summary>
        private static Color StorePkgColor(Color current, Color themeDefault)
            => current == themeDefault ? Color.Empty : current;

        private void SetPKGLabelColor_Click(object sender, EventArgs args)
        {
            if (!(sender is Button clickedButton))
                return;


            if (clickedButton == btnResetPkgLabelColor)
            {
                // Reset to the active theme's own colours (not a fixed dark grey).
                darkLabelGamePkgColorLabel.ForeColor = DefaultPkgForeColor;
                darkLabelGamePkgColorLabel.BackColor = DefaultPkgBackColor;

                darkLabelPatchPkgColorLabel.ForeColor = DefaultPkgForeColor;
                darkLabelPatchPkgColorLabel.BackColor = DefaultPkgBackColor;

                darkLabelAddonPkgColorLabel.ForeColor = DefaultPkgForeColor;
                darkLabelAddonPkgColorLabel.BackColor = DefaultPkgBackColor;

                darkLabelAppPkgColorLabel.ForeColor = DefaultPkgForeColor;
                darkLabelAppPkgColorLabel.BackColor = DefaultPkgBackColor;
            }
            else
            {
                ColorDialog colorDialog = new ColorDialog();
                DialogResult result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    string colorValue = ColorTranslator.ToHtml(selectedColor);

                    // fore
                    if (clickedButton == btnGamePkgForeColor)
                        darkLabelGamePkgColorLabel.ForeColor = selectedColor;
                    if (clickedButton == btnPatchPkgForeColor)
                        darkLabelPatchPkgColorLabel.ForeColor = selectedColor;
                    if (clickedButton == btnAddonPkgForeColor)
                        darkLabelAddonPkgColorLabel.ForeColor = selectedColor;
                    if (clickedButton == btnAppPkgForeColor)
                        darkLabelAppPkgColorLabel.ForeColor = selectedColor;

                    // back
                    if (clickedButton == btnGamePkgBackColor)
                        darkLabelGamePkgColorLabel.BackColor = selectedColor;
                    if (clickedButton == btnPatchPkgBackColor)
                        darkLabelPatchPkgColorLabel.BackColor = selectedColor;
                    if (clickedButton == btnAddonPkgBackColor)
                        darkLabelAddonPkgColorLabel.BackColor = selectedColor;
                    if (clickedButton == btnAppPkgBackColor)
                        darkLabelAppPkgColorLabel.BackColor = selectedColor;

                    Logger.LogInformation($"Selected {colorValue}.");
                }
            }
        }

        private async void btnDownloadPS5BCJson_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Downloading PS5 Backward Compatibility json from github..");

            if (!await Task.Run(() => Tool.CheckForInternetConnection("github.com")))
            {
                ShowError("Problem occured when try connecting to Github", true);
                return;
            }
            try
            {
                ShowTaskbarNotification("PS5 Backward Compatibility Status", "PS5 Backward Compatibility Status is being downloaded..");
                await Tool.DownloadFileFromUrlAsync("https://raw.githubusercontent.com/andshrew/supreme-enigma/master/docs/PS5-BC-Status.json", Ps5BcJsonFile);
                ShowInformation("PS5 Backward Compatibility Status file downloaded to AppData", true);
                appSettings_.Ps5BcJsonLastDownloadDate = DateTime.Now;
                labelPs5BcJsonDownloadDate.Text = appSettings_.Ps5BcJsonLastDownloadDate.ToString("d MMMM yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                ShowError("Failed to download PS5 Backward Compatibility Status file : " + ex.Message, true);
            }
        }

        private async void btnDownloadShadps4Json_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Downloading shadPS4 compatibility data from GitHub..");

            if (!await Task.Run(() => Tool.CheckForInternetConnection("github.com")))
            {
                ShowError("Problem occured when try connecting to Github", true);
                return;
            }

            btnDownloadShadps4Json.Enabled = false;
            btnDownloadShadps4Json.Text = "Downloading...";
            try
            {
                var progress = new Progress<string>(s => Logger.LogInformation("shadPS4 compat: " + s));
                var (count, error) = await Shadps4Compat.DownloadAsync(progress);
                if (error != null)
                {
                    ShowError("Failed to download shadPS4 compatibility data: " + error, true);
                    return;
                }
                ShowInformation($"shadPS4 compatibility data downloaded ({count} games).", true);
                labelShadps4JsonDate.Text = Shadps4Compat.LastDownload?.ToString("d MMMM yyyy", CultureInfo.InvariantCulture) ?? "..";
            }
            catch (Exception ex)
            {
                ShowError("Failed to download shadPS4 compatibility data: " + ex.Message, true);
            }
            finally
            {
                btnDownloadShadps4Json.Enabled = true;
                btnDownloadShadps4Json.Text = "Download compat data";
            }
        }

        /// <summary>
        /// Opens the shadPS4 Manager on its Settings tab - the shadPS4
        /// paths and detection now live there; this tab only keeps the
        /// compatibility database controls.
        /// </summary>
        private void btnOpenShadps4Manager_Click(object sender, EventArgs e)
        {
            using var dlg = new Shadps4Manager(appSettings_, Shadps4Manager.SettingsTabIndex);
            dlg.ShowDialog(this);
        }

        private static void ShowTaskbarNotification(string title, string text)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = AppIcon;
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(3000); // Display the balloon tip for 3 seconds

            // Clean up when done
            notifyIcon.Dispose();
        }

        private void cbPs5BcCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPs5BcCheck.Checked)
                Refresh = true;
        }

        private void PlaceholderButton_Click(object sender, EventArgs e)
        {
            if (sender is DarkUI.Controls.DarkButton btn && btn.Tag != null)
            {
                string tag = btn.Tag.ToString();
                int pos = tbCustomNamePattern.SelectionStart;
                tbCustomNamePattern.Text = tbCustomNamePattern.Text.Insert(pos, tag);
                tbCustomNamePattern.SelectionStart = pos + tag.Length;
                tbCustomNamePattern.Focus();
            }
        }

        private void tbCustomNamePattern_TextChanged(object sender, EventArgs e)
        {
            darkLabelNamingPatternExample.Text = tbCustomNamePattern.Text
                    .Replace("{TITLE}", TITLE)
                    .Replace("{TITLE_ID}", TITLE_ID)
                    .Replace("{VERSION}", VERSION)
                    .Replace("{APP_VERSION}", APP_VERSION)
                    .Replace("{CATEGORY}", CATEGORY)
                    .Replace("{CONTENT_ID}", CONTENT_ID)
                    .Replace("{CONTENT_ID2}", CONTENT_ID2)
                    .Replace("{REGION}", REGION)
                    .Replace("{SYSTEM_VERSION}", SYSTEM_VERSION);
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            tbCustomNamePattern.Text = "";
        }

        private void btnClearAllPkgDirectory_Click(object sender, EventArgs e)
        {
            lbPkgDirectoryList.Items.Clear();
        }

        private void btnDeletePkgDirectory_Click(object sender, EventArgs e)
        {
            if (lbPkgDirectoryList.SelectedItems.Count > 0)
            {
                int selectedIndex = lbPkgDirectoryList.SelectedIndex;
                lbPkgDirectoryList.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnAddPkgDirectory_Click(object sender, EventArgs e)
        {
            if (ShowFolderBrowserDialog(out FolderBrowserDialog fbd))
            {
                string selectedFolder = fbd.SelectedPath;

                if (lbPkgDirectoryList.Items.Contains(selectedFolder))
                {
                    ShowError("Path already added.", false);
                    return;
                }

                if (Tool.IsRootDrive(selectedFolder))
                {
                    DialogResult dialogResult = DialogResultYesNo("Scanning the whole drive may take some time. Are you sure you want to proceed?");
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                lbPkgDirectoryList.Items.Add(selectedFolder);
            }
        }

        private void btnOpenAppData_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(UserDataDirectory))
                Process.Start("explorer.exe", UserDataDirectory);
        }

        private void btnScanStagedPkgs_Click(object sender, EventArgs e)
        {
            // No-op: the staged-PKG recovery subsystem was removed with the
            // orbis-pub-cmd migration (the in-process reader never renames or
            // moves the package file, so no staging artifacts are ever created).
        }

        private void ProgramSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnBuildTrophyCache != null && !btnBuildTrophyCache.Enabled)
            {
                trophyCacheCancellation?.Cancel();
                lblTrophyCacheStatus.Text = "Cancelling trophy metadata cache build...";
                e.Cancel = true;
            }
        }

        private async void btnBuildTrophyCache_Click(object sender, EventArgs e)
        {
            List<string> directories = lbPkgDirectoryList.Items.Cast<string>().ToList();
            if (directories.Count == 0)
            {
                ShowWarning("Add at least one PKG directory before building the trophy metadata cache.", false);
                return;
            }

            trophyCacheCancellation?.Dispose();
            trophyCacheCancellation = new CancellationTokenSource();
            btnBuildTrophyCache.Enabled = false;
            btnClearTrophyCache.Enabled = false;
            btnCancelTrophyCache.Enabled = true;
            btnSaveClose.Enabled = false;
            lblTrophyCacheStatus.Text = "Scanning all configured PKG directories...";
            pbTrophyCacheProgress.Value = 0;

            var progress = new Progress<TrophyCacheProgress>(value =>
            {
                pbTrophyCacheProgress.Maximum = Math.Max(1, value.Total);
                pbTrophyCacheProgress.Value = Math.Min(pbTrophyCacheProgress.Maximum, Math.Max(0, value.Processed));
                lblTrophyCacheStatus.Text = value.Total == 0
                    ? value.CurrentFile
                    : $"{value.Processed}/{value.Total}  {value.CurrentFile}";
            });

            try
            {
                Logger.LogInformation("Building trophy metadata cache from configured PKG directories...");
                var builder = new TrophyMetadataCacheBuilder();
                // The cache must include packages stored below the configured roots,
                // independently of the normal library scan setting.
                TrophyCacheBuildResult result = await builder.BuildAsync(
                    directories: directories,
                    recursive: true,
                    cachePath: TrophyCachePath,
                    progress: progress,
                    cancellationToken: trophyCacheCancellation.Token);

                string summary = $"PKGs: {result.TotalPackages} | Added: {result.Added} | Cached: {result.AlreadyCached} | " +
                    $"No trophies: {result.WithoutTrophies} | Duplicates: {result.DuplicateContentIds} | Failed: {result.Failed}";
                lblTrophyCacheStatus.Text = (result.Cancelled ? "Cancelled. " : "Complete. ") + summary;
                Logger.LogInformation("Trophy metadata cache: " + lblTrophyCacheStatus.Text);
                foreach (string error in result.Errors)
                    Logger.LogWarning("Trophy cache: " + error);

                if (!result.Cancelled)
                    ShowInformation(summary, true);
            }
            catch (Exception ex)
            {
                lblTrophyCacheStatus.Text = "Cache build failed: " + ex.Message;
                Logger.LogError("Failed to build trophy metadata cache", ex);
                ShowError(lblTrophyCacheStatus.Text, true);
            }
            finally
            {
                btnBuildTrophyCache.Enabled = true;
                btnClearTrophyCache.Enabled = true;
                btnCancelTrophyCache.Enabled = false;
                btnSaveClose.Enabled = true;
            }
        }

        private void btnCancelTrophyCache_Click(object sender, EventArgs e)
        {
            trophyCacheCancellation?.Cancel();
        }

        private void btnClearTrophyCache_Click(object sender, EventArgs e)
        {
            if (DialogResultYesNo("Clear every cached NP Communication ID?") != DialogResult.Yes)
                return;
            try
            {
                new NpCommunicationIdCache(TrophyCachePath).Clear();
                UpdateTrophyCacheStatus();
                Logger.LogInformation("Trophy metadata cache cleared.");
            }
            catch (Exception ex)
            {
                ShowError("Failed to clear trophy metadata cache: " + ex.Message, true);
            }
        }

        private void UpdateTrophyCacheStatus()
        {
            try
            {
                int count = new NpCommunicationIdCache(TrophyCachePath).Count;
                lblTrophyCacheStatus.Text = $"Cached NP Communication IDs: {count}";
            }
            catch (Exception ex)
            {
                lblTrophyCacheStatus.Text = "Cache unavailable: " + ex.Message;
            }
        }
    }
}

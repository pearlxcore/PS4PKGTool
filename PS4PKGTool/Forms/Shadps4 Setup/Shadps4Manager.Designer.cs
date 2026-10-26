namespace PS4PKGTool
{
    partial class Shadps4Manager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblManagerHeaderState = new DarkUI.Controls.DarkLabel();
            ctxHeaderMore = new DarkUI.Controls.DarkContextMenu();
            miHeaderConfigFolder = new System.Windows.Forms.ToolStripMenuItem();
            miHeaderManagedBuilds = new System.Windows.Forms.ToolStripMenuItem();
            miHeaderGameLibrary = new System.Windows.Forms.ToolStripMenuItem();
            miHeaderCopyEnvironmentInfo = new System.Windows.Forms.ToolStripMenuItem();
            darkHeaderBar1 = new DarkUI.Controls.DarkHeaderBar();
            darkStatusStrip1 = new DarkUI.Controls.DarkStatusStrip();
            toolStripManagerStatus = new DarkUI.Controls.DarkToolStripStatusLabel();
            shadps4Tabs = new DarkUI.Controls.DarkSidebarTabControl();
            tabManagerOverview = new DarkUI.Controls.SidebarPage();
            grpOverviewDetails = new DarkUI.Controls.DarkSectionPanel();
            lblOverviewEnvDetails = new DarkUI.Controls.DarkLabel();
            btnManagerCopyEnvironmentInfo = new DarkUI.Controls.DarkButton();
            grpOverviewReports = new DarkUI.Controls.DarkSectionPanel();
            dgvOverviewReports = new DarkUI.Controls.DarkDataGridView();
            colReportTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colReportStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colReportCore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpOverviewCounts = new DarkUI.Controls.DarkSectionPanel();
            lblOverviewCounts = new DarkUI.Controls.DarkLabel();
            grpOverviewActions = new DarkUI.Controls.DarkSectionPanel();
            btnOverviewInstallUpdate = new DarkUI.Controls.DarkButton();
            btnOverviewOpenLibrary = new DarkUI.Controls.DarkButton();
            btnOverviewOpenShadps4Folder = new DarkUI.Controls.DarkButton();
            grpOverviewLauncher = new DarkUI.Controls.DarkSectionPanel();
            lblOverviewLauncherInfo = new DarkUI.Controls.DarkLabel();
            btnOverviewLauncherOpenFolder = new DarkUI.Controls.DarkButton();
            grpOverviewCore = new DarkUI.Controls.DarkSectionPanel();
            lblOverviewCoreInfo = new DarkUI.Controls.DarkLabel();
            btnOverviewCoreOpenFolder = new DarkUI.Controls.DarkButton();
            tabManagerGames = new DarkUI.Controls.SidebarPage();
            grpInstallActivity = new DarkUI.Controls.DarkSectionPanel();
            btnInstallDismiss = new DarkUI.Controls.DarkButton();
            btnInstallOpenFolder = new DarkUI.Controls.DarkButton();
            btnInstallCancel = new DarkUI.Controls.DarkButton();
            prgInstallProgress = new DarkUI.Controls.DarkProgressBar();
            lblInstallStage = new DarkUI.Controls.DarkLabel();
            lblInstallMeta = new DarkUI.Controls.DarkLabel();
            lblInstallTitle = new DarkUI.Controls.DarkLabel();
            lblManagerGamesHint = new DarkUI.Controls.DarkLabel();
            btnManagerGamesRefresh = new DarkUI.Controls.DarkButton();
            btnManagerGameMore = new DarkUI.Controls.DarkButton();
            btnManagerGameOpenFolder = new DarkUI.Controls.DarkButton();
            btnManagerGameReports = new DarkUI.Controls.DarkButton();
            btnManagerGameCreateReport = new DarkUI.Controls.DarkButton();
            btnManagerGameAddFeedback = new DarkUI.Controls.DarkButton();
            btnManagerGameLaunch = new DarkUI.Controls.DarkButton();
            lblGameDetailRecent = new DarkUI.Controls.DarkLabel();
            lblGameDetailRecentHeader = new DarkUI.Controls.DarkLabel();
            lblGameDetailPath = new DarkUI.Controls.DarkLabel();
            lblGameDetailSize = new DarkUI.Controls.DarkLabel();
            lblGameDetailBest = new DarkUI.Controls.DarkLabel();
            lblGameDetailReports = new DarkUI.Controls.DarkLabel();
            lblGameDetailLastTest = new DarkUI.Controls.DarkLabel();
            lblGameDetailCompat = new DarkUI.Controls.DarkLabel();
            lblGameDetailMeta = new DarkUI.Controls.DarkLabel();
            lblGameDetailTitle = new DarkUI.Controls.DarkLabel();
            picManagerGameIcon = new System.Windows.Forms.PictureBox();
            lvManagerGames = new DarkUI.Controls.DarkListView();
            imageListManagerGames = new System.Windows.Forms.ImageList(components);
            tabManagerBuilds = new DarkUI.Controls.SidebarPage();
            grpInstalledBuilds = new DarkUI.Controls.DarkSectionPanel();
            btnBuildRemove = new DarkUI.Controls.DarkButton();
            btnBuildOpenFolder = new DarkUI.Controls.DarkButton();
            btnBuildActivate = new DarkUI.Controls.DarkButton();
            tabsBuilds = new DarkUI.Controls.DarkTabControl();
            tabPageCore = new DarkUI.Controls.DarkTabPage();
            lstCoreBuilds = new DarkUI.Controls.DarkListBox(components);
            tabPageLauncher = new DarkUI.Controls.DarkTabPage();
            lstLauncherBuilds = new DarkUI.Controls.DarkListBox(components);
            grpCurrentSetup = new DarkUI.Controls.DarkSectionPanel();
            grpCoreCard = new DarkUI.Controls.DarkGroupBox();
            lblCoreCardState = new DarkUI.Controls.DarkLabel();
            lblCoreCardDate = new DarkUI.Controls.DarkLabel();
            lblCoreCardSha = new DarkUI.Controls.DarkLabel();
            btnCoreCardOpenFolder = new DarkUI.Controls.DarkButton();
            grpLauncherCard = new DarkUI.Controls.DarkGroupBox();
            lblLauncherCardState = new DarkUI.Controls.DarkLabel();
            lblLauncherCardDate = new DarkUI.Controls.DarkLabel();
            lblLauncherCardSha = new DarkUI.Controls.DarkLabel();
            btnLauncherCardOpenFolder = new DarkUI.Controls.DarkButton();
            btnInstallShadps4 = new DarkUI.Controls.DarkButton();
            btnChooseCoreVersion = new DarkUI.Controls.DarkButton();
            btnMaintenance = new DarkUI.Controls.DarkButton();
            lblStatus = new DarkUI.Controls.DarkLabel();
            tabManagerSaves = new DarkUI.Controls.SidebarPage();
            grpSavesSelected = new DarkUI.Controls.DarkSectionPanel();
            lblSaveGameTitle = new DarkUI.Controls.DarkLabel();
            lblSaveGameUser = new DarkUI.Controls.DarkLabel();
            lblSaveGamePath = new DarkUI.Controls.DarkLabel();
            lblSaveNotInstalled = new DarkUI.Controls.DarkLabel();
            lblManagerSavesHint = new DarkUI.Controls.DarkLabel();
            btnSavesRestore = new DarkUI.Controls.DarkButton();
            lstManagerSavesBackups = new DarkUI.Controls.DarkListBox(components);
            lblSavesBackupsHeader = new DarkUI.Controls.DarkLabel();
            lstManagerSavesSlots = new DarkUI.Controls.DarkListBox(components);
            lblSavesSlotsHeader = new DarkUI.Controls.DarkLabel();
            btnSavesOpenFolder = new DarkUI.Controls.DarkButton();
            btnSavesBackup = new DarkUI.Controls.DarkButton();
            lstManagerSaves = new DarkUI.Controls.DarkListBox(components);
            lblSavesHeader = new DarkUI.Controls.DarkLabel();
            tabManagerPatches = new DarkUI.Controls.SidebarPage();
            grpPatchesDefinitions = new DarkUI.Controls.DarkSectionPanel();
            tabsPatchesDefinitions = new DarkUI.Controls.DarkTabControl();
            tabCheatsDefinitions = new DarkUI.Controls.DarkTabPage();
            dgvPatchesCheats = new DarkUI.Controls.DarkDataGridView();
            colCheatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCheatVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCheatAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCheatOperations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCheatStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPatchDefinitions = new DarkUI.Controls.DarkTabPage();
            dgvPatches = new DarkUI.Controls.DarkDataGridView();
            colPatchEnabled = new DarkUI.Controls.DarkDataGridViewCheckBoxColumn();
            colPatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatchVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatchAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatchElf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatchOperations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPatchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnPatchesDownload = new DarkUI.Controls.DarkButton();
            btnPatchesApply = new DarkUI.Controls.DarkButton();
            btnPatchesRevert = new DarkUI.Controls.DarkButton();
            btnPatchesOpenData = new DarkUI.Controls.DarkButton();
            btnPatchesOpenQtLauncher = new DarkUI.Controls.DarkButton();
            lblPatchesHint = new DarkUI.Controls.DarkLabel();
            lblPatchesGame = new DarkUI.Controls.DarkLabel();
            cmbPatchesGame = new DarkUI.Controls.DarkComboBox();
            tabManagerSettings = new DarkUI.Controls.SidebarPage();
            grpSettingsDetection = new DarkUI.Controls.DarkSectionPanel();
            btncopyDetectioninfo = new DarkUI.Controls.DarkButton();
            lblSettingsDetect = new DarkUI.Controls.DarkLabel();
            grpSettingsUpdate = new DarkUI.Controls.DarkSectionPanel();
            btnSettingsCheckUpdates = new DarkUI.Controls.DarkButton();
            grpSettingsPaths = new DarkUI.Controls.DarkSectionPanel();
            btnSettingsConfigFolder = new DarkUI.Controls.DarkButton();
            btnSettingsInstallDirBrowse = new DarkUI.Controls.DarkButton();
            tbSettingsInstallDir = new DarkUI.Controls.DarkTextBox();
            darkLabelSettingsInstallDir = new DarkUI.Controls.DarkLabel();
            btnSettingsLauncherOpen = new DarkUI.Controls.DarkButton();
            btnSettingsLauncherBrowse = new DarkUI.Controls.DarkButton();
            tbSettingsLauncher = new DarkUI.Controls.DarkTextBox();
            darkLabelSettingsLauncher = new DarkUI.Controls.DarkLabel();
            btnSettingsCoreBrowse = new DarkUI.Controls.DarkButton();
            tbSettingsCore = new DarkUI.Controls.DarkTextBox();
            darkLabelSettingsCore = new DarkUI.Controls.DarkLabel();
            colGameTitle = new System.Windows.Forms.ColumnHeader();
            colGameTitleId = new System.Windows.Forms.ColumnHeader();
            colGameVersion = new System.Windows.Forms.ColumnHeader();
            colGameLastTest = new System.Windows.Forms.ColumnHeader();
            ctxGameMore = new DarkUI.Controls.DarkContextMenu();
            miGameAddReport = new System.Windows.Forms.ToolStripMenuItem();
            miGameCopyInfo = new System.Windows.Forms.ToolStripMenuItem();
            miGameUninstall = new System.Windows.Forms.ToolStripMenuItem();
            ctxMaintenance = new DarkUI.Controls.DarkContextMenu();
            miMaintenanceReset = new System.Windows.Forms.ToolStripMenuItem();
            miMaintenanceRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            miMaintenanceOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            toolTipBuilds = new DarkUI.Controls.DarkToolTip();
            components.Add(toolTipBuilds);
            ctxHeaderMore.SuspendLayout();
            darkStatusStrip1.SuspendLayout();
            shadps4Tabs.SuspendLayout();
            tabManagerOverview.SuspendLayout();
            grpOverviewDetails.SuspendLayout();
            grpOverviewReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverviewReports).BeginInit();
            grpOverviewCounts.SuspendLayout();
            grpOverviewActions.SuspendLayout();
            grpOverviewLauncher.SuspendLayout();
            grpOverviewCore.SuspendLayout();
            tabManagerGames.SuspendLayout();
            grpInstallActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picManagerGameIcon).BeginInit();
            tabManagerBuilds.SuspendLayout();
            grpInstalledBuilds.SuspendLayout();
            tabsBuilds.SuspendLayout();
            tabPageCore.SuspendLayout();
            tabPageLauncher.SuspendLayout();
            grpCurrentSetup.SuspendLayout();
            grpCoreCard.SuspendLayout();
            grpLauncherCard.SuspendLayout();
            tabManagerSaves.SuspendLayout();
            grpSavesSelected.SuspendLayout();
            tabManagerPatches.SuspendLayout();
            grpPatchesDefinitions.SuspendLayout();
            tabsPatchesDefinitions.SuspendLayout();
            tabCheatsDefinitions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatchesCheats).BeginInit();
            tabPatchDefinitions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatches).BeginInit();
            tabManagerSettings.SuspendLayout();
            grpSettingsDetection.SuspendLayout();
            grpSettingsUpdate.SuspendLayout();
            grpSettingsPaths.SuspendLayout();
            ctxGameMore.SuspendLayout();
            ctxMaintenance.SuspendLayout();
            SuspendLayout();
            // 
            // lblManagerHeaderState
            // 
            lblManagerHeaderState.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblManagerHeaderState.AutoEllipsis = true;
            lblManagerHeaderState.Location = new System.Drawing.Point(509, 10);
            lblManagerHeaderState.Name = "lblManagerHeaderState";
            lblManagerHeaderState.Size = new System.Drawing.Size(364, 18);
            lblManagerHeaderState.TabIndex = 2;
            lblManagerHeaderState.Text = "Loading environment...";
            lblManagerHeaderState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctxHeaderMore
            // 
            ctxHeaderMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            ctxHeaderMore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { miHeaderConfigFolder, miHeaderManagedBuilds, miHeaderGameLibrary, miHeaderCopyEnvironmentInfo });
            ctxHeaderMore.Name = "ctxHeaderMore";
            ctxHeaderMore.Size = new System.Drawing.Size(228, 92);
            // 
            // miHeaderConfigFolder
            // 
            miHeaderConfigFolder.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miHeaderConfigFolder.Name = "miHeaderConfigFolder";
            miHeaderConfigFolder.Size = new System.Drawing.Size(227, 22);
            miHeaderConfigFolder.Text = "Open Config Folder";
            miHeaderConfigFolder.Click += miHeaderConfigFolder_Click;
            // 
            // miHeaderManagedBuilds
            // 
            miHeaderManagedBuilds.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miHeaderManagedBuilds.Name = "miHeaderManagedBuilds";
            miHeaderManagedBuilds.Size = new System.Drawing.Size(227, 22);
            miHeaderManagedBuilds.Text = "Open Managed Builds Folder";
            miHeaderManagedBuilds.Click += miHeaderManagedBuilds_Click;
            // 
            // miHeaderGameLibrary
            // 
            miHeaderGameLibrary.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miHeaderGameLibrary.Name = "miHeaderGameLibrary";
            miHeaderGameLibrary.Size = new System.Drawing.Size(227, 22);
            miHeaderGameLibrary.Text = "Open Game Library";
            miHeaderGameLibrary.Click += miHeaderGameLibrary_Click;
            // 
            // miHeaderCopyEnvironmentInfo
            // 
            miHeaderCopyEnvironmentInfo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miHeaderCopyEnvironmentInfo.Name = "miHeaderCopyEnvironmentInfo";
            miHeaderCopyEnvironmentInfo.Size = new System.Drawing.Size(227, 22);
            miHeaderCopyEnvironmentInfo.Text = "Copy Environment Info";
            miHeaderCopyEnvironmentInfo.Click += miHeaderCopyEnvironmentInfo_Click;
            // 
            // darkHeaderBar1
            // 
            darkHeaderBar1.Dock = System.Windows.Forms.DockStyle.Top;
            darkHeaderBar1.Location = new System.Drawing.Point(0, 0);
            darkHeaderBar1.Name = "darkHeaderBar1";
            darkHeaderBar1.ShowThemeSelector = false;
            darkHeaderBar1.Size = new System.Drawing.Size(887, 40);
            darkHeaderBar1.TabIndex = 3;
            // 
            // darkStatusStrip1
            // 
            darkStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripManagerStatus });
            darkStatusStrip1.Location = new System.Drawing.Point(0, 856);
            darkStatusStrip1.Name = "darkStatusStrip1";
            darkStatusStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            darkStatusStrip1.Size = new System.Drawing.Size(887, 28);
            darkStatusStrip1.TabIndex = 4;
            darkStatusStrip1.Text = "darkStatusStrip1";
            // 
            // toolStripManagerStatus
            // 
            toolStripManagerStatus.Name = "toolStripManagerStatus";
            toolStripManagerStatus.Size = new System.Drawing.Size(0, 0);
            toolStripManagerStatus.Spring = true;
            toolStripManagerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shadps4Tabs
            // 
            shadps4Tabs.AllowDrop = true;
            shadps4Tabs.AllowSidebarResize = false;
            shadps4Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            shadps4Tabs.Location = new System.Drawing.Point(0, 40);
            shadps4Tabs.Name = "shadps4Tabs";
            shadps4Tabs.Pages.AddRange(new DarkUI.Controls.SidebarPage[] { tabManagerOverview, tabManagerGames, tabManagerBuilds, tabManagerSaves, tabManagerPatches, tabManagerSettings });
            shadps4Tabs.SidebarWidth = 122;
            shadps4Tabs.Size = new System.Drawing.Size(887, 816);
            shadps4Tabs.TabIndex = 2;
            shadps4Tabs.SelectedIndexChanged += shadps4Tabs_SelectedIndexChanged;
            // 
            // tabManagerOverview
            // 
            tabManagerOverview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerOverview.Controls.Add(grpOverviewDetails);
            tabManagerOverview.Controls.Add(grpOverviewReports);
            tabManagerOverview.Controls.Add(grpOverviewCounts);
            tabManagerOverview.Controls.Add(grpOverviewActions);
            tabManagerOverview.Controls.Add(grpOverviewLauncher);
            tabManagerOverview.Controls.Add(grpOverviewCore);
            tabManagerOverview.Location = new System.Drawing.Point(122, 0);
            tabManagerOverview.Name = "tabManagerOverview";
            tabManagerOverview.Padding = new System.Windows.Forms.Padding(12);
            tabManagerOverview.Size = new System.Drawing.Size(765, 816);
            tabManagerOverview.TabIndex = 0;
            tabManagerOverview.Text = "Overview";
            // 
            // grpOverviewDetails
            // 
            grpOverviewDetails.Controls.Add(lblOverviewEnvDetails);
            grpOverviewDetails.Controls.Add(btnManagerCopyEnvironmentInfo);
            grpOverviewDetails.Location = new System.Drawing.Point(12, 632);
            grpOverviewDetails.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewDetails.Name = "grpOverviewDetails";
            grpOverviewDetails.Padding = new System.Windows.Forms.Padding(12);
            grpOverviewDetails.SectionHeader = "Environment Details";
            grpOverviewDetails.Size = new System.Drawing.Size(738, 175);
            grpOverviewDetails.TabIndex = 5;
            // 
            // lblOverviewEnvDetails
            // 
            lblOverviewEnvDetails.AutoEllipsis = true;
            lblOverviewEnvDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblOverviewEnvDetails.Location = new System.Drawing.Point(13, 37);
            lblOverviewEnvDetails.Name = "lblOverviewEnvDetails";
            lblOverviewEnvDetails.Size = new System.Drawing.Size(561, 125);
            lblOverviewEnvDetails.TabIndex = 0;
            lblOverviewEnvDetails.Text = "Loading...";
            // 
            // btnManagerCopyEnvironmentInfo
            // 
            btnManagerCopyEnvironmentInfo.Location = new System.Drawing.Point(580, 136);
            btnManagerCopyEnvironmentInfo.Name = "btnManagerCopyEnvironmentInfo";
            btnManagerCopyEnvironmentInfo.Size = new System.Drawing.Size(145, 26);
            btnManagerCopyEnvironmentInfo.TabIndex = 1;
            btnManagerCopyEnvironmentInfo.Text = "Copy Environment Info";
            btnManagerCopyEnvironmentInfo.Click += btnManagerCopyEnvironmentInfo_Click;
            // 
            // grpOverviewReports
            // 
            grpOverviewReports.Controls.Add(dgvOverviewReports);
            grpOverviewReports.Location = new System.Drawing.Point(12, 286);
            grpOverviewReports.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewReports.Name = "grpOverviewReports";
            grpOverviewReports.SectionHeader = "Latest Reports";
            grpOverviewReports.Size = new System.Drawing.Size(738, 334);
            grpOverviewReports.TabIndex = 4;
            // 
            // dgvOverviewReports
            // 
            dgvOverviewReports.AllowUserToAddRows = false;
            dgvOverviewReports.AllowUserToDeleteRows = false;
            dgvOverviewReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverviewReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colReportTitle, colReportDate, colReportStatus, colReportCore });
            dgvOverviewReports.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvOverviewReports.Location = new System.Drawing.Point(1, 25);
            dgvOverviewReports.Name = "dgvOverviewReports";
            dgvOverviewReports.ReadOnly = true;
            dgvOverviewReports.Size = new System.Drawing.Size(736, 308);
            dgvOverviewReports.TabIndex = 0;
            dgvOverviewReports.CellDoubleClick += dgvOverviewReports_CellDoubleClick;
            // 
            // colReportTitle
            // 
            colReportTitle.HeaderText = "Title";
            colReportTitle.Name = "colReportTitle";
            colReportTitle.ReadOnly = true;
            // 
            // colReportDate
            // 
            colReportDate.FillWeight = 30F;
            colReportDate.HeaderText = "Date";
            colReportDate.Name = "colReportDate";
            colReportDate.ReadOnly = true;
            // 
            // colReportStatus
            // 
            colReportStatus.FillWeight = 30F;
            colReportStatus.HeaderText = "Status";
            colReportStatus.Name = "colReportStatus";
            colReportStatus.ReadOnly = true;
            // 
            // colReportCore
            // 
            colReportCore.FillWeight = 40F;
            colReportCore.HeaderText = "Core";
            colReportCore.Name = "colReportCore";
            colReportCore.ReadOnly = true;
            // 
            // grpOverviewCounts
            // 
            grpOverviewCounts.Controls.Add(lblOverviewCounts);
            grpOverviewCounts.Location = new System.Drawing.Point(12, 206);
            grpOverviewCounts.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewCounts.Name = "grpOverviewCounts";
            grpOverviewCounts.Padding = new System.Windows.Forms.Padding(12);
            grpOverviewCounts.SectionHeader = "Counts";
            grpOverviewCounts.Size = new System.Drawing.Size(738, 68);
            grpOverviewCounts.TabIndex = 3;
            // 
            // lblOverviewCounts
            // 
            lblOverviewCounts.AutoEllipsis = true;
            lblOverviewCounts.Location = new System.Drawing.Point(13, 37);
            lblOverviewCounts.Name = "lblOverviewCounts";
            lblOverviewCounts.Size = new System.Drawing.Size(712, 18);
            lblOverviewCounts.TabIndex = 0;
            lblOverviewCounts.Text = "Loading...";
            // 
            // grpOverviewActions
            // 
            grpOverviewActions.Controls.Add(btnOverviewInstallUpdate);
            grpOverviewActions.Controls.Add(btnOverviewOpenLibrary);
            grpOverviewActions.Controls.Add(btnOverviewOpenShadps4Folder);
            grpOverviewActions.Location = new System.Drawing.Point(12, 118);
            grpOverviewActions.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewActions.Name = "grpOverviewActions";
            grpOverviewActions.Padding = new System.Windows.Forms.Padding(12);
            grpOverviewActions.SectionHeader = "Quick Actions";
            grpOverviewActions.Size = new System.Drawing.Size(738, 76);
            grpOverviewActions.TabIndex = 2;
            // 
            // btnOverviewInstallUpdate
            // 
            btnOverviewInstallUpdate.Location = new System.Drawing.Point(13, 37);
            btnOverviewInstallUpdate.Name = "btnOverviewInstallUpdate";
            btnOverviewInstallUpdate.Size = new System.Drawing.Size(200, 26);
            btnOverviewInstallUpdate.TabIndex = 0;
            btnOverviewInstallUpdate.Text = "Install/Update shadPS4...";
            btnOverviewInstallUpdate.Click += btnOverviewInstallUpdate_Click;
            // 
            // btnOverviewOpenLibrary
            // 
            btnOverviewOpenLibrary.Location = new System.Drawing.Point(221, 37);
            btnOverviewOpenLibrary.Name = "btnOverviewOpenLibrary";
            btnOverviewOpenLibrary.Size = new System.Drawing.Size(160, 26);
            btnOverviewOpenLibrary.TabIndex = 1;
            btnOverviewOpenLibrary.Text = "Open Game Library";
            btnOverviewOpenLibrary.Click += btnOverviewOpenLibrary_Click;
            // 
            // btnOverviewOpenShadps4Folder
            // 
            btnOverviewOpenShadps4Folder.Location = new System.Drawing.Point(389, 37);
            btnOverviewOpenShadps4Folder.Name = "btnOverviewOpenShadps4Folder";
            btnOverviewOpenShadps4Folder.Size = new System.Drawing.Size(150, 26);
            btnOverviewOpenShadps4Folder.TabIndex = 2;
            btnOverviewOpenShadps4Folder.Text = "Open shadPS4 Folder";
            btnOverviewOpenShadps4Folder.Click += btnOverviewOpenShadps4Folder_Click;
            // 
            // grpOverviewLauncher
            // 
            grpOverviewLauncher.Controls.Add(lblOverviewLauncherInfo);
            grpOverviewLauncher.Controls.Add(btnOverviewLauncherOpenFolder);
            grpOverviewLauncher.Location = new System.Drawing.Point(386, 12);
            grpOverviewLauncher.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewLauncher.Name = "grpOverviewLauncher";
            grpOverviewLauncher.Padding = new System.Windows.Forms.Padding(12);
            grpOverviewLauncher.SectionHeader = "QtLauncher";
            grpOverviewLauncher.Size = new System.Drawing.Size(364, 94);
            grpOverviewLauncher.TabIndex = 1;
            // 
            // lblOverviewLauncherInfo
            // 
            lblOverviewLauncherInfo.AutoEllipsis = true;
            lblOverviewLauncherInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewLauncherInfo.Location = new System.Drawing.Point(13, 37);
            lblOverviewLauncherInfo.Name = "lblOverviewLauncherInfo";
            lblOverviewLauncherInfo.Size = new System.Drawing.Size(210, 44);
            lblOverviewLauncherInfo.TabIndex = 0;
            lblOverviewLauncherInfo.Text = "(not set)";
            // 
            // btnOverviewLauncherOpenFolder
            // 
            btnOverviewLauncherOpenFolder.Location = new System.Drawing.Point(230, 37);
            btnOverviewLauncherOpenFolder.Name = "btnOverviewLauncherOpenFolder";
            btnOverviewLauncherOpenFolder.Size = new System.Drawing.Size(120, 26);
            btnOverviewLauncherOpenFolder.TabIndex = 1;
            btnOverviewLauncherOpenFolder.Text = "Open Folder";
            btnOverviewLauncherOpenFolder.Click += btnOverviewLauncherOpenFolder_Click;
            // 
            // grpOverviewCore
            // 
            grpOverviewCore.Controls.Add(lblOverviewCoreInfo);
            grpOverviewCore.Controls.Add(btnOverviewCoreOpenFolder);
            grpOverviewCore.Location = new System.Drawing.Point(12, 12);
            grpOverviewCore.Margin = new System.Windows.Forms.Padding(6);
            grpOverviewCore.Name = "grpOverviewCore";
            grpOverviewCore.Padding = new System.Windows.Forms.Padding(12);
            grpOverviewCore.SectionHeader = "shadPS4 Core";
            grpOverviewCore.Size = new System.Drawing.Size(362, 94);
            grpOverviewCore.TabIndex = 0;
            // 
            // lblOverviewCoreInfo
            // 
            lblOverviewCoreInfo.AutoEllipsis = true;
            lblOverviewCoreInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewCoreInfo.Location = new System.Drawing.Point(13, 37);
            lblOverviewCoreInfo.Name = "lblOverviewCoreInfo";
            lblOverviewCoreInfo.Size = new System.Drawing.Size(210, 44);
            lblOverviewCoreInfo.TabIndex = 0;
            lblOverviewCoreInfo.Text = "(not set)";
            // 
            // btnOverviewCoreOpenFolder
            // 
            btnOverviewCoreOpenFolder.Location = new System.Drawing.Point(229, 37);
            btnOverviewCoreOpenFolder.Name = "btnOverviewCoreOpenFolder";
            btnOverviewCoreOpenFolder.Size = new System.Drawing.Size(120, 26);
            btnOverviewCoreOpenFolder.TabIndex = 1;
            btnOverviewCoreOpenFolder.Text = "Open Folder";
            btnOverviewCoreOpenFolder.Click += btnOverviewCoreOpenFolder_Click;
            // 
            // tabManagerGames
            // 
            tabManagerGames.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerGames.Controls.Add(grpInstallActivity);
            tabManagerGames.Controls.Add(lblManagerGamesHint);
            tabManagerGames.Controls.Add(btnManagerGamesRefresh);
            tabManagerGames.Controls.Add(btnManagerGameMore);
            tabManagerGames.Controls.Add(btnManagerGameOpenFolder);
            tabManagerGames.Controls.Add(btnManagerGameReports);
            tabManagerGames.Controls.Add(btnManagerGameCreateReport);
            tabManagerGames.Controls.Add(btnManagerGameAddFeedback);
            tabManagerGames.Controls.Add(btnManagerGameLaunch);
            tabManagerGames.Controls.Add(lblGameDetailRecent);
            tabManagerGames.Controls.Add(lblGameDetailRecentHeader);
            tabManagerGames.Controls.Add(lblGameDetailPath);
            tabManagerGames.Controls.Add(lblGameDetailSize);
            tabManagerGames.Controls.Add(lblGameDetailBest);
            tabManagerGames.Controls.Add(lblGameDetailReports);
            tabManagerGames.Controls.Add(lblGameDetailLastTest);
            tabManagerGames.Controls.Add(lblGameDetailCompat);
            tabManagerGames.Controls.Add(lblGameDetailMeta);
            tabManagerGames.Controls.Add(lblGameDetailTitle);
            tabManagerGames.Controls.Add(picManagerGameIcon);
            tabManagerGames.Controls.Add(lvManagerGames);
            tabManagerGames.Location = new System.Drawing.Point(122, 0);
            tabManagerGames.Name = "tabManagerGames";
            tabManagerGames.Padding = new System.Windows.Forms.Padding(12);
            tabManagerGames.Size = new System.Drawing.Size(765, 816);
            tabManagerGames.TabIndex = 1;
            tabManagerGames.Text = "Games";
            // 
            // grpInstallActivity
            // 
            grpInstallActivity.Controls.Add(btnInstallDismiss);
            grpInstallActivity.Controls.Add(btnInstallOpenFolder);
            grpInstallActivity.Controls.Add(btnInstallCancel);
            grpInstallActivity.Controls.Add(prgInstallProgress);
            grpInstallActivity.Controls.Add(lblInstallStage);
            grpInstallActivity.Controls.Add(lblInstallMeta);
            grpInstallActivity.Controls.Add(lblInstallTitle);
            grpInstallActivity.Location = new System.Drawing.Point(12, 656);
            grpInstallActivity.Margin = new System.Windows.Forms.Padding(6);
            grpInstallActivity.Name = "grpInstallActivity";
            grpInstallActivity.Padding = new System.Windows.Forms.Padding(12);
            grpInstallActivity.SectionHeader = "Installation";
            grpInstallActivity.Size = new System.Drawing.Size(735, 126);
            grpInstallActivity.TabIndex = 30;
            grpInstallActivity.Visible = false;
            // 
            // btnInstallDismiss
            // 
            btnInstallDismiss.Location = new System.Drawing.Point(526, 89);
            btnInstallDismiss.Name = "btnInstallDismiss";
            btnInstallDismiss.Size = new System.Drawing.Size(84, 24);
            btnInstallDismiss.TabIndex = 7;
            btnInstallDismiss.Text = "Dismiss";
            btnInstallDismiss.Click += btnInstallDismiss_Click;
            // 
            // btnInstallOpenFolder
            // 
            btnInstallOpenFolder.Location = new System.Drawing.Point(618, 89);
            btnInstallOpenFolder.Name = "btnInstallOpenFolder";
            btnInstallOpenFolder.Size = new System.Drawing.Size(100, 24);
            btnInstallOpenFolder.TabIndex = 6;
            btnInstallOpenFolder.Text = "Open Folder";
            btnInstallOpenFolder.Click += btnInstallOpenFolder_Click;
            // 
            // btnInstallCancel
            // 
            btnInstallCancel.Location = new System.Drawing.Point(526, 89);
            btnInstallCancel.Name = "btnInstallCancel";
            btnInstallCancel.Size = new System.Drawing.Size(84, 24);
            btnInstallCancel.TabIndex = 4;
            btnInstallCancel.Text = "Cancel";
            btnInstallCancel.Click += btnInstallCancel_Click;
            // 
            // prgInstallProgress
            // 
            prgInstallProgress.Location = new System.Drawing.Point(13, 93);
            prgInstallProgress.Name = "prgInstallProgress";
            prgInstallProgress.Size = new System.Drawing.Size(500, 16);
            prgInstallProgress.TabIndex = 3;
            prgInstallProgress.TextMode = DarkUI.Controls.DarkProgressBarMode.NoText;
            // 
            // lblInstallStage
            // 
            lblInstallStage.AutoEllipsis = true;
            lblInstallStage.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblInstallStage.Location = new System.Drawing.Point(13, 75);
            lblInstallStage.Name = "lblInstallStage";
            lblInstallStage.Size = new System.Drawing.Size(712, 16);
            lblInstallStage.TabIndex = 2;
            // 
            // lblInstallMeta
            // 
            lblInstallMeta.AutoEllipsis = true;
            lblInstallMeta.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblInstallMeta.Location = new System.Drawing.Point(13, 58);
            lblInstallMeta.Name = "lblInstallMeta";
            lblInstallMeta.Size = new System.Drawing.Size(712, 16);
            lblInstallMeta.TabIndex = 1;
            // 
            // lblInstallTitle
            // 
            lblInstallTitle.AutoEllipsis = true;
            lblInstallTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblInstallTitle.Location = new System.Drawing.Point(13, 37);
            lblInstallTitle.Name = "lblInstallTitle";
            lblInstallTitle.Size = new System.Drawing.Size(712, 20);
            lblInstallTitle.TabIndex = 0;
            // 
            // lblManagerGamesHint
            // 
            lblManagerGamesHint.AutoEllipsis = true;
            lblManagerGamesHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblManagerGamesHint.Location = new System.Drawing.Point(12, 631);
            lblManagerGamesHint.Name = "lblManagerGamesHint";
            lblManagerGamesHint.Size = new System.Drawing.Size(752, 16);
            lblManagerGamesHint.TabIndex = 14;
            lblManagerGamesHint.Text = "Installed games in the install directory.";
            // 
            // btnManagerGamesRefresh
            // 
            btnManagerGamesRefresh.Location = new System.Drawing.Point(367, 590);
            btnManagerGamesRefresh.Name = "btnManagerGamesRefresh";
            btnManagerGamesRefresh.Size = new System.Drawing.Size(94, 26);
            btnManagerGamesRefresh.TabIndex = 16;
            btnManagerGamesRefresh.Text = "Refresh";
            btnManagerGamesRefresh.Click += btnManagerGamesRefresh_Click;
            // 
            // btnManagerGameMore
            // 
            btnManagerGameMore.Location = new System.Drawing.Point(690, 470);
            btnManagerGameMore.Name = "btnManagerGameMore";
            btnManagerGameMore.Size = new System.Drawing.Size(57, 26);
            btnManagerGameMore.TabIndex = 15;
            btnManagerGameMore.Text = "...";
            btnManagerGameMore.Click += btnManagerGameMore_Click;
            // 
            // btnManagerGameOpenFolder
            // 
            btnManagerGameOpenFolder.Location = new System.Drawing.Point(566, 470);
            btnManagerGameOpenFolder.Name = "btnManagerGameOpenFolder";
            btnManagerGameOpenFolder.Size = new System.Drawing.Size(118, 26);
            btnManagerGameOpenFolder.TabIndex = 14;
            btnManagerGameOpenFolder.Text = "Open Folder";
            btnManagerGameOpenFolder.Click += btnManagerGameOpenFolder_Click;
            // 
            // btnManagerGameReports
            // 
            btnManagerGameReports.Location = new System.Drawing.Point(476, 470);
            btnManagerGameReports.Name = "btnManagerGameReports";
            btnManagerGameReports.Size = new System.Drawing.Size(84, 26);
            btnManagerGameReports.TabIndex = 13;
            btnManagerGameReports.Text = "Results";
            btnManagerGameReports.Click += btnManagerGameReports_Click;
            // 
            // btnManagerGameCreateReport
            // 
            btnManagerGameCreateReport.Location = new System.Drawing.Point(616, 436);
            btnManagerGameCreateReport.Name = "btnManagerGameCreateReport";
            btnManagerGameCreateReport.Size = new System.Drawing.Size(131, 26);
            btnManagerGameCreateReport.TabIndex = 12;
            btnManagerGameCreateReport.Text = "Create Report";
            btnManagerGameCreateReport.Click += btnManagerGameCreateReport_Click;
            // 
            // btnManagerGameAddFeedback
            // 
            btnManagerGameAddFeedback.Location = new System.Drawing.Point(476, 436);
            btnManagerGameAddFeedback.Name = "btnManagerGameAddFeedback";
            btnManagerGameAddFeedback.Size = new System.Drawing.Size(131, 26);
            btnManagerGameAddFeedback.TabIndex = 11;
            btnManagerGameAddFeedback.Text = "Add Test Result";
            btnManagerGameAddFeedback.Click += btnManagerGameAddFeedback_Click;
            // 
            // btnManagerGameLaunch
            // 
            btnManagerGameLaunch.Location = new System.Drawing.Point(476, 402);
            btnManagerGameLaunch.Name = "btnManagerGameLaunch";
            btnManagerGameLaunch.Size = new System.Drawing.Size(271, 26);
            btnManagerGameLaunch.TabIndex = 10;
            btnManagerGameLaunch.Text = "Launch";
            btnManagerGameLaunch.Click += btnManagerGameLaunch_Click;
            // 
            // lblGameDetailRecent
            // 
            lblGameDetailRecent.AutoEllipsis = true;
            lblGameDetailRecent.Location = new System.Drawing.Point(476, 524);
            lblGameDetailRecent.Name = "lblGameDetailRecent";
            lblGameDetailRecent.Size = new System.Drawing.Size(271, 48);
            lblGameDetailRecent.TabIndex = 17;
            // 
            // lblGameDetailRecentHeader
            // 
            lblGameDetailRecentHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblGameDetailRecentHeader.Location = new System.Drawing.Point(476, 506);
            lblGameDetailRecentHeader.Name = "lblGameDetailRecentHeader";
            lblGameDetailRecentHeader.Size = new System.Drawing.Size(280, 16);
            lblGameDetailRecentHeader.TabIndex = 16;
            lblGameDetailRecentHeader.Text = "Recent Results";
            // 
            // lblGameDetailPath
            // 
            lblGameDetailPath.AutoEllipsis = true;
            lblGameDetailPath.Location = new System.Drawing.Point(476, 576);
            lblGameDetailPath.Name = "lblGameDetailPath";
            lblGameDetailPath.Size = new System.Drawing.Size(280, 40);
            lblGameDetailPath.TabIndex = 18;
            // 
            // lblGameDetailSize
            // 
            lblGameDetailSize.AutoEllipsis = true;
            lblGameDetailSize.Location = new System.Drawing.Point(476, 373);
            lblGameDetailSize.Name = "lblGameDetailSize";
            lblGameDetailSize.Size = new System.Drawing.Size(158, 18);
            lblGameDetailSize.TabIndex = 8;
            // 
            // lblGameDetailBest
            // 
            lblGameDetailBest.AutoEllipsis = true;
            lblGameDetailBest.Location = new System.Drawing.Point(476, 353);
            lblGameDetailBest.Name = "lblGameDetailBest";
            lblGameDetailBest.Size = new System.Drawing.Size(158, 18);
            lblGameDetailBest.TabIndex = 7;
            // 
            // lblGameDetailReports
            // 
            lblGameDetailReports.AutoEllipsis = true;
            lblGameDetailReports.Location = new System.Drawing.Point(476, 333);
            lblGameDetailReports.Name = "lblGameDetailReports";
            lblGameDetailReports.Size = new System.Drawing.Size(158, 18);
            lblGameDetailReports.TabIndex = 6;
            // 
            // lblGameDetailLastTest
            // 
            lblGameDetailLastTest.AutoEllipsis = true;
            lblGameDetailLastTest.Location = new System.Drawing.Point(476, 313);
            lblGameDetailLastTest.Name = "lblGameDetailLastTest";
            lblGameDetailLastTest.Size = new System.Drawing.Size(158, 18);
            lblGameDetailLastTest.TabIndex = 5;
            // 
            // lblGameDetailCompat
            // 
            lblGameDetailCompat.AutoEllipsis = true;
            lblGameDetailCompat.Location = new System.Drawing.Point(476, 293);
            lblGameDetailCompat.Name = "lblGameDetailCompat";
            lblGameDetailCompat.Size = new System.Drawing.Size(158, 18);
            lblGameDetailCompat.TabIndex = 4;
            // 
            // lblGameDetailMeta
            // 
            lblGameDetailMeta.AutoEllipsis = true;
            lblGameDetailMeta.Location = new System.Drawing.Point(476, 259);
            lblGameDetailMeta.Name = "lblGameDetailMeta";
            lblGameDetailMeta.Size = new System.Drawing.Size(158, 30);
            lblGameDetailMeta.TabIndex = 3;
            // 
            // lblGameDetailTitle
            // 
            lblGameDetailTitle.AutoEllipsis = true;
            lblGameDetailTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblGameDetailTitle.Location = new System.Drawing.Point(476, 215);
            lblGameDetailTitle.Name = "lblGameDetailTitle";
            lblGameDetailTitle.Size = new System.Drawing.Size(158, 40);
            lblGameDetailTitle.TabIndex = 2;
            lblGameDetailTitle.Text = "Select a game";
            // 
            // picManagerGameIcon
            // 
            picManagerGameIcon.Location = new System.Drawing.Point(476, 12);
            picManagerGameIcon.Name = "picManagerGameIcon";
            picManagerGameIcon.Size = new System.Drawing.Size(271, 200);
            picManagerGameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picManagerGameIcon.TabIndex = 1;
            picManagerGameIcon.TabStop = false;
            // 
            // lvManagerGames
            // 
            lvManagerGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colGameTitle, colGameTitleId, colGameVersion, colGameLastTest });
            lvManagerGames.FullRowSelect = true;
            lvManagerGames.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            lvManagerGames.LargeImageList = null;
            lvManagerGames.ListViewItemSorter = null;
            lvManagerGames.Location = new System.Drawing.Point(12, 12);
            lvManagerGames.MultiSelect = false;
            lvManagerGames.Name = "lvManagerGames";
            lvManagerGames.Size = new System.Drawing.Size(449, 572);
            lvManagerGames.SmallImageList = imageListManagerGames;
            lvManagerGames.TabIndex = 0;
            lvManagerGames.UseCompatibleStateImageBehavior = false;
            lvManagerGames.View = System.Windows.Forms.View.Details;
            lvManagerGames.SelectedIndexChanged += lvManagerGames_SelectedIndexChanged;
            // 
            // imageListManagerGames
            // 
            imageListManagerGames.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageListManagerGames.ImageSize = new System.Drawing.Size(24, 24);
            imageListManagerGames.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabManagerBuilds
            // 
            tabManagerBuilds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerBuilds.Controls.Add(grpInstalledBuilds);
            tabManagerBuilds.Controls.Add(grpCurrentSetup);
            tabManagerBuilds.Controls.Add(btnInstallShadps4);
            tabManagerBuilds.Controls.Add(btnChooseCoreVersion);
            tabManagerBuilds.Controls.Add(btnMaintenance);
            tabManagerBuilds.Controls.Add(lblStatus);
            tabManagerBuilds.Location = new System.Drawing.Point(122, 0);
            tabManagerBuilds.Name = "tabManagerBuilds";
            tabManagerBuilds.Padding = new System.Windows.Forms.Padding(12);
            tabManagerBuilds.Size = new System.Drawing.Size(765, 816);
            tabManagerBuilds.TabIndex = 2;
            tabManagerBuilds.Text = "Builds";
            // 
            // grpInstalledBuilds
            // 
            grpInstalledBuilds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpInstalledBuilds.Controls.Add(btnBuildRemove);
            grpInstalledBuilds.Controls.Add(btnBuildOpenFolder);
            grpInstalledBuilds.Controls.Add(btnBuildActivate);
            grpInstalledBuilds.Controls.Add(tabsBuilds);
            grpInstalledBuilds.Location = new System.Drawing.Point(12, 169);
            grpInstalledBuilds.Margin = new System.Windows.Forms.Padding(6);
            grpInstalledBuilds.Name = "grpInstalledBuilds";
            grpInstalledBuilds.Padding = new System.Windows.Forms.Padding(12);
            grpInstalledBuilds.SectionHeader = "Installed Builds";
            grpInstalledBuilds.Size = new System.Drawing.Size(739, 422);
            grpInstalledBuilds.TabIndex = 3;
            // 
            // btnBuildRemove
            // 
            btnBuildRemove.Location = new System.Drawing.Point(249, 383);
            btnBuildRemove.Name = "btnBuildRemove";
            btnBuildRemove.Size = new System.Drawing.Size(110, 26);
            btnBuildRemove.TabIndex = 3;
            btnBuildRemove.Text = "Remove";
            toolTipBuilds.SetToolTip(btnBuildRemove, "Delete the selected build folder. The active build cannot be removed.");
            btnBuildRemove.Click += btnBuildRemove_Click;
            // 
            // btnBuildOpenFolder
            // 
            btnBuildOpenFolder.Location = new System.Drawing.Point(131, 383);
            btnBuildOpenFolder.Name = "btnBuildOpenFolder";
            btnBuildOpenFolder.Size = new System.Drawing.Size(110, 26);
            btnBuildOpenFolder.TabIndex = 2;
            btnBuildOpenFolder.Text = "Open Folder";
            btnBuildOpenFolder.Click += btnBuildOpenFolder_Click;
            // 
            // btnBuildActivate
            // 
            btnBuildActivate.Location = new System.Drawing.Point(13, 383);
            btnBuildActivate.Name = "btnBuildActivate";
            btnBuildActivate.Size = new System.Drawing.Size(110, 26);
            btnBuildActivate.TabIndex = 1;
            btnBuildActivate.Text = "Activate";
            toolTipBuilds.SetToolTip(btnBuildActivate, "Make the selected build the active core or launcher. Switching back is always possible.");
            btnBuildActivate.Click += btnBuildActivate_Click;
            // 
            // tabsBuilds
            // 
            tabsBuilds.AllowDrop = true;
            tabsBuilds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabsBuilds.Controls.Add(tabPageCore);
            tabsBuilds.Controls.Add(tabPageLauncher);
            tabsBuilds.ItemSize = new System.Drawing.Size(85, 28);
            tabsBuilds.Location = new System.Drawing.Point(13, 37);
            tabsBuilds.Name = "tabsBuilds";
            tabsBuilds.Padding = new System.Drawing.Point(0, 0);
            tabsBuilds.SelectedIndex = 0;
            tabsBuilds.Size = new System.Drawing.Size(713, 340);
            tabsBuilds.TabIndex = 0;
            tabsBuilds.SelectedIndexChanged += tabsBuilds_SelectedIndexChanged;
            // 
            // tabPageCore
            // 
            tabPageCore.Controls.Add(lstCoreBuilds);
            tabPageCore.Location = new System.Drawing.Point(4, 32);
            tabPageCore.Name = "tabPageCore";
            tabPageCore.Padding = new System.Windows.Forms.Padding(3);
            tabPageCore.Size = new System.Drawing.Size(705, 304);
            tabPageCore.TabIndex = 0;
            tabPageCore.Text = "Core";
            // 
            // lstCoreBuilds
            // 
            lstCoreBuilds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstCoreBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            lstCoreBuilds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lstCoreBuilds.ItemHeight = 18;
            lstCoreBuilds.Location = new System.Drawing.Point(3, 3);
            lstCoreBuilds.Name = "lstCoreBuilds";
            lstCoreBuilds.Size = new System.Drawing.Size(699, 298);
            lstCoreBuilds.TabIndex = 0;
            lstCoreBuilds.SelectedIndexChanged += lstCoreBuilds_SelectedIndexChanged;
            // 
            // tabPageLauncher
            // 
            tabPageLauncher.Controls.Add(lstLauncherBuilds);
            tabPageLauncher.Location = new System.Drawing.Point(4, 32);
            tabPageLauncher.Name = "tabPageLauncher";
            tabPageLauncher.Padding = new System.Windows.Forms.Padding(3);
            tabPageLauncher.Size = new System.Drawing.Size(704, 304);
            tabPageLauncher.TabIndex = 1;
            tabPageLauncher.Text = "Launcher";
            // 
            // lstLauncherBuilds
            // 
            lstLauncherBuilds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstLauncherBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            lstLauncherBuilds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lstLauncherBuilds.ItemHeight = 18;
            lstLauncherBuilds.Location = new System.Drawing.Point(3, 3);
            lstLauncherBuilds.Name = "lstLauncherBuilds";
            lstLauncherBuilds.Size = new System.Drawing.Size(698, 298);
            lstLauncherBuilds.TabIndex = 0;
            lstLauncherBuilds.SelectedIndexChanged += lstLauncherBuilds_SelectedIndexChanged;
            // 
            // grpCurrentSetup
            // 
            grpCurrentSetup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpCurrentSetup.Controls.Add(grpCoreCard);
            grpCurrentSetup.Controls.Add(grpLauncherCard);
            grpCurrentSetup.Location = new System.Drawing.Point(12, 12);
            grpCurrentSetup.Margin = new System.Windows.Forms.Padding(6);
            grpCurrentSetup.Name = "grpCurrentSetup";
            grpCurrentSetup.Padding = new System.Windows.Forms.Padding(12);
            grpCurrentSetup.SectionHeader = "Current Setup";
            grpCurrentSetup.Size = new System.Drawing.Size(739, 145);
            grpCurrentSetup.TabIndex = 2;
            // 
            // grpCoreCard
            // 
            grpCoreCard.Controls.Add(lblCoreCardState);
            grpCoreCard.Controls.Add(lblCoreCardDate);
            grpCoreCard.Controls.Add(lblCoreCardSha);
            grpCoreCard.Controls.Add(btnCoreCardOpenFolder);
            grpCoreCard.Location = new System.Drawing.Point(13, 37);
            grpCoreCard.Name = "grpCoreCard";
            grpCoreCard.Padding = new System.Windows.Forms.Padding(12);
            grpCoreCard.Size = new System.Drawing.Size(351, 95);
            grpCoreCard.TabIndex = 0;
            grpCoreCard.TabStop = false;
            grpCoreCard.Text = "Core";
            // 
            // lblCoreCardState
            // 
            lblCoreCardState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCoreCardState.Location = new System.Drawing.Point(12, 18);
            lblCoreCardState.Name = "lblCoreCardState";
            lblCoreCardState.Size = new System.Drawing.Size(180, 18);
            lblCoreCardState.TabIndex = 0;
            lblCoreCardState.Text = "Not set";
            // 
            // lblCoreCardDate
            // 
            lblCoreCardDate.AutoEllipsis = true;
            lblCoreCardDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCoreCardDate.Location = new System.Drawing.Point(12, 38);
            lblCoreCardDate.Name = "lblCoreCardDate";
            lblCoreCardDate.Size = new System.Drawing.Size(200, 18);
            lblCoreCardDate.TabIndex = 1;
            lblCoreCardDate.Text = "(not set)";
            // 
            // lblCoreCardSha
            // 
            lblCoreCardSha.AutoEllipsis = true;
            lblCoreCardSha.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCoreCardSha.Location = new System.Drawing.Point(12, 58);
            lblCoreCardSha.Name = "lblCoreCardSha";
            lblCoreCardSha.Size = new System.Drawing.Size(200, 16);
            lblCoreCardSha.TabIndex = 2;
            // 
            // btnCoreCardOpenFolder
            // 
            btnCoreCardOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCoreCardOpenFolder.Location = new System.Drawing.Point(239, 48);
            btnCoreCardOpenFolder.Name = "btnCoreCardOpenFolder";
            btnCoreCardOpenFolder.Size = new System.Drawing.Size(96, 26);
            btnCoreCardOpenFolder.TabIndex = 3;
            btnCoreCardOpenFolder.Text = "Open Folder";
            btnCoreCardOpenFolder.Click += btnCoreCardOpenFolder_Click;
            // 
            // grpLauncherCard
            // 
            grpLauncherCard.Controls.Add(lblLauncherCardState);
            grpLauncherCard.Controls.Add(lblLauncherCardDate);
            grpLauncherCard.Controls.Add(lblLauncherCardSha);
            grpLauncherCard.Controls.Add(btnLauncherCardOpenFolder);
            grpLauncherCard.Location = new System.Drawing.Point(377, 37);
            grpLauncherCard.Name = "grpLauncherCard";
            grpLauncherCard.Padding = new System.Windows.Forms.Padding(12);
            grpLauncherCard.Size = new System.Drawing.Size(352, 95);
            grpLauncherCard.TabIndex = 1;
            grpLauncherCard.TabStop = false;
            grpLauncherCard.Text = "Launcher";
            // 
            // lblLauncherCardState
            // 
            lblLauncherCardState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblLauncherCardState.Location = new System.Drawing.Point(12, 18);
            lblLauncherCardState.Name = "lblLauncherCardState";
            lblLauncherCardState.Size = new System.Drawing.Size(180, 18);
            lblLauncherCardState.TabIndex = 0;
            lblLauncherCardState.Text = "Not set";
            // 
            // lblLauncherCardDate
            // 
            lblLauncherCardDate.AutoEllipsis = true;
            lblLauncherCardDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblLauncherCardDate.Location = new System.Drawing.Point(12, 38);
            lblLauncherCardDate.Name = "lblLauncherCardDate";
            lblLauncherCardDate.Size = new System.Drawing.Size(200, 18);
            lblLauncherCardDate.TabIndex = 1;
            lblLauncherCardDate.Text = "(not set)";
            // 
            // lblLauncherCardSha
            // 
            lblLauncherCardSha.AutoEllipsis = true;
            lblLauncherCardSha.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblLauncherCardSha.Location = new System.Drawing.Point(12, 58);
            lblLauncherCardSha.Name = "lblLauncherCardSha";
            lblLauncherCardSha.Size = new System.Drawing.Size(200, 16);
            lblLauncherCardSha.TabIndex = 2;
            // 
            // btnLauncherCardOpenFolder
            // 
            btnLauncherCardOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLauncherCardOpenFolder.Location = new System.Drawing.Point(240, 48);
            btnLauncherCardOpenFolder.Name = "btnLauncherCardOpenFolder";
            btnLauncherCardOpenFolder.Size = new System.Drawing.Size(96, 26);
            btnLauncherCardOpenFolder.TabIndex = 3;
            btnLauncherCardOpenFolder.Text = "Open Folder";
            btnLauncherCardOpenFolder.Click += btnLauncherCardOpenFolder_Click;
            // 
            // btnInstallShadps4
            // 
            btnInstallShadps4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnInstallShadps4.Location = new System.Drawing.Point(12, 603);
            btnInstallShadps4.Name = "btnInstallShadps4";
            btnInstallShadps4.Size = new System.Drawing.Size(160, 26);
            btnInstallShadps4.TabIndex = 4;
            btnInstallShadps4.Text = "Install Build...";
            btnInstallShadps4.Click += btnInstallShadps4_Click;
            // 
            // btnChooseCoreVersion
            // 
            btnChooseCoreVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnChooseCoreVersion.Location = new System.Drawing.Point(180, 603);
            btnChooseCoreVersion.Name = "btnChooseCoreVersion";
            btnChooseCoreVersion.Size = new System.Drawing.Size(190, 26);
            btnChooseCoreVersion.TabIndex = 5;
            btnChooseCoreVersion.Text = "Browse Available Builds";
            btnChooseCoreVersion.Click += btnChooseCoreVersion_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnMaintenance.Location = new System.Drawing.Point(643, 603);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new System.Drawing.Size(108, 26);
            btnMaintenance.TabIndex = 6;
            btnMaintenance.Text = "Maintenance â–¾";
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.AutoEllipsis = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblStatus.Location = new System.Drawing.Point(12, 635);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(723, 24);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Managed builds are kept locally so you can switch back to an older build.";
            // 
            // tabManagerSaves
            // 
            tabManagerSaves.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerSaves.Controls.Add(grpSavesSelected);
            tabManagerSaves.Controls.Add(lblManagerSavesHint);
            tabManagerSaves.Controls.Add(btnSavesRestore);
            tabManagerSaves.Controls.Add(lstManagerSavesBackups);
            tabManagerSaves.Controls.Add(lblSavesBackupsHeader);
            tabManagerSaves.Controls.Add(lstManagerSavesSlots);
            tabManagerSaves.Controls.Add(lblSavesSlotsHeader);
            tabManagerSaves.Controls.Add(btnSavesOpenFolder);
            tabManagerSaves.Controls.Add(btnSavesBackup);
            tabManagerSaves.Controls.Add(lstManagerSaves);
            tabManagerSaves.Controls.Add(lblSavesHeader);
            tabManagerSaves.Location = new System.Drawing.Point(122, 0);
            tabManagerSaves.Name = "tabManagerSaves";
            tabManagerSaves.Padding = new System.Windows.Forms.Padding(12);
            tabManagerSaves.Size = new System.Drawing.Size(765, 816);
            tabManagerSaves.TabIndex = 3;
            tabManagerSaves.Text = "Saves";
            // 
            // grpSavesSelected
            // 
            grpSavesSelected.Controls.Add(lblSaveGameTitle);
            grpSavesSelected.Controls.Add(lblSaveGameUser);
            grpSavesSelected.Controls.Add(lblSaveGamePath);
            grpSavesSelected.Controls.Add(lblSaveNotInstalled);
            grpSavesSelected.Location = new System.Drawing.Point(12, 12);
            grpSavesSelected.Margin = new System.Windows.Forms.Padding(6);
            grpSavesSelected.Name = "grpSavesSelected";
            grpSavesSelected.Padding = new System.Windows.Forms.Padding(12);
            grpSavesSelected.SectionHeader = "Selected Save";
            grpSavesSelected.Size = new System.Drawing.Size(738, 122);
            grpSavesSelected.TabIndex = 10;
            // 
            // lblSaveGameTitle
            // 
            lblSaveGameTitle.AutoEllipsis = true;
            lblSaveGameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSaveGameTitle.Location = new System.Drawing.Point(13, 37);
            lblSaveGameTitle.Name = "lblSaveGameTitle";
            lblSaveGameTitle.Size = new System.Drawing.Size(673, 18);
            lblSaveGameTitle.TabIndex = 0;
            lblSaveGameTitle.Text = "No save selected";
            // 
            // lblSaveGameUser
            // 
            lblSaveGameUser.AutoEllipsis = true;
            lblSaveGameUser.Location = new System.Drawing.Point(13, 57);
            lblSaveGameUser.Name = "lblSaveGameUser";
            lblSaveGameUser.Size = new System.Drawing.Size(673, 16);
            lblSaveGameUser.TabIndex = 1;
            // 
            // lblSaveGamePath
            // 
            lblSaveGamePath.AutoEllipsis = true;
            lblSaveGamePath.Location = new System.Drawing.Point(13, 75);
            lblSaveGamePath.Name = "lblSaveGamePath";
            lblSaveGamePath.Size = new System.Drawing.Size(673, 16);
            lblSaveGamePath.TabIndex = 2;
            // 
            // lblSaveNotInstalled
            // 
            lblSaveNotInstalled.AutoEllipsis = true;
            lblSaveNotInstalled.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            lblSaveNotInstalled.Location = new System.Drawing.Point(13, 93);
            lblSaveNotInstalled.Name = "lblSaveNotInstalled";
            lblSaveNotInstalled.Size = new System.Drawing.Size(673, 16);
            lblSaveNotInstalled.TabIndex = 3;
            // 
            // lblManagerSavesHint
            // 
            lblManagerSavesHint.AutoEllipsis = true;
            lblManagerSavesHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblManagerSavesHint.Location = new System.Drawing.Point(12, 425);
            lblManagerSavesHint.Name = "lblManagerSavesHint";
            lblManagerSavesHint.Size = new System.Drawing.Size(752, 44);
            lblManagerSavesHint.TabIndex = 9;
            lblManagerSavesHint.Text = "Save games in the shadPS4 user directory.";
            // 
            // btnSavesRestore
            // 
            btnSavesRestore.Location = new System.Drawing.Point(266, 388);
            btnSavesRestore.Name = "btnSavesRestore";
            btnSavesRestore.Size = new System.Drawing.Size(121, 26);
            btnSavesRestore.TabIndex = 8;
            btnSavesRestore.Text = "Restore Backup...";
            btnSavesRestore.Click += btnSavesRestore_Click;
            // 
            // lstManagerSavesBackups
            // 
            lstManagerSavesBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstManagerSavesBackups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lstManagerSavesBackups.ItemHeight = 18;
            lstManagerSavesBackups.Location = new System.Drawing.Point(536, 159);
            lstManagerSavesBackups.Name = "lstManagerSavesBackups";
            lstManagerSavesBackups.Size = new System.Drawing.Size(214, 218);
            lstManagerSavesBackups.TabIndex = 7;
            lstManagerSavesBackups.SelectedIndexChanged += lstManagerSavesBackups_SelectedIndexChanged;
            // 
            // lblSavesBackupsHeader
            // 
            lblSavesBackupsHeader.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblSavesBackupsHeader.Location = new System.Drawing.Point(538, 143);
            lblSavesBackupsHeader.Name = "lblSavesBackupsHeader";
            lblSavesBackupsHeader.Size = new System.Drawing.Size(110, 16);
            lblSavesBackupsHeader.TabIndex = 6;
            lblSavesBackupsHeader.Text = "Backups";
            // 
            // lstManagerSavesSlots
            // 
            lstManagerSavesSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstManagerSavesSlots.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lstManagerSavesSlots.ItemHeight = 18;
            lstManagerSavesSlots.Location = new System.Drawing.Point(279, 159);
            lstManagerSavesSlots.Name = "lstManagerSavesSlots";
            lstManagerSavesSlots.Size = new System.Drawing.Size(208, 218);
            lstManagerSavesSlots.TabIndex = 5;
            // 
            // lblSavesSlotsHeader
            // 
            lblSavesSlotsHeader.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblSavesSlotsHeader.Location = new System.Drawing.Point(270, 143);
            lblSavesSlotsHeader.Name = "lblSavesSlotsHeader";
            lblSavesSlotsHeader.Size = new System.Drawing.Size(110, 16);
            lblSavesSlotsHeader.TabIndex = 4;
            lblSavesSlotsHeader.Text = "Slots";
            // 
            // btnSavesOpenFolder
            // 
            btnSavesOpenFolder.Location = new System.Drawing.Point(139, 388);
            btnSavesOpenFolder.Name = "btnSavesOpenFolder";
            btnSavesOpenFolder.Size = new System.Drawing.Size(121, 26);
            btnSavesOpenFolder.TabIndex = 3;
            btnSavesOpenFolder.Text = "Open Save Folder";
            btnSavesOpenFolder.Click += btnSavesOpenFolder_Click;
            // 
            // btnSavesBackup
            // 
            btnSavesBackup.Location = new System.Drawing.Point(12, 388);
            btnSavesBackup.Name = "btnSavesBackup";
            btnSavesBackup.Size = new System.Drawing.Size(121, 26);
            btnSavesBackup.TabIndex = 2;
            btnSavesBackup.Text = "Create Backup";
            btnSavesBackup.Click += btnSavesBackup_Click;
            // 
            // lstManagerSaves
            // 
            lstManagerSaves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstManagerSaves.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lstManagerSaves.ItemHeight = 18;
            lstManagerSaves.Location = new System.Drawing.Point(12, 159);
            lstManagerSaves.Name = "lstManagerSaves";
            lstManagerSaves.Size = new System.Drawing.Size(218, 218);
            lstManagerSaves.TabIndex = 1;
            lstManagerSaves.SelectedIndexChanged += lstManagerSaves_SelectedIndexChanged;
            // 
            // lblSavesHeader
            // 
            lblSavesHeader.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblSavesHeader.Location = new System.Drawing.Point(12, 143);
            lblSavesHeader.Name = "lblSavesHeader";
            lblSavesHeader.Size = new System.Drawing.Size(110, 16);
            lblSavesHeader.TabIndex = 0;
            lblSavesHeader.Text = "Saves";
            // 
            // tabManagerPatches
            // 
            tabManagerPatches.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerPatches.Controls.Add(grpPatchesDefinitions);
            tabManagerPatches.Controls.Add(btnPatchesDownload);
            tabManagerPatches.Controls.Add(btnPatchesApply);
            tabManagerPatches.Controls.Add(btnPatchesRevert);
            tabManagerPatches.Controls.Add(btnPatchesOpenData);
            tabManagerPatches.Controls.Add(btnPatchesOpenQtLauncher);
            tabManagerPatches.Controls.Add(lblPatchesHint);
            tabManagerPatches.Controls.Add(lblPatchesGame);
            tabManagerPatches.Controls.Add(cmbPatchesGame);
            tabManagerPatches.Location = new System.Drawing.Point(122, 0);
            tabManagerPatches.Name = "tabManagerPatches";
            tabManagerPatches.Padding = new System.Windows.Forms.Padding(12);
            tabManagerPatches.Size = new System.Drawing.Size(765, 816);
            tabManagerPatches.TabIndex = 4;
            tabManagerPatches.Text = "Patches && Cheats";
            tabManagerPatches.Visible = false;
            // 
            // grpPatchesDefinitions
            // 
            grpPatchesDefinitions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpPatchesDefinitions.Controls.Add(tabsPatchesDefinitions);
            grpPatchesDefinitions.Location = new System.Drawing.Point(12, 94);
            grpPatchesDefinitions.Margin = new System.Windows.Forms.Padding(6);
            grpPatchesDefinitions.Name = "grpPatchesDefinitions";
            grpPatchesDefinitions.Padding = new System.Windows.Forms.Padding(12);
            grpPatchesDefinitions.SectionHeader = "Local definitions";
            grpPatchesDefinitions.Size = new System.Drawing.Size(739, 610);
            grpPatchesDefinitions.TabIndex = 6;
            // 
            // tabsPatchesDefinitions
            // 
            tabsPatchesDefinitions.AllowDrop = true;
            tabsPatchesDefinitions.Controls.Add(tabCheatsDefinitions);
            tabsPatchesDefinitions.Controls.Add(tabPatchDefinitions);
            tabsPatchesDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
            tabsPatchesDefinitions.ItemSize = new System.Drawing.Size(80, 28);
            tabsPatchesDefinitions.Location = new System.Drawing.Point(13, 37);
            tabsPatchesDefinitions.Name = "tabsPatchesDefinitions";
            tabsPatchesDefinitions.Padding = new System.Drawing.Point(0, 0);
            tabsPatchesDefinitions.SelectedIndex = 0;
            tabsPatchesDefinitions.Size = new System.Drawing.Size(713, 560);
            tabsPatchesDefinitions.TabIndex = 0;
            // 
            // tabCheatsDefinitions
            // 
            tabCheatsDefinitions.Controls.Add(dgvPatchesCheats);
            tabCheatsDefinitions.Location = new System.Drawing.Point(4, 32);
            tabCheatsDefinitions.Name = "tabCheatsDefinitions";
            tabCheatsDefinitions.Padding = new System.Windows.Forms.Padding(3);
            tabCheatsDefinitions.Size = new System.Drawing.Size(705, 524);
            tabCheatsDefinitions.TabIndex = 0;
            tabCheatsDefinitions.Text = "Cheats";
            // 
            // dgvPatchesCheats
            // 
            dgvPatchesCheats.AllowUserToAddRows = false;
            dgvPatchesCheats.AllowUserToDeleteRows = false;
            dgvPatchesCheats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatchesCheats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colCheatName, colCheatVersion, colCheatAuthor, colCheatOperations, colCheatStatus });
            dgvPatchesCheats.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPatchesCheats.Location = new System.Drawing.Point(3, 3);
            dgvPatchesCheats.MultiSelect = false;
            dgvPatchesCheats.Name = "dgvPatchesCheats";
            dgvPatchesCheats.ReadOnly = true;
            dgvPatchesCheats.Size = new System.Drawing.Size(699, 518);
            dgvPatchesCheats.TabIndex = 0;
            // 
            // colCheatName
            // 
            colCheatName.FillWeight = 180F;
            colCheatName.HeaderText = "Name";
            colCheatName.Name = "colCheatName";
            colCheatName.ReadOnly = true;
            // 
            // colCheatVersion
            // 
            colCheatVersion.HeaderText = "Version";
            colCheatVersion.Name = "colCheatVersion";
            colCheatVersion.ReadOnly = true;
            // 
            // colCheatAuthor
            // 
            colCheatAuthor.HeaderText = "Author";
            colCheatAuthor.Name = "colCheatAuthor";
            colCheatAuthor.ReadOnly = true;
            // 
            // colCheatOperations
            // 
            colCheatOperations.HeaderText = "Operations";
            colCheatOperations.Name = "colCheatOperations";
            colCheatOperations.ReadOnly = true;
            // 
            // colCheatStatus
            // 
            colCheatStatus.HeaderText = "Status";
            colCheatStatus.Name = "colCheatStatus";
            colCheatStatus.ReadOnly = true;
            // 
            // tabPatchDefinitions
            // 
            tabPatchDefinitions.Controls.Add(dgvPatches);
            tabPatchDefinitions.Location = new System.Drawing.Point(4, 32);
            tabPatchDefinitions.Name = "tabPatchDefinitions";
            tabPatchDefinitions.Padding = new System.Windows.Forms.Padding(3);
            tabPatchDefinitions.Size = new System.Drawing.Size(704, 524);
            tabPatchDefinitions.TabIndex = 1;
            tabPatchDefinitions.Text = "Patches";
            // 
            // dgvPatches
            // 
            dgvPatches.AllowUserToAddRows = false;
            dgvPatches.AllowUserToDeleteRows = false;
            dgvPatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPatchEnabled, colPatchName, colPatchVersion, colPatchAuthor, colPatchElf, colPatchOperations, colPatchStatus });
            dgvPatches.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPatches.Location = new System.Drawing.Point(3, 3);
            dgvPatches.MultiSelect = false;
            dgvPatches.Name = "dgvPatches";
            dgvPatches.Size = new System.Drawing.Size(698, 518);
            dgvPatches.TabIndex = 0;
            dgvPatches.CellValueChanged += dgvPatches_CellValueChanged;
            dgvPatches.CurrentCellDirtyStateChanged += dgvPatches_CurrentCellDirtyStateChanged;
            // 
            // colPatchEnabled
            // 
            colPatchEnabled.FillWeight = 55F;
            colPatchEnabled.HeaderText = "Enabled";
            colPatchEnabled.Name = "colPatchEnabled";
            // 
            // colPatchName
            // 
            colPatchName.FillWeight = 180F;
            colPatchName.HeaderText = "Name";
            colPatchName.Name = "colPatchName";
            colPatchName.ReadOnly = true;
            // 
            // colPatchVersion
            // 
            colPatchVersion.HeaderText = "App version";
            colPatchVersion.Name = "colPatchVersion";
            colPatchVersion.ReadOnly = true;
            // 
            // colPatchAuthor
            // 
            colPatchAuthor.HeaderText = "Author";
            colPatchAuthor.Name = "colPatchAuthor";
            colPatchAuthor.ReadOnly = true;
            // 
            // colPatchElf
            // 
            colPatchElf.HeaderText = "ELF";
            colPatchElf.Name = "colPatchElf";
            colPatchElf.ReadOnly = true;
            // 
            // colPatchOperations
            // 
            colPatchOperations.HeaderText = "Operations";
            colPatchOperations.Name = "colPatchOperations";
            colPatchOperations.ReadOnly = true;
            // 
            // colPatchStatus
            // 
            colPatchStatus.HeaderText = "Status";
            colPatchStatus.Name = "colPatchStatus";
            colPatchStatus.ReadOnly = true;
            // 
            // btnPatchesDownload
            // 
            btnPatchesDownload.Location = new System.Drawing.Point(12, 62);
            btnPatchesDownload.Name = "btnPatchesDownload";
            btnPatchesDownload.Size = new System.Drawing.Size(142, 26);
            btnPatchesDownload.TabIndex = 2;
            btnPatchesDownload.Text = "Download / Update";
            btnPatchesDownload.Click += btnPatchesDownload_Click;
            // 
            // btnPatchesApply
            // 
            btnPatchesApply.Location = new System.Drawing.Point(428, 62);
            btnPatchesApply.Name = "btnPatchesApply";
            btnPatchesApply.Size = new System.Drawing.Size(80, 26);
            btnPatchesApply.TabIndex = 5;
            btnPatchesApply.Text = "Apply";
            btnPatchesApply.Click += btnPatchesApply_Click;
            // 
            // btnPatchesRevert
            // 
            btnPatchesRevert.Location = new System.Drawing.Point(514, 62);
            btnPatchesRevert.Name = "btnPatchesRevert";
            btnPatchesRevert.Size = new System.Drawing.Size(80, 26);
            btnPatchesRevert.TabIndex = 6;
            btnPatchesRevert.Text = "Revert";
            btnPatchesRevert.Click += btnPatchesRevert_Click;
            // 
            // btnPatchesOpenData
            // 
            btnPatchesOpenData.Location = new System.Drawing.Point(160, 62);
            btnPatchesOpenData.Name = "btnPatchesOpenData";
            btnPatchesOpenData.Size = new System.Drawing.Size(128, 26);
            btnPatchesOpenData.TabIndex = 3;
            btnPatchesOpenData.Text = "Open Data Folder";
            btnPatchesOpenData.Click += btnPatchesOpenData_Click;
            // 
            // btnPatchesOpenQtLauncher
            // 
            btnPatchesOpenQtLauncher.Location = new System.Drawing.Point(294, 62);
            btnPatchesOpenQtLauncher.Name = "btnPatchesOpenQtLauncher";
            btnPatchesOpenQtLauncher.Size = new System.Drawing.Size(128, 26);
            btnPatchesOpenQtLauncher.TabIndex = 4;
            btnPatchesOpenQtLauncher.Text = "Open QtLauncher";
            btnPatchesOpenQtLauncher.Click += btnPatchesOpenQtLauncher_Click;
            // 
            // lblPatchesHint
            // 
            lblPatchesHint.AutoEllipsis = true;
            lblPatchesHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            lblPatchesHint.Location = new System.Drawing.Point(12, 42);
            lblPatchesHint.Name = "lblPatchesHint";
            lblPatchesHint.Size = new System.Drawing.Size(700, 16);
            lblPatchesHint.TabIndex = 1;
            lblPatchesHint.Text = "Source: official shadPS4. Definitions are read only here. Enable state is managed by QtLauncher.";
            // 
            // lblPatchesGame
            // 
            lblPatchesGame.Location = new System.Drawing.Point(12, 17);
            lblPatchesGame.Name = "lblPatchesGame";
            lblPatchesGame.Size = new System.Drawing.Size(48, 20);
            lblPatchesGame.TabIndex = 0;
            lblPatchesGame.Text = "Game:";
            // 
            // cmbPatchesGame
            // 
            cmbPatchesGame.Location = new System.Drawing.Point(65, 14);
            cmbPatchesGame.Name = "cmbPatchesGame";
            cmbPatchesGame.Size = new System.Drawing.Size(420, 24);
            cmbPatchesGame.TabIndex = 1;
            cmbPatchesGame.SelectedIndexChanged += cmbPatchesGame_SelectedIndexChanged;
            // 
            // tabManagerSettings
            // 
            tabManagerSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabManagerSettings.Controls.Add(grpSettingsDetection);
            tabManagerSettings.Controls.Add(grpSettingsUpdate);
            tabManagerSettings.Controls.Add(grpSettingsPaths);
            tabManagerSettings.Location = new System.Drawing.Point(122, 0);
            tabManagerSettings.Name = "tabManagerSettings";
            tabManagerSettings.Padding = new System.Windows.Forms.Padding(12);
            tabManagerSettings.Size = new System.Drawing.Size(765, 816);
            tabManagerSettings.TabIndex = 5;
            tabManagerSettings.Text = "Settings";
            // 
            // grpSettingsDetection
            // 
            grpSettingsDetection.Controls.Add(btncopyDetectioninfo);
            grpSettingsDetection.Controls.Add(lblSettingsDetect);
            grpSettingsDetection.Location = new System.Drawing.Point(12, 280);
            grpSettingsDetection.Margin = new System.Windows.Forms.Padding(6);
            grpSettingsDetection.Name = "grpSettingsDetection";
            grpSettingsDetection.Padding = new System.Windows.Forms.Padding(12);
            grpSettingsDetection.SectionHeader = "Detection";
            grpSettingsDetection.Size = new System.Drawing.Size(738, 297);
            grpSettingsDetection.TabIndex = 2;
            // 
            // btncopyDetectioninfo
            // 
            btncopyDetectioninfo.Location = new System.Drawing.Point(13, 258);
            btncopyDetectioninfo.Name = "btncopyDetectioninfo";
            btncopyDetectioninfo.Size = new System.Drawing.Size(145, 26);
            btncopyDetectioninfo.TabIndex = 2;
            btncopyDetectioninfo.Text = "Copy";
            btncopyDetectioninfo.Click += btncopyDetectioninfo_Click;
            // 
            // lblSettingsDetect
            // 
            lblSettingsDetect.AutoEllipsis = true;
            lblSettingsDetect.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblSettingsDetect.Location = new System.Drawing.Point(13, 37);
            lblSettingsDetect.Name = "lblSettingsDetect";
            lblSettingsDetect.Size = new System.Drawing.Size(690, 207);
            lblSettingsDetect.TabIndex = 0;
            lblSettingsDetect.Text = "Detection: not configured";
            // 
            // grpSettingsUpdate
            // 
            grpSettingsUpdate.Controls.Add(btnSettingsCheckUpdates);
            grpSettingsUpdate.Location = new System.Drawing.Point(12, 192);
            grpSettingsUpdate.Margin = new System.Windows.Forms.Padding(6);
            grpSettingsUpdate.Name = "grpSettingsUpdate";
            grpSettingsUpdate.Padding = new System.Windows.Forms.Padding(12);
            grpSettingsUpdate.SectionHeader = "Update";
            grpSettingsUpdate.Size = new System.Drawing.Size(738, 76);
            grpSettingsUpdate.TabIndex = 1;
            // 
            // btnSettingsCheckUpdates
            // 
            btnSettingsCheckUpdates.Location = new System.Drawing.Point(13, 37);
            btnSettingsCheckUpdates.Name = "btnSettingsCheckUpdates";
            btnSettingsCheckUpdates.Size = new System.Drawing.Size(160, 26);
            btnSettingsCheckUpdates.TabIndex = 0;
            btnSettingsCheckUpdates.Text = "Check for Updates";
            btnSettingsCheckUpdates.Click += btnSettingsCheckUpdates_Click;
            // 
            // grpSettingsPaths
            // 
            grpSettingsPaths.Controls.Add(btnSettingsConfigFolder);
            grpSettingsPaths.Controls.Add(btnSettingsInstallDirBrowse);
            grpSettingsPaths.Controls.Add(tbSettingsInstallDir);
            grpSettingsPaths.Controls.Add(darkLabelSettingsInstallDir);
            grpSettingsPaths.Controls.Add(btnSettingsLauncherOpen);
            grpSettingsPaths.Controls.Add(btnSettingsLauncherBrowse);
            grpSettingsPaths.Controls.Add(tbSettingsLauncher);
            grpSettingsPaths.Controls.Add(darkLabelSettingsLauncher);
            grpSettingsPaths.Controls.Add(btnSettingsCoreBrowse);
            grpSettingsPaths.Controls.Add(tbSettingsCore);
            grpSettingsPaths.Controls.Add(darkLabelSettingsCore);
            grpSettingsPaths.Location = new System.Drawing.Point(12, 12);
            grpSettingsPaths.Margin = new System.Windows.Forms.Padding(6);
            grpSettingsPaths.Name = "grpSettingsPaths";
            grpSettingsPaths.Padding = new System.Windows.Forms.Padding(12);
            grpSettingsPaths.SectionHeader = "Paths";
            grpSettingsPaths.Size = new System.Drawing.Size(738, 168);
            grpSettingsPaths.TabIndex = 0;
            // 
            // btnSettingsConfigFolder
            // 
            btnSettingsConfigFolder.Location = new System.Drawing.Point(13, 129);
            btnSettingsConfigFolder.Name = "btnSettingsConfigFolder";
            btnSettingsConfigFolder.Size = new System.Drawing.Size(160, 26);
            btnSettingsConfigFolder.TabIndex = 10;
            btnSettingsConfigFolder.Text = "Open Config Folder";
            btnSettingsConfigFolder.Click += btnSettingsConfigFolder_Click;
            // 
            // btnSettingsInstallDirBrowse
            // 
            btnSettingsInstallDirBrowse.Location = new System.Drawing.Point(483, 97);
            btnSettingsInstallDirBrowse.Name = "btnSettingsInstallDirBrowse";
            btnSettingsInstallDirBrowse.Size = new System.Drawing.Size(90, 26);
            btnSettingsInstallDirBrowse.TabIndex = 9;
            btnSettingsInstallDirBrowse.Text = "Browse...";
            btnSettingsInstallDirBrowse.Click += btnSettingsInstallDirBrowse_Click;
            // 
            // tbSettingsInstallDir
            // 
            tbSettingsInstallDir.Location = new System.Drawing.Point(148, 99);
            tbSettingsInstallDir.Name = "tbSettingsInstallDir";
            tbSettingsInstallDir.Size = new System.Drawing.Size(330, 23);
            tbSettingsInstallDir.TabIndex = 8;
            tbSettingsInstallDir.TextChanged += tbSettingsInstallDir_TextChanged;
            // 
            // darkLabelSettingsInstallDir
            // 
            darkLabelSettingsInstallDir.Location = new System.Drawing.Point(13, 103);
            darkLabelSettingsInstallDir.Name = "darkLabelSettingsInstallDir";
            darkLabelSettingsInstallDir.Size = new System.Drawing.Size(130, 15);
            darkLabelSettingsInstallDir.TabIndex = 7;
            darkLabelSettingsInstallDir.Text = "Install directory:";
            // 
            // btnSettingsLauncherOpen
            // 
            btnSettingsLauncherOpen.Location = new System.Drawing.Point(578, 67);
            btnSettingsLauncherOpen.Name = "btnSettingsLauncherOpen";
            btnSettingsLauncherOpen.Size = new System.Drawing.Size(90, 26);
            btnSettingsLauncherOpen.TabIndex = 6;
            btnSettingsLauncherOpen.Text = "Open";
            btnSettingsLauncherOpen.Click += btnSettingsLauncherOpen_Click;
            // 
            // btnSettingsLauncherBrowse
            // 
            btnSettingsLauncherBrowse.Location = new System.Drawing.Point(483, 67);
            btnSettingsLauncherBrowse.Name = "btnSettingsLauncherBrowse";
            btnSettingsLauncherBrowse.Size = new System.Drawing.Size(90, 26);
            btnSettingsLauncherBrowse.TabIndex = 5;
            btnSettingsLauncherBrowse.Text = "Browse...";
            btnSettingsLauncherBrowse.Click += btnSettingsLauncherBrowse_Click;
            // 
            // tbSettingsLauncher
            // 
            tbSettingsLauncher.Location = new System.Drawing.Point(148, 69);
            tbSettingsLauncher.Name = "tbSettingsLauncher";
            tbSettingsLauncher.ReadOnly = true;
            tbSettingsLauncher.Size = new System.Drawing.Size(330, 23);
            tbSettingsLauncher.TabIndex = 4;
            // 
            // darkLabelSettingsLauncher
            // 
            darkLabelSettingsLauncher.Location = new System.Drawing.Point(13, 73);
            darkLabelSettingsLauncher.Name = "darkLabelSettingsLauncher";
            darkLabelSettingsLauncher.Size = new System.Drawing.Size(130, 15);
            darkLabelSettingsLauncher.TabIndex = 3;
            darkLabelSettingsLauncher.Text = "QtLauncher:";
            // 
            // btnSettingsCoreBrowse
            // 
            btnSettingsCoreBrowse.Location = new System.Drawing.Point(483, 37);
            btnSettingsCoreBrowse.Name = "btnSettingsCoreBrowse";
            btnSettingsCoreBrowse.Size = new System.Drawing.Size(90, 26);
            btnSettingsCoreBrowse.TabIndex = 2;
            btnSettingsCoreBrowse.Text = "Browse...";
            btnSettingsCoreBrowse.Click += btnSettingsCoreBrowse_Click;
            // 
            // tbSettingsCore
            // 
            tbSettingsCore.Location = new System.Drawing.Point(148, 39);
            tbSettingsCore.Name = "tbSettingsCore";
            tbSettingsCore.ReadOnly = true;
            tbSettingsCore.Size = new System.Drawing.Size(330, 23);
            tbSettingsCore.TabIndex = 1;
            // 
            // darkLabelSettingsCore
            // 
            darkLabelSettingsCore.Location = new System.Drawing.Point(13, 43);
            darkLabelSettingsCore.Name = "darkLabelSettingsCore";
            darkLabelSettingsCore.Size = new System.Drawing.Size(130, 15);
            darkLabelSettingsCore.TabIndex = 0;
            darkLabelSettingsCore.Text = "Active shadPS4 Core:";
            // 
            // colGameTitle
            // 
            colGameTitle.Text = "Title";
            colGameTitle.Width = 111;
            // 
            // colGameTitleId
            // 
            colGameTitleId.Text = "Title ID";
            colGameTitleId.Width = 111;
            // 
            // colGameVersion
            // 
            colGameVersion.Text = "Version";
            colGameVersion.Width = 111;
            // 
            // colGameLastTest
            // 
            colGameLastTest.Text = "Last Test";
            colGameLastTest.Width = 111;
            // 
            // ctxGameMore
            // 
            ctxGameMore.Font = new System.Drawing.Font("Segoe UI", 9F);
            ctxGameMore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { miGameAddReport, miGameCopyInfo, miGameUninstall });
            ctxGameMore.Name = "ctxGameMore";
            ctxGameMore.Size = new System.Drawing.Size(203, 70);
            // 
            // miGameAddReport
            // 
            miGameAddReport.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miGameAddReport.Name = "miGameAddReport";
            miGameAddReport.Size = new System.Drawing.Size(202, 22);
            miGameAddReport.Text = "Add Test Result";
            miGameAddReport.Click += miGameAddReport_Click;
            // 
            // miGameCopyInfo
            // 
            miGameCopyInfo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miGameCopyInfo.Name = "miGameCopyInfo";
            miGameCopyInfo.Size = new System.Drawing.Size(202, 22);
            miGameCopyInfo.Text = "Copy Game Information";
            miGameCopyInfo.Click += miGameCopyInfo_Click;
            // 
            // miGameUninstall
            // 
            miGameUninstall.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miGameUninstall.Name = "miGameUninstall";
            miGameUninstall.Size = new System.Drawing.Size(202, 22);
            miGameUninstall.Text = "Uninstall Game...";
            miGameUninstall.Click += miGameUninstall_Click;
            // 
            // ctxMaintenance
            // 
            ctxMaintenance.Font = new System.Drawing.Font("Segoe UI", 9F);
            ctxMaintenance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { miMaintenanceReset, miMaintenanceRemoveAll, miMaintenanceOpenFolder });
            ctxMaintenance.Name = "ctxMaintenance";
            ctxMaintenance.Size = new System.Drawing.Size(228, 70);
            // 
            // miMaintenanceReset
            // 
            miMaintenanceReset.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miMaintenanceReset.Name = "miMaintenanceReset";
            miMaintenanceReset.Size = new System.Drawing.Size(227, 22);
            miMaintenanceReset.Text = "Reset Managed Setup...";
            miMaintenanceReset.Click += miMaintenanceReset_Click;
            // 
            // miMaintenanceRemoveAll
            // 
            miMaintenanceRemoveAll.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miMaintenanceRemoveAll.Name = "miMaintenanceRemoveAll";
            miMaintenanceRemoveAll.Size = new System.Drawing.Size(227, 22);
            miMaintenanceRemoveAll.Text = "Remove All shadPS4 Data...";
            miMaintenanceRemoveAll.Click += miMaintenanceRemoveAll_Click;
            // 
            // miMaintenanceOpenFolder
            // 
            miMaintenanceOpenFolder.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            miMaintenanceOpenFolder.Name = "miMaintenanceOpenFolder";
            miMaintenanceOpenFolder.Size = new System.Drawing.Size(227, 22);
            miMaintenanceOpenFolder.Text = "Open Managed Builds Folder";
            miMaintenanceOpenFolder.Click += miMaintenanceOpenFolder_Click;
            // 
            // Shadps4Manager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(887, 884);
            Controls.Add(shadps4Tabs);
            Controls.Add(darkHeaderBar1);
            Controls.Add(darkStatusStrip1);
            Controls.Add(lblManagerHeaderState);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = Properties.Resources.PackageIcon;
            MaximizeBox = false;
            Name = "Shadps4Manager";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "shadPS4 Manager";
            ctxHeaderMore.ResumeLayout(false);
            darkStatusStrip1.ResumeLayout(false);
            darkStatusStrip1.PerformLayout();
            shadps4Tabs.ResumeLayout(false);
            tabManagerOverview.ResumeLayout(false);
            grpOverviewDetails.ResumeLayout(false);
            grpOverviewReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverviewReports).EndInit();
            grpOverviewCounts.ResumeLayout(false);
            grpOverviewActions.ResumeLayout(false);
            grpOverviewLauncher.ResumeLayout(false);
            grpOverviewCore.ResumeLayout(false);
            tabManagerGames.ResumeLayout(false);
            grpInstallActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picManagerGameIcon).EndInit();
            tabManagerBuilds.ResumeLayout(false);
            grpInstalledBuilds.ResumeLayout(false);
            tabsBuilds.ResumeLayout(false);
            tabPageCore.ResumeLayout(false);
            tabPageLauncher.ResumeLayout(false);
            grpCurrentSetup.ResumeLayout(false);
            grpCoreCard.ResumeLayout(false);
            grpLauncherCard.ResumeLayout(false);
            tabManagerSaves.ResumeLayout(false);
            grpSavesSelected.ResumeLayout(false);
            tabManagerPatches.ResumeLayout(false);
            grpPatchesDefinitions.ResumeLayout(false);
            tabsPatchesDefinitions.ResumeLayout(false);
            tabCheatsDefinitions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatchesCheats).EndInit();
            tabPatchDefinitions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatches).EndInit();
            tabManagerSettings.ResumeLayout(false);
            grpSettingsDetection.ResumeLayout(false);
            grpSettingsUpdate.ResumeLayout(false);
            grpSettingsPaths.ResumeLayout(false);
            grpSettingsPaths.PerformLayout();
            ctxGameMore.ResumeLayout(false);
            ctxMaintenance.ResumeLayout(false);
            ResumeLayout(false);
        }
        private DarkUI.Controls.DarkLabel lblManagerHeaderState;
        private DarkUI.Controls.DarkContextMenu ctxHeaderMore;
        private System.Windows.Forms.ToolStripMenuItem miHeaderConfigFolder;
        private System.Windows.Forms.ToolStripMenuItem miHeaderManagedBuilds;
        private System.Windows.Forms.ToolStripMenuItem miHeaderGameLibrary;
        private System.Windows.Forms.ToolStripMenuItem miHeaderCopyEnvironmentInfo;
        private DarkUI.Controls.DarkHeaderBar darkHeaderBar1;
        private DarkUI.Controls.DarkStatusStrip darkStatusStrip1;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripManagerStatus;
        private DarkUI.Controls.DarkSidebarTabControl shadps4Tabs;
        private DarkUI.Controls.SidebarPage tabManagerOverview;
        private DarkUI.Controls.DarkSectionPanel grpOverviewCore;
        private DarkUI.Controls.DarkLabel lblOverviewCoreInfo;
        private DarkUI.Controls.DarkButton btnOverviewCoreOpenFolder;
        private DarkUI.Controls.DarkSectionPanel grpOverviewLauncher;
        private DarkUI.Controls.DarkLabel lblOverviewLauncherInfo;
        private DarkUI.Controls.DarkButton btnOverviewLauncherOpenFolder;
        private DarkUI.Controls.DarkSectionPanel grpOverviewActions;
        private DarkUI.Controls.DarkButton btnOverviewInstallUpdate;
        private DarkUI.Controls.DarkButton btnOverviewOpenLibrary;
        private DarkUI.Controls.DarkButton btnOverviewOpenShadps4Folder;
        private DarkUI.Controls.DarkSectionPanel grpOverviewCounts;
        private DarkUI.Controls.DarkLabel lblOverviewCounts;
        private DarkUI.Controls.DarkSectionPanel grpOverviewReports;
        private DarkUI.Controls.DarkDataGridView dgvOverviewReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportCore;
        private DarkUI.Controls.DarkSectionPanel grpOverviewDetails;
        private DarkUI.Controls.DarkLabel lblOverviewEnvDetails;
        private DarkUI.Controls.DarkButton btnManagerCopyEnvironmentInfo;
        private System.Windows.Forms.ColumnHeader colGameTitle;
        private System.Windows.Forms.ColumnHeader colGameTitleId;
        private System.Windows.Forms.ColumnHeader colGameVersion;
        private System.Windows.Forms.ColumnHeader colGameLastTest;
        private System.Windows.Forms.ImageList imageListManagerGames;
        private DarkUI.Controls.DarkContextMenu ctxGameMore;
        private System.Windows.Forms.ToolStripMenuItem miGameAddReport;
        private System.Windows.Forms.ToolStripMenuItem miGameCopyInfo;
        private System.Windows.Forms.ToolStripMenuItem miGameUninstall;
        private DarkUI.Controls.SidebarPage tabManagerBuilds;
        private DarkUI.Controls.SidebarPage tabManagerSaves;
        private DarkUI.Controls.DarkListBox lstManagerSaves;
        private DarkUI.Controls.DarkListBox lstManagerSavesSlots;
        private DarkUI.Controls.DarkListBox lstManagerSavesBackups;
        private DarkUI.Controls.DarkButton btnSavesBackup;
        private DarkUI.Controls.DarkButton btnSavesOpenFolder;
        private DarkUI.Controls.DarkButton btnSavesRestore;
        private DarkUI.Controls.DarkLabel lblSavesHeader;
        private DarkUI.Controls.DarkLabel lblSavesSlotsHeader;
        private DarkUI.Controls.DarkLabel lblSavesBackupsHeader;
        private DarkUI.Controls.DarkLabel lblManagerSavesHint;
        private DarkUI.Controls.DarkSectionPanel grpSavesSelected;
        private DarkUI.Controls.DarkLabel lblSaveGameTitle;
        private DarkUI.Controls.DarkLabel lblSaveGameUser;
        private DarkUI.Controls.DarkLabel lblSaveGamePath;
        private DarkUI.Controls.DarkLabel lblSaveNotInstalled;
        private DarkUI.Controls.SidebarPage tabManagerPatches;
        private DarkUI.Controls.DarkSectionPanel grpPatchesDefinitions;
        private DarkUI.Controls.DarkTabControl tabsPatchesDefinitions;
        private DarkUI.Controls.DarkTabPage tabCheatsDefinitions;
        private DarkUI.Controls.DarkDataGridView dgvPatchesCheats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheatVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheatAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheatOperations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheatStatus;
        private DarkUI.Controls.DarkTabPage tabPatchDefinitions;
        private DarkUI.Controls.DarkDataGridView dgvPatches;
        private DarkUI.Controls.DarkDataGridViewCheckBoxColumn colPatchEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchElf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchOperations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatchStatus;
        private DarkUI.Controls.DarkButton btnPatchesDownload;
        private DarkUI.Controls.DarkButton btnPatchesApply;
        private DarkUI.Controls.DarkButton btnPatchesRevert;
        private DarkUI.Controls.DarkButton btnPatchesOpenData;
        private DarkUI.Controls.DarkButton btnPatchesOpenQtLauncher;
        private DarkUI.Controls.DarkLabel lblPatchesHint;
        private DarkUI.Controls.DarkLabel lblPatchesGame;
        private DarkUI.Controls.DarkComboBox cmbPatchesGame;
        private DarkUI.Controls.SidebarPage tabManagerSettings;
        private DarkUI.Controls.DarkSectionPanel grpSettingsPaths;
        private DarkUI.Controls.DarkLabel darkLabelSettingsCore;
        private DarkUI.Controls.DarkTextBox tbSettingsCore;
        private DarkUI.Controls.DarkButton btnSettingsCoreBrowse;
        private DarkUI.Controls.DarkLabel darkLabelSettingsLauncher;
        private DarkUI.Controls.DarkTextBox tbSettingsLauncher;
        private DarkUI.Controls.DarkButton btnSettingsLauncherBrowse;
        private DarkUI.Controls.DarkButton btnSettingsLauncherOpen;
        private DarkUI.Controls.DarkLabel darkLabelSettingsInstallDir;
        private DarkUI.Controls.DarkTextBox tbSettingsInstallDir;
        private DarkUI.Controls.DarkButton btnSettingsInstallDirBrowse;
        private DarkUI.Controls.DarkButton btnSettingsConfigFolder;
        private DarkUI.Controls.DarkSectionPanel grpSettingsUpdate;
        private DarkUI.Controls.DarkButton btnSettingsCheckUpdates;
        private DarkUI.Controls.DarkSectionPanel grpSettingsDetection;
        private DarkUI.Controls.DarkLabel lblSettingsDetect;
        private DarkUI.Controls.DarkSectionPanel grpCurrentSetup;
        private DarkUI.Controls.DarkGroupBox grpCoreCard;
        private DarkUI.Controls.DarkLabel lblCoreCardState;
        private DarkUI.Controls.DarkLabel lblCoreCardDate;
        private DarkUI.Controls.DarkLabel lblCoreCardSha;
        private DarkUI.Controls.DarkButton btnCoreCardOpenFolder;
        private DarkUI.Controls.DarkGroupBox grpLauncherCard;
        private DarkUI.Controls.DarkLabel lblLauncherCardState;
        private DarkUI.Controls.DarkLabel lblLauncherCardDate;
        private DarkUI.Controls.DarkLabel lblLauncherCardSha;
        private DarkUI.Controls.DarkButton btnLauncherCardOpenFolder;
        private DarkUI.Controls.DarkSectionPanel grpInstalledBuilds;
        private DarkUI.Controls.DarkTabControl tabsBuilds;
        private DarkUI.Controls.DarkTabPage tabPageCore;
        private DarkUI.Controls.DarkListBox lstCoreBuilds;
        private DarkUI.Controls.DarkTabPage tabPageLauncher;
        private DarkUI.Controls.DarkListBox lstLauncherBuilds;
        private DarkUI.Controls.DarkButton btnBuildActivate;
        private DarkUI.Controls.DarkButton btnBuildOpenFolder;
        private DarkUI.Controls.DarkButton btnBuildRemove;
        private DarkUI.Controls.DarkButton btnInstallShadps4;
        private DarkUI.Controls.DarkButton btnChooseCoreVersion;
        private DarkUI.Controls.DarkButton btnMaintenance;
        private DarkUI.Controls.DarkContextMenu ctxMaintenance;
        private System.Windows.Forms.ToolStripMenuItem miMaintenanceReset;
        private System.Windows.Forms.ToolStripMenuItem miMaintenanceRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem miMaintenanceOpenFolder;
        private DarkUI.Controls.DarkLabel lblStatus;
        private DarkUI.Controls.DarkToolTip toolTipBuilds;
        private DarkUI.Controls.DarkButton btncopyDetectioninfo;
        private DarkUI.Controls.SidebarPage tabManagerGames;
        private DarkUI.Controls.DarkSectionPanel grpInstallActivity;
        private DarkUI.Controls.DarkButton btnInstallDismiss;
        private DarkUI.Controls.DarkButton btnInstallOpenFolder;
        private DarkUI.Controls.DarkButton btnInstallCancel;
        private DarkUI.Controls.DarkProgressBar prgInstallProgress;
        private DarkUI.Controls.DarkLabel lblInstallStage;
        private DarkUI.Controls.DarkLabel lblInstallMeta;
        private DarkUI.Controls.DarkLabel lblInstallTitle;
        private DarkUI.Controls.DarkLabel lblManagerGamesHint;
        private DarkUI.Controls.DarkButton btnManagerGamesRefresh;
        private DarkUI.Controls.DarkButton btnManagerGameMore;
        private DarkUI.Controls.DarkButton btnManagerGameOpenFolder;
        private DarkUI.Controls.DarkButton btnManagerGameReports;
        private DarkUI.Controls.DarkButton btnManagerGameCreateReport;
        private DarkUI.Controls.DarkButton btnManagerGameAddFeedback;
        private DarkUI.Controls.DarkButton btnManagerGameLaunch;
        private DarkUI.Controls.DarkLabel lblGameDetailRecent;
        private DarkUI.Controls.DarkLabel lblGameDetailRecentHeader;
        private DarkUI.Controls.DarkLabel lblGameDetailPath;
        private DarkUI.Controls.DarkLabel lblGameDetailSize;
        private DarkUI.Controls.DarkLabel lblGameDetailBest;
        private DarkUI.Controls.DarkLabel lblGameDetailReports;
        private DarkUI.Controls.DarkLabel lblGameDetailLastTest;
        private DarkUI.Controls.DarkLabel lblGameDetailCompat;
        private DarkUI.Controls.DarkLabel lblGameDetailMeta;
        private DarkUI.Controls.DarkLabel lblGameDetailTitle;
        private System.Windows.Forms.PictureBox picManagerGameIcon;
        private DarkUI.Controls.DarkListView lvManagerGames;
    }
}

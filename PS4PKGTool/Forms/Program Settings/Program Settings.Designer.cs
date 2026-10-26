namespace PS4PKGTool
{
    partial class ProgramSetting
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lbPkgDirectoryList = new DarkUI.Controls.DarkListBox(components);
            darkCheckBoxRecursive = new DarkUI.Controls.DarkCheckBox();
            btnAddPkgDirectory = new DarkUI.Controls.DarkButton();
            btnDeletePkgDirectory = new DarkUI.Controls.DarkButton();
            btnClearAllPkgDirectory = new DarkUI.Controls.DarkButton();
            grpStartup = new DarkUI.Controls.DarkSectionPanel();
            AutoSortRow = new DarkUI.Controls.DarkCheckBox();
            cbAutoFetchUpdate = new DarkUI.Controls.DarkCheckBox();
            grpDirList = new DarkUI.Controls.DarkSectionPanel();
            BGM = new DarkUI.Controls.DarkCheckBox();
            cmbTheme = new DarkUI.Controls.DarkComboBox();
            btnOpenAppData = new DarkUI.Controls.DarkButton();
            grpPkgExtraction = new DarkUI.Controls.DarkSectionPanel();
            btnUseDefaultOrbisTempDirectory = new DarkUI.Controls.DarkButton();
            btnBrowseOrbisTempDirectory = new DarkUI.Controls.DarkButton();
            tbOrbisTempDirectory = new DarkUI.Controls.DarkTextBox();
            lblOrbisTempDirectory = new DarkUI.Controls.DarkLabel();
            grpColors = new DarkUI.Controls.DarkSectionPanel();
            darkLabel13 = new DarkUI.Controls.DarkLabel();
            darkLabel7 = new DarkUI.Controls.DarkLabel();
            PKGColorLabeling = new DarkUI.Controls.DarkCheckBox();
            darkLabelGamePkgColorLabel = new DarkUI.Controls.DarkLabel();
            btnGamePkgForeColor = new DarkUI.Controls.DarkButton();
            btnGamePkgBackColor = new DarkUI.Controls.DarkButton();
            darkLabelPatchPkgColorLabel = new DarkUI.Controls.DarkLabel();
            btnPatchPkgForeColor = new DarkUI.Controls.DarkButton();
            btnPatchPkgBackColor = new DarkUI.Controls.DarkButton();
            darkLabelAddonPkgColorLabel = new DarkUI.Controls.DarkLabel();
            btnAddonPkgForeColor = new DarkUI.Controls.DarkButton();
            btnAddonPkgBackColor = new DarkUI.Controls.DarkButton();
            darkLabelAppPkgColorLabel = new DarkUI.Controls.DarkLabel();
            btnAppPkgForeColor = new DarkUI.Controls.DarkButton();
            btnAppPkgBackColor = new DarkUI.Controls.DarkButton();
            btnResetPkgLabelColor = new DarkUI.Controls.DarkButton();
            grpColumns = new DarkUI.Controls.DarkSectionPanel();
            PKGname = new DarkUI.Controls.DarkCheckBox();
            TitleId = new DarkUI.Controls.DarkCheckBox();
            ContentId = new DarkUI.Controls.DarkCheckBox();
            Region = new DarkUI.Controls.DarkCheckBox();
            SystemFirmware = new DarkUI.Controls.DarkCheckBox();
            Version = new DarkUI.Controls.DarkCheckBox();
            PkgType = new DarkUI.Controls.DarkCheckBox();
            Category = new DarkUI.Controls.DarkCheckBox();
            Size = new DarkUI.Controls.DarkCheckBox();
            Location = new DarkUI.Controls.DarkCheckBox();
            cbBackported = new DarkUI.Controls.DarkCheckBox();
            grpPS5BC = new DarkUI.Controls.DarkSectionPanel();
            cbPs5BcCheck = new DarkUI.Controls.DarkCheckBox();
            btnDownloadPS5BCJson = new DarkUI.Controls.DarkButton();
            darkLabel9 = new DarkUI.Controls.DarkLabel();
            labelPs5BcJsonDownloadDate = new DarkUI.Controls.DarkLabel();
            grpShadps4Config = new DarkUI.Controls.DarkSectionPanel();
            cbShadps4Check = new DarkUI.Controls.DarkCheckBox();
            darkLabelShadps4Os = new DarkUI.Controls.DarkLabel();
            cmbShadps4Os = new DarkUI.Controls.DarkComboBox();
            btnDownloadShadps4Json = new DarkUI.Controls.DarkButton();
            darkLabelShadps4 = new DarkUI.Controls.DarkLabel();
            labelShadps4JsonDate = new DarkUI.Controls.DarkLabel();
            grpNetwork = new DarkUI.Controls.DarkSectionPanel();
            darkLabel1 = new DarkUI.Controls.DarkLabel();
            darkComboBoxServerIP = new DarkUI.Controls.DarkComboBox();
            darkLabel2 = new DarkUI.Controls.DarkLabel();
            tbPS4IP = new DarkUI.Controls.DarkTextBox();
            btnPingPs4 = new DarkUI.Controls.DarkButton();
            grpTools = new DarkUI.Controls.DarkSectionPanel();
            darkLabel3 = new DarkUI.Controls.DarkLabel();
            darkLabelNodejsInstalled = new DarkUI.Controls.DarkLabel();
            btnInstallNodejs = new DarkUI.Controls.DarkButton();
            darkLabel4 = new DarkUI.Controls.DarkLabel();
            darkLabelserveModuleInstalled = new DarkUI.Controls.DarkLabel();
            btnInstalleServerModule = new DarkUI.Controls.DarkButton();
            grpRename = new DarkUI.Controls.DarkSectionPanel();
            darkLabel12 = new DarkUI.Controls.DarkLabel();
            tbCustomNamePattern = new DarkUI.Controls.DarkTextBox();
            darkLabelPlaceholderHint = new DarkUI.Controls.DarkLabel();
            btnPlaceTitle = new DarkUI.Controls.DarkButton();
            btnPlaceTitleId = new DarkUI.Controls.DarkButton();
            btnPlaceVersion = new DarkUI.Controls.DarkButton();
            btnPlaceAppVer = new DarkUI.Controls.DarkButton();
            btnPlaceCategory = new DarkUI.Controls.DarkButton();
            btnPlaceContentId = new DarkUI.Controls.DarkButton();
            btnPlaceRegion = new DarkUI.Controls.DarkButton();
            btnPlaceSysVer = new DarkUI.Controls.DarkButton();
            darkButton1 = new DarkUI.Controls.DarkButton();
            darkLabelNamingPatternExample = new DarkUI.Controls.DarkLabel();
            grpTrophyCache = new DarkUI.Controls.DarkSectionPanel();
            pbTrophyCacheProgress = new DarkUI.Controls.DarkProgressBar();
            lblTrophyCacheDesc = new DarkUI.Controls.DarkLabel();
            btnBuildTrophyCache = new DarkUI.Controls.DarkButton();
            btnCancelTrophyCache = new DarkUI.Controls.DarkButton();
            btnClearTrophyCache = new DarkUI.Controls.DarkButton();
            lblTrophyCacheStatus = new DarkUI.Controls.DarkLabel();
            btnOpenShadps4Manager = new DarkUI.Controls.DarkButton();
            btnSaveClose = new DarkUI.Controls.DarkButton();
            darkSidebarTabControl1 = new DarkUI.Controls.DarkSidebarTabControl();
            sidebarPage1 = new DarkUI.Controls.SidebarPage();
            grpShellIntegration = new DarkUI.Controls.DarkSectionPanel();
            btnShellRemove = new DarkUI.Controls.DarkButton();
            btnShellInstall = new DarkUI.Controls.DarkButton();
            lblShellIntegrationStatus = new DarkUI.Controls.DarkLabel();
            lblShellIntegrationTitle = new DarkUI.Controls.DarkLabel();
            darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            darkLabel5 = new DarkUI.Controls.DarkLabel();
            darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            sidebarPage2 = new DarkUI.Controls.SidebarPage();
            darkSectionPanel3 = new DarkUI.Controls.DarkSectionPanel();
            darkThemeSelector1 = new DarkUI.Controls.DarkThemeSelector();
            sidebarPage3 = new DarkUI.Controls.SidebarPage();
            sidebarPage4 = new DarkUI.Controls.SidebarPage();
            sidebarPage5 = new DarkUI.Controls.SidebarPage();
            sidebarPage6 = new DarkUI.Controls.SidebarPage();
            darkLabel14 = new DarkUI.Controls.DarkLabel();
            darkHeaderBar1 = new DarkUI.Controls.DarkHeaderBar();
            darkFooterBar1 = new DarkUI.Controls.DarkFooterBar();
            grpStartup.SuspendLayout();
            grpDirList.SuspendLayout();
            grpPkgExtraction.SuspendLayout();
            grpColors.SuspendLayout();
            grpColumns.SuspendLayout();
            grpPS5BC.SuspendLayout();
            grpShadps4Config.SuspendLayout();
            grpNetwork.SuspendLayout();
            grpTools.SuspendLayout();
            grpRename.SuspendLayout();
            grpTrophyCache.SuspendLayout();
            darkSidebarTabControl1.SuspendLayout();
            sidebarPage1.SuspendLayout();
            grpShellIntegration.SuspendLayout();
            darkSectionPanel2.SuspendLayout();
            darkSectionPanel1.SuspendLayout();
            sidebarPage2.SuspendLayout();
            darkSectionPanel3.SuspendLayout();
            sidebarPage3.SuspendLayout();
            sidebarPage4.SuspendLayout();
            sidebarPage5.SuspendLayout();
            sidebarPage6.SuspendLayout();
            darkFooterBar1.SuspendLayout();
            SuspendLayout();
            // 
            // lbPkgDirectoryList
            // 
            lbPkgDirectoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbPkgDirectoryList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lbPkgDirectoryList.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbPkgDirectoryList.FormattingEnabled = true;
            lbPkgDirectoryList.ItemHeight = 15;
            lbPkgDirectoryList.Location = new System.Drawing.Point(13, 37);
            lbPkgDirectoryList.Name = "lbPkgDirectoryList";
            lbPkgDirectoryList.Size = new System.Drawing.Size(570, 107);
            lbPkgDirectoryList.TabIndex = 0;
            lbPkgDirectoryList.TabStop = false;
            lbPkgDirectoryList.UseTabStops = false;
            // 
            // darkCheckBoxRecursive
            // 
            darkCheckBoxRecursive.AutoSize = true;
            darkCheckBoxRecursive.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkCheckBoxRecursive.Location = new System.Drawing.Point(14, 198);
            darkCheckBoxRecursive.Name = "darkCheckBoxRecursive";
            darkCheckBoxRecursive.Size = new System.Drawing.Size(110, 19);
            darkCheckBoxRecursive.TabIndex = 1;
            darkCheckBoxRecursive.Text = "Scan recursively";
            // 
            // btnAddPkgDirectory
            // 
            btnAddPkgDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddPkgDirectory.Location = new System.Drawing.Point(13, 157);
            btnAddPkgDirectory.Name = "btnAddPkgDirectory";
            btnAddPkgDirectory.Size = new System.Drawing.Size(132, 28);
            btnAddPkgDirectory.TabIndex = 2;
            btnAddPkgDirectory.Text = "Add Directory";
            btnAddPkgDirectory.Click += btnAddPkgDirectory_Click;
            // 
            // btnDeletePkgDirectory
            // 
            btnDeletePkgDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnDeletePkgDirectory.Location = new System.Drawing.Point(158, 157);
            btnDeletePkgDirectory.Name = "btnDeletePkgDirectory";
            btnDeletePkgDirectory.Size = new System.Drawing.Size(132, 28);
            btnDeletePkgDirectory.TabIndex = 3;
            btnDeletePkgDirectory.Text = "Remove";
            btnDeletePkgDirectory.Click += btnDeletePkgDirectory_Click;
            // 
            // btnClearAllPkgDirectory
            // 
            btnClearAllPkgDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnClearAllPkgDirectory.Location = new System.Drawing.Point(303, 157);
            btnClearAllPkgDirectory.Name = "btnClearAllPkgDirectory";
            btnClearAllPkgDirectory.Size = new System.Drawing.Size(132, 28);
            btnClearAllPkgDirectory.TabIndex = 4;
            btnClearAllPkgDirectory.Text = "Clear All";
            btnClearAllPkgDirectory.Click += btnClearAllPkgDirectory_Click;
            // 
            // grpStartup
            // 
            grpStartup.Controls.Add(AutoSortRow);
            grpStartup.Controls.Add(cbAutoFetchUpdate);
            grpStartup.Location = new System.Drawing.Point(12, 254);
            grpStartup.Margin = new System.Windows.Forms.Padding(6);
            grpStartup.Name = "grpStartup";
            grpStartup.Padding = new System.Windows.Forms.Padding(12);
            grpStartup.SectionHeader = "Library Behavior";
            grpStartup.Size = new System.Drawing.Size(601, 91);
            grpStartup.TabIndex = 2;
            // 
            // AutoSortRow
            // 
            AutoSortRow.AutoSize = true;
            AutoSortRow.Font = new System.Drawing.Font("Segoe UI", 9F);
            AutoSortRow.ForeColor = System.Drawing.Color.Gainsboro;
            AutoSortRow.Location = new System.Drawing.Point(13, 37);
            AutoSortRow.Name = "AutoSortRow";
            AutoSortRow.Size = new System.Drawing.Size(151, 19);
            AutoSortRow.TabIndex = 2;
            AutoSortRow.Text = "Sort PKGs automatically";
            // 
            // cbAutoFetchUpdate
            // 
            cbAutoFetchUpdate.AutoSize = true;
            cbAutoFetchUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbAutoFetchUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            cbAutoFetchUpdate.Location = new System.Drawing.Point(13, 59);
            cbAutoFetchUpdate.Name = "cbAutoFetchUpdate";
            cbAutoFetchUpdate.Size = new System.Drawing.Size(243, 19);
            cbAutoFetchUpdate.TabIndex = 3;
            cbAutoFetchUpdate.Text = "Check for latest game updates on startup";
            // 
            // grpDirList
            // 
            grpDirList.Controls.Add(lbPkgDirectoryList);
            grpDirList.Controls.Add(darkCheckBoxRecursive);
            grpDirList.Controls.Add(btnAddPkgDirectory);
            grpDirList.Controls.Add(btnDeletePkgDirectory);
            grpDirList.Controls.Add(btnClearAllPkgDirectory);
            grpDirList.Location = new System.Drawing.Point(12, 12);
            grpDirList.Margin = new System.Windows.Forms.Padding(6);
            grpDirList.Name = "grpDirList";
            grpDirList.Padding = new System.Windows.Forms.Padding(12);
            grpDirList.SectionHeader = "PKG Directory List";
            grpDirList.Size = new System.Drawing.Size(596, 230);
            grpDirList.TabIndex = 1;
            // 
            // BGM
            // 
            BGM.AutoSize = true;
            BGM.Font = new System.Drawing.Font("Segoe UI", 9F);
            BGM.ForeColor = System.Drawing.Color.Gainsboro;
            BGM.Location = new System.Drawing.Point(13, 37);
            BGM.Name = "BGM";
            BGM.Size = new System.Drawing.Size(220, 19);
            BGM.TabIndex = 1;
            BGM.Text = "Play selected PKG background music";
            // 
            // cmbTheme
            // 
            cmbTheme.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbTheme.Location = new System.Drawing.Point(140, 7);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.Size = new System.Drawing.Size(180, 24);
            cmbTheme.TabIndex = 5;
            cmbTheme.Visible = false;
            // 
            // btnOpenAppData
            // 
            btnOpenAppData.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnOpenAppData.Location = new System.Drawing.Point(416, 44);
            btnOpenAppData.Name = "btnOpenAppData";
            btnOpenAppData.Size = new System.Drawing.Size(120, 24);
            btnOpenAppData.TabIndex = 4;
            btnOpenAppData.Text = "Open App Data";
            btnOpenAppData.Click += btnOpenAppData_Click;
            // 
            // grpPkgExtraction
            // 
            grpPkgExtraction.Controls.Add(btnUseDefaultOrbisTempDirectory);
            grpPkgExtraction.Controls.Add(btnBrowseOrbisTempDirectory);
            grpPkgExtraction.Controls.Add(tbOrbisTempDirectory);
            grpPkgExtraction.Controls.Add(lblOrbisTempDirectory);
            grpPkgExtraction.Location = new System.Drawing.Point(12, 196);
            grpPkgExtraction.Margin = new System.Windows.Forms.Padding(6);
            grpPkgExtraction.Name = "grpPkgExtraction";
            grpPkgExtraction.Padding = new System.Windows.Forms.Padding(12);
            grpPkgExtraction.SectionHeader = "PKG Extraction";
            // 112 (was 98): the description wraps to two lines at every DPI,
            // so the input row moves down one line and the panel follows.
            grpPkgExtraction.Size = new System.Drawing.Size(597, 112);
            grpPkgExtraction.TabIndex = 2;
            // 
            // btnUseDefaultOrbisTempDirectory
            // 
            btnUseDefaultOrbisTempDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnUseDefaultOrbisTempDirectory.Location = new System.Drawing.Point(509, 75);
            btnUseDefaultOrbisTempDirectory.Name = "btnUseDefaultOrbisTempDirectory";
            btnUseDefaultOrbisTempDirectory.Size = new System.Drawing.Size(75, 26);
            btnUseDefaultOrbisTempDirectory.TabIndex = 3;
            btnUseDefaultOrbisTempDirectory.Text = "Default";
            btnUseDefaultOrbisTempDirectory.Click += btnUseDefaultOrbisTempDirectory_Click;
            // 
            // btnBrowseOrbisTempDirectory
            // 
            btnBrowseOrbisTempDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnBrowseOrbisTempDirectory.Location = new System.Drawing.Point(426, 75);
            btnBrowseOrbisTempDirectory.Name = "btnBrowseOrbisTempDirectory";
            btnBrowseOrbisTempDirectory.Size = new System.Drawing.Size(75, 26);
            btnBrowseOrbisTempDirectory.TabIndex = 2;
            btnBrowseOrbisTempDirectory.Text = "Browse...";
            btnBrowseOrbisTempDirectory.Click += btnBrowseOrbisTempDirectory_Click;
            // 
            // tbOrbisTempDirectory
            // 
            tbOrbisTempDirectory.Location = new System.Drawing.Point(13, 77);
            tbOrbisTempDirectory.Name = "tbOrbisTempDirectory";
            tbOrbisTempDirectory.Size = new System.Drawing.Size(405, 23);
            tbOrbisTempDirectory.TabIndex = 1;
            // 
            // lblOrbisTempDirectory
            // 
            lblOrbisTempDirectory.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOrbisTempDirectory.Location = new System.Drawing.Point(13, 37);
            lblOrbisTempDirectory.Name = "lblOrbisTempDirectory";
            lblOrbisTempDirectory.Size = new System.Drawing.Size(570, 36);
            lblOrbisTempDirectory.TabIndex = 0;
            lblOrbisTempDirectory.Text = "Temporary directory for PKG preview and extraction staging. Leave blank to use the Windows temporary directory.";
            // 
            // grpColors
            // 
            grpColors.Controls.Add(darkLabel13);
            grpColors.Controls.Add(darkLabel7);
            grpColors.Controls.Add(PKGColorLabeling);
            grpColors.Controls.Add(darkLabelGamePkgColorLabel);
            grpColors.Controls.Add(btnGamePkgForeColor);
            grpColors.Controls.Add(btnGamePkgBackColor);
            grpColors.Controls.Add(darkLabelPatchPkgColorLabel);
            grpColors.Controls.Add(btnPatchPkgForeColor);
            grpColors.Controls.Add(btnPatchPkgBackColor);
            grpColors.Controls.Add(darkLabelAddonPkgColorLabel);
            grpColors.Controls.Add(btnAddonPkgForeColor);
            grpColors.Controls.Add(btnAddonPkgBackColor);
            grpColors.Controls.Add(darkLabelAppPkgColorLabel);
            grpColors.Controls.Add(btnAppPkgForeColor);
            grpColors.Controls.Add(btnAppPkgBackColor);
            grpColors.Controls.Add(btnResetPkgLabelColor);
            grpColors.Location = new System.Drawing.Point(12, 102);
            grpColors.Margin = new System.Windows.Forms.Padding(6);
            grpColors.Name = "grpColors";
            grpColors.Padding = new System.Windows.Forms.Padding(12);
            grpColors.SectionHeader = "PKG Color Labeling";
            grpColors.Size = new System.Drawing.Size(601, 265);
            grpColors.TabIndex = 1;
            // 
            // darkLabel13
            // 
            darkLabel13.Location = new System.Drawing.Point(198, 73);
            darkLabel13.Name = "darkLabel13";
            darkLabel13.Size = new System.Drawing.Size(77, 15);
            darkLabel13.TabIndex = 15;
            darkLabel13.Text = "Background";
            // 
            // darkLabel7
            // 
            darkLabel7.Location = new System.Drawing.Point(106, 73);
            darkLabel7.Name = "darkLabel7";
            // Widened: "Text Color" clipped at high DPI (snug design width).
            darkLabel7.Size = new System.Drawing.Size(75, 15);
            darkLabel7.TabIndex = 14;
            darkLabel7.Text = "Text Color";
            // 
            // PKGColorLabeling
            // 
            PKGColorLabeling.AutoSize = true;
            PKGColorLabeling.Font = new System.Drawing.Font("Segoe UI", 9F);
            PKGColorLabeling.ForeColor = System.Drawing.Color.Gainsboro;
            PKGColorLabeling.Location = new System.Drawing.Point(13, 37);
            PKGColorLabeling.Name = "PKGColorLabeling";
            PKGColorLabeling.Size = new System.Drawing.Size(136, 19);
            PKGColorLabeling.TabIndex = 0;
            PKGColorLabeling.Text = "Enable color labeling";
            // 
            // darkLabelGamePkgColorLabel
            // 
            darkLabelGamePkgColorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelGamePkgColorLabel.Location = new System.Drawing.Point(13, 97);
            darkLabelGamePkgColorLabel.Name = "darkLabelGamePkgColorLabel";
            darkLabelGamePkgColorLabel.Size = new System.Drawing.Size(55, 24);
            darkLabelGamePkgColorLabel.TabIndex = 1;
            darkLabelGamePkgColorLabel.Text = "Game";
            darkLabelGamePkgColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGamePkgForeColor
            // 
            btnGamePkgForeColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnGamePkgForeColor.Location = new System.Drawing.Point(96, 97);
            btnGamePkgForeColor.Name = "btnGamePkgForeColor";
            btnGamePkgForeColor.Size = new System.Drawing.Size(80, 24);
            btnGamePkgForeColor.TabIndex = 2;
            btnGamePkgForeColor.Text = "Choose...";
            btnGamePkgForeColor.Click += SetPKGLabelColor_Click;
            // 
            // btnGamePkgBackColor
            // 
            btnGamePkgBackColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnGamePkgBackColor.Location = new System.Drawing.Point(194, 97);
            btnGamePkgBackColor.Name = "btnGamePkgBackColor";
            btnGamePkgBackColor.Size = new System.Drawing.Size(80, 24);
            btnGamePkgBackColor.TabIndex = 3;
            btnGamePkgBackColor.Text = "Choose...";
            btnGamePkgBackColor.Click += SetPKGLabelColor_Click;
            // 
            // darkLabelPatchPkgColorLabel
            // 
            darkLabelPatchPkgColorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelPatchPkgColorLabel.Location = new System.Drawing.Point(13, 126);
            darkLabelPatchPkgColorLabel.Name = "darkLabelPatchPkgColorLabel";
            darkLabelPatchPkgColorLabel.Size = new System.Drawing.Size(55, 24);
            darkLabelPatchPkgColorLabel.TabIndex = 4;
            darkLabelPatchPkgColorLabel.Text = "Patch";
            darkLabelPatchPkgColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPatchPkgForeColor
            // 
            btnPatchPkgForeColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPatchPkgForeColor.Location = new System.Drawing.Point(96, 126);
            btnPatchPkgForeColor.Name = "btnPatchPkgForeColor";
            btnPatchPkgForeColor.Size = new System.Drawing.Size(80, 24);
            btnPatchPkgForeColor.TabIndex = 5;
            btnPatchPkgForeColor.Text = "Choose...";
            btnPatchPkgForeColor.Click += SetPKGLabelColor_Click;
            // 
            // btnPatchPkgBackColor
            // 
            btnPatchPkgBackColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPatchPkgBackColor.Location = new System.Drawing.Point(194, 126);
            btnPatchPkgBackColor.Name = "btnPatchPkgBackColor";
            btnPatchPkgBackColor.Size = new System.Drawing.Size(80, 24);
            btnPatchPkgBackColor.TabIndex = 6;
            btnPatchPkgBackColor.Text = "Choose...";
            btnPatchPkgBackColor.Click += SetPKGLabelColor_Click;
            // 
            // darkLabelAddonPkgColorLabel
            // 
            darkLabelAddonPkgColorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelAddonPkgColorLabel.Location = new System.Drawing.Point(13, 155);
            darkLabelAddonPkgColorLabel.Name = "darkLabelAddonPkgColorLabel";
            darkLabelAddonPkgColorLabel.Size = new System.Drawing.Size(55, 24);
            darkLabelAddonPkgColorLabel.TabIndex = 7;
            darkLabelAddonPkgColorLabel.Text = "Addon";
            darkLabelAddonPkgColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddonPkgForeColor
            // 
            btnAddonPkgForeColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddonPkgForeColor.Location = new System.Drawing.Point(96, 155);
            btnAddonPkgForeColor.Name = "btnAddonPkgForeColor";
            btnAddonPkgForeColor.Size = new System.Drawing.Size(80, 24);
            btnAddonPkgForeColor.TabIndex = 8;
            btnAddonPkgForeColor.Text = "Choose...";
            btnAddonPkgForeColor.Click += SetPKGLabelColor_Click;
            // 
            // btnAddonPkgBackColor
            // 
            btnAddonPkgBackColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAddonPkgBackColor.Location = new System.Drawing.Point(194, 155);
            btnAddonPkgBackColor.Name = "btnAddonPkgBackColor";
            btnAddonPkgBackColor.Size = new System.Drawing.Size(80, 24);
            btnAddonPkgBackColor.TabIndex = 9;
            btnAddonPkgBackColor.Text = "Choose...";
            btnAddonPkgBackColor.Click += SetPKGLabelColor_Click;
            // 
            // darkLabelAppPkgColorLabel
            // 
            darkLabelAppPkgColorLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelAppPkgColorLabel.Location = new System.Drawing.Point(13, 184);
            darkLabelAppPkgColorLabel.Name = "darkLabelAppPkgColorLabel";
            darkLabelAppPkgColorLabel.Size = new System.Drawing.Size(55, 24);
            darkLabelAppPkgColorLabel.TabIndex = 10;
            darkLabelAppPkgColorLabel.Text = "App";
            darkLabelAppPkgColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAppPkgForeColor
            // 
            btnAppPkgForeColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAppPkgForeColor.Location = new System.Drawing.Point(96, 184);
            btnAppPkgForeColor.Name = "btnAppPkgForeColor";
            btnAppPkgForeColor.Size = new System.Drawing.Size(80, 24);
            btnAppPkgForeColor.TabIndex = 11;
            btnAppPkgForeColor.Text = "Choose...";
            btnAppPkgForeColor.Click += SetPKGLabelColor_Click;
            // 
            // btnAppPkgBackColor
            // 
            btnAppPkgBackColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAppPkgBackColor.Location = new System.Drawing.Point(194, 184);
            btnAppPkgBackColor.Name = "btnAppPkgBackColor";
            btnAppPkgBackColor.Size = new System.Drawing.Size(80, 24);
            btnAppPkgBackColor.TabIndex = 12;
            btnAppPkgBackColor.Text = "Choose...";
            btnAppPkgBackColor.Click += SetPKGLabelColor_Click;
            // 
            // btnResetPkgLabelColor
            // 
            btnResetPkgLabelColor.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnResetPkgLabelColor.Location = new System.Drawing.Point(13, 228);
            btnResetPkgLabelColor.Name = "btnResetPkgLabelColor";
            btnResetPkgLabelColor.Size = new System.Drawing.Size(91, 24);
            btnResetPkgLabelColor.TabIndex = 13;
            btnResetPkgLabelColor.Text = "Reset Color";
            btnResetPkgLabelColor.Click += SetPKGLabelColor_Click;
            // 
            // grpColumns
            // 
            grpColumns.Controls.Add(PKGname);
            grpColumns.Controls.Add(TitleId);
            grpColumns.Controls.Add(ContentId);
            grpColumns.Controls.Add(Region);
            grpColumns.Controls.Add(SystemFirmware);
            grpColumns.Controls.Add(Version);
            grpColumns.Controls.Add(PkgType);
            grpColumns.Controls.Add(Category);
            grpColumns.Controls.Add(Size);
            grpColumns.Controls.Add(Location);
            grpColumns.Controls.Add(cbBackported);
            grpColumns.Location = new System.Drawing.Point(12, 379);
            grpColumns.Margin = new System.Windows.Forms.Padding(6);
            grpColumns.Name = "grpColumns";
            grpColumns.Padding = new System.Windows.Forms.Padding(12);
            grpColumns.SectionHeader = "Column Visibility";
            grpColumns.Size = new System.Drawing.Size(601, 117);
            grpColumns.TabIndex = 0;
            // 
            // PKGname
            // 
            PKGname.AutoSize = true;
            PKGname.Checked = true;
            PKGname.CheckState = System.Windows.Forms.CheckState.Checked;
            PKGname.Enabled = false;
            PKGname.Font = new System.Drawing.Font("Segoe UI", 9F);
            PKGname.Location = new System.Drawing.Point(13, 37);
            PKGname.Name = "PKGname";
            PKGname.Size = new System.Drawing.Size(74, 19);
            PKGname.TabIndex = 0;
            PKGname.Text = "Filename";
            // 
            // TitleId
            // 
            TitleId.AutoSize = true;
            TitleId.Checked = true;
            TitleId.CheckState = System.Windows.Forms.CheckState.Checked;
            TitleId.Font = new System.Drawing.Font("Segoe UI", 9F);
            TitleId.Location = new System.Drawing.Point(167, 37);
            TitleId.Name = "TitleId";
            TitleId.Size = new System.Drawing.Size(63, 19);
            TitleId.TabIndex = 1;
            TitleId.Text = "Title ID";
            // 
            // ContentId
            // 
            ContentId.AutoSize = true;
            ContentId.Checked = true;
            ContentId.CheckState = System.Windows.Forms.CheckState.Checked;
            ContentId.Font = new System.Drawing.Font("Segoe UI", 9F);
            ContentId.Location = new System.Drawing.Point(310, 37);
            ContentId.Name = "ContentId";
            ContentId.Size = new System.Drawing.Size(83, 19);
            ContentId.TabIndex = 2;
            ContentId.Text = "Content ID";
            // 
            // Region
            // 
            Region.AutoSize = true;
            Region.Checked = true;
            Region.CheckState = System.Windows.Forms.CheckState.Checked;
            Region.Font = new System.Drawing.Font("Segoe UI", 9F);
            Region.Location = new System.Drawing.Point(473, 37);
            Region.Name = "Region";
            Region.Size = new System.Drawing.Size(63, 19);
            Region.TabIndex = 3;
            Region.Text = "Region";
            // 
            // SystemFirmware
            // 
            SystemFirmware.AutoSize = true;
            SystemFirmware.Checked = true;
            SystemFirmware.CheckState = System.Windows.Forms.CheckState.Checked;
            SystemFirmware.Font = new System.Drawing.Font("Segoe UI", 9F);
            SystemFirmware.Location = new System.Drawing.Point(13, 61);
            SystemFirmware.Name = "SystemFirmware";
            SystemFirmware.Size = new System.Drawing.Size(125, 19);
            SystemFirmware.TabIndex = 4;
            SystemFirmware.Text = "Required Firmware";
            // 
            // Version
            // 
            Version.AutoSize = true;
            Version.Checked = true;
            Version.CheckState = System.Windows.Forms.CheckState.Checked;
            Version.Font = new System.Drawing.Font("Segoe UI", 9F);
            Version.Location = new System.Drawing.Point(167, 61);
            Version.Name = "Version";
            Version.Size = new System.Drawing.Size(116, 19);
            Version.TabIndex = 5;
            Version.Text = "Version [App Ver]";
            // 
            // PkgType
            // 
            PkgType.AutoSize = true;
            PkgType.Checked = true;
            PkgType.CheckState = System.Windows.Forms.CheckState.Checked;
            PkgType.Font = new System.Drawing.Font("Segoe UI", 9F);
            PkgType.Location = new System.Drawing.Point(310, 61);
            PkgType.Name = "PkgType";
            PkgType.Size = new System.Drawing.Size(75, 19);
            PkgType.TabIndex = 6;
            PkgType.Text = "PKG Type";
            // 
            // Category
            // 
            Category.AutoSize = true;
            Category.Checked = true;
            Category.CheckState = System.Windows.Forms.CheckState.Checked;
            Category.Font = new System.Drawing.Font("Segoe UI", 9F);
            Category.Location = new System.Drawing.Point(473, 61);
            Category.Name = "Category";
            Category.Size = new System.Drawing.Size(74, 19);
            Category.TabIndex = 7;
            Category.Text = "Category";
            // 
            // Size
            // 
            Size.AutoSize = true;
            Size.Checked = true;
            Size.CheckState = System.Windows.Forms.CheckState.Checked;
            Size.Font = new System.Drawing.Font("Segoe UI", 9F);
            Size.Location = new System.Drawing.Point(13, 85);
            Size.Name = "Size";
            Size.Size = new System.Drawing.Size(46, 19);
            Size.TabIndex = 8;
            Size.Text = "Size";
            // 
            // Location
            // 
            Location.AutoSize = true;
            Location.Checked = true;
            Location.CheckState = System.Windows.Forms.CheckState.Checked;
            Location.Font = new System.Drawing.Font("Segoe UI", 9F);
            Location.Location = new System.Drawing.Point(167, 85);
            Location.Name = "Location";
            Location.Size = new System.Drawing.Size(74, 19);
            Location.TabIndex = 9;
            Location.Text = "Directory";
            // 
            // cbBackported
            // 
            cbBackported.AutoSize = true;
            cbBackported.Checked = true;
            cbBackported.CheckState = System.Windows.Forms.CheckState.Checked;
            cbBackported.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbBackported.Location = new System.Drawing.Point(310, 85);
            cbBackported.Name = "cbBackported";
            cbBackported.Size = new System.Drawing.Size(86, 19);
            cbBackported.TabIndex = 10;
            cbBackported.Text = "Backported";
            // 
            // grpPS5BC
            // 
            grpPS5BC.Controls.Add(cbPs5BcCheck);
            grpPS5BC.Controls.Add(btnDownloadPS5BCJson);
            grpPS5BC.Controls.Add(darkLabel9);
            grpPS5BC.Controls.Add(labelPs5BcJsonDownloadDate);
            grpPS5BC.Location = new System.Drawing.Point(12, 200);
            grpPS5BC.Margin = new System.Windows.Forms.Padding(6);
            grpPS5BC.Name = "grpPS5BC";
            grpPS5BC.Padding = new System.Windows.Forms.Padding(12);
            grpPS5BC.SectionHeader = "PS5 Backward Compatibility";
            grpPS5BC.Size = new System.Drawing.Size(601, 145);
            grpPS5BC.TabIndex = 2;
            // 
            // cbPs5BcCheck
            // 
            cbPs5BcCheck.AutoSize = true;
            cbPs5BcCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbPs5BcCheck.ForeColor = System.Drawing.Color.Gainsboro;
            cbPs5BcCheck.Location = new System.Drawing.Point(13, 37);
            cbPs5BcCheck.Name = "cbPs5BcCheck";
            cbPs5BcCheck.Size = new System.Drawing.Size(275, 19);
            cbPs5BcCheck.TabIndex = 0;
            cbPs5BcCheck.Text = "Show PS5 BC, PSVR, and PS4 Pro status column";
            // 
            // btnDownloadPS5BCJson
            // 
            btnDownloadPS5BCJson.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnDownloadPS5BCJson.Location = new System.Drawing.Point(13, 106);
            btnDownloadPS5BCJson.Name = "btnDownloadPS5BCJson";
            btnDownloadPS5BCJson.Size = new System.Drawing.Size(170, 26);
            btnDownloadPS5BCJson.TabIndex = 1;
            btnDownloadPS5BCJson.Text = "Download BC status data";
            btnDownloadPS5BCJson.Click += btnDownloadPS5BCJson_Click;
            // 
            // darkLabel9
            // 
            darkLabel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            darkLabel9.Location = new System.Drawing.Point(13, 72);
            darkLabel9.Name = "darkLabel9";
            darkLabel9.Size = new System.Drawing.Size(90, 18);
            darkLabel9.TabIndex = 2;
            darkLabel9.Text = "Last download:";
            // 
            // labelPs5BcJsonDownloadDate
            // 
            labelPs5BcJsonDownloadDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            labelPs5BcJsonDownloadDate.Location = new System.Drawing.Point(108, 72);
            labelPs5BcJsonDownloadDate.Name = "labelPs5BcJsonDownloadDate";
            labelPs5BcJsonDownloadDate.Size = new System.Drawing.Size(220, 18);
            labelPs5BcJsonDownloadDate.TabIndex = 3;
            labelPs5BcJsonDownloadDate.Text = "..";
            // 
            // grpShadps4Config
            // 
            grpShadps4Config.Controls.Add(cbShadps4Check);
            grpShadps4Config.Controls.Add(darkLabelShadps4Os);
            grpShadps4Config.Controls.Add(cmbShadps4Os);
            grpShadps4Config.Controls.Add(btnDownloadShadps4Json);
            grpShadps4Config.Controls.Add(darkLabelShadps4);
            grpShadps4Config.Controls.Add(labelShadps4JsonDate);
            grpShadps4Config.Location = new System.Drawing.Point(12, 12);
            grpShadps4Config.Margin = new System.Windows.Forms.Padding(6);
            grpShadps4Config.Name = "grpShadps4Config";
            grpShadps4Config.Padding = new System.Windows.Forms.Padding(12);
            grpShadps4Config.SectionHeader = "shadPS4 Compatibility  ";
            grpShadps4Config.Size = new System.Drawing.Size(601, 176);
            grpShadps4Config.TabIndex = 5;
            // 
            // cbShadps4Check
            // 
            cbShadps4Check.AutoSize = true;
            cbShadps4Check.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbShadps4Check.ForeColor = System.Drawing.Color.Gainsboro;
            cbShadps4Check.Location = new System.Drawing.Point(13, 37);
            cbShadps4Check.Name = "cbShadps4Check";
            cbShadps4Check.Size = new System.Drawing.Size(253, 19);
            cbShadps4Check.TabIndex = 0;
            cbShadps4Check.Text = "Show shadPS4 compatibility status column";
            // 
            // darkLabelShadps4Os
            // 
            darkLabelShadps4Os.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelShadps4Os.Location = new System.Drawing.Point(13, 72);
            darkLabelShadps4Os.Name = "darkLabelShadps4Os";
            darkLabelShadps4Os.Size = new System.Drawing.Size(137, 15);
            darkLabelShadps4Os.TabIndex = 4;
            darkLabelShadps4Os.Text = "Compatibility platform:";
            // 
            // cmbShadps4Os
            // 
            cmbShadps4Os.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbShadps4Os.Items.AddRange(new object[] { "Windows", "Linux", "macOS" });
            cmbShadps4Os.Location = new System.Drawing.Point(151, 67);
            cmbShadps4Os.Name = "cmbShadps4Os";
            cmbShadps4Os.Size = new System.Drawing.Size(146, 24);
            cmbShadps4Os.TabIndex = 5;
            // 
            // btnDownloadShadps4Json
            // 
            btnDownloadShadps4Json.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnDownloadShadps4Json.Location = new System.Drawing.Point(13, 137);
            btnDownloadShadps4Json.Name = "btnDownloadShadps4Json";
            btnDownloadShadps4Json.Size = new System.Drawing.Size(189, 26);
            btnDownloadShadps4Json.TabIndex = 1;
            btnDownloadShadps4Json.Text = "Download Compatibility Data";
            btnDownloadShadps4Json.Click += btnDownloadShadps4Json_Click;
            // 
            // darkLabelShadps4
            // 
            darkLabelShadps4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            darkLabelShadps4.Location = new System.Drawing.Point(13, 103);
            darkLabelShadps4.Name = "darkLabelShadps4";
            darkLabelShadps4.Size = new System.Drawing.Size(90, 18);
            darkLabelShadps4.TabIndex = 2;
            darkLabelShadps4.Text = "Last download:";
            // 
            // labelShadps4JsonDate
            // 
            labelShadps4JsonDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            labelShadps4JsonDate.Location = new System.Drawing.Point(108, 103);
            labelShadps4JsonDate.Name = "labelShadps4JsonDate";
            labelShadps4JsonDate.Size = new System.Drawing.Size(220, 18);
            labelShadps4JsonDate.TabIndex = 3;
            labelShadps4JsonDate.Text = "..";
            // 
            // grpNetwork
            // 
            grpNetwork.Controls.Add(darkLabel1);
            grpNetwork.Controls.Add(darkComboBoxServerIP);
            grpNetwork.Controls.Add(darkLabel2);
            grpNetwork.Controls.Add(tbPS4IP);
            grpNetwork.Controls.Add(btnPingPs4);
            grpNetwork.Location = new System.Drawing.Point(12, 12);
            grpNetwork.Margin = new System.Windows.Forms.Padding(6);
            grpNetwork.Name = "grpNetwork";
            grpNetwork.Padding = new System.Windows.Forms.Padding(12);
            grpNetwork.SectionHeader = "Network";
            grpNetwork.Size = new System.Drawing.Size(601, 124);
            grpNetwork.TabIndex = 0;
            // 
            // darkLabel1
            // 
            darkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel1.Location = new System.Drawing.Point(13, 37);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new System.Drawing.Size(100, 20);
            darkLabel1.TabIndex = 0;
            darkLabel1.Text = "PC IP address:";
            // 
            // darkComboBoxServerIP
            // 
            darkComboBoxServerIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkComboBoxServerIP.FormattingEnabled = true;
            darkComboBoxServerIP.Location = new System.Drawing.Point(13, 57);
            darkComboBoxServerIP.Name = "darkComboBoxServerIP";
            darkComboBoxServerIP.Size = new System.Drawing.Size(200, 24);
            darkComboBoxServerIP.TabIndex = 1;
            // 
            // darkLabel2
            // 
            darkLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel2.Location = new System.Drawing.Point(319, 37);
            darkLabel2.Name = "darkLabel2";
            darkLabel2.Size = new System.Drawing.Size(100, 20);
            darkLabel2.TabIndex = 2;
            darkLabel2.Text = "PS4 IP address:";
            // 
            // tbPS4IP
            // 
            tbPS4IP.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbPS4IP.Location = new System.Drawing.Point(319, 58);
            tbPS4IP.Name = "tbPS4IP";
            tbPS4IP.Size = new System.Drawing.Size(200, 23);
            tbPS4IP.TabIndex = 3;
            tbPS4IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPingPs4
            // 
            btnPingPs4.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPingPs4.Location = new System.Drawing.Point(319, 87);
            btnPingPs4.Name = "btnPingPs4";
            btnPingPs4.Size = new System.Drawing.Size(117, 24);
            btnPingPs4.TabIndex = 4;
            btnPingPs4.Text = "Test Connection";
            btnPingPs4.Click += btnPingPs4_Click;
            // 
            // grpTools
            // 
            grpTools.Controls.Add(darkLabel3);
            grpTools.Controls.Add(darkLabelNodejsInstalled);
            grpTools.Controls.Add(btnInstallNodejs);
            grpTools.Controls.Add(darkLabel4);
            grpTools.Controls.Add(darkLabelserveModuleInstalled);
            grpTools.Controls.Add(btnInstalleServerModule);
            grpTools.Location = new System.Drawing.Point(12, 148);
            grpTools.Margin = new System.Windows.Forms.Padding(6);
            grpTools.Name = "grpTools";
            grpTools.Padding = new System.Windows.Forms.Padding(12);
            grpTools.SectionHeader = "Requirements";
            grpTools.Size = new System.Drawing.Size(601, 76);
            grpTools.TabIndex = 1;
            // 
            // darkLabel3
            // 
            darkLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel3.Location = new System.Drawing.Point(13, 38);
            darkLabel3.Name = "darkLabel3";
            darkLabel3.Size = new System.Drawing.Size(70, 24);
            darkLabel3.TabIndex = 0;
            darkLabel3.Text = "Node.js";
            darkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabelNodejsInstalled
            // 
            darkLabelNodejsInstalled.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelNodejsInstalled.Location = new System.Drawing.Point(83, 38);
            darkLabelNodejsInstalled.Name = "darkLabelNodejsInstalled";
            darkLabelNodejsInstalled.Size = new System.Drawing.Size(30, 24);
            darkLabelNodejsInstalled.TabIndex = 1;
            darkLabelNodejsInstalled.Text = "✘";
            darkLabelNodejsInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInstallNodejs
            // 
            btnInstallNodejs.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnInstallNodejs.Location = new System.Drawing.Point(118, 37);
            btnInstallNodejs.Name = "btnInstallNodejs";
            btnInstallNodejs.Size = new System.Drawing.Size(55, 26);
            btnInstallNodejs.TabIndex = 2;
            btnInstallNodejs.Text = "Install";
            btnInstallNodejs.Click += btnInstallNodejs_Click;
            // 
            // darkLabel4
            // 
            darkLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel4.Location = new System.Drawing.Point(319, 38);
            darkLabel4.Name = "darkLabel4";
            darkLabel4.Size = new System.Drawing.Size(100, 24);
            darkLabel4.TabIndex = 3;
            darkLabel4.Text = "http-server";
            darkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabelserveModuleInstalled
            // 
            darkLabelserveModuleInstalled.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelserveModuleInstalled.Location = new System.Drawing.Point(439, 38);
            darkLabelserveModuleInstalled.Name = "darkLabelserveModuleInstalled";
            darkLabelserveModuleInstalled.Size = new System.Drawing.Size(30, 24);
            darkLabelserveModuleInstalled.TabIndex = 4;
            darkLabelserveModuleInstalled.Text = "✘";
            darkLabelserveModuleInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInstalleServerModule
            // 
            btnInstalleServerModule.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnInstalleServerModule.Location = new System.Drawing.Point(489, 37);
            btnInstalleServerModule.Name = "btnInstalleServerModule";
            btnInstalleServerModule.Size = new System.Drawing.Size(55, 26);
            btnInstalleServerModule.TabIndex = 5;
            btnInstalleServerModule.Text = "Install";
            btnInstalleServerModule.Click += btnInstallServerModule_Click;
            // 
            // grpRename
            // 
            grpRename.Controls.Add(darkLabel12);
            grpRename.Controls.Add(tbCustomNamePattern);
            grpRename.Controls.Add(darkLabelPlaceholderHint);
            grpRename.Controls.Add(btnPlaceTitle);
            grpRename.Controls.Add(btnPlaceTitleId);
            grpRename.Controls.Add(btnPlaceVersion);
            grpRename.Controls.Add(btnPlaceAppVer);
            grpRename.Controls.Add(btnPlaceCategory);
            grpRename.Controls.Add(btnPlaceContentId);
            grpRename.Controls.Add(btnPlaceRegion);
            grpRename.Controls.Add(btnPlaceSysVer);
            grpRename.Controls.Add(darkButton1);
            grpRename.Controls.Add(darkLabelNamingPatternExample);
            grpRename.Location = new System.Drawing.Point(12, 357);
            grpRename.Margin = new System.Windows.Forms.Padding(6);
            grpRename.Name = "grpRename";
            grpRename.Padding = new System.Windows.Forms.Padding(12);
            grpRename.SectionHeader = "Custom File Naming";
            grpRename.Size = new System.Drawing.Size(601, 269);
            grpRename.TabIndex = 0;
            // 
            // darkLabel12
            // 
            darkLabel12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            darkLabel12.Location = new System.Drawing.Point(13, 37);
            darkLabel12.Name = "darkLabel12";
            darkLabel12.Size = new System.Drawing.Size(570, 20);
            darkLabel12.TabIndex = 0;
            darkLabel12.Text = "Filename format:  (files are renamed using this pattern when you Rename PKG)";
            // 
            // tbCustomNamePattern
            // 
            tbCustomNamePattern.Font = new System.Drawing.Font("Consolas", 10F);
            tbCustomNamePattern.Location = new System.Drawing.Point(13, 60);
            tbCustomNamePattern.Name = "tbCustomNamePattern";
            tbCustomNamePattern.Size = new System.Drawing.Size(570, 23);
            tbCustomNamePattern.TabIndex = 1;
            tbCustomNamePattern.TextChanged += tbCustomNamePattern_TextChanged;
            // 
            // darkLabelPlaceholderHint
            // 
            darkLabelPlaceholderHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            darkLabelPlaceholderHint.Location = new System.Drawing.Point(13, 93);
            darkLabelPlaceholderHint.Name = "darkLabelPlaceholderHint";
            darkLabelPlaceholderHint.Size = new System.Drawing.Size(570, 16);
            darkLabelPlaceholderHint.TabIndex = 2;
            darkLabelPlaceholderHint.Text = "Click a button below to insert that value into the format:";
            // 
            // btnPlaceTitle
            // 
            btnPlaceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceTitle.Location = new System.Drawing.Point(13, 113);
            btnPlaceTitle.Name = "btnPlaceTitle";
            btnPlaceTitle.Size = new System.Drawing.Size(135, 26);
            btnPlaceTitle.TabIndex = 10;
            btnPlaceTitle.Tag = "{TITLE}";
            btnPlaceTitle.Text = "{TITLE}";
            btnPlaceTitle.Click += PlaceholderButton_Click;
            // 
            // btnPlaceTitleId
            // 
            btnPlaceTitleId.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceTitleId.Location = new System.Drawing.Point(158, 113);
            btnPlaceTitleId.Name = "btnPlaceTitleId";
            btnPlaceTitleId.Size = new System.Drawing.Size(135, 26);
            btnPlaceTitleId.TabIndex = 11;
            btnPlaceTitleId.Tag = "{TITLE_ID}";
            btnPlaceTitleId.Text = "{TITLE_ID}";
            btnPlaceTitleId.Click += PlaceholderButton_Click;
            // 
            // btnPlaceVersion
            // 
            btnPlaceVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceVersion.Location = new System.Drawing.Point(303, 113);
            btnPlaceVersion.Name = "btnPlaceVersion";
            btnPlaceVersion.Size = new System.Drawing.Size(135, 26);
            btnPlaceVersion.TabIndex = 12;
            btnPlaceVersion.Tag = "{VERSION}";
            btnPlaceVersion.Text = "{VERSION}";
            btnPlaceVersion.Click += PlaceholderButton_Click;
            // 
            // btnPlaceAppVer
            // 
            btnPlaceAppVer.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceAppVer.Location = new System.Drawing.Point(448, 113);
            btnPlaceAppVer.Name = "btnPlaceAppVer";
            btnPlaceAppVer.Size = new System.Drawing.Size(135, 26);
            btnPlaceAppVer.TabIndex = 13;
            btnPlaceAppVer.Tag = "{APP_VERSION}";
            btnPlaceAppVer.Text = "{APP_VERSION}";
            btnPlaceAppVer.Click += PlaceholderButton_Click;
            // 
            // btnPlaceCategory
            // 
            btnPlaceCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceCategory.Location = new System.Drawing.Point(13, 145);
            btnPlaceCategory.Name = "btnPlaceCategory";
            btnPlaceCategory.Size = new System.Drawing.Size(135, 26);
            btnPlaceCategory.TabIndex = 14;
            btnPlaceCategory.Tag = "{CATEGORY}";
            btnPlaceCategory.Text = "{CATEGORY}";
            btnPlaceCategory.Click += PlaceholderButton_Click;
            // 
            // btnPlaceContentId
            // 
            btnPlaceContentId.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceContentId.Location = new System.Drawing.Point(158, 145);
            btnPlaceContentId.Name = "btnPlaceContentId";
            btnPlaceContentId.Size = new System.Drawing.Size(135, 26);
            btnPlaceContentId.TabIndex = 15;
            btnPlaceContentId.Tag = "{CONTENT_ID}";
            btnPlaceContentId.Text = "{CONTENT_ID}";
            btnPlaceContentId.Click += PlaceholderButton_Click;
            // 
            // btnPlaceRegion
            // 
            btnPlaceRegion.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceRegion.Location = new System.Drawing.Point(303, 145);
            btnPlaceRegion.Name = "btnPlaceRegion";
            btnPlaceRegion.Size = new System.Drawing.Size(135, 26);
            btnPlaceRegion.TabIndex = 16;
            btnPlaceRegion.Tag = "{REGION}";
            btnPlaceRegion.Text = "{REGION}";
            btnPlaceRegion.Click += PlaceholderButton_Click;
            // 
            // btnPlaceSysVer
            // 
            btnPlaceSysVer.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPlaceSysVer.Location = new System.Drawing.Point(448, 145);
            btnPlaceSysVer.Name = "btnPlaceSysVer";
            btnPlaceSysVer.Size = new System.Drawing.Size(135, 26);
            btnPlaceSysVer.TabIndex = 17;
            btnPlaceSysVer.Tag = "{SYSTEM_VERSION}";
            btnPlaceSysVer.Text = "{SYSTEM_VERSION}";
            btnPlaceSysVer.Click += PlaceholderButton_Click;
            // 
            // darkButton1
            // 
            darkButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkButton1.Location = new System.Drawing.Point(13, 181);
            darkButton1.Name = "darkButton1";
            darkButton1.Size = new System.Drawing.Size(135, 26);
            darkButton1.TabIndex = 18;
            darkButton1.Text = "Clear Format";
            darkButton1.Click += darkButton1_Click;
            // 
            // darkLabelNamingPatternExample
            // 
            darkLabelNamingPatternExample.Font = new System.Drawing.Font("Segoe UI", 10F);
            darkLabelNamingPatternExample.Location = new System.Drawing.Point(13, 218);
            darkLabelNamingPatternExample.Name = "darkLabelNamingPatternExample";
            darkLabelNamingPatternExample.Size = new System.Drawing.Size(570, 38);
            darkLabelNamingPatternExample.TabIndex = 5;
            // 
            // grpTrophyCache
            // 
            grpTrophyCache.Controls.Add(pbTrophyCacheProgress);
            grpTrophyCache.Controls.Add(lblTrophyCacheDesc);
            grpTrophyCache.Controls.Add(btnBuildTrophyCache);
            grpTrophyCache.Controls.Add(btnCancelTrophyCache);
            grpTrophyCache.Controls.Add(btnClearTrophyCache);
            grpTrophyCache.Controls.Add(lblTrophyCacheStatus);
            grpTrophyCache.Location = new System.Drawing.Point(12, 12);
            grpTrophyCache.Margin = new System.Windows.Forms.Padding(6);
            grpTrophyCache.Name = "grpTrophyCache";
            grpTrophyCache.Padding = new System.Windows.Forms.Padding(12);
            grpTrophyCache.SectionHeader = "Trophy Metadata Cache";
            grpTrophyCache.Size = new System.Drawing.Size(601, 190);
            grpTrophyCache.TabIndex = 0;
            // 
            // pbTrophyCacheProgress
            // 
            pbTrophyCacheProgress.Location = new System.Drawing.Point(13, 125);
            pbTrophyCacheProgress.Name = "pbTrophyCacheProgress";
            pbTrophyCacheProgress.Size = new System.Drawing.Size(575, 23);
            pbTrophyCacheProgress.TabIndex = 6;
            pbTrophyCacheProgress.TextMode = DarkUI.Controls.DarkProgressBarMode.NoText;
            // 
            // lblTrophyCacheDesc
            // 
            lblTrophyCacheDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTrophyCacheDesc.Location = new System.Drawing.Point(13, 37);
            lblTrophyCacheDesc.Name = "lblTrophyCacheDesc";
            lblTrophyCacheDesc.Size = new System.Drawing.Size(575, 38);
            lblTrophyCacheDesc.TabIndex = 0;
            lblTrophyCacheDesc.Text = "Build a local trophy metadata cache from PKGs in your configured directories. Cached IDs enable full trophy names and descriptions when a PKG is selected.";
            // 
            // btnBuildTrophyCache
            // 
            btnBuildTrophyCache.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnBuildTrophyCache.Location = new System.Drawing.Point(13, 83);
            btnBuildTrophyCache.Name = "btnBuildTrophyCache";
            btnBuildTrophyCache.Size = new System.Drawing.Size(210, 30);
            btnBuildTrophyCache.TabIndex = 1;
            btnBuildTrophyCache.Text = "Build Trophy Metadata Cache";
            btnBuildTrophyCache.Click += btnBuildTrophyCache_Click;
            // 
            // btnCancelTrophyCache
            // 
            btnCancelTrophyCache.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCancelTrophyCache.Location = new System.Drawing.Point(233, 83);
            btnCancelTrophyCache.Name = "btnCancelTrophyCache";
            btnCancelTrophyCache.Size = new System.Drawing.Size(105, 30);
            btnCancelTrophyCache.TabIndex = 2;
            btnCancelTrophyCache.Text = "Cancel";
            btnCancelTrophyCache.Click += btnCancelTrophyCache_Click;
            // 
            // btnClearTrophyCache
            // 
            btnClearTrophyCache.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnClearTrophyCache.Location = new System.Drawing.Point(348, 83);
            btnClearTrophyCache.Name = "btnClearTrophyCache";
            btnClearTrophyCache.Size = new System.Drawing.Size(120, 30);
            btnClearTrophyCache.TabIndex = 3;
            btnClearTrophyCache.Text = "Clear Cache";
            btnClearTrophyCache.Click += btnClearTrophyCache_Click;
            // 
            // lblTrophyCacheStatus
            // 
            lblTrophyCacheStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTrophyCacheStatus.Location = new System.Drawing.Point(13, 155);
            lblTrophyCacheStatus.Name = "lblTrophyCacheStatus";
            lblTrophyCacheStatus.Size = new System.Drawing.Size(575, 22);
            lblTrophyCacheStatus.TabIndex = 5;
            lblTrophyCacheStatus.Text = "Cache not checked.";
            // 
            // btnOpenShadps4Manager
            // 
            btnOpenShadps4Manager.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnOpenShadps4Manager.Location = new System.Drawing.Point(35, 95);
            btnOpenShadps4Manager.Name = "btnOpenShadps4Manager";
            btnOpenShadps4Manager.Size = new System.Drawing.Size(180, 26);
            btnOpenShadps4Manager.TabIndex = 12;
            btnOpenShadps4Manager.Text = "Open shadPS4 Manager...";
            btnOpenShadps4Manager.Click += btnOpenShadps4Manager_Click;
            // 
            // btnSaveClose
            // 
            btnSaveClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnSaveClose.Location = new System.Drawing.Point(607, 8);
            btnSaveClose.Name = "btnSaveClose";
            btnSaveClose.Size = new System.Drawing.Size(146, 25);
            btnSaveClose.TabIndex = 1;
            btnSaveClose.Text = "Save & Close";
            btnSaveClose.Click += btnSaveClose_Click;
            // 
            // darkSidebarTabControl1
            // 
            darkSidebarTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            darkSidebarTabControl1.Location = new System.Drawing.Point(0, 40);
            darkSidebarTabControl1.Name = "darkSidebarTabControl1";
            darkSidebarTabControl1.Pages.AddRange(new DarkUI.Controls.SidebarPage[] { sidebarPage1, sidebarPage2, sidebarPage3, sidebarPage4, sidebarPage5, sidebarPage6 });
            darkSidebarTabControl1.SidebarWidth = 140;
            darkSidebarTabControl1.Size = new System.Drawing.Size(767, 656);
            darkSidebarTabControl1.TabIndex = 2;
            // 
            // sidebarPage1
            // 
            sidebarPage1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage1.Controls.Add(grpShellIntegration);
            sidebarPage1.Controls.Add(darkSectionPanel2);
            sidebarPage1.Controls.Add(darkSectionPanel1);
            sidebarPage1.Controls.Add(grpPkgExtraction);
            sidebarPage1.Location = new System.Drawing.Point(140, 0);
            sidebarPage1.Name = "sidebarPage1";
            sidebarPage1.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage1.Size = new System.Drawing.Size(627, 656);
            sidebarPage1.TabIndex = 2;
            sidebarPage1.Text = "General";
            // 
            // grpShellIntegration
            // 
            grpShellIntegration.Controls.Add(btnShellRemove);
            grpShellIntegration.Controls.Add(btnShellInstall);
            grpShellIntegration.Controls.Add(lblShellIntegrationStatus);
            grpShellIntegration.Controls.Add(lblShellIntegrationTitle);
            grpShellIntegration.Location = new System.Drawing.Point(12, 320);
            grpShellIntegration.Margin = new System.Windows.Forms.Padding(6);
            grpShellIntegration.Name = "grpShellIntegration";
            grpShellIntegration.Padding = new System.Windows.Forms.Padding(12);
            grpShellIntegration.SectionHeader = "File Explorer Integration";
            grpShellIntegration.Size = new System.Drawing.Size(598, 100);
            grpShellIntegration.TabIndex = 3;
            // 
            // btnShellRemove
            // 
            btnShellRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnShellRemove.Location = new System.Drawing.Point(430, 37);
            btnShellRemove.Name = "btnShellRemove";
            btnShellRemove.Size = new System.Drawing.Size(155, 30);
            btnShellRemove.TabIndex = 3;
            btnShellRemove.Text = "Remove Integration";
            btnShellRemove.Visible = false;
            btnShellRemove.Click += btnShellRemove_Click;
            // 
            // btnShellInstall
            // 
            btnShellInstall.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnShellInstall.Location = new System.Drawing.Point(430, 37);
            btnShellInstall.Name = "btnShellInstall";
            btnShellInstall.Size = new System.Drawing.Size(155, 30);
            btnShellInstall.TabIndex = 2;
            btnShellInstall.Text = "Install Integration";
            btnShellInstall.Click += btnShellInstall_Click;
            // 
            // lblShellIntegrationStatus
            // 
            lblShellIntegrationStatus.Location = new System.Drawing.Point(13, 69);
            lblShellIntegrationStatus.Name = "lblShellIntegrationStatus";
            lblShellIntegrationStatus.Size = new System.Drawing.Size(280, 18);
            lblShellIntegrationStatus.TabIndex = 1;
            lblShellIntegrationStatus.Text = "Status: Not installed";
            // 
            // lblShellIntegrationTitle
            // 
            lblShellIntegrationTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblShellIntegrationTitle.Location = new System.Drawing.Point(13, 43);
            lblShellIntegrationTitle.Name = "lblShellIntegrationTitle";
            // 350 (was 280): the sentence wraps to two lines at 280 and its
            // second line ran into the status label below; one line fits here.
            lblShellIntegrationTitle.Size = new System.Drawing.Size(350, 18);
            lblShellIntegrationTitle.TabIndex = 0;
            lblShellIntegrationTitle.Text = "Adds PS4 PKG Tool actions to the right-click menu for .pkg files.";
            // 
            // darkSectionPanel2
            // 
            darkSectionPanel2.Controls.Add(darkLabel5);
            darkSectionPanel2.Controls.Add(btnOpenAppData);
            darkSectionPanel2.Location = new System.Drawing.Point(12, 93);
            darkSectionPanel2.Margin = new System.Windows.Forms.Padding(6);
            darkSectionPanel2.Name = "darkSectionPanel2";
            darkSectionPanel2.Padding = new System.Windows.Forms.Padding(12);
            darkSectionPanel2.SectionHeader = "Application Data";
            darkSectionPanel2.Size = new System.Drawing.Size(601, 91);
            darkSectionPanel2.TabIndex = 1;
            // 
            // darkLabel5
            // 
            darkLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel5.Location = new System.Drawing.Point(13, 37);
            darkLabel5.Name = "darkLabel5";
            darkLabel5.Size = new System.Drawing.Size(397, 41);
            darkLabel5.TabIndex = 5;
            darkLabel5.Text = "PS4 PKG Tool stores its settings, cache and local application data in the App Data folder. ";
            darkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(BGM);
            darkSectionPanel1.Location = new System.Drawing.Point(12, 12);
            darkSectionPanel1.Margin = new System.Windows.Forms.Padding(6);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.Padding = new System.Windows.Forms.Padding(12);
            darkSectionPanel1.SectionHeader = "Application";
            darkSectionPanel1.Size = new System.Drawing.Size(601, 69);
            darkSectionPanel1.TabIndex = 0;
            // 
            // sidebarPage2
            // 
            sidebarPage2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage2.Controls.Add(grpColumns);
            sidebarPage2.Controls.Add(grpColors);
            sidebarPage2.Controls.Add(darkSectionPanel3);
            sidebarPage2.Location = new System.Drawing.Point(140, 0);
            sidebarPage2.Name = "sidebarPage2";
            sidebarPage2.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage2.Size = new System.Drawing.Size(627, 656);
            sidebarPage2.TabIndex = 3;
            sidebarPage2.Text = "Appearance";
            // 
            // darkSectionPanel3
            // 
            darkSectionPanel3.Controls.Add(darkThemeSelector1);
            darkSectionPanel3.Location = new System.Drawing.Point(12, 12);
            darkSectionPanel3.Margin = new System.Windows.Forms.Padding(6);
            darkSectionPanel3.Name = "darkSectionPanel3";
            darkSectionPanel3.Padding = new System.Windows.Forms.Padding(12);
            darkSectionPanel3.SectionHeader = "Theme";
            darkSectionPanel3.Size = new System.Drawing.Size(601, 78);
            darkSectionPanel3.TabIndex = 0;
            // 
            // darkThemeSelector1
            // 
            darkThemeSelector1.Location = new System.Drawing.Point(13, 37);
            darkThemeSelector1.Name = "darkThemeSelector1";
            darkThemeSelector1.Size = new System.Drawing.Size(430, 28);
            darkThemeSelector1.TabIndex = 16;
            // 
            // sidebarPage3
            // 
            sidebarPage3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage3.Controls.Add(grpDirList);
            sidebarPage3.Controls.Add(grpRename);
            sidebarPage3.Controls.Add(grpStartup);
            sidebarPage3.Location = new System.Drawing.Point(140, 0);
            sidebarPage3.Name = "sidebarPage3";
            sidebarPage3.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage3.Size = new System.Drawing.Size(627, 656);
            sidebarPage3.TabIndex = 4;
            sidebarPage3.Text = "Library";
            // 
            // sidebarPage4
            // 
            sidebarPage4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage4.Controls.Add(grpPS5BC);
            sidebarPage4.Controls.Add(grpShadps4Config);
            sidebarPage4.Location = new System.Drawing.Point(140, 0);
            sidebarPage4.Name = "sidebarPage4";
            sidebarPage4.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage4.Size = new System.Drawing.Size(627, 656);
            sidebarPage4.TabIndex = 5;
            sidebarPage4.Text = "Compatibility";
            // 
            // sidebarPage5
            // 
            sidebarPage5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage5.Controls.Add(grpNetwork);
            sidebarPage5.Controls.Add(grpTools);
            sidebarPage5.Location = new System.Drawing.Point(140, 0);
            sidebarPage5.Name = "sidebarPage5";
            sidebarPage5.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage5.Size = new System.Drawing.Size(627, 656);
            sidebarPage5.TabIndex = 6;
            sidebarPage5.Text = "Remote PKG Installer";
            // 
            // sidebarPage6
            // 
            sidebarPage6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidebarPage6.Controls.Add(grpTrophyCache);
            sidebarPage6.Location = new System.Drawing.Point(140, 0);
            sidebarPage6.Name = "sidebarPage6";
            sidebarPage6.Padding = new System.Windows.Forms.Padding(12);
            sidebarPage6.Size = new System.Drawing.Size(627, 656);
            sidebarPage6.TabIndex = 7;
            sidebarPage6.Text = "Trophies";
            // 
            // darkLabel14
            // 
            darkLabel14.Location = new System.Drawing.Point(140, 16);
            darkLabel14.Name = "darkLabel14";
            darkLabel14.Size = new System.Drawing.Size(60, 15);
            darkLabel14.TabIndex = 15;
            darkLabel14.Text = "Theme: ";
            darkLabel14.Visible = false;
            // 
            // darkHeaderBar1
            // 
            darkHeaderBar1.Dock = System.Windows.Forms.DockStyle.Top;
            darkHeaderBar1.Location = new System.Drawing.Point(0, 0);
            darkHeaderBar1.Name = "darkHeaderBar1";
            darkHeaderBar1.ShowThemeSelector = false;
            darkHeaderBar1.Size = new System.Drawing.Size(767, 40);
            darkHeaderBar1.TabIndex = 3;
            darkHeaderBar1.Text = "darkHeaderBar1";
            // 
            // darkFooterBar1
            // 
            darkFooterBar1.Controls.Add(btnSaveClose);
            darkFooterBar1.Controls.Add(darkLabel14);
            darkFooterBar1.Controls.Add(cmbTheme);
            darkFooterBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            darkFooterBar1.Location = new System.Drawing.Point(0, 696);
            darkFooterBar1.Name = "darkFooterBar1";
            darkFooterBar1.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            darkFooterBar1.Size = new System.Drawing.Size(767, 40);
            darkFooterBar1.TabIndex = 4;
            // 
            // ProgramSetting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(767, 736);
            Controls.Add(darkSidebarTabControl1);
            Controls.Add(darkFooterBar1);
            Controls.Add(darkHeaderBar1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = Properties.Resources.PackageIcon;
            MaximizeBox = false;
            Name = "ProgramSetting";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Program Settings";
            Load += ProgramSetting_Load;
            grpStartup.ResumeLayout(false);
            grpStartup.PerformLayout();
            grpDirList.ResumeLayout(false);
            grpDirList.PerformLayout();
            grpPkgExtraction.ResumeLayout(false);
            grpPkgExtraction.PerformLayout();
            grpColors.ResumeLayout(false);
            grpColors.PerformLayout();
            grpColumns.ResumeLayout(false);
            grpColumns.PerformLayout();
            grpPS5BC.ResumeLayout(false);
            grpPS5BC.PerformLayout();
            grpShadps4Config.ResumeLayout(false);
            grpShadps4Config.PerformLayout();
            grpNetwork.ResumeLayout(false);
            grpNetwork.PerformLayout();
            grpTools.ResumeLayout(false);
            grpRename.ResumeLayout(false);
            grpRename.PerformLayout();
            grpTrophyCache.ResumeLayout(false);
            darkSidebarTabControl1.ResumeLayout(false);
            sidebarPage1.ResumeLayout(false);
            grpShellIntegration.ResumeLayout(false);
            darkSectionPanel2.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            darkSectionPanel1.PerformLayout();
            sidebarPage2.ResumeLayout(false);
            darkSectionPanel3.ResumeLayout(false);
            sidebarPage3.ResumeLayout(false);
            sidebarPage4.ResumeLayout(false);
            sidebarPage5.ResumeLayout(false);
            sidebarPage6.ResumeLayout(false);
            darkFooterBar1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private DarkUI.Controls.DarkListBox lbPkgDirectoryList;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRecursive;
        private DarkUI.Controls.DarkButton btnAddPkgDirectory, btnDeletePkgDirectory, btnClearAllPkgDirectory;
        private DarkUI.Controls.DarkCheckBox BGM, AutoSortRow, cbAutoFetchUpdate;
        private DarkUI.Controls.DarkComboBox cmbTheme;
        private DarkUI.Controls.DarkButton btnOpenAppData;
        private DarkUI.Controls.DarkSectionPanel grpPkgExtraction;
        private DarkUI.Controls.DarkSectionPanel grpShellIntegration;
        private DarkUI.Controls.DarkLabel lblShellIntegrationTitle;
        private DarkUI.Controls.DarkLabel lblShellIntegrationStatus;
        private DarkUI.Controls.DarkButton btnShellInstall;
        private DarkUI.Controls.DarkButton btnShellRemove;
        private DarkUI.Controls.DarkSectionPanel grpDirList;
        private DarkUI.Controls.DarkSectionPanel grpColumns, grpColors, grpPS5BC, grpShadps4Config;
        private DarkUI.Controls.DarkCheckBox PKGname, TitleId, ContentId, Region, SystemFirmware, Version, PkgType, Category, Size, Location, cbBackported;
        private DarkUI.Controls.DarkCheckBox PKGColorLabeling;
        private DarkUI.Controls.DarkLabel darkLabelGamePkgColorLabel, darkLabelPatchPkgColorLabel, darkLabelAddonPkgColorLabel, darkLabelAppPkgColorLabel;
        private DarkUI.Controls.DarkButton btnGamePkgForeColor, btnGamePkgBackColor, btnPatchPkgForeColor, btnPatchPkgBackColor, btnAddonPkgForeColor, btnAddonPkgBackColor, btnAppPkgForeColor, btnAppPkgBackColor, btnResetPkgLabelColor;
        private DarkUI.Controls.DarkCheckBox cbPs5BcCheck;
        private DarkUI.Controls.DarkButton btnDownloadPS5BCJson;
        private DarkUI.Controls.DarkLabel darkLabel9, labelPs5BcJsonDownloadDate;
        private DarkUI.Controls.DarkCheckBox cbShadps4Check;
        private DarkUI.Controls.DarkLabel darkLabelShadps4Os;
        private DarkUI.Controls.DarkComboBox cmbShadps4Os;
        private DarkUI.Controls.DarkButton btnOpenShadps4Manager;
        private DarkUI.Controls.DarkButton btnDownloadShadps4Json;
        private DarkUI.Controls.DarkLabel darkLabelShadps4, labelShadps4JsonDate;
        private DarkUI.Controls.DarkSectionPanel grpNetwork, grpTools;
        private DarkUI.Controls.DarkLabel darkLabel1, darkLabel2, darkLabel3, darkLabelNodejsInstalled, darkLabel4, darkLabelserveModuleInstalled;
        private DarkUI.Controls.DarkComboBox darkComboBoxServerIP;
        private DarkUI.Controls.DarkTextBox tbPS4IP;
        private DarkUI.Controls.DarkButton btnPingPs4, btnInstallNodejs, btnInstalleServerModule;
        private DarkUI.Controls.DarkSectionPanel grpRename;
        private DarkUI.Controls.DarkLabel lblOrbisTempDirectory;
        private DarkUI.Controls.DarkTextBox tbOrbisTempDirectory;
        private DarkUI.Controls.DarkButton btnBrowseOrbisTempDirectory, btnUseDefaultOrbisTempDirectory;
        private DarkUI.Controls.DarkLabel darkLabel12, darkLabelPlaceholderHint, darkLabelNamingPatternExample;
        private DarkUI.Controls.DarkButton btnPlaceTitle, btnPlaceTitleId, btnPlaceVersion, btnPlaceAppVer, btnPlaceCategory, btnPlaceContentId, btnPlaceRegion, btnPlaceSysVer;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkTextBox tbCustomNamePattern;
        private DarkUI.Controls.DarkSectionPanel grpTrophyCache;
        private DarkUI.Controls.DarkLabel lblTrophyCacheDesc, lblTrophyCacheStatus;
        private DarkUI.Controls.DarkButton btnBuildTrophyCache, btnCancelTrophyCache, btnClearTrophyCache;
        private DarkUI.Controls.DarkButton btnSaveClose;
        private DarkUI.Controls.DarkSidebarTabControl darkSidebarTabControl1;
        private DarkUI.Controls.SidebarPage sidebarPage1;
        private DarkUI.Controls.SidebarPage sidebarPage2;
        private DarkUI.Controls.SidebarPage sidebarPage3;
        private DarkUI.Controls.SidebarPage sidebarPage4;
        private DarkUI.Controls.SidebarPage sidebarPage5;
        private DarkUI.Controls.SidebarPage sidebarPage6;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkHeaderBar darkHeaderBar1;
        private DarkUI.Controls.DarkLabel darkLabel13;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkLabel darkLabel14;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel3;
        private DarkUI.Controls.DarkFooterBar darkFooterBar1;
        private DarkUI.Controls.DarkThemeSelector darkThemeSelector1;
        private DarkUI.Controls.DarkProgressBar pbTrophyCacheProgress;
    }
}

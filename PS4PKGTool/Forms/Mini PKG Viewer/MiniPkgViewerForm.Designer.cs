namespace PS4PKGTool
{
    partial class MiniPkgViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ReleaseViewerResources();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniPkgViewerForm));
            headerPanel = new DarkUI.Controls.DarkHeaderBar();
            lblContentId = new DarkUI.Controls.DarkLabel();
            lblSubtitle = new DarkUI.Controls.DarkLabel();
            lblTitle = new DarkUI.Controls.DarkLabel();
            picIcon = new System.Windows.Forms.PictureBox();
            toolStripProgressBar1 = new DarkUI.Controls.DarkToolStripProgressBar();
            tabsViewer = new DarkUI.Controls.DarkTabControl();
            tabOverview = new DarkUI.Controls.DarkTabPage();
            darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            dgvSfo = new DarkUI.Controls.DarkDataGridView();
            colSfoKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSfoValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            overviewPanel = new DarkUI.Controls.DarkSectionPanel();
            overviewTable = new System.Windows.Forms.TableLayoutPanel();
            lblOverviewTitleCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewTitle = new DarkUI.Controls.DarkLabel();
            lblOverviewTitleIdCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewTitleId = new DarkUI.Controls.DarkLabel();
            lblOverviewContentIdCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewContentId = new DarkUI.Controls.DarkLabel();
            lblOverviewCategoryCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewCategory = new DarkUI.Controls.DarkLabel();
            lblOverviewStateCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewState = new DarkUI.Controls.DarkLabel();
            lblOverviewAppVersionCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewAppVersion = new DarkUI.Controls.DarkLabel();
            lblOverviewPkgVersionCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewPkgVersion = new DarkUI.Controls.DarkLabel();
            lblOverviewFirmwareCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewFirmware = new DarkUI.Controls.DarkLabel();
            lblOverviewSizeCaption = new DarkUI.Controls.DarkLabel();
            lblOverviewSize = new DarkUI.Controls.DarkLabel();
            tabPackage = new DarkUI.Controls.DarkTabPage();
            packageTabs = new DarkUI.Controls.DarkTabControl();
            tabPackageHeader = new DarkUI.Controls.DarkTabPage();
            dgvPackageHeader = new DarkUI.Controls.DarkDataGridView();
            colHeaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHeaderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPackageBuildInfo = new DarkUI.Controls.DarkTabPage();
            dgvBuildInfo = new DarkUI.Controls.DarkDataGridView();
            colBuildName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colBuildValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPackageEntries = new DarkUI.Controls.DarkTabPage();
            dgvEntries = new DarkUI.Controls.DarkDataGridView();
            colEntryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEntryOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEntrySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEntryFlags1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEntryFlags2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEntryEncrypted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabTrophy = new DarkUI.Controls.DarkTabPage();
            dgvTrophies = new DarkUI.Controls.DarkDataGridView();
            colTrophyIcon = new System.Windows.Forms.DataGridViewImageColumn();
            colTrophyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrophyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrophyDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrophyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrophyHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblTrophyState = new DarkUI.Controls.DarkLabel();
            tabFiles = new DarkUI.Controls.DarkTabPage();
            fileBrowserLayout = new System.Windows.Forms.TableLayoutPanel();
            tvFiles = new DarkUI.Controls.DarkTreeView();
            imageListFiles = new System.Windows.Forms.ImageList(components);
            lvFiles = new DarkUI.Controls.DarkListView();
            _filePreviewPanel = new DarkUI.Controls.DarkSectionPanel();
            _filePreviewInfo = new DarkUI.Controls.DarkLabel();
            _filePreviewBody = new System.Windows.Forms.Panel();
            _filePreviewImage = new System.Windows.Forms.PictureBox();
            _filePreviewText = new DarkUI.Controls.DarkTextBox();
            _filePreviewAssetList = new DarkUI.Controls.DarkListView();
            colAssetName = new System.Windows.Forms.ColumnHeader();
            colAssetType = new System.Windows.Forms.ColumnHeader();
            colAssetSize = new System.Windows.Forms.ColumnHeader();
            _filePreviewBackButton = new DarkUI.Controls.DarkButton();
            tbFilterFiles = new DarkUI.Controls.DarkSearchBox();
            tabArtwork = new DarkUI.Controls.DarkTabPage();
            artworkTable = new System.Windows.Forms.TableLayoutPanel();
            pic0Panel = new DarkUI.Controls.DarkSectionPanel();
            lblNoPic0 = new DarkUI.Controls.DarkLabel();
            picPic0 = new System.Windows.Forms.PictureBox();
            pic1Panel = new DarkUI.Controls.DarkSectionPanel();
            lblNoPic1 = new DarkUI.Controls.DarkLabel();
            picPic1 = new System.Windows.Forms.PictureBox();
            ctxPkgOperations = new DarkUI.Controls.DarkContextMenu();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            copyMenu = new System.Windows.Forms.ToolStripMenuItem();
            copyTitleIdItem = new System.Windows.Forms.ToolStripMenuItem();
            copyContentIdItem = new System.Windows.Forms.ToolStripMenuItem();
            copyTitleItem = new System.Windows.Forms.ToolStripMenuItem();
            copyFilenameItem = new System.Windows.Forms.ToolStripMenuItem();
            sepRename = new DarkUI.Controls.DarkToolStripSeparator();
            renameMenu = new System.Windows.Forms.ToolStripMenuItem();
            renameItem1 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem2 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem3 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem4 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem5 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem6 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem7 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem8 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem9 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem10 = new System.Windows.Forms.ToolStripMenuItem();
            renameItem11 = new System.Windows.Forms.ToolStripMenuItem();
            sepDelete = new DarkUI.Controls.DarkToolStripSeparator();
            deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            artworkMenu = new System.Windows.Forms.ToolStripMenuItem();
            artworkAllItem = new System.Windows.Forms.ToolStripMenuItem();
            artworkImagesItem = new System.Windows.Forms.ToolStripMenuItem();
            artworkIconItem = new System.Windows.Forms.ToolStripMenuItem();
            extractFullPkgItem = new System.Windows.Forms.ToolStripMenuItem();
            sepChangeInfo = new DarkUI.Controls.DarkToolStripSeparator();
            changeInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            colFileName = new System.Windows.Forms.ColumnHeader();
            colFileType = new System.Windows.Forms.ColumnHeader();
            colFilePath = new System.Windows.Forms.ColumnHeader();
            colFileSize = new System.Windows.Forms.ColumnHeader();
            toolStripSeparator13 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripSeparator14 = new DarkUI.Controls.DarkToolStripSeparator();
            tbCopyMenu = new System.Windows.Forms.ToolStripMenuItem();
            tbCopyTitleIdItem = new System.Windows.Forms.ToolStripMenuItem();
            tbCopyContentIdItem = new System.Windows.Forms.ToolStripMenuItem();
            tbCopyTitleItem = new System.Windows.Forms.ToolStripMenuItem();
            tbSepRename = new DarkUI.Controls.DarkToolStripSeparator();
            tbRenameMenu = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem1 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem2 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem3 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem4 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem5 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem6 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem7 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem8 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem9 = new System.Windows.Forms.ToolStripMenuItem();
            tbRenameItem10 = new System.Windows.Forms.ToolStripMenuItem();
            tbArtworkMenu = new System.Windows.Forms.ToolStripMenuItem();
            tbSepChangeInfo = new DarkUI.Controls.DarkToolStripSeparator();
            tbChangeInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            tbDownloadUpdateItem = new System.Windows.Forms.ToolStripMenuItem();
            tbExtractFullPkgItem = new System.Windows.Forms.ToolStripMenuItem();
            tbSepExit = new DarkUI.Controls.DarkToolStripSeparator();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpAboutItem = new System.Windows.Forms.ToolStripMenuItem();
            helpCoffeeItem = new System.Windows.Forms.ToolStripMenuItem();
            helpUpdateItem = new System.Windows.Forms.ToolStripMenuItem();
            ctxFileList = new DarkUI.Controls.DarkContextMenu();
            ctxExtractItem = new System.Windows.Forms.ToolStripMenuItem();
            ctxExtractFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            sepListExtract = new DarkUI.Controls.DarkToolStripSeparator();
            ctxCopyPathItem = new System.Windows.Forms.ToolStripMenuItem();
            ctxCopyNameItem = new System.Windows.Forms.ToolStripMenuItem();
            darkStatusStrip1 = new DarkUI.Controls.DarkStatusStrip();
            toolStripStatusLabel1 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel3 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel5 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel2 = new DarkUI.Controls.DarkToolStripStatusLabel();
            labelDisplayTotalPKG = new DarkUI.Controls.DarkToolStripStatusLabel();
            btnStopExtract = new DarkUI.Controls.DarkToolStripButton();
            toolStripStatusLabel4 = new DarkUI.Controls.DarkToolStripStatusLabel();
            darkMenuStrip1 = new DarkUI.Controls.DarkMenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            tabsViewer.SuspendLayout();
            tabOverview.SuspendLayout();
            darkSectionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSfo).BeginInit();
            overviewPanel.SuspendLayout();
            overviewTable.SuspendLayout();
            tabPackage.SuspendLayout();
            packageTabs.SuspendLayout();
            tabPackageHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPackageHeader).BeginInit();
            tabPackageBuildInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuildInfo).BeginInit();
            tabPackageEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).BeginInit();
            tabTrophy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrophies).BeginInit();
            tabFiles.SuspendLayout();
            fileBrowserLayout.SuspendLayout();
            _filePreviewPanel.SuspendLayout();
            _filePreviewBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_filePreviewImage).BeginInit();
            tabArtwork.SuspendLayout();
            artworkTable.SuspendLayout();
            pic0Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPic0).BeginInit();
            pic1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPic1).BeginInit();
            ctxPkgOperations.SuspendLayout();
            ctxFileList.SuspendLayout();
            darkStatusStrip1.SuspendLayout();
            darkMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(lblContentId);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(picIcon);
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(0, 24);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            headerPanel.ShowThemeSelector = false;
            headerPanel.Size = new System.Drawing.Size(1004, 104);
            headerPanel.TabIndex = 0;
            // 
            // lblContentId
            // 
            lblContentId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblContentId.AutoEllipsis = true;
            lblContentId.Location = new System.Drawing.Point(118, 66);
            lblContentId.Name = "lblContentId";
            lblContentId.Size = new System.Drawing.Size(680, 17);
            lblContentId.TabIndex = 3;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblSubtitle.AutoEllipsis = true;
            lblSubtitle.Location = new System.Drawing.Point(118, 45);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(680, 17);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Reading package metadata...";
            // 
            // lblTitle
            // 
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(118, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(636, 27);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "PKG Viewer";
            // 
            // picIcon
            // 
            picIcon.Location = new System.Drawing.Point(16, 10);
            picIcon.Name = "picIcon";
            picIcon.Size = new System.Drawing.Size(84, 84);
            picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripProgressBar1.Marquee = false;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new System.Drawing.Size(150, 19);
            // 
            // tabsViewer
            // 
            tabsViewer.AllowDrop = true;
            tabsViewer.Controls.Add(tabOverview);
            tabsViewer.Controls.Add(tabPackage);
            tabsViewer.Controls.Add(tabTrophy);
            tabsViewer.Controls.Add(tabFiles);
            tabsViewer.Controls.Add(tabArtwork);
            tabsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            tabsViewer.ItemSize = new System.Drawing.Size(108, 28);
            tabsViewer.Location = new System.Drawing.Point(0, 128);
            tabsViewer.Name = "tabsViewer";
            tabsViewer.Padding = new System.Drawing.Point(0, 0);
            tabsViewer.SelectedIndex = 0;
            tabsViewer.Size = new System.Drawing.Size(1004, 444);
            tabsViewer.TabIndex = 1;
            tabsViewer.SelectedIndexChanged += tabsViewer_SelectedIndexChanged;
            // 
            // tabOverview
            // 
            tabOverview.Controls.Add(darkSectionPanel1);
            tabOverview.Controls.Add(overviewPanel);
            tabOverview.Location = new System.Drawing.Point(4, 32);
            tabOverview.Name = "tabOverview";
            tabOverview.Padding = new System.Windows.Forms.Padding(12);
            tabOverview.Size = new System.Drawing.Size(996, 408);
            tabOverview.TabIndex = 0;
            tabOverview.Text = "Overview";
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(dgvSfo);
            darkSectionPanel1.Location = new System.Drawing.Point(505, 12);
            darkSectionPanel1.Margin = new System.Windows.Forms.Padding(6);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.SectionHeader = "PARAM.SFO";
            darkSectionPanel1.Size = new System.Drawing.Size(481, 386);
            darkSectionPanel1.TabIndex = 1;
            // 
            // dgvSfo
            // 
            dgvSfo.AllowUserToAddRows = false;
            dgvSfo.AllowUserToDeleteRows = false;
            dgvSfo.AllowUserToOrderColumns = true;
            dgvSfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSfoKey, colSfoValue });
            dgvSfo.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvSfo.Location = new System.Drawing.Point(1, 25);
            dgvSfo.MultiSelect = false;
            dgvSfo.Name = "dgvSfo";
            dgvSfo.ReadOnly = true;
            dgvSfo.Size = new System.Drawing.Size(479, 360);
            dgvSfo.TabIndex = 0;
            // 
            // colSfoKey
            // 
            colSfoKey.FillWeight = 35F;
            colSfoKey.HeaderText = "Key";
            colSfoKey.Name = "colSfoKey";
            colSfoKey.ReadOnly = true;
            colSfoKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colSfoValue
            // 
            colSfoValue.FillWeight = 65F;
            colSfoValue.HeaderText = "Value";
            colSfoValue.Name = "colSfoValue";
            colSfoValue.ReadOnly = true;
            colSfoValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // overviewPanel
            // 
            overviewPanel.Controls.Add(overviewTable);
            overviewPanel.Location = new System.Drawing.Point(12, 12);
            overviewPanel.Margin = new System.Windows.Forms.Padding(6);
            overviewPanel.Name = "overviewPanel";
            overviewPanel.Padding = new System.Windows.Forms.Padding(16, 12, 16, 16);
            overviewPanel.SectionHeader = "Package Summary";
            overviewPanel.Size = new System.Drawing.Size(481, 386);
            overviewPanel.TabIndex = 0;
            // 
            // overviewTable
            // 
            overviewTable.ColumnCount = 2;
            overviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            overviewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            overviewTable.Controls.Add(lblOverviewTitleCaption, 0, 0);
            overviewTable.Controls.Add(lblOverviewTitle, 1, 0);
            overviewTable.Controls.Add(lblOverviewTitleIdCaption, 0, 1);
            overviewTable.Controls.Add(lblOverviewTitleId, 1, 1);
            overviewTable.Controls.Add(lblOverviewContentIdCaption, 0, 2);
            overviewTable.Controls.Add(lblOverviewContentId, 1, 2);
            overviewTable.Controls.Add(lblOverviewCategoryCaption, 0, 3);
            overviewTable.Controls.Add(lblOverviewCategory, 1, 3);
            overviewTable.Controls.Add(lblOverviewStateCaption, 0, 4);
            overviewTable.Controls.Add(lblOverviewState, 1, 4);
            overviewTable.Controls.Add(lblOverviewAppVersionCaption, 0, 5);
            overviewTable.Controls.Add(lblOverviewAppVersion, 1, 5);
            overviewTable.Controls.Add(lblOverviewPkgVersionCaption, 0, 6);
            overviewTable.Controls.Add(lblOverviewPkgVersion, 1, 6);
            overviewTable.Controls.Add(lblOverviewFirmwareCaption, 0, 7);
            overviewTable.Controls.Add(lblOverviewFirmware, 1, 7);
            overviewTable.Controls.Add(lblOverviewSizeCaption, 0, 8);
            overviewTable.Controls.Add(lblOverviewSize, 1, 8);
            overviewTable.Location = new System.Drawing.Point(17, 37);
            overviewTable.Name = "overviewTable";
            overviewTable.RowCount = 9;
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            overviewTable.Size = new System.Drawing.Size(447, 332);
            overviewTable.TabIndex = 0;
            // 
            // lblOverviewTitleCaption
            // 
            lblOverviewTitleCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewTitleCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewTitleCaption.Location = new System.Drawing.Point(3, 3);
            lblOverviewTitleCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewTitleCaption.Name = "lblOverviewTitleCaption";
            lblOverviewTitleCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewTitleCaption.TabIndex = 0;
            lblOverviewTitleCaption.Text = "Title";
            // 
            // lblOverviewTitle
            // 
            lblOverviewTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblOverviewTitle.Location = new System.Drawing.Point(133, 3);
            lblOverviewTitle.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewTitle.Name = "lblOverviewTitle";
            lblOverviewTitle.Size = new System.Drawing.Size(311, 30);
            lblOverviewTitle.TabIndex = 1;
            lblOverviewTitle.Text = "Not available";
            // 
            // lblOverviewTitleIdCaption
            // 
            lblOverviewTitleIdCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewTitleIdCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewTitleIdCaption.Location = new System.Drawing.Point(3, 39);
            lblOverviewTitleIdCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewTitleIdCaption.Name = "lblOverviewTitleIdCaption";
            lblOverviewTitleIdCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewTitleIdCaption.TabIndex = 2;
            lblOverviewTitleIdCaption.Text = "Title ID";
            // 
            // lblOverviewTitleId
            // 
            lblOverviewTitleId.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewTitleId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblOverviewTitleId.Location = new System.Drawing.Point(133, 39);
            lblOverviewTitleId.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewTitleId.Name = "lblOverviewTitleId";
            lblOverviewTitleId.Size = new System.Drawing.Size(311, 30);
            lblOverviewTitleId.TabIndex = 3;
            lblOverviewTitleId.Text = "Not available";
            // 
            // lblOverviewContentIdCaption
            // 
            lblOverviewContentIdCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewContentIdCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewContentIdCaption.Location = new System.Drawing.Point(3, 75);
            lblOverviewContentIdCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewContentIdCaption.Name = "lblOverviewContentIdCaption";
            lblOverviewContentIdCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewContentIdCaption.TabIndex = 4;
            lblOverviewContentIdCaption.Text = "Content ID";
            // 
            // lblOverviewContentId
            // 
            lblOverviewContentId.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewContentId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblOverviewContentId.Location = new System.Drawing.Point(133, 75);
            lblOverviewContentId.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewContentId.Name = "lblOverviewContentId";
            lblOverviewContentId.Size = new System.Drawing.Size(311, 30);
            lblOverviewContentId.TabIndex = 5;
            lblOverviewContentId.Text = "Not available";
            // 
            // lblOverviewCategoryCaption
            // 
            lblOverviewCategoryCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewCategoryCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewCategoryCaption.Location = new System.Drawing.Point(3, 111);
            lblOverviewCategoryCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewCategoryCaption.Name = "lblOverviewCategoryCaption";
            lblOverviewCategoryCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewCategoryCaption.TabIndex = 6;
            lblOverviewCategoryCaption.Text = "Category";
            // 
            // lblOverviewCategory
            // 
            lblOverviewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewCategory.Location = new System.Drawing.Point(133, 111);
            lblOverviewCategory.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewCategory.Name = "lblOverviewCategory";
            lblOverviewCategory.Size = new System.Drawing.Size(311, 30);
            lblOverviewCategory.TabIndex = 7;
            lblOverviewCategory.Text = "Not available";
            // 
            // lblOverviewStateCaption
            // 
            lblOverviewStateCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewStateCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewStateCaption.Location = new System.Drawing.Point(3, 147);
            lblOverviewStateCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewStateCaption.Name = "lblOverviewStateCaption";
            lblOverviewStateCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewStateCaption.TabIndex = 8;
            lblOverviewStateCaption.Text = "Package state";
            // 
            // lblOverviewState
            // 
            lblOverviewState.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewState.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewState.Location = new System.Drawing.Point(133, 147);
            lblOverviewState.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewState.Name = "lblOverviewState";
            lblOverviewState.Size = new System.Drawing.Size(311, 30);
            lblOverviewState.TabIndex = 9;
            lblOverviewState.Text = "Not available";
            // 
            // lblOverviewAppVersionCaption
            // 
            lblOverviewAppVersionCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewAppVersionCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewAppVersionCaption.Location = new System.Drawing.Point(3, 183);
            lblOverviewAppVersionCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewAppVersionCaption.Name = "lblOverviewAppVersionCaption";
            lblOverviewAppVersionCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewAppVersionCaption.TabIndex = 10;
            lblOverviewAppVersionCaption.Text = "Application version";
            // 
            // lblOverviewAppVersion
            // 
            lblOverviewAppVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewAppVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewAppVersion.Location = new System.Drawing.Point(133, 183);
            lblOverviewAppVersion.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewAppVersion.Name = "lblOverviewAppVersion";
            lblOverviewAppVersion.Size = new System.Drawing.Size(311, 30);
            lblOverviewAppVersion.TabIndex = 11;
            lblOverviewAppVersion.Text = "Not available";
            // 
            // lblOverviewPkgVersionCaption
            // 
            lblOverviewPkgVersionCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewPkgVersionCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewPkgVersionCaption.Location = new System.Drawing.Point(3, 219);
            lblOverviewPkgVersionCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewPkgVersionCaption.Name = "lblOverviewPkgVersionCaption";
            lblOverviewPkgVersionCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewPkgVersionCaption.TabIndex = 12;
            lblOverviewPkgVersionCaption.Text = "Package version";
            // 
            // lblOverviewPkgVersion
            // 
            lblOverviewPkgVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewPkgVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewPkgVersion.Location = new System.Drawing.Point(133, 219);
            lblOverviewPkgVersion.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewPkgVersion.Name = "lblOverviewPkgVersion";
            lblOverviewPkgVersion.Size = new System.Drawing.Size(311, 30);
            lblOverviewPkgVersion.TabIndex = 13;
            lblOverviewPkgVersion.Text = "Not available";
            // 
            // lblOverviewFirmwareCaption
            // 
            lblOverviewFirmwareCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewFirmwareCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewFirmwareCaption.Location = new System.Drawing.Point(3, 255);
            lblOverviewFirmwareCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewFirmwareCaption.Name = "lblOverviewFirmwareCaption";
            lblOverviewFirmwareCaption.Size = new System.Drawing.Size(124, 30);
            lblOverviewFirmwareCaption.TabIndex = 14;
            lblOverviewFirmwareCaption.Text = "Required firmware";
            // 
            // lblOverviewFirmware
            // 
            lblOverviewFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewFirmware.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewFirmware.Location = new System.Drawing.Point(133, 255);
            lblOverviewFirmware.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewFirmware.Name = "lblOverviewFirmware";
            lblOverviewFirmware.Size = new System.Drawing.Size(311, 30);
            lblOverviewFirmware.TabIndex = 15;
            lblOverviewFirmware.Text = "Not available";
            // 
            // lblOverviewSizeCaption
            // 
            lblOverviewSizeCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewSizeCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewSizeCaption.Location = new System.Drawing.Point(3, 291);
            lblOverviewSizeCaption.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewSizeCaption.Name = "lblOverviewSizeCaption";
            lblOverviewSizeCaption.Size = new System.Drawing.Size(124, 38);
            lblOverviewSizeCaption.TabIndex = 16;
            lblOverviewSizeCaption.Text = "Package size";
            // 
            // lblOverviewSize
            // 
            lblOverviewSize.Dock = System.Windows.Forms.DockStyle.Fill;
            lblOverviewSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOverviewSize.Location = new System.Drawing.Point(133, 291);
            lblOverviewSize.Margin = new System.Windows.Forms.Padding(3);
            lblOverviewSize.Name = "lblOverviewSize";
            lblOverviewSize.Size = new System.Drawing.Size(311, 38);
            lblOverviewSize.TabIndex = 17;
            lblOverviewSize.Text = "Not available";
            // 
            // tabPackage
            // 
            tabPackage.Controls.Add(packageTabs);
            tabPackage.Location = new System.Drawing.Point(4, 32);
            tabPackage.Name = "tabPackage";
            tabPackage.Padding = new System.Windows.Forms.Padding(12);
            tabPackage.Size = new System.Drawing.Size(996, 408);
            tabPackage.TabIndex = 2;
            tabPackage.Text = "PKG Internals";
            // 
            // packageTabs
            // 
            packageTabs.AllowDrop = true;
            packageTabs.Controls.Add(tabPackageHeader);
            packageTabs.Controls.Add(tabPackageBuildInfo);
            packageTabs.Controls.Add(tabPackageEntries);
            packageTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            packageTabs.ItemSize = new System.Drawing.Size(88, 28);
            packageTabs.Location = new System.Drawing.Point(12, 12);
            packageTabs.Name = "packageTabs";
            packageTabs.Padding = new System.Drawing.Point(0, 0);
            packageTabs.SelectedIndex = 0;
            packageTabs.Size = new System.Drawing.Size(972, 384);
            packageTabs.TabIndex = 0;
            packageTabs.SelectedIndexChanged += packageTabs_SelectedIndexChanged;
            // 
            // tabPackageHeader
            // 
            tabPackageHeader.Controls.Add(dgvPackageHeader);
            tabPackageHeader.Location = new System.Drawing.Point(4, 32);
            tabPackageHeader.Name = "tabPackageHeader";
            tabPackageHeader.Size = new System.Drawing.Size(964, 348);
            tabPackageHeader.TabIndex = 0;
            tabPackageHeader.Text = "Header";
            // 
            // dgvPackageHeader
            // 
            dgvPackageHeader.AllowUserToAddRows = false;
            dgvPackageHeader.AllowUserToDeleteRows = false;
            dgvPackageHeader.AllowUserToOrderColumns = true;
            dgvPackageHeader.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPackageHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colHeaderName, colHeaderValue });
            dgvPackageHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPackageHeader.Location = new System.Drawing.Point(0, 0);
            dgvPackageHeader.MultiSelect = false;
            dgvPackageHeader.Name = "dgvPackageHeader";
            dgvPackageHeader.ReadOnly = true;
            dgvPackageHeader.Size = new System.Drawing.Size(964, 348);
            dgvPackageHeader.TabIndex = 0;
            // 
            // colHeaderName
            // 
            colHeaderName.FillWeight = 38F;
            colHeaderName.HeaderText = "Field";
            colHeaderName.Name = "colHeaderName";
            colHeaderName.ReadOnly = true;
            colHeaderName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colHeaderValue
            // 
            colHeaderValue.FillWeight = 62F;
            colHeaderValue.HeaderText = "Value";
            colHeaderValue.Name = "colHeaderValue";
            colHeaderValue.ReadOnly = true;
            colHeaderValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabPackageBuildInfo
            // 
            tabPackageBuildInfo.Controls.Add(dgvBuildInfo);
            tabPackageBuildInfo.Location = new System.Drawing.Point(4, 32);
            tabPackageBuildInfo.Name = "tabPackageBuildInfo";
            tabPackageBuildInfo.Size = new System.Drawing.Size(964, 348);
            tabPackageBuildInfo.TabIndex = 1;
            tabPackageBuildInfo.Text = "Build Info";
            // 
            // dgvBuildInfo
            // 
            dgvBuildInfo.AllowUserToAddRows = false;
            dgvBuildInfo.AllowUserToDeleteRows = false;
            dgvBuildInfo.AllowUserToOrderColumns = true;
            dgvBuildInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuildInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colBuildName, colBuildValue });
            dgvBuildInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBuildInfo.Location = new System.Drawing.Point(0, 0);
            dgvBuildInfo.MultiSelect = false;
            dgvBuildInfo.Name = "dgvBuildInfo";
            dgvBuildInfo.ReadOnly = true;
            dgvBuildInfo.Size = new System.Drawing.Size(964, 348);
            dgvBuildInfo.TabIndex = 0;
            // 
            // colBuildName
            // 
            colBuildName.FillWeight = 38F;
            colBuildName.HeaderText = "Field";
            colBuildName.Name = "colBuildName";
            colBuildName.ReadOnly = true;
            colBuildName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colBuildValue
            // 
            colBuildValue.FillWeight = 62F;
            colBuildValue.HeaderText = "Value";
            colBuildValue.Name = "colBuildValue";
            colBuildValue.ReadOnly = true;
            colBuildValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabPackageEntries
            // 
            tabPackageEntries.Controls.Add(dgvEntries);
            tabPackageEntries.Location = new System.Drawing.Point(4, 32);
            tabPackageEntries.Name = "tabPackageEntries";
            tabPackageEntries.Size = new System.Drawing.Size(964, 348);
            tabPackageEntries.TabIndex = 2;
            tabPackageEntries.Text = "Entries";
            // 
            // dgvEntries
            // 
            dgvEntries.AllowUserToAddRows = false;
            dgvEntries.AllowUserToDeleteRows = false;
            dgvEntries.AllowUserToOrderColumns = true;
            dgvEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colEntryName, colEntryOffset, colEntrySize, colEntryFlags1, colEntryFlags2, colEntryEncrypted });
            dgvEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvEntries.Location = new System.Drawing.Point(0, 0);
            dgvEntries.MultiSelect = false;
            dgvEntries.Name = "dgvEntries";
            dgvEntries.ReadOnly = true;
            dgvEntries.Size = new System.Drawing.Size(964, 348);
            dgvEntries.TabIndex = 1;
            // 
            // colEntryName
            // 
            colEntryName.FillWeight = 24F;
            colEntryName.HeaderText = "Name";
            colEntryName.Name = "colEntryName";
            colEntryName.ReadOnly = true;
            colEntryName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEntryOffset
            // 
            colEntryOffset.FillWeight = 17F;
            colEntryOffset.HeaderText = "Offset";
            colEntryOffset.Name = "colEntryOffset";
            colEntryOffset.ReadOnly = true;
            colEntryOffset.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEntrySize
            // 
            colEntrySize.FillWeight = 17F;
            colEntrySize.HeaderText = "Size";
            colEntrySize.Name = "colEntrySize";
            colEntrySize.ReadOnly = true;
            colEntrySize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEntryFlags1
            // 
            colEntryFlags1.FillWeight = 14F;
            colEntryFlags1.HeaderText = "Flags 1";
            colEntryFlags1.Name = "colEntryFlags1";
            colEntryFlags1.ReadOnly = true;
            colEntryFlags1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEntryFlags2
            // 
            colEntryFlags2.FillWeight = 14F;
            colEntryFlags2.HeaderText = "Flags 2";
            colEntryFlags2.Name = "colEntryFlags2";
            colEntryFlags2.ReadOnly = true;
            colEntryFlags2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEntryEncrypted
            // 
            colEntryEncrypted.FillWeight = 14F;
            colEntryEncrypted.HeaderText = "Encrypted?";
            colEntryEncrypted.Name = "colEntryEncrypted";
            colEntryEncrypted.ReadOnly = true;
            colEntryEncrypted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabTrophy
            // 
            tabTrophy.Controls.Add(dgvTrophies);
            tabTrophy.Controls.Add(lblTrophyState);
            tabTrophy.Location = new System.Drawing.Point(4, 32);
            tabTrophy.Name = "tabTrophy";
            tabTrophy.Padding = new System.Windows.Forms.Padding(12);
            tabTrophy.Size = new System.Drawing.Size(996, 408);
            tabTrophy.TabIndex = 3;
            tabTrophy.Text = "Trophy";
            // 
            // dgvTrophies
            // 
            dgvTrophies.AllowUserToAddRows = false;
            dgvTrophies.AllowUserToDeleteRows = false;
            dgvTrophies.AllowUserToOrderColumns = true;
            dgvTrophies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrophies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgvTrophies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colTrophyIcon, colTrophyId, colTrophyName, colTrophyDescription, colTrophyType, colTrophyHidden });
            dgvTrophies.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTrophies.Location = new System.Drawing.Point(12, 42);
            dgvTrophies.MultiSelect = false;
            dgvTrophies.Name = "dgvTrophies";
            dgvTrophies.ReadOnly = true;
            dgvTrophies.RowTemplate.Height = 52;
            dgvTrophies.Size = new System.Drawing.Size(972, 354);
            dgvTrophies.TabIndex = 1;
            // 
            // colTrophyIcon
            // 
            colTrophyIcon.FillWeight = 10F;
            colTrophyIcon.HeaderText = "Icon";
            colTrophyIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            colTrophyIcon.Name = "colTrophyIcon";
            colTrophyIcon.ReadOnly = true;
            colTrophyIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTrophyId
            // 
            colTrophyId.FillWeight = 8F;
            colTrophyId.HeaderText = "ID";
            colTrophyId.Name = "colTrophyId";
            colTrophyId.ReadOnly = true;
            colTrophyId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTrophyName
            // 
            colTrophyName.FillWeight = 23F;
            colTrophyName.HeaderText = "Name";
            colTrophyName.Name = "colTrophyName";
            colTrophyName.ReadOnly = true;
            colTrophyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTrophyDescription
            // 
            colTrophyDescription.FillWeight = 39F;
            colTrophyDescription.HeaderText = "Description";
            colTrophyDescription.Name = "colTrophyDescription";
            colTrophyDescription.ReadOnly = true;
            colTrophyDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTrophyType
            // 
            colTrophyType.FillWeight = 12F;
            colTrophyType.HeaderText = "Type";
            colTrophyType.Name = "colTrophyType";
            colTrophyType.ReadOnly = true;
            colTrophyType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTrophyHidden
            // 
            colTrophyHidden.FillWeight = 8F;
            colTrophyHidden.HeaderText = "Hidden";
            colTrophyHidden.Name = "colTrophyHidden";
            colTrophyHidden.ReadOnly = true;
            colTrophyHidden.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lblTrophyState
            // 
            lblTrophyState.Dock = System.Windows.Forms.DockStyle.Top;
            lblTrophyState.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            lblTrophyState.Location = new System.Drawing.Point(12, 12);
            lblTrophyState.Name = "lblTrophyState";
            lblTrophyState.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            lblTrophyState.Size = new System.Drawing.Size(972, 30);
            lblTrophyState.TabIndex = 0;
            lblTrophyState.Text = "Trophy information loads when this page is selected.";
            // 
            // tabFiles
            // 
            tabFiles.Controls.Add(fileBrowserLayout);
            tabFiles.Controls.Add(tbFilterFiles);
            tabFiles.Location = new System.Drawing.Point(4, 32);
            tabFiles.Name = "tabFiles";
            tabFiles.Padding = new System.Windows.Forms.Padding(12);
            tabFiles.Size = new System.Drawing.Size(996, 408);
            tabFiles.TabIndex = 4;
            tabFiles.Text = "File Browser";
            // 
            // fileBrowserLayout
            // 
            fileBrowserLayout.ColumnCount = 3;
            fileBrowserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            fileBrowserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            fileBrowserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            fileBrowserLayout.Controls.Add(tvFiles, 0, 0);
            fileBrowserLayout.Controls.Add(lvFiles, 1, 0);
            fileBrowserLayout.Controls.Add(_filePreviewPanel, 2, 0);
            fileBrowserLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            fileBrowserLayout.Location = new System.Drawing.Point(12, 40);
            fileBrowserLayout.Name = "fileBrowserLayout";
            fileBrowserLayout.RowCount = 1;
            fileBrowserLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            fileBrowserLayout.Size = new System.Drawing.Size(972, 356);
            fileBrowserLayout.TabIndex = 1;
            // 
            // tvFiles
            // 
            tvFiles.CheckBoxes = false;
            tvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            tvFiles.FullRowSelect = false;
            tvFiles.HotTracking = false;
            tvFiles.ImageList = imageListFiles;
            tvFiles.Indent = 19;
            tvFiles.ItemHeight = 24;
            tvFiles.LabelEdit = false;
            tvFiles.Location = new System.Drawing.Point(0, 0);
            tvFiles.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            tvFiles.Name = "tvFiles";
            tvFiles.PathSeparator = "\\";
            tvFiles.Scrollable = true;
            tvFiles.SelectedNode = null;
            tvFiles.ShowLines = true;
            tvFiles.ShowPlusMinus = true;
            tvFiles.ShowRootLines = true;
            tvFiles.Size = new System.Drawing.Size(380, 356);
            tvFiles.Sorted = false;
            tvFiles.TabIndex = 0;
            tvFiles.TopNode = null;
            tvFiles.TreeViewNodeSorter = null;
            tvFiles.UseCompatibleStateImageBehavior = false;
            tvFiles.AfterSelect += tvFiles_AfterSelect;
            // 
            // imageListFiles
            // 
            imageListFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageListFiles.ImageSize = new System.Drawing.Size(16, 16);
            imageListFiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lvFiles
            // 
            lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            lvFiles.FullRowSelect = true;
            lvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            lvFiles.LargeImageList = null;
            lvFiles.ListViewItemSorter = null;
            lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colFileName, colFileType, colFilePath, colFileSize });
            lvFiles.Location = new System.Drawing.Point(280, 0);
            lvFiles.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            lvFiles.MultiSelect = false;
            lvFiles.Name = "lvFiles";
            lvFiles.Size = new System.Drawing.Size(342, 356);
            lvFiles.SmallImageList = imageListFiles;
            lvFiles.TabIndex = 1;
            lvFiles.UseCompatibleStateImageBehavior = false;
            lvFiles.View = System.Windows.Forms.View.Details;
            lvFiles.ItemActivate += lvFiles_ItemActivate;
            lvFiles.MouseClick += lvFiles_MouseClick;
            // 
            // _filePreviewPanel
            // 
            _filePreviewPanel.Controls.Add(_filePreviewBody);
            _filePreviewPanel.Controls.Add(_filePreviewInfo);
            _filePreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _filePreviewPanel.Location = new System.Drawing.Point(630, 0);
            _filePreviewPanel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            _filePreviewPanel.Name = "_filePreviewPanel";
            _filePreviewPanel.SectionHeader = "File Preview";
            _filePreviewPanel.Size = new System.Drawing.Size(342, 356);
            _filePreviewPanel.TabIndex = 2;
            // 
            // _filePreviewInfo
            // 
            _filePreviewInfo.AutoEllipsis = true;
            _filePreviewInfo.Dock = System.Windows.Forms.DockStyle.Top;
            _filePreviewInfo.Location = new System.Drawing.Point(1, 25);
            _filePreviewInfo.Name = "_filePreviewInfo";
            _filePreviewInfo.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            _filePreviewInfo.Size = new System.Drawing.Size(340, 34);
            _filePreviewInfo.TabIndex = 0;
            _filePreviewInfo.Text = "Double-click a file to preview it.";
            _filePreviewInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _filePreviewBody
            // 
            _filePreviewBody.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            _filePreviewBody.Controls.Add(_filePreviewImage);
            _filePreviewBody.Controls.Add(_filePreviewText);
            _filePreviewBody.Controls.Add(_filePreviewAssetList);
            _filePreviewBody.Controls.Add(_filePreviewBackButton);
            _filePreviewBody.Dock = System.Windows.Forms.DockStyle.Fill;
            _filePreviewBody.Location = new System.Drawing.Point(1, 59);
            _filePreviewBody.Name = "_filePreviewBody";
            _filePreviewBody.Padding = new System.Windows.Forms.Padding(1);
            _filePreviewBody.Size = new System.Drawing.Size(340, 296);
            _filePreviewBody.TabIndex = 1;
            // 
            // _filePreviewImage
            // 
            _filePreviewImage.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            _filePreviewImage.Dock = System.Windows.Forms.DockStyle.Fill;
            _filePreviewImage.Location = new System.Drawing.Point(1, 1);
            _filePreviewImage.Name = "_filePreviewImage";
            _filePreviewImage.Size = new System.Drawing.Size(338, 266);
            _filePreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            _filePreviewImage.TabIndex = 0;
            _filePreviewImage.TabStop = false;
            _filePreviewImage.Visible = false;
            // 
            // _filePreviewText
            // 
            _filePreviewText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            _filePreviewText.Dock = System.Windows.Forms.DockStyle.Fill;
            _filePreviewText.Font = new System.Drawing.Font("Consolas", 9F);
            _filePreviewText.HideSelection = false;
            _filePreviewText.Location = new System.Drawing.Point(1, 1);
            _filePreviewText.Multiline = true;
            _filePreviewText.Name = "_filePreviewText";
            _filePreviewText.ReadOnly = true;
            _filePreviewText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            _filePreviewText.Size = new System.Drawing.Size(338, 266);
            _filePreviewText.TabIndex = 1;
            _filePreviewText.Visible = false;
            _filePreviewText.WordWrap = false;
            // 
            // _filePreviewAssetList
            // 
            _filePreviewAssetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colAssetName, colAssetType, colAssetSize });
            _filePreviewAssetList.Dock = System.Windows.Forms.DockStyle.Fill;
            _filePreviewAssetList.FullRowSelect = true;
            _filePreviewAssetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable;
            _filePreviewAssetList.Location = new System.Drawing.Point(1, 1);
            _filePreviewAssetList.MultiSelect = false;
            _filePreviewAssetList.Name = "_filePreviewAssetList";
            _filePreviewAssetList.Size = new System.Drawing.Size(338, 266);
            _filePreviewAssetList.TabIndex = 2;
            _filePreviewAssetList.UseCompatibleStateImageBehavior = false;
            _filePreviewAssetList.View = System.Windows.Forms.View.Details;
            _filePreviewAssetList.Visible = false;
            _filePreviewAssetList.ItemActivate += filePreviewAssetList_ItemActivate;
            // 
            // colAssetName
            // 
            colAssetName.Text = "Name";
            colAssetName.Width = 190;
            // 
            // colAssetType
            // 
            colAssetType.Text = "Type";
            colAssetType.Width = 90;
            // 
            // colAssetSize
            // 
            colAssetSize.Text = "Size";
            colAssetSize.Width = 75;
            // 
            // _filePreviewBackButton
            // 
            _filePreviewBackButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            _filePreviewBackButton.Location = new System.Drawing.Point(1, 267);
            _filePreviewBackButton.Name = "_filePreviewBackButton";
            _filePreviewBackButton.Size = new System.Drawing.Size(338, 28);
            _filePreviewBackButton.TabIndex = 3;
            _filePreviewBackButton.Text = "Back to asset list";
            _filePreviewBackButton.Visible = false;
            _filePreviewBackButton.Click += filePreviewBackButton_Click;
            // 
            // tbFilterFiles
            // 
            tbFilterFiles.Dock = System.Windows.Forms.DockStyle.Top;
            tbFilterFiles.Location = new System.Drawing.Point(12, 12);
            tbFilterFiles.Name = "tbFilterFiles";
            tbFilterFiles.Placeholder = "Filter filename here";
            tbFilterFiles.Size = new System.Drawing.Size(972, 28);
            tbFilterFiles.TabIndex = 2;
            tbFilterFiles.SearchTextChanged += tbFilterFiles_SearchTextChanged;
            // 
            // tabArtwork
            // 
            tabArtwork.Controls.Add(artworkTable);
            tabArtwork.Location = new System.Drawing.Point(4, 32);
            tabArtwork.Name = "tabArtwork";
            tabArtwork.Padding = new System.Windows.Forms.Padding(12);
            tabArtwork.Size = new System.Drawing.Size(996, 408);
            tabArtwork.TabIndex = 5;
            tabArtwork.Text = "Artwork";
            // 
            // artworkTable
            // 
            artworkTable.ColumnCount = 2;
            artworkTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            artworkTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            artworkTable.Controls.Add(pic0Panel, 0, 0);
            artworkTable.Controls.Add(pic1Panel, 1, 0);
            artworkTable.Dock = System.Windows.Forms.DockStyle.Fill;
            artworkTable.Location = new System.Drawing.Point(12, 12);
            artworkTable.Name = "artworkTable";
            artworkTable.RowCount = 1;
            artworkTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            artworkTable.Size = new System.Drawing.Size(972, 384);
            artworkTable.TabIndex = 0;
            // 
            // pic0Panel
            // 
            pic0Panel.Controls.Add(lblNoPic0);
            pic0Panel.Controls.Add(picPic0);
            pic0Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            pic0Panel.Location = new System.Drawing.Point(0, 0);
            pic0Panel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            pic0Panel.Name = "pic0Panel";
            pic0Panel.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            pic0Panel.SectionHeader = "PIC0";
            pic0Panel.Size = new System.Drawing.Size(478, 384);
            pic0Panel.TabIndex = 0;
            // 
            // lblNoPic0
            // 
            lblNoPic0.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNoPic0.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblNoPic0.Location = new System.Drawing.Point(13, 35);
            lblNoPic0.Name = "lblNoPic0";
            lblNoPic0.Size = new System.Drawing.Size(452, 336);
            lblNoPic0.TabIndex = 0;
            lblNoPic0.Text = "No PIC0 image in this package.";
            lblNoPic0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPic0
            // 
            picPic0.Dock = System.Windows.Forms.DockStyle.Fill;
            picPic0.Location = new System.Drawing.Point(13, 35);
            picPic0.Name = "picPic0";
            picPic0.Size = new System.Drawing.Size(452, 336);
            picPic0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picPic0.TabIndex = 1;
            picPic0.TabStop = false;
            picPic0.Visible = false;
            // 
            // pic1Panel
            // 
            pic1Panel.Controls.Add(lblNoPic1);
            pic1Panel.Controls.Add(picPic1);
            pic1Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            pic1Panel.Location = new System.Drawing.Point(494, 0);
            pic1Panel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            pic1Panel.Name = "pic1Panel";
            pic1Panel.Padding = new System.Windows.Forms.Padding(12, 10, 12, 12);
            pic1Panel.SectionHeader = "PIC1";
            pic1Panel.Size = new System.Drawing.Size(478, 384);
            pic1Panel.TabIndex = 1;
            // 
            // lblNoPic1
            // 
            lblNoPic1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNoPic1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblNoPic1.Location = new System.Drawing.Point(13, 35);
            lblNoPic1.Name = "lblNoPic1";
            lblNoPic1.Size = new System.Drawing.Size(452, 336);
            lblNoPic1.TabIndex = 0;
            lblNoPic1.Text = "No PIC1 image in this package.";
            lblNoPic1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPic1
            // 
            picPic1.Dock = System.Windows.Forms.DockStyle.Fill;
            picPic1.Location = new System.Drawing.Point(13, 35);
            picPic1.Name = "picPic1";
            picPic1.Size = new System.Drawing.Size(452, 336);
            picPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picPic1.TabIndex = 1;
            picPic1.TabStop = false;
            picPic1.Visible = false;
            // 
            // ctxPkgOperations
            // 
            ctxPkgOperations.Font = new System.Drawing.Font("Segoe UI", 9F);
            ctxPkgOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileMenu, toolsMenu });
            ctxPkgOperations.Name = "ctxPkgOperations";
            ctxPkgOperations.Size = new System.Drawing.Size(103, 48);
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyMenu, sepRename, renameMenu, sepDelete, deleteItem });
            fileMenu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new System.Drawing.Size(102, 22);
            fileMenu.Text = "File";
            // 
            // copyMenu
            // 
            copyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyTitleIdItem, copyContentIdItem, copyTitleItem, copyFilenameItem });
            copyMenu.Name = "copyMenu";
            copyMenu.Size = new System.Drawing.Size(141, 22);
            copyMenu.Text = "Copy";
            // 
            // copyTitleIdItem
            // 
            copyTitleIdItem.Name = "copyTitleIdItem";
            copyTitleIdItem.Size = new System.Drawing.Size(145, 22);
            copyTitleIdItem.Tag = "title_id";
            copyTitleIdItem.Text = "TITLE_ID";
            copyTitleIdItem.Click += CopyInfoItem_Click;
            // 
            // copyContentIdItem
            // 
            copyContentIdItem.Name = "copyContentIdItem";
            copyContentIdItem.Size = new System.Drawing.Size(145, 22);
            copyContentIdItem.Tag = "content_id";
            copyContentIdItem.Text = "CONTENT_ID";
            copyContentIdItem.Click += CopyInfoItem_Click;
            // 
            // copyTitleItem
            // 
            copyTitleItem.Name = "copyTitleItem";
            copyTitleItem.Size = new System.Drawing.Size(145, 22);
            copyTitleItem.Tag = "title";
            copyTitleItem.Text = "TITLE";
            copyTitleItem.Click += CopyInfoItem_Click;
            // 
            // copyFilenameItem
            // 
            copyFilenameItem.Name = "copyFilenameItem";
            copyFilenameItem.Size = new System.Drawing.Size(145, 22);
            copyFilenameItem.Tag = "filename";
            copyFilenameItem.Text = "FILENAME";
            copyFilenameItem.Click += CopyInfoItem_Click;
            // 
            // sepRename
            // 
            sepRename.Name = "sepRename";
            sepRename.Size = new System.Drawing.Size(138, 6);
            // 
            // renameMenu
            // 
            renameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { renameItem1, renameItem2, renameItem3, renameItem4, renameItem5, renameItem6, renameItem7, renameItem8, renameItem9, renameItem10, renameItem11 });
            renameMenu.Name = "renameMenu";
            renameMenu.Size = new System.Drawing.Size(141, 22);
            renameMenu.Text = "Rename PKG";
            // 
            // renameItem1
            // 
            renameItem1.Name = "renameItem1";
            renameItem1.Size = new System.Drawing.Size(314, 22);
            renameItem1.Tag = 1;
            renameItem1.Text = "TITLE";
            renameItem1.Click += RenamePkgItem_Click;
            // 
            // renameItem2
            // 
            renameItem2.Name = "renameItem2";
            renameItem2.Size = new System.Drawing.Size(314, 22);
            renameItem2.Tag = 2;
            renameItem2.Text = "TITLE [TITLE_ID]";
            renameItem2.Click += RenamePkgItem_Click;
            // 
            // renameItem3
            // 
            renameItem3.Name = "renameItem3";
            renameItem3.Size = new System.Drawing.Size(314, 22);
            renameItem3.Tag = 3;
            renameItem3.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            renameItem3.Click += RenamePkgItem_Click;
            // 
            // renameItem4
            // 
            renameItem4.Name = "renameItem4";
            renameItem4.Size = new System.Drawing.Size(314, 22);
            renameItem4.Tag = 4;
            renameItem4.Text = "TITLE [CATEGORY]";
            renameItem4.Click += RenamePkgItem_Click;
            // 
            // renameItem5
            // 
            renameItem5.Name = "renameItem5";
            renameItem5.Size = new System.Drawing.Size(314, 22);
            renameItem5.Tag = 5;
            renameItem5.Text = "TITLE_ID";
            renameItem5.Click += RenamePkgItem_Click;
            // 
            // renameItem6
            // 
            renameItem6.Name = "renameItem6";
            renameItem6.Size = new System.Drawing.Size(314, 22);
            renameItem6.Tag = 6;
            renameItem6.Text = "TITLE_ID [TITLE]";
            renameItem6.Click += RenamePkgItem_Click;
            // 
            // renameItem7
            // 
            renameItem7.Name = "renameItem7";
            renameItem7.Size = new System.Drawing.Size(314, 22);
            renameItem7.Tag = 7;
            renameItem7.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            renameItem7.Click += RenamePkgItem_Click;
            // 
            // renameItem8
            // 
            renameItem8.Name = "renameItem8";
            renameItem8.Size = new System.Drawing.Size(314, 22);
            renameItem8.Tag = 8;
            renameItem8.Text = "TITLE [CATEGORY] [VERSION]";
            renameItem8.Click += RenamePkgItem_Click;
            // 
            // renameItem9
            // 
            renameItem9.Name = "renameItem9";
            renameItem9.Size = new System.Drawing.Size(314, 22);
            renameItem9.Tag = 9;
            renameItem9.Text = "CONTENT_ID";
            renameItem9.Click += RenamePkgItem_Click;
            // 
            // renameItem10
            // 
            renameItem10.Name = "renameItem10";
            renameItem10.Size = new System.Drawing.Size(314, 22);
            renameItem10.Tag = 10;
            renameItem10.Text = "CONTENT_ID 2";
            renameItem10.Click += RenamePkgItem_Click;
            // 
            // renameItem11
            // 
            renameItem11.Name = "renameItem11";
            renameItem11.Size = new System.Drawing.Size(314, 22);
            renameItem11.Tag = 11;
            renameItem11.Text = "CUSTOM NAME";
            renameItem11.Click += RenamePkgItem_Click;
            // 
            // sepDelete
            // 
            sepDelete.Name = "sepDelete";
            sepDelete.Size = new System.Drawing.Size(138, 6);
            // 
            // deleteItem
            // 
            deleteItem.Name = "deleteItem";
            deleteItem.Size = new System.Drawing.Size(141, 22);
            deleteItem.Text = "Delete PKG";
            deleteItem.Click += DeletePkgItem_Click;
            // 
            // toolsMenu
            // 
            toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { artworkMenu, extractFullPkgItem, sepChangeInfo, changeInfoItem });
            toolsMenu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolsMenu.Name = "toolsMenu";
            toolsMenu.Size = new System.Drawing.Size(102, 22);
            toolsMenu.Text = "Tools";
            // 
            // artworkMenu
            // 
            artworkMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { artworkAllItem, artworkImagesItem, artworkIconItem });
            artworkMenu.Name = "artworkMenu";
            artworkMenu.Size = new System.Drawing.Size(191, 22);
            artworkMenu.Text = "Save artwork";
            // 
            // artworkAllItem
            // 
            artworkAllItem.Name = "artworkAllItem";
            artworkAllItem.Size = new System.Drawing.Size(180, 22);
            artworkAllItem.Tag = "ALL";
            artworkAllItem.Text = "Backgrounds + Icon";
            artworkAllItem.Click += SaveArtworkItem_Click;
            // 
            // artworkImagesItem
            // 
            artworkImagesItem.Name = "artworkImagesItem";
            artworkImagesItem.Size = new System.Drawing.Size(180, 22);
            artworkImagesItem.Tag = "IMAGE";
            artworkImagesItem.Text = "Backgrounds only";
            artworkImagesItem.Click += SaveArtworkItem_Click;
            // 
            // artworkIconItem
            // 
            artworkIconItem.Name = "artworkIconItem";
            artworkIconItem.Size = new System.Drawing.Size(180, 22);
            artworkIconItem.Tag = "ICON";
            artworkIconItem.Text = "Icon only";
            artworkIconItem.Click += SaveArtworkItem_Click;
            // 
            // extractFullPkgItem
            // 
            extractFullPkgItem.Name = "extractFullPkgItem";
            extractFullPkgItem.Size = new System.Drawing.Size(191, 22);
            extractFullPkgItem.Text = "Extract Full PKG...";
            extractFullPkgItem.Click += ExtractFullPkgItem_Click;
            // 
            // sepChangeInfo
            // 
            sepChangeInfo.Name = "sepChangeInfo";
            sepChangeInfo.Size = new System.Drawing.Size(188, 6);
            // 
            // changeInfoItem
            // 
            changeInfoItem.Name = "changeInfoItem";
            changeInfoItem.Size = new System.Drawing.Size(191, 22);
            changeInfoItem.Text = "View PKG Change Info";
            changeInfoItem.Click += ViewChangeInfoItem_Click;
            // 
            // colFileName
            // 
            colFileName.Text = "Name";
            colFileName.Width = 143;
            // 
            // colFileType
            // 
            colFileType.Text = "Type";
            colFileType.Width = 143;
            // 
            // colFilePath
            // 
            colFilePath.Text = "Path";
            colFilePath.Width = 143;
            // 
            // colFileSize
            // 
            colFileSize.Text = "Size";
            colFileSize.Width = 143;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator13.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new System.Drawing.Size(6, 21);
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator14.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new System.Drawing.Size(6, 21);
            // 
            // tbCopyMenu
            // 
            tbCopyMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tbCopyTitleIdItem, tbCopyContentIdItem, tbCopyTitleItem });
            tbCopyMenu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbCopyMenu.Name = "tbCopyMenu";
            tbCopyMenu.Size = new System.Drawing.Size(141, 22);
            tbCopyMenu.Text = "Copy";
            // 
            // tbCopyTitleIdItem
            // 
            tbCopyTitleIdItem.Name = "tbCopyTitleIdItem";
            tbCopyTitleIdItem.Size = new System.Drawing.Size(145, 22);
            tbCopyTitleIdItem.Tag = "title_id";
            tbCopyTitleIdItem.Text = "TITLE_ID";
            tbCopyTitleIdItem.Click += CopyInfoItem_Click;
            // 
            // tbCopyContentIdItem
            // 
            tbCopyContentIdItem.Name = "tbCopyContentIdItem";
            tbCopyContentIdItem.Size = new System.Drawing.Size(145, 22);
            tbCopyContentIdItem.Tag = "content_id";
            tbCopyContentIdItem.Text = "CONTENT_ID";
            tbCopyContentIdItem.Click += CopyInfoItem_Click;
            // 
            // tbCopyTitleItem
            // 
            tbCopyTitleItem.Name = "tbCopyTitleItem";
            tbCopyTitleItem.Size = new System.Drawing.Size(145, 22);
            tbCopyTitleItem.Tag = "title";
            tbCopyTitleItem.Text = "TITLE";
            tbCopyTitleItem.Click += CopyInfoItem_Click;
            // 
            // tbSepRename
            // 
            tbSepRename.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbSepRename.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            tbSepRename.Name = "tbSepRename";
            tbSepRename.Size = new System.Drawing.Size(138, 6);
            // 
            // tbRenameMenu
            // 
            tbRenameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tbRenameItem1, tbRenameItem2, tbRenameItem3, tbRenameItem4, tbRenameItem5, tbRenameItem6, tbRenameItem7, tbRenameItem8, tbRenameItem9, tbRenameItem10 });
            tbRenameMenu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbRenameMenu.Name = "tbRenameMenu";
            tbRenameMenu.Size = new System.Drawing.Size(141, 22);
            tbRenameMenu.Text = "Rename PKG";
            // 
            // tbRenameItem1
            // 
            tbRenameItem1.Name = "tbRenameItem1";
            tbRenameItem1.Size = new System.Drawing.Size(314, 22);
            tbRenameItem1.Tag = 1;
            tbRenameItem1.Text = "TITLE";
            tbRenameItem1.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem2
            // 
            tbRenameItem2.Name = "tbRenameItem2";
            tbRenameItem2.Size = new System.Drawing.Size(314, 22);
            tbRenameItem2.Tag = 2;
            tbRenameItem2.Text = "TITLE [TITLE_ID]";
            tbRenameItem2.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem3
            // 
            tbRenameItem3.Name = "tbRenameItem3";
            tbRenameItem3.Size = new System.Drawing.Size(314, 22);
            tbRenameItem3.Tag = 3;
            tbRenameItem3.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            tbRenameItem3.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem4
            // 
            tbRenameItem4.Name = "tbRenameItem4";
            tbRenameItem4.Size = new System.Drawing.Size(314, 22);
            tbRenameItem4.Tag = 4;
            tbRenameItem4.Text = "TITLE [CATEGORY]";
            tbRenameItem4.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem5
            // 
            tbRenameItem5.Name = "tbRenameItem5";
            tbRenameItem5.Size = new System.Drawing.Size(314, 22);
            tbRenameItem5.Tag = 5;
            tbRenameItem5.Text = "TITLE_ID";
            tbRenameItem5.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem6
            // 
            tbRenameItem6.Name = "tbRenameItem6";
            tbRenameItem6.Size = new System.Drawing.Size(314, 22);
            tbRenameItem6.Tag = 6;
            tbRenameItem6.Text = "TITLE_ID [TITLE]";
            tbRenameItem6.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem7
            // 
            tbRenameItem7.Name = "tbRenameItem7";
            tbRenameItem7.Size = new System.Drawing.Size(314, 22);
            tbRenameItem7.Tag = 7;
            tbRenameItem7.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            tbRenameItem7.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem8
            // 
            tbRenameItem8.Name = "tbRenameItem8";
            tbRenameItem8.Size = new System.Drawing.Size(314, 22);
            tbRenameItem8.Tag = 8;
            tbRenameItem8.Text = "TITLE [CATEGORY] [VERSION]";
            tbRenameItem8.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem9
            // 
            tbRenameItem9.Name = "tbRenameItem9";
            tbRenameItem9.Size = new System.Drawing.Size(314, 22);
            tbRenameItem9.Tag = 9;
            tbRenameItem9.Text = "CONTENT_ID";
            tbRenameItem9.Click += RenamePkgItem_Click;
            // 
            // tbRenameItem10
            // 
            tbRenameItem10.Name = "tbRenameItem10";
            tbRenameItem10.Size = new System.Drawing.Size(314, 22);
            tbRenameItem10.Tag = 10;
            tbRenameItem10.Text = "CONTENT_ID 2";
            tbRenameItem10.Click += RenamePkgItem_Click;
            // 
            // tbArtworkMenu
            // 
            tbArtworkMenu.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbArtworkMenu.Name = "tbArtworkMenu";
            tbArtworkMenu.Size = new System.Drawing.Size(210, 22);
            tbArtworkMenu.Tag = "ALL";
            tbArtworkMenu.Text = "Save Artwork";
            tbArtworkMenu.Click += SaveArtworkItem_Click;
            // 
            // tbSepChangeInfo
            // 
            tbSepChangeInfo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbSepChangeInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            tbSepChangeInfo.Name = "tbSepChangeInfo";
            tbSepChangeInfo.Size = new System.Drawing.Size(207, 6);
            // 
            // tbChangeInfoItem
            // 
            tbChangeInfoItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbChangeInfoItem.Name = "tbChangeInfoItem";
            tbChangeInfoItem.Size = new System.Drawing.Size(210, 22);
            tbChangeInfoItem.Text = "View Change Info";
            tbChangeInfoItem.Click += ViewChangeInfoItem_Click;
            // 
            // tbDownloadUpdateItem
            // 
            tbDownloadUpdateItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbDownloadUpdateItem.Name = "tbDownloadUpdateItem";
            tbDownloadUpdateItem.Size = new System.Drawing.Size(210, 22);
            tbDownloadUpdateItem.Text = "Download Official Update";
            tbDownloadUpdateItem.Visible = false;
            tbDownloadUpdateItem.Click += DownloadUpdateItem_Click;
            // 
            // tbExtractFullPkgItem
            // 
            tbExtractFullPkgItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            tbExtractFullPkgItem.Name = "tbExtractFullPkgItem";
            tbExtractFullPkgItem.Size = new System.Drawing.Size(210, 22);
            tbExtractFullPkgItem.Text = "Extract PKG";
            tbExtractFullPkgItem.Click += ExtractFullPkgItem_Click;
            // 
            // tbSepExit
            // 
            tbSepExit.Name = "tbSepExit";
            tbSepExit.Size = new System.Drawing.Size(138, 6);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { helpAboutItem, helpCoffeeItem, helpUpdateItem });
            helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpAboutItem
            // 
            helpAboutItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            helpAboutItem.Name = "helpAboutItem";
            helpAboutItem.Size = new System.Drawing.Size(165, 22);
            helpAboutItem.Text = "About";
            helpAboutItem.Click += HelpAboutItem_Click;
            // 
            // helpCoffeeItem
            // 
            helpCoffeeItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            helpCoffeeItem.Name = "helpCoffeeItem";
            helpCoffeeItem.Size = new System.Drawing.Size(165, 22);
            helpCoffeeItem.Text = "Buy me a coffee";
            helpCoffeeItem.Click += HelpCoffeeItem_Click;
            // 
            // helpUpdateItem
            // 
            helpUpdateItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            helpUpdateItem.Name = "helpUpdateItem";
            helpUpdateItem.Size = new System.Drawing.Size(165, 22);
            helpUpdateItem.Text = "Check for update";
            helpUpdateItem.Click += HelpUpdateItem_Click;
            // 
            // ctxFileList
            // 
            ctxFileList.Font = new System.Drawing.Font("Segoe UI", 9F);
            ctxFileList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ctxExtractItem, ctxExtractFolderItem, sepListExtract, ctxCopyPathItem, ctxCopyNameItem });
            ctxFileList.Name = "ctxFileList";
            ctxFileList.Size = new System.Drawing.Size(274, 99);
            // 
            // ctxExtractItem
            // 
            ctxExtractItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxExtractItem.Name = "ctxExtractItem";
            ctxExtractItem.Size = new System.Drawing.Size(273, 22);
            ctxExtractItem.Text = "Extract selected item";
            ctxExtractItem.Click += CtxExtractItem_Click;
            // 
            // ctxExtractFolderItem
            // 
            ctxExtractFolderItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxExtractFolderItem.Name = "ctxExtractFolderItem";
            ctxExtractFolderItem.Size = new System.Drawing.Size(273, 22);
            ctxExtractFolderItem.Text = "Extract selected (with folder structure)";
            ctxExtractFolderItem.Click += CtxExtractFolderItem_Click;
            // 
            // sepListExtract
            // 
            sepListExtract.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            sepListExtract.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            sepListExtract.Name = "sepListExtract";
            sepListExtract.Size = new System.Drawing.Size(270, 6);
            // 
            // ctxCopyPathItem
            // 
            ctxCopyPathItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxCopyPathItem.Name = "ctxCopyPathItem";
            ctxCopyPathItem.Size = new System.Drawing.Size(273, 22);
            ctxCopyPathItem.Text = "Copy path";
            ctxCopyPathItem.Click += CtxCopyPathItem_Click;
            // 
            // ctxCopyNameItem
            // 
            ctxCopyNameItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxCopyNameItem.Name = "ctxCopyNameItem";
            ctxCopyNameItem.Size = new System.Drawing.Size(273, 22);
            ctxCopyNameItem.Text = "Copy filename";
            ctxCopyNameItem.Click += CtxCopyNameItem_Click;
            // 
            // darkStatusStrip1
            // 
            darkStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            darkStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel3, toolStripStatusLabel5, toolStripSeparator13, toolStripProgressBar1, toolStripSeparator14, toolStripStatusLabel2, labelDisplayTotalPKG, btnStopExtract, toolStripStatusLabel4 });
            darkStatusStrip1.Location = new System.Drawing.Point(0, 572);
            darkStatusStrip1.Name = "darkStatusStrip1";
            darkStatusStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 2);
            darkStatusStrip1.Size = new System.Drawing.Size(1004, 28);
            darkStatusStrip1.TabIndex = 2;
            darkStatusStrip1.Text = "darkStatusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(13, 16);
            toolStripStatusLabel1.Text = "  ";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(796, 16);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Text = "... ";
            toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDisplayTotalPKG
            // 
            labelDisplayTotalPKG.Name = "labelDisplayTotalPKG";
            labelDisplayTotalPKG.Size = new System.Drawing.Size(16, 16);
            labelDisplayTotalPKG.Text = "...";
            // 
            // btnStopExtract
            // 
            btnStopExtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnStopExtract.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            btnStopExtract.Name = "btnStopExtract";
            btnStopExtract.Size = new System.Drawing.Size(72, 19);
            btnStopExtract.Text = "Stop Extract";
            btnStopExtract.Visible = false;
            btnStopExtract.Click += BtnStopExtract_Click;
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(13, 16);
            toolStripStatusLabel4.Text = "  ";
            // 
            // darkMenuStrip1
            // 
            darkMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            darkMenuStrip1.Location = new System.Drawing.Point(0, 0);
            darkMenuStrip1.Name = "darkMenuStrip1";
            darkMenuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            darkMenuStrip1.Size = new System.Drawing.Size(1004, 24);
            darkMenuStrip1.TabIndex = 3;
            darkMenuStrip1.Text = "darkMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tbCopyMenu, tbSepRename, tbRenameMenu, tbSepExit, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tbArtworkMenu, tbExtractFullPkgItem, tbSepChangeInfo, tbChangeInfoItem, tbDownloadUpdateItem });
            toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            exitToolStripMenuItem1.Text = "Exit";
            // 
            // MiniPkgViewerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1004, 600);
            Controls.Add(tabsViewer);
            Controls.Add(headerPanel);
            Controls.Add(darkMenuStrip1);
            Controls.Add(darkStatusStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(800, 580);
            Name = "MiniPkgViewerForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosing += MiniPkgViewerForm_FormClosing;
            Shown += MiniPkgViewerForm_Shown;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            tabsViewer.ResumeLayout(false);
            tabOverview.ResumeLayout(false);
            darkSectionPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSfo).EndInit();
            overviewPanel.ResumeLayout(false);
            overviewTable.ResumeLayout(false);
            tabPackage.ResumeLayout(false);
            packageTabs.ResumeLayout(false);
            tabPackageHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPackageHeader).EndInit();
            tabPackageBuildInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBuildInfo).EndInit();
            tabPackageEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEntries).EndInit();
            tabTrophy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrophies).EndInit();
            tabFiles.ResumeLayout(false);
            fileBrowserLayout.ResumeLayout(false);
            _filePreviewPanel.ResumeLayout(false);
            _filePreviewBody.ResumeLayout(false);
            _filePreviewBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_filePreviewImage).EndInit();
            tabArtwork.ResumeLayout(false);
            artworkTable.ResumeLayout(false);
            pic0Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPic0).EndInit();
            pic1Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPic1).EndInit();
            ctxPkgOperations.ResumeLayout(false);
            ctxFileList.ResumeLayout(false);
            darkStatusStrip1.ResumeLayout(false);
            darkStatusStrip1.PerformLayout();
            darkMenuStrip1.ResumeLayout(false);
            darkMenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private DarkUI.Controls.DarkHeaderBar headerPanel;
        private DarkUI.Controls.DarkToolStripProgressBar toolStripProgressBar1;
        private DarkUI.Controls.DarkLabel lblContentId;
        private DarkUI.Controls.DarkLabel lblSubtitle;
        private DarkUI.Controls.DarkLabel lblTitle;
        private System.Windows.Forms.PictureBox picIcon;
        private DarkUI.Controls.DarkTabControl tabsViewer;
        private DarkUI.Controls.DarkTabPage tabOverview;
        private DarkUI.Controls.DarkSectionPanel overviewPanel;
        private System.Windows.Forms.TableLayoutPanel overviewTable;
        private DarkUI.Controls.DarkLabel lblOverviewTitleCaption;
        private DarkUI.Controls.DarkLabel lblOverviewTitle;
        private DarkUI.Controls.DarkLabel lblOverviewTitleIdCaption;
        private DarkUI.Controls.DarkLabel lblOverviewTitleId;
        private DarkUI.Controls.DarkLabel lblOverviewContentIdCaption;
        private DarkUI.Controls.DarkLabel lblOverviewContentId;
        private DarkUI.Controls.DarkLabel lblOverviewCategoryCaption;
        private DarkUI.Controls.DarkLabel lblOverviewCategory;
        private DarkUI.Controls.DarkLabel lblOverviewStateCaption;
        private DarkUI.Controls.DarkLabel lblOverviewState;
        private DarkUI.Controls.DarkLabel lblOverviewAppVersionCaption;
        private DarkUI.Controls.DarkLabel lblOverviewAppVersion;
        private DarkUI.Controls.DarkLabel lblOverviewPkgVersionCaption;
        private DarkUI.Controls.DarkLabel lblOverviewPkgVersion;
        private DarkUI.Controls.DarkLabel lblOverviewFirmwareCaption;
        private DarkUI.Controls.DarkLabel lblOverviewFirmware;
        private DarkUI.Controls.DarkLabel lblOverviewSizeCaption;
        private DarkUI.Controls.DarkLabel lblOverviewSize;
        private DarkUI.Controls.DarkDataGridView dgvSfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSfoKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSfoValue;
        private DarkUI.Controls.DarkTabPage tabPackage;
        private DarkUI.Controls.DarkTabControl packageTabs;
        private DarkUI.Controls.DarkTabPage tabPackageHeader;
        private DarkUI.Controls.DarkDataGridView dgvPackageHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeaderValue;
        private DarkUI.Controls.DarkTabPage tabPackageBuildInfo;
        private DarkUI.Controls.DarkDataGridView dgvBuildInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildValue;
        private DarkUI.Controls.DarkTabPage tabPackageEntries;
        private DarkUI.Controls.DarkDataGridView dgvEntries;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryOffset;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrySize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryFlags1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryFlags2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntryEncrypted;
        private DarkUI.Controls.DarkTabPage tabTrophy;
        private DarkUI.Controls.DarkDataGridView dgvTrophies;
        private System.Windows.Forms.DataGridViewImageColumn colTrophyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrophyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrophyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrophyDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrophyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrophyHidden;
        private DarkUI.Controls.DarkLabel lblTrophyState;
        private DarkUI.Controls.DarkTabPage tabFiles;
        private System.Windows.Forms.TableLayoutPanel fileBrowserLayout;
        private DarkUI.Controls.DarkTreeView tvFiles;
        private DarkUI.Controls.DarkListView lvFiles;
        private DarkUI.Controls.DarkSectionPanel _filePreviewPanel;
        private System.Windows.Forms.Panel _filePreviewBody;
        private System.Windows.Forms.PictureBox _filePreviewImage;
        private DarkUI.Controls.DarkTextBox _filePreviewText;
        private DarkUI.Controls.DarkLabel _filePreviewInfo;
        private DarkUI.Controls.DarkListView _filePreviewAssetList;
        private DarkUI.Controls.DarkButton _filePreviewBackButton;
        private System.Windows.Forms.ColumnHeader colAssetName;
        private System.Windows.Forms.ColumnHeader colAssetType;
        private System.Windows.Forms.ColumnHeader colAssetSize;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ColumnHeader colFileType;
        private System.Windows.Forms.ColumnHeader colFilePath;
        private System.Windows.Forms.ImageList imageListFiles;
        private DarkUI.Controls.DarkSearchBox tbFilterFiles;
        private DarkUI.Controls.DarkTabPage tabArtwork;
        private System.Windows.Forms.TableLayoutPanel artworkTable;
        private DarkUI.Controls.DarkSectionPanel pic0Panel;
        private DarkUI.Controls.DarkLabel lblNoPic0;
        private System.Windows.Forms.PictureBox picPic0;
        private DarkUI.Controls.DarkSectionPanel pic1Panel;
        private DarkUI.Controls.DarkLabel lblNoPic1;
        private System.Windows.Forms.PictureBox picPic1;
        private DarkUI.Controls.DarkStatusStrip darkStatusStrip1;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel1;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel2;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel3;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel4;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel5;
        private DarkUI.Controls.DarkToolStripStatusLabel labelDisplayTotalPKG;
        private DarkUI.Controls.DarkToolStripButton btnStopExtract;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkMenuStrip darkMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private DarkUI.Controls.DarkContextMenu ctxPkgOperations;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMenu;
        private System.Windows.Forms.ToolStripMenuItem copyTitleIdItem;
        private System.Windows.Forms.ToolStripMenuItem copyContentIdItem;
        private System.Windows.Forms.ToolStripMenuItem copyTitleItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilenameItem;
        private DarkUI.Controls.DarkToolStripSeparator sepRename;
        private System.Windows.Forms.ToolStripMenuItem renameMenu;
        private System.Windows.Forms.ToolStripMenuItem renameItem1;
        private System.Windows.Forms.ToolStripMenuItem renameItem2;
        private System.Windows.Forms.ToolStripMenuItem renameItem3;
        private System.Windows.Forms.ToolStripMenuItem renameItem4;
        private System.Windows.Forms.ToolStripMenuItem renameItem5;
        private System.Windows.Forms.ToolStripMenuItem renameItem6;
        private System.Windows.Forms.ToolStripMenuItem renameItem7;
        private System.Windows.Forms.ToolStripMenuItem renameItem8;
        private System.Windows.Forms.ToolStripMenuItem renameItem9;
        private System.Windows.Forms.ToolStripMenuItem renameItem10;
        private System.Windows.Forms.ToolStripMenuItem renameItem11;
        private DarkUI.Controls.DarkToolStripSeparator sepDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem artworkMenu;
        private System.Windows.Forms.ToolStripMenuItem artworkAllItem;
        private System.Windows.Forms.ToolStripMenuItem artworkImagesItem;
        private System.Windows.Forms.ToolStripMenuItem artworkIconItem;
        private DarkUI.Controls.DarkToolStripSeparator sepChangeInfo;
        private System.Windows.Forms.ToolStripMenuItem changeInfoItem;
        private System.Windows.Forms.ToolStripMenuItem extractFullPkgItem;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator13;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem tbCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem tbCopyTitleIdItem;
        private System.Windows.Forms.ToolStripMenuItem tbCopyContentIdItem;
        private System.Windows.Forms.ToolStripMenuItem tbCopyTitleItem;
        private DarkUI.Controls.DarkToolStripSeparator tbSepRename;
        private System.Windows.Forms.ToolStripMenuItem tbRenameMenu;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem1;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem2;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem3;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem4;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem5;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem6;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem7;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem8;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem9;
        private System.Windows.Forms.ToolStripMenuItem tbRenameItem10;
        private System.Windows.Forms.ToolStripMenuItem tbArtworkMenu;
        private DarkUI.Controls.DarkToolStripSeparator tbSepChangeInfo;
        private System.Windows.Forms.ToolStripMenuItem tbChangeInfoItem;
        private System.Windows.Forms.ToolStripMenuItem tbDownloadUpdateItem;
        private System.Windows.Forms.ToolStripMenuItem tbExtractFullPkgItem;
        private DarkUI.Controls.DarkToolStripSeparator tbSepExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutItem;
        private System.Windows.Forms.ToolStripMenuItem helpCoffeeItem;
        private System.Windows.Forms.ToolStripMenuItem helpUpdateItem;
        private DarkUI.Controls.DarkContextMenu ctxFileList;
        private System.Windows.Forms.ToolStripMenuItem ctxExtractItem;
        private System.Windows.Forms.ToolStripMenuItem ctxExtractFolderItem;
        private DarkUI.Controls.DarkToolStripSeparator sepListExtract;
        private System.Windows.Forms.ToolStripMenuItem ctxCopyPathItem;
        private System.Windows.Forms.ToolStripMenuItem ctxCopyNameItem;
    }
}

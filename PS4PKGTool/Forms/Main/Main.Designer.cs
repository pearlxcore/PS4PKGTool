using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PS4PKGTool
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _groupedViewRefreshTimer = new Timer(components);
            _logFlushTimer = new Timer(components);
            taskRefreshTimer = new Timer(components);
            label1 = new DarkUI.Controls.DarkLabel();
            label2 = new DarkUI.Controls.DarkLabel();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openGameFolderToolStripMenuItem = new ToolStripMenuItem();
            refreshContentToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolToolStripMenuItem = new ToolStripMenuItem();
            gameToolStripMenuItem = new ToolStripMenuItem();
            renamePKGToTITLEToolStripMenuItem = new ToolStripMenuItem();
            renameToTITLEIDToolStripMenuItem = new ToolStripMenuItem();
            renameToCONTENTIDToolStripMenuItem = new ToolStripMenuItem();
            renamePKGToTITLETITLEIDToolStripMenuItem = new ToolStripMenuItem();
            renamePKGToTITLEToolStripMenuItem1 = new ToolStripMenuItem();
            renamePKGToTITLECATEGORYToolStripMenuItem = new ToolStripMenuItem();
            viewTrophyListToolStripMenuItem = new ToolStripMenuItem();
            exportPKGListToExcelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            donateToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            contextMenuPKGGridView = new DarkUI.Controls.DarkContextMenu();
            toolStripMenuItem94 = new ToolStripMenuItem();
            checkForDuplicatePKGToolStripMenuItem2 = new ToolStripMenuItem();
            checkForPatchesMissingBasePKGToolStripMenuItem2 = new ToolStripMenuItem();
            globalExportPKGListToExcelToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            globalExtractImagesAndIconToolStripMenuItem2 = new ToolStripMenuItem();
            globalExtractImageOnlyToolStripMenuItem2 = new ToolStripMenuItem();
            globalExtractIconOnlyToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem111 = new ToolStripMenuItem();
            renameAllPkg1ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg2ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg3ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg4ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg5ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg6ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg7ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg8ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg9ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg10ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg11ToolStripMenuItem2 = new ToolStripMenuItem();
            renameAllPkg12ToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem38 = new ToolStripMenuItem();
            movePkgTitleToolStripMenuItem2 = new ToolStripMenuItem();
            moveByPkgTitleIdToolStripMenuItem = new ToolStripMenuItem();
            movePkgTypeToolStripMenuItem2 = new ToolStripMenuItem();
            movePkgCategoryToolStripMenuItem2 = new ToolStripMenuItem();
            movePkgRegionToolStripMenuItem2 = new ToolStripMenuItem();
            movePkgSingleFolderToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator2 = new DarkUI.Controls.DarkToolStripSeparator();
            GroupActionTitleStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem127 = new ToolStripMenuItem();
            copyTitleIdtoolStripMenuItem2 = new ToolStripMenuItem();
            copyContentIdtoolStripMenuItem2 = new ToolStripMenuItem();
            copyTitleToolStripMenuItem2 = new ToolStripMenuItem();
            copyFilenameToolStripMenuItem2 = new ToolStripMenuItem();
            backportToolStripMenuItem = new ToolStripMenuItem();
            setBackportedToolStripMenuItem2 = new ToolStripMenuItem();
            setBackportRemarksToolStripMenuItem = new ToolStripMenuItem();
            backportRemarkTextboxtoolStripTextBox2 = new DarkUI.Controls.DarkToolStripTextBox();
            setRemarktoolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator9 = new DarkUI.Controls.DarkToolStripSeparator();
            removeBackportedToolStripMenuItem2 = new ToolStripMenuItem();
            deletePkgtoolStripMenuItem2 = new ToolStripMenuItem();
            selectedExportPKGListToExcelToolStripMenuItem2 = new ToolStripMenuItem();
            mergeSelectedBaseAndUpdateToolStripMenuItem = new ToolStripMenuItem();
            convertSelectedToFfpfscToolStripMenuItem = new ToolStripMenuItem();
            extractSelectedFullPkgToolStripMenuItem = new ToolStripMenuItem();
            GroupActionExtacrtImageToolStripMenuItem = new ToolStripMenuItem();
            selectedExtractImagesAndIconToolStripMenuItem2 = new ToolStripMenuItem();
            selectedExtractImageOnlyToolStripMenuItem2 = new ToolStripMenuItem();
            selectedExtractIconOnlyToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem133 = new ToolStripMenuItem();
            renameSelectedPkg1ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg2ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg3ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg4ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg5ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg6ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg7ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg8ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg9ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg10ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg11ToolStripMenuItem2 = new ToolStripMenuItem();
            renameSelectedPkg12ToolStripMenuItem2 = new ToolStripMenuItem();
            viewPkgChangeInfotoolStripMenuItem2 = new ToolStripMenuItem();
            viewPkgExplorerStripMenuItem2 = new ToolStripMenuItem();
            downloadOfficialUpdateToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator7 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripMenuItem18 = new ToolStripMenuItem();
            RpiCheckPkgInstalledtoolStripMenuItem2 = new ToolStripMenuItem();
            RpiSendPkgtoolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem21 = new ToolStripMenuItem();
            RpiUninstallBasePKGToolStripMenuItem2 = new ToolStripMenuItem();
            RpiUninstallPatchPKGToolStripMenuItem2 = new ToolStripMenuItem();
            RpiUninstallDlcPKGToolStripMenuItem2 = new ToolStripMenuItem();
            RpiUninstallThemePKGToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparatorShadps4 = new DarkUI.Controls.DarkToolStripSeparator();
            sToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemShadps4Launch = new ToolStripMenuItem();
            toolStripMenuItemShadps4Install = new ToolStripMenuItem();
            toolStripMenuItemShadps4Uninstall = new ToolStripMenuItem();
            toolStripMenuItemShadps4OpenManager = new ToolStripMenuItem();
            toolStripMenuItemShadps4InstallSetup = new ToolStripMenuItem();
            toolStripMenuItemShadps4OpenLauncher = new ToolStripMenuItem();
            toolStripMenuItemShadps4Configure = new ToolStripMenuItem();
            toolStripMenuItemShadps4Manager = new ToolStripMenuItem();
            toolStripMenuItemTools = new ToolStripMenuItem();
            openAppDataDirectoryToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem34 = new ToolStripMenuItem();
            toolStripSeparator1 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripSeparator5 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripSeparator6 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripSeparator3 = new DarkUI.Controls.DarkToolStripSeparator();
            label8 = new DarkUI.Controls.DarkLabel();
            darkMenuStrip1 = new DarkUI.Controls.DarkMenuStrip();
            fileToolStripMenuItem2 = new ToolStripMenuItem();
            managePS4PKGToolStripMenuItem = new ToolStripMenuItem();
            settingstoolStripMenuItem = new ToolStripMenuItem();
            loadFromDirectoryToolStripMenuItem = new ToolStripMenuItem();
            loadFromManifestToolStripMenuItem = new ToolStripMenuItem();
            saveManifestToolStripMenuItem = new ToolStripMenuItem();
            emptyListToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator11 = new DarkUI.Controls.DarkToolStripSeparator();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem144 = new ToolStripMenuItem();
            toolStripMenuItem159 = new ToolStripMenuItem();
            toolStripMenuItem160 = new ToolStripMenuItem();
            toolStripMenuItem158 = new ToolStripMenuItem();
            toolStripSeparator12 = new DarkUI.Controls.DarkToolStripSeparator();
            globalActionToolStripMenuItem = new ToolStripMenuItem();
            checkForDuplicatePKGToolStripMenuItem1 = new ToolStripMenuItem();
            globalExportPKGListToExcelToolStripMenuItem1 = new ToolStripMenuItem();
            extractImageAndBackgroundToolStripMenuItem = new ToolStripMenuItem();
            globalExtractImagesAndIconToolStripMenuItem1 = new ToolStripMenuItem();
            globalExtractImageOnlyToolStripMenuItem1 = new ToolStripMenuItem();
            globalExtractIconOnlyToolStripMenuItem1 = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            renameAllPkg1ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg2ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg3ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg4ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg5ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg6ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg7ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg8ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg9ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg10ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg11ToolStripMenuItem1 = new ToolStripMenuItem();
            renameAllPkg12ToolStripMenuItem1 = new ToolStripMenuItem();
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem = new ToolStripMenuItem();
            movePkgTitleToolStripMenuItem1 = new ToolStripMenuItem();
            movePkgCategoryToolStripMenuItem1 = new ToolStripMenuItem();
            movePkgTypeToolStripMenuItem1 = new ToolStripMenuItem();
            movePkgRegionToolStripMenuItem1 = new ToolStripMenuItem();
            movePkgSingleFolderToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator4 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            globalCopyStripMenuItem = new ToolStripMenuItem();
            copyTitleIdtoolStripMenuItem1 = new ToolStripMenuItem();
            copyContentIdtoolStripMenuItem1 = new ToolStripMenuItem();
            copyTitleToolStripMenuItem1 = new ToolStripMenuItem();
            copyFilenameToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            setBackportedtoolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            backportRemarkTextboxtoolStripTextBox1 = new DarkUI.Controls.DarkToolStripTextBox();
            setRemarktoolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator10 = new DarkUI.Controls.DarkToolStripSeparator();
            removeBackportedtoolStripMenuItem1 = new ToolStripMenuItem();
            deletePKGtoolStripMenuItem1 = new ToolStripMenuItem();
            selectedExportPKGListToExcelToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem28 = new ToolStripMenuItem();
            selectedExtractImagesAndIconToolStripMenuItem1 = new ToolStripMenuItem();
            selectedExtractImageOnlyToolStripMenuItem1 = new ToolStripMenuItem();
            selectedExtractIconOnlyToolStripMenuItem1 = new ToolStripMenuItem();
            renameCurrentPKGStripMenuItem = new ToolStripMenuItem();
            renameSelectedPkg1ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg2ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg3ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg4ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg5ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg6ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg7ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg8ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg9ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg10ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg11ToolStripMenuItem1 = new ToolStripMenuItem();
            renameSelectedPkg12ToolStripMenuItem1 = new ToolStripMenuItem();
            viewPkgChangeInfotoolStripMenuItem1 = new ToolStripMenuItem();
            viewPkgExplorerStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator8 = new DarkUI.Controls.DarkToolStripSeparator();
            downloadOfficialUpdateToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem16 = new ToolStripMenuItem();
            RpiCheckPkgInstalledtoolStripMenuItem1 = new ToolStripMenuItem();
            RpiSendPkgtoolStripMenuItem1 = new ToolStripMenuItem();
            uninstallPKGFromPS4ToolStripMenuItem = new ToolStripMenuItem();
            RpiUninstallBasePKGToolStripMenuItem1 = new ToolStripMenuItem();
            RpiUninstallPatchPKGToolStripMenuItem1 = new ToolStripMenuItem();
            RpiUninstallDlcPKGToolStripMenuItem1 = new ToolStripMenuItem();
            RpiUninstallThemePKGToolStripMenuItem1 = new ToolStripMenuItem();
            darkStatusStrip1 = new DarkUI.Controls.DarkStatusStrip();
            toolStripStatusLabel1 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel3 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel5 = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripSeparator13 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripProgressBar1 = new DarkUI.Controls.DarkToolStripProgressBar();
            toolStripSeparator14 = new DarkUI.Controls.DarkToolStripSeparator();
            toolStripStatusLabel2 = new DarkUI.Controls.DarkToolStripStatusLabel();
            labelDisplayTotalPKG = new DarkUI.Controls.DarkToolStripStatusLabel();
            toolStripStatusLabel4 = new DarkUI.Controls.DarkToolStripStatusLabel();
            contextMenuTrophy = new DarkUI.Controls.DarkContextMenu();
            ExtractTrophyImageToolStripMenuItem = new ToolStripMenuItem();
            contextMenuEntry = new DarkUI.Controls.DarkContextMenu();
            ExtractAllEntryToolStripMenuItem = new ToolStripMenuItem();
            ExtractDecryptedEntryToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            contextMenuOfficialUpdate = new DarkUI.Controls.DarkContextMenu();
            copyURLToolStripMenuItem = new ToolStripMenuItem();
            downloadSelectedPKGUpdateToolStripMenuItem = new ToolStripMenuItem();
            contextMenuBackgroundImage = new DarkUI.Controls.DarkContextMenu();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            SetImageAsDesktopBackgroundToolStripMenuItem = new ToolStripMenuItem();
            contextMenuExtractNode = new DarkUI.Controls.DarkContextMenu();
            ctxExpandNode = new ToolStripMenuItem();
            ctxCollapseNode = new ToolStripMenuItem();
            ctxTreeSeparator = new DarkUI.Controls.DarkToolStripSeparator();
            expandAllToolStripMenuItem = new ToolStripMenuItem();
            collapseAllNodeToolStripMenuItem = new ToolStripMenuItem();
            extractNodeToolStripMenuItem = new ToolStripMenuItem();
            columnHeader1 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            darkSectionPanel7 = new DarkUI.Controls.DarkSectionPanel();
            contextMenuExtractListView = new DarkUI.Controls.DarkContextMenu();
            toolStripMenuItem32 = new ToolStripMenuItem();
            ctxExtractFolder = new ToolStripMenuItem();
            ctxListSeparator = new DarkUI.Controls.DarkToolStripSeparator();
            ctxCopyPath = new ToolStripMenuItem();
            ctxCopyName = new ToolStripMenuItem();
            mainTabControl = new DarkUI.Controls.DarkTabControl();
            tabPage1 = new DarkUI.Controls.DarkTabPage();
            darkSectionPanel10 = new DarkUI.Controls.DarkSectionPanel();
            darkDataGridView2 = new DarkUI.Controls.DarkDataGridView();
            grpFilter = new DarkUI.Controls.DarkGroupBox();
            flpFilter = new FlowLayoutPanel();
            lblCategory = new DarkUI.Controls.DarkLabel();
            ccbCategory = new DarkUI.Controls.DarkCheckedComboBox(components);
            lblRegion = new DarkUI.Controls.DarkLabel();
            ccbRegion = new DarkUI.Controls.DarkCheckedComboBox(components);
            lblFilterSysVer = new DarkUI.Controls.DarkLabel();
            tbFilterSysVer = new DarkUI.Controls.DarkTextBox();
            lblType = new DarkUI.Controls.DarkLabel();
            ccbType = new DarkUI.Controls.DarkCheckedComboBox(components);
            lblShadps4 = new DarkUI.Controls.DarkLabel();
            ccbShadps4 = new DarkUI.Controls.DarkCheckedComboBox(components);
            chkShadps4Installed = new DarkUI.Controls.DarkCheckBox();
            tbSearchGame = new DarkUI.Controls.DarkSearchBox();
            btnFilterClear = new DarkUI.Controls.DarkButton();
            flowChips = new DarkUI.Controls.DarkChipsPanel(components);
            lblFilterCount = new DarkUI.Controls.DarkLabel();
            subTabControl = new DarkUI.Controls.DarkTabControl();
            tabPageTable = new DarkUI.Controls.DarkTabPage();
            PKGGridView = new DarkUI.Controls.DarkDataGridView();
            tabPageGroup = new DarkUI.Controls.DarkTabPage();
            groupedListView = new DarkUI.Controls.DarkGroupedListView();
            contextMenuGLV = new DarkUI.Controls.DarkContextMenu();
            btnGroupExpand = new DarkUI.Controls.DarkButton();
            cbGroupBy = new DarkUI.Controls.DarkComboBox();
            darkLabelGroupBy = new DarkUI.Controls.DarkLabel();
            darkLabelGroupCount = new DarkUI.Controls.DarkLabel();
            lblGlvFilterHint = new DarkUI.Controls.DarkLabel();
            darkSectionPanel8 = new DarkUI.Controls.DarkSectionPanel();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new DarkUI.Controls.DarkLabel();
            darkSectionPanel9 = new DarkUI.Controls.DarkSectionPanel();
            panel1 = new Panel();
            darkLabel1 = new DarkUI.Controls.DarkLabel();
            tabPage2 = new DarkUI.Controls.DarkTabPage();
            TrophyGridView = new DarkUI.Controls.DarkDataGridView();
            tabPage3 = new DarkUI.Controls.DarkTabPage();
            flatTabControlBgi = new DarkUI.Controls.DarkTabControl();
            tabPagePic0 = new DarkUI.Controls.DarkTabPage();
            pbPIC0 = new PictureBox();
            tabPagePic1 = new DarkUI.Controls.DarkTabPage();
            pbPIC1 = new PictureBox();
            tabPage4 = new DarkUI.Controls.DarkTabPage();
            panel7 = new Panel();
            darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            dgvEntryList = new DarkUI.Controls.DarkDataGridView();
            darkSectionPanel3 = new DarkUI.Controls.DarkSectionPanel();
            darkDataGridView4 = new DarkUI.Controls.DarkDataGridView();
            darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            dgvHeader = new DarkUI.Controls.DarkDataGridView();
            tabPage7 = new DarkUI.Controls.DarkTabPage();
            panel6 = new Panel();
            darkSplitContainer1 = new DarkUI.Controls.DarkSplitContainer();
            splitPane1 = new DarkUI.Controls.DarkSplitPane();
            PKGTreeView = new DarkUI.Controls.DarkTreeView();
            splitPane2 = new DarkUI.Controls.DarkSplitPane();
            listView1 = new DarkUI.Controls.DarkListView();
            tbFilterTreeView = new DarkUI.Controls.DarkSearchBox();
            splitPane3 = new DarkUI.Controls.DarkSplitPane();
            sectionFileViewer = new DarkUI.Controls.DarkSectionPanel();
            btnAssetBack = new DarkUI.Controls.DarkButton();
            fileViewerBody = new Panel();
            assetListView = new DarkUI.Controls.DarkListView();
            picPreview = new PictureBox();
            txtPreview = new DarkUI.Controls.DarkTextBox();
            txtHexPreview = new DarkUI.Controls.DarkTextBox();
            lblFileViewerInfo = new DarkUI.Controls.DarkLabel();
            darkHeaderBar1 = new DarkUI.Controls.DarkHeaderBar();
            darkLabel5 = new DarkUI.Controls.DarkLabel();
            btnExportTextures = new DarkUI.Controls.DarkButton();
            tbPasscode = new DarkUI.Controls.DarkTextBox();
            btnExportTreeView = new DarkUI.Controls.DarkButton();
            btnExtractFullPKG = new DarkUI.Controls.DarkButton();
            btnViewPKGData = new DarkUI.Controls.DarkButton();
            _tabLog = new DarkUI.Controls.DarkTabPage();
            _tbLogBox = new DarkUI.Controls.DarkTextBox();
            _tasksTab = new DarkUI.Controls.DarkTabPage();
            _tasksGrid = new DarkUI.Controls.DarkDataGridView();
            taskTypeColumn = new DataGridViewTextBoxColumn();
            taskNameColumn = new DataGridViewTextBoxColumn();
            taskStatusColumn = new DataGridViewTextBoxColumn();
            taskProgressColumn = new DataGridViewTextBoxColumn();
            taskDetailsLayout = new DarkUI.Controls.DarkTableLayoutPanel();
            _taskStageLabel = new DarkUI.Controls.DarkLabel();
            _taskProgressLabel = new DarkUI.Controls.DarkLabel();
            _taskCurrentProgress = new DarkUI.Controls.DarkProgressBar();
            _taskDetailLabel = new DarkUI.Controls.DarkLabel();
            _taskOverallLabel = new DarkUI.Controls.DarkLabel();
            _taskOverallProgress = new DarkUI.Controls.DarkProgressBar();
            taskActionsPanel = new DarkUI.Controls.DarkChipsPanel(components);
            _taskCancel = new DarkUI.Controls.DarkButton();
            _taskRetry = new DarkUI.Controls.DarkButton();
            _taskOpenOutput = new DarkUI.Controls.DarkButton();
            _taskRemove = new DarkUI.Controls.DarkButton();
            tasksToolbar = new DarkUI.Controls.DarkFooterBar();
            _taskAutoStart = new DarkUI.Controls.DarkCheckBox();
            _taskStartNext = new DarkUI.Controls.DarkButton();
            _taskClearFinished = new DarkUI.Controls.DarkButton();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            assetNameColumn = new ColumnHeader();
            assetTypeColumn = new ColumnHeader();
            assetSizeColumn = new ColumnHeader();
            tabPage5 = new DarkUI.Controls.DarkTabPage();
            darkSectionPanel11 = new DarkUI.Controls.DarkSectionPanel();
            dgvUpdate = new DarkUI.Controls.DarkDataGridView();
            lblUpdateInfo = new DarkUI.Controls.DarkLabel();
            lblVersion = new DarkUI.Controls.DarkLabel();
            lblSysVer = new DarkUI.Controls.DarkLabel();
            lblUpdType = new DarkUI.Controls.DarkLabel();
            lblMand = new DarkUI.Controls.DarkLabel();
            lblRemaster = new DarkUI.Controls.DarkLabel();
            lblFiles = new DarkUI.Controls.DarkLabel();
            lblSize = new DarkUI.Controls.DarkLabel();
            panel8 = new Panel();
            darkSectionPanel12 = new DarkUI.Controls.DarkSectionPanel();
            label13 = new DarkUI.Controls.DarkLabel();
            label14 = new DarkUI.Controls.DarkLabel();
            label15 = new DarkUI.Controls.DarkLabel();
            label16 = new DarkUI.Controls.DarkLabel();
            label17 = new DarkUI.Controls.DarkLabel();
            label18 = new DarkUI.Controls.DarkLabel();
            label19 = new DarkUI.Controls.DarkLabel();
            labelRemaster = new DarkUI.Controls.DarkLabel();
            label21 = new DarkUI.Controls.DarkLabel();
            labelUpdateType = new DarkUI.Controls.DarkLabel();
            labelMandatory = new DarkUI.Controls.DarkLabel();
            labelPKGdigest = new DarkUI.Controls.DarkLabel();
            label5 = new DarkUI.Controls.DarkLabel();
            label12 = new DarkUI.Controls.DarkLabel();
            label9 = new DarkUI.Controls.DarkLabel();
            label11 = new DarkUI.Controls.DarkLabel();
            label4 = new DarkUI.Controls.DarkLabel();
            label10 = new DarkUI.Controls.DarkLabel();
            label7 = new DarkUI.Controls.DarkLabel();
            labelSystemReq = new DarkUI.Controls.DarkLabel();
            label6 = new DarkUI.Controls.DarkLabel();
            labelUpdateVersion = new DarkUI.Controls.DarkLabel();
            labelTotalSize = new DarkUI.Controls.DarkLabel();
            labelTotalFile = new DarkUI.Controls.DarkLabel();
            contextMenuPKGGridView.SuspendLayout();
            darkMenuStrip1.SuspendLayout();
            darkStatusStrip1.SuspendLayout();
            contextMenuTrophy.SuspendLayout();
            contextMenuEntry.SuspendLayout();
            contextMenuOfficialUpdate.SuspendLayout();
            contextMenuBackgroundImage.SuspendLayout();
            contextMenuExtractNode.SuspendLayout();
            contextMenuExtractListView.SuspendLayout();
            mainTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            darkSectionPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)darkDataGridView2).BeginInit();
            grpFilter.SuspendLayout();
            flpFilter.SuspendLayout();
            subTabControl.SuspendLayout();
            tabPageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PKGGridView).BeginInit();
            tabPageGroup.SuspendLayout();
            darkSectionPanel8.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            darkSectionPanel9.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrophyGridView).BeginInit();
            tabPage3.SuspendLayout();
            flatTabControlBgi.SuspendLayout();
            tabPagePic0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPIC0).BeginInit();
            tabPagePic1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPIC1).BeginInit();
            tabPage4.SuspendLayout();
            panel7.SuspendLayout();
            darkSectionPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntryList).BeginInit();
            darkSectionPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)darkDataGridView4).BeginInit();
            darkSectionPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHeader).BeginInit();
            tabPage7.SuspendLayout();
            panel6.SuspendLayout();
            darkSplitContainer1.SuspendLayout();
            splitPane1.SuspendLayout();
            splitPane2.SuspendLayout();
            splitPane3.SuspendLayout();
            sectionFileViewer.SuspendLayout();
            fileViewerBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            darkHeaderBar1.SuspendLayout();
            _tabLog.SuspendLayout();
            _tasksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGrid).BeginInit();
            taskDetailsLayout.SuspendLayout();
            taskActionsPanel.SuspendLayout();
            tasksToolbar.SuspendLayout();
            tabPage5.SuspendLayout();
            darkSectionPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpdate).BeginInit();
            SuspendLayout();
            // 
            // _groupedViewRefreshTimer
            // 
            _groupedViewRefreshTimer.Interval = 140;
            _groupedViewRefreshTimer.Tick += GroupedViewRefreshTimer_Tick;
            // 
            // _logFlushTimer
            // 
            _logFlushTimer.Tick += LogFlushTimer_Tick;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            label2.Location = new System.Drawing.Point(154, 471);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(0, 14);
            label2.TabIndex = 39;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openGameFolderToolStripMenuItem, refreshContentToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openGameFolderToolStripMenuItem
            // 
            openGameFolderToolStripMenuItem.Name = "openGameFolderToolStripMenuItem";
            openGameFolderToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // refreshContentToolStripMenuItem
            // 
            refreshContentToolStripMenuItem.Name = "refreshContentToolStripMenuItem";
            refreshContentToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gameToolStripMenuItem, viewTrophyListToolStripMenuItem, exportPKGListToExcelToolStripMenuItem });
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            toolToolStripMenuItem.Text = "Tool";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { renamePKGToTITLEToolStripMenuItem, renameToTITLEIDToolStripMenuItem, renameToCONTENTIDToolStripMenuItem, renamePKGToTITLETITLEIDToolStripMenuItem, renamePKGToTITLEToolStripMenuItem1, renamePKGToTITLECATEGORYToolStripMenuItem });
            gameToolStripMenuItem.Enabled = false;
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            gameToolStripMenuItem.Text = "Rename PKG";
            // 
            // renamePKGToTITLEToolStripMenuItem
            // 
            renamePKGToTITLEToolStripMenuItem.Name = "renamePKGToTITLEToolStripMenuItem";
            renamePKGToTITLEToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // renameToTITLEIDToolStripMenuItem
            // 
            renameToTITLEIDToolStripMenuItem.Name = "renameToTITLEIDToolStripMenuItem";
            renameToTITLEIDToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // renameToCONTENTIDToolStripMenuItem
            // 
            renameToCONTENTIDToolStripMenuItem.Name = "renameToCONTENTIDToolStripMenuItem";
            renameToCONTENTIDToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // renamePKGToTITLETITLEIDToolStripMenuItem
            // 
            renamePKGToTITLETITLEIDToolStripMenuItem.Name = "renamePKGToTITLETITLEIDToolStripMenuItem";
            renamePKGToTITLETITLEIDToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // renamePKGToTITLEToolStripMenuItem1
            // 
            renamePKGToTITLEToolStripMenuItem1.Name = "renamePKGToTITLEToolStripMenuItem1";
            renamePKGToTITLEToolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // renamePKGToTITLECATEGORYToolStripMenuItem
            // 
            renamePKGToTITLECATEGORYToolStripMenuItem.Name = "renamePKGToTITLECATEGORYToolStripMenuItem";
            renamePKGToTITLECATEGORYToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // viewTrophyListToolStripMenuItem
            // 
            viewTrophyListToolStripMenuItem.Name = "viewTrophyListToolStripMenuItem";
            viewTrophyListToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            // 
            // exportPKGListToExcelToolStripMenuItem
            // 
            exportPKGListToExcelToolStripMenuItem.Name = "exportPKGListToExcelToolStripMenuItem";
            exportPKGListToExcelToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // donateToolStripMenuItem
            // 
            donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            donateToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // contextMenuPKGGridView
            // 
            contextMenuPKGGridView.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuPKGGridView.Items.AddRange(new ToolStripItem[] { toolStripMenuItem94, checkForDuplicatePKGToolStripMenuItem2, checkForPatchesMissingBasePKGToolStripMenuItem2, globalExportPKGListToExcelToolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem111, toolStripMenuItem38, toolStripSeparator2, GroupActionTitleStripMenuItem, toolStripMenuItem127, backportToolStripMenuItem, deletePkgtoolStripMenuItem2, selectedExportPKGListToExcelToolStripMenuItem2, mergeSelectedBaseAndUpdateToolStripMenuItem, convertSelectedToFfpfscToolStripMenuItem, extractSelectedFullPkgToolStripMenuItem, GroupActionExtacrtImageToolStripMenuItem, toolStripMenuItem133, viewPkgChangeInfotoolStripMenuItem2, viewPkgExplorerStripMenuItem2, downloadOfficialUpdateToolStripMenuItem2, toolStripSeparator7, toolStripMenuItem18, RpiCheckPkgInstalledtoolStripMenuItem2, RpiSendPkgtoolStripMenuItem2, toolStripMenuItem21, toolStripSeparatorShadps4, sToolStripMenuItem, toolStripMenuItemShadps4Launch, toolStripMenuItemShadps4Install, toolStripMenuItemShadps4Uninstall, toolStripMenuItemShadps4OpenManager });
            contextMenuPKGGridView.Name = "DarkContextMenuStrip1";
            contextMenuPKGGridView.Size = new System.Drawing.Size(306, 641);
            contextMenuPKGGridView.Opening += contextMenuPKGGridView_Opening;
            // 
            // toolStripMenuItem94
            // 
            toolStripMenuItem94.Enabled = false;
            toolStripMenuItem94.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStripMenuItem94.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem94.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem94.Name = "toolStripMenuItem94";
            toolStripMenuItem94.ShowShortcutKeys = false;
            toolStripMenuItem94.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem94.Text = "Global Action";
            // 
            // checkForDuplicatePKGToolStripMenuItem2
            // 
            checkForDuplicatePKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            checkForDuplicatePKGToolStripMenuItem2.Name = "checkForDuplicatePKGToolStripMenuItem2";
            checkForDuplicatePKGToolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            checkForDuplicatePKGToolStripMenuItem2.Text = "Check for duplicate PKG";
            checkForDuplicatePKGToolStripMenuItem2.Click += CheckForDuplicatePKG_Click;
            // 
            // checkForPatchesMissingBasePKGToolStripMenuItem2
            // 
            checkForPatchesMissingBasePKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            checkForPatchesMissingBasePKGToolStripMenuItem2.Name = "checkForPatchesMissingBasePKGToolStripMenuItem2";
            checkForPatchesMissingBasePKGToolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            checkForPatchesMissingBasePKGToolStripMenuItem2.Text = "Check patches missing base PKG";
            checkForPatchesMissingBasePKGToolStripMenuItem2.Click += CheckForPatchesMissingBasePKG_Click;
            // 
            // globalExportPKGListToExcelToolStripMenuItem2
            // 
            globalExportPKGListToExcelToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExportPKGListToExcelToolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            globalExportPKGListToExcelToolStripMenuItem2.Name = "globalExportPKGListToExcelToolStripMenuItem2";
            globalExportPKGListToExcelToolStripMenuItem2.ShowShortcutKeys = false;
            globalExportPKGListToExcelToolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            globalExportPKGListToExcelToolStripMenuItem2.Text = "Export PKG list as excel file";
            globalExportPKGListToExcelToolStripMenuItem2.Click += ExportPKGToExcel_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { globalExtractImagesAndIconToolStripMenuItem2, globalExtractImageOnlyToolStripMenuItem2, globalExtractIconOnlyToolStripMenuItem2 });
            toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem3.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.ShowShortcutKeys = false;
            toolStripMenuItem3.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem3.Text = "Save artwork";
            // 
            // globalExtractImagesAndIconToolStripMenuItem2
            // 
            globalExtractImagesAndIconToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractImagesAndIconToolStripMenuItem2.Name = "globalExtractImagesAndIconToolStripMenuItem2";
            globalExtractImagesAndIconToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            globalExtractImagesAndIconToolStripMenuItem2.Text = "Backgrounds + Icon";
            globalExtractImagesAndIconToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // globalExtractImageOnlyToolStripMenuItem2
            // 
            globalExtractImageOnlyToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractImageOnlyToolStripMenuItem2.Name = "globalExtractImageOnlyToolStripMenuItem2";
            globalExtractImageOnlyToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            globalExtractImageOnlyToolStripMenuItem2.Text = "Backgrounds only";
            globalExtractImageOnlyToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // globalExtractIconOnlyToolStripMenuItem2
            // 
            globalExtractIconOnlyToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractIconOnlyToolStripMenuItem2.Name = "globalExtractIconOnlyToolStripMenuItem2";
            globalExtractIconOnlyToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            globalExtractIconOnlyToolStripMenuItem2.Text = "Icon only";
            globalExtractIconOnlyToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // toolStripMenuItem111
            // 
            toolStripMenuItem111.DropDownItems.AddRange(new ToolStripItem[] { renameAllPkg1ToolStripMenuItem2, renameAllPkg2ToolStripMenuItem2, renameAllPkg3ToolStripMenuItem2, renameAllPkg4ToolStripMenuItem2, renameAllPkg5ToolStripMenuItem2, renameAllPkg6ToolStripMenuItem2, renameAllPkg7ToolStripMenuItem2, renameAllPkg8ToolStripMenuItem2, renameAllPkg9ToolStripMenuItem2, renameAllPkg10ToolStripMenuItem2, renameAllPkg11ToolStripMenuItem2, renameAllPkg12ToolStripMenuItem2 });
            toolStripMenuItem111.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem111.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem111.Name = "toolStripMenuItem111";
            toolStripMenuItem111.ShowShortcutKeys = false;
            toolStripMenuItem111.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem111.Text = "Rename all PKG";
            // 
            // renameAllPkg1ToolStripMenuItem2
            // 
            renameAllPkg1ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg1ToolStripMenuItem2.Name = "renameAllPkg1ToolStripMenuItem2";
            renameAllPkg1ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg1ToolStripMenuItem2.Text = "TITILE";
            renameAllPkg1ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg2ToolStripMenuItem2
            // 
            renameAllPkg2ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg2ToolStripMenuItem2.Name = "renameAllPkg2ToolStripMenuItem2";
            renameAllPkg2ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg2ToolStripMenuItem2.Text = "TITLE [TITLE_ID]";
            renameAllPkg2ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg3ToolStripMenuItem2
            // 
            renameAllPkg3ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg3ToolStripMenuItem2.Name = "renameAllPkg3ToolStripMenuItem2";
            renameAllPkg3ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg3ToolStripMenuItem2.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            renameAllPkg3ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg4ToolStripMenuItem2
            // 
            renameAllPkg4ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg4ToolStripMenuItem2.Name = "renameAllPkg4ToolStripMenuItem2";
            renameAllPkg4ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg4ToolStripMenuItem2.Text = "TITLE [CATEGORY]";
            renameAllPkg4ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg5ToolStripMenuItem2
            // 
            renameAllPkg5ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg5ToolStripMenuItem2.Name = "renameAllPkg5ToolStripMenuItem2";
            renameAllPkg5ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg5ToolStripMenuItem2.Text = "TITLE_ID";
            renameAllPkg5ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg6ToolStripMenuItem2
            // 
            renameAllPkg6ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg6ToolStripMenuItem2.Name = "renameAllPkg6ToolStripMenuItem2";
            renameAllPkg6ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg6ToolStripMenuItem2.Text = "TITLE_ID [TITLE]";
            renameAllPkg6ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg7ToolStripMenuItem2
            // 
            renameAllPkg7ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg7ToolStripMenuItem2.Name = "renameAllPkg7ToolStripMenuItem2";
            renameAllPkg7ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg7ToolStripMenuItem2.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            renameAllPkg7ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg8ToolStripMenuItem2
            // 
            renameAllPkg8ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg8ToolStripMenuItem2.Name = "renameAllPkg8ToolStripMenuItem2";
            renameAllPkg8ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg8ToolStripMenuItem2.Text = "TITLE [CATEGORY] [APP_VERSION]";
            renameAllPkg8ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg9ToolStripMenuItem2
            // 
            renameAllPkg9ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg9ToolStripMenuItem2.Name = "renameAllPkg9ToolStripMenuItem2";
            renameAllPkg9ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg9ToolStripMenuItem2.Text = "CONTENT_ID";
            renameAllPkg9ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg10ToolStripMenuItem2
            // 
            renameAllPkg10ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg10ToolStripMenuItem2.Name = "renameAllPkg10ToolStripMenuItem2";
            renameAllPkg10ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg10ToolStripMenuItem2.Text = "CONTENT_ID 2";
            renameAllPkg10ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg11ToolStripMenuItem2
            // 
            renameAllPkg11ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg11ToolStripMenuItem2.Name = "renameAllPkg11ToolStripMenuItem2";
            renameAllPkg11ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg11ToolStripMenuItem2.Text = "CUSTOM NAME";
            renameAllPkg11ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameAllPkg12ToolStripMenuItem2
            // 
            renameAllPkg12ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg12ToolStripMenuItem2.Name = "renameAllPkg12ToolStripMenuItem2";
            renameAllPkg12ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameAllPkg12ToolStripMenuItem2.Text = "RENAME BY INSTALL PRIORITY";
            renameAllPkg12ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // toolStripMenuItem38
            // 
            toolStripMenuItem38.DropDownItems.AddRange(new ToolStripItem[] { movePkgTitleToolStripMenuItem2, moveByPkgTitleIdToolStripMenuItem, movePkgTypeToolStripMenuItem2, movePkgCategoryToolStripMenuItem2, movePkgRegionToolStripMenuItem2, movePkgSingleFolderToolStripMenuItem2 });
            toolStripMenuItem38.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem38.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem38.Name = "toolStripMenuItem38";
            toolStripMenuItem38.ShowShortcutKeys = false;
            toolStripMenuItem38.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem38.Text = "Move PKG";
            // 
            // movePkgTitleToolStripMenuItem2
            // 
            movePkgTitleToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgTitleToolStripMenuItem2.Name = "movePkgTitleToolStripMenuItem2";
            movePkgTitleToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            movePkgTitleToolStripMenuItem2.Text = "Move by PKG Title";
            movePkgTitleToolStripMenuItem2.Click += MovePkg_Click;
            // 
            // moveByPkgTitleIdToolStripMenuItem
            // 
            moveByPkgTitleIdToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            moveByPkgTitleIdToolStripMenuItem.Name = "moveByPkgTitleIdToolStripMenuItem";
            moveByPkgTitleIdToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            moveByPkgTitleIdToolStripMenuItem.Text = "Move by PKG Title Id";
            moveByPkgTitleIdToolStripMenuItem.Click += MovePkg_Click;
            // 
            // movePkgTypeToolStripMenuItem2
            // 
            movePkgTypeToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgTypeToolStripMenuItem2.Name = "movePkgTypeToolStripMenuItem2";
            movePkgTypeToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            movePkgTypeToolStripMenuItem2.Text = "Move by PKG Category (Base/Update/Addon)";
            movePkgTypeToolStripMenuItem2.Click += MovePkg_Click;
            // 
            // movePkgCategoryToolStripMenuItem2
            // 
            movePkgCategoryToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgCategoryToolStripMenuItem2.Name = "movePkgCategoryToolStripMenuItem2";
            movePkgCategoryToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            movePkgCategoryToolStripMenuItem2.Text = "Move by PKG Type (Fake/Official)";
            movePkgCategoryToolStripMenuItem2.Click += MovePkg_Click;
            // 
            // movePkgRegionToolStripMenuItem2
            // 
            movePkgRegionToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgRegionToolStripMenuItem2.Name = "movePkgRegionToolStripMenuItem2";
            movePkgRegionToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            movePkgRegionToolStripMenuItem2.Text = "Move by PKG Region";
            movePkgRegionToolStripMenuItem2.Click += MovePkg_Click;
            // 
            // movePkgSingleFolderToolStripMenuItem2
            // 
            movePkgSingleFolderToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgSingleFolderToolStripMenuItem2.Name = "movePkgSingleFolderToolStripMenuItem2";
            movePkgSingleFolderToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            movePkgSingleFolderToolStripMenuItem2.Text = "Move all to single folder";
            movePkgSingleFolderToolStripMenuItem2.Click += MovePkg_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator2.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(302, 6);
            // 
            // GroupActionTitleStripMenuItem
            // 
            GroupActionTitleStripMenuItem.Enabled = false;
            GroupActionTitleStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            GroupActionTitleStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            GroupActionTitleStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            GroupActionTitleStripMenuItem.Name = "GroupActionTitleStripMenuItem";
            GroupActionTitleStripMenuItem.ShowShortcutKeys = false;
            GroupActionTitleStripMenuItem.Size = new System.Drawing.Size(305, 22);
            GroupActionTitleStripMenuItem.Text = "...";
            // 
            // toolStripMenuItem127
            // 
            toolStripMenuItem127.DropDownItems.AddRange(new ToolStripItem[] { copyTitleIdtoolStripMenuItem2, copyContentIdtoolStripMenuItem2, copyTitleToolStripMenuItem2, copyFilenameToolStripMenuItem2 });
            toolStripMenuItem127.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem127.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem127.Name = "toolStripMenuItem127";
            toolStripMenuItem127.ShowShortcutKeys = false;
            toolStripMenuItem127.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem127.Text = "Copy";
            // 
            // copyTitleIdtoolStripMenuItem2
            // 
            copyTitleIdtoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyTitleIdtoolStripMenuItem2.Name = "copyTitleIdtoolStripMenuItem2";
            copyTitleIdtoolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            copyTitleIdtoolStripMenuItem2.Text = "TITLE_ID";
            copyTitleIdtoolStripMenuItem2.Click += CopyID_Click;
            // 
            // copyContentIdtoolStripMenuItem2
            // 
            copyContentIdtoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyContentIdtoolStripMenuItem2.Name = "copyContentIdtoolStripMenuItem2";
            copyContentIdtoolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            copyContentIdtoolStripMenuItem2.Text = "CONTENT_ID";
            copyContentIdtoolStripMenuItem2.Click += CopyID_Click;
            // 
            // copyTitleToolStripMenuItem2
            // 
            copyTitleToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyTitleToolStripMenuItem2.Name = "copyTitleToolStripMenuItem2";
            copyTitleToolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            copyTitleToolStripMenuItem2.Text = "TITLE";
            copyTitleToolStripMenuItem2.Click += CopyID_Click;
            // 
            // copyFilenameToolStripMenuItem2
            // 
            copyFilenameToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyFilenameToolStripMenuItem2.Name = "copyFilenameToolStripMenuItem2";
            copyFilenameToolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            copyFilenameToolStripMenuItem2.Text = "Filename";
            copyFilenameToolStripMenuItem2.Click += CopyID_Click;
            // 
            // backportToolStripMenuItem
            // 
            backportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setBackportedToolStripMenuItem2, setBackportRemarksToolStripMenuItem, toolStripSeparator9, removeBackportedToolStripMenuItem2 });
            backportToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            backportToolStripMenuItem.Name = "backportToolStripMenuItem";
            backportToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            backportToolStripMenuItem.Text = "Backport";
            // 
            // setBackportedToolStripMenuItem2
            // 
            setBackportedToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            setBackportedToolStripMenuItem2.Name = "setBackportedToolStripMenuItem2";
            setBackportedToolStripMenuItem2.Size = new System.Drawing.Size(208, 22);
            setBackportedToolStripMenuItem2.Text = "Set as backported";
            setBackportedToolStripMenuItem2.Click += Backport_Click;
            // 
            // setBackportRemarksToolStripMenuItem
            // 
            setBackportRemarksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backportRemarkTextboxtoolStripTextBox2, setRemarktoolStripMenuItem2 });
            setBackportRemarksToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            setBackportRemarksToolStripMenuItem.Name = "setBackportRemarksToolStripMenuItem";
            setBackportRemarksToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            setBackportRemarksToolStripMenuItem.Text = "Set backport remarks";
            // 
            // backportRemarkTextboxtoolStripTextBox2
            // 
            backportRemarkTextboxtoolStripTextBox2.Name = "backportRemarkTextboxtoolStripTextBox2";
            backportRemarkTextboxtoolStripTextBox2.Size = new System.Drawing.Size(180, 23);
            // 
            // setRemarktoolStripMenuItem2
            // 
            setRemarktoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            setRemarktoolStripMenuItem2.Name = "setRemarktoolStripMenuItem2";
            setRemarktoolStripMenuItem2.Size = new System.Drawing.Size(240, 22);
            setRemarktoolStripMenuItem2.Text = "Set remarks";
            setRemarktoolStripMenuItem2.Click += Backport_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator9.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(205, 6);
            // 
            // removeBackportedToolStripMenuItem2
            // 
            removeBackportedToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            removeBackportedToolStripMenuItem2.Name = "removeBackportedToolStripMenuItem2";
            removeBackportedToolStripMenuItem2.Size = new System.Drawing.Size(208, 22);
            removeBackportedToolStripMenuItem2.Text = "Remove backported label";
            removeBackportedToolStripMenuItem2.Click += Backport_Click;
            // 
            // deletePkgtoolStripMenuItem2
            // 
            deletePkgtoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            deletePkgtoolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            deletePkgtoolStripMenuItem2.Name = "deletePkgtoolStripMenuItem2";
            deletePkgtoolStripMenuItem2.ShowShortcutKeys = false;
            deletePkgtoolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            deletePkgtoolStripMenuItem2.Text = "Delete PKG";
            deletePkgtoolStripMenuItem2.Click += DeletePKG_Click;
            // 
            // selectedExportPKGListToExcelToolStripMenuItem2
            // 
            selectedExportPKGListToExcelToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExportPKGListToExcelToolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            selectedExportPKGListToExcelToolStripMenuItem2.Name = "selectedExportPKGListToExcelToolStripMenuItem2";
            selectedExportPKGListToExcelToolStripMenuItem2.ShowShortcutKeys = false;
            selectedExportPKGListToExcelToolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            selectedExportPKGListToExcelToolStripMenuItem2.Text = "Export as excel file";
            selectedExportPKGListToExcelToolStripMenuItem2.Click += ExportPKGToExcel_Click;
            // 
            // mergeSelectedBaseAndUpdateToolStripMenuItem
            // 
            mergeSelectedBaseAndUpdateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            mergeSelectedBaseAndUpdateToolStripMenuItem.Name = "mergeSelectedBaseAndUpdateToolStripMenuItem";
            mergeSelectedBaseAndUpdateToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            mergeSelectedBaseAndUpdateToolStripMenuItem.Text = "Merge selected base + update";
            mergeSelectedBaseAndUpdateToolStripMenuItem.Click += MergeSelectedBaseAndUpdate_Click;
            // 
            // convertSelectedToFfpfscToolStripMenuItem
            // 
            convertSelectedToFfpfscToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            convertSelectedToFfpfscToolStripMenuItem.Name = "convertSelectedToFfpfscToolStripMenuItem";
            convertSelectedToFfpfscToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            convertSelectedToFfpfscToolStripMenuItem.Text = "Convert to FFPFSC (PS5 ShadowMountPlus)";
            convertSelectedToFfpfscToolStripMenuItem.Click += ConvertSelectedToFfpfsc_Click;
            // 
            // extractSelectedFullPkgToolStripMenuItem
            // 
            extractSelectedFullPkgToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            extractSelectedFullPkgToolStripMenuItem.Name = "extractSelectedFullPkgToolStripMenuItem";
            extractSelectedFullPkgToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            extractSelectedFullPkgToolStripMenuItem.Text = "Extract Full PKG";
            extractSelectedFullPkgToolStripMenuItem.Click += ExtractSelectedFullPkg_Click;
            // 
            // GroupActionExtacrtImageToolStripMenuItem
            // 
            GroupActionExtacrtImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectedExtractImagesAndIconToolStripMenuItem2, selectedExtractImageOnlyToolStripMenuItem2, selectedExtractIconOnlyToolStripMenuItem2 });
            GroupActionExtacrtImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            GroupActionExtacrtImageToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            GroupActionExtacrtImageToolStripMenuItem.Name = "GroupActionExtacrtImageToolStripMenuItem";
            GroupActionExtacrtImageToolStripMenuItem.ShowShortcutKeys = false;
            GroupActionExtacrtImageToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            GroupActionExtacrtImageToolStripMenuItem.Text = "Save artwork";
            // 
            // selectedExtractImagesAndIconToolStripMenuItem2
            // 
            selectedExtractImagesAndIconToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractImagesAndIconToolStripMenuItem2.Name = "selectedExtractImagesAndIconToolStripMenuItem2";
            selectedExtractImagesAndIconToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            selectedExtractImagesAndIconToolStripMenuItem2.Text = "Backgrounds + Icon";
            selectedExtractImagesAndIconToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // selectedExtractImageOnlyToolStripMenuItem2
            // 
            selectedExtractImageOnlyToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractImageOnlyToolStripMenuItem2.Name = "selectedExtractImageOnlyToolStripMenuItem2";
            selectedExtractImageOnlyToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            selectedExtractImageOnlyToolStripMenuItem2.Text = "Backgrounds only";
            selectedExtractImageOnlyToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // selectedExtractIconOnlyToolStripMenuItem2
            // 
            selectedExtractIconOnlyToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractIconOnlyToolStripMenuItem2.Name = "selectedExtractIconOnlyToolStripMenuItem2";
            selectedExtractIconOnlyToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            selectedExtractIconOnlyToolStripMenuItem2.Text = "Icon only";
            selectedExtractIconOnlyToolStripMenuItem2.Click += ExtractImageIcon_Click;
            // 
            // toolStripMenuItem133
            // 
            toolStripMenuItem133.DropDownItems.AddRange(new ToolStripItem[] { renameSelectedPkg1ToolStripMenuItem2, renameSelectedPkg2ToolStripMenuItem2, renameSelectedPkg3ToolStripMenuItem2, renameSelectedPkg4ToolStripMenuItem2, renameSelectedPkg5ToolStripMenuItem2, renameSelectedPkg6ToolStripMenuItem2, renameSelectedPkg7ToolStripMenuItem2, renameSelectedPkg8ToolStripMenuItem2, renameSelectedPkg9ToolStripMenuItem2, renameSelectedPkg10ToolStripMenuItem2, renameSelectedPkg11ToolStripMenuItem2, renameSelectedPkg12ToolStripMenuItem2 });
            toolStripMenuItem133.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem133.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem133.Name = "toolStripMenuItem133";
            toolStripMenuItem133.ShowShortcutKeys = false;
            toolStripMenuItem133.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem133.Text = "Rename PKG";
            // 
            // renameSelectedPkg1ToolStripMenuItem2
            // 
            renameSelectedPkg1ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg1ToolStripMenuItem2.Name = "renameSelectedPkg1ToolStripMenuItem2";
            renameSelectedPkg1ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg1ToolStripMenuItem2.Text = "TITILE";
            renameSelectedPkg1ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg2ToolStripMenuItem2
            // 
            renameSelectedPkg2ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg2ToolStripMenuItem2.Name = "renameSelectedPkg2ToolStripMenuItem2";
            renameSelectedPkg2ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg2ToolStripMenuItem2.Text = "TITLE [TITLE_ID]";
            renameSelectedPkg2ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg3ToolStripMenuItem2
            // 
            renameSelectedPkg3ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg3ToolStripMenuItem2.Name = "renameSelectedPkg3ToolStripMenuItem2";
            renameSelectedPkg3ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg3ToolStripMenuItem2.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            renameSelectedPkg3ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg4ToolStripMenuItem2
            // 
            renameSelectedPkg4ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg4ToolStripMenuItem2.Name = "renameSelectedPkg4ToolStripMenuItem2";
            renameSelectedPkg4ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg4ToolStripMenuItem2.Text = "TITLE [CATEGORY]";
            renameSelectedPkg4ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg5ToolStripMenuItem2
            // 
            renameSelectedPkg5ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg5ToolStripMenuItem2.Name = "renameSelectedPkg5ToolStripMenuItem2";
            renameSelectedPkg5ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg5ToolStripMenuItem2.Text = "TITLE_ID";
            renameSelectedPkg5ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg6ToolStripMenuItem2
            // 
            renameSelectedPkg6ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg6ToolStripMenuItem2.Name = "renameSelectedPkg6ToolStripMenuItem2";
            renameSelectedPkg6ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg6ToolStripMenuItem2.Text = "TITLE_ID [TITLE]";
            renameSelectedPkg6ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg7ToolStripMenuItem2
            // 
            renameSelectedPkg7ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg7ToolStripMenuItem2.Name = "renameSelectedPkg7ToolStripMenuItem2";
            renameSelectedPkg7ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg7ToolStripMenuItem2.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            renameSelectedPkg7ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg8ToolStripMenuItem2
            // 
            renameSelectedPkg8ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg8ToolStripMenuItem2.Name = "renameSelectedPkg8ToolStripMenuItem2";
            renameSelectedPkg8ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg8ToolStripMenuItem2.Text = "TITLE [CATEGORY] [APP_VERSION]";
            renameSelectedPkg8ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg9ToolStripMenuItem2
            // 
            renameSelectedPkg9ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg9ToolStripMenuItem2.Name = "renameSelectedPkg9ToolStripMenuItem2";
            renameSelectedPkg9ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg9ToolStripMenuItem2.Text = "CONTENT_ID";
            renameSelectedPkg9ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg10ToolStripMenuItem2
            // 
            renameSelectedPkg10ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg10ToolStripMenuItem2.Name = "renameSelectedPkg10ToolStripMenuItem2";
            renameSelectedPkg10ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg10ToolStripMenuItem2.Text = "CONTENT_ID 2";
            renameSelectedPkg10ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg11ToolStripMenuItem2
            // 
            renameSelectedPkg11ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg11ToolStripMenuItem2.Name = "renameSelectedPkg11ToolStripMenuItem2";
            renameSelectedPkg11ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg11ToolStripMenuItem2.Text = "CUSTOM NAME";
            renameSelectedPkg11ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg12ToolStripMenuItem2
            // 
            renameSelectedPkg12ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg12ToolStripMenuItem2.Name = "renameSelectedPkg12ToolStripMenuItem2";
            renameSelectedPkg12ToolStripMenuItem2.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg12ToolStripMenuItem2.Text = "RENAME BY INSTALL PRIORITY";
            renameSelectedPkg12ToolStripMenuItem2.Click += RenamePkg_Click;
            // 
            // viewPkgChangeInfotoolStripMenuItem2
            // 
            viewPkgChangeInfotoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            viewPkgChangeInfotoolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            viewPkgChangeInfotoolStripMenuItem2.Name = "viewPkgChangeInfotoolStripMenuItem2";
            viewPkgChangeInfotoolStripMenuItem2.ShowShortcutKeys = false;
            viewPkgChangeInfotoolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            viewPkgChangeInfotoolStripMenuItem2.Text = "View PKG Change Info";
            viewPkgChangeInfotoolStripMenuItem2.Click += ViewPatchChangelog_Click;
            // 
            // viewPkgExplorerStripMenuItem2
            // 
            viewPkgExplorerStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            viewPkgExplorerStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            viewPkgExplorerStripMenuItem2.Name = "viewPkgExplorerStripMenuItem2";
            viewPkgExplorerStripMenuItem2.ShowShortcutKeys = false;
            viewPkgExplorerStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            viewPkgExplorerStripMenuItem2.Text = "View PKG in Explorer";
            viewPkgExplorerStripMenuItem2.Click += ViewPKGExplorer_Click;
            // 
            // downloadOfficialUpdateToolStripMenuItem2
            // 
            downloadOfficialUpdateToolStripMenuItem2.Enabled = false;
            downloadOfficialUpdateToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            downloadOfficialUpdateToolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            downloadOfficialUpdateToolStripMenuItem2.Name = "downloadOfficialUpdateToolStripMenuItem2";
            downloadOfficialUpdateToolStripMenuItem2.ShowShortcutKeys = false;
            downloadOfficialUpdateToolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            downloadOfficialUpdateToolStripMenuItem2.Text = "Download official update";
            downloadOfficialUpdateToolStripMenuItem2.Click += DownloadOfficialUpdate_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator7.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(302, 6);
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Enabled = false;
            toolStripMenuItem18.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStripMenuItem18.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem18.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.ShowShortcutKeys = false;
            toolStripMenuItem18.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem18.Text = "Remote PKG Installer | Status : Idle";
            // 
            // RpiCheckPkgInstalledtoolStripMenuItem2
            // 
            RpiCheckPkgInstalledtoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiCheckPkgInstalledtoolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            RpiCheckPkgInstalledtoolStripMenuItem2.Name = "RpiCheckPkgInstalledtoolStripMenuItem2";
            RpiCheckPkgInstalledtoolStripMenuItem2.ShowShortcutKeys = false;
            RpiCheckPkgInstalledtoolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            RpiCheckPkgInstalledtoolStripMenuItem2.Text = "Check if base PKG installed on PS4";
            RpiCheckPkgInstalledtoolStripMenuItem2.Click += Rpi_Click;
            // 
            // RpiSendPkgtoolStripMenuItem2
            // 
            RpiSendPkgtoolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiSendPkgtoolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            RpiSendPkgtoolStripMenuItem2.Name = "RpiSendPkgtoolStripMenuItem2";
            RpiSendPkgtoolStripMenuItem2.ShowShortcutKeys = false;
            RpiSendPkgtoolStripMenuItem2.Size = new System.Drawing.Size(305, 22);
            RpiSendPkgtoolStripMenuItem2.Text = "Send PKG to PS4";
            RpiSendPkgtoolStripMenuItem2.Click += Rpi_Click;
            // 
            // toolStripMenuItem21
            // 
            toolStripMenuItem21.DropDownItems.AddRange(new ToolStripItem[] { RpiUninstallBasePKGToolStripMenuItem2, RpiUninstallPatchPKGToolStripMenuItem2, RpiUninstallDlcPKGToolStripMenuItem2, RpiUninstallThemePKGToolStripMenuItem2 });
            toolStripMenuItem21.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem21.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem21.Name = "toolStripMenuItem21";
            toolStripMenuItem21.ShowShortcutKeys = false;
            toolStripMenuItem21.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItem21.Text = "Uninstall PKG from PS4";
            // 
            // RpiUninstallBasePKGToolStripMenuItem2
            // 
            RpiUninstallBasePKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallBasePKGToolStripMenuItem2.Name = "RpiUninstallBasePKGToolStripMenuItem2";
            RpiUninstallBasePKGToolStripMenuItem2.Size = new System.Drawing.Size(229, 22);
            RpiUninstallBasePKGToolStripMenuItem2.Text = "Uninstall base PKG";
            RpiUninstallBasePKGToolStripMenuItem2.Click += Rpi_Click;
            // 
            // RpiUninstallPatchPKGToolStripMenuItem2
            // 
            RpiUninstallPatchPKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallPatchPKGToolStripMenuItem2.Name = "RpiUninstallPatchPKGToolStripMenuItem2";
            RpiUninstallPatchPKGToolStripMenuItem2.Size = new System.Drawing.Size(229, 22);
            RpiUninstallPatchPKGToolStripMenuItem2.Text = "Uninstall patch PKG";
            RpiUninstallPatchPKGToolStripMenuItem2.Click += Rpi_Click;
            // 
            // RpiUninstallDlcPKGToolStripMenuItem2
            // 
            RpiUninstallDlcPKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallDlcPKGToolStripMenuItem2.Name = "RpiUninstallDlcPKGToolStripMenuItem2";
            RpiUninstallDlcPKGToolStripMenuItem2.Size = new System.Drawing.Size(229, 22);
            RpiUninstallDlcPKGToolStripMenuItem2.Text = "Uninstall addon PKG (DLC)";
            RpiUninstallDlcPKGToolStripMenuItem2.Click += Rpi_Click;
            // 
            // RpiUninstallThemePKGToolStripMenuItem2
            // 
            RpiUninstallThemePKGToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallThemePKGToolStripMenuItem2.Name = "RpiUninstallThemePKGToolStripMenuItem2";
            RpiUninstallThemePKGToolStripMenuItem2.Size = new System.Drawing.Size(229, 22);
            RpiUninstallThemePKGToolStripMenuItem2.Text = "Uninstall addon PKG (Theme)";
            RpiUninstallThemePKGToolStripMenuItem2.Click += Rpi_Click;
            // 
            // toolStripSeparatorShadps4
            // 
            toolStripSeparatorShadps4.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparatorShadps4.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparatorShadps4.Name = "toolStripSeparatorShadps4";
            toolStripSeparatorShadps4.Size = new System.Drawing.Size(302, 6);
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Enabled = false;
            sToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            sToolStripMenuItem.Text = "shadPS4";
            // 
            // toolStripMenuItemShadps4Launch
            // 
            toolStripMenuItemShadps4Launch.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4Launch.Name = "toolStripMenuItemShadps4Launch";
            toolStripMenuItemShadps4Launch.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItemShadps4Launch.Text = "Launch";
            toolStripMenuItemShadps4Launch.Click += toolStripMenuItemShadps4Launch_Click;
            // 
            // toolStripMenuItemShadps4Install
            // 
            toolStripMenuItemShadps4Install.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4Install.Name = "toolStripMenuItemShadps4Install";
            toolStripMenuItemShadps4Install.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItemShadps4Install.Text = "Install to shadPS4...";
            toolStripMenuItemShadps4Install.Click += toolStripMenuItemShadps4Install_Click;
            // 
            // toolStripMenuItemShadps4Uninstall
            // 
            toolStripMenuItemShadps4Uninstall.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4Uninstall.Name = "toolStripMenuItemShadps4Uninstall";
            toolStripMenuItemShadps4Uninstall.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItemShadps4Uninstall.Text = "Uninstall game";
            toolStripMenuItemShadps4Uninstall.Visible = false;
            toolStripMenuItemShadps4Uninstall.Click += toolStripMenuItemShadps4Uninstall_Click;
            // 
            // toolStripMenuItemShadps4OpenManager
            // 
            toolStripMenuItemShadps4OpenManager.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4OpenManager.Name = "toolStripMenuItemShadps4OpenManager";
            toolStripMenuItemShadps4OpenManager.Size = new System.Drawing.Size(305, 22);
            toolStripMenuItemShadps4OpenManager.Text = "Open shadPS4 Manager";
            toolStripMenuItemShadps4OpenManager.Click += toolStripMenuItemShadps4OpenManager_Click;
            // 
            // toolStripMenuItemShadps4InstallSetup
            // 
            toolStripMenuItemShadps4InstallSetup.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4InstallSetup.Name = "toolStripMenuItemShadps4InstallSetup";
            toolStripMenuItemShadps4InstallSetup.Size = new System.Drawing.Size(239, 22);
            toolStripMenuItemShadps4InstallSetup.Text = "Install shadPS4 Setup...";
            toolStripMenuItemShadps4InstallSetup.Click += toolStripMenuItemShadps4InstallSetup_Click;
            // 
            // toolStripMenuItemShadps4OpenLauncher
            // 
            toolStripMenuItemShadps4OpenLauncher.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4OpenLauncher.Name = "toolStripMenuItemShadps4OpenLauncher";
            toolStripMenuItemShadps4OpenLauncher.Size = new System.Drawing.Size(239, 22);
            toolStripMenuItemShadps4OpenLauncher.Text = "Open shadPS4 Launcher";
            toolStripMenuItemShadps4OpenLauncher.Click += toolStripMenuItemShadps4OpenLauncher_Click;
            // 
            // toolStripMenuItemShadps4Configure
            // 
            toolStripMenuItemShadps4Configure.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4Configure.Name = "toolStripMenuItemShadps4Configure";
            toolStripMenuItemShadps4Configure.Size = new System.Drawing.Size(239, 22);
            toolStripMenuItemShadps4Configure.Text = "Configure shadPS4...";
            toolStripMenuItemShadps4Configure.Click += toolStripMenuItemShadps4Configure_Click;
            // 
            // toolStripMenuItemShadps4Manager
            // 
            toolStripMenuItemShadps4Manager.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemShadps4Manager.Name = "toolStripMenuItemShadps4Manager";
            toolStripMenuItemShadps4Manager.Size = new System.Drawing.Size(168, 22);
            toolStripMenuItemShadps4Manager.Text = "shadPS4 Manager";
            toolStripMenuItemShadps4Manager.Click += toolStripMenuItemShadps4Manager_Click;
            // 
            // toolStripMenuItemTools
            // 
            toolStripMenuItemTools.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemShadps4Manager });
            toolStripMenuItemTools.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItemTools.Name = "toolStripMenuItemTools";
            toolStripMenuItemTools.Size = new System.Drawing.Size(47, 20);
            toolStripMenuItemTools.Text = "Tools";
            // 
            // openAppDataDirectoryToolStripMenuItem2
            // 
            openAppDataDirectoryToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            openAppDataDirectoryToolStripMenuItem2.Name = "openAppDataDirectoryToolStripMenuItem2";
            openAppDataDirectoryToolStripMenuItem2.Size = new System.Drawing.Size(249, 22);
            openAppDataDirectoryToolStripMenuItem2.Text = "Open App Data Folder";
            openAppDataDirectoryToolStripMenuItem2.Click += OpenAppDataDirectory_Click;
            // 
            // toolStripMenuItem34
            // 
            toolStripMenuItem34.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem34.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem34.Name = "toolStripMenuItem34";
            toolStripMenuItem34.ShowShortcutKeys = false;
            toolStripMenuItem34.Size = new System.Drawing.Size(249, 22);
            toolStripMenuItem34.Text = "Settings";
            toolStripMenuItem34.Click += toolStripMenuItem34_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator1.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator5.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(267, 6);
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator6.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(267, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator3.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(267, 6);
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            label8.Location = new System.Drawing.Point(1194, 649);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(0, 15);
            label8.TabIndex = 82;
            label8.Visible = false;
            // 
            // darkMenuStrip1
            // 
            darkMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkMenuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem2, toolStripMenuItemTools, toolStripMenuItem144 });
            darkMenuStrip1.Location = new System.Drawing.Point(0, 0);
            darkMenuStrip1.Name = "darkMenuStrip1";
            darkMenuStrip1.Padding = new Padding(3, 2, 0, 2);
            darkMenuStrip1.Size = new System.Drawing.Size(1219, 24);
            darkMenuStrip1.TabIndex = 84;
            darkMenuStrip1.Text = "darkMenuStrip1";
            // 
            // fileToolStripMenuItem2
            // 
            fileToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { managePS4PKGToolStripMenuItem, settingstoolStripMenuItem, loadFromDirectoryToolStripMenuItem, loadFromManifestToolStripMenuItem, saveManifestToolStripMenuItem, emptyListToolStripMenuItem, toolStripSeparator11, exitToolStripMenuItem1 });
            fileToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem2.Text = "File";
            // 
            // managePS4PKGToolStripMenuItem
            // 
            managePS4PKGToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            managePS4PKGToolStripMenuItem.Name = "managePS4PKGToolStripMenuItem";
            managePS4PKGToolStripMenuItem.ShowShortcutKeys = false;
            managePS4PKGToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            managePS4PKGToolStripMenuItem.Text = "Open PKG Directory Settings";
            managePS4PKGToolStripMenuItem.Visible = false;
            managePS4PKGToolStripMenuItem.Click += managePS4PKGToolStripMenuItem_Click;
            // 
            // settingstoolStripMenuItem
            // 
            settingstoolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            settingstoolStripMenuItem.Name = "settingstoolStripMenuItem";
            settingstoolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            settingstoolStripMenuItem.Text = "Settings";
            settingstoolStripMenuItem.Click += settingstoolStripMenuItem_Click;
            // 
            // loadFromDirectoryToolStripMenuItem
            // 
            loadFromDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            loadFromDirectoryToolStripMenuItem.Name = "loadFromDirectoryToolStripMenuItem";
            loadFromDirectoryToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            loadFromDirectoryToolStripMenuItem.Text = "Load from saved directory";
            loadFromDirectoryToolStripMenuItem.Click += loadFromDirectoryToolStripMenuItem_Click;
            // 
            // loadFromManifestToolStripMenuItem
            // 
            loadFromManifestToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            loadFromManifestToolStripMenuItem.Name = "loadFromManifestToolStripMenuItem";
            loadFromManifestToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            loadFromManifestToolStripMenuItem.Text = "Load Manifest From...";
            loadFromManifestToolStripMenuItem.Click += loadFromManifestToolStripMenuItem_Click;
            // 
            // saveManifestToolStripMenuItem
            // 
            saveManifestToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            saveManifestToolStripMenuItem.Name = "saveManifestToolStripMenuItem";
            saveManifestToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            saveManifestToolStripMenuItem.Text = "Save Manifest As...";
            saveManifestToolStripMenuItem.Click += saveManifestToolStripMenuItem_Click;
            // 
            // emptyListToolStripMenuItem
            // 
            emptyListToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            emptyListToolStripMenuItem.Name = "emptyListToolStripMenuItem";
            emptyListToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            emptyListToolStripMenuItem.Text = "Empty list";
            emptyListToolStripMenuItem.Click += emptyListToolStripMenuItem_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator11.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(213, 6);
            toolStripSeparator11.Visible = false;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            exitToolStripMenuItem1.Text = "Exit";
            exitToolStripMenuItem1.Click += toolStripMenuItem78_Click;
            // 
            // toolStripMenuItem144
            // 
            toolStripMenuItem144.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem159, toolStripMenuItem160, toolStripMenuItem158 });
            toolStripMenuItem144.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem144.Name = "toolStripMenuItem144";
            toolStripMenuItem144.Size = new System.Drawing.Size(44, 20);
            toolStripMenuItem144.Text = "Help";
            // 
            // toolStripMenuItem159
            // 
            toolStripMenuItem159.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem159.Name = "toolStripMenuItem159";
            toolStripMenuItem159.Size = new System.Drawing.Size(165, 22);
            toolStripMenuItem159.Text = "About";
            toolStripMenuItem159.Click += toolStripMenuItem159_Click;
            // 
            // toolStripMenuItem160
            // 
            toolStripMenuItem160.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem160.Name = "toolStripMenuItem160";
            toolStripMenuItem160.Size = new System.Drawing.Size(165, 22);
            toolStripMenuItem160.Text = "Buy me a coffee";
            toolStripMenuItem160.Click += toolStripMenuItem160_Click;
            // 
            // toolStripMenuItem158
            // 
            toolStripMenuItem158.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem158.Name = "toolStripMenuItem158";
            toolStripMenuItem158.Size = new System.Drawing.Size(165, 22);
            toolStripMenuItem158.Text = "Check for update";
            toolStripMenuItem158.Click += toolStripMenuItem158_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator12.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new System.Drawing.Size(251, 6);
            // 
            // globalActionToolStripMenuItem
            // 
            globalActionToolStripMenuItem.Enabled = false;
            globalActionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            globalActionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(153, 153, 153);
            globalActionToolStripMenuItem.Name = "globalActionToolStripMenuItem";
            globalActionToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            globalActionToolStripMenuItem.Text = "Global Action";
            // 
            // checkForDuplicatePKGToolStripMenuItem1
            // 
            checkForDuplicatePKGToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            checkForDuplicatePKGToolStripMenuItem1.Name = "checkForDuplicatePKGToolStripMenuItem1";
            checkForDuplicatePKGToolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            checkForDuplicatePKGToolStripMenuItem1.Text = "Check for duplicate PKG";
            checkForDuplicatePKGToolStripMenuItem1.Click += CheckForDuplicatePKG_Click;
            // 
            // globalExportPKGListToExcelToolStripMenuItem1
            // 
            globalExportPKGListToExcelToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExportPKGListToExcelToolStripMenuItem1.Name = "globalExportPKGListToExcelToolStripMenuItem1";
            globalExportPKGListToExcelToolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            globalExportPKGListToExcelToolStripMenuItem1.Text = "Export PKG list as excel file";
            globalExportPKGListToExcelToolStripMenuItem1.Click += ExportPKGToExcel_Click;
            // 
            // extractImageAndBackgroundToolStripMenuItem
            // 
            extractImageAndBackgroundToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { globalExtractImagesAndIconToolStripMenuItem1, globalExtractImageOnlyToolStripMenuItem1, globalExtractIconOnlyToolStripMenuItem1 });
            extractImageAndBackgroundToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            extractImageAndBackgroundToolStripMenuItem.Name = "extractImageAndBackgroundToolStripMenuItem";
            extractImageAndBackgroundToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            extractImageAndBackgroundToolStripMenuItem.Text = "Save artwork";
            // 
            // globalExtractImagesAndIconToolStripMenuItem1
            // 
            globalExtractImagesAndIconToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractImagesAndIconToolStripMenuItem1.Name = "globalExtractImagesAndIconToolStripMenuItem1";
            globalExtractImagesAndIconToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            globalExtractImagesAndIconToolStripMenuItem1.Text = "Backgrounds + Icon";
            globalExtractImagesAndIconToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // globalExtractImageOnlyToolStripMenuItem1
            // 
            globalExtractImageOnlyToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractImageOnlyToolStripMenuItem1.Name = "globalExtractImageOnlyToolStripMenuItem1";
            globalExtractImageOnlyToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            globalExtractImageOnlyToolStripMenuItem1.Text = "Backgrounds only";
            globalExtractImageOnlyToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // globalExtractIconOnlyToolStripMenuItem1
            // 
            globalExtractIconOnlyToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalExtractIconOnlyToolStripMenuItem1.Name = "globalExtractIconOnlyToolStripMenuItem1";
            globalExtractIconOnlyToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            globalExtractIconOnlyToolStripMenuItem1.Text = "Icon only";
            globalExtractIconOnlyToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { renameAllPkg1ToolStripMenuItem1, renameAllPkg2ToolStripMenuItem1, renameAllPkg3ToolStripMenuItem1, renameAllPkg4ToolStripMenuItem1, renameAllPkg5ToolStripMenuItem1, renameAllPkg6ToolStripMenuItem1, renameAllPkg7ToolStripMenuItem1, renameAllPkg8ToolStripMenuItem1, renameAllPkg9ToolStripMenuItem1, renameAllPkg10ToolStripMenuItem1, renameAllPkg11ToolStripMenuItem1, renameAllPkg12ToolStripMenuItem1 });
            renameToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            renameToolStripMenuItem.Text = "Rename all PKG";
            // 
            // renameAllPkg1ToolStripMenuItem1
            // 
            renameAllPkg1ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg1ToolStripMenuItem1.Name = "renameAllPkg1ToolStripMenuItem1";
            renameAllPkg1ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg1ToolStripMenuItem1.Text = "TITILE";
            renameAllPkg1ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg2ToolStripMenuItem1
            // 
            renameAllPkg2ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg2ToolStripMenuItem1.Name = "renameAllPkg2ToolStripMenuItem1";
            renameAllPkg2ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg2ToolStripMenuItem1.Text = "TITLE [TITLE_ID]";
            renameAllPkg2ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg3ToolStripMenuItem1
            // 
            renameAllPkg3ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg3ToolStripMenuItem1.Name = "renameAllPkg3ToolStripMenuItem1";
            renameAllPkg3ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg3ToolStripMenuItem1.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            renameAllPkg3ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg4ToolStripMenuItem1
            // 
            renameAllPkg4ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg4ToolStripMenuItem1.Name = "renameAllPkg4ToolStripMenuItem1";
            renameAllPkg4ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg4ToolStripMenuItem1.Text = "TITLE [CATEGORY]";
            renameAllPkg4ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg5ToolStripMenuItem1
            // 
            renameAllPkg5ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg5ToolStripMenuItem1.Name = "renameAllPkg5ToolStripMenuItem1";
            renameAllPkg5ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg5ToolStripMenuItem1.Text = "TITLE_ID";
            renameAllPkg5ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg6ToolStripMenuItem1
            // 
            renameAllPkg6ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg6ToolStripMenuItem1.Name = "renameAllPkg6ToolStripMenuItem1";
            renameAllPkg6ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg6ToolStripMenuItem1.Text = "[TITLE_ID] TITLE";
            renameAllPkg6ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg7ToolStripMenuItem1
            // 
            renameAllPkg7ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg7ToolStripMenuItem1.Name = "renameAllPkg7ToolStripMenuItem1";
            renameAllPkg7ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg7ToolStripMenuItem1.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            renameAllPkg7ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg8ToolStripMenuItem1
            // 
            renameAllPkg8ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg8ToolStripMenuItem1.Name = "renameAllPkg8ToolStripMenuItem1";
            renameAllPkg8ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg8ToolStripMenuItem1.Text = "TITLE [CATEGORY] [APP_VERSION]";
            renameAllPkg8ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg9ToolStripMenuItem1
            // 
            renameAllPkg9ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg9ToolStripMenuItem1.Name = "renameAllPkg9ToolStripMenuItem1";
            renameAllPkg9ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg9ToolStripMenuItem1.Text = "CONTENT_ID";
            renameAllPkg9ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg10ToolStripMenuItem1
            // 
            renameAllPkg10ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg10ToolStripMenuItem1.Name = "renameAllPkg10ToolStripMenuItem1";
            renameAllPkg10ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg10ToolStripMenuItem1.Text = "CONTENT_ID 2";
            renameAllPkg10ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg11ToolStripMenuItem1
            // 
            renameAllPkg11ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg11ToolStripMenuItem1.Name = "renameAllPkg11ToolStripMenuItem1";
            renameAllPkg11ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg11ToolStripMenuItem1.Text = "CUSTOM NAME";
            renameAllPkg11ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameAllPkg12ToolStripMenuItem1
            // 
            renameAllPkg12ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameAllPkg12ToolStripMenuItem1.Name = "renameAllPkg12ToolStripMenuItem1";
            renameAllPkg12ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameAllPkg12ToolStripMenuItem1.Text = "RENAME BY INSTALL PRIORITY";
            renameAllPkg12ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // seperateAndMovePKGByTypeIntoFolderToolStripMenuItem
            // 
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { movePkgTitleToolStripMenuItem1, movePkgCategoryToolStripMenuItem1, movePkgTypeToolStripMenuItem1, movePkgRegionToolStripMenuItem1, movePkgSingleFolderToolStripMenuItem1 });
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem.Name = "seperateAndMovePKGByTypeIntoFolderToolStripMenuItem";
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            seperateAndMovePKGByTypeIntoFolderToolStripMenuItem.Text = "Move PKG";
            // 
            // movePkgTitleToolStripMenuItem1
            // 
            movePkgTitleToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgTitleToolStripMenuItem1.Name = "movePkgTitleToolStripMenuItem1";
            movePkgTitleToolStripMenuItem1.Size = new System.Drawing.Size(312, 22);
            movePkgTitleToolStripMenuItem1.Text = "Move by PKG title";
            movePkgTitleToolStripMenuItem1.Click += MovePkg_Click;
            // 
            // movePkgCategoryToolStripMenuItem1
            // 
            movePkgCategoryToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgCategoryToolStripMenuItem1.Name = "movePkgCategoryToolStripMenuItem1";
            movePkgCategoryToolStripMenuItem1.Size = new System.Drawing.Size(312, 22);
            movePkgCategoryToolStripMenuItem1.Text = "Move by PKG category (Base/Update/Addon)";
            movePkgCategoryToolStripMenuItem1.Click += MovePkg_Click;
            // 
            // movePkgTypeToolStripMenuItem1
            // 
            movePkgTypeToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgTypeToolStripMenuItem1.Name = "movePkgTypeToolStripMenuItem1";
            movePkgTypeToolStripMenuItem1.Size = new System.Drawing.Size(312, 22);
            movePkgTypeToolStripMenuItem1.Text = "Move by PKG type (Fake/Official)";
            movePkgTypeToolStripMenuItem1.Click += MovePkg_Click;
            // 
            // movePkgRegionToolStripMenuItem1
            // 
            movePkgRegionToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgRegionToolStripMenuItem1.Name = "movePkgRegionToolStripMenuItem1";
            movePkgRegionToolStripMenuItem1.Size = new System.Drawing.Size(312, 22);
            movePkgRegionToolStripMenuItem1.Text = "Move by PKG region";
            movePkgRegionToolStripMenuItem1.Click += MovePkg_Click;
            // 
            // movePkgSingleFolderToolStripMenuItem1
            // 
            movePkgSingleFolderToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            movePkgSingleFolderToolStripMenuItem1.Name = "movePkgSingleFolderToolStripMenuItem1";
            movePkgSingleFolderToolStripMenuItem1.Size = new System.Drawing.Size(312, 22);
            movePkgSingleFolderToolStripMenuItem1.Text = "Move all to single folder";
            movePkgSingleFolderToolStripMenuItem1.Click += MovePkg_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator4.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(251, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(153, 153, 153);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(254, 22);
            toolStripMenuItem2.Text = "...";
            // 
            // globalCopyStripMenuItem
            // 
            globalCopyStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyTitleIdtoolStripMenuItem1, copyContentIdtoolStripMenuItem1, copyTitleToolStripMenuItem1, copyFilenameToolStripMenuItem1 });
            globalCopyStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            globalCopyStripMenuItem.Name = "globalCopyStripMenuItem";
            globalCopyStripMenuItem.Size = new System.Drawing.Size(254, 22);
            globalCopyStripMenuItem.Text = "Copy";
            // 
            // copyTitleIdtoolStripMenuItem1
            // 
            copyTitleIdtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyTitleIdtoolStripMenuItem1.Name = "copyTitleIdtoolStripMenuItem1";
            copyTitleIdtoolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            copyTitleIdtoolStripMenuItem1.Text = "TITLE_ID";
            copyTitleIdtoolStripMenuItem1.Click += CopyID_Click;
            // 
            // copyContentIdtoolStripMenuItem1
            // 
            copyContentIdtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyContentIdtoolStripMenuItem1.Name = "copyContentIdtoolStripMenuItem1";
            copyContentIdtoolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            copyContentIdtoolStripMenuItem1.Text = "CONTENT_ID";
            copyContentIdtoolStripMenuItem1.Click += CopyID_Click;
            // 
            // copyTitleToolStripMenuItem1
            // 
            copyTitleToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyTitleToolStripMenuItem1.Name = "copyTitleToolStripMenuItem1";
            copyTitleToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            copyTitleToolStripMenuItem1.Text = "TITLE";
            copyTitleToolStripMenuItem1.Click += CopyID_Click;
            // 
            // copyFilenameToolStripMenuItem1
            // 
            copyFilenameToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyFilenameToolStripMenuItem1.Name = "copyFilenameToolStripMenuItem1";
            copyFilenameToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            copyFilenameToolStripMenuItem1.Text = "Filename";
            copyFilenameToolStripMenuItem1.Click += CopyID_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { setBackportedtoolStripMenuItem1, toolStripMenuItem4, toolStripSeparator10, removeBackportedtoolStripMenuItem1 });
            toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            toolStripMenuItem1.Text = "Backport";
            // 
            // setBackportedtoolStripMenuItem1
            // 
            setBackportedtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            setBackportedtoolStripMenuItem1.Name = "setBackportedtoolStripMenuItem1";
            setBackportedtoolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            setBackportedtoolStripMenuItem1.Text = "Set as backported";
            setBackportedtoolStripMenuItem1.Click += Backport_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { backportRemarkTextboxtoolStripTextBox1, setRemarktoolStripMenuItem1 });
            toolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(208, 22);
            toolStripMenuItem4.Text = "Set backport remarks";
            // 
            // backportRemarkTextboxtoolStripTextBox1
            // 
            backportRemarkTextboxtoolStripTextBox1.Name = "backportRemarkTextboxtoolStripTextBox1";
            backportRemarkTextboxtoolStripTextBox1.Size = new System.Drawing.Size(180, 23);
            // 
            // setRemarktoolStripMenuItem1
            // 
            setRemarktoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            setRemarktoolStripMenuItem1.Name = "setRemarktoolStripMenuItem1";
            setRemarktoolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            setRemarktoolStripMenuItem1.Text = "Set remarks";
            setRemarktoolStripMenuItem1.Click += Backport_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator10.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(205, 6);
            // 
            // removeBackportedtoolStripMenuItem1
            // 
            removeBackportedtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            removeBackportedtoolStripMenuItem1.Name = "removeBackportedtoolStripMenuItem1";
            removeBackportedtoolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            removeBackportedtoolStripMenuItem1.Text = "Remove backported label";
            removeBackportedtoolStripMenuItem1.Click += Backport_Click;
            // 
            // deletePKGtoolStripMenuItem1
            // 
            deletePKGtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            deletePKGtoolStripMenuItem1.Name = "deletePKGtoolStripMenuItem1";
            deletePKGtoolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            deletePKGtoolStripMenuItem1.Text = "Delete PKG";
            deletePKGtoolStripMenuItem1.Click += DeletePKG_Click;
            // 
            // selectedExportPKGListToExcelToolStripMenuItem1
            // 
            selectedExportPKGListToExcelToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExportPKGListToExcelToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            selectedExportPKGListToExcelToolStripMenuItem1.Name = "selectedExportPKGListToExcelToolStripMenuItem1";
            selectedExportPKGListToExcelToolStripMenuItem1.ShowShortcutKeys = false;
            selectedExportPKGListToExcelToolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            selectedExportPKGListToExcelToolStripMenuItem1.Text = "Export as excel file";
            selectedExportPKGListToExcelToolStripMenuItem1.Click += ExportPKGToExcel_Click;
            // 
            // toolStripMenuItem28
            // 
            toolStripMenuItem28.DropDownItems.AddRange(new ToolStripItem[] { selectedExtractImagesAndIconToolStripMenuItem1, selectedExtractImageOnlyToolStripMenuItem1, selectedExtractIconOnlyToolStripMenuItem1 });
            toolStripMenuItem28.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem28.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem28.Name = "toolStripMenuItem28";
            toolStripMenuItem28.ShowShortcutKeys = false;
            toolStripMenuItem28.Size = new System.Drawing.Size(254, 22);
            toolStripMenuItem28.Text = "Save artwork";
            // 
            // selectedExtractImagesAndIconToolStripMenuItem1
            // 
            selectedExtractImagesAndIconToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractImagesAndIconToolStripMenuItem1.Name = "selectedExtractImagesAndIconToolStripMenuItem1";
            selectedExtractImagesAndIconToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            selectedExtractImagesAndIconToolStripMenuItem1.Text = "Backgrounds + Icon";
            selectedExtractImagesAndIconToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // selectedExtractImageOnlyToolStripMenuItem1
            // 
            selectedExtractImageOnlyToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractImageOnlyToolStripMenuItem1.Name = "selectedExtractImageOnlyToolStripMenuItem1";
            selectedExtractImageOnlyToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            selectedExtractImageOnlyToolStripMenuItem1.Text = "Backgrounds only";
            selectedExtractImageOnlyToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // selectedExtractIconOnlyToolStripMenuItem1
            // 
            selectedExtractIconOnlyToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            selectedExtractIconOnlyToolStripMenuItem1.Name = "selectedExtractIconOnlyToolStripMenuItem1";
            selectedExtractIconOnlyToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            selectedExtractIconOnlyToolStripMenuItem1.Text = "Icon only";
            selectedExtractIconOnlyToolStripMenuItem1.Click += ExtractImageIcon_Click;
            // 
            // renameCurrentPKGStripMenuItem
            // 
            renameCurrentPKGStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { renameSelectedPkg1ToolStripMenuItem1, renameSelectedPkg2ToolStripMenuItem1, renameSelectedPkg3ToolStripMenuItem1, renameSelectedPkg4ToolStripMenuItem1, renameSelectedPkg5ToolStripMenuItem1, renameSelectedPkg6ToolStripMenuItem1, renameSelectedPkg7ToolStripMenuItem1, renameSelectedPkg8ToolStripMenuItem1, renameSelectedPkg9ToolStripMenuItem1, renameSelectedPkg10ToolStripMenuItem1, renameSelectedPkg11ToolStripMenuItem1, renameSelectedPkg12ToolStripMenuItem1 });
            renameCurrentPKGStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameCurrentPKGStripMenuItem.Name = "renameCurrentPKGStripMenuItem";
            renameCurrentPKGStripMenuItem.Size = new System.Drawing.Size(254, 22);
            renameCurrentPKGStripMenuItem.Text = "Rename PKG";
            // 
            // renameSelectedPkg1ToolStripMenuItem1
            // 
            renameSelectedPkg1ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg1ToolStripMenuItem1.Name = "renameSelectedPkg1ToolStripMenuItem1";
            renameSelectedPkg1ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg1ToolStripMenuItem1.Text = "TITILE";
            renameSelectedPkg1ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg2ToolStripMenuItem1
            // 
            renameSelectedPkg2ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg2ToolStripMenuItem1.Name = "renameSelectedPkg2ToolStripMenuItem1";
            renameSelectedPkg2ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg2ToolStripMenuItem1.Text = "TITLE [TITLE_ID]";
            renameSelectedPkg2ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg3ToolStripMenuItem1
            // 
            renameSelectedPkg3ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg3ToolStripMenuItem1.Name = "renameSelectedPkg3ToolStripMenuItem1";
            renameSelectedPkg3ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg3ToolStripMenuItem1.Text = "TITLE [TITLE_ID] [APP_VERSION]";
            renameSelectedPkg3ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg4ToolStripMenuItem1
            // 
            renameSelectedPkg4ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg4ToolStripMenuItem1.Name = "renameSelectedPkg4ToolStripMenuItem1";
            renameSelectedPkg4ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg4ToolStripMenuItem1.Text = "TITLE [CATEGORY]";
            renameSelectedPkg4ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg5ToolStripMenuItem1
            // 
            renameSelectedPkg5ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg5ToolStripMenuItem1.Name = "renameSelectedPkg5ToolStripMenuItem1";
            renameSelectedPkg5ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg5ToolStripMenuItem1.Text = "TITLE_ID";
            renameSelectedPkg5ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg6ToolStripMenuItem1
            // 
            renameSelectedPkg6ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg6ToolStripMenuItem1.Name = "renameSelectedPkg6ToolStripMenuItem1";
            renameSelectedPkg6ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg6ToolStripMenuItem1.Text = "TITLE_ID [TITLE]";
            renameSelectedPkg6ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg7ToolStripMenuItem1
            // 
            renameSelectedPkg7ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg7ToolStripMenuItem1.Name = "renameSelectedPkg7ToolStripMenuItem1";
            renameSelectedPkg7ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg7ToolStripMenuItem1.Text = "[TITLE_ID] [CATEGORY] [APP_VERSION] TITLE";
            renameSelectedPkg7ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg8ToolStripMenuItem1
            // 
            renameSelectedPkg8ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg8ToolStripMenuItem1.Name = "renameSelectedPkg8ToolStripMenuItem1";
            renameSelectedPkg8ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg8ToolStripMenuItem1.Text = "TITLE [CATEGORY] [APP_VERSION]";
            renameSelectedPkg8ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg9ToolStripMenuItem1
            // 
            renameSelectedPkg9ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg9ToolStripMenuItem1.Name = "renameSelectedPkg9ToolStripMenuItem1";
            renameSelectedPkg9ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg9ToolStripMenuItem1.Text = "CONTENT_ID";
            renameSelectedPkg9ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg10ToolStripMenuItem1
            // 
            renameSelectedPkg10ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg10ToolStripMenuItem1.Name = "renameSelectedPkg10ToolStripMenuItem1";
            renameSelectedPkg10ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg10ToolStripMenuItem1.Text = "CONTENT_ID 2";
            renameSelectedPkg10ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg11ToolStripMenuItem1
            // 
            renameSelectedPkg11ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg11ToolStripMenuItem1.Name = "renameSelectedPkg11ToolStripMenuItem1";
            renameSelectedPkg11ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg11ToolStripMenuItem1.Text = "CUSTOM NAME";
            renameSelectedPkg11ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // renameSelectedPkg12ToolStripMenuItem1
            // 
            renameSelectedPkg12ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            renameSelectedPkg12ToolStripMenuItem1.Name = "renameSelectedPkg12ToolStripMenuItem1";
            renameSelectedPkg12ToolStripMenuItem1.Size = new System.Drawing.Size(314, 22);
            renameSelectedPkg12ToolStripMenuItem1.Text = "RENAME BY INSTALL PRIORITY";
            renameSelectedPkg12ToolStripMenuItem1.Click += RenamePkg_Click;
            // 
            // viewPkgChangeInfotoolStripMenuItem1
            // 
            viewPkgChangeInfotoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            viewPkgChangeInfotoolStripMenuItem1.Name = "viewPkgChangeInfotoolStripMenuItem1";
            viewPkgChangeInfotoolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            viewPkgChangeInfotoolStripMenuItem1.Text = "View PKG Change Info";
            viewPkgChangeInfotoolStripMenuItem1.Click += ViewPatchChangelog_Click;
            // 
            // viewPkgExplorerStripMenuItem1
            // 
            viewPkgExplorerStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            viewPkgExplorerStripMenuItem1.Name = "viewPkgExplorerStripMenuItem1";
            viewPkgExplorerStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            viewPkgExplorerStripMenuItem1.Text = "View PKG in Explorer";
            viewPkgExplorerStripMenuItem1.Click += ViewPKGExplorer_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator8.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(251, 6);
            // 
            // downloadOfficialUpdateToolStripMenuItem1
            // 
            downloadOfficialUpdateToolStripMenuItem1.Enabled = false;
            downloadOfficialUpdateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            downloadOfficialUpdateToolStripMenuItem1.Name = "downloadOfficialUpdateToolStripMenuItem1";
            downloadOfficialUpdateToolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            downloadOfficialUpdateToolStripMenuItem1.Text = "Download official update";
            downloadOfficialUpdateToolStripMenuItem1.Click += DownloadOfficialUpdate_Click;
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Enabled = false;
            toolStripMenuItem16.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStripMenuItem16.ForeColor = System.Drawing.Color.FromArgb(153, 153, 153);
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.Size = new System.Drawing.Size(254, 22);
            toolStripMenuItem16.Text = "Remote PKG Installer | Status : Idle";
            // 
            // RpiCheckPkgInstalledtoolStripMenuItem1
            // 
            RpiCheckPkgInstalledtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiCheckPkgInstalledtoolStripMenuItem1.Name = "RpiCheckPkgInstalledtoolStripMenuItem1";
            RpiCheckPkgInstalledtoolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            RpiCheckPkgInstalledtoolStripMenuItem1.Text = "Check if base PKG installed on PS4";
            RpiCheckPkgInstalledtoolStripMenuItem1.Click += Rpi_Click;
            // 
            // RpiSendPkgtoolStripMenuItem1
            // 
            RpiSendPkgtoolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiSendPkgtoolStripMenuItem1.Name = "RpiSendPkgtoolStripMenuItem1";
            RpiSendPkgtoolStripMenuItem1.Size = new System.Drawing.Size(254, 22);
            RpiSendPkgtoolStripMenuItem1.Text = "Send PKG to PS4";
            RpiSendPkgtoolStripMenuItem1.Click += Rpi_Click;
            // 
            // uninstallPKGFromPS4ToolStripMenuItem
            // 
            uninstallPKGFromPS4ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RpiUninstallBasePKGToolStripMenuItem1, RpiUninstallPatchPKGToolStripMenuItem1, RpiUninstallDlcPKGToolStripMenuItem1, RpiUninstallThemePKGToolStripMenuItem1 });
            uninstallPKGFromPS4ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            uninstallPKGFromPS4ToolStripMenuItem.Name = "uninstallPKGFromPS4ToolStripMenuItem";
            uninstallPKGFromPS4ToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            uninstallPKGFromPS4ToolStripMenuItem.Text = "Uninstall PKG from PS4";
            // 
            // RpiUninstallBasePKGToolStripMenuItem1
            // 
            RpiUninstallBasePKGToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallBasePKGToolStripMenuItem1.Name = "RpiUninstallBasePKGToolStripMenuItem1";
            RpiUninstallBasePKGToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            RpiUninstallBasePKGToolStripMenuItem1.Text = "Uninstall base PKG";
            RpiUninstallBasePKGToolStripMenuItem1.Click += Rpi_Click;
            // 
            // RpiUninstallPatchPKGToolStripMenuItem1
            // 
            RpiUninstallPatchPKGToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallPatchPKGToolStripMenuItem1.Name = "RpiUninstallPatchPKGToolStripMenuItem1";
            RpiUninstallPatchPKGToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            RpiUninstallPatchPKGToolStripMenuItem1.Text = "Uninstall patch PKG";
            RpiUninstallPatchPKGToolStripMenuItem1.Click += Rpi_Click;
            // 
            // RpiUninstallDlcPKGToolStripMenuItem1
            // 
            RpiUninstallDlcPKGToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallDlcPKGToolStripMenuItem1.Name = "RpiUninstallDlcPKGToolStripMenuItem1";
            RpiUninstallDlcPKGToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            RpiUninstallDlcPKGToolStripMenuItem1.Text = "Uninstall addon PKG (DLC)";
            RpiUninstallDlcPKGToolStripMenuItem1.Click += Rpi_Click;
            // 
            // RpiUninstallThemePKGToolStripMenuItem1
            // 
            RpiUninstallThemePKGToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            RpiUninstallThemePKGToolStripMenuItem1.Name = "RpiUninstallThemePKGToolStripMenuItem1";
            RpiUninstallThemePKGToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            RpiUninstallThemePKGToolStripMenuItem1.Text = "Uninstall addon PKG (Theme)";
            RpiUninstallThemePKGToolStripMenuItem1.Click += Rpi_Click;
            // 
            // darkStatusStrip1
            // 
            darkStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            darkStatusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel3, toolStripStatusLabel5, toolStripSeparator13, toolStripProgressBar1, toolStripSeparator14, toolStripStatusLabel2, labelDisplayTotalPKG, toolStripStatusLabel4 });
            darkStatusStrip1.Location = new System.Drawing.Point(0, 789);
            darkStatusStrip1.Name = "darkStatusStrip1";
            darkStatusStrip1.Padding = new Padding(0, 5, 0, 2);
            darkStatusStrip1.Size = new System.Drawing.Size(1219, 28);
            darkStatusStrip1.TabIndex = 85;
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
            // toolStripSeparator13
            // 
            toolStripSeparator13.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator13.Margin = new Padding(0, 0, 2, 0);
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new System.Drawing.Size(6, 21);
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripProgressBar1.Marquee = false;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new System.Drawing.Size(298, 19);
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripSeparator14.Margin = new Padding(0, 0, 2, 0);
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new System.Drawing.Size(6, 21);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(863, 16);
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
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(13, 16);
            toolStripStatusLabel4.Text = "  ";
            // 
            // contextMenuTrophy
            // 
            contextMenuTrophy.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuTrophy.Items.AddRange(new ToolStripItem[] { ExtractTrophyImageToolStripMenuItem });
            contextMenuTrophy.Name = "DarkContextMenu1";
            contextMenuTrophy.Size = new System.Drawing.Size(174, 26);
            // 
            // ExtractTrophyImageToolStripMenuItem
            // 
            ExtractTrophyImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ExtractTrophyImageToolStripMenuItem.Name = "ExtractTrophyImageToolStripMenuItem";
            ExtractTrophyImageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            ExtractTrophyImageToolStripMenuItem.Text = "Extract trophy icon";
            ExtractTrophyImageToolStripMenuItem.Click += ExtractTrophyImageToolStripMenuItem_Click;
            // 
            // contextMenuEntry
            // 
            contextMenuEntry.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuEntry.Items.AddRange(new ToolStripItem[] { ExtractAllEntryToolStripMenuItem, ExtractDecryptedEntryToolStripMenuItem });
            contextMenuEntry.Name = "DarkContextMenuBitmap";
            contextMenuEntry.Size = new System.Drawing.Size(211, 48);
            // 
            // ExtractAllEntryToolStripMenuItem
            // 
            ExtractAllEntryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ExtractAllEntryToolStripMenuItem.Name = "ExtractAllEntryToolStripMenuItem";
            ExtractAllEntryToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            ExtractAllEntryToolStripMenuItem.Text = "Extract all item";
            ExtractAllEntryToolStripMenuItem.Click += ExtractAllEntryToolStripMenuItem_Click;
            // 
            // ExtractDecryptedEntryToolStripMenuItem
            // 
            ExtractDecryptedEntryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ExtractDecryptedEntryToolStripMenuItem.Name = "ExtractDecryptedEntryToolStripMenuItem";
            ExtractDecryptedEntryToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            ExtractDecryptedEntryToolStripMenuItem.Text = "Extract all decrypted entry";
            ExtractDecryptedEntryToolStripMenuItem.Click += ExtractDecryptedEntryToolStripMenuItem_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new System.Drawing.Size(16, 16);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuOfficialUpdate
            // 
            contextMenuOfficialUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuOfficialUpdate.Items.AddRange(new ToolStripItem[] { copyURLToolStripMenuItem, downloadSelectedPKGUpdateToolStripMenuItem });
            contextMenuOfficialUpdate.Name = "DarkContextMenuPkgUpdate";
            contextMenuOfficialUpdate.Size = new System.Drawing.Size(215, 48);
            // 
            // copyURLToolStripMenuItem
            // 
            copyURLToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            copyURLToolStripMenuItem.Name = "copyURLToolStripMenuItem";
            copyURLToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            copyURLToolStripMenuItem.Text = "Copy all url";
            // 
            // downloadSelectedPKGUpdateToolStripMenuItem
            // 
            downloadSelectedPKGUpdateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            downloadSelectedPKGUpdateToolStripMenuItem.Name = "downloadSelectedPKGUpdateToolStripMenuItem";
            downloadSelectedPKGUpdateToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            downloadSelectedPKGUpdateToolStripMenuItem.Text = "Download selected update";
            // 
            // contextMenuBackgroundImage
            // 
            contextMenuBackgroundImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuBackgroundImage.Items.AddRange(new ToolStripItem[] { saveImageToolStripMenuItem, SetImageAsDesktopBackgroundToolStripMenuItem });
            contextMenuBackgroundImage.Name = "BitmapPIC0DarkContextMenu";
            contextMenuBackgroundImage.Size = new System.Drawing.Size(204, 48);
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            saveImageToolStripMenuItem.Text = "Save background art";
            saveImageToolStripMenuItem.Click += ContextMenuBackgroundImage_Click;
            // 
            // SetImageAsDesktopBackgroundToolStripMenuItem
            // 
            SetImageAsDesktopBackgroundToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            SetImageAsDesktopBackgroundToolStripMenuItem.Name = "SetImageAsDesktopBackgroundToolStripMenuItem";
            SetImageAsDesktopBackgroundToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            SetImageAsDesktopBackgroundToolStripMenuItem.Text = "Set as desktop wallpaper";
            SetImageAsDesktopBackgroundToolStripMenuItem.Click += ContextMenuBackgroundImage_Click;
            // 
            // contextMenuExtractNode
            // 
            contextMenuExtractNode.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuExtractNode.Items.AddRange(new ToolStripItem[] { ctxExpandNode, ctxCollapseNode, ctxTreeSeparator, expandAllToolStripMenuItem, collapseAllNodeToolStripMenuItem, extractNodeToolStripMenuItem });
            contextMenuExtractNode.Name = "DarkContextMenuExtractNode";
            contextMenuExtractNode.Size = new System.Drawing.Size(183, 121);
            // 
            // ctxExpandNode
            // 
            ctxExpandNode.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxExpandNode.Name = "ctxExpandNode";
            ctxExpandNode.Size = new System.Drawing.Size(182, 22);
            ctxExpandNode.Text = "Expand";
            ctxExpandNode.Click += CtxExpandNode_Click;
            // 
            // ctxCollapseNode
            // 
            ctxCollapseNode.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxCollapseNode.Name = "ctxCollapseNode";
            ctxCollapseNode.Size = new System.Drawing.Size(182, 22);
            ctxCollapseNode.Text = "Collapse";
            ctxCollapseNode.Click += CtxCollapseNode_Click;
            // 
            // ctxTreeSeparator
            // 
            ctxTreeSeparator.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxTreeSeparator.Margin = new Padding(0, 0, 0, 1);
            ctxTreeSeparator.Name = "ctxTreeSeparator";
            ctxTreeSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // expandAllToolStripMenuItem
            // 
            expandAllToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            expandAllToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            expandAllToolStripMenuItem.Text = "Expand all node";
            expandAllToolStripMenuItem.Click += expandAllToolStripMenuItem_Click;
            // 
            // collapseAllNodeToolStripMenuItem
            // 
            collapseAllNodeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            collapseAllNodeToolStripMenuItem.Name = "collapseAllNodeToolStripMenuItem";
            collapseAllNodeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            collapseAllNodeToolStripMenuItem.Text = "Collapse all node";
            collapseAllNodeToolStripMenuItem.Click += collapseAllNodeToolStripMenuItem_Click;
            // 
            // extractNodeToolStripMenuItem
            // 
            extractNodeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            extractNodeToolStripMenuItem.Name = "extractNodeToolStripMenuItem";
            extractNodeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            extractNodeToolStripMenuItem.Text = "Extract selected item";
            extractNodeToolStripMenuItem.Visible = false;
            extractNodeToolStripMenuItem.Click += extractToToolStripMenuItem_Click;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 123;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Type";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 123;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Path";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 123;
            // 
            // darkSectionPanel7
            // 
            darkSectionPanel7.Dock = DockStyle.Fill;
            darkSectionPanel7.Location = new System.Drawing.Point(6, 6);
            darkSectionPanel7.Margin = new Padding(6);
            darkSectionPanel7.Name = "darkSectionPanel7";
            darkSectionPanel7.Padding = new Padding(12);
            darkSectionPanel7.SectionHeader = null;
            darkSectionPanel7.Size = new System.Drawing.Size(288, 225);
            darkSectionPanel7.TabIndex = 95;
            // 
            // contextMenuExtractListView
            // 
            contextMenuExtractListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuExtractListView.Items.AddRange(new ToolStripItem[] { toolStripMenuItem32, ctxExtractFolder, ctxListSeparator, ctxCopyPath, ctxCopyName });
            contextMenuExtractListView.Name = "DarkContextMenuExtractFromListView";
            contextMenuExtractListView.Size = new System.Drawing.Size(274, 99);
            // 
            // toolStripMenuItem32
            // 
            toolStripMenuItem32.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            toolStripMenuItem32.Name = "toolStripMenuItem32";
            toolStripMenuItem32.Size = new System.Drawing.Size(273, 22);
            toolStripMenuItem32.Text = "Extract selected item";
            toolStripMenuItem32.Click += toolStripMenuItem32_Click;
            // 
            // ctxExtractFolder
            // 
            ctxExtractFolder.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxExtractFolder.Name = "ctxExtractFolder";
            ctxExtractFolder.Size = new System.Drawing.Size(273, 22);
            ctxExtractFolder.Text = "Extract selected (with folder structure)";
            ctxExtractFolder.Click += CtxExtractFolder_Click;
            // 
            // ctxListSeparator
            // 
            ctxListSeparator.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxListSeparator.Margin = new Padding(0, 0, 0, 1);
            ctxListSeparator.Name = "ctxListSeparator";
            ctxListSeparator.Size = new System.Drawing.Size(270, 6);
            // 
            // ctxCopyPath
            // 
            ctxCopyPath.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxCopyPath.Name = "ctxCopyPath";
            ctxCopyPath.Size = new System.Drawing.Size(273, 22);
            ctxCopyPath.Text = "Copy path";
            ctxCopyPath.Click += CtxCopyPath_Click;
            // 
            // ctxCopyName
            // 
            ctxCopyName.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            ctxCopyName.Name = "ctxCopyName";
            ctxCopyName.Size = new System.Drawing.Size(273, 22);
            ctxCopyName.Text = "Copy filename";
            ctxCopyName.Click += CtxCopyName_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.AllowDrop = true;
            mainTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTabControl.Controls.Add(tabPage1);
            mainTabControl.Controls.Add(tabPage2);
            mainTabControl.Controls.Add(tabPage3);
            mainTabControl.Controls.Add(tabPage4);
            mainTabControl.Controls.Add(tabPage7);
            mainTabControl.Controls.Add(_tabLog);
            mainTabControl.Controls.Add(_tasksTab);
            mainTabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            mainTabControl.ItemSize = new System.Drawing.Size(121, 28);
            mainTabControl.Location = new System.Drawing.Point(12, 38);
            mainTabControl.Margin = new Padding(3, 2, 3, 2);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.Padding = new System.Drawing.Point(0, 0);
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new System.Drawing.Size(1194, 748);
            mainTabControl.TabIndex = 91;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(darkSectionPanel10);
            tabPage1.Controls.Add(grpFilter);
            tabPage1.Controls.Add(subTabControl);
            tabPage1.Controls.Add(darkSectionPanel8);
            tabPage1.Controls.Add(darkSectionPanel9);
            tabPage1.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage1.Location = new System.Drawing.Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(12);
            tabPage1.Size = new System.Drawing.Size(1186, 712);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "PKG List";
            // 
            // darkSectionPanel10
            // 
            darkSectionPanel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            darkSectionPanel10.Controls.Add(darkDataGridView2);
            darkSectionPanel10.Location = new System.Drawing.Point(911, 389);
            darkSectionPanel10.Margin = new Padding(6);
            darkSectionPanel10.Name = "darkSectionPanel10";
            darkSectionPanel10.SectionHeader = "Param.sfo";
            darkSectionPanel10.Size = new System.Drawing.Size(259, 309);
            darkSectionPanel10.TabIndex = 90;
            // 
            // darkDataGridView2
            // 
            darkDataGridView2.AllowDrop = true;
            darkDataGridView2.AllowUserToAddRows = false;
            darkDataGridView2.AllowUserToDeleteRows = false;
            darkDataGridView2.AllowUserToDragDropRows = false;
            darkDataGridView2.AllowUserToPasteCells = false;
            darkDataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            darkDataGridView2.Dock = DockStyle.Fill;
            darkDataGridView2.Location = new System.Drawing.Point(1, 25);
            darkDataGridView2.Margin = new Padding(3, 4, 3, 4);
            darkDataGridView2.MultiSelect = false;
            darkDataGridView2.Name = "darkDataGridView2";
            darkDataGridView2.ReadOnly = true;
            darkDataGridView2.RowTemplate.Height = 23;
            darkDataGridView2.ScrollBars = ScrollBars.Horizontal;
            darkDataGridView2.Size = new System.Drawing.Size(257, 283);
            darkDataGridView2.TabIndex = 76;
            // 
            // grpFilter
            // 
            grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilter.Controls.Add(flpFilter);
            grpFilter.Controls.Add(flowChips);
            grpFilter.Controls.Add(lblFilterCount);
            grpFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            grpFilter.Location = new System.Drawing.Point(12, 18);
            grpFilter.Margin = new Padding(6);
            grpFilter.Name = "grpFilter";
            grpFilter.Padding = new Padding(12);
            grpFilter.Size = new System.Drawing.Size(884, 127);
            grpFilter.TabIndex = 92;
            grpFilter.TabStop = false;
            grpFilter.Text = "Filters";
            grpFilter.Resize += grpFilter_Resize;
            // 
            // flpFilter
            // 
            flpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpFilter.BackColor = System.Drawing.Color.Transparent;
            flpFilter.Controls.Add(lblCategory);
            flpFilter.Controls.Add(ccbCategory);
            flpFilter.Controls.Add(lblRegion);
            flpFilter.Controls.Add(ccbRegion);
            flpFilter.Controls.Add(lblFilterSysVer);
            flpFilter.Controls.Add(tbFilterSysVer);
            flpFilter.Controls.Add(lblType);
            flpFilter.Controls.Add(ccbType);
            flpFilter.Controls.Add(lblShadps4);
            flpFilter.Controls.Add(ccbShadps4);
            flpFilter.Controls.Add(chkShadps4Installed);
            flpFilter.Controls.Add(tbSearchGame);
            flpFilter.Controls.Add(btnFilterClear);
            flpFilter.Location = new System.Drawing.Point(12, 28);
            flpFilter.Name = "flpFilter";
            flpFilter.Size = new System.Drawing.Size(858, 59);
            flpFilter.TabIndex = 0;
            // 
            // lblCategory
            // 
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCategory.Location = new System.Drawing.Point(0, 5);
            lblCategory.Margin = new Padding(0, 5, 4, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(55, 15);
            lblCategory.TabIndex = 0;
            lblCategory.Text = "Category";
            // 
            // ccbCategory
            // 
            ccbCategory.ItemHeight = 18;
            ccbCategory.Items.AddRange(new object[] { "Game", "Patch", "Addon", "App", "Uknown" });
            ccbCategory.Location = new System.Drawing.Point(59, 0);
            ccbCategory.Margin = new Padding(0, 0, 12, 4);
            ccbCategory.Name = "ccbCategory";
            ccbCategory.Size = new System.Drawing.Size(150, 24);
            ccbCategory.TabIndex = 1;
            // 
            // lblRegion
            // 
            lblRegion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblRegion.Location = new System.Drawing.Point(221, 5);
            lblRegion.Margin = new Padding(0, 5, 4, 0);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new System.Drawing.Size(44, 15);
            lblRegion.TabIndex = 2;
            lblRegion.Text = "Region";
            // 
            // ccbRegion
            // 
            ccbRegion.ItemHeight = 18;
            ccbRegion.Items.AddRange(new object[] { "EU", "US", "JAPAN", "HONG_KONG", "ASIA", "KOREA" });
            ccbRegion.Location = new System.Drawing.Point(269, 0);
            ccbRegion.Margin = new Padding(0, 0, 12, 4);
            ccbRegion.Name = "ccbRegion";
            ccbRegion.Size = new System.Drawing.Size(150, 24);
            ccbRegion.TabIndex = 3;
            // 
            // lblFilterSysVer
            // 
            lblFilterSysVer.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFilterSysVer.Location = new System.Drawing.Point(431, 5);
            lblFilterSysVer.Margin = new Padding(0, 5, 4, 0);
            lblFilterSysVer.Name = "lblFilterSysVer";
            lblFilterSysVer.Size = new System.Drawing.Size(107, 15);
            lblFilterSysVer.TabIndex = 4;
            lblFilterSysVer.Text = "Required Firmware ≥";
            // 
            // tbFilterSysVer
            // 
            tbFilterSysVer.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbFilterSysVer.Location = new System.Drawing.Point(542, 0);
            tbFilterSysVer.Margin = new Padding(0, 0, 12, 4);
            tbFilterSysVer.Name = "tbFilterSysVer";
            tbFilterSysVer.Size = new System.Drawing.Size(55, 23);
            tbFilterSysVer.TabIndex = 5;
            tbFilterSysVer.TextChanged += tbFilterSysVer_TextChanged;
            // 
            // lblType
            // 
            lblType.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblType.Location = new System.Drawing.Point(609, 5);
            lblType.Margin = new Padding(0, 5, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(32, 15);
            lblType.TabIndex = 6;
            lblType.Text = "Type";
            // 
            // ccbType
            // 
            ccbType.ItemHeight = 18;
            ccbType.Items.AddRange(new object[] { "Official", "Fake" });
            ccbType.Location = new System.Drawing.Point(645, 0);
            ccbType.Margin = new Padding(0, 0, 12, 4);
            ccbType.Name = "ccbType";
            ccbType.Size = new System.Drawing.Size(135, 24);
            ccbType.TabIndex = 7;
            // 
            // lblShadps4
            // 
            lblShadps4.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblShadps4.Location = new System.Drawing.Point(792, 5);
            lblShadps4.Margin = new Padding(0, 5, 4, 0);
            lblShadps4.Name = "lblShadps4";
            lblShadps4.Size = new System.Drawing.Size(132, 15);
            lblShadps4.TabIndex = 8;
            lblShadps4.Text = "ShadPS4 Compatibility";
            // 
            // ccbShadps4
            // 
            ccbShadps4.ItemHeight = 18;
            ccbShadps4.Items.AddRange(new object[] { "Playable", "In-Game", "Menus", "Boots", "Nothing", "Unknown" });
            ccbShadps4.Location = new System.Drawing.Point(0, 28);
            ccbShadps4.Margin = new Padding(0, 0, 12, 4);
            ccbShadps4.Name = "ccbShadps4";
            ccbShadps4.Size = new System.Drawing.Size(150, 24);
            ccbShadps4.TabIndex = 9;
            // 
            // chkShadps4Installed
            // 
            chkShadps4Installed.AutoSize = true;
            chkShadps4Installed.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkShadps4Installed.Location = new System.Drawing.Point(162, 31);
            chkShadps4Installed.Margin = new Padding(0, 3, 12, 4);
            chkShadps4Installed.Name = "chkShadps4Installed";
            chkShadps4Installed.Size = new System.Drawing.Size(129, 19);
            chkShadps4Installed.TabIndex = 10;
            chkShadps4Installed.Text = "ShadPS4 Installed";
            chkShadps4Installed.CheckedChanged += chkShadps4Installed_CheckedChanged;
            // 
            // tbSearchGame
            // 
            tbSearchGame.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbSearchGame.Location = new System.Drawing.Point(162, 28);
            tbSearchGame.Margin = new Padding(0, 0, 12, 4);
            tbSearchGame.Name = "tbSearchGame";
            tbSearchGame.Placeholder = "[Filename]/[Title]/[ID]";
            tbSearchGame.Size = new System.Drawing.Size(296, 24);
            tbSearchGame.TabIndex = 86;
            tbSearchGame.SearchTextChanged += TbSearchGame_TextChanged;
            // 
            // btnFilterClear
            // 
            btnFilterClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnFilterClear.Location = new System.Drawing.Point(470, 28);
            btnFilterClear.Margin = new Padding(0, 0, 0, 4);
            btnFilterClear.Name = "btnFilterClear";
            btnFilterClear.Size = new System.Drawing.Size(64, 24);
            btnFilterClear.TabIndex = 87;
            btnFilterClear.Text = "Clear";
            btnFilterClear.Click += btnFilterClear_Click;
            // 
            // flowChips
            // 
            flowChips.Location = new System.Drawing.Point(12, 85);
            flowChips.Name = "flowChips";
            flowChips.Padding = new Padding(2);
            flowChips.Size = new System.Drawing.Size(838, 30);
            flowChips.TabIndex = 10;
            // 
            // lblFilterCount
            // 
            lblFilterCount.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblFilterCount.Location = new System.Drawing.Point(555, 74);
            lblFilterCount.Name = "lblFilterCount";
            lblFilterCount.Size = new System.Drawing.Size(104, 15);
            lblFilterCount.TabIndex = 7;
            // 
            // subTabControl
            // 
            subTabControl.AllowDrop = true;
            subTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            subTabControl.Controls.Add(tabPageTable);
            subTabControl.Controls.Add(tabPageGroup);
            subTabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            subTabControl.ItemSize = new System.Drawing.Size(84, 28);
            subTabControl.Location = new System.Drawing.Point(12, 157);
            subTabControl.Margin = new Padding(6);
            subTabControl.Name = "subTabControl";
            subTabControl.Padding = new System.Drawing.Point(0, 0);
            subTabControl.SelectedIndex = 0;
            subTabControl.Size = new System.Drawing.Size(884, 541);
            subTabControl.TabIndex = 92;
            subTabControl.SelectedIndexChanged += SubTabControl_SelectedIndexChanged;
            // 
            // tabPageTable
            // 
            tabPageTable.Controls.Add(PKGGridView);
            tabPageTable.ForeColor = System.Drawing.Color.Gainsboro;
            tabPageTable.Location = new System.Drawing.Point(4, 32);
            tabPageTable.Name = "tabPageTable";
            tabPageTable.Size = new System.Drawing.Size(876, 505);
            tabPageTable.TabIndex = 0;
            tabPageTable.Text = "Table";
            // 
            // PKGGridView
            // 
            PKGGridView.AllowDrop = true;
            PKGGridView.AllowUserToAddRows = false;
            PKGGridView.AllowUserToDeleteRows = false;
            PKGGridView.AllowUserToDragDropRows = false;
            PKGGridView.AllowUserToPasteCells = false;
            PKGGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PKGGridView.ContextMenuStrip = contextMenuPKGGridView;
            PKGGridView.Dock = DockStyle.Fill;
            PKGGridView.Location = new System.Drawing.Point(0, 0);
            PKGGridView.MultiSelect = true;
            PKGGridView.Name = "PKGGridView";
            PKGGridView.ReadOnly = true;
            PKGGridView.RowTemplate.Height = 23;
            PKGGridView.ScrollBars = ScrollBars.Vertical;
            PKGGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PKGGridView.Size = new System.Drawing.Size(876, 505);
            PKGGridView.TabIndex = 75;
            PKGGridView.CellFormatting += PKGListGridView_CellFormatting;
            PKGGridView.ColumnHeaderMouseClick += PKGListGridView_ColumnHeaderMouseClick;
            PKGGridView.DataError += PKGGridView_DataError;
            PKGGridView.SelectionChanged += PKGListGridView_SelectionChanged;
            PKGGridView.DragDrop += PKGGridView_DragDrop;
            PKGGridView.DragEnter += PKGGridView_DragEnter;
            PKGGridView.MouseDown += PKGGridView_MouseDown;
            // 
            // tabPageGroup
            // 
            tabPageGroup.Controls.Add(groupedListView);
            tabPageGroup.Controls.Add(btnGroupExpand);
            tabPageGroup.Controls.Add(cbGroupBy);
            tabPageGroup.Controls.Add(darkLabelGroupBy);
            tabPageGroup.Controls.Add(darkLabelGroupCount);
            tabPageGroup.Controls.Add(lblGlvFilterHint);
            tabPageGroup.ForeColor = System.Drawing.Color.Gainsboro;
            tabPageGroup.Location = new System.Drawing.Point(4, 32);
            tabPageGroup.Name = "tabPageGroup";
            tabPageGroup.Size = new System.Drawing.Size(876, 505);
            tabPageGroup.TabIndex = 1;
            tabPageGroup.Text = "Grouped";
            // 
            // groupedListView
            // 
            groupedListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupedListView.ContextMenuStrip = contextMenuGLV;
            groupedListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            groupedListView.Location = new System.Drawing.Point(0, 30);
            groupedListView.MultiSelect = false;
            groupedListView.Name = "groupedListView";
            groupedListView.Size = new System.Drawing.Size(882, 474);
            groupedListView.TabIndex = 0;
            groupedListView.SelectedItemChanged += GroupedListView_SelectedItemChanged;
            // 
            // contextMenuGLV
            // 
            contextMenuGLV.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenuGLV.Name = "contextMenuGLV";
            contextMenuGLV.Size = new System.Drawing.Size(61, 4);
            contextMenuGLV.Opening += ContextMenuGLV_Opening;
            // 
            // btnGroupExpand
            // 
            btnGroupExpand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGroupExpand.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnGroupExpand.Location = new System.Drawing.Point(788, 4);
            btnGroupExpand.Margin = new Padding(0, 2, 3, 2);
            btnGroupExpand.Name = "btnGroupExpand";
            btnGroupExpand.Size = new System.Drawing.Size(89, 23);
            btnGroupExpand.TabIndex = 103;
            btnGroupExpand.Text = "Expand All";
            btnGroupExpand.Click += BtnGroupExpand_Click;
            // 
            // cbGroupBy
            // 
            cbGroupBy.DropDownWidth = 185;
            cbGroupBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbGroupBy.Items.AddRange(new object[] { "Title", "Title ID", "Required Firmware", "PKG Type", "Category", "ShadPS4" });
            cbGroupBy.Location = new System.Drawing.Point(62, 3);
            cbGroupBy.Name = "cbGroupBy";
            cbGroupBy.SelectedIndex = 1;
            cbGroupBy.Size = new System.Drawing.Size(185, 24);
            cbGroupBy.TabIndex = 105;
            cbGroupBy.SelectedIndexChanged += CbGroupBy_SelectedIndexChanged;
            // 
            // darkLabelGroupBy
            // 
            darkLabelGroupBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelGroupBy.Location = new System.Drawing.Point(4, 8);
            darkLabelGroupBy.Name = "darkLabelGroupBy";
            darkLabelGroupBy.Size = new System.Drawing.Size(55, 15);
            darkLabelGroupBy.TabIndex = 106;
            darkLabelGroupBy.Text = "Group by:";
            // 
            // darkLabelGroupCount
            // 
            darkLabelGroupCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabelGroupCount.Location = new System.Drawing.Point(252, 7);
            darkLabelGroupCount.Name = "darkLabelGroupCount";
            darkLabelGroupCount.Size = new System.Drawing.Size(60, 15);
            darkLabelGroupCount.TabIndex = 107;
            // 
            // lblGlvFilterHint
            // 
            lblGlvFilterHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblGlvFilterHint.Location = new System.Drawing.Point(320, 7);
            lblGlvFilterHint.Name = "lblGlvFilterHint";
            lblGlvFilterHint.Size = new System.Drawing.Size(200, 15);
            lblGlvFilterHint.TabIndex = 108;
            // 
            // darkSectionPanel8
            // 
            darkSectionPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            darkSectionPanel8.Controls.Add(panel5);
            darkSectionPanel8.Location = new System.Drawing.Point(910, 18);
            darkSectionPanel8.Margin = new Padding(6);
            darkSectionPanel8.Name = "darkSectionPanel8";
            darkSectionPanel8.SectionHeader = "Avatar";
            darkSectionPanel8.Size = new System.Drawing.Size(260, 272);
            darkSectionPanel8.TabIndex = 88;
            darkSectionPanel8.Tag = "";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(pictureBox1);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(1, 25);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(258, 246);
            panel5.TabIndex = 79;
            panel5.Paint += panel5_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(256, 244);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 59;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(4, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(249, 46);
            label3.TabIndex = 70;
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkSectionPanel9
            // 
            darkSectionPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            darkSectionPanel9.Controls.Add(panel1);
            darkSectionPanel9.Location = new System.Drawing.Point(910, 302);
            darkSectionPanel9.Margin = new Padding(6);
            darkSectionPanel9.Name = "darkSectionPanel9";
            darkSectionPanel9.SectionHeader = "Title";
            darkSectionPanel9.Size = new System.Drawing.Size(259, 75);
            darkSectionPanel9.TabIndex = 89;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(darkLabel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(1, 25);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(257, 49);
            panel1.TabIndex = 70;
            // 
            // darkLabel1
            // 
            darkLabel1.BackColor = System.Drawing.Color.Transparent;
            darkLabel1.Dock = DockStyle.Fill;
            darkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel1.Location = new System.Drawing.Point(0, 0);
            darkLabel1.Name = "darkLabel1";
            darkLabel1.Size = new System.Drawing.Size(255, 47);
            darkLabel1.TabIndex = 69;
            darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TrophyGridView);
            tabPage2.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage2.Location = new System.Drawing.Point(4, 32);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new System.Drawing.Size(1186, 712);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Trophy";
            // 
            // TrophyGridView
            // 
            TrophyGridView.AllowUserToAddRows = false;
            TrophyGridView.AllowUserToDeleteRows = false;
            TrophyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TrophyGridView.ContextMenuStrip = contextMenuTrophy;
            TrophyGridView.Dock = DockStyle.Fill;
            TrophyGridView.Location = new System.Drawing.Point(3, 2);
            TrophyGridView.Margin = new Padding(3, 4, 3, 4);
            TrophyGridView.MultiSelect = false;
            TrophyGridView.Name = "TrophyGridView";
            TrophyGridView.ReadOnly = true;
            TrophyGridView.RowTemplate.Height = 23;
            TrophyGridView.ScrollBars = ScrollBars.Horizontal;
            TrophyGridView.Size = new System.Drawing.Size(1180, 708);
            TrophyGridView.TabIndex = 76;
            TrophyGridView.SelectionChanged += darkDataGridView3_SelectionChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(flatTabControlBgi);
            tabPage3.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage3.Location = new System.Drawing.Point(4, 32);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(12);
            tabPage3.Size = new System.Drawing.Size(1186, 712);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Background Art";
            // 
            // flatTabControlBgi
            // 
            flatTabControlBgi.AllowDrop = true;
            flatTabControlBgi.Controls.Add(tabPagePic0);
            flatTabControlBgi.Controls.Add(tabPagePic1);
            flatTabControlBgi.Dock = DockStyle.Fill;
            flatTabControlBgi.Font = new System.Drawing.Font("Segoe UI", 9F);
            flatTabControlBgi.ItemSize = new System.Drawing.Size(87, 28);
            flatTabControlBgi.Location = new System.Drawing.Point(12, 12);
            flatTabControlBgi.Margin = new Padding(3, 2, 3, 2);
            flatTabControlBgi.Name = "flatTabControlBgi";
            flatTabControlBgi.Padding = new System.Drawing.Point(0, 0);
            flatTabControlBgi.SelectedIndex = 0;
            flatTabControlBgi.Size = new System.Drawing.Size(1162, 688);
            flatTabControlBgi.TabIndex = 91;
            // 
            // tabPagePic0
            // 
            tabPagePic0.Controls.Add(pbPIC0);
            tabPagePic0.Location = new System.Drawing.Point(4, 32);
            tabPagePic0.Margin = new Padding(3, 2, 3, 2);
            tabPagePic0.Name = "tabPagePic0";
            tabPagePic0.Padding = new Padding(3, 2, 3, 2);
            tabPagePic0.Size = new System.Drawing.Size(1154, 652);
            tabPagePic0.TabIndex = 0;
            tabPagePic0.Text = "PIC0.PNG";
            // 
            // pbPIC0
            // 
            pbPIC0.BackColor = System.Drawing.Color.Transparent;
            pbPIC0.Dock = DockStyle.Fill;
            pbPIC0.Location = new System.Drawing.Point(3, 2);
            pbPIC0.Margin = new Padding(3, 2, 3, 2);
            pbPIC0.Name = "pbPIC0";
            pbPIC0.Size = new System.Drawing.Size(1148, 648);
            pbPIC0.SizeMode = PictureBoxSizeMode.Zoom;
            pbPIC0.TabIndex = 0;
            pbPIC0.TabStop = false;
            // 
            // tabPagePic1
            // 
            tabPagePic1.Controls.Add(pbPIC1);
            tabPagePic1.Location = new System.Drawing.Point(4, 32);
            tabPagePic1.Margin = new Padding(3, 2, 3, 2);
            tabPagePic1.Name = "tabPagePic1";
            tabPagePic1.Padding = new Padding(3, 2, 3, 2);
            tabPagePic1.Size = new System.Drawing.Size(1154, 652);
            tabPagePic1.TabIndex = 1;
            tabPagePic1.Text = "PIC1.PNG";
            // 
            // pbPIC1
            // 
            pbPIC1.BackColor = System.Drawing.Color.Transparent;
            pbPIC1.Dock = DockStyle.Fill;
            pbPIC1.Location = new System.Drawing.Point(3, 2);
            pbPIC1.Margin = new Padding(3, 2, 3, 2);
            pbPIC1.Name = "pbPIC1";
            pbPIC1.Size = new System.Drawing.Size(1148, 648);
            pbPIC1.TabIndex = 0;
            pbPIC1.TabStop = false;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(panel7);
            tabPage4.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage4.Location = new System.Drawing.Point(4, 32);
            tabPage4.Margin = new Padding(3, 2, 3, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(12);
            tabPage4.Size = new System.Drawing.Size(1186, 712);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "PKG Internals";
            // 
            // panel7
            // 
            panel7.Controls.Add(darkSectionPanel2);
            panel7.Controls.Add(darkSectionPanel3);
            panel7.Controls.Add(darkSectionPanel1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(12, 12);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(1162, 688);
            panel7.TabIndex = 98;
            // 
            // darkSectionPanel2
            // 
            darkSectionPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            darkSectionPanel2.Controls.Add(dgvEntryList);
            darkSectionPanel2.Location = new System.Drawing.Point(255, 92);
            darkSectionPanel2.Margin = new Padding(3, 2, 3, 2);
            darkSectionPanel2.Name = "darkSectionPanel2";
            darkSectionPanel2.SectionHeader = "Entry List";
            darkSectionPanel2.Size = new System.Drawing.Size(907, 597);
            darkSectionPanel2.TabIndex = 95;
            // 
            // dgvEntryList
            // 
            dgvEntryList.AllowUserToAddRows = false;
            dgvEntryList.AllowUserToDeleteRows = false;
            dgvEntryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntryList.ContextMenuStrip = contextMenuEntry;
            dgvEntryList.Dock = DockStyle.Fill;
            dgvEntryList.Location = new System.Drawing.Point(1, 25);
            dgvEntryList.Margin = new Padding(3, 4, 3, 4);
            dgvEntryList.MultiSelect = false;
            dgvEntryList.Name = "dgvEntryList";
            dgvEntryList.ReadOnly = true;
            dgvEntryList.RowTemplate.Height = 23;
            dgvEntryList.Size = new System.Drawing.Size(905, 571);
            dgvEntryList.TabIndex = 77;
            dgvEntryList.SelectionChanged += dgvEntryList_SelectionChanged;
            // 
            // darkSectionPanel3
            // 
            darkSectionPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            darkSectionPanel3.Controls.Add(darkDataGridView4);
            darkSectionPanel3.Location = new System.Drawing.Point(255, 0);
            darkSectionPanel3.Margin = new Padding(3, 2, 3, 2);
            darkSectionPanel3.Name = "darkSectionPanel3";
            darkSectionPanel3.SectionHeader = "Build Information";
            darkSectionPanel3.Size = new System.Drawing.Size(907, 76);
            darkSectionPanel3.TabIndex = 95;
            // 
            // darkDataGridView4
            // 
            darkDataGridView4.AllowUserToAddRows = false;
            darkDataGridView4.AllowUserToDeleteRows = false;
            darkDataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            darkDataGridView4.Dock = DockStyle.Fill;
            darkDataGridView4.Location = new System.Drawing.Point(1, 25);
            darkDataGridView4.Margin = new Padding(3, 4, 3, 4);
            darkDataGridView4.MultiSelect = false;
            darkDataGridView4.Name = "darkDataGridView4";
            darkDataGridView4.ReadOnly = true;
            darkDataGridView4.RowTemplate.Height = 23;
            darkDataGridView4.ScrollBars = ScrollBars.Horizontal;
            darkDataGridView4.Size = new System.Drawing.Size(905, 50);
            darkDataGridView4.TabIndex = 78;
            darkDataGridView4.SelectionChanged += darkDataGridView4_SelectionChanged;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(dgvHeader);
            darkSectionPanel1.Dock = DockStyle.Left;
            darkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            darkSectionPanel1.Margin = new Padding(3, 2, 3, 2);
            darkSectionPanel1.Name = "darkSectionPanel1";
            darkSectionPanel1.SectionHeader = "Advanced PKG Header";
            darkSectionPanel1.Size = new System.Drawing.Size(240, 688);
            darkSectionPanel1.TabIndex = 94;
            // 
            // dgvHeader
            // 
            dgvHeader.AllowUserToAddRows = false;
            dgvHeader.AllowUserToDeleteRows = false;
            dgvHeader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHeader.Dock = DockStyle.Fill;
            dgvHeader.Location = new System.Drawing.Point(1, 25);
            dgvHeader.Margin = new Padding(3, 4, 3, 4);
            dgvHeader.MultiSelect = false;
            dgvHeader.Name = "dgvHeader";
            dgvHeader.ReadOnly = true;
            dgvHeader.RowTemplate.Height = 23;
            dgvHeader.Size = new System.Drawing.Size(238, 662);
            dgvHeader.TabIndex = 76;
            dgvHeader.SelectionChanged += dgvHeader_SelectionChanged;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(panel6);
            tabPage7.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage7.Location = new System.Drawing.Point(4, 32);
            tabPage7.Margin = new Padding(3, 2, 3, 2);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3, 2, 3, 2);
            tabPage7.Size = new System.Drawing.Size(1186, 712);
            tabPage7.TabIndex = 5;
            tabPage7.Text = "File Browser";
            // 
            // panel6
            // 
            panel6.Controls.Add(darkSplitContainer1);
            panel6.Controls.Add(darkHeaderBar1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(3, 2);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(1180, 708);
            panel6.TabIndex = 97;
            // 
            // darkSplitContainer1
            // 
            darkSplitContainer1.Controls.Add(splitPane1);
            darkSplitContainer1.Controls.Add(splitPane2);
            darkSplitContainer1.Controls.Add(splitPane3);
            darkSplitContainer1.Dock = DockStyle.Fill;
            darkSplitContainer1.Location = new System.Drawing.Point(0, 50);
            darkSplitContainer1.Name = "darkSplitContainer1";
            darkSplitContainer1.Size = new System.Drawing.Size(1180, 658);
            darkSplitContainer1.TabIndex = 104;
            // 
            // splitPane1
            // 
            splitPane1.Controls.Add(PKGTreeView);
            splitPane1.Location = new System.Drawing.Point(0, 0);
            splitPane1.Name = "splitPane1";
            splitPane1.Size = new System.Drawing.Size(390, 658);
            splitPane1.TabIndex = 0;
            // 
            // PKGTreeView
            // 
            PKGTreeView.CheckBoxes = false;
            PKGTreeView.Dock = DockStyle.Fill;
            PKGTreeView.FullRowSelect = false;
            PKGTreeView.HotTracking = false;
            PKGTreeView.ImageList = null;
            PKGTreeView.Indent = 19;
            PKGTreeView.ItemHeight = 24;
            PKGTreeView.LabelEdit = false;
            PKGTreeView.Location = new System.Drawing.Point(0, 0);
            PKGTreeView.Margin = new Padding(3, 4, 3, 4);
            PKGTreeView.Name = "PKGTreeView";
            PKGTreeView.PathSeparator = "\\";
            PKGTreeView.Scrollable = true;
            PKGTreeView.SelectedNode = null;
            PKGTreeView.ShowLines = true;
            PKGTreeView.ShowPlusMinus = true;
            PKGTreeView.ShowRootLines = true;
            PKGTreeView.Size = new System.Drawing.Size(390, 658);
            PKGTreeView.Sorted = false;
            PKGTreeView.TabIndex = 0;
            PKGTreeView.TopNode = null;
            PKGTreeView.TreeViewNodeSorter = null;
            PKGTreeView.UseCompatibleStateImageBehavior = false;
            PKGTreeView.AfterSelect += PKGTreeView_AfterSelect;
            PKGTreeView.NodeMouseClick += PKGTreeView_NodeMouseClick;
            PKGTreeView.MouseClick += PKGTreeView_MouseClick;
            PKGTreeView.ItemDrag += PKGTreeView_ItemDrag;
            // 
            // splitPane2
            // 
            splitPane2.Controls.Add(listView1);
            splitPane2.Controls.Add(tbFilterTreeView);
            splitPane2.Location = new System.Drawing.Point(395, 0);
            splitPane2.Name = "splitPane2";
            splitPane2.Size = new System.Drawing.Size(390, 658);
            splitPane2.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.LargeImageList = imageList1;
            listView1.ListViewItemSorter = null;
            listView1.Location = new System.Drawing.Point(0, 28);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.MultiSelect = true;
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(390, 630);
            listView1.SmallImageList = null;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ColumnWidthChanging += listView1_ColumnWidthChanging;
            listView1.ItemActivate += listView1_ItemActivate;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            listView1.ItemDrag += listView1_ItemDrag;
            listView1.MouseClick += listView1_MouseClick;
            listView1.SizeChanged += listView1_SizeChanged;
            // 
            // tbFilterTreeView
            // 
            tbFilterTreeView.Dock = DockStyle.Top;
            tbFilterTreeView.Location = new System.Drawing.Point(0, 0);
            tbFilterTreeView.Margin = new Padding(3, 2, 3, 2);
            tbFilterTreeView.Name = "tbFilterTreeView";
            tbFilterTreeView.Placeholder = "Filter filename here";
            tbFilterTreeView.Size = new System.Drawing.Size(390, 28);
            tbFilterTreeView.TabIndex = 100;
            tbFilterTreeView.SearchTextChanged += TbFilterTreeView_SearchTextChanged;
            // 
            // splitPane3
            // 
            splitPane3.Controls.Add(sectionFileViewer);
            splitPane3.Location = new System.Drawing.Point(790, 0);
            splitPane3.Name = "splitPane3";
            splitPane3.Size = new System.Drawing.Size(390, 658);
            splitPane3.TabIndex = 3;
            // 
            // sectionFileViewer
            // 
            sectionFileViewer.Controls.Add(btnExportTextures);
            sectionFileViewer.Controls.Add(btnAssetBack);
            sectionFileViewer.Controls.Add(fileViewerBody);
            sectionFileViewer.Controls.Add(lblFileViewerInfo);
            sectionFileViewer.Dock = DockStyle.Fill;
            sectionFileViewer.Location = new System.Drawing.Point(0, 0);
            sectionFileViewer.Margin = new Padding(6);
            sectionFileViewer.Name = "sectionFileViewer";
            sectionFileViewer.SectionHeader = "File Viewer";
            sectionFileViewer.Size = new System.Drawing.Size(390, 658);
            sectionFileViewer.TabIndex = 2;
            // 
            // btnAssetBack
            // 
            btnAssetBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAssetBack.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnAssetBack.Location = new System.Drawing.Point(304, 30);
            btnAssetBack.Margin = new Padding(3, 2, 3, 2);
            btnAssetBack.Name = "btnAssetBack";
            btnAssetBack.Size = new System.Drawing.Size(70, 24);
            btnAssetBack.TabIndex = 3;
            btnAssetBack.Text = "Back to list";
            btnAssetBack.Visible = false;
            btnAssetBack.Click += btnAssetBack_Click;
            // 
            // btnExportTextures
            // 
            btnExportTextures.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportTextures.Font = new System.Drawing.Font("Segoe UI", 8F);
            btnExportTextures.Location = new System.Drawing.Point(196, 30);
            btnExportTextures.Margin = new Padding(3, 2, 3, 2);
            btnExportTextures.Name = "btnExportTextures";
            btnExportTextures.Size = new System.Drawing.Size(104, 24);
            btnExportTextures.TabIndex = 4;
            btnExportTextures.Text = "Export Textures";
            btnExportTextures.Visible = false;
            btnExportTextures.Click += btnExportTextures_Click;
            // 
            // fileViewerBody
            // 
            fileViewerBody.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            fileViewerBody.Controls.Add(assetListView);
            fileViewerBody.Controls.Add(picPreview);
            fileViewerBody.Controls.Add(txtPreview);
            fileViewerBody.Controls.Add(txtHexPreview);
            fileViewerBody.Dock = DockStyle.Fill;
            fileViewerBody.Location = new System.Drawing.Point(1, 59);
            fileViewerBody.Name = "fileViewerBody";
            fileViewerBody.Padding = new Padding(1);
            fileViewerBody.Size = new System.Drawing.Size(388, 598);
            fileViewerBody.TabIndex = 0;
            // 
            // assetListView
            // 
            assetListView.Dock = DockStyle.Fill;
            assetListView.FullRowSelect = true;
            assetListView.HeaderStyle = ColumnHeaderStyle.Clickable;
            assetListView.LargeImageList = null;
            assetListView.ListViewItemSorter = null;
            assetListView.Columns.AddRange(new ColumnHeader[] { assetNameColumn, assetTypeColumn, assetSizeColumn });
            assetListView.Location = new System.Drawing.Point(1, 1);
            assetListView.MultiSelect = false;
            assetListView.Name = "assetListView";
            assetListView.Size = new System.Drawing.Size(386, 596);
            assetListView.SmallImageList = null;
            assetListView.TabIndex = 0;
            assetListView.UseCompatibleStateImageBehavior = false;
            assetListView.View = View.Details;
            assetListView.Visible = false;
            assetListView.DoubleClick += assetListView_DoubleClick;
            // 
            // picPreview
            // 
            picPreview.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            picPreview.Dock = DockStyle.Fill;
            picPreview.Location = new System.Drawing.Point(1, 1);
            picPreview.Name = "picPreview";
            picPreview.Size = new System.Drawing.Size(386, 596);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 0;
            picPreview.TabStop = false;
            picPreview.Visible = false;
            // 
            // txtPreview
            // 
            txtPreview.BorderStyle = BorderStyle.None;
            txtPreview.Dock = DockStyle.Fill;
            txtPreview.Font = new System.Drawing.Font("Consolas", 9F);
            txtPreview.HideSelection = false;
            txtPreview.Location = new System.Drawing.Point(1, 1);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Both;
            txtPreview.Size = new System.Drawing.Size(386, 596);
            txtPreview.TabIndex = 1;
            txtPreview.Visible = false;
            txtPreview.WordWrap = false;
            // 
            // txtHexPreview
            // 
            txtHexPreview.BorderStyle = BorderStyle.None;
            txtHexPreview.Dock = DockStyle.Fill;
            txtHexPreview.Font = new System.Drawing.Font("Consolas", 9F);
            txtHexPreview.HideSelection = false;
            txtHexPreview.Location = new System.Drawing.Point(1, 1);
            txtHexPreview.Multiline = true;
            txtHexPreview.Name = "txtHexPreview";
            txtHexPreview.ReadOnly = true;
            txtHexPreview.ScrollBars = ScrollBars.Both;
            txtHexPreview.Size = new System.Drawing.Size(386, 596);
            txtHexPreview.TabIndex = 2;
            txtHexPreview.Visible = false;
            txtHexPreview.WordWrap = false;
            // 
            // lblFileViewerInfo
            // 
            lblFileViewerInfo.AutoEllipsis = true;
            lblFileViewerInfo.Dock = DockStyle.Top;
            lblFileViewerInfo.Location = new System.Drawing.Point(1, 25);
            lblFileViewerInfo.Name = "lblFileViewerInfo";
            lblFileViewerInfo.Padding = new Padding(8, 0, 8, 0);
            lblFileViewerInfo.Size = new System.Drawing.Size(388, 34);
            lblFileViewerInfo.TabIndex = 1;
            lblFileViewerInfo.Text = "Select a file to preview it.";
            lblFileViewerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // darkHeaderBar1
            // 
            darkHeaderBar1.Controls.Add(darkLabel5);
            darkHeaderBar1.Controls.Add(tbPasscode);
            darkHeaderBar1.Controls.Add(btnExportTreeView);
            darkHeaderBar1.Controls.Add(btnExtractFullPKG);
            darkHeaderBar1.Controls.Add(btnViewPKGData);
            darkHeaderBar1.Dock = DockStyle.Top;
            darkHeaderBar1.Location = new System.Drawing.Point(0, 0);
            darkHeaderBar1.Name = "darkHeaderBar1";
            darkHeaderBar1.ShowThemeSelector = false;
            darkHeaderBar1.Size = new System.Drawing.Size(1180, 50);
            darkHeaderBar1.TabIndex = 103;
            darkHeaderBar1.Text = "darkHeaderBar1";
            // 
            // darkLabel5
            // 
            darkLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            darkLabel5.Location = new System.Drawing.Point(3, 15);
            darkLabel5.Name = "darkLabel5";
            darkLabel5.Size = new System.Drawing.Size(59, 15);
            darkLabel5.TabIndex = 96;
            darkLabel5.Text = "Passcode:";
            // 
            // tbPasscode
            // 
            tbPasscode.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbPasscode.Location = new System.Drawing.Point(69, 11);
            tbPasscode.Margin = new Padding(3, 2, 3, 2);
            tbPasscode.MaxLength = 32;
            tbPasscode.Multiline = true;
            tbPasscode.Name = "tbPasscode";
            tbPasscode.ReadOnly = true;
            tbPasscode.Size = new System.Drawing.Size(219, 23);
            tbPasscode.TabIndex = 0;
            tbPasscode.Text = "00000000000000000000000000000000";
            tbPasscode.TextAlign = HorizontalAlignment.Center;
            // 
            // btnExportTreeView
            // 
            btnExportTreeView.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExportTreeView.Location = new System.Drawing.Point(419, 11);
            btnExportTreeView.Margin = new Padding(3, 2, 3, 2);
            btnExportTreeView.Name = "btnExportTreeView";
            btnExportTreeView.Size = new System.Drawing.Size(108, 23);
            btnExportTreeView.TabIndex = 101;
            btnExportTreeView.Text = "Export Tree View";
            btnExportTreeView.Click += btnExportTreeView_Click;
            // 
            // btnExtractFullPKG
            // 
            btnExtractFullPKG.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnExtractFullPKG.Location = new System.Drawing.Point(533, 11);
            btnExtractFullPKG.Margin = new Padding(3, 2, 3, 2);
            btnExtractFullPKG.Name = "btnExtractFullPKG";
            btnExtractFullPKG.Size = new System.Drawing.Size(108, 23);
            btnExtractFullPKG.TabIndex = 100;
            btnExtractFullPKG.Text = "Extract full PKG";
            btnExtractFullPKG.Click += btnExtractFullPKG_Click;
            // 
            // btnViewPKGData
            // 
            btnViewPKGData.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnViewPKGData.Location = new System.Drawing.Point(294, 11);
            btnViewPKGData.Margin = new Padding(3, 2, 3, 2);
            btnViewPKGData.Name = "btnViewPKGData";
            btnViewPKGData.Size = new System.Drawing.Size(119, 23);
            btnViewPKGData.TabIndex = 94;
            btnViewPKGData.Text = "View PKG files";
            btnViewPKGData.Click += btnViewPKGData_Click;
            // 
            // _tabLog
            // 
            _tabLog.Controls.Add(_tbLogBox);
            _tabLog.Location = new System.Drawing.Point(4, 32);
            _tabLog.Name = "_tabLog";
            _tabLog.Size = new System.Drawing.Size(1186, 712);
            _tabLog.TabIndex = 7;
            _tabLog.Text = "Log";
            // 
            // _tbLogBox
            // 
            _tbLogBox.Dock = DockStyle.Fill;
            _tbLogBox.Font = new System.Drawing.Font("Consolas", 9F);
            _tbLogBox.Location = new System.Drawing.Point(0, 0);
            _tbLogBox.Multiline = true;
            _tbLogBox.Name = "_tbLogBox";
            _tbLogBox.ReadOnly = true;
            _tbLogBox.ScrollBars = ScrollBars.Vertical;
            _tbLogBox.Size = new System.Drawing.Size(1186, 712);
            _tbLogBox.TabIndex = 0;
            // 
            // _tasksTab
            // 
            _tasksTab.Controls.Add(_tasksGrid);
            _tasksTab.Controls.Add(taskDetailsLayout);
            _tasksTab.Controls.Add(tasksToolbar);
            _tasksTab.ForeColor = System.Drawing.Color.Gainsboro;
            _tasksTab.Location = new System.Drawing.Point(4, 32);
            _tasksTab.Name = "_tasksTab";
            _tasksTab.Padding = new Padding(12);
            _tasksTab.Size = new System.Drawing.Size(1186, 712);
            _tasksTab.TabIndex = 7;
            _tasksTab.Text = "Tasks";
            // 
            // _tasksGrid
            // 
            _tasksGrid.AllowUserToAddRows = false;
            _tasksGrid.AllowUserToDeleteRows = false;
            _tasksGrid.AllowUserToDragDropRows = false;
            _tasksGrid.AllowUserToResizeColumns = true;
            _tasksGrid.AutoGenerateColumns = false;
            _tasksGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _tasksGrid.Columns.AddRange(new DataGridViewColumn[] { taskTypeColumn, taskNameColumn, taskStatusColumn, taskProgressColumn });
            _tasksGrid.Dock = DockStyle.Fill;
            _tasksGrid.Location = new System.Drawing.Point(12, 52);
            _tasksGrid.MultiSelect = false;
            _tasksGrid.Name = "_tasksGrid";
            _tasksGrid.ReadOnly = true;
            _tasksGrid.Size = new System.Drawing.Size(1162, 404);
            _tasksGrid.TabIndex = 0;
            _tasksGrid.SelectionChanged += tasksGrid_SelectionChanged;
            // 
            // taskTypeColumn
            // 
            taskTypeColumn.HeaderText = "Type";
            taskTypeColumn.Name = "taskTypeColumn";
            taskTypeColumn.ReadOnly = true;
            taskTypeColumn.FillWeight = 25F;
            taskTypeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // taskNameColumn
            // 
            taskNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            taskNameColumn.FillWeight = 25F;
            taskNameColumn.HeaderText = "Task";
            taskNameColumn.Name = "taskNameColumn";
            taskNameColumn.ReadOnly = true;
            // 
            // taskStatusColumn
            // 
            taskStatusColumn.HeaderText = "Status";
            taskStatusColumn.Name = "taskStatusColumn";
            taskStatusColumn.ReadOnly = true;
            taskStatusColumn.FillWeight = 25F;
            taskStatusColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // taskProgressColumn
            // 
            taskProgressColumn.HeaderText = "Progress";
            taskProgressColumn.Name = "taskProgressColumn";
            taskProgressColumn.ReadOnly = true;
            taskProgressColumn.FillWeight = 25F;
            taskProgressColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // taskDetailsLayout
            // 
            taskDetailsLayout.ColumnCount = 1;
            taskDetailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            taskDetailsLayout.Controls.Add(_taskStageLabel, 0, 0);
            taskDetailsLayout.Controls.Add(_taskProgressLabel, 0, 1);
            taskDetailsLayout.Controls.Add(_taskCurrentProgress, 0, 2);
            taskDetailsLayout.Controls.Add(_taskDetailLabel, 0, 3);
            taskDetailsLayout.Controls.Add(_taskOverallLabel, 0, 4);
            taskDetailsLayout.Controls.Add(_taskOverallProgress, 0, 5);
            taskDetailsLayout.Controls.Add(taskActionsPanel, 0, 6);
            taskDetailsLayout.Dock = DockStyle.Bottom;
            taskDetailsLayout.Location = new System.Drawing.Point(12, 440);
            taskDetailsLayout.Name = "taskDetailsLayout";
            taskDetailsLayout.Padding = new Padding(0, 14, 0, 0);
            taskDetailsLayout.RowCount = 7;
            taskDetailsLayout.RowStyles.Add(new RowStyle());
            taskDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            taskDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            taskDetailsLayout.RowStyles.Add(new RowStyle());
            taskDetailsLayout.RowStyles.Add(new RowStyle());
            taskDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            taskDetailsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            taskDetailsLayout.Size = new System.Drawing.Size(1162, 260);
            taskDetailsLayout.TabIndex = 1;
            // 
            // _taskStageLabel
            // 
            _taskStageLabel.Dock = DockStyle.Fill;
            _taskStageLabel.Location = new System.Drawing.Point(0, 14);
            _taskStageLabel.Margin = new Padding(0, 0, 0, 10);
            _taskStageLabel.Name = "_taskStageLabel";
            _taskStageLabel.Size = new System.Drawing.Size(1162, 15);
            _taskStageLabel.TabIndex = 0;
            _taskStageLabel.Text = "Select a task to see details.";
            // 
            // _taskProgressLabel
            // 
            _taskProgressLabel.Dock = DockStyle.Fill;
            _taskProgressLabel.Location = new System.Drawing.Point(0, 39);
            _taskProgressLabel.Margin = new Padding(0, 0, 0, 8);
            _taskProgressLabel.Name = "_taskProgressLabel";
            _taskProgressLabel.Size = new System.Drawing.Size(1162, 32);
            _taskProgressLabel.TabIndex = 3;
            _taskProgressLabel.Text = "Current task";
            // 
            // _taskCurrentProgress
            // 
            _taskCurrentProgress.Dock = DockStyle.Fill;
            _taskCurrentProgress.Location = new System.Drawing.Point(0, 60);
            _taskCurrentProgress.Margin = new Padding(0, 0, 0, 8);
            _taskCurrentProgress.Name = "_taskCurrentProgress";
            _taskCurrentProgress.Size = new System.Drawing.Size(1162, 24);
            _taskCurrentProgress.TabIndex = 4;
            // 
            // _taskDetailLabel
            // 
            _taskDetailLabel.Dock = DockStyle.Fill;
            _taskDetailLabel.Location = new System.Drawing.Point(0, 92);
            _taskDetailLabel.Margin = new Padding(0, 0, 0, 16);
            _taskDetailLabel.Name = "_taskDetailLabel";
            _taskDetailLabel.Size = new System.Drawing.Size(1162, 15);
            _taskDetailLabel.TabIndex = 5;
            // 
            // _taskOverallLabel
            // 
            _taskOverallLabel.Dock = DockStyle.Fill;
            _taskOverallLabel.Location = new System.Drawing.Point(0, 123);
            _taskOverallLabel.Margin = new Padding(0, 0, 0, 6);
            _taskOverallLabel.Name = "_taskOverallLabel";
            _taskOverallLabel.Size = new System.Drawing.Size(1162, 23);
            _taskOverallLabel.TabIndex = 1;
            _taskOverallLabel.Text = "Overall progress";
            // 
            // _taskOverallProgress
            // 
            _taskOverallProgress.Dock = DockStyle.Fill;
            _taskOverallProgress.Location = new System.Drawing.Point(0, 152);
            _taskOverallProgress.Margin = new Padding(0, 0, 0, 8);
            _taskOverallProgress.Name = "_taskOverallProgress";
            _taskOverallProgress.Size = new System.Drawing.Size(1162, 24);
            _taskOverallProgress.TabIndex = 2;
            // 
            // taskActionsPanel
            // 
            taskActionsPanel.Controls.Add(_taskCancel);
            taskActionsPanel.Controls.Add(_taskRetry);
            taskActionsPanel.Controls.Add(_taskOpenOutput);
            taskActionsPanel.Controls.Add(_taskRemove);
            taskActionsPanel.Dock = DockStyle.Fill;
            taskActionsPanel.Location = new System.Drawing.Point(0, 196);
            taskActionsPanel.Margin = new Padding(0, 12, 0, 0);
            taskActionsPanel.Name = "taskActionsPanel";
            taskActionsPanel.Padding = new Padding(2);
            taskActionsPanel.Size = new System.Drawing.Size(1162, 48);
            taskActionsPanel.TabIndex = 6;
            // 
            // _taskCancel
            // 
            _taskCancel.Location = new System.Drawing.Point(5, 5);
            _taskCancel.Name = "_taskCancel";
            _taskCancel.Size = new System.Drawing.Size(100, 26);
            _taskCancel.TabIndex = 0;
            _taskCancel.Text = "Cancel task";
            _taskCancel.Click += taskCancel_Click;
            // 
            // _taskRetry
            // 
            _taskRetry.Location = new System.Drawing.Point(111, 5);
            _taskRetry.Name = "_taskRetry";
            _taskRetry.Size = new System.Drawing.Size(100, 26);
            _taskRetry.TabIndex = 1;
            _taskRetry.Text = "Retry";
            _taskRetry.Click += taskRetry_Click;
            // 
            // _taskOpenOutput
            // 
            _taskOpenOutput.Location = new System.Drawing.Point(217, 5);
            _taskOpenOutput.Name = "_taskOpenOutput";
            _taskOpenOutput.Size = new System.Drawing.Size(100, 26);
            _taskOpenOutput.TabIndex = 2;
            _taskOpenOutput.Text = "Open output";
            _taskOpenOutput.Click += taskOpenOutput_Click;
            // 
            // _taskRemove
            // 
            _taskRemove.Location = new System.Drawing.Point(323, 5);
            _taskRemove.Name = "_taskRemove";
            _taskRemove.Size = new System.Drawing.Size(100, 26);
            _taskRemove.TabIndex = 3;
            _taskRemove.Text = "Remove";
            _taskRemove.Click += taskRemove_Click;
            // 
            // tasksToolbar
            // 
            tasksToolbar.Controls.Add(_taskAutoStart);
            tasksToolbar.Controls.Add(_taskStartNext);
            tasksToolbar.Controls.Add(_taskClearFinished);
            tasksToolbar.Dock = DockStyle.Top;
            tasksToolbar.Location = new System.Drawing.Point(12, 12);
            tasksToolbar.Name = "tasksToolbar";
            tasksToolbar.Size = new System.Drawing.Size(1162, 40);
            tasksToolbar.TabIndex = 2;
            // 
            // _taskAutoStart
            // 
            _taskAutoStart.AutoSize = true;
            _taskAutoStart.Checked = true;
            _taskAutoStart.CheckState = CheckState.Checked;
            _taskAutoStart.Location = new System.Drawing.Point(0, 10);
            _taskAutoStart.Name = "_taskAutoStart";
            _taskAutoStart.Size = new System.Drawing.Size(116, 19);
            _taskAutoStart.TabIndex = 0;
            _taskAutoStart.Text = "Auto-start queue";
            _taskAutoStart.CheckedChanged += taskAutoStart_CheckedChanged;
            // 
            // _taskStartNext
            // 
            _taskStartNext.Location = new System.Drawing.Point(154, 6);
            _taskStartNext.Name = "_taskStartNext";
            _taskStartNext.Size = new System.Drawing.Size(128, 26);
            _taskStartNext.TabIndex = 1;
            _taskStartNext.Text = "Start next";
            _taskStartNext.Click += taskStartNext_Click;
            // 
            // _taskClearFinished
            // 
            _taskClearFinished.Location = new System.Drawing.Point(289, 6);
            _taskClearFinished.Name = "_taskClearFinished";
            _taskClearFinished.Size = new System.Drawing.Size(128, 26);
            _taskClearFinished.TabIndex = 2;
            _taskClearFinished.Text = "Clear Completed";
            _taskClearFinished.Click += taskClearFinished_Click;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Name";
            columnHeader7.Width = 128;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Type";
            columnHeader8.Width = 128;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Path";
            columnHeader9.Width = 128;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Size";
            columnHeader10.Width = 30;
            // 
            // assetNameColumn
            // 
            assetNameColumn.Text = "Name";
            assetNameColumn.Width = 110;
            // 
            // assetTypeColumn
            // 
            assetTypeColumn.Text = "Type";
            // 
            // assetSizeColumn
            // 
            assetSizeColumn.Text = "Size";
            assetSizeColumn.Width = 214;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(darkSectionPanel11);
            tabPage5.Controls.Add(lblUpdateInfo);
            tabPage5.Controls.Add(lblVersion);
            tabPage5.Controls.Add(lblSysVer);
            tabPage5.Controls.Add(lblUpdType);
            tabPage5.Controls.Add(lblMand);
            tabPage5.Controls.Add(lblRemaster);
            tabPage5.Controls.Add(lblFiles);
            tabPage5.Controls.Add(lblSize);
            tabPage5.ForeColor = System.Drawing.Color.Gainsboro;
            tabPage5.Location = new System.Drawing.Point(4, 32);
            tabPage5.Margin = new Padding(3, 2, 3, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3, 2, 3, 2);
            tabPage5.Size = new System.Drawing.Size(951, 556);
            tabPage5.TabIndex = 6;
            tabPage5.Text = "Official Update";
            // 
            // darkSectionPanel11
            // 
            darkSectionPanel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            darkSectionPanel11.Controls.Add(dgvUpdate);
            darkSectionPanel11.Location = new System.Drawing.Point(12, 50);
            darkSectionPanel11.Margin = new Padding(3, 2, 3, 2);
            darkSectionPanel11.Name = "darkSectionPanel11";
            darkSectionPanel11.Padding = new Padding(12);
            darkSectionPanel11.SectionHeader = "Update Package Files";
            darkSectionPanel11.Size = new System.Drawing.Size(927, 496);
            darkSectionPanel11.TabIndex = 109;
            // 
            // dgvUpdate
            // 
            dgvUpdate.AllowUserToAddRows = false;
            dgvUpdate.AllowUserToDeleteRows = false;
            dgvUpdate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUpdate.ContextMenuStrip = contextMenuOfficialUpdate;
            dgvUpdate.Dock = DockStyle.Fill;
            dgvUpdate.Location = new System.Drawing.Point(13, 37);
            dgvUpdate.Margin = new Padding(3, 4, 3, 4);
            dgvUpdate.MultiSelect = false;
            dgvUpdate.Name = "dgvUpdate";
            dgvUpdate.ReadOnly = true;
            dgvUpdate.RowTemplate.Height = 23;
            dgvUpdate.ScrollBars = ScrollBars.Horizontal;
            dgvUpdate.Size = new System.Drawing.Size(901, 446);
            dgvUpdate.TabIndex = 108;
            // 
            // lblUpdateInfo
            // 
            lblUpdateInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUpdateInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblUpdateInfo.Location = new System.Drawing.Point(12, 10);
            lblUpdateInfo.Name = "lblUpdateInfo";
            lblUpdateInfo.Size = new System.Drawing.Size(927, 16);
            lblUpdateInfo.TabIndex = 110;
            lblUpdateInfo.Text = "Select a Game or Patch PKG to view available updates.";
            // 
            // lblVersion
            // 
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblVersion.Location = new System.Drawing.Point(12, 28);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(140, 16);
            lblVersion.TabIndex = 111;
            lblVersion.Text = "Version: ...";
            // 
            // lblSysVer
            // 
            lblSysVer.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSysVer.Location = new System.Drawing.Point(160, 28);
            lblSysVer.Name = "lblSysVer";
            lblSysVer.Size = new System.Drawing.Size(130, 16);
            lblSysVer.TabIndex = 112;
            lblSysVer.Text = "System: ...";
            // 
            // lblUpdType
            // 
            lblUpdType.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblUpdType.Location = new System.Drawing.Point(300, 28);
            lblUpdType.Name = "lblUpdType";
            lblUpdType.Size = new System.Drawing.Size(100, 16);
            lblUpdType.TabIndex = 113;
            lblUpdType.Text = "Type: ...";
            // 
            // lblMand
            // 
            lblMand.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMand.Location = new System.Drawing.Point(410, 28);
            lblMand.Name = "lblMand";
            lblMand.Size = new System.Drawing.Size(110, 16);
            lblMand.TabIndex = 114;
            lblMand.Text = "Mandatory: ...";
            // 
            // lblRemaster
            // 
            lblRemaster.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblRemaster.Location = new System.Drawing.Point(530, 28);
            lblRemaster.Name = "lblRemaster";
            lblRemaster.Size = new System.Drawing.Size(110, 16);
            lblRemaster.TabIndex = 115;
            lblRemaster.Text = "Remaster: ...";
            // 
            // lblFiles
            // 
            lblFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFiles.Location = new System.Drawing.Point(650, 28);
            lblFiles.Name = "lblFiles";
            lblFiles.Size = new System.Drawing.Size(80, 16);
            lblFiles.TabIndex = 116;
            lblFiles.Text = "Files: ...";
            // 
            // lblSize
            // 
            lblSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSize.Location = new System.Drawing.Point(740, 28);
            lblSize.Name = "lblSize";
            lblSize.Size = new System.Drawing.Size(120, 16);
            lblSize.TabIndex = 117;
            lblSize.Text = "Size: ...";
            // 
            // panel8
            // 
            panel8.Location = new System.Drawing.Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(200, 100);
            panel8.TabIndex = 0;
            // 
            // darkSectionPanel12
            // 
            darkSectionPanel12.Location = new System.Drawing.Point(0, 0);
            darkSectionPanel12.Margin = new Padding(6);
            darkSectionPanel12.Name = "darkSectionPanel12";
            darkSectionPanel12.Padding = new Padding(12);
            darkSectionPanel12.SectionHeader = null;
            darkSectionPanel12.Size = new System.Drawing.Size(200, 100);
            darkSectionPanel12.TabIndex = 0;
            // 
            // label13
            // 
            label13.Location = new System.Drawing.Point(0, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(100, 23);
            label13.TabIndex = 0;
            // 
            // label14
            // 
            label14.Location = new System.Drawing.Point(0, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(100, 23);
            label14.TabIndex = 0;
            // 
            // label15
            // 
            label15.Location = new System.Drawing.Point(0, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(100, 23);
            label15.TabIndex = 0;
            // 
            // label16
            // 
            label16.Location = new System.Drawing.Point(0, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(100, 23);
            label16.TabIndex = 0;
            // 
            // label17
            // 
            label17.Location = new System.Drawing.Point(0, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(100, 23);
            label17.TabIndex = 0;
            // 
            // label18
            // 
            label18.Location = new System.Drawing.Point(0, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(100, 23);
            label18.TabIndex = 0;
            // 
            // label19
            // 
            label19.Location = new System.Drawing.Point(0, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(100, 23);
            label19.TabIndex = 0;
            // 
            // labelRemaster
            // 
            labelRemaster.Location = new System.Drawing.Point(0, 0);
            labelRemaster.Name = "labelRemaster";
            labelRemaster.Size = new System.Drawing.Size(100, 23);
            labelRemaster.TabIndex = 0;
            // 
            // label21
            // 
            label21.Location = new System.Drawing.Point(0, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(100, 23);
            label21.TabIndex = 0;
            // 
            // labelUpdateType
            // 
            labelUpdateType.Location = new System.Drawing.Point(0, 0);
            labelUpdateType.Name = "labelUpdateType";
            labelUpdateType.Size = new System.Drawing.Size(100, 23);
            labelUpdateType.TabIndex = 0;
            // 
            // labelMandatory
            // 
            labelMandatory.Location = new System.Drawing.Point(0, 0);
            labelMandatory.Name = "labelMandatory";
            labelMandatory.Size = new System.Drawing.Size(100, 23);
            labelMandatory.TabIndex = 0;
            // 
            // labelPKGdigest
            // 
            labelPKGdigest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelPKGdigest.Location = new System.Drawing.Point(424, 66);
            labelPKGdigest.Name = "labelPKGdigest";
            labelPKGdigest.Size = new System.Drawing.Size(16, 15);
            labelPKGdigest.TabIndex = 113;
            labelPKGdigest.Text = "...";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(20, 36);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(122, 15);
            label5.TabIndex = 98;
            label5.Text = "System requirement";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label12.Location = new System.Drawing.Point(20, 51);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(92, 15);
            label12.TabIndex = 95;
            label12.Text = "Update version";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.Location = new System.Drawing.Point(164, 81);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(10, 15);
            label9.TabIndex = 106;
            label9.Text = ":";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(20, 66);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(55, 15);
            label11.TabIndex = 96;
            label11.Text = "Total file";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.Location = new System.Drawing.Point(164, 66);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(10, 15);
            label4.TabIndex = 105;
            label4.Text = ":";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(20, 81);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(58, 15);
            label10.TabIndex = 97;
            label10.Text = "Total size";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.Location = new System.Drawing.Point(164, 51);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(10, 15);
            label7.TabIndex = 104;
            label7.Text = ":";
            // 
            // labelSystemReq
            // 
            labelSystemReq.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelSystemReq.Location = new System.Drawing.Point(175, 36);
            labelSystemReq.Name = "labelSystemReq";
            labelSystemReq.Size = new System.Drawing.Size(16, 15);
            labelSystemReq.TabIndex = 99;
            labelSystemReq.Text = "...";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.Location = new System.Drawing.Point(164, 36);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(10, 15);
            label6.TabIndex = 103;
            label6.Text = ":";
            // 
            // labelUpdateVersion
            // 
            labelUpdateVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelUpdateVersion.Location = new System.Drawing.Point(175, 51);
            labelUpdateVersion.Name = "labelUpdateVersion";
            labelUpdateVersion.Size = new System.Drawing.Size(16, 15);
            labelUpdateVersion.TabIndex = 100;
            labelUpdateVersion.Text = "...";
            // 
            // labelTotalSize
            // 
            labelTotalSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTotalSize.Location = new System.Drawing.Point(175, 81);
            labelTotalSize.Name = "labelTotalSize";
            labelTotalSize.Size = new System.Drawing.Size(16, 15);
            labelTotalSize.TabIndex = 102;
            labelTotalSize.Text = "...";
            // 
            // labelTotalFile
            // 
            labelTotalFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTotalFile.Location = new System.Drawing.Point(175, 66);
            labelTotalFile.Name = "labelTotalFile";
            labelTotalFile.Size = new System.Drawing.Size(16, 15);
            labelTotalFile.TabIndex = 101;
            labelTotalFile.Text = "...";
            // 
            // Main
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1219, 817);
            Controls.Add(darkMenuStrip1);
            Controls.Add(mainTabControl);
            Controls.Add(darkStatusStrip1);
            Controls.Add(label8);
            Controls.Add(label2);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Icon = Properties.Resources.PackageIcon;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new System.Drawing.Size(1235, 856);
            Name = "Main";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PS4 PKG Tool";
            TransparencyKey = System.Drawing.Color.Fuchsia;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            DragDrop += PKGGridView_DragDrop;
            DragEnter += PKGGridView_DragEnter;
            DragOver += Main_DragOver;
            Resize += Main_Resize;
            contextMenuPKGGridView.ResumeLayout(false);
            darkMenuStrip1.ResumeLayout(false);
            darkMenuStrip1.PerformLayout();
            darkStatusStrip1.ResumeLayout(false);
            darkStatusStrip1.PerformLayout();
            contextMenuTrophy.ResumeLayout(false);
            contextMenuEntry.ResumeLayout(false);
            contextMenuOfficialUpdate.ResumeLayout(false);
            contextMenuBackgroundImage.ResumeLayout(false);
            contextMenuExtractNode.ResumeLayout(false);
            contextMenuExtractListView.ResumeLayout(false);
            mainTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            darkSectionPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)darkDataGridView2).EndInit();
            grpFilter.ResumeLayout(false);
            flpFilter.ResumeLayout(false);
            flpFilter.PerformLayout();
            subTabControl.ResumeLayout(false);
            tabPageTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PKGGridView).EndInit();
            tabPageGroup.ResumeLayout(false);
            darkSectionPanel8.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            darkSectionPanel9.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TrophyGridView).EndInit();
            tabPage3.ResumeLayout(false);
            flatTabControlBgi.ResumeLayout(false);
            tabPagePic0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPIC0).EndInit();
            tabPagePic1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPIC1).EndInit();
            tabPage4.ResumeLayout(false);
            panel7.ResumeLayout(false);
            darkSectionPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEntryList).EndInit();
            darkSectionPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)darkDataGridView4).EndInit();
            darkSectionPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHeader).EndInit();
            tabPage7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            darkSplitContainer1.ResumeLayout(false);
            splitPane1.ResumeLayout(false);
            splitPane2.ResumeLayout(false);
            splitPane3.ResumeLayout(false);
            sectionFileViewer.ResumeLayout(false);
            fileViewerBody.ResumeLayout(false);
            fileViewerBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            darkHeaderBar1.ResumeLayout(false);
            darkHeaderBar1.PerformLayout();
            _tabLog.ResumeLayout(false);
            _tabLog.PerformLayout();
            _tasksTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_tasksGrid).EndInit();
            taskDetailsLayout.ResumeLayout(false);
            taskActionsPanel.ResumeLayout(false);
            tasksToolbar.ResumeLayout(false);
            tasksToolbar.PerformLayout();
            tabPage5.ResumeLayout(false);
            darkSectionPanel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUpdate).EndInit();
            ConfigureGlvContextMenu();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureGlvContextMenu()
        {
            contextMenuGLV.Items.Add(CreateGlvHeader("Global Operations"));
            contextMenuGLV.Items.Add(CreateForwardingMenu(checkForDuplicatePKGToolStripMenuItem2));
            contextMenuGLV.Items.Add(CreateForwardingMenu(checkForPatchesMissingBasePKGToolStripMenuItem2));
            contextMenuGLV.Items.Add(CreateForwardingMenu(globalExportPKGListToExcelToolStripMenuItem2));
            contextMenuGLV.Items.Add(CreateForwardingMenu(toolStripMenuItem3));
            contextMenuGLV.Items.Add(CreateForwardingMenu(toolStripMenuItem111));
            contextMenuGLV.Items.Add(CreateForwardingMenu(toolStripMenuItem38));

            _glvGroupTitleMenu = CreateGlvHeader("Group Operations");
            _glvTitleIdOnlyMenuItems = new ToolStripItem[]
            {
                new DarkUI.Controls.DarkToolStripSeparator(),
                _glvGroupTitleMenu,
                CreateGlvForwardingMenu(GroupActionExtacrtImageToolStripMenuItem),
                CreateGlvForwardingMenu(toolStripMenuItem133),
                CreateGlvAction("Export this group as excel file", () => RunWithGlvGroupSelection(() => selectedExportPKGListToExcelToolStripMenuItem2.PerformClick())),
                CreateGlvAction("Delete group PKGs", GlvDeletePkg),
                CreateGlvAction("Merge base + latest update", GlvMergeBaseAndLatestUpdate),
                new DarkUI.Controls.DarkToolStripSeparator(),
                CreateGlvHeader("shadPS4"),
                CreateGlvAction("Install base game", () => RunWithGlvCategorySelection(Util.Constants.PKGCategory.GAME, () => toolStripMenuItemShadps4Install.PerformClick())),
                CreateGlvAction("Install latest update", () => RunWithGlvCategorySelection(Util.Constants.PKGCategory.PATCH, () => toolStripMenuItemShadps4Install.PerformClick())),
                CreateGlvAction("Launch installed game", () => RunWithGlvCategorySelection(Util.Constants.PKGCategory.GAME, () => toolStripMenuItemShadps4Launch.PerformClick())),
                _glvShadps4UninstallMenu = CreateGlvAction("Uninstall game", () => RunWithGlvCategorySelection(Util.Constants.PKGCategory.GAME, () => toolStripMenuItemShadps4Uninstall.PerformClick())),
                CreateGlvAction("Open shadPS4 Manager", () => toolStripMenuItemShadps4OpenManager.PerformClick())
            };
            contextMenuGLV.Items.AddRange(_glvTitleIdOnlyMenuItems);
        }

        private static ToolStripMenuItem CreateGlvHeader(string text)
            => new ToolStripMenuItem(text) { Enabled = false };

        private static ToolStripMenuItem CreateGlvAction(string text, System.Action action)
        {
            var item = new ToolStripMenuItem(text);
            item.Click += (_, _) => action();
            return item;
        }

        private static ToolStripMenuItem CreateForwardingMenu(ToolStripMenuItem source)
        {
            var item = new ToolStripMenuItem(source.Text);
            foreach (ToolStripItem child in source.DropDownItems)
            {
                if (child is ToolStripSeparator)
                {
                    item.DropDownItems.Add(new DarkUI.Controls.DarkToolStripSeparator());
                    continue;
                }
                if (child is ToolStripMenuItem childMenu)
                    item.DropDownItems.Add(CreateForwardingMenu(childMenu));
            }
            if (item.DropDownItems.Count == 0)
                item.Click += (_, _) => source.PerformClick();
            return item;
        }

        private ToolStripMenuItem CreateGlvForwardingMenu(ToolStripMenuItem source)
        {
            var item = new ToolStripMenuItem(source.Text);
            foreach (ToolStripItem child in source.DropDownItems)
            {
                if (child is ToolStripSeparator)
                {
                    item.DropDownItems.Add(new DarkUI.Controls.DarkToolStripSeparator());
                    continue;
                }
                if (child is ToolStripMenuItem childMenu)
                    item.DropDownItems.Add(CreateGlvForwardingMenu(childMenu));
            }
            if (item.DropDownItems.Count == 0)
                item.Click += (_, _) => RunWithGlvGroupSelection(() => source.PerformClick());
            return item;
        }

        #endregion

        private DarkUI.Controls.DarkLabel label1;
        private DarkUI.Controls.DarkLabel label2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openGameFolderToolStripMenuItem;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem viewTrophyListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem renameToTITLEIDToolStripMenuItem;
        private ToolStripMenuItem renameToCONTENTIDToolStripMenuItem;
        private ToolStripMenuItem exportPKGListToExcelToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem refreshContentToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem renamePKGToTITLEToolStripMenuItem;
        private ToolStripMenuItem renamePKGToTITLETITLEIDToolStripMenuItem;
        private ToolStripMenuItem renamePKGToTITLEToolStripMenuItem1;
        private ToolStripMenuItem renamePKGToTITLECATEGORYToolStripMenuItem;
        private Panel panel5;
        private DarkUI.Controls.DarkLabel label3;
        private DarkUI.Controls.DarkLabel label8;
        private DarkUI.Controls.DarkMenuStrip darkMenuStrip1;
        private DarkUI.Controls.DarkContextMenu PkgGridViewDarkContextMenu;
        private ToolStripMenuItem toolStripMenuItem94;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem111;
        private ToolStripMenuItem renameAllPkg1ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg2ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg3ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg4ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg5ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg6ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg9ToolStripMenuItem2;
        private ToolStripMenuItem globalExportPKGListToExcelToolStripMenuItem2;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuItem127;
        private ToolStripMenuItem copyTitleIdtoolStripMenuItem2;
        private ToolStripMenuItem copyContentIdtoolStripMenuItem2;
        private ToolStripMenuItem copyTitleToolStripMenuItem2;
        private ToolStripMenuItem copyFilenameToolStripMenuItem2;
        private ToolStripMenuItem viewPkgExplorerStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem133;
        private ToolStripMenuItem renameSelectedPkg1ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg2ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg3ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg4ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg5ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg6ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg9ToolStripMenuItem2;
        private ToolStripMenuItem fileToolStripMenuItem2;
        private ToolStripMenuItem loadFromDirectoryToolStripMenuItem;
        private ToolStripMenuItem loadFromManifestToolStripMenuItem;
        private ToolStripMenuItem saveManifestToolStripMenuItem;
        private ToolStripMenuItem emptyListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem globalActionToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem renameAllPkg1ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg2ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg3ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg4ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg5ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg7ToolStripMenuItem1;
        private ToolStripMenuItem extractImageAndBackgroundToolStripMenuItem;
        private ToolStripMenuItem globalExportPKGListToExcelToolStripMenuItem1;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem globalCopyStripMenuItem;
        private ToolStripMenuItem copyTitleIdtoolStripMenuItem1;
        private ToolStripMenuItem copyContentIdtoolStripMenuItem1;
        private ToolStripMenuItem copyTitleToolStripMenuItem1;
        private ToolStripMenuItem copyFilenameToolStripMenuItem1;
        private ToolStripMenuItem viewPkgExplorerStripMenuItem1;
        private ToolStripMenuItem renameCurrentPKGStripMenuItem;
        private ToolStripMenuItem renameSelectedPkg1ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg2ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg3ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg4ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg5ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg6ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg9ToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem144;
        private ToolStripMenuItem settingstoolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem158;
        private ToolStripMenuItem toolStripMenuItem159;
        private ToolStripMenuItem toolStripMenuItem160;
        private ToolStripMenuItem renameAllPkg6ToolStripMenuItem1;
        private DarkUI.Controls.DarkGroupBox grpFilter;
        private DarkUI.Controls.DarkLabel lblCategory;
        private DarkUI.Controls.DarkCheckedComboBox ccbCategory;
        private DarkUI.Controls.DarkLabel lblRegion;
        private DarkUI.Controls.DarkCheckedComboBox ccbRegion;
        private DarkUI.Controls.DarkLabel lblFilterSysVer;
        private DarkUI.Controls.DarkTextBox tbFilterSysVer;
        private DarkUI.Controls.DarkLabel lblType;
        private DarkUI.Controls.DarkCheckedComboBox ccbType;
        private DarkUI.Controls.DarkLabel lblShadps4;
        private DarkUI.Controls.DarkCheckedComboBox ccbShadps4;
        private DarkUI.Controls.DarkCheckBox chkShadps4Installed;
        private DarkUI.Controls.DarkButton btnFilterClear;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private DarkUI.Controls.DarkChipsPanel flowChips;
        private DarkUI.Controls.DarkLabel lblFilterCount;
        private DarkUI.Controls.DarkLabel lblGlvFilterHint;
        public DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel2;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel3;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel4;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel5;
        private DarkUI.Controls.DarkSearchBox tbSearchGame;
        private ToolStripMenuItem globalExtractImagesAndIconToolStripMenuItem1;
        private ToolStripMenuItem globalExtractImageOnlyToolStripMenuItem1;
        private ToolStripMenuItem globalExtractIconOnlyToolStripMenuItem1;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem globalExtractImagesAndIconToolStripMenuItem2;
        private ToolStripMenuItem globalExtractImageOnlyToolStripMenuItem2;
        private ToolStripMenuItem globalExtractIconOnlyToolStripMenuItem2;
        private ToolStripMenuItem managePS4PKGToolStripMenuItem;
        private ToolStripMenuItem renameAllPkg7ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg8ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg8ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg9ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg7ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg8ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg7ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg8ToolStripMenuItem1;
        private ToolStripMenuItem deletePkgtoolStripMenuItem2;
        private ToolStripMenuItem deletePKGtoolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem RpiSendPkgtoolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem RpiSendPkgtoolStripMenuItem1;
        private ToolStripMenuItem RpiCheckPkgInstalledtoolStripMenuItem2;
        private ToolStripMenuItem RpiCheckPkgInstalledtoolStripMenuItem1;
        private ToolStripMenuItem uninstallPKGFromPS4ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem21;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparatorShadps4;
        private ToolStripMenuItem toolStripMenuItemShadps4Launch;
        private ToolStripMenuItem toolStripMenuItemShadps4Install;
        private ToolStripMenuItem toolStripMenuItemShadps4Uninstall;
        private ToolStripMenuItem toolStripMenuItemShadps4InstallSetup;
        private ToolStripMenuItem toolStripMenuItemShadps4OpenLauncher;
        private ToolStripMenuItem toolStripMenuItemShadps4Configure;
        private ToolStripMenuItem toolStripMenuItemShadps4OpenManager;
        private ToolStripMenuItem toolStripMenuItemShadps4Manager;
        private ToolStripMenuItem toolStripMenuItemTools;
        private ToolStripMenuItem renameAllPkg10ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg10ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg10ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg10ToolStripMenuItem1;
        private DarkUI.Controls.DarkToolStripProgressBar toolStripProgressBar1;
        private DarkUI.Controls.DarkDataGridView darkDataGridView2;
        private ToolStripMenuItem RpiUninstallThemePKGToolStripMenuItem2;
        private DarkUI.Controls.DarkTabControl mainTabControl;
        private DarkUI.Controls.DarkTabPage _tasksTab;
        private DarkUI.Controls.DarkFooterBar tasksToolbar;
        private DarkUI.Controls.DarkCheckBox _taskAutoStart;
        private DarkUI.Controls.DarkButton _taskStartNext;
        private DarkUI.Controls.DarkButton _taskClearFinished;
        private DarkUI.Controls.DarkDataGridView _tasksGrid;
        private DataGridViewTextBoxColumn taskTypeColumn;
        private DataGridViewTextBoxColumn taskNameColumn;
        private DataGridViewTextBoxColumn taskStatusColumn;
        private DataGridViewTextBoxColumn taskProgressColumn;
        private DarkUI.Controls.DarkTableLayoutPanel taskDetailsLayout;
        private DarkUI.Controls.DarkLabel _taskStageLabel;
        private DarkUI.Controls.DarkLabel _taskProgressLabel;
        private DarkUI.Controls.DarkProgressBar _taskCurrentProgress;
        private DarkUI.Controls.DarkLabel _taskOverallLabel;
        private DarkUI.Controls.DarkProgressBar _taskOverallProgress;
        private DarkUI.Controls.DarkLabel _taskDetailLabel;
        private DarkUI.Controls.DarkChipsPanel taskActionsPanel;
        private DarkUI.Controls.DarkButton _taskCancel;
        private DarkUI.Controls.DarkButton _taskRetry;
        private DarkUI.Controls.DarkButton _taskOpenOutput;
        private DarkUI.Controls.DarkButton _taskRemove;
        private System.Windows.Forms.Timer taskRefreshTimer;
        private DarkUI.Controls.DarkTabPage tabPage1;
        private DarkUI.Controls.DarkTabPage tabPage2;
        private DarkUI.Controls.DarkDataGridView TrophyGridView;
        private DarkUI.Controls.DarkTabPage tabPage3;
        private DarkUI.Controls.DarkTabControl flatTabControlBgi;
        private DarkUI.Controls.DarkContextMenu TrophyDarkContextMenu;
        private ToolStripMenuItem ExtractTrophyImageToolStripMenuItem;
        private DarkUI.Controls.DarkContextMenu contextMenuBackgroundImage;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem SetImageAsDesktopBackgroundToolStripMenuItem;
        private DarkUI.Controls.DarkTabPage tabPage4;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel3;
        private DarkUI.Controls.DarkDataGridView darkDataGridView4;
        private DarkUI.Controls.DarkDataGridView dgvEntryList;
        private DarkUI.Controls.DarkDataGridView dgvHeader;
        private DarkUI.Controls.DarkContextMenu PkgEntryDarkContextMenu;
        private ToolStripMenuItem ExtractDecryptedEntryToolStripMenuItem;
        private ToolStripMenuItem ExtractAllEntryToolStripMenuItem;
        private ImageList imageList1;
        private DarkUI.Controls.DarkContextMenu PkgExtractDarkContextMenu;
        private ToolStripMenuItem extractNodeToolStripMenuItem;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader6;
        private Panel panel7;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel10;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel9;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel8;
        private DarkUI.Controls.DarkLabel label9;
        private DarkUI.Controls.DarkLabel label4;
        private DarkUI.Controls.DarkLabel label7;
        private DarkUI.Controls.DarkLabel label6;
        private DarkUI.Controls.DarkLabel labelTotalSize;
        private DarkUI.Controls.DarkLabel labelTotalFile;
        private DarkUI.Controls.DarkLabel labelUpdateVersion;
        private DarkUI.Controls.DarkLabel labelSystemReq;
        private DarkUI.Controls.DarkLabel label5;
        private DarkUI.Controls.DarkLabel label10;
        private DarkUI.Controls.DarkLabel label11;
        private DarkUI.Controls.DarkLabel label12;
        private DarkUI.Controls.DarkContextMenu OfficialUpdateDarkContextMenu;
        private ToolStripMenuItem copyURLToolStripMenuItem;
        private ToolStripMenuItem downloadSelectedPKGUpdateToolStripMenuItem;
        private DarkUI.Controls.DarkLabel label13;
        private DarkUI.Controls.DarkLabel label14;
        private DarkUI.Controls.DarkLabel label15;
        private DarkUI.Controls.DarkLabel label16;
        private DarkUI.Controls.DarkLabel label17;
        private DarkUI.Controls.DarkLabel label18;
        private DarkUI.Controls.DarkLabel label19;
        private DarkUI.Controls.DarkLabel labelRemaster;
        private DarkUI.Controls.DarkLabel label21;
        private DarkUI.Controls.DarkLabel labelUpdateType;
        private DarkUI.Controls.DarkLabel labelMandatory;
        private DarkUI.Controls.DarkLabel labelPKGdigest;
        private DarkUI.Controls.DarkTextBox tbPasscode;
        private DarkUI.Controls.DarkButton btnViewPKGData;
        private DarkUI.Controls.DarkTabPage tabPage7;
        private DarkUI.Controls.DarkSectionPanel sectionFileViewer;
        private DarkUI.Controls.DarkLabel lblFileViewerInfo;
        private Panel fileViewerBody;
        private DarkUI.Controls.DarkTextBox txtPreview;
        private DarkUI.Controls.DarkTextBox txtHexPreview;
        private PictureBox picPreview;
        private DarkUI.Controls.DarkListView assetListView;
        private ColumnHeader assetNameColumn;
        private ColumnHeader assetTypeColumn;
        private ColumnHeader assetSizeColumn;
        private DarkUI.Controls.DarkButton btnAssetBack;
        private DarkUI.Controls.DarkTreeView PKGTreeView;
        private DarkUI.Controls.DarkListView listView1;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private DarkUI.Controls.DarkTabPage tabPage5;
        private DarkUI.Controls.DarkTabPage _tabLog;
        private DarkUI.Controls.DarkTextBox _tbLogBox;
        private Panel panel8;
        private DarkUI.Controls.DarkLabel lblUpdateInfo;
        private DarkUI.Controls.DarkLabel lblVersion, lblSysVer, lblUpdType, lblMand, lblRemaster, lblFiles, lblSize;
        private DarkUI.Controls.DarkDataGridView dgvUpdate;
        private Panel panel6;
        private DarkUI.Controls.DarkDataGridView PKGGridView;
        private DarkUI.Controls.DarkTabControl subTabControl;
        private DarkUI.Controls.DarkTabPage tabPageTable;
        private DarkUI.Controls.DarkTabPage tabPageGroup;
        private DarkUI.Controls.DarkGroupedListView groupedListView;
        // Removed tbGroupFilter and darkLabel7. The GLV filter uses the Table tab's tbSearchGame.

        private DarkUI.Controls.DarkButton btnGroupExpand;
        private DarkUI.Controls.DarkComboBox cbGroupBy;
        private DarkUI.Controls.DarkLabel darkLabelGroupBy;
        private DarkUI.Controls.DarkLabel darkLabelGroupCount;
        private DarkUI.Controls.DarkContextMenu contextMenuGLV;
        private ToolStripItem[] _glvTitleIdOnlyMenuItems = Array.Empty<ToolStripItem>();
        private ToolStripMenuItem? _glvShadps4UninstallMenu;
        private System.Windows.Forms.Timer _groupedViewRefreshTimer;
        private System.Windows.Forms.Timer _logFlushTimer;
        private DarkUI.Controls.DarkTabPage tabPagePic0;
        private DarkUI.Controls.DarkTabPage tabPagePic1;
        private PictureBox pbPIC0;
        private PictureBox pbPIC1;
        private DarkUI.Controls.DarkContextMenu contextMenuExtractListView;
        private ToolStripMenuItem toolStripMenuItem32;
        private ToolStripMenuItem ctxExtractFolder;
        private DarkUI.Controls.DarkToolStripSeparator ctxListSeparator;
        private ToolStripMenuItem ctxCopyPath;
        private ToolStripMenuItem ctxCopyName;
        private ToolStripMenuItem viewPkgChangeInfotoolStripMenuItem2;
        private DarkUI.Controls.DarkToolStripStatusLabel labelDisplayTotalPKG;
        private DarkUI.Controls.DarkToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem toolStripMenuItem34;
        private ToolStripMenuItem viewPkgChangeInfotoolStripMenuItem1;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkSearchBox tbFilterTreeView;
        private ToolStripMenuItem expandAllToolStripMenuItem;
        private ToolStripMenuItem collapseAllNodeToolStripMenuItem;
        private ToolStripMenuItem ctxExpandNode;
        private ToolStripMenuItem ctxCollapseNode;
        private DarkUI.Controls.DarkToolStripSeparator ctxTreeSeparator;
        private ToolStripMenuItem seperateAndMovePKGByTypeIntoFolderToolStripMenuItem;
        private ToolStripMenuItem renameAllPkg11ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg11ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg11ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg11ToolStripMenuItem2;
        private ToolStripMenuItem renameAllPkg12ToolStripMenuItem1;
        private ToolStripMenuItem renameSelectedPkg12ToolStripMenuItem1;
        private ToolStripMenuItem renameAllPkg12ToolStripMenuItem2;
        private ToolStripMenuItem renameSelectedPkg12ToolStripMenuItem2;
        private ToolStripMenuItem movePkgCategoryToolStripMenuItem1;
        private ToolStripMenuItem RpiUninstallDlcPKGToolStripMenuItem2;
        private ToolStripMenuItem RpiUninstallPatchPKGToolStripMenuItem2;
        private ToolStripMenuItem RpiUninstallBasePKGToolStripMenuItem2;
        private ToolStripMenuItem movePkgTypeToolStripMenuItem1;
        private ToolStripMenuItem movePkgRegionToolStripMenuItem1;
        private ToolStripMenuItem movePkgSingleFolderToolStripMenuItem1;
        private ToolStripMenuItem RpiUninstallBasePKGToolStripMenuItem1;
        private ToolStripMenuItem RpiUninstallPatchPKGToolStripMenuItem1;
        private ToolStripMenuItem RpiUninstallDlcPKGToolStripMenuItem1;
        private ToolStripMenuItem RpiUninstallThemePKGToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem38;
        private ToolStripMenuItem movePkgTypeToolStripMenuItem2;
        private ToolStripMenuItem movePkgCategoryToolStripMenuItem2;
        private ToolStripMenuItem movePkgRegionToolStripMenuItem2;
        private ToolStripMenuItem movePkgSingleFolderToolStripMenuItem2;
        private DarkUI.Controls.DarkButton btnExtractFullPKG;
        private ToolStripMenuItem GroupActionTitleStripMenuItem;
        private ToolStripMenuItem selectedExportPKGListToExcelToolStripMenuItem2;
        private ToolStripMenuItem mergeSelectedBaseAndUpdateToolStripMenuItem;
        private ToolStripMenuItem convertSelectedToFfpfscToolStripMenuItem;
        private ToolStripMenuItem extractSelectedFullPkgToolStripMenuItem;
        private ToolStripMenuItem GroupActionExtacrtImageToolStripMenuItem;
        private ToolStripMenuItem selectedExtractImagesAndIconToolStripMenuItem2;
        private ToolStripMenuItem selectedExtractImageOnlyToolStripMenuItem2;
        private ToolStripMenuItem selectedExtractIconOnlyToolStripMenuItem2;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator3;
        private DarkUI.Controls.DarkContextMenu contextMenuPKGGridView;
        private DarkUI.Controls.DarkContextMenu contextMenuTrophy;
        private DarkUI.Controls.DarkContextMenu contextMenuEntry;
        private DarkUI.Controls.DarkContextMenu contextMenuOfficialUpdate;
        private DarkUI.Controls.DarkContextMenu contextMenuExtractNode;
        private DarkUI.Controls.DarkStatusStrip darkStatusStrip1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel7;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel12;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel11;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator1;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator2;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem selectedExportPKGListToExcelToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem28;
        private ToolStripMenuItem selectedExtractImagesAndIconToolStripMenuItem1;
        private ToolStripMenuItem selectedExtractImageOnlyToolStripMenuItem1;
        private ToolStripMenuItem selectedExtractIconOnlyToolStripMenuItem1;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem backportToolStripMenuItem;
        private ToolStripMenuItem setBackportedToolStripMenuItem2;
        private ToolStripMenuItem removeBackportedToolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem setBackportedtoolStripMenuItem1;
        private ToolStripMenuItem removeBackportedtoolStripMenuItem1;
        private DarkUI.Controls.DarkToolStripTextBox backportRemarkTextboxtoolStripTextBox1;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem setBackportRemarksToolStripMenuItem;
        private ToolStripMenuItem setRemarktoolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem setRemarktoolStripMenuItem1;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator10;
        private DarkUI.Controls.DarkToolStripTextBox backportRemarkTextboxtoolStripTextBox2;
        private ToolStripMenuItem movePkgTitleToolStripMenuItem2;
        private ToolStripMenuItem movePkgTitleToolStripMenuItem1;
        private ToolStripMenuItem checkForDuplicatePKGToolStripMenuItem2;
        private ToolStripMenuItem checkForDuplicatePKGToolStripMenuItem1;
        private ToolStripMenuItem checkForPatchesMissingBasePKGToolStripMenuItem2;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator11;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator12;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator13;
        private DarkUI.Controls.DarkToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem openAppDataDirectoryToolStripMenuItem2;
        private ToolStripMenuItem downloadOfficialUpdateToolStripMenuItem1;
        private ToolStripMenuItem downloadOfficialUpdateToolStripMenuItem2;
        private ToolStripMenuItem moveByPkgTitleIdToolStripMenuItem;
        private DarkUI.Controls.DarkButton btnExportTreeView;
        private DarkUI.Controls.DarkButton btnExportTextures;
        private ToolStripMenuItem sToolStripMenuItem;
        private DarkUI.Controls.DarkHeaderBar darkHeaderBar1;
        private DarkUI.Controls.DarkSplitContainer darkSplitContainer1;
        private DarkUI.Controls.DarkSplitPane splitPane1;
        private DarkUI.Controls.DarkSplitPane splitPane2;
        private DarkUI.Controls.DarkSplitPane splitPane3;
    }
}

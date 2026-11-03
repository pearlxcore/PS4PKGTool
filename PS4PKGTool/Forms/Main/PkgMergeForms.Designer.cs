namespace PS4PKGTool
{
    internal sealed partial class PkgMergeOptionsForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.FlowLayoutPanel optionsPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private DarkUI.Controls.DarkLabel lblBaseGame;
        private DarkUI.Controls.DarkLabel lblUpdate;
        private DarkUI.Controls.DarkLabel lblTitleId;
        private DarkUI.Controls.DarkLabel lblVersions;
        private DarkUI.Controls.DarkLabel lblOutputPkg;
        private DarkUI.Controls.DarkLabel lblWorkLocation;
        private DarkUI.Controls.DarkLabel lblWorkers;
        private DarkUI.Controls.DarkLabel lblNote;
        private DarkUI.Controls.DarkLabel lblSpaceWarning;
        private DarkUI.Controls.DarkTextBox txtBaseGame;
        private DarkUI.Controls.DarkTextBox txtUpdate;
        private DarkUI.Controls.DarkTextBox txtTitleId;
        private DarkUI.Controls.DarkTextBox txtVersions;
        private DarkUI.Controls.DarkTextBox _outputPath;
        private DarkUI.Controls.DarkTextBox _workParent;
        private DarkUI.Controls.DarkCheckBox _validate;
        private DarkUI.Controls.DarkNumericUpDown _workers;
        private DarkUI.Controls.DarkButton btnBrowseOutput;
        private DarkUI.Controls.DarkButton btnBrowseWork;
        private DarkUI.Controls.DarkButton btnCancel;
        private DarkUI.Controls.DarkButton btnMerge;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            layout = new System.Windows.Forms.TableLayoutPanel();
            lblBaseGame = new DarkUI.Controls.DarkLabel();
            txtBaseGame = new DarkUI.Controls.DarkTextBox();
            lblUpdate = new DarkUI.Controls.DarkLabel();
            txtUpdate = new DarkUI.Controls.DarkTextBox();
            lblTitleId = new DarkUI.Controls.DarkLabel();
            txtTitleId = new DarkUI.Controls.DarkTextBox();
            lblVersions = new DarkUI.Controls.DarkLabel();
            txtVersions = new DarkUI.Controls.DarkTextBox();
            lblOutputPkg = new DarkUI.Controls.DarkLabel();
            _outputPath = new DarkUI.Controls.DarkTextBox();
            btnBrowseOutput = new DarkUI.Controls.DarkButton();
            lblWorkLocation = new DarkUI.Controls.DarkLabel();
            _workParent = new DarkUI.Controls.DarkTextBox();
            btnBrowseWork = new DarkUI.Controls.DarkButton();
            optionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            _validate = new DarkUI.Controls.DarkCheckBox();
            lblWorkers = new DarkUI.Controls.DarkLabel();
            _workers = new DarkUI.Controls.DarkNumericUpDown();
            lblSpaceWarning = new DarkUI.Controls.DarkLabel();
            lblNote = new DarkUI.Controls.DarkLabel();
            buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new DarkUI.Controls.DarkButton();
            btnMerge = new DarkUI.Controls.DarkButton();
            layout.SuspendLayout();
            optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_workers).BeginInit();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.ColumnCount = 3;
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            layout.Controls.Add(lblBaseGame, 0, 0);
            layout.Controls.Add(txtBaseGame, 1, 0);
            layout.Controls.Add(lblUpdate, 0, 1);
            layout.Controls.Add(txtUpdate, 1, 1);
            layout.Controls.Add(lblTitleId, 0, 2);
            layout.Controls.Add(txtTitleId, 1, 2);
            layout.Controls.Add(lblVersions, 0, 3);
            layout.Controls.Add(txtVersions, 1, 3);
            layout.Controls.Add(lblOutputPkg, 0, 4);
            layout.Controls.Add(_outputPath, 1, 4);
            layout.Controls.Add(btnBrowseOutput, 2, 4);
            layout.Controls.Add(lblWorkLocation, 0, 5);
            layout.Controls.Add(_workParent, 1, 5);
            layout.Controls.Add(btnBrowseWork, 2, 5);
            layout.Controls.Add(optionsPanel, 1, 6);
            layout.Controls.Add(lblSpaceWarning, 0, 7);
            layout.Controls.Add(lblNote, 0, 8);
            layout.Dock = System.Windows.Forms.DockStyle.Fill;
            layout.Location = new System.Drawing.Point(0, 0);
            layout.Name = "layout";
            layout.Padding = new System.Windows.Forms.Padding(12);
            layout.RowCount = 9;
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            layout.Size = new System.Drawing.Size(760, 344);
            layout.TabIndex = 0;
            // 
            // lblBaseGame
            // 
            lblBaseGame.Location = new System.Drawing.Point(12, 19);
            lblBaseGame.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblBaseGame.Name = "lblBaseGame";
            lblBaseGame.Size = new System.Drawing.Size(65, 15);
            lblBaseGame.TabIndex = 0;
            lblBaseGame.Text = "Base Game";
            // 
            // txtBaseGame
            // 
            layout.SetColumnSpan(txtBaseGame, 2);
            txtBaseGame.Dock = System.Windows.Forms.DockStyle.Fill;
            txtBaseGame.Location = new System.Drawing.Point(120, 15);
            txtBaseGame.Name = "txtBaseGame";
            txtBaseGame.ReadOnly = true;
            txtBaseGame.Size = new System.Drawing.Size(625, 23);
            txtBaseGame.TabIndex = 1;
            // 
            // lblUpdate
            // 
            lblUpdate.Location = new System.Drawing.Point(12, 53);
            lblUpdate.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblUpdate.Name = "lblUpdate";
            lblUpdate.Size = new System.Drawing.Size(45, 15);
            lblUpdate.TabIndex = 2;
            lblUpdate.Text = "Update";
            // 
            // txtUpdate
            // 
            layout.SetColumnSpan(txtUpdate, 2);
            txtUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            txtUpdate.Location = new System.Drawing.Point(120, 49);
            txtUpdate.Name = "txtUpdate";
            txtUpdate.ReadOnly = true;
            txtUpdate.Size = new System.Drawing.Size(625, 23);
            txtUpdate.TabIndex = 3;
            // 
            // lblTitleId
            // 
            lblTitleId.Location = new System.Drawing.Point(12, 87);
            lblTitleId.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblTitleId.Name = "lblTitleId";
            lblTitleId.Size = new System.Drawing.Size(44, 15);
            lblTitleId.TabIndex = 4;
            lblTitleId.Text = "Title ID";
            // 
            // txtTitleId
            // 
            layout.SetColumnSpan(txtTitleId, 2);
            txtTitleId.Dock = System.Windows.Forms.DockStyle.Fill;
            txtTitleId.Location = new System.Drawing.Point(120, 83);
            txtTitleId.Name = "txtTitleId";
            txtTitleId.ReadOnly = true;
            txtTitleId.Size = new System.Drawing.Size(625, 23);
            txtTitleId.TabIndex = 5;
            // 
            // lblVersions
            // 
            lblVersions.Location = new System.Drawing.Point(12, 121);
            lblVersions.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblVersions.Name = "lblVersions";
            lblVersions.Size = new System.Drawing.Size(50, 15);
            lblVersions.TabIndex = 6;
            lblVersions.Text = "Versions";
            // 
            // txtVersions
            // 
            layout.SetColumnSpan(txtVersions, 2);
            txtVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            txtVersions.Location = new System.Drawing.Point(120, 117);
            txtVersions.Name = "txtVersions";
            txtVersions.ReadOnly = true;
            txtVersions.Size = new System.Drawing.Size(625, 23);
            txtVersions.TabIndex = 7;
            // 
            // lblOutputPkg
            // 
            lblOutputPkg.Location = new System.Drawing.Point(12, 155);
            lblOutputPkg.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblOutputPkg.Name = "lblOutputPkg";
            lblOutputPkg.Size = new System.Drawing.Size(69, 15);
            lblOutputPkg.TabIndex = 8;
            lblOutputPkg.Text = "Output PKG";
            // 
            // _outputPath
            // 
            _outputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            _outputPath.Location = new System.Drawing.Point(120, 151);
            _outputPath.Name = "_outputPath";
            _outputPath.Size = new System.Drawing.Size(537, 23);
            _outputPath.TabIndex = 0;
            _outputPath.TextChanged += UpdateSpaceWarning;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            btnBrowseOutput.Location = new System.Drawing.Point(663, 151);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new System.Drawing.Size(82, 28);
            btnBrowseOutput.TabIndex = 1;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // lblWorkLocation
            // 
            lblWorkLocation.Location = new System.Drawing.Point(12, 189);
            lblWorkLocation.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            lblWorkLocation.Name = "lblWorkLocation";
            lblWorkLocation.Size = new System.Drawing.Size(81, 15);
            lblWorkLocation.TabIndex = 9;
            lblWorkLocation.Text = "Work location";
            // 
            // _workParent
            // 
            _workParent.Dock = System.Windows.Forms.DockStyle.Fill;
            _workParent.Location = new System.Drawing.Point(120, 185);
            _workParent.Name = "_workParent";
            _workParent.Size = new System.Drawing.Size(537, 23);
            _workParent.TabIndex = 2;
            _workParent.TextChanged += UpdateSpaceWarning;
            // 
            // btnBrowseWork
            // 
            btnBrowseWork.Dock = System.Windows.Forms.DockStyle.Fill;
            btnBrowseWork.Location = new System.Drawing.Point(663, 185);
            btnBrowseWork.Name = "btnBrowseWork";
            btnBrowseWork.Size = new System.Drawing.Size(82, 28);
            btnBrowseWork.TabIndex = 3;
            btnBrowseWork.Text = "Browse...";
            btnBrowseWork.Click += btnBrowseWork_Click;
            // 
            // optionsPanel
            // 
            layout.SetColumnSpan(optionsPanel, 2);
            optionsPanel.Controls.Add(_validate);
            optionsPanel.Controls.Add(lblWorkers);
            optionsPanel.Controls.Add(_workers);
            optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            optionsPanel.Location = new System.Drawing.Point(120, 219);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new System.Drawing.Size(625, 28);
            optionsPanel.TabIndex = 10;
            optionsPanel.WrapContents = false;
            // 
            // _validate
            // 
            _validate.AutoSize = true;
            _validate.Checked = true;
            _validate.CheckState = System.Windows.Forms.CheckState.Checked;
            _validate.Location = new System.Drawing.Point(3, 3);
            _validate.Name = "_validate";
            _validate.Size = new System.Drawing.Size(192, 19);
            _validate.TabIndex = 0;
            _validate.Text = "Validate merged PKG after build";
            // 
            // lblWorkers
            // 
            lblWorkers.Location = new System.Drawing.Point(220, 6);
            lblWorkers.Margin = new System.Windows.Forms.Padding(22, 6, 4, 0);
            lblWorkers.Name = "lblWorkers";
            lblWorkers.Size = new System.Drawing.Size(53, 15);
            lblWorkers.TabIndex = 1;
            lblWorkers.Text = "Workers:";
            // 
            // _workers
            // 
            _workers.Location = new System.Drawing.Point(280, 3);
            _workers.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            _workers.Name = "_workers";
            _workers.Size = new System.Drawing.Size(70, 23);
            _workers.TabIndex = 2;
            _workers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSpaceWarning
            // 
            lblSpaceWarning.AutoEllipsis = true;
            layout.SetColumnSpan(lblSpaceWarning, 3);
            lblSpaceWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSpaceWarning.Location = new System.Drawing.Point(15, 250);
            lblSpaceWarning.Name = "lblSpaceWarning";
            lblSpaceWarning.Size = new System.Drawing.Size(730, 34);
            lblSpaceWarning.TabIndex = 11;
            lblSpaceWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNote
            // 
            layout.SetColumnSpan(lblNote, 3);
            lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            lblNote.Location = new System.Drawing.Point(15, 284);
            lblNote.MaximumSize = new System.Drawing.Size(712, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(712, 48);
            lblNote.TabIndex = 12;
            lblNote.Text = "The source PKGs are not changed. A rebuilt Game PKG is created with the update version. The work location holds the temporary merge folder (extraction dumps and build scratch files). For best results, set the work location and output to a local disk (C: or an internal SSD); network/Samba shares can cause filesystem errors during extraction and image building.";
            lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(btnCancel);
            buttonsPanel.Controls.Add(btnMerge);
            buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            buttonsPanel.Location = new System.Drawing.Point(0, 344);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new System.Windows.Forms.Padding(12, 7, 12, 7);
            buttonsPanel.Size = new System.Drawing.Size(760, 44);
            buttonsPanel.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(651, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(82, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            // 
            // btnMerge
            // 
            btnMerge.Location = new System.Drawing.Point(549, 10);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new System.Drawing.Size(96, 30);
            btnMerge.TabIndex = 1;
            btnMerge.Text = "Merge";
            btnMerge.Click += btnMerge_Click;
            // 
            // PkgMergeOptionsForm
            // 
            AcceptButton = btnMerge;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(760, 388);
            Controls.Add(layout);
            Controls.Add(buttonsPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PkgMergeOptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Merge Base and Update PKG";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            optionsPanel.ResumeLayout(false);
            optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_workers).EndInit();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

    }

}

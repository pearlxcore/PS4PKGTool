namespace PS4PKGTool.Shell
{
    partial class ShellOperationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblShellTitle = new DarkUI.Controls.DarkLabel();
            lblShellPackage = new DarkUI.Controls.DarkLabel();
            lblShellMeta = new DarkUI.Controls.DarkLabel();
            lblShellStage = new DarkUI.Controls.DarkLabel();
            prgShellProgress = new DarkUI.Controls.DarkProgressBar();
            lblShellResult = new DarkUI.Controls.DarkLabel();
            lblShellDestination = new DarkUI.Controls.DarkLabel();
            btnShellCancel = new DarkUI.Controls.DarkButton();
            btnShellDetails = new DarkUI.Controls.DarkButton();
            btnShellCopyResult = new DarkUI.Controls.DarkButton();
            btnShellOpenFolder = new DarkUI.Controls.DarkButton();
            btnShellClose = new DarkUI.Controls.DarkButton();
            SuspendLayout();
            //
            // lblShellTitle
            //
            lblShellTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblShellTitle.Location = new System.Drawing.Point(12, 10);
            lblShellTitle.Name = "lblShellTitle";
            lblShellTitle.Size = new System.Drawing.Size(396, 20);
            lblShellTitle.TabIndex = 0;
            //
            // lblShellPackage
            //
            lblShellPackage.Location = new System.Drawing.Point(12, 34);
            lblShellPackage.Name = "lblShellPackage";
            lblShellPackage.Size = new System.Drawing.Size(396, 16);
            lblShellPackage.TabIndex = 1;
            //
            // lblShellMeta
            //
            lblShellMeta.Location = new System.Drawing.Point(12, 52);
            lblShellMeta.Name = "lblShellMeta";
            lblShellMeta.Size = new System.Drawing.Size(396, 16);
            lblShellMeta.TabIndex = 2;
            //
            // lblShellDestination
            //
            lblShellDestination.Location = new System.Drawing.Point(12, 70);
            lblShellDestination.Name = "lblShellDestination";
            lblShellDestination.Size = new System.Drawing.Size(396, 16);
            lblShellDestination.TabIndex = 3;
            //
            // lblShellStage
            //
            lblShellStage.Location = new System.Drawing.Point(12, 96);
            lblShellStage.Name = "lblShellStage";
            lblShellStage.Size = new System.Drawing.Size(396, 16);
            lblShellStage.TabIndex = 4;
            //
            // prgShellProgress
            //
            prgShellProgress.Location = new System.Drawing.Point(12, 116);
            prgShellProgress.Name = "prgShellProgress";
            prgShellProgress.Size = new System.Drawing.Size(396, 16);
            prgShellProgress.TabIndex = 5;
            prgShellProgress.TextMode = DarkUI.Controls.DarkProgressBarMode.NoText;
            //
            // lblShellResult
            //
            lblShellResult.Location = new System.Drawing.Point(12, 140);
            lblShellResult.Name = "lblShellResult";
            lblShellResult.Size = new System.Drawing.Size(396, 64);
            lblShellResult.TabIndex = 6;
            //
            // btnShellCancel
            //
            btnShellCancel.Location = new System.Drawing.Point(316, 214);
            btnShellCancel.Name = "btnShellCancel";
            btnShellCancel.Size = new System.Drawing.Size(92, 30);
            btnShellCancel.TabIndex = 7;
            btnShellCancel.Text = "Cancel";
            btnShellCancel.Click += btnShellCancel_Click;
            //
            // btnShellDetails
            //
            btnShellDetails.Location = new System.Drawing.Point(12, 214);
            btnShellDetails.Name = "btnShellDetails";
            btnShellDetails.Size = new System.Drawing.Size(90, 30);
            btnShellDetails.TabIndex = 8;
            btnShellDetails.Text = "View Details";
            btnShellDetails.Visible = false;
            btnShellDetails.Click += btnShellDetails_Click;
            //
            // btnShellCopyResult
            //
            btnShellCopyResult.Location = new System.Drawing.Point(108, 214);
            btnShellCopyResult.Name = "btnShellCopyResult";
            btnShellCopyResult.Size = new System.Drawing.Size(90, 30);
            btnShellCopyResult.TabIndex = 9;
            btnShellCopyResult.Text = "Copy Result";
            btnShellCopyResult.Visible = false;
            btnShellCopyResult.Click += btnShellCopyResult_Click;
            //
            // btnShellOpenFolder
            //
            btnShellOpenFolder.Location = new System.Drawing.Point(204, 214);
            btnShellOpenFolder.Name = "btnShellOpenFolder";
            btnShellOpenFolder.Size = new System.Drawing.Size(104, 30);
            btnShellOpenFolder.TabIndex = 10;
            btnShellOpenFolder.Text = "Open Folder";
            btnShellOpenFolder.Visible = false;
            btnShellOpenFolder.Click += btnShellOpenFolder_Click;
            //
            // btnShellClose
            //
            btnShellClose.Location = new System.Drawing.Point(316, 214);
            btnShellClose.Name = "btnShellClose";
            btnShellClose.Size = new System.Drawing.Size(92, 30);
            btnShellClose.TabIndex = 11;
            btnShellClose.Text = "Close";
            btnShellClose.Visible = false;
            btnShellClose.Click += btnShellClose_Click;
            //
            // ShellOperationForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(420, 256);
            Controls.Add(btnShellClose);
            Controls.Add(btnShellOpenFolder);
            Controls.Add(btnShellCopyResult);
            Controls.Add(btnShellDetails);
            Controls.Add(btnShellCancel);
            Controls.Add(lblShellResult);
            Controls.Add(prgShellProgress);
            Controls.Add(lblShellStage);
            Controls.Add(lblShellDestination);
            Controls.Add(lblShellMeta);
            Controls.Add(lblShellPackage);
            Controls.Add(lblShellTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimizeBox = true;
            Name = "ShellOperationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        private DarkUI.Controls.DarkLabel lblShellTitle;
        private DarkUI.Controls.DarkLabel lblShellPackage;
        private DarkUI.Controls.DarkLabel lblShellMeta;
        private DarkUI.Controls.DarkLabel lblShellStage;
        private DarkUI.Controls.DarkProgressBar prgShellProgress;
        private DarkUI.Controls.DarkLabel lblShellResult;
        private DarkUI.Controls.DarkLabel lblShellDestination;
        private DarkUI.Controls.DarkButton btnShellCancel;
        private DarkUI.Controls.DarkButton btnShellDetails;
        private DarkUI.Controls.DarkButton btnShellCopyResult;
        private DarkUI.Controls.DarkButton btnShellOpenFolder;
        private DarkUI.Controls.DarkButton btnShellClose;
    }
}

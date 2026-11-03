namespace PS4PKGTool
{
    partial class Shadps4SetupWizard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelStep1 = new System.Windows.Forms.Panel();
            lblWizardIntro = new DarkUI.Controls.DarkLabel();
            btnWizardRecommended = new DarkUI.Controls.DarkButton();
            btnWizardChooseVersion = new DarkUI.Controls.DarkButton();
            btnWizardUseExisting = new DarkUI.Controls.DarkButton();
            btnWizardCancel1 = new DarkUI.Controls.DarkButton();
            panelStep2 = new System.Windows.Forms.Panel();
            lblManagedRoot = new DarkUI.Controls.DarkLabel();
            tbManagedRoot = new DarkUI.Controls.DarkTextBox();
            btnBrowseRoot = new DarkUI.Controls.DarkButton();
            lblInstallDir = new DarkUI.Controls.DarkLabel();
            tbInstallDir = new DarkUI.Controls.DarkTextBox();
            btnBrowseInstallDir = new DarkUI.Controls.DarkButton();
            chkInstallLauncher = new DarkUI.Controls.DarkCheckBox();
            lblLauncherHint = new DarkUI.Controls.DarkLabel();
            btnBack2 = new DarkUI.Controls.DarkButton();
            btnNext2 = new DarkUI.Controls.DarkButton();
            panelStep3 = new System.Windows.Forms.Panel();
            lblProgress = new DarkUI.Controls.DarkLabel();
            pbInstall = new DarkUI.Controls.DarkProgressBar();
            btnCancelInstall = new DarkUI.Controls.DarkButton();
            panelStep4 = new System.Windows.Forms.Panel();
            lblComplete = new DarkUI.Controls.DarkLabel();
            btnOpenLauncher4 = new DarkUI.Controls.DarkButton();
            btnDone = new DarkUI.Controls.DarkButton();
            panelStep1.SuspendLayout();
            panelStep2.SuspendLayout();
            panelStep3.SuspendLayout();
            panelStep4.SuspendLayout();
            this.SuspendLayout();
            //
            // panelStep1
            //
            panelStep1.Controls.Add(lblWizardIntro);
            panelStep1.Controls.Add(btnWizardRecommended);
            panelStep1.Controls.Add(btnWizardChooseVersion);
            panelStep1.Controls.Add(btnWizardUseExisting);
            panelStep1.Controls.Add(btnWizardCancel1);
            panelStep1.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStep1.Location = new System.Drawing.Point(0, 0);
            panelStep1.Name = "panelStep1";
            panelStep1.Size = new System.Drawing.Size(620, 400);
            panelStep1.TabIndex = 0;
            //
            // lblWizardIntro
            //
            lblWizardIntro.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblWizardIntro.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lblWizardIntro.Location = new System.Drawing.Point(24, 20);
            lblWizardIntro.Name = "lblWizardIntro";
            lblWizardIntro.Size = new System.Drawing.Size(572, 120);
            lblWizardIntro.TabIndex = 0;
            lblWizardIntro.Text = "shadPS4 is not configured.";
            //
            // btnWizardRecommended
            //
            btnWizardRecommended.Location = new System.Drawing.Point(24, 160);
            btnWizardRecommended.Name = "btnWizardRecommended";
            btnWizardRecommended.Size = new System.Drawing.Size(240, 34);
            btnWizardRecommended.TabIndex = 1;
            btnWizardRecommended.Text = "Install Recommended shadPS4 Setup";
            btnWizardRecommended.Click += btnWizardRecommended_Click;
            //
            // btnWizardChooseVersion
            //
            btnWizardChooseVersion.Location = new System.Drawing.Point(24, 204);
            btnWizardChooseVersion.Name = "btnWizardChooseVersion";
            btnWizardChooseVersion.Size = new System.Drawing.Size(240, 34);
            btnWizardChooseVersion.TabIndex = 2;
            btnWizardChooseVersion.Text = "Choose Core Version...";
            btnWizardChooseVersion.Click += btnWizardChooseVersion_Click;
            //
            // btnWizardUseExisting
            //
            btnWizardUseExisting.Location = new System.Drawing.Point(24, 248);
            btnWizardUseExisting.Name = "btnWizardUseExisting";
            btnWizardUseExisting.Size = new System.Drawing.Size(240, 34);
            btnWizardUseExisting.TabIndex = 3;
            btnWizardUseExisting.Text = "Use Existing Installation";
            btnWizardUseExisting.Click += btnWizardUseExisting_Click;
            //
            // btnWizardCancel1
            //
            btnWizardCancel1.Location = new System.Drawing.Point(516, 360);
            btnWizardCancel1.Name = "btnWizardCancel1";
            btnWizardCancel1.Size = new System.Drawing.Size(90, 28);
            btnWizardCancel1.TabIndex = 4;
            btnWizardCancel1.Text = "Cancel";
            btnWizardCancel1.Click += btnWizardCancel1_Click;
            //
            // panelStep2
            //
            panelStep2.Controls.Add(lblManagedRoot);
            panelStep2.Controls.Add(tbManagedRoot);
            panelStep2.Controls.Add(btnBrowseRoot);
            panelStep2.Controls.Add(lblInstallDir);
            panelStep2.Controls.Add(tbInstallDir);
            panelStep2.Controls.Add(btnBrowseInstallDir);
            panelStep2.Controls.Add(chkInstallLauncher);
            panelStep2.Controls.Add(lblLauncherHint);
            panelStep2.Controls.Add(btnBack2);
            panelStep2.Controls.Add(btnNext2);
            panelStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStep2.Location = new System.Drawing.Point(0, 0);
            panelStep2.Name = "panelStep2";
            panelStep2.Size = new System.Drawing.Size(620, 400);
            panelStep2.TabIndex = 1;
            panelStep2.Visible = false;
            //
            // lblManagedRoot
            //
            lblManagedRoot.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblManagedRoot.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lblManagedRoot.Location = new System.Drawing.Point(24, 24);
            lblManagedRoot.Name = "lblManagedRoot";
            lblManagedRoot.Size = new System.Drawing.Size(572, 40);
            lblManagedRoot.TabIndex = 0;
            lblManagedRoot.Text = "Managed builds folder (chosen once, all versions install under it):";
            //
            // tbManagedRoot
            //
            tbManagedRoot.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbManagedRoot.Location = new System.Drawing.Point(24, 68);
            tbManagedRoot.Name = "tbManagedRoot";
            tbManagedRoot.Size = new System.Drawing.Size(440, 23);
            tbManagedRoot.TabIndex = 1;
            //
            // btnBrowseRoot
            //
            btnBrowseRoot.Location = new System.Drawing.Point(470, 66);
            btnBrowseRoot.Name = "btnBrowseRoot";
            btnBrowseRoot.Size = new System.Drawing.Size(90, 26);
            btnBrowseRoot.TabIndex = 2;
            btnBrowseRoot.Text = "Browse...";
            btnBrowseRoot.Click += btnBrowseRoot_Click;
            //
            // lblInstallDir
            //
            lblInstallDir.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblInstallDir.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lblInstallDir.Location = new System.Drawing.Point(24, 100);
            lblInstallDir.Name = "lblInstallDir";
            lblInstallDir.Size = new System.Drawing.Size(572, 16);
            lblInstallDir.TabIndex = 7;
            lblInstallDir.Text = "Install directory (games installed by PS4 PKG Tool):";
            //
            // tbInstallDir
            //
            tbInstallDir.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbInstallDir.Location = new System.Drawing.Point(24, 118);
            tbInstallDir.Name = "tbInstallDir";
            tbInstallDir.Size = new System.Drawing.Size(440, 23);
            tbInstallDir.TabIndex = 8;
            //
            // btnBrowseInstallDir
            //
            btnBrowseInstallDir.Location = new System.Drawing.Point(470, 116);
            btnBrowseInstallDir.Name = "btnBrowseInstallDir";
            btnBrowseInstallDir.Size = new System.Drawing.Size(90, 26);
            btnBrowseInstallDir.TabIndex = 9;
            btnBrowseInstallDir.Text = "Browse...";
            btnBrowseInstallDir.Click += btnBrowseInstallDir_Click;
            //
            // chkInstallLauncher
            //
            chkInstallLauncher.AutoSize = true;
            chkInstallLauncher.Checked = true;
            chkInstallLauncher.CheckState = System.Windows.Forms.CheckState.Checked;
            chkInstallLauncher.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkInstallLauncher.ForeColor = System.Drawing.Color.Gainsboro;
            chkInstallLauncher.Location = new System.Drawing.Point(24, 162);
            chkInstallLauncher.Name = "chkInstallLauncher";
            chkInstallLauncher.Size = new System.Drawing.Size(380, 19);
            chkInstallLauncher.TabIndex = 3;
            chkInstallLauncher.Text = "Install QtLauncher for emulator settings, cheats and patches";
            //
            // lblLauncherHint
            //
            lblLauncherHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblLauncherHint.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            lblLauncherHint.Location = new System.Drawing.Point(42, 184);
            lblLauncherHint.Name = "lblLauncherHint";
            lblLauncherHint.Size = new System.Drawing.Size(540, 40);
            lblLauncherHint.TabIndex = 4;
            lblLauncherHint.Text = "shadPS4 Core is required for launching games directly from PS4 PKG Tool. The QtLauncher configures graphics, controllers, audio, cheats and patches. PS4 PKG Tool never writes shadPS4's own configuration.";
            //
            // btnBack2
            //
            btnBack2.Location = new System.Drawing.Point(414, 360);
            btnBack2.Name = "btnBack2";
            btnBack2.Size = new System.Drawing.Size(90, 28);
            btnBack2.TabIndex = 5;
            btnBack2.Text = "Back";
            btnBack2.Click += btnBack2_Click;
            //
            // btnNext2
            //
            btnNext2.Location = new System.Drawing.Point(516, 360);
            btnNext2.Name = "btnNext2";
            btnNext2.Size = new System.Drawing.Size(90, 28);
            btnNext2.TabIndex = 6;
            btnNext2.Text = "Install";
            btnNext2.Click += btnNext2_Click;
            //
            // panelStep3
            //
            panelStep3.Controls.Add(lblProgress);
            panelStep3.Controls.Add(pbInstall);
            panelStep3.Controls.Add(btnCancelInstall);
            panelStep3.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStep3.Location = new System.Drawing.Point(0, 0);
            panelStep3.Name = "panelStep3";
            panelStep3.Size = new System.Drawing.Size(620, 400);
            panelStep3.TabIndex = 2;
            panelStep3.Visible = false;
            //
            // lblProgress
            //
            lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblProgress.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lblProgress.Location = new System.Drawing.Point(24, 140);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(572, 40);
            lblProgress.TabIndex = 0;
            lblProgress.Text = "Preparing download...";
            //
            // pbInstall
            //
            pbInstall.Location = new System.Drawing.Point(24, 200);
            pbInstall.Name = "pbInstall";
            pbInstall.Size = new System.Drawing.Size(572, 22);
            pbInstall.TabIndex = 1;
            //
            // btnCancelInstall
            //
            btnCancelInstall.Location = new System.Drawing.Point(516, 360);
            btnCancelInstall.Name = "btnCancelInstall";
            btnCancelInstall.Size = new System.Drawing.Size(90, 28);
            btnCancelInstall.TabIndex = 2;
            btnCancelInstall.Text = "Cancel";
            btnCancelInstall.Click += btnCancelInstall_Click;
            //
            // panelStep4
            //
            panelStep4.Controls.Add(lblComplete);
            panelStep4.Controls.Add(btnOpenLauncher4);
            panelStep4.Controls.Add(btnDone);
            panelStep4.Dock = System.Windows.Forms.DockStyle.Fill;
            panelStep4.Location = new System.Drawing.Point(0, 0);
            panelStep4.Name = "panelStep4";
            panelStep4.Size = new System.Drawing.Size(620, 400);
            panelStep4.TabIndex = 3;
            panelStep4.Visible = false;
            //
            // lblComplete
            //
            lblComplete.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblComplete.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lblComplete.Location = new System.Drawing.Point(24, 20);
            lblComplete.Name = "lblComplete";
            lblComplete.Size = new System.Drawing.Size(572, 300);
            lblComplete.TabIndex = 0;
            lblComplete.Text = "shadPS4 Setup Complete";
            //
            // btnOpenLauncher4
            //
            btnOpenLauncher4.Location = new System.Drawing.Point(380, 360);
            btnOpenLauncher4.Name = "btnOpenLauncher4";
            btnOpenLauncher4.Size = new System.Drawing.Size(120, 28);
            btnOpenLauncher4.TabIndex = 1;
            btnOpenLauncher4.Text = "Open QtLauncher";
            btnOpenLauncher4.Click += btnOpenLauncher4_Click;
            //
            // btnDone
            //
            btnDone.Location = new System.Drawing.Point(516, 360);
            btnDone.Name = "btnDone";
            btnDone.Size = new System.Drawing.Size(90, 28);
            btnDone.TabIndex = 2;
            btnDone.Text = "Done";
            btnDone.Click += btnDone_Click;
            //
            // Shadps4SetupWizard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(panelStep1);
            this.Controls.Add(panelStep2);
            this.Controls.Add(panelStep3);
            this.Controls.Add(panelStep4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shadps4SetupWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "shadPS4 Setup";
            panelStep1.ResumeLayout(false);
            panelStep2.ResumeLayout(false);
            panelStep2.PerformLayout();
            panelStep3.ResumeLayout(false);
            panelStep4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelStep1;
        private DarkUI.Controls.DarkLabel lblWizardIntro;
        private DarkUI.Controls.DarkButton btnWizardRecommended;
        private DarkUI.Controls.DarkButton btnWizardChooseVersion;
        private DarkUI.Controls.DarkButton btnWizardUseExisting;
        private DarkUI.Controls.DarkButton btnWizardCancel1;
        private System.Windows.Forms.Panel panelStep2;
        private DarkUI.Controls.DarkLabel lblManagedRoot;
        private DarkUI.Controls.DarkTextBox tbManagedRoot;
        private DarkUI.Controls.DarkButton btnBrowseRoot;
        private DarkUI.Controls.DarkLabel lblInstallDir;
        private DarkUI.Controls.DarkTextBox tbInstallDir;
        private DarkUI.Controls.DarkButton btnBrowseInstallDir;
        private DarkUI.Controls.DarkCheckBox chkInstallLauncher;
        private DarkUI.Controls.DarkLabel lblLauncherHint;
        private DarkUI.Controls.DarkButton btnBack2;
        private DarkUI.Controls.DarkButton btnNext2;
        private System.Windows.Forms.Panel panelStep3;
        private DarkUI.Controls.DarkLabel lblProgress;
        private DarkUI.Controls.DarkProgressBar pbInstall;
        private DarkUI.Controls.DarkButton btnCancelInstall;
        private System.Windows.Forms.Panel panelStep4;
        private DarkUI.Controls.DarkLabel lblComplete;
        private DarkUI.Controls.DarkButton btnOpenLauncher4;
        private DarkUI.Controls.DarkButton btnDone;
    }
}

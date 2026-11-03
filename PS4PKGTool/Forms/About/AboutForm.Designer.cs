using System.Drawing;
using System.Windows.Forms;

namespace PS4PKGTool
{
    partial class AboutForm
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
            this.picAppIcon = new PictureBox();
            this.lblTitle = new DarkUI.Controls.DarkLabel();
            this.lblVersion = new DarkUI.Controls.DarkLabel();
            this.lblCopyright = new DarkUI.Controls.DarkLabel();
            this.lblCredits = new DarkUI.Controls.DarkLabel();
            this.lblLicense = new DarkUI.Controls.DarkLabel();
            this.btnGitHub = new DarkUI.Controls.DarkButton();
            this.btnKofi = new DarkUI.Controls.DarkButton();
            this.btnClose = new DarkUI.Controls.DarkButton();
            this.btnBug = new DarkUI.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).BeginInit();
            this.SuspendLayout();
            //
            // picAppIcon
            //
            this.picAppIcon.Location = new Point(20, 20);
            this.picAppIcon.Name = "picAppIcon";
            this.picAppIcon.Size = new Size(64, 64);
            this.picAppIcon.SizeMode = PictureBoxSizeMode.Zoom;
            this.picAppIcon.TabIndex = 0;
            this.picAppIcon.TabStop = false;
            this.picAppIcon.Image = Icon.ExtractAssociatedIcon(Application.ExecutablePath)?.ToBitmap();
            //
            // lblTitle
            //
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Gainsboro;
            this.lblTitle.Location = new Point(100, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(280, 26);
            this.lblTitle.Text = "PS4 PKG Tool";
            //
            // lblVersion
            //
            this.lblVersion.Font = new Font("Segoe UI", 9F);
            this.lblVersion.ForeColor = Color.Gainsboro;
            this.lblVersion.Location = new Point(100, 46);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new Size(280, 20);
            this.lblVersion.Text = "Version ...";
            //
            // lblCopyright
            //
            this.lblCopyright.Font = new Font("Segoe UI", 9F);
            this.lblCopyright.ForeColor = Color.FromArgb(160, 160, 160);
            this.lblCopyright.Location = new Point(100, 66);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new Size(280, 20);
            this.lblCopyright.Text = "Copyright © pearlxcore";
            //
            // lblCredits
            //
            this.lblCredits.Font = new Font("Segoe UI", 9F);
            this.lblCredits.ForeColor = Color.FromArgb(160, 160, 160);
            this.lblCredits.Location = new Point(20, 104);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new Size(360, 60);
            this.lblCredits.Text = "Credit to Robin Perris (DarkUI),\r\nxXxTheDarkprogramerxXx, Maxton (RIP), leecherman, Andshrew,\r\nSony <3";
            //
            // lblLicense
            //
            this.lblLicense.Font = new Font("Segoe UI", 9F);
            this.lblLicense.ForeColor = Color.FromArgb(120, 120, 120);
            this.lblLicense.Location = new Point(20, 170);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new Size(360, 20);
            this.lblLicense.Text = "Licensed under the GNU General Public License v3.0 (GPL-3.0)";
            //
            // btnGitHub
            //
            this.btnGitHub.Font = new Font("Segoe UI", 9F);
            this.btnGitHub.Location = new Point(20, 204);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new Size(85, 30);
            this.btnGitHub.TabIndex = 0;
            this.btnGitHub.Text = "GitHub";
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            //
            // btnKofi
            //
            this.btnKofi.Font = new Font("Segoe UI", 9F);
            this.btnKofi.Location = new Point(112, 204);
            this.btnKofi.Name = "btnKofi";
            this.btnKofi.Size = new Size(85, 30);
            this.btnKofi.TabIndex = 1;
            this.btnKofi.Text = "Ko-fi";
            this.btnKofi.Click += new System.EventHandler(this.btnKofi_Click);
            //
            // btnBug
            //
            this.btnBug.Font = new Font("Segoe UI", 9F);
            this.btnBug.Location = new Point(204, 204);
            this.btnBug.Name = "btnBug";
            this.btnBug.Size = new Size(85, 30);
            this.btnBug.TabIndex = 2;
            this.btnBug.Text = "Report Bug";
            this.btnBug.Click += new System.EventHandler(this.btnBug_Click);
            //
            // btnClose
            //
            this.btnClose.Font = new Font("Segoe UI", 9F);
            this.btnClose.Location = new Point(296, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(85, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // AboutForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new Size(400, 250);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBug);
            this.Controls.Add(this.btnKofi);
            this.Controls.Add(this.btnGitHub);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picAppIcon);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "About PS4 PKG Tool";
            ((System.ComponentModel.ISupportInitialize)(this.picAppIcon)).EndInit();
            this.ResumeLayout(false);
        }

        private PictureBox picAppIcon;
        private DarkUI.Controls.DarkLabel lblTitle;
        private DarkUI.Controls.DarkLabel lblVersion;
        private DarkUI.Controls.DarkLabel lblCopyright;
        private DarkUI.Controls.DarkLabel lblCredits;
        private DarkUI.Controls.DarkLabel lblLicense;
        private DarkUI.Controls.DarkButton btnGitHub;
        private DarkUI.Controls.DarkButton btnKofi;
        private DarkUI.Controls.DarkButton btnBug;
        private DarkUI.Controls.DarkButton btnClose;
    }
}

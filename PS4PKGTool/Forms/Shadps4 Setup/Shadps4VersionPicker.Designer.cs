namespace PS4PKGTool
{
    partial class Shadps4VersionPicker
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lstVersions = new DarkUI.Controls.DarkListBox();
            btnOk = new DarkUI.Controls.DarkButton();
            btnCancel = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            //
            // lstVersions
            //
            lstVersions.Location = new System.Drawing.Point(12, 12);
            lstVersions.Name = "lstVersions";
            lstVersions.Size = new System.Drawing.Size(560, 320);
            lstVersions.TabIndex = 0;
            //
            // btnOk
            //
            btnOk.Location = new System.Drawing.Point(380, 340);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(90, 28);
            btnOk.TabIndex = 1;
            btnOk.Text = "Install";
            btnOk.Click += btnOk_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new System.Drawing.Point(482, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 28);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            //
            // Shadps4VersionPicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 380);
            this.Controls.Add(lstVersions);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shadps4VersionPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose shadPS4 Core Version";
            this.ResumeLayout(false);
        }

        private DarkUI.Controls.DarkListBox lstVersions;
        private DarkUI.Controls.DarkButton btnOk;
        private DarkUI.Controls.DarkButton btnCancel;
    }
}

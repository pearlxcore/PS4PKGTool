namespace PS4PKGTool.Shell
{
    partial class ShellConfirmForm
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
            lblShellConfirm = new DarkUI.Controls.DarkLabel();
            SuspendLayout();
            //
            // lblShellConfirm
            //
            lblShellConfirm.Location = new System.Drawing.Point(14, 14);
            lblShellConfirm.Name = "lblShellConfirm";
            lblShellConfirm.Size = new System.Drawing.Size(332, 36);
            lblShellConfirm.TabIndex = 0;
            lblShellConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ShellConfirmForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(360, 64);
            Controls.Add(lblShellConfirm);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShellConfirmForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PS4 PKG Tool";
            ResumeLayout(false);
        }

        private DarkUI.Controls.DarkLabel lblShellConfirm;
    }
}

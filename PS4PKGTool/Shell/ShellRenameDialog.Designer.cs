namespace PS4PKGTool.Shell
{
    partial class ShellRenameDialog
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
            lblShellFormatLabel = new DarkUI.Controls.DarkLabel();
            txtShellFormat = new DarkUI.Controls.DarkTextBox();
            btnShellOk = new DarkUI.Controls.DarkButton();
            btnShellCancel = new DarkUI.Controls.DarkButton();
            SuspendLayout();
            //
            // lblShellFormatLabel
            //
            lblShellFormatLabel.Location = new System.Drawing.Point(12, 12);
            lblShellFormatLabel.Name = "lblShellFormatLabel";
            lblShellFormatLabel.Size = new System.Drawing.Size(356, 16);
            lblShellFormatLabel.TabIndex = 0;
            lblShellFormatLabel.Text = "Rename format (placeholders: {TITLE} {TITLE_ID} {CONTENT_ID} {APP_VERSION} {VERSION} {CATEGORY} {REGION} {SYSTEM_VERSION})";
            //
            // txtShellFormat
            //
            txtShellFormat.Location = new System.Drawing.Point(12, 34);
            txtShellFormat.Name = "txtShellFormat";
            txtShellFormat.Size = new System.Drawing.Size(356, 24);
            txtShellFormat.TabIndex = 1;
            //
            // btnShellOk
            //
            btnShellOk.Location = new System.Drawing.Point(180, 70);
            btnShellOk.Name = "btnShellOk";
            btnShellOk.Size = new System.Drawing.Size(90, 30);
            btnShellOk.TabIndex = 2;
            btnShellOk.Text = "Rename";
            btnShellOk.Click += btnShellOk_Click;
            //
            // btnShellCancel
            //
            btnShellCancel.Location = new System.Drawing.Point(278, 70);
            btnShellCancel.Name = "btnShellCancel";
            btnShellCancel.Size = new System.Drawing.Size(90, 30);
            btnShellCancel.TabIndex = 3;
            btnShellCancel.Text = "Cancel";
            btnShellCancel.Click += btnShellCancel_Click;
            //
            // ShellRenameDialog
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(380, 112);
            Controls.Add(btnShellCancel);
            Controls.Add(btnShellOk);
            Controls.Add(txtShellFormat);
            Controls.Add(lblShellFormatLabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShellRenameDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Custom Rename Format";
            ResumeLayout(false);
        }

        private DarkUI.Controls.DarkLabel lblShellFormatLabel;
        private DarkUI.Controls.DarkTextBox txtShellFormat;
        private DarkUI.Controls.DarkButton btnShellOk;
        private DarkUI.Controls.DarkButton btnShellCancel;
    }
}

namespace PS4PKGTool
{
    partial class PasscodePromptForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPasscodePrompt = new DarkUI.Controls.DarkLabel();
            tbPasscodeInput = new DarkUI.Controls.DarkTextBox();
            btnPasscodeOk = new DarkUI.Controls.DarkButton();
            btnPasscodeCancel = new DarkUI.Controls.DarkButton();
            chkNoPasscode = new DarkUI.Controls.DarkCheckBox();
            SuspendLayout();
            //
            // lblPasscodePrompt
            //
            lblPasscodePrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPasscodePrompt.Location = new System.Drawing.Point(13, 12);
            lblPasscodePrompt.Name = "lblPasscodePrompt";
            lblPasscodePrompt.Size = new System.Drawing.Size(394, 44);
            lblPasscodePrompt.TabIndex = 0;
            lblPasscodePrompt.Text = "This PKG is protected by a custom passcode. Enter the PKG passcode to list its files, or choose \"No passcode\" for official PKGs whose key is unknown.";
            //
            // tbPasscodeInput
            //
            tbPasscodeInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            tbPasscodeInput.Location = new System.Drawing.Point(13, 64);
            tbPasscodeInput.MaxLength = 32;
            tbPasscodeInput.Name = "tbPasscodeInput";
            tbPasscodeInput.Size = new System.Drawing.Size(361, 23);
            tbPasscodeInput.TabIndex = 1;
            tbPasscodeInput.Text = "00000000000000000000000000000000";
            tbPasscodeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // chkNoPasscode
            //
            chkNoPasscode.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkNoPasscode.Location = new System.Drawing.Point(13, 93);
            chkNoPasscode.Name = "chkNoPasscode";
            chkNoPasscode.Size = new System.Drawing.Size(361, 22);
            chkNoPasscode.TabIndex = 2;
            chkNoPasscode.Text = "No passcode (official PKG)";
            chkNoPasscode.CheckedChanged += chkNoPasscode_CheckedChanged;
            //
            // btnPasscodeOk
            //
            btnPasscodeOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPasscodeOk.Location = new System.Drawing.Point(213, 123);
            btnPasscodeOk.Name = "btnPasscodeOk";
            btnPasscodeOk.Size = new System.Drawing.Size(90, 26);
            btnPasscodeOk.TabIndex = 3;
            btnPasscodeOk.Text = "OK";
            btnPasscodeOk.Click += btnPasscodeOk_Click;
            //
            // btnPasscodeCancel
            //
            btnPasscodeCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnPasscodeCancel.Location = new System.Drawing.Point(313, 123);
            btnPasscodeCancel.Name = "btnPasscodeCancel";
            btnPasscodeCancel.Size = new System.Drawing.Size(90, 26);
            btnPasscodeCancel.TabIndex = 4;
            btnPasscodeCancel.Text = "Cancel";
            //
            // PasscodePromptForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(417, 162);
            Controls.Add(btnPasscodeCancel);
            Controls.Add(btnPasscodeOk);
            Controls.Add(chkNoPasscode);
            Controls.Add(tbPasscodeInput);
            Controls.Add(lblPasscodePrompt);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasscodePromptForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "PKG Passcode";
            ResumeLayout(false);
            PerformLayout();
        }

        private DarkUI.Controls.DarkLabel lblPasscodePrompt;
        private DarkUI.Controls.DarkTextBox tbPasscodeInput;
        private DarkUI.Controls.DarkButton btnPasscodeOk;
        private DarkUI.Controls.DarkButton btnPasscodeCancel;
        private DarkUI.Controls.DarkCheckBox chkNoPasscode;
    }
}

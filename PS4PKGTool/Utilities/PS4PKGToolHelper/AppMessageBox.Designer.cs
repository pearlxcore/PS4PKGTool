using System.Drawing;
using System.Windows.Forms;

namespace PS4PKGTool.Utilities.PS4PKGToolHelper
{
    partial class AppMessageBox
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
            this.darkLabelTitle = new DarkUI.Controls.DarkLabel();
            this.darkLabelMessage = new DarkUI.Controls.DarkLabel();
            this.btnOK = new DarkUI.Controls.DarkButton();
            this.btnYes = new DarkUI.Controls.DarkButton();
            this.btnNo = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnCopy = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            //
            // darkLabelTitle
            //
            this.darkLabelTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.darkLabelTitle.ForeColor = Color.Gainsboro;
            this.darkLabelTitle.Location = new Point(20, 15);
            this.darkLabelTitle.Name = "darkLabelTitle";
            this.darkLabelTitle.Size = new Size(420, 22);
            //
            // darkLabelMessage
            //
            this.darkLabelMessage.Font = new Font("Segoe UI", 9F);
            this.darkLabelMessage.ForeColor = Color.Gainsboro;
            this.darkLabelMessage.Location = new Point(20, 42);
            this.darkLabelMessage.Name = "darkLabelMessage";
            this.darkLabelMessage.Size = new Size(420, 60);
            //
            // btnOK
            //
            this.btnOK.Font = new Font("Segoe UI", 9F);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new Padding(5);
            this.btnOK.Size = new Size(100, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnYes
            //
            this.btnYes.Font = new Font("Segoe UI", 9F);
            this.btnYes.Name = "btnYes";
            this.btnYes.Padding = new Padding(5);
            this.btnYes.Size = new Size(100, 30);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            //
            // btnNo
            //
            this.btnNo.Font = new Font("Segoe UI", 9F);
            this.btnNo.Name = "btnNo";
            this.btnNo.Padding = new Padding(5);
            this.btnNo.Size = new Size(100, 30);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            //
            // btnCancel
            //
            this.btnCancel.Font = new Font("Segoe UI", 9F);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new Padding(5);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnCopy
            //
            this.btnCopy.Font = new Font("Segoe UI", 9F);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Padding = new Padding(5);
            this.btnCopy.Size = new Size(100, 30);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            //
            // AppMessageBox
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new Size(460, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.darkLabelMessage);
            this.Controls.Add(this.darkLabelTitle);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppMessageBox";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private DarkUI.Controls.DarkLabel darkLabelTitle;
        private DarkUI.Controls.DarkLabel darkLabelMessage;
        private DarkUI.Controls.DarkButton btnOK;
        private DarkUI.Controls.DarkButton btnYes;
        private DarkUI.Controls.DarkButton btnNo;
        private DarkUI.Controls.DarkButton btnCancel;
        private DarkUI.Controls.DarkButton btnCopy;
    }
}

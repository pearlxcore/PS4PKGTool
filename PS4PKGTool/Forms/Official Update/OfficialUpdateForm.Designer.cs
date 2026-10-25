using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PS4PKGTool
{
    partial class OfficialUpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficialUpdateForm));
            lblSummary = new DarkUI.Controls.DarkLabel();
            dgvParts = new DarkUI.Controls.DarkDataGridView();
            ctxMenuParts = new DarkUI.Controls.DarkContextMenu();
            ctxCopyUrl = new ToolStripMenuItem();
            ctxDownload = new ToolStripMenuItem();
            btnDownloadSelected = new DarkUI.Controls.DarkButton();
            btnDownloadAll = new DarkUI.Controls.DarkButton();
            btnClose = new DarkUI.Controls.DarkButton();
            lblStatus = new DarkUI.Controls.DarkLabel();
            toolStripProgress = new DarkUI.Controls.DarkProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvParts).BeginInit();
            ctxMenuParts.SuspendLayout();
            SuspendLayout();
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(220, 220, 220);
            lblSummary.Location = new Point(12, 12);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(893, 44);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Select a Game or Patch PKG to view updates.";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvParts
            // 
            dgvParts.AllowUserToAddRows = false;
            dgvParts.AllowUserToDeleteRows = false;
            dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParts.ContextMenuStrip = ctxMenuParts;
            dgvParts.Location = new Point(12, 62);
            dgvParts.Name = "dgvParts";
            dgvParts.ReadOnly = true;
            dgvParts.RowTemplate.Height = 23;
            dgvParts.Size = new Size(893, 370);
            dgvParts.TabIndex = 1;
            // 
            // ctxMenuParts
            // 
            ctxMenuParts.BackColor = Color.FromArgb(60, 63, 65);
            ctxMenuParts.Font = new Font("Segoe UI", 9F);
            ctxMenuParts.ForeColor = Color.FromArgb(220, 220, 220);
            ctxMenuParts.Items.AddRange(new ToolStripItem[] { ctxCopyUrl, ctxDownload });
            ctxMenuParts.Name = "ctxMenuParts";
            ctxMenuParts.Size = new Size(228, 48);
            // 
            // ctxCopyUrl
            // 
            ctxCopyUrl.BackColor = Color.FromArgb(60, 63, 65);
            ctxCopyUrl.ForeColor = Color.FromArgb(220, 220, 220);
            ctxCopyUrl.Name = "ctxCopyUrl";
            ctxCopyUrl.Size = new Size(227, 22);
            ctxCopyUrl.Text = "Copy URL";
            ctxCopyUrl.Click += ctxCopyUrl_Click;
            // 
            // ctxDownload
            // 
            ctxDownload.BackColor = Color.FromArgb(60, 63, 65);
            ctxDownload.ForeColor = Color.FromArgb(220, 220, 220);
            ctxDownload.Name = "ctxDownload";
            ctxDownload.Size = new Size(227, 22);
            ctxDownload.Text = "Download selected update(s)";
            ctxDownload.Click += ctxDownload_Click;
            // 
            // btnDownloadSelected
            // 
            btnDownloadSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDownloadSelected.Font = new Font("Segoe UI", 9F);
            btnDownloadSelected.Location = new Point(12, 440);
            btnDownloadSelected.Name = "btnDownloadSelected";
            btnDownloadSelected.Size = new Size(130, 30);
            btnDownloadSelected.TabIndex = 2;
            btnDownloadSelected.Text = "Download Selected";
            btnDownloadSelected.Click += btnDownloadSelected_Click;
            // 
            // btnDownloadAll
            // 
            btnDownloadAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDownloadAll.Font = new Font("Segoe UI", 9F);
            btnDownloadAll.Location = new Point(150, 440);
            btnDownloadAll.Name = "btnDownloadAll";
            btnDownloadAll.Size = new Size(100, 30);
            btnDownloadAll.TabIndex = 3;
            btnDownloadAll.Text = "Download All";
            btnDownloadAll.Click += btnDownloadAll_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.Location = new Point(830, 440);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Location = new Point(260, 446);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(563, 18);
            lblStatus.TabIndex = 5;
            // 
            // toolStripProgress
            // 
            toolStripProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            toolStripProgress.Location = new Point(12, 475);
            toolStripProgress.Name = "toolStripProgress";
            toolStripProgress.Size = new Size(660, 10);
            toolStripProgress.TabIndex = 6;
            toolStripProgress.Visible = false;
            // 
            // OfficialUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new Size(917, 491);
            Controls.Add(toolStripProgress);
            Controls.Add(lblStatus);
            Controls.Add(btnClose);
            Controls.Add(btnDownloadAll);
            Controls.Add(btnDownloadSelected);
            Controls.Add(dgvParts);
            Controls.Add(lblSummary);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = global::PS4PKGTool.Properties.Resources.PackageIcon;
            MaximizeBox = false;
            MinimumSize = new Size(700, 530);
            Name = "OfficialUpdateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Official Update Downloader";
            FormClosing += OfficialUpdateForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvParts).EndInit();
            ctxMenuParts.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DarkUI.Controls.DarkLabel lblSummary;
        private DarkUI.Controls.DarkDataGridView dgvParts;
        private DarkUI.Controls.DarkButton btnDownloadSelected;
        private DarkUI.Controls.DarkButton btnDownloadAll;
        private DarkUI.Controls.DarkButton btnClose;
        private DarkUI.Controls.DarkLabel lblStatus;
        private DarkUI.Controls.DarkProgressBar toolStripProgress;
        private DarkUI.Controls.DarkContextMenu ctxMenuParts;
        private System.Windows.Forms.ToolStripMenuItem ctxCopyUrl;
        private System.Windows.Forms.ToolStripMenuItem ctxDownload;
    }
}

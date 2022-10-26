namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class UpdateAvailableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAvailableForm));
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelButtonDownload = new System.Windows.Forms.Panel();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelQuestionTitle = new System.Windows.Forms.Label();
            this.labelDownloadSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelQuestion.SuspendLayout();
            this.panelButtonDownload.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.panelButtonDownload);
            this.panelQuestion.Controls.Add(this.groupBoxInfo);
            this.panelQuestion.Controls.Add(this.labelQuestionTitle);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(8, 8);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(241, 181);
            this.panelQuestion.TabIndex = 1;
            // 
            // panelButtonDownload
            // 
            this.panelButtonDownload.Controls.Add(this.buttonSkip);
            this.panelButtonDownload.Controls.Add(this.buttonUpdate);
            this.panelButtonDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonDownload.Location = new System.Drawing.Point(0, 144);
            this.panelButtonDownload.Name = "panelButtonDownload";
            this.panelButtonDownload.Size = new System.Drawing.Size(241, 37);
            this.panelButtonDownload.TabIndex = 5;
            // 
            // buttonSkip
            // 
            this.buttonSkip.Image = ((System.Drawing.Image)(resources.GetObject("buttonSkip.Image")));
            this.buttonSkip.Location = new System.Drawing.Point(128, 3);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(104, 29);
            this.buttonSkip.TabIndex = 0;
            this.buttonSkip.Text = "Not now";
            this.buttonSkip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonUpdate.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpdate.Image")));
            this.buttonUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(104, 29);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.labelDownloadSize);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.labelReleaseDate);
            this.groupBoxInfo.Controls.Add(this.labelNewVersion);
            this.groupBoxInfo.Controls.Add(this.labelCurrentVersion);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxInfo.Location = new System.Drawing.Point(0, 37);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(241, 93);
            this.groupBoxInfo.TabIndex = 3;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Release date:";
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.Location = new System.Drawing.Point(128, 53);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(12, 15);
            this.labelReleaseDate.TabIndex = 2;
            this.labelReleaseDate.Text = "-";
            // 
            // labelNewVersion
            // 
            this.labelNewVersion.AutoSize = true;
            this.labelNewVersion.Location = new System.Drawing.Point(128, 36);
            this.labelNewVersion.Name = "labelNewVersion";
            this.labelNewVersion.Size = new System.Drawing.Size(12, 15);
            this.labelNewVersion.TabIndex = 2;
            this.labelNewVersion.Text = "-";
            // 
            // labelCurrentVersion
            // 
            this.labelCurrentVersion.AutoSize = true;
            this.labelCurrentVersion.Location = new System.Drawing.Point(128, 19);
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            this.labelCurrentVersion.Size = new System.Drawing.Size(12, 15);
            this.labelCurrentVersion.TabIndex = 2;
            this.labelCurrentVersion.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Version:";
            // 
            // labelQuestionTitle
            // 
            this.labelQuestionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuestionTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelQuestionTitle.Location = new System.Drawing.Point(0, 0);
            this.labelQuestionTitle.Name = "labelQuestionTitle";
            this.labelQuestionTitle.Size = new System.Drawing.Size(241, 37);
            this.labelQuestionTitle.TabIndex = 0;
            this.labelQuestionTitle.Text = "A new application version is available.\r\nDownload and install this update?";
            // 
            // labelDownloadSize
            // 
            this.labelDownloadSize.AutoSize = true;
            this.labelDownloadSize.Location = new System.Drawing.Point(128, 70);
            this.labelDownloadSize.Name = "labelDownloadSize";
            this.labelDownloadSize.Size = new System.Drawing.Size(12, 15);
            this.labelDownloadSize.TabIndex = 2;
            this.labelDownloadSize.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Download size:";
            // 
            // UpdateAvailableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 197);
            this.Controls.Add(this.panelQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateAvailableForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zilliqa Desktop Wallet";
            this.panelQuestion.ResumeLayout(false);
            this.panelButtonDownload.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelQuestion;
        private Panel panelButtonDownload;
        private Button buttonSkip;
        private Button buttonUpdate;
        private GroupBox groupBoxInfo;
        private Label label3;
        private Label labelReleaseDate;
        private Label labelNewVersion;
        private Label labelCurrentVersion;
        private Label label2;
        private Label label1;
        private Label labelQuestionTitle;
        private Label label5;
        private Label labelDownloadSize;
    }
}
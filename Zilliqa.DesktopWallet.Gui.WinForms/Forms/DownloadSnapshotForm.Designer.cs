namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class DownloadSnapshotForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadSnapshotForm));
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelButtonDownload = new System.Windows.Forms.Panel();
            this.buttonSkip = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.groupBoxSnapshotInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSnapshotSize = new System.Windows.Forms.Label();
            this.labelSnapshotDate = new System.Windows.Forms.Label();
            this.labelSnapshotHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLocalState = new System.Windows.Forms.Panel();
            this.labelLocalStateTitle = new System.Windows.Forms.Label();
            this.labelLocalStateValue = new System.Windows.Forms.Label();
            this.labelQuestionTitle = new System.Windows.Forms.Label();
            this.panelDownloadStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancelDownload = new System.Windows.Forms.Button();
            this.panelExtractDetails = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.labelExtractedFiles = new System.Windows.Forms.Label();
            this.labelExtractedProgress = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelDownloadDetails = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelDownloadedSize = new System.Windows.Forms.Label();
            this.labelDownloadedTimeLeft = new System.Windows.Forms.Label();
            this.labelDownloadedProgress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDownloadedSpeed = new System.Windows.Forms.Label();
            this.labelDownloadTitle = new System.Windows.Forms.Label();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.timerExtract = new System.Windows.Forms.Timer(this.components);
            this.panelQuestion.SuspendLayout();
            this.panelButtonDownload.SuspendLayout();
            this.groupBoxSnapshotInfo.SuspendLayout();
            this.panelLocalState.SuspendLayout();
            this.panelDownloadStatus.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelExtractDetails.SuspendLayout();
            this.panelDownloadDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.panelButtonDownload);
            this.panelQuestion.Controls.Add(this.groupBoxSnapshotInfo);
            this.panelQuestion.Controls.Add(this.panelLocalState);
            this.panelQuestion.Controls.Add(this.labelQuestionTitle);
            this.panelQuestion.Location = new System.Drawing.Point(12, 12);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(275, 201);
            this.panelQuestion.TabIndex = 0;
            // 
            // panelButtonDownload
            // 
            this.panelButtonDownload.Controls.Add(this.buttonSkip);
            this.panelButtonDownload.Controls.Add(this.buttonDownload);
            this.panelButtonDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonDownload.Location = new System.Drawing.Point(0, 144);
            this.panelButtonDownload.Name = "panelButtonDownload";
            this.panelButtonDownload.Size = new System.Drawing.Size(275, 57);
            this.panelButtonDownload.TabIndex = 5;
            // 
            // buttonSkip
            // 
            this.buttonSkip.Image = ((System.Drawing.Image)(resources.GetObject("buttonSkip.Image")));
            this.buttonSkip.Location = new System.Drawing.Point(128, 6);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(104, 48);
            this.buttonSkip.TabIndex = 0;
            this.buttonSkip.Text = "Sync without Download";
            this.buttonSkip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSkip.UseVisualStyleBackColor = true;
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Image = ((System.Drawing.Image)(resources.GetObject("buttonDownload.Image")));
            this.buttonDownload.Location = new System.Drawing.Point(3, 6);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(104, 48);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // groupBoxSnapshotInfo
            // 
            this.groupBoxSnapshotInfo.Controls.Add(this.label3);
            this.groupBoxSnapshotInfo.Controls.Add(this.labelSnapshotSize);
            this.groupBoxSnapshotInfo.Controls.Add(this.labelSnapshotDate);
            this.groupBoxSnapshotInfo.Controls.Add(this.labelSnapshotHeight);
            this.groupBoxSnapshotInfo.Controls.Add(this.label2);
            this.groupBoxSnapshotInfo.Controls.Add(this.label1);
            this.groupBoxSnapshotInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSnapshotInfo.Location = new System.Drawing.Point(0, 60);
            this.groupBoxSnapshotInfo.Name = "groupBoxSnapshotInfo";
            this.groupBoxSnapshotInfo.Size = new System.Drawing.Size(275, 77);
            this.groupBoxSnapshotInfo.TabIndex = 3;
            this.groupBoxSnapshotInfo.TabStop = false;
            this.groupBoxSnapshotInfo.Text = "Snapshot info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Download size:";
            // 
            // labelSnapshotSize
            // 
            this.labelSnapshotSize.AutoSize = true;
            this.labelSnapshotSize.Location = new System.Drawing.Point(128, 53);
            this.labelSnapshotSize.Name = "labelSnapshotSize";
            this.labelSnapshotSize.Size = new System.Drawing.Size(12, 15);
            this.labelSnapshotSize.TabIndex = 2;
            this.labelSnapshotSize.Text = "-";
            // 
            // labelSnapshotDate
            // 
            this.labelSnapshotDate.AutoSize = true;
            this.labelSnapshotDate.Location = new System.Drawing.Point(128, 36);
            this.labelSnapshotDate.Name = "labelSnapshotDate";
            this.labelSnapshotDate.Size = new System.Drawing.Size(12, 15);
            this.labelSnapshotDate.TabIndex = 2;
            this.labelSnapshotDate.Text = "-";
            // 
            // labelSnapshotHeight
            // 
            this.labelSnapshotHeight.AutoSize = true;
            this.labelSnapshotHeight.Location = new System.Drawing.Point(128, 19);
            this.labelSnapshotHeight.Name = "labelSnapshotHeight";
            this.labelSnapshotHeight.Size = new System.Drawing.Size(12, 15);
            this.labelSnapshotHeight.TabIndex = 2;
            this.labelSnapshotHeight.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Block height:";
            // 
            // panelLocalState
            // 
            this.panelLocalState.Controls.Add(this.labelLocalStateTitle);
            this.panelLocalState.Controls.Add(this.labelLocalStateValue);
            this.panelLocalState.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLocalState.Location = new System.Drawing.Point(0, 37);
            this.panelLocalState.Name = "panelLocalState";
            this.panelLocalState.Size = new System.Drawing.Size(275, 23);
            this.panelLocalState.TabIndex = 4;
            // 
            // labelLocalStateTitle
            // 
            this.labelLocalStateTitle.AutoSize = true;
            this.labelLocalStateTitle.Location = new System.Drawing.Point(0, 0);
            this.labelLocalStateTitle.Name = "labelLocalStateTitle";
            this.labelLocalStateTitle.Size = new System.Drawing.Size(99, 15);
            this.labelLocalStateTitle.TabIndex = 1;
            this.labelLocalStateTitle.Text = "Local blockchain:";
            // 
            // labelLocalStateValue
            // 
            this.labelLocalStateValue.AutoSize = true;
            this.labelLocalStateValue.Location = new System.Drawing.Point(128, 0);
            this.labelLocalStateValue.Name = "labelLocalStateValue";
            this.labelLocalStateValue.Size = new System.Drawing.Size(12, 15);
            this.labelLocalStateValue.TabIndex = 2;
            this.labelLocalStateValue.Text = "-";
            // 
            // labelQuestionTitle
            // 
            this.labelQuestionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuestionTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelQuestionTitle.Location = new System.Drawing.Point(0, 0);
            this.labelQuestionTitle.Name = "labelQuestionTitle";
            this.labelQuestionTitle.Size = new System.Drawing.Size(275, 37);
            this.labelQuestionTitle.TabIndex = 0;
            this.labelQuestionTitle.Text = "A new blockchain snapshot is available. Do you want to download the newest snapsh" +
    "ot?";
            // 
            // panelDownloadStatus
            // 
            this.panelDownloadStatus.Controls.Add(this.panel2);
            this.panelDownloadStatus.Controls.Add(this.panelExtractDetails);
            this.panelDownloadStatus.Controls.Add(this.panelDownloadDetails);
            this.panelDownloadStatus.Controls.Add(this.labelDownloadTitle);
            this.panelDownloadStatus.Location = new System.Drawing.Point(178, 12);
            this.panelDownloadStatus.Name = "panelDownloadStatus";
            this.panelDownloadStatus.Size = new System.Drawing.Size(233, 201);
            this.panelDownloadStatus.TabIndex = 1;
            this.panelDownloadStatus.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCancelDownload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 27);
            this.panel2.TabIndex = 5;
            // 
            // buttonCancelDownload
            // 
            this.buttonCancelDownload.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelDownload.Image")));
            this.buttonCancelDownload.Location = new System.Drawing.Point(3, 2);
            this.buttonCancelDownload.Name = "buttonCancelDownload";
            this.buttonCancelDownload.Size = new System.Drawing.Size(104, 23);
            this.buttonCancelDownload.TabIndex = 0;
            this.buttonCancelDownload.Text = "Cancel";
            this.buttonCancelDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelDownload.UseVisualStyleBackColor = true;
            this.buttonCancelDownload.Click += new System.EventHandler(this.buttonCancelDownload_Click);
            // 
            // panelExtractDetails
            // 
            this.panelExtractDetails.Controls.Add(this.label12);
            this.panelExtractDetails.Controls.Add(this.labelExtractedFiles);
            this.panelExtractDetails.Controls.Add(this.labelExtractedProgress);
            this.panelExtractDetails.Controls.Add(this.label18);
            this.panelExtractDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExtractDetails.Location = new System.Drawing.Point(0, 117);
            this.panelExtractDetails.Name = "panelExtractDetails";
            this.panelExtractDetails.Size = new System.Drawing.Size(233, 42);
            this.panelExtractDetails.TabIndex = 4;
            this.panelExtractDetails.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Files:";
            // 
            // labelExtractedFiles
            // 
            this.labelExtractedFiles.AutoSize = true;
            this.labelExtractedFiles.Location = new System.Drawing.Point(122, 0);
            this.labelExtractedFiles.Name = "labelExtractedFiles";
            this.labelExtractedFiles.Size = new System.Drawing.Size(12, 15);
            this.labelExtractedFiles.TabIndex = 2;
            this.labelExtractedFiles.Text = "-";
            // 
            // labelExtractedProgress
            // 
            this.labelExtractedProgress.AutoSize = true;
            this.labelExtractedProgress.Location = new System.Drawing.Point(122, 19);
            this.labelExtractedProgress.Name = "labelExtractedProgress";
            this.labelExtractedProgress.Size = new System.Drawing.Size(12, 15);
            this.labelExtractedProgress.TabIndex = 2;
            this.labelExtractedProgress.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 1;
            this.label18.Text = "Progress:";
            // 
            // panelDownloadDetails
            // 
            this.panelDownloadDetails.Controls.Add(this.label5);
            this.panelDownloadDetails.Controls.Add(this.label11);
            this.panelDownloadDetails.Controls.Add(this.labelDownloadedSize);
            this.panelDownloadDetails.Controls.Add(this.labelDownloadedTimeLeft);
            this.panelDownloadDetails.Controls.Add(this.labelDownloadedProgress);
            this.panelDownloadDetails.Controls.Add(this.label9);
            this.panelDownloadDetails.Controls.Add(this.label7);
            this.panelDownloadDetails.Controls.Add(this.labelDownloadedSpeed);
            this.panelDownloadDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDownloadDetails.Location = new System.Drawing.Point(0, 37);
            this.panelDownloadDetails.Name = "panelDownloadDetails";
            this.panelDownloadDetails.Size = new System.Drawing.Size(233, 80);
            this.panelDownloadDetails.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Downloaded:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Time left:";
            // 
            // labelDownloadedSize
            // 
            this.labelDownloadedSize.AutoSize = true;
            this.labelDownloadedSize.Location = new System.Drawing.Point(122, 0);
            this.labelDownloadedSize.Name = "labelDownloadedSize";
            this.labelDownloadedSize.Size = new System.Drawing.Size(12, 15);
            this.labelDownloadedSize.TabIndex = 2;
            this.labelDownloadedSize.Text = "-";
            // 
            // labelDownloadedTimeLeft
            // 
            this.labelDownloadedTimeLeft.AutoSize = true;
            this.labelDownloadedTimeLeft.Location = new System.Drawing.Point(122, 55);
            this.labelDownloadedTimeLeft.Name = "labelDownloadedTimeLeft";
            this.labelDownloadedTimeLeft.Size = new System.Drawing.Size(12, 15);
            this.labelDownloadedTimeLeft.TabIndex = 2;
            this.labelDownloadedTimeLeft.Text = "-";
            // 
            // labelDownloadedProgress
            // 
            this.labelDownloadedProgress.AutoSize = true;
            this.labelDownloadedProgress.Location = new System.Drawing.Point(122, 19);
            this.labelDownloadedProgress.Name = "labelDownloadedProgress";
            this.labelDownloadedProgress.Size = new System.Drawing.Size(12, 15);
            this.labelDownloadedProgress.TabIndex = 2;
            this.labelDownloadedProgress.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Speed:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Progress:";
            // 
            // labelDownloadedSpeed
            // 
            this.labelDownloadedSpeed.AutoSize = true;
            this.labelDownloadedSpeed.Location = new System.Drawing.Point(122, 37);
            this.labelDownloadedSpeed.Name = "labelDownloadedSpeed";
            this.labelDownloadedSpeed.Size = new System.Drawing.Size(12, 15);
            this.labelDownloadedSpeed.TabIndex = 2;
            this.labelDownloadedSpeed.Text = "-";
            // 
            // labelDownloadTitle
            // 
            this.labelDownloadTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDownloadTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDownloadTitle.Location = new System.Drawing.Point(0, 0);
            this.labelDownloadTitle.Name = "labelDownloadTitle";
            this.labelDownloadTitle.Size = new System.Drawing.Size(233, 37);
            this.labelDownloadTitle.TabIndex = 0;
            this.labelDownloadTitle.Text = "Downloading snapshot...";
            // 
            // timerDownload
            // 
            this.timerDownload.Interval = 1000;
            this.timerDownload.Tick += new System.EventHandler(this.timerDownload_Tick);
            // 
            // timerExtract
            // 
            this.timerExtract.Interval = 1000;
            this.timerExtract.Tick += new System.EventHandler(this.timerExtract_Tick);
            // 
            // DownloadSnapshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 224);
            this.Controls.Add(this.panelDownloadStatus);
            this.Controls.Add(this.panelQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadSnapshotForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Blockchain snapshot download";
            this.panelQuestion.ResumeLayout(false);
            this.panelButtonDownload.ResumeLayout(false);
            this.groupBoxSnapshotInfo.ResumeLayout(false);
            this.groupBoxSnapshotInfo.PerformLayout();
            this.panelLocalState.ResumeLayout(false);
            this.panelLocalState.PerformLayout();
            this.panelDownloadStatus.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelExtractDetails.ResumeLayout(false);
            this.panelExtractDetails.PerformLayout();
            this.panelDownloadDetails.ResumeLayout(false);
            this.panelDownloadDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelQuestion;
        private Panel panelDownloadStatus;
        private Panel panelButtonDownload;
        private Button buttonSkip;
        private Button buttonDownload;
        private GroupBox groupBoxSnapshotInfo;
        private Label label3;
        private Label labelSnapshotSize;
        private Label labelSnapshotDate;
        private Label labelSnapshotHeight;
        private Label label2;
        private Label label1;
        private Panel panelLocalState;
        private Label labelLocalStateTitle;
        private Label labelLocalStateValue;
        private Label labelQuestionTitle;
        private Label labelDownloadTitle;
        private Label label11;
        private Label labelDownloadedTimeLeft;
        private Label label9;
        private Label labelDownloadedSpeed;
        private Label label7;
        private Label labelDownloadedProgress;
        private Label label5;
        private Label labelDownloadedSize;
        private Panel panel2;
        private Button buttonCancelDownload;
        private Panel panelExtractDetails;
        private Label label12;
        private Label labelExtractedFiles;
        private Label labelExtractedProgress;
        private Label label18;
        private Panel panelDownloadDetails;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.Timer timerExtract;
    }
}
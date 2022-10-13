namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class TransactionSendResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionSendResultForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTransactionPayload = new System.Windows.Forms.Label();
            this.labelTransactionMessage = new System.Windows.Forms.Label();
            this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSender = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelRecipient = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timerRefreshStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.Location = new System.Drawing.Point(199, 167);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(119, 27);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // timerAutoClose
            // 
            this.timerAutoClose.Interval = 1000;
            this.timerAutoClose.Tick += new System.EventHandler(this.timerAutoClose_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(76, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Successfull created Transaction";
            // 
            // labelTransactionPayload
            // 
            this.labelTransactionPayload.AutoSize = true;
            this.labelTransactionPayload.Location = new System.Drawing.Point(166, 69);
            this.labelTransactionPayload.Name = "labelTransactionPayload";
            this.labelTransactionPayload.Size = new System.Drawing.Size(16, 15);
            this.labelTransactionPayload.TabIndex = 3;
            this.labelTransactionPayload.Text = "...";
            // 
            // labelTransactionMessage
            // 
            this.labelTransactionMessage.AutoSize = true;
            this.labelTransactionMessage.Location = new System.Drawing.Point(166, 88);
            this.labelTransactionMessage.Name = "labelTransactionMessage";
            this.labelTransactionMessage.Size = new System.Drawing.Size(16, 15);
            this.labelTransactionMessage.TabIndex = 4;
            this.labelTransactionMessage.Text = "...";
            // 
            // imageListStatus
            // 
            this.imageListStatus.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
            this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStatus.Images.SetKeyName(0, "hourglass.png");
            this.imageListStatus.Images.SetKeyName(1, "check2.png");
            this.imageListStatus.Images.SetKeyName(2, "warning.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Details:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(166, 107);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 15);
            this.labelId.TabIndex = 4;
            this.labelId.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Transaction ID:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(166, 126);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(16, 15);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Status:";
            // 
            // labelSender
            // 
            this.labelSender.AutoSize = true;
            this.labelSender.Location = new System.Drawing.Point(166, 31);
            this.labelSender.Name = "labelSender";
            this.labelSender.Size = new System.Drawing.Size(16, 15);
            this.labelSender.TabIndex = 3;
            this.labelSender.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Sender:";
            // 
            // labelRecipient
            // 
            this.labelRecipient.AutoSize = true;
            this.labelRecipient.Location = new System.Drawing.Point(166, 50);
            this.labelRecipient.Name = "labelRecipient";
            this.labelRecipient.Size = new System.Drawing.Size(16, 15);
            this.labelRecipient.TabIndex = 3;
            this.labelRecipient.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Recipient:";
            // 
            // timerRefreshStatus
            // 
            this.timerRefreshStatus.Interval = 1000;
            this.timerRefreshStatus.Tick += new System.EventHandler(this.timerRefreshStatus_Tick);
            // 
            // TransactionSendResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 206);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRecipient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSender);
            this.Controls.Add(this.labelTransactionMessage);
            this.Controls.Add(this.labelTransactionPayload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TransactionSendResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction created";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonClose;
        private System.Windows.Forms.Timer timerAutoClose;
        private PictureBox pictureBox1;
        private Label label1;
        private Label labelTransactionPayload;
        private Label labelTransactionMessage;
        private ImageList imageListStatus;
        private Label label2;
        private Label label3;
        private Label labelId;
        private Label label5;
        private Label labelStatus;
        private Label label7;
        private Label labelSender;
        private Label label9;
        private Label labelRecipient;
        private Label label11;
        private System.Windows.Forms.Timer timerRefreshStatus;
    }
}
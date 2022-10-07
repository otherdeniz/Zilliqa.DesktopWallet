namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class TransactionCreatedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCreatedForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTransactionPayload = new System.Windows.Forms.Label();
            this.labelTransactionMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.Location = new System.Drawing.Point(189, 68);
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
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
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
            this.labelTransactionPayload.Location = new System.Drawing.Point(76, 29);
            this.labelTransactionPayload.Name = "labelTransactionPayload";
            this.labelTransactionPayload.Size = new System.Drawing.Size(16, 15);
            this.labelTransactionPayload.TabIndex = 3;
            this.labelTransactionPayload.Text = "...";
            // 
            // labelTransactionMessage
            // 
            this.labelTransactionMessage.AutoSize = true;
            this.labelTransactionMessage.Location = new System.Drawing.Point(76, 48);
            this.labelTransactionMessage.Name = "labelTransactionMessage";
            this.labelTransactionMessage.Size = new System.Drawing.Size(16, 15);
            this.labelTransactionMessage.TabIndex = 4;
            this.labelTransactionMessage.Text = "...";
            // 
            // TransactionCreatedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 107);
            this.Controls.Add(this.labelTransactionMessage);
            this.Controls.Add(this.labelTransactionPayload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TransactionCreatedForm";
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
    }
}
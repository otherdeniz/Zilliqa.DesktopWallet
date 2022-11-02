namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    partial class WhaleTransferNotificationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhaleTransferNotificationControl));
            this.labelValue = new System.Windows.Forms.Label();
            this.labelValueTitle = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(90, 15);
            this.labelTitle.Text = "Whale transfer";
            // 
            // pictureImage
            // 
            this.pictureImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureImage.Image")));
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(45, 77);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(43, 15);
            this.labelValue.TabIndex = 17;
            this.labelValue.Text = "(Value)";
            // 
            // labelValueTitle
            // 
            this.labelValueTitle.AutoSize = true;
            this.labelValueTitle.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelValueTitle.Location = new System.Drawing.Point(0, 78);
            this.labelValueTitle.Name = "labelValueTitle";
            this.labelValueTitle.Size = new System.Drawing.Size(22, 12);
            this.labelValueTitle.TabIndex = 16;
            this.labelValueTitle.Text = "USD";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAmount.Location = new System.Drawing.Point(45, 59);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(60, 15);
            this.labelAmount.TabIndex = 15;
            this.labelAmount.Text = "(Amount)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Amount";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(45, 25);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(51, 15);
            this.labelFrom.TabIndex = 12;
            this.labelFrom.Text = "(Sender)";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(45, 42);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(59, 15);
            this.labelTo.TabIndex = 13;
            this.labelTo.Text = "(Receiver)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "To";
            // 
            // WhaleTransferNotificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelValueTitle);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WhaleTransferNotificationControl";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.labelTo, 0);
            this.Controls.SetChildIndex(this.labelFrom, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.labelAmount, 0);
            this.Controls.SetChildIndex(this.labelValueTitle, 0);
            this.Controls.SetChildIndex(this.labelValue, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelValue;
        private Label labelValueTitle;
        private Label labelAmount;
        private Label label4;
        private Label labelFrom;
        private Label labelTo;
        private Label label2;
        private Label label1;
    }
}

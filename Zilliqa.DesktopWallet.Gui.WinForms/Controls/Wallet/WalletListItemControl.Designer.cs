namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    partial class WalletListItemControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(21, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 19);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "[Name]";
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAmount.Location = new System.Drawing.Point(5, 37);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(136, 15);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "0 ZIL + 0 Tokens = 0 USD";
            this.labelAmount.Click += new System.EventHandler(this.labelAmount_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddress.Location = new System.Drawing.Point(5, 20);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(78, 15);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "zil1 xxx ... xxx";
            this.labelAddress.Click += new System.EventHandler(this.labelAmount_Click);
            // 
            // pictureIcon
            // 
            this.pictureIcon.Location = new System.Drawing.Point(5, 3);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(16, 16);
            this.pictureIcon.TabIndex = 3;
            this.pictureIcon.TabStop = false;
            // 
            // WalletListItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureIcon);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "WalletListItemControl";
            this.Size = new System.Drawing.Size(366, 56);
            this.Click += new System.EventHandler(this.WalletListItemControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelName;
        private Label labelAmount;
        private Label labelAddress;
        private PictureBox pictureIcon;
    }
}

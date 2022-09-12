namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class AddWatchedAccountForm
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
            this.panelPage1 = new System.Windows.Forms.Panel();
            this.checkBoxMyAddress = new System.Windows.Forms.CheckBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textWalletName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(570, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(678, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.checkBoxMyAddress);
            this.panelPage1.Controls.Add(this.textAddress);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.textWalletName);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(784, 181);
            this.panelPage1.TabIndex = 0;
            // 
            // checkBoxMyAddress
            // 
            this.checkBoxMyAddress.AutoSize = true;
            this.checkBoxMyAddress.Location = new System.Drawing.Point(8, 136);
            this.checkBoxMyAddress.Name = "checkBoxMyAddress";
            this.checkBoxMyAddress.Size = new System.Drawing.Size(178, 19);
            this.checkBoxMyAddress.TabIndex = 12;
            this.checkBoxMyAddress.Text = "This Address is owned by me";
            this.checkBoxMyAddress.UseVisualStyleBackColor = true;
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(3, 101);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(775, 23);
            this.textAddress.TabIndex = 1;
            this.textAddress.TextChanged += new System.EventHandler(this.textAddress_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Address";
            // 
            // textWalletName
            // 
            this.textWalletName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWalletName.Location = new System.Drawing.Point(3, 38);
            this.textWalletName.Name = "textWalletName";
            this.textWalletName.Size = new System.Drawing.Size(775, 23);
            this.textWalletName.TabIndex = 0;
            this.textWalletName.TextChanged += new System.EventHandler(this.textWalletName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "The display name to identify your first Account. This title is not visible to oth" +
    "er people.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Account Title";
            // 
            // AddWatchedAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 234);
            this.Controls.Add(this.panelPage1);
            this.Name = "AddWatchedAccountForm";
            this.Text = "Add Watched Account";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textAddress;
        private Label label4;
        private TextBox textWalletName;
        private Label label2;
        private Label label5;
        private CheckBox checkBoxMyAddress;
    }
}
namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class CreateMyAccountForm
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
            this.textPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textWalletName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(401, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(509, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.textPassword1);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Controls.Add(this.textWalletName);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(615, 158);
            this.panelPage1.TabIndex = 0;
            // 
            // textPassword1
            // 
            this.textPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword1.Location = new System.Drawing.Point(3, 98);
            this.textPassword1.Name = "textPassword1";
            this.textPassword1.PasswordChar = '*';
            this.textPassword1.Size = new System.Drawing.Size(606, 23);
            this.textPassword1.TabIndex = 1;
            this.textPassword1.TextChanged += new System.EventHandler(this.textPassword1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wallet Password";
            // 
            // textWalletName
            // 
            this.textWalletName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWalletName.Location = new System.Drawing.Point(3, 38);
            this.textWalletName.Name = "textWalletName";
            this.textWalletName.Size = new System.Drawing.Size(606, 23);
            this.textWalletName.TabIndex = 0;
            this.textWalletName.TextChanged += new System.EventHandler(this.textWalletName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your current Wallet password.";
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
            // CreateMyAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 211);
            this.Controls.Add(this.panelPage1);
            this.Name = "CreateMyAccountForm";
            this.Text = "Create Account";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textWalletName;
        private Label label2;
        private Label label5;
        private TextBox textPassword1;
        private Label label1;
        private Label label3;
    }
}
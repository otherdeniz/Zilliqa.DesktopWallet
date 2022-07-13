namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class CreatePasswordForm
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
            this.textWalletName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPassword2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(507, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(424, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.textWalletName);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Controls.Add(this.textPassword2);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.textPassword1);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(588, 222);
            this.panelPage1.TabIndex = 0;
            // 
            // textWalletName
            // 
            this.textWalletName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWalletName.Location = new System.Drawing.Point(3, 38);
            this.textWalletName.Name = "textWalletName";
            this.textWalletName.Size = new System.Drawing.Size(582, 23);
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
            // textPassword2
            // 
            this.textPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword2.Location = new System.Drawing.Point(3, 176);
            this.textPassword2.Name = "textPassword2";
            this.textPassword2.Size = new System.Drawing.Size(582, 23);
            this.textPassword2.TabIndex = 2;
            this.textPassword2.TextChanged += new System.EventHandler(this.textPassword2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum length: 12 Characters. Please choose a verry strong password.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Repeat Password";
            // 
            // textPassword1
            // 
            this.textPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword1.Location = new System.Drawing.Point(3, 100);
            this.textPassword1.Name = "textPassword1";
            this.textPassword1.PasswordChar = '*';
            this.textPassword1.Size = new System.Drawing.Size(582, 23);
            this.textPassword1.TabIndex = 1;
            this.textPassword1.TextChanged += new System.EventHandler(this.textPassword1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wallet Password";
            // 
            // CreatePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 275);
            this.Controls.Add(this.panelPage1);
            this.Name = "CreatePasswordForm";
            this.Text = "Create Wallet";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textPassword2;
        private Label label3;
        private Label label4;
        private TextBox textPassword1;
        private Label label1;
        private TextBox textWalletName;
        private Label label2;
        private Label label5;
    }
}
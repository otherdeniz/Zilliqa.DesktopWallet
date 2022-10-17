namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class DialogWithPasswordBaseForm
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
            this.panelPassword = new System.Windows.Forms.Panel();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelPasswortHint = new System.Windows.Forms.Label();
            this.panelPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(448, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(556, 6);
            // 
            // panelPassword
            // 
            this.panelPassword.Controls.Add(this.textPassword);
            this.panelPassword.Controls.Add(this.labelPassword);
            this.panelPassword.Controls.Add(this.labelPasswortHint);
            this.panelPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPassword.Location = new System.Drawing.Point(8, 226);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(662, 84);
            this.panelPassword.TabIndex = 98;
            // 
            // textPassword
            // 
            this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword.Location = new System.Drawing.Point(3, 29);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(653, 23);
            this.textPassword.TabIndex = 103;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword1_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPassword.Location = new System.Drawing.Point(3, 11);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(93, 15);
            this.labelPassword.TabIndex = 105;
            this.labelPassword.Text = "Wallet Password";
            // 
            // labelPasswortHint
            // 
            this.labelPasswortHint.AutoSize = true;
            this.labelPasswortHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelPasswortHint.Location = new System.Drawing.Point(3, 55);
            this.labelPasswortHint.Name = "labelPasswortHint";
            this.labelPasswortHint.Size = new System.Drawing.Size(164, 15);
            this.labelPasswortHint.TabIndex = 104;
            this.labelPasswortHint.Text = "Your current Wallet password.";
            // 
            // DialogWithPasswordBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 355);
            this.Controls.Add(this.panelPassword);
            this.Name = "DialogWithPasswordBaseForm";
            this.Text = "DialogWithPasswordBaseForm";
            this.Controls.SetChildIndex(this.panelPassword, 0);
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPassword;
        private TextBox textPassword;
        private Label labelPassword;
        private Label labelPasswortHint;
    }
}
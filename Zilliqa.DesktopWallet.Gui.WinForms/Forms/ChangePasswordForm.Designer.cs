namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class ChangePasswordForm
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
            this.textNewPassword2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textNewPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textOldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(474, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(582, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.textNewPassword2);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.textNewPassword1);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPage1.Location = new System.Drawing.Point(8, 83);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(688, 124);
            this.panelPage1.TabIndex = 1;
            // 
            // textNewPassword2
            // 
            this.textNewPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNewPassword2.Location = new System.Drawing.Point(5, 92);
            this.textNewPassword2.Name = "textNewPassword2";
            this.textNewPassword2.PasswordChar = '*';
            this.textNewPassword2.Size = new System.Drawing.Size(677, 23);
            this.textNewPassword2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum length: 12 Characters. Please choose a verry strong password.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Repeat new password";
            // 
            // textNewPassword1
            // 
            this.textNewPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNewPassword1.Location = new System.Drawing.Point(5, 21);
            this.textNewPassword1.Name = "textNewPassword1";
            this.textNewPassword1.PasswordChar = '*';
            this.textNewPassword1.Size = new System.Drawing.Size(677, 23);
            this.textNewPassword1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set new password";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textOldPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 75);
            this.panel1.TabIndex = 0;
            // 
            // textOldPassword
            // 
            this.textOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOldPassword.Location = new System.Drawing.Point(3, 18);
            this.textOldPassword.Name = "textOldPassword";
            this.textOldPassword.PasswordChar = '*';
            this.textOldPassword.Size = new System.Drawing.Size(679, 23);
            this.textOldPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current wallet password";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 252);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPage1);
            this.Name = "ChangePasswordForm";
            this.Text = "Change Password";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textNewPassword2;
        private Label label3;
        private Label label4;
        private TextBox textNewPassword1;
        private Label label1;
        private Panel panel1;
        private TextBox textOldPassword;
        private Label label2;
    }
}
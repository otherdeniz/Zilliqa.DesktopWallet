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
            this.textPassword2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonCreateNow = new System.Windows.Forms.RadioButton();
            this.radioButtonNotCreate = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addAccountControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.AddAccountControl();
            this.panelPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(374, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(482, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.textPassword2);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.textPassword1);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPage1.Location = new System.Drawing.Point(8, 270);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(588, 124);
            this.panelPage1.TabIndex = 0;
            // 
            // textPassword2
            // 
            this.textPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword2.Location = new System.Drawing.Point(5, 92);
            this.textPassword2.Name = "textPassword2";
            this.textPassword2.PasswordChar = '*';
            this.textPassword2.Size = new System.Drawing.Size(582, 23);
            this.textPassword2.TabIndex = 2;
            this.textPassword2.TextChanged += new System.EventHandler(this.textPassword2_TextChanged);
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
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Repeat Password";
            // 
            // textPassword1
            // 
            this.textPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword1.Location = new System.Drawing.Point(5, 21);
            this.textPassword1.Name = "textPassword1";
            this.textPassword1.PasswordChar = '*';
            this.textPassword1.Size = new System.Drawing.Size(582, 23);
            this.textPassword1.TabIndex = 1;
            this.textPassword1.TextChanged += new System.EventHandler(this.textPassword1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wallet Password";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonCreateNow);
            this.panel1.Controls.Add(this.radioButtonNotCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 53);
            this.panel1.TabIndex = 100;
            // 
            // radioButtonCreateNow
            // 
            this.radioButtonCreateNow.AutoSize = true;
            this.radioButtonCreateNow.Location = new System.Drawing.Point(5, 25);
            this.radioButtonCreateNow.Name = "radioButtonCreateNow";
            this.radioButtonCreateNow.Size = new System.Drawing.Size(121, 19);
            this.radioButtonCreateNow.TabIndex = 0;
            this.radioButtonCreateNow.Text = "Add Account now";
            this.radioButtonCreateNow.UseVisualStyleBackColor = true;
            this.radioButtonCreateNow.CheckedChanged += new System.EventHandler(this.radioButtonCreateNow_CheckedChanged);
            // 
            // radioButtonNotCreate
            // 
            this.radioButtonNotCreate.AutoSize = true;
            this.radioButtonNotCreate.Checked = true;
            this.radioButtonNotCreate.Location = new System.Drawing.Point(5, 3);
            this.radioButtonNotCreate.Name = "radioButtonNotCreate";
            this.radioButtonNotCreate.Size = new System.Drawing.Size(121, 19);
            this.radioButtonNotCreate.TabIndex = 0;
            this.radioButtonNotCreate.TabStop = true;
            this.radioButtonNotCreate.Text = "Add Account later";
            this.radioButtonNotCreate.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addAccountControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 61);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(588, 209);
            this.panel2.TabIndex = 8;
            // 
            // addAccountControl
            // 
            this.addAccountControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addAccountControl.Location = new System.Drawing.Point(5, 0);
            this.addAccountControl.Name = "addAccountControl";
            this.addAccountControl.Padding = new System.Windows.Forms.Padding(3);
            this.addAccountControl.Size = new System.Drawing.Size(583, 209);
            this.addAccountControl.TabIndex = 0;
            this.addAccountControl.Visible = false;
            this.addAccountControl.ValueChanged += new System.EventHandler<System.EventArgs>(this.addAccountControl_ValueChanged);
            // 
            // CreatePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 439);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPage1);
            this.Name = "CreatePasswordForm";
            this.Text = "Create Wallet";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textPassword2;
        private Label label3;
        private Label label4;
        private TextBox textPassword1;
        private Label label1;
        private Panel panel1;
        private RadioButton radioButtonCreateNow;
        private RadioButton radioButtonNotCreate;
        private Panel panel2;
        private Controls.Wallet.AddAccountControl addAccountControl;
    }
}
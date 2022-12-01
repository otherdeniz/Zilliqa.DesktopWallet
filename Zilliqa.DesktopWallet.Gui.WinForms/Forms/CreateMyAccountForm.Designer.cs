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
            this.addAccountControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.AddAccountControl();
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
            // addAccountControl
            // 
            this.addAccountControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addAccountControl.Location = new System.Drawing.Point(8, 8);
            this.addAccountControl.Name = "addAccountControl";
            this.addAccountControl.Padding = new System.Windows.Forms.Padding(3);
            this.addAccountControl.Size = new System.Drawing.Size(615, 212);
            this.addAccountControl.TabIndex = 101;
            this.addAccountControl.ValueChanged += new System.EventHandler<System.EventArgs>(this.addAccountControl1_ValueChanged);
            // 
            // CreateMyAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 349);
            this.Controls.Add(this.addAccountControl);
            this.DisplaySenderAccount = false;
            this.Name = "CreateMyAccountForm";
            this.Text = "Add Account";
            this.Controls.SetChildIndex(this.addAccountControl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Wallet.AddAccountControl addAccountControl;
    }
}
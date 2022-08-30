using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    partial class WalletAddressControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletAddressControl));
            this.toolStripAccountActions = new System.Windows.Forms.ToolStrip();
            this.buttonSend = new System.Windows.Forms.ToolStripButton();
            this.buttonSendToken = new System.Windows.Forms.ToolStripButton();
            this.separatorSend = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackupPrivateKey = new System.Windows.Forms.ToolStripButton();
            this.separatorBackup = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveAccount = new System.Windows.Forms.ToolStripButton();
            this.addressDetails = new AddressDetailsControl();
            this.toolStripAccountActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAccountActions
            // 
            this.toolStripAccountActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSend,
            this.buttonSendToken,
            this.separatorSend,
            this.buttonBackupPrivateKey,
            this.separatorBackup,
            this.buttonRemoveAccount});
            this.toolStripAccountActions.Location = new System.Drawing.Point(0, 0);
            this.toolStripAccountActions.Name = "toolStripAccountActions";
            this.toolStripAccountActions.Size = new System.Drawing.Size(703, 25);
            this.toolStripAccountActions.TabIndex = 2;
            // 
            // buttonSend
            // 
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 22);
            this.buttonSend.Text = "Send ZIL";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonSendToken
            // 
            this.buttonSendToken.Image = ((System.Drawing.Image)(resources.GetObject("buttonSendToken.Image")));
            this.buttonSendToken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSendToken.Name = "buttonSendToken";
            this.buttonSendToken.Size = new System.Drawing.Size(136, 22);
            this.buttonSendToken.Text = "Send Fungible Token";
            this.buttonSendToken.Click += new System.EventHandler(this.buttonSendToken_Click);
            // 
            // separatorSend
            // 
            this.separatorSend.Name = "separatorSend";
            this.separatorSend.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonBackupPrivateKey
            // 
            this.buttonBackupPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackupPrivateKey.Image")));
            this.buttonBackupPrivateKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackupPrivateKey.Name = "buttonBackupPrivateKey";
            this.buttonBackupPrivateKey.Size = new System.Drawing.Size(127, 22);
            this.buttonBackupPrivateKey.Text = "Backup Private Key";
            this.buttonBackupPrivateKey.Click += new System.EventHandler(this.buttonBackupPrivateKey_Click);
            // 
            // separatorBackup
            // 
            this.separatorBackup.Name = "separatorBackup";
            this.separatorBackup.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveAccount.Image")));
            this.buttonRemoveAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(118, 22);
            this.buttonRemoveAccount.Text = "Remove Account";
            this.buttonRemoveAccount.Click += new System.EventHandler(this.buttonRemoveAccount_Click);
            // 
            // addressDetails
            // 
            this.addressDetails.BackColor = System.Drawing.Color.White;
            this.addressDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressDetails.DrillDownPanel = this;
            this.addressDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressDetails.IsDrillDownMainControl = true;
            this.addressDetails.Location = new System.Drawing.Point(0, 25);
            this.addressDetails.Name = "addressDetails";
            this.addressDetails.ShowCurrencyColumns = true;
            this.addressDetails.Size = new System.Drawing.Size(703, 658);
            this.addressDetails.TabIndex = 3;
            // 
            // WalletAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addressDetails);
            this.Controls.Add(this.toolStripAccountActions);
            this.Name = "WalletAddressControl";
            this.Size = new System.Drawing.Size(1047, 683);
            this.Controls.SetChildIndex(this.toolStripAccountActions, 0);
            this.Controls.SetChildIndex(this.addressDetails, 0);
            this.toolStripAccountActions.ResumeLayout(false);
            this.toolStripAccountActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStripAccountActions;
        private ToolStripButton buttonSend;
        private ToolStripButton buttonSendToken;
        private ToolStripSeparator separatorSend;
        private ToolStripButton buttonBackupPrivateKey;
        private ToolStripSeparator separatorBackup;
        private ToolStripButton buttonRemoveAccount;
        private AddressDetailsControl addressDetails;
    }
}

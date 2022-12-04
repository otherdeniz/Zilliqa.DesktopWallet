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
            this.buttonGetTestZil = new System.Windows.Forms.ToolStripButton();
            this.buttonSendToken = new System.Windows.Forms.ToolStripButton();
            this.menuStaking = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonStakingStake = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStakingClaim = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStakingUnstake = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStakeGetPendingWithdraw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSmartContracts = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonSmartContractCall = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSmartContractDeploy = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorSend = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackupPrivateKey = new System.Windows.Forms.ToolStripButton();
            this.separatorBackup = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveAccount = new System.Windows.Forms.ToolStripButton();
            this.addressDetails = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.AddressDetailsControl();
            this.toolStripAccountActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAccountActions
            // 
            this.toolStripAccountActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSend,
            this.buttonGetTestZil,
            this.buttonSendToken,
            this.menuStaking,
            this.menuSmartContracts,
            this.separatorSend,
            this.buttonBackupPrivateKey,
            this.separatorBackup,
            this.buttonRemoveAccount});
            this.toolStripAccountActions.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripAccountActions.Location = new System.Drawing.Point(0, 0);
            this.toolStripAccountActions.Name = "toolStripAccountActions";
            this.toolStripAccountActions.Size = new System.Drawing.Size(758, 23);
            this.toolStripAccountActions.TabIndex = 2;
            // 
            // buttonSend
            // 
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 20);
            this.buttonSend.Text = "Send ZIL";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonGetTestZil
            // 
            this.buttonGetTestZil.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetTestZil.Image")));
            this.buttonGetTestZil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGetTestZil.Name = "buttonGetTestZil";
            this.buttonGetTestZil.Size = new System.Drawing.Size(89, 20);
            this.buttonGetTestZil.Text = "Get Test-ZIL";
            this.buttonGetTestZil.Click += new System.EventHandler(this.buttonGetTestZil_Click);
            // 
            // buttonSendToken
            // 
            this.buttonSendToken.Image = ((System.Drawing.Image)(resources.GetObject("buttonSendToken.Image")));
            this.buttonSendToken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSendToken.Name = "buttonSendToken";
            this.buttonSendToken.Size = new System.Drawing.Size(136, 20);
            this.buttonSendToken.Text = "Send Fungible Token";
            this.buttonSendToken.Click += new System.EventHandler(this.buttonSendToken_Click);
            // 
            // menuStaking
            // 
            this.menuStaking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStakingStake,
            this.buttonStakingClaim,
            this.buttonStakingUnstake,
            this.buttonStakeGetPendingWithdraw});
            this.menuStaking.Image = ((System.Drawing.Image)(resources.GetObject("menuStaking.Image")));
            this.menuStaking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStaking.Name = "menuStaking";
            this.menuStaking.Size = new System.Drawing.Size(75, 20);
            this.menuStaking.Text = "Staking";
            // 
            // buttonStakingStake
            // 
            this.buttonStakingStake.Name = "buttonStakingStake";
            this.buttonStakingStake.Size = new System.Drawing.Size(224, 22);
            this.buttonStakingStake.Text = "Stake Funds";
            this.buttonStakingStake.Click += new System.EventHandler(this.buttonStakingStake_Click);
            // 
            // buttonStakingClaim
            // 
            this.buttonStakingClaim.Enabled = false;
            this.buttonStakingClaim.Name = "buttonStakingClaim";
            this.buttonStakingClaim.Size = new System.Drawing.Size(224, 22);
            this.buttonStakingClaim.Text = "Claim Rewards";
            this.buttonStakingClaim.Click += new System.EventHandler(this.buttonStakingClaim_Click);
            // 
            // buttonStakingUnstake
            // 
            this.buttonStakingUnstake.Enabled = false;
            this.buttonStakingUnstake.Name = "buttonStakingUnstake";
            this.buttonStakingUnstake.Size = new System.Drawing.Size(224, 22);
            this.buttonStakingUnstake.Text = "Unstake";
            this.buttonStakingUnstake.Click += new System.EventHandler(this.buttonStakingUnstake_Click);
            // 
            // buttonStakeGetPendingWithdraw
            // 
            this.buttonStakeGetPendingWithdraw.Enabled = false;
            this.buttonStakeGetPendingWithdraw.Name = "buttonStakeGetPendingWithdraw";
            this.buttonStakeGetPendingWithdraw.Size = new System.Drawing.Size(224, 22);
            this.buttonStakeGetPendingWithdraw.Text = "Get Pending Stake Withdraw";
            this.buttonStakeGetPendingWithdraw.Click += new System.EventHandler(this.buttonStakeGetPendingWithdraw_Click);
            // 
            // menuSmartContracts
            // 
            this.menuSmartContracts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSmartContractCall,
            this.buttonSmartContractDeploy});
            this.menuSmartContracts.Image = ((System.Drawing.Image)(resources.GetObject("menuSmartContracts.Image")));
            this.menuSmartContracts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSmartContracts.Name = "menuSmartContracts";
            this.menuSmartContracts.Size = new System.Drawing.Size(121, 20);
            this.menuSmartContracts.Text = "Smart Contracts";
            // 
            // buttonSmartContractCall
            // 
            this.buttonSmartContractCall.Image = ((System.Drawing.Image)(resources.GetObject("buttonSmartContractCall.Image")));
            this.buttonSmartContractCall.Name = "buttonSmartContractCall";
            this.buttonSmartContractCall.Size = new System.Drawing.Size(194, 22);
            this.buttonSmartContractCall.Text = "Call Smart Contract";
            this.buttonSmartContractCall.Click += new System.EventHandler(this.buttonSmartContractCall_Click);
            // 
            // buttonSmartContractDeploy
            // 
            this.buttonSmartContractDeploy.Image = ((System.Drawing.Image)(resources.GetObject("buttonSmartContractDeploy.Image")));
            this.buttonSmartContractDeploy.Name = "buttonSmartContractDeploy";
            this.buttonSmartContractDeploy.Size = new System.Drawing.Size(194, 22);
            this.buttonSmartContractDeploy.Text = "Deploy Smart Contract";
            this.buttonSmartContractDeploy.Click += new System.EventHandler(this.buttonSmartContractDeploy_Click);
            // 
            // separatorSend
            // 
            this.separatorSend.Name = "separatorSend";
            this.separatorSend.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonBackupPrivateKey
            // 
            this.buttonBackupPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackupPrivateKey.Image")));
            this.buttonBackupPrivateKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackupPrivateKey.Name = "buttonBackupPrivateKey";
            this.buttonBackupPrivateKey.Size = new System.Drawing.Size(124, 20);
            this.buttonBackupPrivateKey.Text = "Export Private-Key";
            this.buttonBackupPrivateKey.Click += new System.EventHandler(this.buttonBackupPrivateKey_Click);
            // 
            // separatorBackup
            // 
            this.separatorBackup.Name = "separatorBackup";
            this.separatorBackup.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveAccount.Image")));
            this.buttonRemoveAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(118, 20);
            this.buttonRemoveAccount.Text = "Remove Account";
            this.buttonRemoveAccount.Click += new System.EventHandler(this.buttonRemoveAccount_Click);
            // 
            // addressDetails
            // 
            this.addressDetails.BackColor = System.Drawing.Color.White;
            this.addressDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressDetails.IsDrillDownMainControl = true;
            this.addressDetails.Location = new System.Drawing.Point(0, 23);
            this.addressDetails.MasterPanel = this;
            this.addressDetails.Name = "addressDetails";
            this.addressDetails.ShowCurrencyColumns = true;
            this.addressDetails.Size = new System.Drawing.Size(758, 660);
            this.addressDetails.TabIndex = 3;
            this.addressDetails.AfterRefreshAccountDetails += new System.EventHandler<System.EventArgs>(this.addressDetails_AfterRefreshAccountDetails);
            this.addressDetails.PendingStakeWithdrawChanged += new System.EventHandler<System.EventArgs>(this.addressDetails_PendingStakeWithdrawChanged);
            // 
            // WalletAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addressDetails);
            this.Controls.Add(this.toolStripAccountActions);
            this.Name = "WalletAddressControl";
            this.Size = new System.Drawing.Size(1128, 683);
            this.Load += new System.EventHandler(this.WalletAddressControl_Load);
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
        private ToolStripButton buttonGetTestZil;
        private ToolStripDropDownButton menuStaking;
        private ToolStripMenuItem buttonStakingStake;
        private ToolStripMenuItem buttonStakingClaim;
        private ToolStripMenuItem buttonStakingUnstake;
        private ToolStripDropDownButton menuSmartContracts;
        private ToolStripMenuItem buttonSmartContractCall;
        private ToolStripMenuItem buttonSmartContractDeploy;
        private ToolStripMenuItem buttonStakeGetPendingWithdraw;
    }
}

﻿using System.ComponentModel;
using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletAddressControl : DrillDownMasterPanelControl
    {
        private AccountViewModel? _account;

        public WalletAddressControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AddressDetailsControl AddressDetailsControl => addressDetails;

        public void BindAccountViewModel(AccountViewModel account)
        {
            _account = account;
            SetMainValueUniqueId(account.Address);
            if (account.AccountData is MyAccount)
            {
                buttonSend.Visible = true;
                buttonSendToken.Visible = true;
                separatorSend.Visible = true;
                buttonBackupPrivateKey.Visible = true;
                separatorBackup.Visible = true;
            }
            else
            {
                buttonSend.Visible = false;
                buttonSendToken.Visible = false;
                separatorSend.Visible = false;
                buttonBackupPrivateKey.Visible = false;
                separatorBackup.Visible = false;
            }
            addressDetails.BindAccountViewModel(account, false);
        }

        private void WalletAddressControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                buttonGetTestZil.Visible = ApplicationInfo.IsTestnet;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount myAccount)
            {
                var sendZilResult = SendZilForm.Execute(this.ParentForm!);
                if (sendZilResult != null)
                {
                    var transactionInfo = SendTransactionService.Instance.SendZilToAddress(
                        sendZilResult.ToAddress, 
                        sendZilResult.Amount, 
                        myAccount.AccountDetails);
                    MessageBox.Show(transactionInfo.InfoMessage, "Transaction Info", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonGetTestZil_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://dev-wallet.zilliqa.com/faucet?network=testnet",
                UseShellExecute = true
            });
        }

        private void buttonSendToken_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackupPrivateKey_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveAccount_Click(object sender, EventArgs e)
        {
            if (_account != null
                && MessageBox.Show($"Are you sure to remove Account {_account.AccountData.Name}?", "Remove Account?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RepositoryManager.Instance.WalletRepository.RemoveAccount(_account.AccountData.Id);
                Visible = false;
            }
        }

    }
}

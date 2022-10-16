using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

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
                menuStaking.Visible = true;
                buttonRemoveAccount.Enabled = !_account.HasFunds;
            }
            else
            {
                buttonSend.Visible = false;
                buttonSendToken.Visible = false;
                separatorSend.Visible = false;
                buttonBackupPrivateKey.Visible = false;
                separatorBackup.Visible = false;
                menuStaking.Visible = false;
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

        private void buttonGetTestZil_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://dev-wallet.zilliqa.com/faucet?network=testnet",
                UseShellExecute = true
            });
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount myAccount)
            {
                var sendZilResult = SendZilForm.Execute(this.ParentForm!, _account);
                if (sendZilResult != null)
                {
                    var sendResult = SendTransactionService.Instance.SendZilToAddress(
                        myAccount.AccountDetails,
                        sendZilResult.ToAddress, 
                        sendZilResult.Amount);
                    TransactionSendResultForm.ExecuteShow(this.ParentForm!, sendResult);
                }
            }
        }

        private void buttonSendToken_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackupPrivateKey_Click(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount myAccount)
            {
                var exportKeyResult = ExportPrivateKeyForm.Execute(this.ParentForm!, myAccount.Address.GetBech32());
                if (exportKeyResult != null)
                {
                    if (File.Exists(exportKeyResult.FileName))
                    {
                        File.Delete(exportKeyResult.FileName);
                    }
                    using (var textWriter = File.CreateText(exportKeyResult.FileName))
                    {
                        var stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine($"Wallet Title = {myAccount.Name}");
                        stringBuilder.AppendLine($"Address = {myAccount.Address.GetBech32()}");
                        stringBuilder.AppendLine($"Public Key = {myAccount.PublicKey}");
                        stringBuilder.AppendLine($"Private Key = {myAccount.AccountDetails.GetPrivateKey()}");
                        textWriter.Write(stringBuilder);
                    }
                    MessageBox.Show($"Private Key successfull exported to: {exportKeyResult.FileName}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void addressDetails_AfterRefreshAccountDetails(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount)
            {
                buttonRemoveAccount.Enabled = !_account.HasFunds;
                var hasStakes = _account.ZilStakedBalance > 0;
                buttonStakingClaim.Enabled = hasStakes;
                buttonStakingUnstake.Enabled = hasStakes;
                buttonStakeGetPendingWithdraw.Enabled = hasStakes;
            }
        }

        private void buttonStakingStake_Click(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount myAccount)
            {
                var stakeResult = StakingStakeForm.Execute(this.ParentForm!, _account);
                if (stakeResult != null)
                {
                    var sendResult = StakingService.Instance.SendTransactionStake(
                        myAccount.AccountDetails,
                        stakeResult.SsnAddress,
                        stakeResult.Amount);
                    TransactionSendResultForm.ExecuteShow(this.ParentForm!, sendResult);
                }
            }
        }

        private void buttonStakingClaim_Click(object sender, EventArgs e)
        {
            if (_account?.AccountData is MyAccount myAccount)
            {
                var claimResult = StakingClaimForm.Execute(this.ParentForm!, _account);
                if (claimResult != null)
                {
                    //var transactionInfo = SendTransactionService.Instance.SendZilToAddress(
                    //    sendZilResult.ToAddress,
                    //    sendZilResult.Amount,
                    //    myAccount.AccountDetails);
                    MessageBox.Show("bla bla bla", "Transaction Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonStakingUnstake_Click(object sender, EventArgs e)
        {

        }

        private void buttonStakeGetPendingWithdraw_Click(object sender, EventArgs e)
        {

        }

    }
}

using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main;

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

        private void buttonSend_Click(object sender, EventArgs e)
        {

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

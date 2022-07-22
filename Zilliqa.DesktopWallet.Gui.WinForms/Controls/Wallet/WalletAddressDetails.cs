using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletAddressDetails : UserControl
    {
        private AccountViewModel _account;

        public WalletAddressDetails()
        {
            InitializeComponent();
        }

        public void LoadAccount(AccountViewModel account)
        {
            _account = account;
            //labelName.Text = _account.AccountData.Name;
        }

    }
}

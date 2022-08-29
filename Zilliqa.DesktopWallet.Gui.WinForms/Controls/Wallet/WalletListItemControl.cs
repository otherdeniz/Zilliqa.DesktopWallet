using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletListItemControl : HighlitableBaseControl
    {
        private AccountViewModel _accountViewModel;

        public WalletListItemControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> ButtonClicked;

        public AccountViewModel Account => _accountViewModel;

        public void AssignAccount(AccountViewModel account)
        {
            _accountViewModel = account;
            Tag = account;
            labelName.Text = $"{account.AccountData.Name} ({account.AccountData.GetAddressBech32().FromBech32ToShortReadable()})";
            RefreshAccount();
        }

        public void RefreshAccount()
        {
            labelAmount.Text = $"{Account.ZilTotalBalance:#,##0} ZIL + {Account.TokenBalances.Count} Tokens = {Account.TotalValueUsd:#,##0.00} USD";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OnAnyClick()
        {
            ButtonClicked.Invoke(this, EventArgs.Empty);
        }

        private void WalletListItemControl_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }

        private void labelName_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }

        private void labelAmount_Click(object sender, EventArgs e)
        {
            OnAnyClick();
        }
    }
}

using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel;
using SystemColors = System.Drawing.SystemColors;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletListItemControl : UserControl
    {
        private bool _isSelected;
        private AccountViewModel _accountViewModel;

        public WalletListItemControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> ButtonClicked;

        public AccountViewModel Account => _accountViewModel;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                this.BackColor = _isSelected ? SystemColors.ControlLight : SystemColors.Control;
            }
        }

        public void AssignAccount(AccountViewModel account)
        {
            _accountViewModel = account;
            Tag = account;
            labelName.Text = $"{account.AccountData.Name} ({account.AccountData.AddressBech32.FromBech32ToShortReadable()})";
            labelAmount.Text = "0 ZIL + 0 Tokens = 0 USD";
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

using Zilliqa.DesktopWallet.Core.ViewModel;
using SystemColors = System.Drawing.SystemColors;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletListItemControl : UserControl
    {
        private bool _isSelected;

        public WalletListItemControl()
        {
            InitializeComponent();
        }

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
            Tag = account;
            labelName.Text = account.AccountData.Name;
            labelAmount.Text = account.AccountData.AddressBech32;
        }
    }
}

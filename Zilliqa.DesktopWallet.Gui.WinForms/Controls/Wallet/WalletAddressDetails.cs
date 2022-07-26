using System.Diagnostics;
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
            textZilAddress.Text = account.AccountData.AddressBech32;
            //labelName.Text = _account.AccountData.Name;
        }

        private void buttonClipboardAddress_Click(object sender, EventArgs e)
        {
            buttonClipboardAddress.BackColor = Color.Green;
            buttonClipboardAddress.Refresh();
            timerButtonPressed.Enabled = true;
            Clipboard.SetText(_account.AccountData.AddressBech32);
        }

        private void buttonOpenBlockExplorer_Click(object sender, EventArgs e)
        {
            buttonOpenBlockExplorer.BackColor = Color.Green;
            buttonOpenBlockExplorer.Refresh();
            timerButtonPressed.Enabled = true;
            Process.Start(new ProcessStartInfo
            {
                FileName = $"https://viewblock.io/zilliqa/address/{_account.AccountData.AddressBech32}",
                UseShellExecute = true
            });
        }

        private void timerButtonPressed_Tick(object sender, EventArgs e)
        {
            timerButtonPressed.Enabled = false;
            buttonClipboardAddress.BackColor = SystemColors.Control;
            buttonOpenBlockExplorer.BackColor = SystemColors.Control;
        }
    }
}

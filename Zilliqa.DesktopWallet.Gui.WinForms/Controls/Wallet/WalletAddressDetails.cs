using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletAddressDetails : UserControl
    {
        private AccountViewModel? _account;

        public WalletAddressDetails()
        {
            InitializeComponent();
            gridViewZilTransactions.Dock = DockStyle.Fill;
            gridViewTokenTransactions.Dock = DockStyle.Fill;
        }

        public void LoadAccount(AccountViewModel account)
        {
            _account = account;
            textZilAddress.Text = account.AddressBech32;
            gridViewTokenBalances.LoadData(account.TokenBalances, typeof(AccountTokenBalanceRowViewModel));
            gridViewZilTransactions.LoadData(account.ZilTransactions, typeof(AccountZilTransactionRowViewModel));
            gridViewTokenTransactions.LoadData(account.TokenTransactions, typeof(AccountTokenTransactionRowViewModel));
            RefreshAccountSummaries();
        }

        public void RefreshAccountSummaries()
        {
            if (_account == null) return;

            if (!(groupBoxTokens.Tag is string groupBoxTokensText))
            {
                groupBoxTokens.Tag = groupBoxTokens.Text;
                groupBoxTokensText = groupBoxTokens.Text;
            }
            groupBoxTokens.Text = $"{groupBoxTokensText} ({_account.TokenBalances.Count})";

            if (!(tabButtonZilTransactions.Tag is string buttonZilTransactionsText))
            {
                tabButtonZilTransactions.Tag = tabButtonZilTransactions.Text;
                buttonZilTransactionsText = tabButtonZilTransactions.Text;
            }
            tabButtonZilTransactions.Text = $"{buttonZilTransactionsText} ({_account.ZilTransactions.Count})";

            if (!(tabButtonTokenTransactions.Tag is string buttonTokenTransactionsText))
            {
                tabButtonTokenTransactions.Tag = tabButtonTokenTransactions.Text;
                buttonTokenTransactionsText = tabButtonTokenTransactions.Text;
            }
            tabButtonTokenTransactions.Text = $"{buttonTokenTransactionsText} ({_account.TokenTransactions.Count})";

            labelTokensValue.Text = $"{_account.TokensValueUsd:#,##0.00} USD";
            labelZilPlusTokensValue.Text = $"{_account.TotalValueUsd:#,##0.00} USD";

        }

        private void WalletAddressDetails_Load(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonZilTransactions, gridViewZilTransactions);
        }

        private void buttonClipboardAddress_Click(object sender, EventArgs e)
        {
            if (_account == null) return;
            buttonClipboardAddress.BackColor = Color.Green;
            buttonClipboardAddress.Refresh();
            timerButtonPressed.Enabled = true;
            Clipboard.SetText(_account.AccountData.GetAddressBech32());
        }

        private void buttonOpenBlockExplorer_Click(object sender, EventArgs e)
        {
            if (_account == null) return;
            buttonOpenBlockExplorer.BackColor = Color.Green;
            buttonOpenBlockExplorer.Refresh();
            timerButtonPressed.Enabled = true;
            Process.Start(new ProcessStartInfo
            {
                FileName = $"https://viewblock.io/zilliqa/address/{_account.AccountData.GetAddressBech32()}",
                UseShellExecute = true
            });
        }

        private void timerButtonPressed_Tick(object sender, EventArgs e)
        {
            timerButtonPressed.Enabled = false;
            buttonClipboardAddress.BackColor = SystemColors.Control;
            buttonOpenBlockExplorer.BackColor = SystemColors.Control;
        }

        private void tabButtonZilTransactions_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonZilTransactions, gridViewZilTransactions);
        }

        private void tabButtonTokenTransactions_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonTokenTransactions, gridViewTokenTransactions);
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripTransactions.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabPages.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

    }
}

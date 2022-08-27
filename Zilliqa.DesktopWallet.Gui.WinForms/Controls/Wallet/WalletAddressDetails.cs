using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class WalletAddressDetails : UserControl
    {
        private AccountViewModel? _account;

        public WalletAddressDetails()
        {
            InitializeComponent();
            gridViewTokenBalances.Dock = DockStyle.Fill;
            gridViewZilTransactions.Dock = DockStyle.Fill;
            gridViewTokenTransactions.Dock = DockStyle.Fill;
        }

        public void LoadAccount(AccountViewModel account)
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
            textZilAddress.Text = account.AddressBech32;
            gridViewTokenBalances.LoadData(account.TokenBalances, typeof(TokenBalanceRowViewModel));
            gridViewZilTransactions.LoadData(account.ZilTransactions, typeof(ZilTransactionRowViewModel));
            gridViewTokenTransactions.LoadData(account.TokenTransactions, typeof(TokenTransactionRowViewModel));
            RefreshAccountSummaries();
        }

        public void RefreshAccountSummaries()
        {
            if (_account == null) return;

            SetTabButtonCountText(tabButtonZrc2Tokens, _account.TokenBalances.Count);
            SetTabButtonCountText(tabButtonZilTransactions, _account.ZilTransactions.Count);
            SetTabButtonCountText(tabButtonTokenTransactions, _account.TokenTransactions.Count);

            labelZilTotalBalance.Text = $"{_account.ZilTotalBalance:#,##0.00} ZIL";
            labelZilLiquidBalance.Text = $"{_account.ZilLiquidBalance:#,##0.00} ZIL";

            labelTokensValueUsd.Text = $"{_account.TokensValueUsd:#,##0.00} USD";
            labelZilValueUsd.Text = $"{_account.ZilTotalValueUsd:#,##0.00} USD";
            labelTotalValueUsd.Text = $"{_account.TotalValueUsd:#,##0.00} USD";
        }

        private void SetTabButtonCountText(ToolStripButton button, long count)
        {
            if (!(button.Tag is string buttonText))
            {
                button.Tag = button.Text;
                buttonText = button.Text;
            }
            button.Text = $"{buttonText} ({count})";
        }

        private void WalletAddressDetails_Load(object sender, EventArgs e)
        {
            TabButtonTransactionClick(tabButtonZilTransactions, gridViewZilTransactions);
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

        private void tabButtonZrc2Tokens_Click(object sender, EventArgs e)
        {
            TabButtonHoldingClick(tabButtonZrc2Tokens, gridViewTokenBalances);
        }

        private void TabButtonHoldingClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripHoldings.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabPagesHoldings.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void tabButtonZilTransactions_Click(object sender, EventArgs e)
        {
            TabButtonTransactionClick(tabButtonZilTransactions, gridViewZilTransactions);
        }

        private void tabButtonTokenTransactions_Click(object sender, EventArgs e)
        {
            TabButtonTransactionClick(tabButtonTokenTransactions, gridViewTokenTransactions);
        }

        private void TabButtonTransactionClick(ToolStripButton button, Control tabPageControl)
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

            foreach (Control pageControl in panelTabPagesTransactions.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
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

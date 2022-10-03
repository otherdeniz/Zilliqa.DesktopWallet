using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class AddressDetailsControl : DetailsBaseControl
    {
        private AccountViewModel? _account;
        private bool _viewModelOwned;
        private bool _showCurrencyColumns = false;

        public AddressDetailsControl()
        {
            InitializeComponent();
            gridViewTokenBalances.Dock = DockStyle.Fill;
            gridViewAllTransactions.Dock = DockStyle.Fill;
            gridViewZilTransactions.Dock = DockStyle.Fill;
            gridViewTokenTransactions.Dock = DockStyle.Fill;
        }

        public event EventHandler<EventArgs>? AfterRefreshAccountDetails;

        [DefaultValue(false)]
        public bool ShowCurrencyColumns
        {
            get => _showCurrencyColumns;
            set
            {
                _showCurrencyColumns = value;
                gridViewTokenBalances.DisplayDynamicColumns = value;
                gridViewAllTransactions.DisplayDynamicColumns = value;
                gridViewZilTransactions.DisplayDynamicColumns = value;
                gridViewTokenTransactions.DisplayDynamicColumns = value;
            }
        }

        public void BindAccountViewModel(AccountViewModel account, bool viewModelOwned)
        {
            _account = account;
            _viewModelOwned = viewModelOwned;
            bech32Address.Bech32Address = account.AddressBech32;
            bech32Address.ShowAddToWatchedAccounts = !(account.AccountData is MyAccount);
            gridViewTokenBalances.LoadData(account.TokenBalances, typeof(TokenBalanceRowViewModel));
            gridViewAllTransactions.LoadData(account.AllTransactions);
            gridViewZilTransactions.LoadData(account.ZilTransactions);
            gridViewTokenTransactions.LoadData(account.TokenTransactions);
            RefreshAccountSummaries();
        }

        public void RefreshAccountSummaries()
        {
            if (_account == null) return;

            SetTabButtonCountText(tabButtonZrc2Tokens, _account.TokenBalances.Count);

            _account.AllTransactions.ExecuteAfterLoadCompleted(l => SetTabButtonCountText(tabButtonAllTransactions, l.RecordCount), true);

            _account.ZilTransactions.ExecuteAfterLoadCompleted(l => SetTabButtonCountText(tabButtonZilTransactions, l.RecordCount), true);

            _account.TokenTransactions.ExecuteAfterLoadCompleted(l => SetTabButtonCountText(tabButtonTokenTransactions, l.RecordCount), true);

            labelCreatedDate.Text = _account.CreatedDate.ToString("g");

            labelZilTotalBalance.Text = $"{_account.ZilTotalBalance:#,##0.00} ZIL";
            labelZilLiquidBalance.Text = $"{_account.ZilLiquidBalance:#,##0.00} ZIL";

            labelTokensValueUsd.Text = $"{_account.TokensValueUsd:#,##0.00} USD";
            labelZilValueUsd.Text = $"{_account.ZilTotalValueUsd:#,##0.00} USD";
            labelTotalValueUsd.Text = $"{_account.TotalValueUsd:#,##0.00} USD";

            AfterRefreshAccountDetails?.Invoke(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (_viewModelOwned)
            {
                _account?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetTabButtonCountText(ToolStripButton button, long count)
        {
            if (!(button.Tag is string buttonText))
            {
                button.Tag = button.Text;
                buttonText = button.Text;
            }
            button.Text = $"{buttonText} ({count:#,##0})";
        }

        private void WalletAddressDetails_Load(object sender, EventArgs e)
        {
            TabButtonHoldingClick(tabButtonZrc2Tokens, gridViewTokenBalances);
            TabButtonTransactionClick(tabButtonZilTransactions, gridViewZilTransactions);
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

        private void tabButtonAllTransactions_Click(object sender, EventArgs e)
        {
            TabButtonTransactionClick(tabButtonAllTransactions, gridViewAllTransactions);
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

    }
}

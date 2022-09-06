using System.ComponentModel;
using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class AddressDetailsControl : DrillDownBaseControl
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
            gridViewTokenBalances.LoadData(account.TokenBalances, typeof(TokenBalanceRowViewModel));
            gridViewAllTransactions.LoadData(account.AllTransactions, typeof(CommonTransactionRowViewModel));
            gridViewZilTransactions.LoadData(account.ZilTransactions, typeof(ZilTransactionRowViewModel));
            gridViewTokenTransactions.LoadData(account.TokenTransactions, typeof(TokenTransactionRowViewModel));
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
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (_viewModelOwned)
            {
                _account?.CancelBackgroundTasks();
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

        //private void buttonClipboardAddress_Click(object sender, EventArgs e)
        //{
        //    if (_account == null) return;
        //    buttonClipboardAddress.BackColor = Color.Green;
        //    buttonClipboardAddress.Refresh();
        //    timerButtonPressed.Enabled = true;
        //    Clipboard.SetText(_account.AccountData.GetAddressBech32());
        //}

        //private void buttonOpenBlockExplorer_Click(object sender, EventArgs e)
        //{
        //    if (_account == null) return;
        //    buttonOpenBlockExplorer.BackColor = Color.Green;
        //    buttonOpenBlockExplorer.Refresh();
        //    timerButtonPressed.Enabled = true;
        //    Process.Start(new ProcessStartInfo
        //    {
        //        FileName = $"https://viewblock.io/zilliqa/address/{_account.AccountData.GetAddressBech32()}",
        //        UseShellExecute = true
        //    });
        //}

        private void timerButtonPressed_Tick(object sender, EventArgs e)
        {
            //timerButtonPressed.Enabled = false;
            //buttonClipboardAddress.BackColor = SystemColors.Control;
            //buttonOpenBlockExplorer.BackColor = SystemColors.Control;
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

        private void gridView_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null
                && sender is GridViewControl gridView)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridView)
                    {
                        gridView.ClearSelection();
                    }
                }, gridView);
            }
        }

        private void gridView_IsItemSelectable(object sender, GridView.GridViewControl.IsItemSelectableEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                e.IsSelectable = CanDrillDownToObject(e.SelectedItem.Value);
            }
        }
    }
}

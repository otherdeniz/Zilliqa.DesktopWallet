﻿using System.Diagnostics;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class AddressDetailsControl : DrillDownBaseControl
    {
        private AccountViewModel? _account;
        private bool _viewModelOwned;

        public AddressDetailsControl()
        {
            InitializeComponent();
            gridViewTokenBalances.Dock = DockStyle.Fill;
            gridViewAllTransactions.Dock = DockStyle.Fill;
            gridViewZilTransactions.Dock = DockStyle.Fill;
            gridViewTokenTransactions.Dock = DockStyle.Fill;
        }

        public void BindAccountViewModel(AccountViewModel account, bool viewModelOwned)
        {
            _account = account;
            _viewModelOwned = viewModelOwned;
            textZilAddress.Text = account.AddressBech32;
            if (account.IsBindingListsLoadCompleted)
            {
                gridViewTokenBalances.LoadData(account.TokenBalances, typeof(TokenBalanceRowViewModel));
                gridViewAllTransactions.LoadData(account.AllTransactions, typeof(CommonTransactionRowViewModel));
                gridViewZilTransactions.LoadData(account.ZilTransactions, typeof(ZilTransactionRowViewModel));
                gridViewTokenTransactions.LoadData(account.TokenTransactions, typeof(TokenTransactionRowViewModel));
                RefreshAccountSummaries();
            }
            else
            {
                account.BindingListsLoadCompleted += Account_BindingListsLoadCompleted;
            }
        }

        private void Account_BindingListsLoadCompleted(object? sender, EventArgs e)
        {
            if (_account == null) return;

            gridViewTokenBalances.LoadData(_account.TokenBalances, typeof(TokenBalanceRowViewModel));
            gridViewAllTransactions.LoadData(_account.AllTransactions, typeof(CommonTransactionRowViewModel));
            gridViewZilTransactions.LoadData(_account.ZilTransactions, typeof(ZilTransactionRowViewModel));
            gridViewTokenTransactions.LoadData(_account.TokenTransactions, typeof(TokenTransactionRowViewModel));
            RefreshAccountSummaries();
        }

        public void RefreshAccountSummaries()
        {
            if (_account == null) return;

            SetTabButtonCountText(tabButtonZrc2Tokens, _account.TokenBalances.Count);
            SetTabButtonCountText(tabButtonAllTransactions, _account.AllTransactions.Count);
            SetTabButtonCountText(tabButtonZilTransactions, _account.ZilTransactions.Count);
            SetTabButtonCountText(tabButtonTokenTransactions, _account.TokenTransactions.Count);

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
            button.Text = $"{buttonText} ({count})";
        }

        private void WalletAddressDetails_Load(object sender, EventArgs e)
        {
            TabButtonHoldingClick(tabButtonZrc2Tokens, gridViewTokenBalances);
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

        private void gridViewAllTransactions_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridViewAllTransactions)
                    {
                        gridViewAllTransactions.ClearSelection();
                    }
                }, gridViewAllTransactions);
            }
        }

        private void gridViewZilTransactions_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridViewZilTransactions)
                    {
                        gridViewZilTransactions.ClearSelection();
                    }
                }, gridViewZilTransactions);
            }
        }

        private void gridViewTokenTransactions_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridViewTokenTransactions)
                    {
                        gridViewTokenTransactions.ClearSelection();
                    }
                }, gridViewTokenTransactions);
            }
        }

        private void gridViewTokenBalances_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridViewTokenBalances)
                    {
                        gridViewTokenBalances.ClearSelection();
                    }
                }, gridViewTokenBalances);
            }
        }
    }
}

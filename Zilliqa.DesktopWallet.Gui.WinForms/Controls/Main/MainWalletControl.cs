using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainWalletControl : UserControl
    {
        private SynchronizationContext? _currentContext;
        private WalletViewModel _viewModel;

        public MainWalletControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (_viewModel != null)
            {
                return;
            }
            panelMyAccounts.Controls.Clear();
            panelWatchedAccounts.Controls.Clear();
            _currentContext = SynchronizationContext.Current;
            _viewModel = new WalletViewModel(WalletDat.Instance.MyAccounts);
            _viewModel.AfterRefresh += ViewModelOnAfterRefresh;
            LoadWalletList();
        }
        private void ViewModelOnAfterRefresh(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
            }, null);
        }

        private void LoadWalletList()
        {
            panelMyAccounts.Controls.OfType<WalletListItemControl>().ToList().ForEach(c =>
            {
                if (!_viewModel.MyAccounts.Any(a => a.AccountData.Id == ((AccountViewModel)c.Tag).AccountData.Id))
                {
                    panelMyAccounts.Controls.Remove(c);
                }
            });
            _viewModel.MyAccounts.ForEach(a =>
            {
                if (!panelMyAccounts.Controls.OfType<WalletListItemControl>().Any(c => ((AccountViewModel)c.Tag).AccountData.Id == a.AccountData.Id))
                {
                    var control = new WalletListItemControl
                    {
                        Dock = DockStyle.Top
                    };
                    control.ButtonClicked += (sender, args) => ShowWalletAccount(control);
                    control.AssignAccount(a);
                    panelMyAccounts.Controls.Add(control);
                }
            });
            //panelWalletList.Controls.ForEach(c => );
        }

        private void ShowWalletAccount(WalletListItemControl walletListItemControl)
        {
            if (walletListItemControl.IsSelected)
            {
                return;
            }

            panelMyAccounts.Controls.OfType<WalletListItemControl>().ForEach(c => c.IsSelected = false);
            walletListItemControl.IsSelected = true;

            groupAccountDetails.Visible = true;
            groupAccountDetails.Text = walletListItemControl.Account.AccountData.Name;

            if (panelAccountDetails.Controls.Count > 0)
            {
                var oldControl = panelAccountDetails.Controls[0];
                panelAccountDetails.Controls.Clear();
                oldControl.Dispose();
            }

            var addControl = new WalletAddressDetails
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            addControl.LoadAccount(walletListItemControl.Account);

            panelAccountDetails.Controls.Add(addControl);
        }
    }
}

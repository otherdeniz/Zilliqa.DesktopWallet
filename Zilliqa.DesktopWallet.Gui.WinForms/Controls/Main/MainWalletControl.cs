using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainWalletControl : UserControl
    {
        private SynchronizationContext? _currentContext;
        private WalletRepository? _repository;

        public MainWalletControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (_repository != null)
            {
                return;
            }
            panelMyAccounts.Controls.Clear();
            panelWatchedAccounts.Controls.Clear();
            _currentContext = SynchronizationContext.Current;
            _repository = RepositoryManager.Instance.WalletRepository;
            _repository.AccountsListChanged += RepositoryOnAccountsListChanged;
            _repository.AccountChanged += RepositoryOnAccountChanged;
            LoadWalletList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (_repository != null)
            {
                _repository.AccountsListChanged -= RepositoryOnAccountsListChanged;
                _repository.AccountChanged -= RepositoryOnAccountChanged;
                _repository = null;
            }
            base.Dispose(disposing);
        }

        private void RepositoryOnAccountsListChanged(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                LoadWalletList();
            }, null);
        }

        private void RepositoryOnAccountChanged(object? sender, WalletRepository.AccountChangedEventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                RefreshAccountDetails(e.AccountViewModel);
            }, null);
        }

        private void LoadWalletList()
        {
            panelMyAccounts.Controls.OfType<WalletListItemControl>().ToList().ForEach(c =>
            {
                if (_repository?.MyAccounts.Any(a => a.AccountData.Id == ((AccountViewModel)c.Tag).AccountData.Id) == false)
                {
                    // remove MyAccount
                    panelMyAccounts.Controls.Remove(c);
                    c.Dispose();
                }
            });
            _repository?.MyAccounts.ForEach(a =>
            {
                if (GetMyAccountControl(a.AccountData.Id) == null)
                {
                    // add MyAccount
                    var control = new WalletListItemControl
                    {
                        Dock = DockStyle.Top
                    };
                    control.ButtonClicked += (sender, args) => ShowWalletAccount(control);
                    control.AssignAccount(a);
                    panelMyAccounts.Controls.Add(control);
                }
            });
            panelWatchedAccounts.Controls.OfType<WalletListItemControl>().ToList().ForEach(c =>
            {
                if (_repository?.WatchedAccounts.Any(a => a.AccountData.Id == ((AccountViewModel)c.Tag).AccountData.Id) == false)
                {
                    // remove WatchedAccount
                    panelWatchedAccounts.Controls.Remove(c);
                    c.Dispose();
                }
            });
            _repository?.WatchedAccounts.ForEach(a =>
            {
                if (GetWatchedAccountControl(a.AccountData.Id) == null)
                {
                    // add WatchedAccount
                    var control = new WalletListItemControl
                    {
                        Dock = DockStyle.Top
                    };
                    control.ButtonClicked += (sender, args) => ShowWalletAccount(control);
                    control.AssignAccount(a);
                    panelWatchedAccounts.Controls.Add(control);
                }
            });
        }

        private void RefreshAccountDetails(AccountViewModel accountViewModel)
        {
            var accountControl = GetAccountControl(accountViewModel.AccountData.Id);
            if (accountControl != null)
            {
                accountControl.RefreshAccount();
                if (accountControl.IsSelected)
                {
                    var walletAddressControl = (WalletAddressControl)panelAccountDetails.Controls[0];
                    walletAddressControl.AddressDetailsControl.RefreshAccountSummaries();
                }
            }

        }

        private WalletListItemControl? GetAccountControl(string id)
        {
            return GetMyAccountControl(id) ?? GetWatchedAccountControl(id);
        }

        private WalletListItemControl? GetMyAccountControl(string id)
        {
            return panelMyAccounts.Controls.OfType<WalletListItemControl>()
                .FirstOrDefault(c => ((AccountViewModel)c.Tag).AccountData.Id == id);
        }

        private WalletListItemControl? GetWatchedAccountControl(string id)
        {
            return panelWatchedAccounts.Controls.OfType<WalletListItemControl>()
                .FirstOrDefault(c => ((AccountViewModel)c.Tag).AccountData.Id == id);
        }

        private void ShowWalletAccount(WalletListItemControl walletListItemControl)
        {
            if (walletListItemControl.IsSelected)
            {
                return;
            }

            panelMyAccounts.Controls.OfType<WalletListItemControl>().ForEach(c => c.IsSelected = false);
            panelWatchedAccounts.Controls.OfType<WalletListItemControl>().ForEach(c => c.IsSelected = false);
            walletListItemControl.IsSelected = true;
            walletListItemControl.Refresh();

            groupAccountDetails.Visible = true;
            groupAccountDetails.Text = walletListItemControl.Account.AccountData.Name;

            if (panelAccountDetails.Controls.Count > 0)
            {
                var oldControl = panelAccountDetails.Controls[0];
                panelAccountDetails.Controls.Clear();
                oldControl.Dispose();
            }

            var addControl = new WalletAddressControl
            {
                Dock = DockStyle.Fill
            };
            addControl.BindAccountViewModel(walletListItemControl.Account);

            panelAccountDetails.Controls.Add(addControl);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var result = CreateMyAccountForm.Execute(this.ParentForm!);
            if (result?.AddWalletType == AddAccountControl.AddWalletType.AddNew)
            {
                _repository?.AddAccount(MyAccount.Create(result.AccountName, result.Password.Password));
            }
            else if (result?.AddWalletType == AddAccountControl.AddWalletType.ImportPrivateKey)
            {
                _repository?.AddAccount(MyAccount.Import(result.AccountName, result.PrivateKey!, result.Password.Password));
            }
            else if (result?.AddWalletType == AddAccountControl.AddWalletType.ConnectLedger)
            {
                _repository?.AddAccount(MyAccount.CreateLedger(result.AccountName, result.LedgerAddressBech32!, result.LedgerPublicKey!, result.LedgerKeyIndex));
            }
        }

        private void buttonAddWatched_Click(object sender, EventArgs e)
        {
            var result = AddWatchedAccountForm.Execute(this.ParentForm!);
            if (result != null)
            {
                _repository?.AddAccount(WatchedAccount.Create(result.AccountName, result.Address, result.IsMyAccount));
            }
        }
    }
}

using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

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
            _repository.AfterRefresh += RepositoryOnAfterRefresh;
            LoadWalletList();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (_repository != null)
            {
                _repository.AfterRefresh -= RepositoryOnAfterRefresh;
                _repository = null;
            }
            base.Dispose(disposing);
        }

        private void RepositoryOnAfterRefresh(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                LoadWalletList();
            }, null);
        }

        private void LoadWalletList()
        {
            panelMyAccounts.Controls.OfType<WalletListItemControl>().ToList().ForEach(c =>
            {
                if (_repository?.MyAccounts.Any(a => a.AccountData.Id == ((AccountViewModel)c.Tag).AccountData.Id) == false)
                {
                    panelMyAccounts.Controls.Remove(c);
                }
            });
            _repository?.MyAccounts.ForEach(a =>
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
                Dock = DockStyle.Fill
            };
            addControl.LoadAccount(walletListItemControl.Account);

            panelAccountDetails.Controls.Add(addControl);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var result = CreateMyAccountForm.Execute(this.ParentForm);
            if (result != null)
            {
                _repository?.AddAccount(MyAccount.Create(result.AccountName, result.Password.Password));
            }
        }

        private void toolImport_Click(object sender, EventArgs e)
        {
            var result = ImportMyAccountForm.Execute(this.ParentForm);
            if (result != null)
            {
                _repository?.AddAccount(MyAccount.Import(result.AccountName, result.PrivateKey, result.Password.Password));
            }
        }

        private void buttonAddWatched_Click(object sender, EventArgs e)
        {
            var result = AddWatchedAccountForm.Execute(this.ParentForm);
            if (result != null)
            {
                _repository?.AddAccount(WatchedAccount.Add(result.AccountName, result.Address, result.IsMyAccount));
            }
        }
    }
}

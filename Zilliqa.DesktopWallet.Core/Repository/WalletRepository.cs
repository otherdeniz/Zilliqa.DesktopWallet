using System.Collections.ObjectModel;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class WalletRepository : ZilliqaApiClientRepositoryBase
    {
        private readonly List<AccountViewModel> _myAccountsList = new List<AccountViewModel>();
        private readonly List<AccountViewModel> _watchedAccountsList = new List<AccountViewModel>();

        public WalletRepository()
        {
            WalletDat.Instance.MyAccounts.ForEach(a => _myAccountsList.Add(new AccountViewModel
            {
                AccountData = a
            }));
            MyAccounts = new ReadOnlyCollection<AccountViewModel>(_myAccountsList);
            WalletDat.Instance.WatchedAccounts.ForEach(a => _watchedAccountsList.Add(new AccountViewModel
            {
                AccountData = a
            }));
            WatchedAccounts = new ReadOnlyCollection<AccountViewModel>(_watchedAccountsList);
        }

        public event EventHandler<EventArgs> AfterRefresh;

        public event EventHandler<EventArgs> AccountsListChanged;

        public ReadOnlyCollection<AccountViewModel> MyAccounts { get; }

        public ReadOnlyCollection<AccountViewModel> WatchedAccounts { get; }

        public void AddAccount(AccountBase account)
        {
            if (account is MyAccount myAccount)
            {
                WalletDat.Instance.MyAccounts.Add(myAccount);
                _myAccountsList.Add(new AccountViewModel
                {
                    AccountData = account
                });
            }
            else if (account is WatchedAccount watchedAccount)
            {
                WalletDat.Instance.WatchedAccounts.Add(watchedAccount);
                _watchedAccountsList.Add(new AccountViewModel
                {
                    AccountData = account
                });
            }
            else
            {
                throw new NotSupportedException("Account type not supported");
            }
            WalletDat.Instance.Save();
            AccountsListChanged.Invoke(this, EventArgs.Empty);
        }

        public void RemoveAccount(string id)
        {
            for (int i = 0; i < _myAccountsList.Count; i++)
            {
                if (_myAccountsList[i].AccountData.Id == id)
                {
                    _myAccountsList.RemoveAt(i);
                    WalletDat.Instance.MyAccounts.RemoveAt(i);
                    WalletDat.Instance.Save();
                    AccountsListChanged.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
            for (int i = 0; i < _watchedAccountsList.Count; i++)
            {
                if (_watchedAccountsList[i].AccountData.Id == id)
                {
                    _watchedAccountsList.RemoveAt(i);
                    WalletDat.Instance.WatchedAccounts.RemoveAt(i);
                    WalletDat.Instance.Save();
                    AccountsListChanged.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        protected override async Task RefreshFunction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                AfterRefresh?.Invoke(this, EventArgs.Empty);

                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}

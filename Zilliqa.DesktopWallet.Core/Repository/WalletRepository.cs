using System.Collections.ObjectModel;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class WalletRepository : IDisposable
    {
        private readonly List<AccountViewModel> _myAccountsList = new List<AccountViewModel>();
        private readonly List<AccountViewModel> _watchedAccountsList = new List<AccountViewModel>();

        public WalletRepository()
        {
            WalletDat.Instance.MyAccounts.ForEach(a =>
            {
                KnownAddressService.Instance.AddUnique(a.GetAddressBech32(), "Account", a.Name);
                _myAccountsList.Add(new AccountViewModel(a, OnAccountChanged, true));
            });
            MyAccounts = new ReadOnlyCollection<AccountViewModel>(_myAccountsList);
            WalletDat.Instance.WatchedAccounts.ForEach(a =>
            {
                KnownAddressService.Instance.AddUnique(a.GetAddressBech32(), "Account", a.Name);
                _watchedAccountsList.Add(new AccountViewModel(a, OnAccountChanged, true));
            });
            WatchedAccounts = new ReadOnlyCollection<AccountViewModel>(_watchedAccountsList);
        }

        public event EventHandler<EventArgs>? AccountsListChanged;

        public event EventHandler<AccountChangedEventArgs>? AccountChanged;

        public ReadOnlyCollection<AccountViewModel> MyAccounts { get; }

        public ReadOnlyCollection<AccountViewModel> WatchedAccounts { get; }

        public void AddAccount(AccountBase account)
        {
            if (account is MyAccount myAccount)
            {
                WalletDat.Instance.MyAccounts.Add(myAccount);
                _myAccountsList.Add(new AccountViewModel(account, OnAccountChanged, true));
            }
            else if (account is WatchedAccount watchedAccount)
            {
                WalletDat.Instance.WatchedAccounts.Add(watchedAccount);
                _watchedAccountsList.Add(new AccountViewModel(account, OnAccountChanged, true));
            }
            else
            {
                throw new NotSupportedException("Account type not supported");
            }
            KnownAddressService.Instance.AddUnique(account.GetAddressBech32(), "Account", account.Name);
            WalletDat.Instance.Save();
            AccountsListChanged?.Invoke(this, EventArgs.Empty);
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
                    AccountsListChanged?.Invoke(this, EventArgs.Empty);
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
                    AccountsListChanged?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        public void Dispose()
        {
            _myAccountsList.ForEach(a => a.Dispose());
            _myAccountsList.Clear();
            _watchedAccountsList.ForEach(a => a.Dispose());
            _watchedAccountsList.Clear();
        }

        private void OnAccountChanged(AccountViewModel accountViewModel)
        {
            AccountChanged?.Invoke(this, new AccountChangedEventArgs(accountViewModel));
        }

        public class AccountChangedEventArgs : EventArgs
        {
            public AccountChangedEventArgs(AccountViewModel accountViewModel)
            {
                AccountViewModel = accountViewModel;
            }

            public AccountViewModel AccountViewModel { get; }
        }

    }
}

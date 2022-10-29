using System.Collections.ObjectModel;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class WalletRepository : IDisposable
    {
        private readonly List<AccountViewModel> _myAccountsList = new();
        private readonly List<AccountViewModel> _watchedAccountsList = new();
        private readonly Dictionary<string, AccountViewModel> _accountsByAddress = new();

        public WalletRepository()
        {
            WalletDat.Instance.MyAccounts.ForEach(a =>
            {
                KnownAddressService.Instance.AddUnique(a.GetAddressBech32(), "Account", a.Name);
                var accountViewModel = new AccountViewModel(a, OnAccountChanged, true);
                AddAccountToDictionary(accountViewModel);
                _myAccountsList.Add(accountViewModel);
            });
            MyAccounts = new ReadOnlyCollection<AccountViewModel>(_myAccountsList);
            WalletDat.Instance.WatchedAccounts.ForEach(a =>
            {
                KnownAddressService.Instance.AddUnique(a.GetAddressBech32(), "Account", a.Name);
                var accountViewModel = new AccountViewModel(a, OnAccountChanged, true);
                AddAccountToDictionary(accountViewModel);
                _watchedAccountsList.Add(accountViewModel);
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
                var accountViewModel = new AccountViewModel(account, OnAccountChanged, true);
                AddAccountToDictionary(accountViewModel);
                _myAccountsList.Add(accountViewModel);
            }
            else if (account is WatchedAccount watchedAccount)
            {
                WalletDat.Instance.WatchedAccounts.Add(watchedAccount);
                var accountViewModel = new AccountViewModel(account, OnAccountChanged, true);
                AddAccountToDictionary(accountViewModel);
                _watchedAccountsList.Add(accountViewModel);
            }
            else
            {
                throw new NotSupportedException("Account type not supported");
            }

            KnownAddressService.Instance.AddUnique(account.GetAddressBech32(), "Account", account.Name);
            WalletDat.Instance.Save();
            AccountsListChanged?.Invoke(this, EventArgs.Empty);
        }

        private void AddAccountToDictionary(AccountViewModel accountViewModel)
        {
            if (!_accountsByAddress.ContainsKey(accountViewModel.AddressHex))
            {
                _accountsByAddress.Add(accountViewModel.AddressHex, accountViewModel);
            }
        }

        public void RemoveAccount(string id)
        {
            for (int i = 0; i < _myAccountsList.Count; i++)
            {
                if (_myAccountsList[i].AccountData.Id == id)
                {
                    RemoveAccountFromDictionary(_myAccountsList[i]);
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
                    RemoveAccountFromDictionary(_watchedAccountsList[i]);
                    _watchedAccountsList.RemoveAt(i);
                    WalletDat.Instance.WatchedAccounts.RemoveAt(i);
                    WalletDat.Instance.Save();
                    AccountsListChanged?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        private void RemoveAccountFromDictionary(AccountViewModel accountViewModel)
        {
            if (_accountsByAddress.ContainsKey(accountViewModel.AddressHex))
            {
                _accountsByAddress.Remove(accountViewModel.AddressHex);
            }
        }

        public AccountViewModel? FindAccount(string? addressHex)
        {
            if (addressHex == null) return null;
            return _accountsByAddress.TryGetValue(addressHex, out var accountViewModel) 
                ? accountViewModel 
                : null;
        }

        public void Dispose()
        {
            _accountsByAddress.Clear();
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

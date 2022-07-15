using System.Collections.ObjectModel;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class WalletViewModel : ApiClientViewModelBase
    {
        private readonly List<AccountViewModel> _myAccountsList = new List<AccountViewModel>();
        private readonly List<AccountViewModel> _watchedAccountsList = new List<AccountViewModel>();

        public WalletViewModel(List<MyAccount> myAccounts)
        {
            myAccounts.ForEach(a => _myAccountsList.Add(new AccountViewModel
            {
                AccountData = a
            }));
            MyAccounts = new ReadOnlyCollection<AccountViewModel>(_myAccountsList);
            WatchedAccounts = new ReadOnlyCollection<AccountViewModel>(_watchedAccountsList);
        }

        public event EventHandler<EventArgs> AfterRefresh;

        public event EventHandler<EventArgs> AccountsListChanged;

        public ReadOnlyCollection<AccountViewModel> MyAccounts { get; }

        public ReadOnlyCollection<AccountViewModel> WatchedAccounts { get; }

        public void AddAccount(AccountBase account)
        {
            if (account is MyAccount)
            {
                _myAccountsList.Add(new AccountViewModel
                {
                    AccountData = account
                });

            }
            else if (account is WatchedAccount)
            {
                _watchedAccountsList.Add(new AccountViewModel
                {
                    AccountData = account
                });
            }
            else
            {
                throw new NotSupportedException("Account type not supported");
            }
            AccountsListChanged.Invoke(this, EventArgs.Empty);
        }

        public void RemoveAccount(string id)
        {
            for (int i = 0; i < _myAccountsList.Count; i++)
            {
                if (_myAccountsList[i].AccountData.Id == id)
                {
                    _myAccountsList.RemoveAt(i);
                    AccountsListChanged.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
            for (int i = 0; i < _watchedAccountsList.Count; i++)
            {
                if (_watchedAccountsList[i].AccountData.Id == id)
                {
                    _watchedAccountsList.RemoveAt(i);
                    AccountsListChanged.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }

        protected override async Task RefreshFunction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                AfterRefresh.Invoke(this, EventArgs.Empty);

                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}

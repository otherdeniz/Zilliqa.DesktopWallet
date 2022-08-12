using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel
    {
        public static AccountViewModel CreateInstance(AccountBase accountData, Action<AccountViewModel> afterChangedAction)
        {
            return new AccountViewModel(afterChangedAction)
            {
                AccountData = accountData
            };
        }

        private AccountViewModel(Action<AccountViewModel> afterChangedAction)
        {
            _afterChangedAction = afterChangedAction;
        }

        private readonly Action<AccountViewModel> _afterChangedAction;

        public AccountBase AccountData { get; private init; }

        //TODO add these properties to cache data
        //public List<object> SmartContracts { get; set; }
        //public List<object> Stakes { get; set; }
        //public List<object> Transactions { get; set; }

        public void RaiseAfterChanged()
        {
            _afterChangedAction(this);
        }
    }
}

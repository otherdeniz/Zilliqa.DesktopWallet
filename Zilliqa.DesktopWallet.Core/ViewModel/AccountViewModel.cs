using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel
    {
        private readonly Action<AccountViewModel> _afterChangedAction;

        public AccountViewModel(AccountBase accountData, Action<AccountViewModel> afterChangedAction) 
        {
            AccountData = accountData;
            _afterChangedAction = afterChangedAction;
        }

        public AccountBase AccountData { get; }

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

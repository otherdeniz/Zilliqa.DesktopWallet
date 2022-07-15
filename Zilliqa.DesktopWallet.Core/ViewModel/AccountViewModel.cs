using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel
    {
        public AccountBase AccountData { get; set; }

        public List<object> SmartContracts { get; set; }

        public List<object> Stakes { get; set; }

        public List<object> Transactions { get; set; }
    }
}

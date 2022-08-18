using System.Collections.Generic;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class TransactionPage
    {
        public int CurrPage { get; set; }

        public int NumPages { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}

using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;

namespace Zilliqa.DesktopWallet.Core.CacheDatabase.Model
{
    public class CoinHistoryCache
    {
        [PropertyIndex]
        public DateTime Date { get; set; }

        public CoinHistory CoinHistory { get; set; }

    }
}

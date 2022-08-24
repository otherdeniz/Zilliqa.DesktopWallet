using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;

namespace Zilliqa.DesktopWallet.Core.CacheDatabase.Model
{
    public class CoinHistoryCache
    {
        [SchemaIndex]
        public DateTime Date { get; set; }

        public CoinHistory CoinHistory { get; set; }

    }
}

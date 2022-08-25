using System.Runtime.Caching;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Api.Coingecko;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.Core.CacheDatabase.Model;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class CurrencyPriceRepository
    {
        private static readonly MemoryCache MemoryCache = new MemoryCache("CurrencyPriceRepository");
        private readonly CoingeckoApiClient _apiClient;
        private readonly object _lockGetCoinSymbolIds = new();
        private readonly object _lockGetCoinHistory = new();

        public CurrencyPriceRepository()
        {
            _apiClient = new CoingeckoApiClient();
        }

        public CoinHistory? GetCoinHistory(DateTime date, string symbol, Action<CoinHistory> afterDataReceived)
        {
            if (date.Date == DateTime.Today)
            {
                date = DateTime.Today.AddDays(-1);
            }
            if (MemoryCache.TryGet<CoinHistory>($"GetCoinHistory({date.ToShortDateString()},{symbol})", out var cacheValue))
            {
                return cacheValue;
            }
            Task.Run(() =>
            {
                var result = GetCoinHistory(date, symbol);
                if (result != null)
                {
                    afterDataReceived(result);
                }
            });

            return null;
        }

        public CoinHistory? GetCoinHistory(DateTime date, string symbol)
        {
            if (date.Date == DateTime.Today)
            {
                date = DateTime.Today.AddDays(-1);
            }
            return MemoryCache.GetOrAdd($"GetCoinHistory({date.ToShortDateString()},{symbol})",
                TimeSpan.FromMinutes(10),
                () =>
                {
                    var symbolLower = symbol.ToLower();
                    var dbTable = RepositoryManager.Instance.CacheDatabase.GetTable<CoinHistoryCache>();
                    var dbResult = dbTable.FindRecords(new FilterQueryField(nameof(CoinHistoryCache.Date), date),
                        c => c.CoinHistory.Symbol == symbolLower).FirstOrDefault();
                    if (dbResult == null)
                    {
                        var coinSymbolIds = GetCoinSymbolIds();
                        if (coinSymbolIds.TryGetValue(symbolLower, out var coinId))
                        {
                            try
                            {
                                var apiResult = _apiClient.GetCoinHistory(coinId, date);
                                if (apiResult == null)
                                {
                                    Logging.LogInfo($"GetCoinHistory of Symbol {symbolLower} @ {date.ToShortDateString()} - ApiClient returned NULL");
                                    apiResult = CoinHistory.CreateEmpty(symbolLower);
                                }

                                if (apiResult.MarketData != null)
                                {
                                    dbTable.AddRecord(new CoinHistoryCache
                                    {
                                        Date = date,
                                        CoinHistory = apiResult
                                    });
                                }
                                return apiResult;
                            }
                            catch (Exception e)
                            {
                                Logging.LogError($"GetCoinHistory of Symbol {symbolLower} failed", e);
                            }
                        }
                    }
                    else
                    {
                        return dbResult.CoinHistory;
                    }

                    return null;
                },
                _lockGetCoinHistory);
        }

        private Dictionary<string, string> GetCoinSymbolIds()
        {
            return MemoryCache.GetOrAdd("GetCoinSymbolIds", TimeSpan.FromDays(1), 
                () => _apiClient.GetCoinsListInfo()
                    .DistinctBy(c => c.Symbol.ToLower())
                    .ToDictionary(k => k.Symbol.ToLower(), v => v.Id),
                _lockGetCoinSymbolIds)
                ?? new Dictionary<string, string>();
        }
    }
}

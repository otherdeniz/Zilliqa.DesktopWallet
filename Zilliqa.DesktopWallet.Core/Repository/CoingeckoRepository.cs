using System.Runtime.Caching;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Api.Coingecko;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.Core.CacheDatabase.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class CoingeckoRepository
    {
        private static readonly MemoryCache MemoryCache = new MemoryCache("CoingeckoRepository");
        private const string CoinIdZilliqa = "zilliqa";
        private static readonly string[] CoinIdsWhiteList = new[]
        {
            "governance-zil"
        };

        private readonly CoingeckoApiClient _apiClient;
        private readonly CancellationTokenSource _backgroundCancellationTokenSource = new();
        private Task? _startupTask;
        private readonly object _startupLock = new();
        private readonly Dictionary<string, string> _symbolToCoinId = new();
        private readonly Queue<QueuedCoinHistoryRequest> _coinHistoryRequestQueue = new(1024);

        public CoingeckoRepository()
        {
            _apiClient = new CoingeckoApiClient();
        }

        public event EventHandler<EventArgs>? ZilCoinPriceChanged;

        public event EventHandler<CoinPriceChangedEventArgs>? CoinPriceChanged;

        public bool StartupCompleted { get; private set; }

        public CoinPrice? ZilCoinPrice { get; private set; }

        public Dictionary<string, CoinPrice> TokenPricesBySymbol { get; } = new();

        public void Startup(bool wait)
        {
            if ((!wait && _startupTask != null) || StartupCompleted) return;
            lock (_startupLock)
            {
                _startupTask ??= Task.Run(() =>
                {
                    try
                    {
                        var tokens = TokenDataService.Instance.GetTokens(false).AsList();
                        var coinSymbolIds = GetCoinSymbolIds();
#pragma warning disable CS4014 // task not awaited
                        BackgroundRefreshTask(tokens, coinSymbolIds, _backgroundCancellationTokenSource.Token);
                        BackgroundCoinHistoryDownloaderTask(_backgroundCancellationTokenSource.Token);
#pragma warning restore CS4014
                        UpdateZilPrice();
                    }
                    catch (Exception e)
                    {
                        Logging.LogError("CoingeckoRepository.Startup failed", e);
                    }

                    StartupCompleted = true;
                });
            }

            if (wait)
            {
                while (!StartupCompleted
                       && _startupTask?.Status == TaskStatus.Running)
                {
                    Task.Run(async () => await Task.Delay(500)).GetAwaiter().GetResult();
                }
            }
        }

        public void CancelBackgroundTasks()
        {
            _backgroundCancellationTokenSource.Cancel();
        }

        private void UpdateZilPrice()
        {
            ZilCoinPrice = _apiClient.GetCoinPrice(CoinIdZilliqa);
        }

        private async Task BackgroundRefreshTask(List<TokenModel> tokens, Dictionary<string, List<string>> coinSymbolIds, CancellationToken cancellationToken)
        {
            bool firstRun = true;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (firstRun)
                    {
                        foreach (var tokenSymbol in tokens
                                     .Where(t => t.Symbol != "ZIL")
                                     .Select(t => t.Symbol.ToLower()))
                        {
                            if (!TokenPricesBySymbol.ContainsKey(tokenSymbol) 
                                && coinSymbolIds.TryGetValue(tokenSymbol, out var tokenCoinIds))
                            {
                                foreach (var tokenCoinId in tokenCoinIds)
                                {
                                    if (cancellationToken.IsCancellationRequested) return;
                                    try
                                    {
                                        var tokenCoinPrice = _apiClient.GetCoinPrice(tokenCoinId);
                                        if (CoinIdsWhiteList.Any(w => tokenCoinPrice.Id == w)
                                            || !string.IsNullOrEmpty(tokenCoinPrice.Platforms.Zilliqa))
                                        {
                                            TokenPricesBySymbol.Add(tokenSymbol, tokenCoinPrice);
                                            _symbolToCoinId.Add(tokenSymbol, tokenCoinId);
                                            CoinPriceChanged?.Invoke(this, new CoinPriceChangedEventArgs(tokenSymbol));
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        // get coin price failed
                                    }
                                }

                                try
                                {
                                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                                }
                                catch (TaskCanceledException)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var tokenSymbol in TokenPricesBySymbol.Select(t => t.Key))
                        {
                            if (_symbolToCoinId.TryGetValue(tokenSymbol, out var coinId))
                            {
                                if (cancellationToken.IsCancellationRequested) return;
                                TokenPricesBySymbol[tokenSymbol] = _apiClient.GetCoinPrice(coinId);
                                CoinPriceChanged?.Invoke(this, new CoinPriceChangedEventArgs(tokenSymbol));
                            }

                            try
                            {
                                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
                            }
                            catch (TaskCanceledException)
                            {
                                return;
                            }
                        }
                        if (cancellationToken.IsCancellationRequested) return;
                        UpdateZilPrice();
                        WinFormsSynchronisationContext.ExecuteSynchronized(() => 
                            ZilCoinPriceChanged?.Invoke(this, EventArgs.Empty));
                    }

                    firstRun = false;
                }
                catch (Exception e)
                {
                    Logging.LogError("CoingeckoRepository.BackgroundRefreshTask caused an error, will retry in next iteration", e);
                }
                try
                {
                    await Task.Delay(TimeSpan.FromHours(3), cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        public CoinPrice? GetCoinPrice(string symbol)
        {
            if (symbol == "ZIL")
            {
                return ZilCoinPrice;
            }
            if (TokenPricesBySymbol.TryGetValue(symbol, out var tokenCoinPrice))
            {
                return tokenCoinPrice;
            }
            return null;
        }

        public void GetCoinHistory(DateTime date, string symbol, Action<CoinHistory?> afterDataReceived)
        {
            if (date > DateTime.Now.AddHours(-36))
            {
                var coinPrice = GetCoinPrice(symbol);
                if (coinPrice != null)
                {
                    afterDataReceived(coinPrice.MapToModel<CoinPrice, CoinHistory>());
                }
                else
                {
                    afterDataReceived(null);
                }
                return;
            }
            if (MemoryCache.TryGet<CoinHistory>($"GetCoinHistory({date.ToShortDateString()},{symbol})", out var cacheValue))
            {
                afterDataReceived(cacheValue);
            }

            try
            {
                _coinHistoryRequestQueue.Enqueue(new QueuedCoinHistoryRequest(date.Date, symbol, afterDataReceived));
            }
            catch (Exception)
            {
                // to much in the queue, skip this request
            }
        }

        private async Task BackgroundCoinHistoryDownloaderTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_coinHistoryRequestQueue.TryDequeue(out var request) && request != null)
                {
                    var coinHistory = GetOrAddCoinHistory(request.Date, request.Symbol);
                    if (coinHistory != null)
                    {
                        request.AfterDataReceived(coinHistory);
                    }
                    else
                    {
                        request.AfterDataReceived(null);
                    }
                }
                else
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                    }
                    catch (TaskCanceledException)
                    {
                        return;
                    }
                }
            }
        }

        private CoinHistory? GetOrAddCoinHistory(DateTime date, string symbol)
        {
            return MemoryCache.GetOrAdd($"GetCoinHistory({date.ToShortDateString()},{symbol})",
                TimeSpan.FromMinutes(10),
                () =>
                {
                    var symbolLower = symbol.ToLower();
                    string? coinId = null;
                    if (symbol == "ZIL")
                    {
                        coinId = CoinIdZilliqa;
                    }
                    else if (_symbolToCoinId.TryGetValue(symbol, out var tokenCoinId))
                    {
                        coinId = tokenCoinId;
                    }

                    if (coinId != null)
                    {
                        var dbTable = RepositoryManager.Instance.CacheDatabase.GetTable<CoinHistoryCache>();
                        var dbResult = dbTable.FindRecords(new FilterQueryField(nameof(CoinHistoryCache.Date), date),
                            c => c.CoinHistory.Symbol == symbolLower).FirstOrDefault();
                        if (dbResult != null)
                        {
                            return dbResult.CoinHistory;
                        }

                        try
                        {
                            var apiResult = _apiClient.GetCoinHistory(coinId, date);
                            if (apiResult == null)
                            {
                                Logging.LogInfo(
                                    $"GetCoinHistory of Symbol {symbolLower} @ {date.ToShortDateString()} - ApiClient returned NULL");
                                apiResult = CoinHistory.CreateEmpty(symbolLower);
                            }
                            else if (!string.IsNullOrEmpty(apiResult.Name)
                                     && apiResult.MarketData != null)
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

                    return null;
                });
        }

        private Dictionary<string, List<string>> GetCoinSymbolIds()
        {
            return _apiClient.GetCoinsListInfo()
                .GroupBy(c => c.Symbol.ToLower())
                .ToDictionary(k => k.Key, v => v.Select(c => c.Id).ToList());
        }

        private class QueuedCoinHistoryRequest
        {
            public QueuedCoinHistoryRequest(DateTime date, string symbol, Action<CoinHistory?> afterDataReceived)
            {
                Date = date;
                Symbol = symbol;
                AfterDataReceived = afterDataReceived;
            }
            public DateTime Date { get; }
            public string Symbol { get; }
            public Action<CoinHistory?> AfterDataReceived { get; }
        }

        public class CoinPriceChangedEventArgs : EventArgs
        {
            public CoinPriceChangedEventArgs(string symbol)
            {
                Symbol = symbol;
            }
            public string Symbol { get; }
        }
    }
}

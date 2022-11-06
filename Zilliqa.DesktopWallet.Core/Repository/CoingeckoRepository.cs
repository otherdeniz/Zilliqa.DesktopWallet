using System.Drawing;
using System.Runtime.Caching;
using Svg;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Api.Coingecko;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.Core.CacheDatabase.Model;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class CoingeckoRepository
    {
        private const int MaxQueueSize = 1000;
        private static readonly MemoryCache MemoryCache = new MemoryCache("CoingeckoRepository");
        private const string CoinIdZilliqa = "zilliqa";
        private const int CoinNumberZilliqa = 2687;
        private static readonly string[] CoinIdsWhiteList = new[]
        {
            "governance-zil",
            "bitcoin",
            "wrapped-bitcoin",
            "ethereum",
            "tether"
        };

        private readonly CoingeckoApiClient _apiClient;
        private readonly CancellationTokenSource _backgroundCancellationTokenSource = new();
        private Task? _startupTask;
        private readonly object _startupLock = new();
        private readonly Queue<QueuedCoinHistoryRequest> _coinHistoryRequestQueue = new(MaxQueueSize);
        private readonly Queue<QueuedCoinPriceRequest> _coinPriceRequestQueue = new(MaxQueueSize);
        private Dictionary<string, List<string>>? _coinSymbolCoinIds;
        private readonly Dictionary<string, string?> _symbolToCoinId = new();

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
                        _coinSymbolCoinIds = GetCoinSymbolIds();
#pragma warning disable CS4014 // task not awaited
                        BackgroundRefreshTask(_backgroundCancellationTokenSource.Token);
                        BackgroundCoinInfoDownloaderTask(_backgroundCancellationTokenSource.Token);
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

        private async Task BackgroundRefreshTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromHours(3), cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
                try
                {
                    foreach (var symbolLowered in TokenPricesBySymbol.Select(t => t.Key))
                    {
                        if (_symbolToCoinId.TryGetValue(symbolLowered, out var coinId)
                            && coinId != null)
                        {
                            if (cancellationToken.IsCancellationRequested) return;
                            var coinPrice = _apiClient.GetCoinPrice(coinId);
                            TokenPricesBySymbol[symbolLowered] = coinPrice;
                            CoinPriceChanged?.Invoke(this, new CoinPriceChangedEventArgs(symbolLowered, coinPrice));
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
                catch (Exception e)
                {
                    Logging.LogError("CoingeckoRepository.BackgroundRefreshTask caused an error, will retry in next iteration", e);
                }
            }
        }

        public Image? GetZilSparklineImage()
        {
            try
            {
                var imageData = _apiClient.GetCoinSparkline(CoinNumberZilliqa.ToString());
                if (imageData != null)
                {
                    using (var imageStream = new MemoryStream(imageData))
                    {
                        var svgDocument = SvgDocument.Open<SvgDocument>(imageStream);
                        return svgDocument.Draw(135, 50);
                    }
                }
            }
            catch (Exception)
            {
                // skip
            }

            return null;
        }

        public void GetCoinPrice(string symbol, Action<CoinPrice> afterDataReceived, bool loadInBackground = true)
        {
            var symbolLowered = symbol.ToLower();
            if (symbolLowered == "zil" 
                && ZilCoinPrice != null)
            {
                afterDataReceived(ZilCoinPrice);
                return;
            }
            if (TokenPricesBySymbol.TryGetValue(symbolLowered, out var tokenCoinPrice))
            {
                afterDataReceived(tokenCoinPrice);
                return;
            }
            if (loadInBackground)
            {
                try
                {
                    if (_coinPriceRequestQueue.Count < MaxQueueSize)
                    {
                        _coinPriceRequestQueue.Enqueue(new QueuedCoinPriceRequest(symbolLowered, afterDataReceived));
                    }
                }
                catch (Exception)
                {
                    // to much in the queue, skip this request
                }
            }
            else
            {
                var coinPrice = GetOrAddTokenCoinPrice(symbolLowered);
                if (coinPrice != null)
                {
                    afterDataReceived(coinPrice);
                }
            }
        }

        public void GetCoinHistory(DateTime date, string symbol, Action<CoinHistory> afterDataReceived)
        {
            var symbolLowered = symbol.ToLower();
            if (date > DateTime.Now.AddHours(-26))
            {
                GetCoinPrice(symbolLowered, cp => afterDataReceived(cp.MapToModel<CoinPrice, CoinHistory>()));
                return;
            }
            if (MemoryCache.TryGet<CoinHistory>($"GetCoinHistory({date.ToShortDateString()},{symbolLowered})", out var cacheValue))
            {
                afterDataReceived(cacheValue);
            }

            try
            {
                if (_coinHistoryRequestQueue.Count < MaxQueueSize)
                {
                    _coinHistoryRequestQueue.Enqueue(new QueuedCoinHistoryRequest(date.Date, symbolLowered, afterDataReceived));
                }
            }
            catch (Exception)
            {
                // to much in the queue, skip this request
            }
        }

        private async Task BackgroundCoinInfoDownloaderTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_coinPriceRequestQueue.TryDequeue(out var priceRequest) && priceRequest != null)
                {
                    var coinPrice = GetOrAddTokenCoinPrice(priceRequest.SymbolLowered);
                    if (coinPrice != null)
                    {
                        priceRequest.AfterDataReceived(coinPrice);
                    }
                }
                else if (_coinHistoryRequestQueue.TryDequeue(out var historyRequest) && historyRequest != null)
                {
                    var coinHistory = GetOrAddCoinHistory(historyRequest.Date, historyRequest.SymbolLowered);
                    if (coinHistory != null)
                    {
                        historyRequest.AfterDataReceived(coinHistory);
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

        private CoinPrice? GetOrAddTokenCoinPrice(string symbolLowered)
        {
            if (TokenPricesBySymbol.TryGetValue(symbolLowered, out var coinPrice))
            {
                return coinPrice;
            }
            if (_coinSymbolCoinIds?.TryGetValue(symbolLowered, out var tokenCoinIds) == true)
            {
                foreach (var tokenCoinId in tokenCoinIds)
                {
                    try
                    {
                        var tokenCoinPrice = _apiClient.GetCoinPrice(tokenCoinId);
                        if (CoinIdsWhiteList.Any(w => tokenCoinPrice.Id == w)
                            || !string.IsNullOrEmpty(tokenCoinPrice.Platforms.Zilliqa))
                        {
                            TokenPricesBySymbol.Add(symbolLowered, tokenCoinPrice);
                            _symbolToCoinId.Add(symbolLowered, tokenCoinId);
                            CoinPriceChanged?.Invoke(this, new CoinPriceChangedEventArgs(symbolLowered, tokenCoinPrice));
                            return tokenCoinPrice;
                        }
                    }
                    catch (Exception ex)
                    {
                        // get coin price failed
                        Logging.LogWarning(
                            $"CoingeckoRepository.GetOrAddTokenCoinPrice('{symbolLowered}') failed with error: {ex.GetType()} - {ex.Message}");
                    }
                }
            }

            return null;
        }

        private CoinHistory? GetOrAddCoinHistory(DateTime date, string symbolLowered)
        {
            return MemoryCache.GetOrAdd($"GetCoinHistory({date.ToShortDateString()},{symbolLowered})",
                TimeSpan.FromMinutes(30),
                () =>
                {
                    string? coinId = null;
                    if (symbolLowered == "zil")
                    {
                        coinId = CoinIdZilliqa;
                    }
                    else if (_symbolToCoinId.TryGetValue(symbolLowered, out var tokenCoinId))
                    {
                        coinId = tokenCoinId;
                    }

                    if (coinId != null)
                    {
                        var dbTable = RepositoryManager.Instance.CacheDatabase.GetTable<CoinHistoryCache>();
                        var dbResult = dbTable.EnumerateRecords(new FilterQueryField(nameof(CoinHistoryCache.Date), date),
                            c => c.CoinHistory.Symbol == symbolLowered).FirstOrDefault();
                        if (dbResult != null)
                        {
                            return dbResult.CoinHistory;
                        }

                        try
                        {
                            var apiResult = _apiClient.GetCoinHistory(coinId, date);
                            if (apiResult == null)
                            {
                                Logging.LogWarning(
                                    $"CoingeckoRepository.GetCoinHistory({date.ToShortDateString()},{symbolLowered}) ApiClient returned NULL");
                                apiResult = CoinHistory.CreateEmpty(symbolLowered);
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
                        catch (Exception ex)
                        {
                            Logging.LogWarning(
                                $"CoingeckoRepository.GetCoinHistory({date.ToShortDateString()},{symbolLowered}) failed with error: {ex.GetType()} - {ex.Message}");
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
            public QueuedCoinHistoryRequest(DateTime date, string symbolLowered, Action<CoinHistory> afterDataReceived)
            {
                Date = date;
                SymbolLowered = symbolLowered;
                AfterDataReceived = afterDataReceived;
            }
            public DateTime Date { get; }
            public string SymbolLowered { get; }
            public Action<CoinHistory> AfterDataReceived { get; }
        }

        private class QueuedCoinPriceRequest
        {
            public QueuedCoinPriceRequest(string symbolLowered, Action<CoinPrice> afterDataReceived)
            {
                SymbolLowered = symbolLowered;
                AfterDataReceived = afterDataReceived;
            }
            public string SymbolLowered { get; }
            public Action<CoinPrice> AfterDataReceived { get; }
        }

        public class CoinPriceChangedEventArgs : EventArgs
        {
            public CoinPriceChangedEventArgs(string symbolLowered, CoinPrice coinPrice)
            {
                SymbolLowered = symbolLowered;
                CoinPrice = coinPrice;
            }
            public string SymbolLowered { get; }
            public CoinPrice CoinPrice { get; }
        }
    }
}

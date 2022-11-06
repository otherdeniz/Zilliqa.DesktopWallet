using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;

namespace Zilliqa.DesktopWallet.Core.Api.Coingecko
{
    public class CoingeckoApiClient
    {
        private static readonly string BaseUrl = "https://api.coingecko.com/api/v3/";
        private static readonly string WebUrl = "https://www.coingecko.com/";
        private readonly object _callLock = new();
        private DateTime _lastCall = DateTime.Now.AddSeconds(-3);

        public List<CoinListInfo> GetCoinsListInfo()
        {
            return CallApi<List<CoinListInfo>>("coins/list");
        }

        public CoinPrice GetCoinPrice(string coinId)
        {
            return CallApi<CoinPrice>($"coins/{coinId}?localization=false&tickers=false&community_data=false&developer_data=false&sparkline=false");
        }

        public CoinHistory GetCoinHistory(string coinId, DateTime date)
        {
            return CallApi<CoinHistory>($"coins/{coinId}/history?date={date:dd-MM-yyyy}");
        }

        public byte[]? GetCoinSparkline(string coinNumber)
        {
            try
            {
                using (var client = new RestClient(WebUrl))
                {
                    var imageRequest = new RestRequest($"coins/{coinNumber}/sparkline");
                    var imageResponse = client.Execute(imageRequest);
                    if (imageResponse.IsSuccessful)
                    {
                        return imageResponse.RawBytes;
                    }
                }
            }
            catch (Exception e)
            {
                Logging.LogError("Failed to download sparkline from Coingecko", e);
            }

            return null;
        }

        private TResult CallApi<TResult>(string urlPath)
        {
            lock (_callLock)
            {
                var responseContent = Task.Run(async () => await CallApiContent(urlPath))
                    .GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<TResult>(responseContent)
                       ?? throw new ApiCallException(
                           $"CoingeckoApiClient Response Deserialization failed to Type {typeof(TResult)};");
            }
        }

        private async Task<string> CallApiContent(string urlPath)
        {
            if (_lastCall.AddSeconds(2) > DateTime.Now)
            {
                // only 1 call per 1.2 seconds (Coingecko limits the number of calls to 50 per minute)
                await Task.Delay(2000);
            }

            var requestUrl = $"{BaseUrl}{urlPath}";
            int retryAfterSeconds = 0;
            do
            {
                _lastCall = DateTime.Now;
                using (var client = new RestClient())
                {
                    var request = new RestRequest(requestUrl, Method.Get);

                    var response = await client.ExecuteAsync(request);
                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        if (retryAfterSeconds == 0)
                        {
                            retryAfterSeconds = 10;
                        }
                        else if(retryAfterSeconds == 10)
                        {
                            retryAfterSeconds = 30;
                        }
                        else if (retryAfterSeconds == 30)
                        {
                            retryAfterSeconds = 60;
                        }
                        else if (retryAfterSeconds == 60)
                        {
                            retryAfterSeconds = 61;
                        }
                        else if (retryAfterSeconds == 61)
                        {
                            retryAfterSeconds = 62;
                        }
                        else if (retryAfterSeconds == 32)
                        {
                            retryAfterSeconds = 63;
                        }
                        else if (retryAfterSeconds == 63)
                        {
                            throw new ApiCallException($"CoingeckoApiClient Response Code was always TooManyRequests for more than 6 retries (10s, 30s, 60s, 61s, 62s, 63s); URL = {requestUrl};");
                        }
                        await Task.Delay(retryAfterSeconds * 1000);
                    }
                    else if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApiCallException($"CoingeckoApiClient Response was not OK; URL = {requestUrl}; StatusCode = {response.StatusCode}; Response = {response.Content}");
                    }
                    else
                    {
                        return response.Content
                               ?? throw new ApiCallException($"CoingeckoApiClient Response Content was null; URL = {requestUrl}");
                    }
                }
            } while (retryAfterSeconds > 0);

            throw new ApiCallException($"CoingeckoApiClient Response ended unexpected; URL = {requestUrl}");
        }
    }
}

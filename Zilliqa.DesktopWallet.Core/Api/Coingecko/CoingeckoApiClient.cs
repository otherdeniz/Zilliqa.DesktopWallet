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
        private readonly object _callLock = new();
        private DateTime _lastCall = DateTime.Now;

        public List<CoinListInfo> GetCoinsListInfo()
        {
            return CallApi<List<CoinListInfo>>("coins/list");
        }

        public CoinHistory GetCoinHistory(string coinId, DateTime date)
        {
            return CallApi<CoinHistory>($"coins/{coinId}/history?date={date:dd-MM-yyyy}");

        }

        private TResult CallApi<TResult>(string urlPath, List<KeyValuePair<string, string>>? arguments = null)
        {
            lock (_callLock)
            {
                var responseContent = Task.Run(async () => await CallApiContent(urlPath, arguments))
                    .GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<TResult>(responseContent)
                       ?? throw new ApiCallException(
                           $"CoingeckoApiClient Response Deserialization failed to Type {typeof(TResult)};");
            }
        }

        private async Task<string> CallApiContent(string urlPath, List<KeyValuePair<string, string>>? arguments = null)
        {
            if (_lastCall.AddSeconds(1.2) > DateTime.Now)
            {
                // only 1 call per 1.2 seconds (Coingecko limits the number of calls to 50 per minute)
                await Task.Delay(1200);
            }
            _lastCall = DateTime.Now;
            var requestUrl = $"{BaseUrl}{urlPath}";
            if (arguments != null && arguments.Count > 0)
            {
                requestUrl += "?" + string.Join("&", arguments.Select(a => $"¨{a.Key}={a.Value}"));
            }
            using (var client = new RestClient())
            {
                var request = new RestRequest(requestUrl, Method.Get);

                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApiCallException($"CoingeckoApiClient Response was not OK; URL = {requestUrl}");
                }

                return response.Content
                       ?? throw new ApiCallException($"CoingeckoApiClient Response Content was null; URL = {requestUrl}");
            }
        }
    }
}

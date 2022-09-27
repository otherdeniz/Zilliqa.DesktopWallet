using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi
{
    public class ViewBlockApiClient
    {
        private const string BaseUrl = "https://api.viewblock.io/v1/zilliqa";
        private readonly string _apiKey;
        private readonly bool _useMainnet;

        public ViewBlockApiClient(string apiKey, bool useMainnet = false)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _useMainnet = useMainnet;
        }

        private string NetworkParameter => _useMainnet ? "mainnet" : "testnet";

        public List<ViewBlockTransaction> GetTransactionsForAddress(string addressHex)
        {
            var result = new List<ViewBlockTransaction>();
            using (var client = GetClient())
            {
                var pageNumber = 0;
                var getNextPage = true;
                do
                {
                    pageNumber++;
                    var responseContent = string.Empty;
                    try
                    {
                        var request = new RestRequest(
                            $"addresses/{addressHex}/txs?network={NetworkParameter}&page={pageNumber}",
                            Method.Get);
                        var response = client.Execute(request);
                        responseContent = response.Content;
                        var responseTransactions = JsonConvert.DeserializeObject<List<ViewBlockTransaction>>(response.Content ?? throw new Exception("Content is null"));
                        result.AddRange(responseTransactions);
                        getNextPage = responseTransactions.Count >= 25;
                        if (getNextPage)
                        {
                            Task.Delay(500).GetAwaiter().GetResult();
                        }
                    }
                    catch (Exception e)
                    {
                        throw new ApiCallException($"{e.Message} {responseContent}", e);
                    }
                } while (getNextPage);
            }

            return result;
        }

        private RestClient GetClient()
        {
            var client = new RestClient(BaseUrl);
            client.AddDefaultHeader("X-APIKEY", _apiKey);
            return client;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model;

namespace Zilliqa.DesktopWallet.ApiClient.ZilstreamApi
{
    public class ZilstreamApiClient
    {
        private const string BaseUrl = "https://api.zilstream.com/v2/";

        public async Task<List<ZilstreamToken>> GetTokensAsync()
        {
            using (var client = GetClient())
            {
                var request = new RestRequest("tokens", Method.Get);
                var response = await client.ExecuteAsync(request);
                return JsonConvert.DeserializeObject<List<ZilstreamToken>>(response.Content ?? throw new Exception("Content is null"));
            }
        }

        private RestClient GetClient()
        {
            var client = new RestClient(BaseUrl);
            return client;
        }

    }
}

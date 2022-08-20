using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.API
{
    public class APIResponse
    {
      
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("jsonrpc")]
            public string Jsonrpc { get; set; }

            [JsonProperty("result")]
            public object Result { get; set; }

            [JsonProperty("error")]
            public object Error { get; set; }

    }
}

using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.API
{
    public class MusRequest
    {
        public MusRequest(string method, string param)
        {
            Id = "1";
            Method = method;
            Parameters = new object[] { param };
            Jsonrpc = "2.0";
        }
        public MusRequest(string method, object[] parameters)
        {
            Id = "1";
            Method = method;
            Parameters = parameters;
            Jsonrpc = "2.0";
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object[] Parameters { get; set; }

        /// <summary>
        /// Returns request as Json (using Newtonsoft)
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

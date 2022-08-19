using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class Param
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("vname")]
        public string Vname { get; set; }

    }

}
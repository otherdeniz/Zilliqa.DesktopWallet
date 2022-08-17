using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class Msg
    {
        [JsonProperty("_amount")]
        public long Amount { get; set; }

        [JsonProperty("_recipient")]
        public string Recipient { get; set; }

        [JsonProperty("_tag")]
        public string Tag { get; set; }

        [JsonProperty("params")]
        public Param[] Params { get; set; }
    }
}

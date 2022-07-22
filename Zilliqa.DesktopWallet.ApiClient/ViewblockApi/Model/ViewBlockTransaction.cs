using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model
{
    public class ViewBlockTransaction
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("blockHeight")]
        public long Blockheight { get; set; }

        [JsonProperty("from")]
        public string FromAddress { get; set; }

        [JsonProperty("to")]
        public string ToAddress { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("timestamp")]
        public long TimestampUnix { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; set; }

        [JsonProperty("receiptSuccess")]
        public bool ReceiptSuccess { get; set; }
    }
}

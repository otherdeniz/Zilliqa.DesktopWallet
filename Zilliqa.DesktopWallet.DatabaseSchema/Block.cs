using Newtonsoft.Json;
using Zilligraph.Database.Contract;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class Block
    {
        [SchemaIndex]
        [JsonProperty("A")]
        public int BlockNumber { get; set; }

        [JsonProperty("B")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("C")]
        public int DSBlockNum { get; set; }

        [JsonProperty("D")]
        public long GasLimit { get; set; }

        [JsonProperty("E")]
        public long GasUsed { get; set; }

        [JsonProperty("F")]
        public string MinerPubKey { get; set; }

        [JsonProperty("G")]
        public int NumMicroBlocks { get; set; }

        [JsonProperty("H")]
        public int NumTxns { get; set; }

        [JsonProperty("I")]
        public long Rewards { get; set; }

        [JsonProperty("J")]
        public long TxnFees { get; set; }

        [JsonProperty("K")]
        public int Version { get; set; }

    }
}

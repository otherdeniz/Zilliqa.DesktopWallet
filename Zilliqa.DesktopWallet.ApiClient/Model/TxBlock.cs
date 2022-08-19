using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class TxBlock : BlockInfo
    {
        [JsonIgnore]
        public override string BlockNum => Header.BlockNum;

        [JsonIgnore]
        public override string Hash { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        [JsonProperty("header")]
        public TxBlockHeader Header { get; set; }
    }

    public class Body
    {
        public string BlockHash { get; set; }

        public string HeaderSign { get; set; }

        public IList<MicroBlockInfo> MicroBlockInfos { get; set; }
    }

    public class TxBlockHeader
    {
        public string BlockNum { get; set; }

        public string DSBlockNum { get; set; }

        public string GasLimit { get; set; }

        public string GasUsed { get; set; }

        public string MbInfoHash { get; set; }

        public string MinerPubKey { get; set; }

        public int NumMicroBlocks { get; set; }

        public int NumPages { get; set; }

        public int NumTxns { get; set; }

        public string PrevBlockHash { get; set; }

        public string Rewards { get; set; }

        public string StateDeltaHash { get; set; }

        public string StateRootHash { get; set; }

        public string Timestamp { get; set; }

        public string TxnFees { get; set; }

        public int Version { get; set; }
    }

    public class MicroBlockInfo
    {
        public string MicroBlockHash { get; set; }

        public int MicroBlockShardId { get; set; }

        public string MicroBlockTxnRootHash { get; set; }
    }

}

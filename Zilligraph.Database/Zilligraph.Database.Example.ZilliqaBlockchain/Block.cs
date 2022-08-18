using Zilligraph.Database.Definition;

namespace Zilligraph.Database.Schema.ZilliqaBlockchain
{
    public class Block
    {
        [SchemaIndex]
        public int Number { get; set; }

        public DateTime Timestamp { get; set; }

        public string DSBlockNum { get; set; }

        public string GasLimit { get; set; }

        public string GasUsed { get; set; }

        public string MinerPubKey { get; set; }

        public int NumMicroBlocks { get; set; }

        public int NumTxns { get; set; }

        public string Rewards { get; set; }

        public int Version { get; set; }

    }
}

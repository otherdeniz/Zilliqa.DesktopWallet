using System.Collections.Generic;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.ApiClient.Blockchain
{
    public class BlockchainInfo
    {
        public string CurrentDSEpoch { get; set; }
        public string CurrentMiniEpoch { get; set; }
        public double DSBlockRate { get; set; }
        public string NumDSBlocks { get; set; }
        public int NumPeers { get; set; }
        public string NumTransactions { get; set; }
        public string NumTxBlocks { get; set; }
        public string NumTxnsDSEpoch { get; set; }
        public string NumTxnsTxEpoch { get; set; }

        [Browsable(false)]
        public ShardingStructure ShardingStructure { get; set; }
        public IList<int> ShardingPeers => ShardingStructure.NumPeers;
    }
    public class ShardingStructure
    {
        public IList<int> NumPeers { get; set; }
    }
}

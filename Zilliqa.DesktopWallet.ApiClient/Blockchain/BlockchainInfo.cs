using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Zilliqa.DesktopWallet.ApiClient.Blockchain
{
    public class BlockchainInfo
    {
        [Browsable(false)]
        public string CurrentDSEpoch { get; set; }

        [Browsable(false)]
        public string CurrentMiniEpoch { get; set; }

        public double DSBlockRate { get; set; }

        public double TxBlockRate { get; set; }

        public double TransactionRate { get; set; }

        [Browsable(false)]
        public string NumDSBlocks { get; set; }

        [Browsable(false)]
        public string NumTransactions { get; set; }
        public int NumberOfTransactions => int.TryParse(NumTransactions, out int intValue) ? intValue : 0;

        [Browsable(false)]
        public string NumTxBlocks { get; set; }
        public int NumberOfBlocks => int.TryParse(NumTxBlocks, out int intValue) ? intValue : 0;

        [Browsable(false)]
        public string NumTxnsDSEpoch { get; set; }

        [Browsable(false)]
        public string NumTxnsTxEpoch { get; set; }

        [Browsable(false)]
        public ShardingStructure ShardingStructure { get; set; }

        public int NumPeers { get; set; }

        public string ShardingPeers => ShardingStructure?.NumPeers?.Any() == true
            ? string.Join(",", ShardingStructure.NumPeers.Select(p => p.ToString()))
            : "-";
    }
    public class ShardingStructure
    {
        public IList<int> NumPeers { get; set; }
    }
}

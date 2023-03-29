using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zilliqa.DesktopWallet.SqliteDatabase.Entities
{
    public class TransactionEntity
    {
        public int BlockNumber { get; set; }

        public DateTime Timestamp { get; set; }

        //[SchemaReference(nameof(BlockNumber), nameof(DatabaseSchema.Block.BlockNumber))]
        //[JsonIgnore]
        //[Browsable(false)] //only for GUI PropertyGrid
        //public LazyReference<Block> Block { get; set; } = null!;

        //[JsonProperty("C")]
        //[PropertyIndex(LowDistinctOptimization = true)]
        public int TransactionType { get; set; }

        //[JsonIgnore]
        //public TransactionType TransactionTypeEnum => (TransactionType)TransactionType;

        public bool TransactionFailed { get; set; }

        //[RequiredValue]
        //[PropertyIndex]
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Data { get; set; }

        public string Code { get; set; }

        public long GasLimit { get; set; }

        public long GasPrice { get; set; }

        public long Nonce { get; set; }

        public string SenderPubKey { get; set; }

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        //[PropertyIndex]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        //[PropertyIndex]
        public string ToAddress { get; set; }

        //[JsonProperty("O")]
        //[TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
        public string ReceiptJson { get; set; }

    }
}

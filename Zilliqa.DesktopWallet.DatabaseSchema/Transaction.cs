using Newtonsoft.Json;
using Zilligraph.Database.Definition;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class Transaction
    {
        [RequiredValue]
        [JsonProperty("A")]
        public int BlockNumber { get; set; }

        [JsonProperty("B")]
        public DateTime Timestamp { get; set; }

        [SchemaReference(nameof(BlockNumber), nameof(DatabaseSchema.Block.BlockNumber))]
        [JsonIgnore]
        public LazyReference<Block> Block { get; set; } = null!;

        [JsonProperty("C")]
        public int TransactionType { get; set; }

        [JsonProperty("D")]
        public bool TransactionFailed { get; set; }

        [JsonIgnore]
        public TransactionType TransactionTypeEnum => (TransactionType)TransactionType;

        [RequiredValue]
        [SchemaIndex]
        [JsonProperty("E")]
        public string Id { get; set; }

        [JsonProperty("F")]
        public decimal Amount { get; set; }

        [JsonProperty("G")]
        public string Data { get; set; }

        [JsonProperty("H")]
        public string Code { get; set; }

        [JsonProperty("I")]
        public long GasLimit { get; set; }

        [JsonProperty("J")]
        public long GasPrice { get; set; }

        [JsonProperty("K")]
        public long Nonce { get; set; }

        [JsonProperty("L")]
        public string SenderPubKey { get; set; }

        [SchemaIndex]
        [JsonProperty("M")]
        public string SenderAddress { get; set; }

        [SchemaIndex]
        [JsonProperty("N")]
        public string ToAddress { get; set; }

        public TransactionContractCall? ContractCall { get; set; }
    }

    public enum TransactionType
    {
        Unknown = 0,
        Payment = 1,
        ContractDeployment = 2,
        ContractCall = 3
    }
}
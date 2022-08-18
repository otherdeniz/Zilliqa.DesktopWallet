using Newtonsoft.Json;
using Zilligraph.Database.Definition;

namespace Zilligraph.Database.Schema.ZilliqaBlockchain
{
    public class Transaction
    {
        [RequiredValue]
        public int BlockNumber { get; set; }

        [SchemaReference(nameof(BlockNumber), typeof(Block), nameof(ZilliqaBlockchain.Block.Number))]
        public LazyReference<Block> Block { get; set; } = null!;

        public int TransactionType { get; set; }

        [JsonIgnore]
        public TransactionType TransactionTypeEnum => (TransactionType)TransactionType;

        [RequiredValue]
        [SchemaIndex]
        public string Id { get; set; }

        public double Amount { get; set; }

        public string Data { get; set; }

        public string Code { get; set; }

        public long GasLimit { get; set; }

        public long GasPrice { get; set; }

        public long Nonce { get; set; }

        public string SenderPubKey { get; set; }

        [SchemaIndex]
        public string SenderAddress { get; set; }

        [SchemaIndex]
        public string ToAddress { get; set; }

        public TransactionContractDeployment? ContractDeployment { get; set; }

        public TransactionContractCall? ContractCall { get; set; }
    }

    public enum TransactionType
    {
        Unknown = 0,
        Payment = 1,
        ContractDeployment = 2,
        ContractCall = 3,
        Failed = 9
    }
}
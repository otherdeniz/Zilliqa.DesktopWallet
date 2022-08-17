using Newtonsoft.Json;
using Zilligraph.Database.Definition;

namespace Zilligraph.Database.Schema.ZilliqaBlockchain
{
    public class Transaction
    {
        [RequiredValue]
        public long Block { get; set; }

        public int TransactionType { get; set; }

        [JsonIgnore]
        public TransactionType TransactionTypeEnum 
            => (ZilliqaBlockchain.TransactionType)TransactionType;

        [RequiredValue]
        [SchemaIndex]
        public string Id { get; set; }

        public long Amount { get; set; }

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
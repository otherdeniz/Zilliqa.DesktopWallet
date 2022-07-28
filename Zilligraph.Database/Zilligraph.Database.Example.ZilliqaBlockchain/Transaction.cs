using Zilligraph.Database.SchemaDefinition;

namespace Zilligraph.Database.Schema.ZilliqaBlockchain
{
    public class Transaction
    {
        public long Block { get; set; }

        [SchemaIndex]
        public int TransactionType { get; set; }

        public string ID { get; set; }

        public long Amount { get; set; }

        public int GasLimit { get; set; }

        public int Nonce { get; set; }

        public string SenderPubKey { get; set; }

        [SchemaIndex]
        public string SenderAddress { get; set; }

        [SchemaIndex]
        public string ToAddress { get; set; }

        public string Data { get; set; }

        public TransactionContractDeployment? ContractDeployment { get; set; }

        public TransactionContractCall? ContractCall { get; set; }
    }

    public enum TransactionType
    {
        Payment = 1,
        ContractDeployment = 2,
        ContractCall = 3,
        Failed = 9
    }
}
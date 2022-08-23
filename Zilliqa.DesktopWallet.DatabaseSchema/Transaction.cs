using Newtonsoft.Json;
using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class Transaction
    {
        private DataContractCall? _dataContractCall;

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

        public decimal GetZilAmount()
        {
            return Amount / 1000000000000m;
        }

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

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        [SchemaIndex]
        [JsonProperty("M")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        [SchemaIndex]
        [JsonProperty("N")]
        public string ToAddress { get; set; }

        [JsonProperty("O")]
        public TransactionReceipt Receipt { get; set; }

        [JsonIgnore]
        public DataContractCall DataContractCall => _dataContractCall ??=
            DataContractCall.TryParse(Data, out var data) ? data : DataContractCall.Empty;

        [CalculatedIndex]
        public string? TokenTransferRecipient()
        {
            if (!TransactionFailed &&
                DataContractCall.Tag == "Transfer")
            {
                var firstEvent = Receipt.EventLogs.FirstOrDefault();
                if (firstEvent?.Eventname == "TransferSuccess")
                {
                    return firstEvent.Params
                        .Where(p => p.Vname == "recipient")
                        .Select(p => p.ResolvedValue.ToString())
                        .FirstOrDefault();
                }
            }

            return null;
        }

        [CalculatedIndex]
        public string? TokenTransferSender()
        {
            if (!TransactionFailed &&
                DataContractCall.Tag == "Transfer")
            {
                var firstEvent = Receipt.EventLogs.FirstOrDefault();
                if (firstEvent?.Eventname == "TransferSuccess")
                {
                    return firstEvent.Params
                        .Where(p => p.Vname == "sender")
                        .Select(p => p.ResolvedValue.ToString())
                        .FirstOrDefault();
                }
            }

            return null;
        }

        public decimal? TokenTransferAmount()
        {
            if (!TransactionFailed &&
                DataContractCall.Tag == "Transfer")
            {
                var firstEvent = Receipt.EventLogs.FirstOrDefault();
                if (firstEvent?.Eventname == "TransferSuccess")
                {
                    var amountParam = firstEvent.Params.FirstOrDefault(p => p.Vname == "amount");
                    if (amountParam?.ResolvedValue is ParamValueUInt128 value128)
                    {
                        return value128.Number128;
                    }
                    if (amountParam?.ResolvedValue is ParamValueUInt32 value32)
                    {
                        return value32.Number32;
                    }
                }
            }

            return null;
        }
    }

    public enum TransactionType
    {
        Unknown = 0,
        Payment = 1,
        ContractDeployment = 2,
        ContractCall = 3
    }
}
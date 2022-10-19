using System.ComponentModel;
using Newtonsoft.Json;
using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;
using Environment = System.Environment;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    [TableModel(TableKind.NotMutable)]
    public class Transaction
    {
        private DataContractCall? _dataContractCall;
        private List<DataParam>? _dataContractDeploymentParams;

        [RequiredValue]
        [PropertyIndex]
        [JsonProperty("A")]
        public int BlockNumber { get; set; }

        [JsonProperty("B")]
        public DateTime Timestamp { get; set; }

        [SchemaReference(nameof(BlockNumber), nameof(DatabaseSchema.Block.BlockNumber))]
        [JsonIgnore]
        [Browsable(false)] //only for GUI PropertyGrid
        public LazyReference<Block> Block { get; set; } = null!;

        [JsonProperty("C")]
        [PropertyIndex(LowDistinctOptimization = true)]
        public int TransactionType { get; set; }

        [JsonIgnore]
        public TransactionType TransactionTypeEnum => (TransactionType)TransactionType;

        [JsonProperty("D")]
        public bool TransactionFailed { get; set; }

        [RequiredValue]
        [PropertyIndex]
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

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        [PropertyIndex]
        [JsonProperty("M")]
        public string SenderAddress { get; set; }

        /// <summary>
        /// Hex-Address without leading '0x'
        /// </summary>
        [PropertyIndex]
        [JsonProperty("N")]
        public string ToAddress { get; set; }

        [JsonProperty("O")]
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
        public TransactionReceipt Receipt { get; set; }

        [JsonIgnore]
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
        public DataContractCall DataContractCall => _dataContractCall ??=
            TransactionTypeEnum == DatabaseSchema.TransactionType.ContractCall
            && DataContractCall.TryParse(Data, out var pasedData)
                ? pasedData
                : DataContractCall.Empty;

        [JsonIgnore]
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
        public List<DataParam> DataContractDeploymentParams => _dataContractDeploymentParams ??=
            TransactionTypeEnum == DatabaseSchema.TransactionType.ContractDeployment
            && DataParam.TryParseList(Data, out var parsedData)
            && parsedData != null
                ? parsedData
                : new List<DataParam>();

        [CalculatedIndex]
        public string? ContractMethod()
        {
            return DataContractCall.Tag;
        }

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
                    if (amountParam?.ResolvedValue is ParamValueBigInteger valueBigInteger)
                    {
                        return (ulong)valueBigInteger.NumberBig.LongValue;
                    }
                    if (amountParam?.ResolvedValue is ParamValueUInt32 value32)
                    {
                        return value32.Number32;
                    }
                }
            }

            return null;
        }

        public string? GetErrorMessage()
        {
            return TransactionFailed
                ? Receipt.Exceptions.Select(e => e.Message).FirstOrDefault()
                  ?? Receipt.Errors.Numbers.Select(n => $"Error Code #{n} : {(TransactionErrorCodes)n}").FirstOrDefault()
                : null;
        }

        public string? GetPatchedCode()
        {
            return Code?.Replace(" end ", $"{Environment.NewLine}end{Environment.NewLine}");
        }
    }

    public enum TransactionType
    {
        Unknown = 0,
        Payment = 1,
        ContractDeployment = 2,
        ContractCall = 3
    }

    public enum TransactionErrorCodes
    {
        CHECKER_FAILED = 0,
        RUNNER_FAILED = 1,
        BALANCE_TRANSFER_FAILED = 2,
        EXECUTE_CMD_FAILED = 3,
        EXECUTE_CMD_TIMEOUT = 4,
        NO_GAS_REMAINING_FOUND = 5,
        NO_ACCEPTED_FOUND = 6,
        CALL_CONTRACT_FAILED = 7,
        CREATE_CONTRACT_FAILED = 8,
        JSON_OUTPUT_CORRUPTED = 9,
        CONTRACT_NOT_EXIST = 10,
        STATE_CORRUPTED = 11,
        LOG_ENTRY_INSTALL_FAILED = 12,
        MESSAGE_CORRUPTED = 13,
        RECEIPT_IS_NULL = 14,
        MAX_EDGES_REACHED = 15,
        CHAIN_CALL_DIFF_SHARD = 16,
        PREPARATION_FAILED = 17,
        NO_OUTPUT = 18,
        OUTPUT_ILLEGAL = 19,
        MAP_DEPTH_MISSING = 20,
        GAS_NOT_SUFFICIENT = 21,
        INTERNAL_ERROR = 22,
        LIBRARY_AS_RECIPIENT = 23,
        VERSION_INCONSISTENT = 24,
        LIBRARY_EXTRACTION_FAILED = 25
    }

}
using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(Title), nameof(SubTitle))]
    public class TransactionDetailsViewModel
    {
        private readonly ContractCallAmountInfo? _contractCallAmountInfo;

        public TransactionDetailsViewModel(Transaction transactionModel)
        {
            TransactionModel = transactionModel;
            var tokenTransferRecipient = TransactionModel.TokenTransferRecipient();
            if (tokenTransferRecipient == null)
            {
                if (TransactionModel.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    ContractAddress = new AddressValue(TransactionModel.ToAddress);
                }
                else
                {
                    RecipientAddress = new AddressValue(TransactionModel.ToAddress);
                }
            }
            else
            {
                ContractAddress = new AddressValue(TransactionModel.ToAddress);
                RecipientAddress = new AddressValue(tokenTransferRecipient);
            }
            if (ContractAddress != null 
                && ContractCallAmountInfo.TryParse(transactionModel, out var callInfo))
            {
                _contractCallAmountInfo = callInfo;
            }
        }

        [Browsable(false)]
        public Transaction TransactionModel { get; }

        [Browsable(false)]
        public Image Icon48 => TransactionModel.TransactionFailed 
            ? IconResources.TransactionFailed48 
            : IconResources.Transaction48;

        [Browsable(false)]
        public string Title
        {
            get
            {
                var sufix = TransactionModel.TransactionFailed ? " (Failed)" : "";
                if (TransactionModel.TransactionTypeEnum == TransactionType.Payment)
                {
                    return $"ZIL Transfer{sufix}";
                }
                if (TransactionModel.TransactionTypeEnum == TransactionType.ContractCall
                    && TransactionModel.DataContractCall.Tag == "Transfer")
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(TransactionModel.ToAddress);
                    if (tokenModel != null)
                    {
                        return $"{tokenModel.TokenModel.Symbol} Transfer{sufix}";

                    }
                    return $"Token Transfer{sufix}";
                }
                if (TransactionModel.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    return $"Contract Call{sufix}";
                }
                if (TransactionModel.TransactionTypeEnum == TransactionType.ContractDeployment)
                {
                    return $"Contract Deployment{sufix}";
                }
                return $"Transaction{sufix}";
            }
        }

        [Browsable(false)]
        public string SubTitle => $"0x{TransactionModel.Id}";

        [DetailsProperty]
        [DisplayName("Error Message")]
        public string? Error => TransactionModel.TransactionFailed 
            ? TransactionModel.Receipt.Exceptions.Select(e => e.Message).FirstOrDefault()
                ?? TransactionModel.Receipt.Errors.Numbers.Select(n => $"Error Code #{n} : {(TransactionErrorCodes)n}").FirstOrDefault()
            : null;

        [DetailsProperty(DetailsPropertyType.BlockNumber)]
        public int Block => TransactionModel.BlockNumber;

        [DetailsProperty]
        public string Date => TransactionModel.Timestamp.ToString("g");

        [DetailsProperty]
        [DisplayName("Sender Address")]
        public AddressValue SenderAddress => new AddressValue(TransactionModel.SenderAddress);

        [DetailsProperty]
        [DisplayName("Contract Address")]
        public AddressValue? ContractAddress { get; }

        [DetailsProperty]
        [DisplayName("Recipient Address")]
        public AddressValue? RecipientAddress { get; }

        [DetailsProperty]
        [DisplayName("Contract Name")]
        public string? ContractName => ContractAddress?.SmartContract?.ContractName;

        [DetailsProperty]
        [DisplayName("Contract Method")]
        public string? Method => TransactionModel.DataContractCall.Tag;

        [DetailsChildProperties("Contract Parameters")]
        public List<DataParam> DataParams => TransactionModel.DataContractCall.Params;

        [DetailsProperty]
        [DisplayName("ZIL Amount")]
        public string? ZilAmount => TransactionModel.Amount == 0 
            ? (_contractCallAmountInfo?.Symbol == "ZIL" ? _contractCallAmountInfo.Amount.ToString("#,##0.0000 ZIL") : null) 
            : TransactionModel.Amount.ZilSatoshisToZil().ToString("#,##0.0000 ZIL");

        [DetailsProperty]
        [DisplayName("Token Amount")]
        public string? Amount => _contractCallAmountInfo != null && _contractCallAmountInfo.Symbol != "ZIL"
            ? $"{_contractCallAmountInfo.Amount:#,##0.0000} {_contractCallAmountInfo.Symbol}"
            : null;

        [DetailsProperty]
        [DisplayName("Fee")]
        public string Fee => (TransactionModel.Receipt.CumulativeGas * TransactionModel.GasPrice)
            .ZilSatoshisToZil().ToString("#,##0.0000 ZIL");

        [DetailsProperty]
        [DisplayName("Gas Limit")]
        public string GasLimit => TransactionModel.GasLimit.ToString("#,##0");

        [DetailsProperty]
        [DisplayName("Gas Price")]
        public string GasPrice => TransactionModel.GasPrice.ZilSatoshisToZil().ToString("#,##0.000000 ZIL");

        [DetailsProperty]
        [DisplayName("Nonce")]
        public string Nonce => TransactionModel.Nonce.ToString("0");

        [DetailsChildObject("Receipt")]
        public TransactionReceipt Receipt => TransactionModel.Receipt;

        [DetailsChildObject("Code")]
        public ScillaCodeValue? Code => string.IsNullOrEmpty(TransactionModel.Code)
            ? null
            : new ScillaCodeValue(TransactionModel.Code);
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

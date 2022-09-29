using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ContractCallTransactionRowViewModel : TransactionRowViewModelBase
    {
        private readonly ContractCallInfo? _contractCallInfo;
        private Image? _directionIcon;
        private string? _date;

        public ContractCallTransactionRowViewModel(Address thisAddress, Transaction transactionModel) 
            : base(thisAddress, transactionModel)
        {
            if (ContractCallInfo.TryParse(transactionModel, out var callInfo))
            {
                _contractCallInfo = callInfo;
            }
        }

        [Browsable(false)]
        public override string Symbol => _contractCallInfo?.Symbol ?? "";

        [Browsable(false)] 
        public override decimal Amount => _contractCallInfo?.Amount ?? 0;

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(true)]
        public override BlockNumberValue Block => base.Block;


        public string? Method => Transaction.DataContractCall.Tag;

        [Browsable(true)]
        [DisplayName(" ")]
        public override Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
            ? IconResources.ArrowRightBlue16
            : IconResources.ArrowLeftBlue16;

        [DisplayName(" ")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo
            ? "to"
            : "from";

        [Browsable(true)]
        [DisplayName("Address")]
        [ColumnWidth(150)]
        public override AddressValue? OtherAddress => base.OtherAddress;

        [Browsable(true)] 
        public override decimal Fee => base.Fee;

    }

    public class ContractCallInfo
    {
        public static bool TryParse(Transaction transactionModel, out ContractCallInfo? result)
        {
            result = null;
            if (transactionModel.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "DelegateStake") 
                is { } delegateStakeTransition)
            {
                result = new ContractCallInfo
                {
                    Amount = delegateStakeTransition.Msg.Amount.ZilSatoshisToZil(),
                    Symbol = "ZIL"
                };
            }
            else if (transactionModel.DataContractCall.Params?.FirstOrDefault(t => t.Vname == "token_address")
                         is { } paramTokenAddressHex
                     && AddressValue.TryParse(paramTokenAddressHex.ResolvedValue.ToString(), out var paramTokenAddress)
                     && transactionModel.DataContractCall.Params?.FirstOrDefault(t => t.Vname == "token_amount")?.ResolvedValue
                         is ParamValueUInt128 paramTokenAmount)
            {

                var tokenModel = TokenDataService.Instance.FindTokenByAddress(paramTokenAddress!.Address);
                if (tokenModel != null)
                {
                    result = new ContractCallInfo
                    {
                        Amount = tokenModel.SmartContract.AmountToDecimal(paramTokenAmount.Number64),
                        Symbol = tokenModel.TokenModel.Symbol
                    };
                }
            }
            return result != null;
        }

        private ContractCallInfo()
        {
        }

        public decimal Amount { get; private set; }

        public string Symbol { get; private set; } = null!;

    }
}

using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.ViewModel;

public class ContractCallAmountInfo
{
    public static bool TryParse(Transaction transactionModel, out ContractCallAmountInfo? result)
    {
        result = null;
        if (transactionModel.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "DelegateStake") 
                is { } delegateStakeTransition)
        {
            result = new ContractCallAmountInfo
            {
                Amount = delegateStakeTransition.Msg.Amount.ZilSatoshisToZil(),
                Symbol = "ZIL"
            };
        }
        else if (transactionModel.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "AddFunds")
                    is { } addFundsTransition)
        {
            result = new ContractCallAmountInfo
            {
                Amount = addFundsTransition.Msg.Amount.ZilSatoshisToZil(),
                Symbol = "ZIL"
            };
        }
        else if (transactionModel.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "RecipientAcceptTransfer")
                     is { } transferTransition1
                 && transferTransition1.Msg.Params?.FirstOrDefault(t => t.Vname == "amount")?.ResolvedValue
                     is ParamValueBigInteger paramTokenAmount1)
        {
            var tokenByAddress = TokenDataService.Instance.FindTokenByAddress(transferTransition1.Addr);
            if (tokenByAddress != null)
            {
                result = new ContractCallAmountInfo
                {
                    Amount = tokenByAddress.SmartContract.AmountToDecimal(paramTokenAmount1.NumberBig),
                    Symbol = tokenByAddress.TokenModel.Symbol,
                    TokenModel = tokenByAddress
                };
            }
        }
        else if (transactionModel.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "Transfer")
                     is { } transferTransition2
                 && transferTransition2.Msg.Params?.FirstOrDefault(t => t.Vname == "amount")?.ResolvedValue
                     is ParamValueBigInteger paramTokenAmount2)
        {
            var tokenModel = TokenDataService.Instance.FindTokenByAddress(transferTransition2.Msg.Recipient);
            if (tokenModel != null)
            {
                result = new ContractCallAmountInfo
                {
                    Amount = tokenModel.SmartContract.AmountToDecimal(paramTokenAmount2.NumberBig),
                    Symbol = tokenModel.TokenModel.Symbol,
                    TokenModel = tokenModel
                };
            }
        }
        return result != null;
    }

    private ContractCallAmountInfo()
    {
    }

    public TokenModelByAddress? TokenModel { get; private set; }

    public decimal Amount { get; private set; }

    public string Symbol { get; private set; } = null!;

}
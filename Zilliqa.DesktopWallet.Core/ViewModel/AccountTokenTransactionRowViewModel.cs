using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel;

public class AccountTokenTransactionRowViewModel
{
    private readonly AccountViewModel _account;
    private readonly Transaction _transactionModel;
    private readonly TokenModel _tokenModel;
    private Image? _logoIcon;
    private Image? _directionIcon;
    private string? _otherAddress;
    private decimal? _tokenAmount;
    private string? _date;

    public AccountTokenTransactionRowViewModel(AccountViewModel account, Transaction transactionModel, TokenModel tokenModel)
    {
        _account = account;
        _transactionModel = transactionModel;
        _tokenModel = tokenModel;
        Direction = _account.Address.Equals(transactionModel.TokenTransferSender())
            ? TransactionDirection.SendTo
            : TransactionDirection.ReceiveFrom;
    }

    [Browsable(false)]
    public TransactionDirection Direction { get; }

    [DisplayName("Icon")]
    public Image? LogoIcon => _logoIcon ??= _tokenModel.GetTokenIcon().Icon16;

    public string Symbol => _tokenModel.Symbol;

    [DisplayName(" ")]
    public Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
        ? IconResources.SendArrow16
        : IconResources.ReceiveArrow16;

    [DisplayName("Direction")]
    public string DirectionLabel => Direction == TransactionDirection.SendTo 
        ? "send to" 
        : "receive from";

    [DisplayName("Address")]
    public string OtherAddress => _otherAddress ??= Direction == TransactionDirection.SendTo
        ? GetAddressDisplay(_transactionModel.TokenTransferRecipient())
        : GetAddressDisplay(_transactionModel.TokenTransferSender());

    [GridViewFormat("#,##0.0000")]
    public decimal Amount => _tokenAmount ??= _tokenModel.AmountToDecimal(_transactionModel.TokenTransferAmount());

    public string Date => _date ??= _transactionModel.Timestamp.ToLocalTime().ToString("g");

    private string GetAddressDisplay(string? rawAddress)
    {
        return rawAddress == null 
            ? "-" 
            : new Address(rawAddress).GetBech32().FromBech32ToShortReadable();
    }
}
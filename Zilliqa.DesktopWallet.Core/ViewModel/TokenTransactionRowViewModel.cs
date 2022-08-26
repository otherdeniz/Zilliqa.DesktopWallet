using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel;

public class TokenTransactionRowViewModel
{
    private readonly Transaction _transactionModel;
    private readonly TokenModel _tokenModel;
    private Image? _logoIcon;
    private Image? _directionIcon;
    private string? _otherAddress;
    private decimal? _tokenAmount;
    private string? _date;

    public TokenTransactionRowViewModel(Address address, Transaction transactionModel, TokenModel tokenModel)
    {
        _transactionModel = transactionModel;
        ThisAddress = address;
        _tokenModel = tokenModel;
        Direction = address.Equals(transactionModel.TokenTransferSender())
            ? TransactionDirection.SendTo
            : TransactionDirection.ReceiveFrom;
    }

    [Browsable(false)]
    public Transaction Transaction => _transactionModel;

    [Browsable(false)]
    public Address ThisAddress { get; }

    [Browsable(false)]
    public TransactionDirection Direction { get; }

    [DisplayName("Icon")]
    public Image? LogoIcon => _logoIcon ??= _tokenModel.GetTokenIcon().Icon16;

    public string Symbol => _tokenModel.Symbol;

    [DisplayName(" ")]
    public Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
        ? IconResources.ArrowRight16
        : IconResources.ArrowLeft16;

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
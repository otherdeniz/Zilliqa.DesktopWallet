using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel;

public class TokenTransactionRowViewModel : TransactionRowViewModelBase
{
    private readonly TokenModel _tokenModel;
    private Image? _logoIcon;
    private Image? _directionIcon;
    private string? _otherAddress;
    private decimal? _tokenAmount;
    private string? _date;

    public TokenTransactionRowViewModel(Address address, Transaction transactionModel, TokenModel tokenModel)
        :base(transactionModel)
    {
        ThisAddress = address;
        _tokenModel = tokenModel;
        Direction = address.Equals(transactionModel.TokenTransferSender())
            ? TransactionDirection.SendTo
            : TransactionDirection.ReceiveFrom;
    }

    [Browsable(false)]
    public Address ThisAddress { get; }

    [Browsable(false)]
    public TransactionDirection Direction { get; }

    [DisplayName("Icon")]
    public Image? LogoIcon => _logoIcon ??= _tokenModel.GetTokenIcon().Icon16;

    public override string Symbol => _tokenModel.Symbol;

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
        ? GetAddressDisplay(Transaction.TokenTransferRecipient())
        : GetAddressDisplay(Transaction.TokenTransferSender());

    [Browsable(true)]
    [GridViewFormat("#,##0.0000")]
    public override decimal Amount => _tokenAmount ??= _tokenModel.AmountToDecimal(Transaction.TokenTransferAmount());

    public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

    private string GetAddressDisplay(string? rawAddress)
    {
        return rawAddress == null 
            ? "-" 
            : new Address(rawAddress).GetBech32().FromBech32ToShortReadable();
    }
}
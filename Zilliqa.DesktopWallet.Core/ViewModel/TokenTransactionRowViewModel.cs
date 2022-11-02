using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel;

public class TokenTransactionRowViewModel : TransactionRowViewModelBase
{
    private readonly TokenModelByAddress _tokenModelByAddress;
    private Image? _logoIcon;
    private Image? _directionIcon;
    private AddressValue? _otherAddress;
    private Zrc2TokenValue? _token;

    private decimal? _tokenAmount;
    private string? _date;

    public TokenTransactionRowViewModel(Address address, Transaction transactionModel, TokenModelByAddress tokenModelByAddress)
        :base(address, transactionModel)
    {
        _tokenModelByAddress = tokenModelByAddress;
        Direction = address.Equals(transactionModel.TokenTransferSender())
            ? TransactionDirection.SendTo
            : TransactionDirection.ReceiveFrom;
    }

    [Browsable(false)]
    public override TransactionDirection Direction { get; }

    [Browsable(false)] 
    public TokenModelByAddress TokenModelByAddress => _tokenModelByAddress;

    public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

    [Browsable(true)]
    public override BlockNumberValue Block => base.Block;

    [DisplayName(" ")]
    public Image? LogoIcon => _logoIcon ??= _tokenModelByAddress.TokenModel.Icon.Icon16;

    public Zrc2TokenValue Token => _token ??= new Zrc2TokenValue(_tokenModelByAddress.TokenModel);

    [Browsable(false)]
    public override string Symbol => _tokenModelByAddress.TokenModel.Symbol;

    [Browsable(true)]
    [DisplayName(" ")]
    public override Image? DirectionIcon => _directionIcon ??= Transaction.TransactionFailed
        ? IconResources.Warning16
        : Direction == TransactionDirection.SendTo
            ? IconResources.ArrowRightViolet16
            : IconResources.ArrowLeftViolet16;

    [DisplayName(" ")]
    public string DirectionLabel => Direction == TransactionDirection.SendTo 
        ? "to" 
        : "from";

    [Browsable(true)]
    [DisplayName("Address")]
    public override AddressValue? OtherAddress =>
        _otherAddress ??= (Direction == TransactionDirection.SendTo
            ? AddressValue.Create(Transaction.TokenTransferRecipient())
            : AddressValue.Create(Transaction.TokenTransferSender())
              ?? base.OtherAddress);

    [Browsable(false)]
    public override decimal Amount => _tokenAmount 
        ??= _tokenModelByAddress.SmartContract?.AmountToDecimal(Transaction.TokenTransferAmount()) 
            ?? Transaction.TokenTransferAmount() 
            ?? 0m;

    [DisplayName("Amount")] 
    public string AmountDisplay => $"{Amount:#,##0.####} {Symbol.TokenSymbolShort()}";

    [Browsable(true)]
    public override decimal Fee => base.Fee;

}
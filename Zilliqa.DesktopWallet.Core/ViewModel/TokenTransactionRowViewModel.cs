﻿using System.ComponentModel;
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
    private decimal? _fee;

    public TokenTransactionRowViewModel(Address address, Transaction transactionModel, TokenModel tokenModel)
        :base(address, transactionModel)
    {
        _tokenModel = tokenModel;
        Direction = address.Equals(transactionModel.TokenTransferSender())
            ? TransactionDirection.SendTo
            : TransactionDirection.ReceiveFrom;
    }

    [Browsable(false)]
    public override TransactionDirection Direction { get; }

    public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

    [DisplayName("Icon")]
    public Image? LogoIcon => _logoIcon ??= _tokenModel.GetTokenIcon().Icon16;

    [Browsable(true)]
    public override string Symbol => _tokenModel.Symbol;

    [Browsable(true)]
    [DisplayName(" ")]
    public override Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
        ? IconResources.ArrowRightBlue16
        : IconResources.ArrowLeftBlue16;

    [DisplayName("Direction")]
    public string DirectionLabel => Direction == TransactionDirection.SendTo 
        ? "send to" 
        : "receive from";

    [Browsable(true)]
    [DisplayName("Address")]
    public override string OtherAddress => _otherAddress ??= Direction == TransactionDirection.SendTo
        ? GetAddressDisplay(Transaction.TokenTransferRecipient())
        : GetAddressDisplay(Transaction.TokenTransferSender());

    [Browsable(false)]
    public override decimal Amount => _tokenAmount ??= _tokenModel.AmountToDecimal(Transaction.TokenTransferAmount());

    [DisplayName("Amount")] 
    public string AmountDisplay => $"{Amount:#,##0.0000} {Symbol}";

    [GridViewFormat("0.0000 ZIL")]
    public decimal Fee => _fee ??= (Transaction.GasPrice * Transaction.GasLimit).ZilSatoshisToZil();

}
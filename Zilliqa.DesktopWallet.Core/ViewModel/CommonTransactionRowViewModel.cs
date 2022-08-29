using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class CommonTransactionRowViewModel : TransactionRowViewModelBase
    {
        private readonly TransactionRowViewModelBase? _innerTransaction;
        private string? _date;
        private decimal? _fee;

        public CommonTransactionRowViewModel(Address thisAddress, Transaction transactionModel, TransactionRowViewModelBase? innerTransaction)
            : base(thisAddress, transactionModel)
        {
            _innerTransaction = innerTransaction;
        }

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(false)]
        public override TransactionDirection Direction => _innerTransaction?.Direction ?? base.Direction;

        public string Type
        {
            get
            {
                if (_innerTransaction is ZilTransactionRowViewModel)
                {
                    return "ZIL Transfer";
                }
                if (_innerTransaction is TokenTransactionRowViewModel tokenTransaction)
                {
                    return $"{tokenTransaction.Symbol} Transfer";
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    return "Contract Call";
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractDeployment)
                {
                    return "Contract Deployment";
                }

                return "other";
            }
        }

        [Browsable(true)]
        [DisplayName(" ")]
        public override Image? DirectionIcon
        {
            get
            {
                if (_innerTransaction != null)
                {
                    return _innerTransaction.DirectionIcon;
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    return IconResources.ArrowRightViolet16;
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractDeployment)
                {
                    return IconResources.ArrowRightRed16;
                }

                return base.DirectionIcon;
            }
        }

        [DisplayName("Direction")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo
            ? "send to"
            : "receive from";

        [Browsable(true)]
        [DisplayName("Address")]
        public override AddressValueViewModel OtherAddress => _innerTransaction?.OtherAddress
                                                              ?? (Direction == TransactionDirection.SendTo
                                                                  ? new AddressValueViewModel(Transaction.ToAddress)
                                                                  : new AddressValueViewModel(Transaction
                                                                      .SenderAddress));

        [Browsable(true)]
        [DisplayName("Amount")]
        public string AmountDisplay =>
            _innerTransaction == null ? string.Empty : $"{_innerTransaction.Amount:#,##0.0000} {_innerTransaction.Symbol}";

        [GridViewFormat("0.0000 ZIL")]
        public decimal Fee => _fee ??= (Transaction.Receipt.CumulativeGas * Transaction.GasPrice).ZilSatoshisToZil();

        public override string Symbol => _innerTransaction?.Symbol ?? "";

        public override decimal Amount => _innerTransaction?.Amount ?? 0;

        //Usd
        public override decimal? ValueUsdToday => _innerTransaction?.ValueUsdToday;
        public override decimal? ValueUsdThen => _innerTransaction?.ValueUsdThen;
        public override ValueNumberDisplay? ChangeUsd => _innerTransaction?.ChangeUsd;

        //Chf
        public override decimal? ValueChfToday => _innerTransaction?.ValueChfToday;
        public override decimal? ValueChfThen => _innerTransaction?.ValueChfThen;
        public override ValueNumberDisplay? ChangeChf => _innerTransaction?.ChangeChf;

        //Eur
        public override decimal? ValueEurToday => _innerTransaction?.ValueEurToday;
        public override decimal? ValueEurThen => _innerTransaction?.ValueEurThen;
        public override ValueNumberDisplay? ChangeEur => _innerTransaction?.ChangeEur;

        //Gbp
        public override decimal? ValueGbpToday => _innerTransaction?.ValueGbpToday;
        public override decimal? ValueGbpThen => _innerTransaction?.ValueGbpThen;
        public override ValueNumberDisplay? ChangeGbp => _innerTransaction?.ChangeGbp;

        //Btc
        public override decimal? ValueBtcToday => _innerTransaction?.ValueBtcToday;
        public override decimal? ValueBtcThen => _innerTransaction?.ValueBtcThen;
        public override ValueNumberDisplay? ChangeBtc => _innerTransaction?.ChangeBtc;

        //Eth
        public override decimal? ValueEthToday => _innerTransaction?.ValueEthToday;
        public override decimal? ValueEthThen => _innerTransaction?.ValueEthThen;
        public override ValueNumberDisplay? ChangeEth => _innerTransaction?.ChangeEth;

        //Ltc
        public override decimal? ValueLtcToday => _innerTransaction?.ValueLtcToday;
        public override decimal? ValueLtcThen => _innerTransaction?.ValueLtcThen;
        public override ValueNumberDisplay? ChangeLtc => _innerTransaction?.ChangeLtc;
    }
}

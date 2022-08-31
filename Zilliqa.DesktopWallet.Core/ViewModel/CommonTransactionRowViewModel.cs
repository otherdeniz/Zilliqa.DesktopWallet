using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class CommonTransactionRowViewModel : TransactionRowViewModelBase
    {
        private readonly TransactionRowViewModelBase? _innerViewModel;
        private AddressValue? _otherAddress;
        private string? _date;
        private decimal? _fee;

        public CommonTransactionRowViewModel(Address thisAddress, Transaction transactionModel, TransactionRowViewModelBase? innerViewModel)
            : base(thisAddress, transactionModel)
        {
            _innerViewModel = innerViewModel;
        }

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(false)]
        public override TransactionDirection Direction => _innerViewModel?.Direction ?? base.Direction;

        public string Type
        {
            get
            {
                if (_innerViewModel is ZilTransactionRowViewModel)
                {
                    return "ZIL Transfer";
                }
                if (_innerViewModel is TokenTransactionRowViewModel tokenTransaction)
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
                if (_innerViewModel != null)
                {
                    return _innerViewModel.DirectionIcon;
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    return IconResources.BarBlue16;
                }
                if (Transaction.TransactionTypeEnum == TransactionType.ContractDeployment)
                {
                    return IconResources.CircleRigthBlue16;
                }

                return base.DirectionIcon;
            }
        }

        [DisplayName(" ")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo
            ? "to"
            : "from";

        [Browsable(true)]
        [DisplayName("Address")]
        public override AddressValue? OtherAddress => _innerViewModel?.OtherAddress
                                                      ?? (_otherAddress ??= Direction == TransactionDirection.SendTo
                                                          ? new AddressValue(Transaction.ToAddress)
                                                          : new AddressValue(Transaction.SenderAddress));

        [Browsable(true)]
        [DisplayName("Amount")]
        public string AmountDisplay =>
            _innerViewModel == null ? string.Empty : $"{_innerViewModel.Amount:#,##0.0000} {_innerViewModel.Symbol}";

        [GridViewFormat("0.0000 ZIL")]
        public decimal Fee => _fee ??= (Transaction.Receipt.CumulativeGas * Transaction.GasPrice).ZilSatoshisToZil();

        public override string Symbol => _innerViewModel?.Symbol ?? "";

        public override decimal Amount => _innerViewModel?.Amount ?? 0;

        //Usd
        public override decimal? ValueUsdToday => _innerViewModel?.ValueUsdToday;
        public override decimal? ValueUsdThen => _innerViewModel?.ValueUsdThen;
        public override ValueNumberDisplay? ChangeUsd => _innerViewModel?.ChangeUsd;

        //Chf
        public override decimal? ValueChfToday => _innerViewModel?.ValueChfToday;
        public override decimal? ValueChfThen => _innerViewModel?.ValueChfThen;
        public override ValueNumberDisplay? ChangeChf => _innerViewModel?.ChangeChf;

        //Eur
        public override decimal? ValueEurToday => _innerViewModel?.ValueEurToday;
        public override decimal? ValueEurThen => _innerViewModel?.ValueEurThen;
        public override ValueNumberDisplay? ChangeEur => _innerViewModel?.ChangeEur;

        //Gbp
        public override decimal? ValueGbpToday => _innerViewModel?.ValueGbpToday;
        public override decimal? ValueGbpThen => _innerViewModel?.ValueGbpThen;
        public override ValueNumberDisplay? ChangeGbp => _innerViewModel?.ChangeGbp;

        //Btc
        public override decimal? ValueBtcToday => _innerViewModel?.ValueBtcToday;
        public override decimal? ValueBtcThen => _innerViewModel?.ValueBtcThen;
        public override ValueNumberDisplay? ChangeBtc => _innerViewModel?.ChangeBtc;

        //Eth
        public override decimal? ValueEthToday => _innerViewModel?.ValueEthToday;
        public override decimal? ValueEthThen => _innerViewModel?.ValueEthThen;
        public override ValueNumberDisplay? ChangeEth => _innerViewModel?.ChangeEth;

        //Ltc
        public override decimal? ValueLtcToday => _innerViewModel?.ValueLtcToday;
        public override decimal? ValueLtcThen => _innerViewModel?.ValueLtcThen;
        public override ValueNumberDisplay? ChangeLtc => _innerViewModel?.ChangeLtc;

        public override void LoadValuesProperties(bool notifiyPropertyChanged)
        {
            _innerViewModel?.LoadValuesProperties(notifiyPropertyChanged);
        }
    }
}

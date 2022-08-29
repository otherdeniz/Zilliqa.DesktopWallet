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
        public override Image? DirectionIcon => _innerTransaction?.DirectionIcon ?? base.DirectionIcon;

        [DisplayName("Direction")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo
            ? "send to"
            : "receive from";

        [Browsable(true)]
        [DisplayName("Address")]
        public override string OtherAddress => _innerTransaction?.OtherAddress
                                      ?? (Direction == TransactionDirection.SendTo
                                          ? GetAddressDisplay(Transaction.ToAddress)
                                          : GetAddressDisplay(Transaction.SenderAddress));

        [Browsable(true)]
        [DisplayName("Amount")]
        public string AmountDisplay =>
            _innerTransaction == null ? string.Empty : $"{_innerTransaction.Amount:#,##0.0000} {_innerTransaction.Symbol}";

        [GridViewFormat("0.0000 ZIL")]
        public decimal Fee => _fee ??= (Transaction.GasPrice * Transaction.GasLimit).ZilSatoshisToZil();

        public override string Symbol => _innerTransaction?.Symbol ?? "";

        public override decimal Amount => _innerTransaction?.Amount ?? 0;
    }
}

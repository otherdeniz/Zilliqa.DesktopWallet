using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ZilTransactionRowViewModel : TransactionRowViewModelBase
    {
        private Image? _directionIcon;
        private string? _otherAddress;
        private decimal? _zilAmount;
        private decimal? _fee;
        private string? _date;

        public ZilTransactionRowViewModel(Address thisAddress, Transaction transactionModel)
            : base (transactionModel)
        {
            ThisAddress = thisAddress;
            Direction = thisAddress.Equals(transactionModel.SenderAddress)
                ? TransactionDirection.SendTo
                : TransactionDirection.ReceiveFrom;
        }

        [Browsable(false)]
        public TransactionDirection Direction { get; }

        [Browsable(false)]
        public Address ThisAddress { get; }

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
            ? GetAddressDisplay(Transaction.ToAddress)
            : GetAddressDisplay(Transaction.SenderAddress);

        [Browsable(true)]
        [GridViewFormat("#,##0.0000 ZIL")]
        public override decimal Amount => _zilAmount ??= Transaction.Amount.ZilSatoshisToZil();

        [GridViewFormat("0.0000 ZIL")]
        public decimal Fee => _fee ??= Transaction.GasPrice.ZilSatoshisToZil();

        //public decimal Fee
        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        private string GetAddressDisplay(string rawAddress)
        {
            return new Address(rawAddress).GetBech32().FromBech32ToShortReadable();
        }

    }

    public enum TransactionDirection
    {
        SendTo = 1,
        ReceiveFrom = 2
    }
}

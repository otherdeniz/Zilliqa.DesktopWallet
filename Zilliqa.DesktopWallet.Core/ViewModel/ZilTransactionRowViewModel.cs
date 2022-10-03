using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ZilTransactionRowViewModel : TransactionRowViewModelBase
    {
        private Image? _directionIcon;
        private decimal? _zilAmount;
        private string? _date;

        public ZilTransactionRowViewModel(Address thisAddress, Transaction transactionModel)
            : base (thisAddress, transactionModel)
        {
        }

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(true)]
        public override BlockNumberValue Block => base.Block;

        [Browsable(true)]
        [DisplayName(" ")]
        public override Image? DirectionIcon => _directionIcon ??= Transaction.TransactionFailed
            ? IconResources.Warning16
            : Direction == TransactionDirection.SendTo
                ? IconResources.ArrowRightGreen16
                : IconResources.ArrowLeftGreen16;

        [DisplayName(" ")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo 
            ? "to" 
            : "from";

        [Browsable(true)]
        [DisplayName("Address")]
        [ColumnWidth(150)]
        public override AddressValue? OtherAddress => base.OtherAddress;

        [Browsable(true)]
        [GridViewFormat("#,##0.0000 ZIL")]
        public override decimal Amount => _zilAmount ??= Transaction.Amount.ZilSatoshisToZil();

        [Browsable(true)]
        public override decimal Fee => base.Fee;


    }

    public enum TransactionDirection
    {
        SendTo = 1,
        ReceiveFrom = 2
    }
}

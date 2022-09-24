using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ContractCallTransactionRowViewModel : TransactionRowViewModelBase
    {
        private Image? _directionIcon;
        private string? _date;

        public ContractCallTransactionRowViewModel(Address thisAddress, Transaction transactionModel) 
            : base(thisAddress, transactionModel)
        {
        }

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(true)]
        public override BlockNumberValue Block => base.Block;

        public string? Method => Transaction.DataContractCall.Tag;

        [Browsable(true)]
        [DisplayName(" ")]
        public override Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
            ? IconResources.ArrowRightBlue16
            : IconResources.ArrowLeftBlue16;

        [DisplayName(" ")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo
            ? "to"
            : "from";

        [Browsable(true)]
        [DisplayName("Address")]
        [ColumnWidth(150)]
        public override AddressValue? OtherAddress => base.OtherAddress;

        [Browsable(true)] 
        public override decimal Fee => base.Fee;

    }
}

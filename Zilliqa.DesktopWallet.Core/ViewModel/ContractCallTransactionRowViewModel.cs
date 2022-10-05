using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ContractCallTransactionRowViewModel : TransactionRowViewModelBase
    {
        private readonly ContractCallAmountInfo? _contractCallInfo;
        private Image? _directionIcon;
        private string? _date;

        public ContractCallTransactionRowViewModel(Address thisAddress, Transaction transactionModel) 
            : base(thisAddress, transactionModel)
        {
            if (ContractCallAmountInfo.TryParse(transactionModel, out var callInfo))
            {
                _contractCallInfo = callInfo;
            }
        }

        [Browsable(false)]
        public override string Symbol => _contractCallInfo?.Symbol ?? "";

        [Browsable(false)] 
        public override decimal Amount => _contractCallInfo?.Amount ?? 0;

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(true)]
        public override BlockNumberValue Block => base.Block;

        public string? Method => Transaction.DataContractCall.Tag;

        [Browsable(true)]
        [DisplayName(" ")]
        public override Image? DirectionIcon => _directionIcon ??= Transaction.TransactionFailed
            ? IconResources.Warning16
            : Direction == TransactionDirection.SendTo
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

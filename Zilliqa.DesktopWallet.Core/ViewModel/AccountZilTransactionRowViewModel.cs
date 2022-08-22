using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountZilTransactionRowViewModel
    {
        private readonly AccountViewModel _account;
        private readonly Transaction _transactionModel;
        private Image? _directionIcon;
        private string? _otherAddress;
        private decimal? _zilAmount;
        private string? _date;

        public AccountZilTransactionRowViewModel(AccountViewModel account, Transaction transactionModel)
        {
            _account = account;
            _transactionModel = transactionModel;
            Direction = _account.Address.Equals(transactionModel.SenderAddress)
                ? TransactionDirection.SendTo
                : TransactionDirection.ReceiveFrom;
        }

        [Browsable(false)]
        public TransactionDirection Direction { get; }

        [DisplayName(" ")]
        public Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
            ? IconResources.SendArrow16
            : IconResources.ReceiveArrow16;

        [DisplayName("Direction")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo 
            ? "send to" 
            : "receive from";

        [DisplayName("Address")]
        public string OtherAddress => _otherAddress ??= Direction == TransactionDirection.SendTo
            ? GetAddressDisplay(_transactionModel.ToAddress)
            : GetAddressDisplay(_transactionModel.SenderAddress);

        [GridViewFormat("#,##0.0000")]
        public decimal Amount => _zilAmount ??= _transactionModel.GetZilAmount();

        public string Date => _date ??= _transactionModel.Timestamp.ToLocalTime().ToString("g");

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

using System.ComponentModel;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ContractCallTransactionRowViewModel : TransactionRowViewModelBase
    {
        private string? _date;

        public ContractCallTransactionRowViewModel(Address thisAddress, Transaction transactionModel) 
            : base(thisAddress, transactionModel)
        {
        }

        public string Date => _date ??= Transaction.Timestamp.ToLocalTime().ToString("g");

        [Browsable(true)]
        public override BlockNumberValue Block => base.Block;

        [Browsable(true)]
        [DisplayName("Contract Address")]
        public override AddressValue? OtherAddress => base.OtherAddress;

        [Browsable(true)] 
        public override decimal Fee => base.Fee;

    }
}

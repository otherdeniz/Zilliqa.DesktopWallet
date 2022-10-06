using System.ComponentModel;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class BlockTransactionRowViewModel : TransactionRowViewModelBase
    {
        private AddressValue? _fromAddress;
        private AddressValue? _toAddress;
        private decimal? _zilAmount;
        private decimal? _fee;

        public BlockTransactionRowViewModel(Transaction transactionModel) 
            : base(new Address(transactionModel.SenderAddress), transactionModel)
        {
        }

        [DisplayName("Type")]
        public string TransactionType
        {
            get
            {
                if (Transaction.TransactionFailed)
                {
                    return "Failed";
                }
                switch (Transaction.TransactionTypeEnum)
                {
                    case DatabaseSchema.TransactionType.ContractDeployment:
                        return "Contract Deployment";
                    case DatabaseSchema.TransactionType.ContractCall:
                        return "Contract Call";
                    case DatabaseSchema.TransactionType.Payment:
                        return "ZIL Payment";
                }
                return "?";
            }
        }

        public string? Method => Transaction.DataContractCall.Tag;

        [Browsable(true)]
        [DisplayName("From")]
        public AddressValue FromAddress => _fromAddress ??= new AddressValue(Transaction.SenderAddress);

        [Browsable(true)]
        [DisplayName("To")]
        public AddressValue ToAddress => _toAddress ??= new AddressValue(Transaction.ToAddress);

        [Browsable(true)]
        [GridViewFormat("#,##0.0000 ZIL")]
        [DisplayName("ZIL Amount")]
        public override decimal Amount => _zilAmount ??= Transaction.Amount.ZilSatoshisToZil();

        [Browsable(true)]
        [GridViewFormat("0.0000 ZIL")]
        public override decimal Fee => _fee ??= (Transaction.Receipt.CumulativeGas * Transaction.GasPrice).ZilSatoshisToZil();

    }
}

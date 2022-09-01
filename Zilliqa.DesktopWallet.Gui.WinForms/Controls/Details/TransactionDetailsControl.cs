using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class TransactionDetailsControl : DrillDownBaseControl
    {
        private TransactionRowViewModelBase _transactionViewModel;

        public TransactionDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadTransaction(TransactionRowViewModelBase transactionViewModel)
        {
            _transactionViewModel = transactionViewModel;
            labelId.Text = transactionViewModel.Transaction.Id;
            labelDate.Text = transactionViewModel.Transaction.Timestamp.ToString("g");
            labelBlockNumber.LoadValue(transactionViewModel.Block, DrillDownPanel);
        }
    }
}

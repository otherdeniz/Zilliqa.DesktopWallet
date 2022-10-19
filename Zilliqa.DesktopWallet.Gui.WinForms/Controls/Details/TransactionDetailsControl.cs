using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    // this class is not used any more
    public partial class TransactionDetailsControl : DetailsBaseControl
    {
        private TransactionRowViewModelBase _transactionViewModel;

        public TransactionDetailsControl()
        {
            InitializeComponent();
        }

        public override void LoadViewModel(object viewModel)
        {
            if (viewModel is TransactionIdValue transactionIdValue)
            {
                LoadTransaction(transactionIdValue);
            }
            else if (viewModel is Transaction transactionModel)
            {
                LoadTransaction(transactionModel);
            }
            else if (viewModel is TransactionRowViewModelBase transactionViewModel)
            {
                LoadTransaction(transactionViewModel);
            }
        }

        public void LoadTransaction(TransactionIdValue transactionId)
        {
            var transactionModel = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>()
                .FindRecord(nameof(Transaction.Id), transactionId.TransactionId);
            if (transactionModel == null)
            {
                throw new RuntimeException($"Transaction {transactionId.TransactionId} not found in DB");
            }
            LoadTransaction(new BlockTransactionRowViewModel(transactionModel));
        }

        public void LoadTransaction(Transaction transactionModel)
        {
            LoadTransaction(new BlockTransactionRowViewModel(transactionModel));
        }

        public void LoadTransaction(TransactionRowViewModelBase transactionViewModel)
        {
            _transactionViewModel = transactionViewModel;
            labelId.Text = $"0x{transactionViewModel.Transaction.Id}";
            labelDate.Text = transactionViewModel.Transaction.Timestamp.ToLocalTime().ToString("g");
            labelBlockNumber.LoadValue(transactionViewModel.Block, MasterPanel);
            propertyGridModel.SelectedObject = transactionViewModel.Transaction;
        }

        private void labelId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuId.Show(labelId, 0, labelId.Height);
        }

        private void menuIdCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_transactionViewModel.Transaction.Id);
        }

        private void menuIdBlockExplorer_Click(object sender, EventArgs e)
        {
            BlockExplorerBrowser.ShowTransaction(_transactionViewModel.Transaction.Id);
        }

        private void labelBlockNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuBlockNumber.Show(labelBlockNumber, 0, labelBlockNumber.Height);
        }

        private void menuBlockOpen_Click(object sender, EventArgs e)
        {
            MasterPanel?.DisplayValue(_transactionViewModel.Block, false);
        }

        private void menuBlockCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_transactionViewModel.Block.BlockNumber.ToString());
        }

        private void menuBlockOpenExplorer_Click(object sender, EventArgs e)
        {
            BlockExplorerBrowser.ShowBlock(_transactionViewModel.Block.BlockNumber);
        }

    }
}

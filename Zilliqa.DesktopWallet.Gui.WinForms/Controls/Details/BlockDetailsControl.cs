using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class BlockDetailsControl : DetailsBaseControl
    {
        private int _blockNumber;
        private Block? _blockModel;
        private IEnumerable<Transaction>? _transactionsEnumerable;
        private PageableDataSource<BlockTransactionRowViewModel>? _transactionsDataSource;

        public BlockDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadBlock(int blockNumber)
        {
            // apply block details
            _blockNumber = blockNumber;
            labelNumber.Text = blockNumber.ToString("#,##0");
            _blockModel = RepositoryManager.Instance.DatabaseRepository.Database
                .GetTable<Block>()
                .FindRecord(nameof(Block.BlockNumber), blockNumber, false);
            if (_blockModel == null) return;
            labelDate.Text = _blockModel.Timestamp.ToString("g");

            // apply transactions
            _transactionsEnumerable = RepositoryManager.Instance.DatabaseRepository.Database
                .GetTable<Transaction>()
                .EnumerateRecords(new FilterQueryField(nameof(Block.BlockNumber), blockNumber), resolveReferences: false);
            _transactionsDataSource = new PageableDataSource<BlockTransactionRowViewModel>();
            gridViewTransactions.LoadData(_transactionsDataSource);
            Task.Run(() =>
                _transactionsDataSource.Load(_transactionsEnumerable.Select(t => new BlockTransactionRowViewModel(t))
                    .ToList())
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

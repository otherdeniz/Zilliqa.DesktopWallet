using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle(nameof(Icon48), nameof(Title), nameof(SubTitle))]
    public class BlockViewModel : IDetailsLabel
    {
        public BlockViewModel(Block blockModel)
        {
            BlockModel = blockModel;
        }
        public BlockViewModel(int blockNumber)
        {
            BlockModel = RepositoryManager.Instance.DatabaseRepository.Database
                             .GetTable<Block>()
                             .FindRecord(nameof(Block.BlockNumber), blockNumber, false)
                         ?? throw new RuntimeException($"Block Number '{blockNumber}' not found in DB");
        }

        [Browsable(false)]
        public Block BlockModel { get; }

        [Browsable(false)]
        public Image Icon48 => IconResources.Block48;

        [Browsable(false)]
        public string Title => BlockModel.BlockNumber.ToString("#,##0");

        [Browsable(false)]
        public string SubTitle => $"{BlockModel.NumTxns:#,##0} Transactions";

        [DisplayName("Timestamp")] 
        public DateTime Timestamp => BlockModel.Timestamp;

        [DisplayName("Gas limit")]
        public string GasLimit => BlockModel.GasLimit.ToString("#,##0");

        [DisplayName("Gas used")]
        public string GasUsed => BlockModel.GasUsed.ToString("#,##0");

        [DisplayName("Rewards")]
        public string Rewards => BlockModel.Rewards.ToString("#,##0");

        [DisplayName("Transaction Fees")]
        public string TxnFees => BlockModel.TxnFees.ToString("#,##0");

        [DetailsGridView("Transactions")]
        public PageableLazyDataSource<BlockTransactionRowViewModel, Transaction> TransactionsDataSource()
        {
            var filter = new FilterQueryField(nameof(Block.BlockNumber), BlockModel.BlockNumber);
            return RepositoryManager.Instance.DatabaseRepository
                .ReadViewModelsPaged<BlockTransactionRowViewModel, Transaction>(t =>
                        new BlockTransactionRowViewModel(t),
                    filter);
        }

        public string GetUniqueId()
        {
            return $"Block-{BlockModel.BlockNumber}";
        }

        public string GetDisplayTitle()
        {
            return $"Block: {BlockModel.BlockNumber:#,##0}";
        }
    }
}

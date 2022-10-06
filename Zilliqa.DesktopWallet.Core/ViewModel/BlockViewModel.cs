using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Extensions;
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
        [DetailsProperty]
        public string Timestamp => BlockModel.Timestamp.ToString("g");

        [DisplayName("Transaction Fees")]
        [DetailsProperty]
        public string TxnFees => BlockModel.TxnFees.ZilSatoshisToZil().ToString("#,##0.0000 ZIL");

        [DisplayName("Gas limit")]
        [DetailsProperty]
        public string GasLimit => BlockModel.GasLimit.ToString("#,##0");

        [DisplayName("Gas used")]
        [DetailsProperty]
        public string GasUsed => BlockModel.GasUsed.ToString("#,##0");

        [DisplayName("Rewards")]
        [DetailsProperty]
        public string Rewards => BlockModel.Rewards.ZilSatoshisToZil().ToString("#,##0.0000 ZIL");

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

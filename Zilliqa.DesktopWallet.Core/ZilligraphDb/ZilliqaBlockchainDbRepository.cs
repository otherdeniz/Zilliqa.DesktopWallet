using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.Index;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public class ZilliqaBlockchainDbRepository
    {
        public const string ZilliqaDbFolder = "ZilliqaDB";

        public ZilliqaBlockchainDbRepository()
        {
            Database = new ZilligraphDatabase(DataPathBuilder.AppDataRoot.GetSubFolder(ZilliqaDbFolder).FullPath);
        }

        public ZilligraphDatabase Database { get; }

        public Transaction? GetLatestContractCallTransaction(AddressValue contractAddress, string method)
        {
            var filter = new FilterCombination
            {
                Method = FilterQueryCombinationMethod.And,
                Queries = new List<IFilterQuery>
                {
                    new FilterQueryField(nameof(Transaction.ToAddress), contractAddress.Address.GetBase16(false)),
                    new FilterQueryField(nameof(Transaction.ContractMethod), method)
                }
            };
            var table = Database.GetTable<Transaction>();
            var filterSearcher = FilterSearcherFactory.CreateFilterSearcher(table, filter);
            ulong? recordPoint = null;
            while (!filterSearcher.NoMoreRecords)
            {
                var nextPoint = filterSearcher.GetNextRecordPoint();
                if (nextPoint != null)
                {
                    recordPoint = nextPoint;
                }
                else
                {
                    break;
                }
            }
            if (recordPoint != null)
            {
                return table.ReadRecord(recordPoint.Value);
            }
            return null;
        }

        public PageableLazyDataSource<SmartContractViewModel, SmartContract> ReadSmartContractViewModelsPaged(
            IFilterQuery? queryFilter = null,
            bool inverseOrder = true,
            int pageSize = 1000)
        {
            return ReadViewModelsPaged<SmartContractViewModel, SmartContract>(r => new SmartContractViewModel(r),
                queryFilter, true, inverseOrder, pageSize);
        }

        public PageableLazyDataSource<TViewModel, TRecordModel> ReadViewModelsPaged<TViewModel, TRecordModel>(
            Func<TRecordModel, TViewModel> recordToViewModelMapping,
            IFilterQuery? queryFilter = null,
            bool resolveReferences = true,
            bool inverseOrder = true, 
            int pageSize = 1000,
            bool loadFirstPage = true,
            Func<TViewModel, string, bool>? searchFunction = null)
                where TViewModel : class
                where TRecordModel : class, new()
        {
            var pagedRecords = Database.GetTable<TRecordModel>()
                .FindRecordsPaged(queryFilter, resolveReferences, inverseOrder, pageSize);
            var result = new PageableLazyDataSource<TViewModel, TRecordModel>(pageSize, searchFunction);
            result.Load(pagedRecords, recordToViewModelMapping);
            if (loadFirstPage)
            {
                result.GetPage(1);
            }
            return result;
        }
    }
}

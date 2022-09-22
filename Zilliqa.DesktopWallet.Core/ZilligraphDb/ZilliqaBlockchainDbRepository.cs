using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public class ZilliqaBlockchainDbRepository
    {
        public const string ZilliqaDbFolder = "ZilliqaDB";

        public ZilliqaBlockchainDbRepository()
        {
            Database = new ZilligraphDatabase(DataPathBuilder.Root.GetSubFolder(ZilliqaDbFolder).FullPath);
        }

        public ZilligraphDatabase Database { get; }

        public PageableLazyDataSource<SmartContractRowViewModel, SmartContract> ReadSmartContractViewModelsPaged(
            IFilterQuery? queryFilter = null,
            bool inverseOrder = true,
            int pageSize = 1000)
        {
            return ReadViewModelsPaged<SmartContractRowViewModel, SmartContract>(r => new SmartContractRowViewModel(r),
                queryFilter, true, inverseOrder, pageSize);
        }

        public PageableLazyDataSource<TViewModel, TRecordModel> ReadViewModelsPaged<TViewModel, TRecordModel>(
            Func<TRecordModel, TViewModel> recordToViewModelMapping,
            IFilterQuery? queryFilter = null,
            bool resolveReferences = true,
            bool inverseOrder = true, 
            int pageSize = 1000,
            bool loadFirstPage = true)
                where TViewModel : class
                where TRecordModel : class, new()
        {
            var pagedRecords = Database.GetTable<TRecordModel>()
                .FindRecordsPaged(queryFilter, resolveReferences, inverseOrder, pageSize);
            var result = new PageableLazyDataSource<TViewModel, TRecordModel>(pageSize);
            result.Load(pagedRecords, recordToViewModelMapping);
            if (loadFirstPage)
            {
                result.GetPage(1);
            }
            return result;
        }
    }
}

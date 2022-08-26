using Zilligraph.Database.Storage;
using Zilliqa.DesktopWallet.Core.CacheDatabase;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class RepositoryManager
    {
        public static RepositoryManager Instance { get; } = new();

        private BlockchainBrowserRepository? _blockchainBrowserRepository;
        private WalletRepository? _walletRepository;
        private ZilliqaBlockchainDbRepository? _dbRepository;
        private ZilligraphDatabase? _chacheDatabase;
        private CoingeckoRepository? _currencyPriceRepository;

        private RepositoryManager()
        {
        }

        public BlockchainBrowserRepository BlockchainBrowserRepository =>
            _blockchainBrowserRepository ??= new BlockchainBrowserRepository();

        public CoingeckoRepository CoingeckoRepository =>
            _currencyPriceRepository ??= new CoingeckoRepository();

        public ZilligraphDatabase CacheDatabase =>
            _chacheDatabase ??= CacheDatabaseFactory.CreateDatabaseInstance();

        public ZilliqaBlockchainDbRepository DatabaseRepository =>
            _dbRepository ??= new ZilliqaBlockchainDbRepository();

        public WalletRepository WalletRepository => 
            _walletRepository ??= new WalletRepository();
        
        public void Shutdown()
        {
            _currencyPriceRepository?.CancelBackgroundTasks();
            _walletRepository?.CancelBackgroundTasks();
            _blockchainBrowserRepository?.Dispose();
            _dbRepository?.Database.Dispose();
        }
    }
}

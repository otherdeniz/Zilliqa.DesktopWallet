using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class RepositoryManager
    {
        public static RepositoryManager Instance { get; } = new();

        private BlockchainBrowserRepository? _blockchainBrowserRepository;
        private WalletRepository? _walletRepository;
        private ZilliqaBlockchainDbRepository? _dbRepository;

        private RepositoryManager()
        {
        }

        public BlockchainBrowserRepository BlockchainBrowserRepository =>
            _blockchainBrowserRepository ??= new BlockchainBrowserRepository();

        public WalletRepository WalletRepository => 
            _walletRepository ??= new WalletRepository();

        public ZilliqaBlockchainDbRepository DatabaseRepository => 
            _dbRepository ??= new ZilliqaBlockchainDbRepository();

        public void Shutdown()
        {
            _walletRepository?.CancelBackgroundTasks();
            _blockchainBrowserRepository?.Dispose();
            _dbRepository?.Database.Dispose();
        }
    }
}

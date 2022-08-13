using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class RepositoryManager
    {
        public static RepositoryManager Instance { get; } = new();

        private BlockchainBrowserRepository? _blockchainBrowserRepository;
        private WalletRepository? _walletRepository;
        private ZilliqaBlockchainDbRepository? _zilliqaBlockchainDbRepository;

        private RepositoryManager()
        {
        }

        public BlockchainBrowserRepository BlockchainBrowserRepository =>
            _blockchainBrowserRepository ??= new BlockchainBrowserRepository();

        public WalletRepository WalletRepository => 
            _walletRepository ??= new WalletRepository();

        public ZilliqaBlockchainDbRepository ZilliqaBlockchainDbRepository => 
            _zilliqaBlockchainDbRepository ??= new ZilliqaBlockchainDbRepository();

        public void Shutdown()
        {
            _blockchainBrowserRepository?.Dispose();
            _zilliqaBlockchainDbRepository?.Database.Dispose();
        }
    }
}

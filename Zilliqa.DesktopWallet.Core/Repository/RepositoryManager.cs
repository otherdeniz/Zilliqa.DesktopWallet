namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class RepositoryManager
    {
        public static RepositoryManager Instance { get; } = new();

        private BlockchainBrowserRepository? _blockchainBrowserRepository;
        private WalletRepository? _walletRepository;

        private RepositoryManager()
        {
        }

        public BlockchainBrowserRepository BlockchainBrowserRepository =>
            _blockchainBrowserRepository ??= new BlockchainBrowserRepository();

        public WalletRepository WalletRepository => _walletRepository ??= new WalletRepository();
    }
}

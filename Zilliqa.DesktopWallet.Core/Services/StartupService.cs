using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class StartupService
    {
        public static StartupService Instance { get; } = new();

        private StartupService()
        {
        }

        public void Startup()
        {
            RepositoryManager.Instance.CoingeckoRepository.Startup(false);
            CryptometaDownloadService.Instance.LoadOrRefresh();
            StakingService.Instance.GetStakingSeedNodeRewards();
        }

        public void Shutdown()
        {
            ZilliqaBlockchainCrawler.Instance.Stop(true);
            RepositoryManager.Instance.Shutdown();
        }
    }
}

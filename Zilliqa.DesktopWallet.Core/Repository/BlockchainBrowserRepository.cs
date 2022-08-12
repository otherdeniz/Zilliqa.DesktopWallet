using Zilliqa.DesktopWallet.ApiClient.Blockchain;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class BlockchainBrowserRepository : ZilliqaApiClientRepositoryBase
    {
        public event EventHandler<EventArgs> AfterRefresh;

        public BlockchainInfo BlockchainInfo { get; private set; }

        protected override async Task RefreshFunction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                BlockchainInfo = await ZilliqaApiClient.GetBlockchainInfo();

                AfterRefresh.Invoke(this, EventArgs.Empty);

                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}

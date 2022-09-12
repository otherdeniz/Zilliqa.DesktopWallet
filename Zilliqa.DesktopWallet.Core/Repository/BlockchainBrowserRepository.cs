using Zilliqa.DesktopWallet.ApiClient.Model;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class BlockchainBrowserRepository : ZilliqaApiClientRepositoryBase
    {
        public event EventHandler<EventArgs> AfterRefresh;

        public BlockchainInfo BlockchainInfo { get; private set; } = new();

        public long MinimumGasPrice { get; private set; }

        protected override async Task RefreshFunction(CancellationToken cancellationToken)
        {
            int refreshInterval = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    BlockchainInfo = await ZilliqaApiClient.GetBlockchainInfo();
                    if (refreshInterval % 100 == 0)
                    {
                        // every 100 iterations
                        MinimumGasPrice = await ZilliqaApiClient.GetMinimumGasPrice();
                    }
                    refreshInterval++;
                    AfterRefresh?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    // skip
                }

                try
                {
                    await Task.Delay(15000, cancellationToken); // wait 15 seconds
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }
}

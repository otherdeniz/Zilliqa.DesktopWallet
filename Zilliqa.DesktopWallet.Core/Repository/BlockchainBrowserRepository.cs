using Zilliqa.DesktopWallet.ApiClient.Model;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class BlockchainBrowserRepository : ZilliqaApiClientRepositoryBase
    {
        public event EventHandler<EventArgs> AfterRefresh;

        public BlockchainInfo BlockchainInfo { get; private set; } = new();

        protected override async Task RefreshFunction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    BlockchainInfo = await ZilliqaApiClient.GetBlockchainInfo();

                    AfterRefresh?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    // skip
                }

                try
                {
                    await Task.Delay(30000, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }
}

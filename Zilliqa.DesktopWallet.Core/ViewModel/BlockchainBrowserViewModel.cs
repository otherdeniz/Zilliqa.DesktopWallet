using Zilliqa.DesktopWallet.ApiClient.Blockchain;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class BlockchainBrowserViewModel : IDisposable
    {
        private readonly Task _refreshTask;
        private readonly CancellationTokenSource _refreshCancellationTokenSource = new CancellationTokenSource();
        private readonly ApiClient.Zilliqa _zilliqaApi;

        public BlockchainBrowserViewModel()
        {
            _zilliqaApi = new ApiClient.Zilliqa(false);
            _refreshTask = Task.Run(async () => await RefreshFunction(_refreshCancellationTokenSource.Token));
        }

        public event EventHandler<EventArgs> AfterRefresh;

        public BlockchainInfo BlockchainInfo { get; private set; }

        public void Dispose()
        {
            _refreshCancellationTokenSource.Cancel();
            //if (_refreshCancellationTokenSource != null)
            //{
            //    _refreshCancellationTokenSource.Cancel();
            //    _refreshCancellationTokenSource = null;
            //}
        }

        private async Task RefreshFunction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                BlockchainInfo = await _zilliqaApi.GetBlockchainInfo();

                AfterRefresh.Invoke(this, EventArgs.Empty);

                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}

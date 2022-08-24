using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public abstract class ZilliqaApiClientRepositoryBase : IDisposable
    {
        private readonly Task _refreshTask;
        private readonly CancellationTokenSource _refreshCancellationTokenSource = new CancellationTokenSource();
        private readonly ZilliqaClient _zilliqaApiClient;

        protected ZilliqaApiClientRepositoryBase()
        {
            _zilliqaApiClient = new ZilliqaClient();
            _refreshTask = Task.Run(async () => await RefreshFunction(_refreshCancellationTokenSource.Token));
        }

        protected ZilliqaClient ZilliqaApiClient => _zilliqaApiClient;

        public void Dispose()
        {
            _refreshCancellationTokenSource.Cancel();
            //_refreshTask.GetAwaiter().GetResult();
        }

        protected virtual async Task RefreshFunction(CancellationToken cancellationToken)
        {

        }
    }
}

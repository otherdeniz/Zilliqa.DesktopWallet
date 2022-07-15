using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ApiClientViewModelBase : IDisposable
    {
        private readonly Task _refreshTask;
        private readonly CancellationTokenSource _refreshCancellationTokenSource = new CancellationTokenSource();
        private readonly ZilliqaClient _zilliqaApiClient;

        public ApiClientViewModelBase()
        {
            _zilliqaApiClient = new ZilliqaClient(false);
            _refreshTask = Task.Run(async () => await RefreshFunction(_refreshCancellationTokenSource.Token));
        }

        protected ZilliqaClient ZilliqaApiClient => _zilliqaApiClient;

        public void Dispose()
        {
            _refreshCancellationTokenSource.Cancel();
            //if (_refreshCancellationTokenSource != null)
            //{
            //    _refreshCancellationTokenSource.Cancel();
            //    _refreshCancellationTokenSource = null;
            //}
        }

        protected virtual async Task RefreshFunction(CancellationToken cancellationToken)
        {

        }
    }
}

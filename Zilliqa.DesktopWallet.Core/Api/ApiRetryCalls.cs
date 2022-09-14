using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core.Api
{
    public static class ApiRetryCalls
    {
        public static TResult? RetryTillCompleted<TResult>(Func<TResult> apiCall, 
            int maxTryCount = 10,
            int intervallIncreaseSeconds = 1) where TResult : class
        {
            var waitSeconds = intervallIncreaseSeconds;
            var tryNumber = 1;
            while (tryNumber <= maxTryCount)
            {
                try
                {
                    return apiCall();
                }
                catch (ApiCallException e)
                {
                    // failed, we retry
                    if (tryNumber == maxTryCount)
                    {
                        throw new ApiCallException($"API-Call failed after {tryNumber} retries", e);
                    }
                }
                Task.Run(async () => await Task.Delay(waitSeconds * 1000)).GetAwaiter().GetResult();
                tryNumber++;
                waitSeconds += intervallIncreaseSeconds;
            }

            return null;
        }

        public static TResult? RetryTaskTillCompleted<TResult>(Func<Task<TResult>> apiCallTask,
            int maxTryCount = 10,
            int intervallIncreaseSeconds = 1) where TResult : class
        {
            var waitSeconds = intervallIncreaseSeconds;
            var tryNumber = 1;
            while (tryNumber <= maxTryCount)
            {
                try
                {
                    return Task.Run(async () => await apiCallTask()).GetAwaiter().GetResult();
                }
                catch (ApiCallException e)
                {
                    // failed, we retry
                    if (tryNumber == maxTryCount)
                    {
                        throw new ApiCallException($"API-Call failed after {tryNumber} retries", e);
                    }
                }
                Task.Run(async () => await Task.Delay(waitSeconds * 1000)).GetAwaiter().GetResult();
                tryNumber++;
                waitSeconds += intervallIncreaseSeconds;
            }

            return null;
        }
    }
}

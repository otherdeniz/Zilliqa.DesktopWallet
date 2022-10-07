using System;

namespace Zilliqa.DesktopWallet.ApiClient
{
    public class ZilliqaClientException : Exception
    {
        public ZilliqaClientException(string message) : base(message)
        {
        }
    }

    public class ZilliqaClientTestnetNoData : Exception
    {
    }
}

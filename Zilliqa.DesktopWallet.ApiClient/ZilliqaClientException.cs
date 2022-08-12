using System;
using System.Collections.Generic;
using System.Text;

namespace Zilliqa.DesktopWallet.ApiClient
{
    public class ZilliqaClientException : Exception
    {
        public ZilliqaClientException(string message) : base(message)
        {
            
        }
    }
}

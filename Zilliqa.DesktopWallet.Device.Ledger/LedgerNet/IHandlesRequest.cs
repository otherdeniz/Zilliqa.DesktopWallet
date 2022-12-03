using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public interface IHandlesRequest
    {
        Task<TResponse> SendRequestAsync<TResponse, TRequest>(TRequest request)
            where TResponse : ResponseBase
            where TRequest : RequestBase;
    }
}
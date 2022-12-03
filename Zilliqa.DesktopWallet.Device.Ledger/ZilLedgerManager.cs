using System.Text;
using Hardwarewallets.Net;
using Hardwarewallets.Net.Model;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Exceptions;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;
using ICoinUtility = Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.ICoinUtility;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilLedgerManager : IAddressDeriver, IManagesLedger
    {
        private bool _IsDisposed;
        
        public ZilLedgerManager(IHandlesRequest ledgerManagerTransport) : this(ledgerManagerTransport, null, null)
        {
        }

        public ZilLedgerManager(IHandlesRequest ledgerManagerTransport, ICoinUtility? coinUtility, ErrorPromptDelegate? errorPrompt)
        {
            ErrorPrompt = errorPrompt;
            RequestHandler = ledgerManagerTransport;
            CoinUtility = coinUtility ?? new ZilliqaCoinUtility();
        }

        public ErrorPromptDelegate? ErrorPrompt { get; set; }

        public IHandlesRequest RequestHandler { get; }

        public ICoinUtility CoinUtility { get; }

        public ICoinInfo CurrentCoin { get; } = new CoinInfo(App.Bitcoin, "ZIL", "Zilliqa", 313U, false);

        public Task SetCoinNumber()
        {
            return Task.CompletedTask;
        }

        public void SetCoinNumber(uint coinNumber)
        {
        }

        public Task<ResponseBase> CallAndPrompt<T, T2>(Func<CallAndPromptArgs<T2>, Task<T>> func, CallAndPromptArgs<T2> state) where T : ResponseBase
        {
            throw new NotSupportedException();
        }

        private void CheckForDisposed()
        {
            if (_IsDisposed) throw new ObjectDisposedException($"The {nameof(ZilLedgerManager)} is Disposed. It can not longer function.", nameof(ZilLedgerManager));
        }

        public async Task<string> GetTransactionSignatureAsync(uint index, bool showDisplay, byte[] transactionMessage)
        {
            CheckForDisposed();

            var indexData = BitConverter.GetBytes(index);
            var signatureRequest = new ZilliqaAppSignatureRequest(indexData.Concat(transactionMessage).ToArray());

            var response = await RequestHandler.SendRequestAsync<ZilliqaAppSignatureResponse, ZilliqaAppSignatureRequest>(signatureRequest);
            if (!response.IsSuccess)
            {
                throw new LedgerAppException($"Ledger error: {response.StatusMessage}");
            }
            return HexDataToString(response.Data);
        }

        public async Task<ZilliqaAppGetAddressResponse> GetAddressAsync(uint index, bool showDisplay)
        {
            CheckForDisposed();
            var data = BitConverter.GetBytes(index);
            var response = await RequestHandler.SendRequestAsync<ZilliqaAppGetAddressResponse, ZilliqaAppGetAddressRequest>(new ZilliqaAppGetAddressRequest(showDisplay, data, false));
            if (!response.AddressBech32.StartsWith("zil1"))
            {
                throw new LedgerAppException("Could not read ZIL address. Ensure Zilliqa app is open.");
            }
            return response;
        }

        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool showDisplay)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            if (_IsDisposed) return;
            _IsDisposed = true;


            GC.SuppressFinalize(this);
        }

        ~ZilLedgerManager()
        {
            Dispose();
        }

        private static string HexDataToString(byte[] data)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
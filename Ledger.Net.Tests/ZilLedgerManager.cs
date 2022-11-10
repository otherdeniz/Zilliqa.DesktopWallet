using System;
using System.Threading.Tasks;
using Hardwarewallets.Net;
using Hardwarewallets.Net.AddressManagement;
using Hardwarewallets.Net.Model;
using Ledger.Net.Exceptions;
using Ledger.Net.Requests;
using Ledger.Net.Responses;

namespace Ledger.Net
{
    public class ZilLedgerManager : IAddressDeriver, IDisposable, IManagesLedger
    {
        private bool _IsDisposed;


        private readonly Func<ZilCallAndPromptArgs<GetAddressArgs>, Task<GetPublicKeyResponseBase>> _GetAddressFunc = async s =>
        {
            var lm = s.LedgerManager;

            var data = Helpers.GetDerivationPathData(s.Args.AddressPath);

            var response = await lm.RequestHandler.SendRequestAsync<ZilliqaAppGetPublicKeyResponse, ZilliqaAppGetPublicKeyRequest>(new ZilliqaAppGetPublicKeyRequest(s.Args.ShowDisplay, data));

            //switch (lm.CurrentCoin.App)
            //{
            //    case App.Ethereum:
            //        response = await lm.RequestHandler.SendRequestAsync<EthereumAppGetPublicKeyResponse, EthereumAppGetPublicKeyRequest>(new EthereumAppGetPublicKeyRequest(s.Args.ShowDisplay, false, data));
            //        break;
            //    case App.BitcoinGold:
            //    case App.Bitcoin:
            //        //TODO: Should we use the Coin's IsSegwit here?
            //        response = await lm.RequestHandler.SendRequestAsync<BitcoinAppGetPublicKeyResponse, BitcoinAppGetPublicKeyRequest>(new BitcoinAppGetPublicKeyRequest(s.Args.ShowDisplay, BitcoinAddressType.Segwit, data));
            //        break;
            //    case App.Tron:
            //        response = await lm.RequestHandler.SendRequestAsync<TronAppGetPublicKeyResponse, TronAppGetPublicKeyRequest>(new TronAppGetPublicKeyRequest(s.Args.ShowDisplay, data));
            //        break;
            //    default:
            //        throw new NotImplementedException();
            //}

            return response;
        };

        public ErrorPromptDelegate ErrorPrompt { get; set; }
        public int PromptRetryCount { get; set; } = 6;
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

        //public ICoinInfo CurrentCoin { get; private set; }

        public ZilLedgerManager(IHandlesRequest ledgerManagerTransport) : this(ledgerManagerTransport, null, null)
        {
        }

        public ZilLedgerManager(IHandlesRequest ledgerManagerTransport, ICoinUtility coinUtility, ErrorPromptDelegate errorPrompt)
        {
            ErrorPrompt = errorPrompt;
            RequestHandler = ledgerManagerTransport;
            CoinUtility = coinUtility ?? new ZilliqaCoinUtility();
        }

        private void CheckForDisposed()
        {
            if (_IsDisposed) throw new ObjectDisposedException($"The {nameof(ZilLedgerManager)} is Disposed. It can not longer function.", nameof(ZilLedgerManager));
        }

        public async Task<string> GetAddressAsync(uint account, uint index)
        {
            return await GetAddressAsync(account, false, index, false);
        }

        public Task<string> GetAddressAsync(uint account, bool isChange, uint index, bool showDisplay)
        {
            return GetAddressAsync(new BIP44AddressPath(false, 313U, account, isChange, index), false, showDisplay);
        }

        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display)
        {
            CheckForDisposed();

            var returnResponse = (GetPublicKeyResponseBase)await ZilCallAndPrompt(_GetAddressFunc,
                new ZilCallAndPromptArgs<GetAddressArgs>
                {
                    LedgerManager = this,
                    MemberName = nameof(GetAddressAsync),
                    Args = new GetAddressArgs(addressPath, display)
                });

            return isPublicKey ? returnResponse.PublicKey : returnResponse.Address;
        }

        public async Task<ResponseBase> ZilCallAndPrompt<T, T2>(Func<ZilCallAndPromptArgs<T2>, Task<T>> func, ZilCallAndPromptArgs<T2> state) where T : ResponseBase
        {
            for (var i = 0; i < PromptRetryCount; i++)
            {
                CheckForDisposed();

                try
                {
                    var response = await func.Invoke(state);

                    //Use this to get the response as an array of bytes
                    //var data = string.Join(", ", response.Data.Select(b => b.ToString()));

                    if (response.IsSuccess)
                    {
                        return response;
                    }

                    if (ErrorPrompt == null)
                    {
                        Helpers.HandleErrorResponse(response);
                    }
                    else
                    {
                        await ErrorPrompt(response.ReturnCode, null, state.MemberName);
                    }
                }
                catch (Exception ex)
                {
                    if (ErrorPrompt == null)
                    {
                        throw;
                    }

                    await ErrorPrompt(null, ex, state.MemberName);
                }
            }

            throw new TooManyPromptsException(PromptRetryCount, state.MemberName);
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

        public class ZilCallAndPromptArgs<T>
        {
            public string MemberName { get; set; }
            public T Args { get; set; }
            public ZilLedgerManager LedgerManager { get; set; }
        }

    }
}
using Device.Net;
using Hid.Net.Windows;
using Usb.Net.Windows;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Device.Ledger;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Exceptions;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class LedgerWalletService : IDisposable
    {
        private readonly LedgerManagerBroker _ledgerManagerBroker;

        static LedgerWalletService()
        {
            WindowsHidDeviceFactory.Register(new DummyLogger(), new DebugTracer());
            WindowsUsbDeviceFactory.Register(new DummyLogger(), new DebugTracer());
        }

        public LedgerWalletService()
        {
            _ledgerManagerBroker = new LedgerManagerBroker(3000, null, null, new ZilliqaLedgerManagerFactory());
            _ledgerManagerBroker.Start();
        }

        public async Task<ZilliqaAppGetAddressResponse> ReadAddressBech32Async(int keyIndex)
        {
            return await GetLedgerManager().GetAddressAsync(Convert.ToUInt32(keyIndex), true);
        }

        public async Task<bool> SignTransactionAsync(int keyIndex, TransactionPayload transaction)
        {
            var signature = await GetLedgerManager().GetTransactionSignatureAsync(Convert.ToUInt32(keyIndex), true, transaction.Encode());
            if (string.IsNullOrEmpty(signature))
            {
                return false;
            }
            transaction.Signature = signature;
            return true;
        }

        public void Dispose()
        {
            _ledgerManagerBroker.Dispose();
        }

        private ZilLedgerManager GetLedgerManager()
        {
            var i = 0;

            while (_ledgerManagerBroker.LedgerManagers.Count == 0)
            {
                Thread.Sleep(100);
                i++;
                if (i > 100) throw new LedgerAppException("Could not connect to Ledger device");
            }

            return (ZilLedgerManager)_ledgerManagerBroker.LedgerManagers.First();
        }

        private class DummyLogger : ILogger
        {
            public void Log(string message, string region, Exception ex, LogLevel logLevel)
            {
            }
        }
    }
}

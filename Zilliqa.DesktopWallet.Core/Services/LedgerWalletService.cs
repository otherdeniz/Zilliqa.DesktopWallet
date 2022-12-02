using Device.Net;
using Hid.Net.Windows;
using Ledger.Net;
using Usb.Net.Windows;
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

        public async Task<string> ReadAddressBech32Async()
        {
            return await GetLedgerManager().GetAddressAsync(1, true);
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

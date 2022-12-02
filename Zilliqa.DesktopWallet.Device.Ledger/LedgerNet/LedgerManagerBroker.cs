using Device.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ledger.Net
{
    public class LedgerManagerBroker : IDisposable
    {
        protected List<FilterDeviceDefinition> DeviceDefinitions { get; } = new List<FilterDeviceDefinition>
        {
            new FilterDeviceDefinition{ DeviceType= DeviceType.Hid, VendorId= 0x2c97, UsagePage=0xffa0 },
            new FilterDeviceDefinition{ DeviceType= DeviceType.Hid, VendorId= 0x2581, ProductId=0x3b7c, UsagePage=0xffa0 },
            //Android only
            new FilterDeviceDefinition{ DeviceType= DeviceType.Usb, VendorId= 0x2c97, UsagePage=0xffa0 },
            new FilterDeviceDefinition{ DeviceType= DeviceType.Usb, VendorId= 0x2581, ProductId=0x3b7c, UsagePage=0xffa0 },
            //Ledger Nano X
            new FilterDeviceDefinition{ DeviceType= DeviceType.Hid, VendorId= 0x2c97, ProductId=0x0004, Label="Ledger Nano X"  }
        };

        private DeviceListener _deviceListener;
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private TaskCompletionSource<IManagesLedger> _firstLedgerTaskCompletionSource = new TaskCompletionSource<IManagesLedger>();
        private bool _disposed;

        /// <summary>
        /// Occurs after the LedgerManagerBroker notices that a device hasbeen connected, and initialized
        /// </summary>
        public event EventHandler<LedgerManagerConnectionEventArgs> LedgerInitialized;

        /// <summary>
        /// Occurs after the LedgerManagerBroker notices that the device has been disconnected, but before the LedgerManager is disposed
        /// </summary>
        public event EventHandler<LedgerManagerConnectionEventArgs> LedgerDisconnected;

        public ReadOnlyCollection<IManagesLedger> LedgerManagers { get; private set; } = new ReadOnlyCollection<IManagesLedger>(new List<IManagesLedger>());
        public ICoinUtility CoinUtility { get; }
        public int? PollInterval { get; }
        public ErrorPromptDelegate ErrorPromptDelegate { get; }
        public ILedgerManagerFactory LedgerManagerFactory { get; }

        public LedgerManagerBroker(int? pollInterval, ICoinUtility coinUtility, ErrorPromptDelegate errorPromptDelegate, ILedgerManagerFactory ledgerManagerFactory)
        {
            CoinUtility = coinUtility;
            PollInterval = pollInterval;
            ErrorPromptDelegate = errorPromptDelegate;
            LedgerManagerFactory = ledgerManagerFactory;
        }

        private async void DevicePoller_DeviceInitialized(object sender, DeviceEventArgs e)
        {
            try
            {
                await _lock.WaitAsync();

                var ledgerManager = LedgerManagers.FirstOrDefault(t =>
                {
                    var ledgerManagerTransport = t.RequestHandler as LedgerManagerTransport;
                    return ReferenceEquals(ledgerManagerTransport?.LedgerHidDevice, e.Device);
                });

                if (ledgerManager == null)
                {
                    ledgerManager = LedgerManagerFactory.GetNewLedgerManager(e.Device, CoinUtility, ErrorPromptDelegate);

                    var tempList = new List<IManagesLedger>(LedgerManagers)
                    {
                        ledgerManager
                    };

                    LedgerManagers = new ReadOnlyCollection<IManagesLedger>(tempList);

                    if (_firstLedgerTaskCompletionSource.Task.Status == TaskStatus.WaitingForActivation) _firstLedgerTaskCompletionSource.SetResult(ledgerManager);

                    LedgerInitialized?.Invoke(this, new LedgerManagerConnectionEventArgs(ledgerManager));
                }
            }
            finally
            {
                _lock.Release();
            }
        }

        private async void DevicePoller_DeviceDisconnected(object sender, DeviceEventArgs e)
        {
            try
            {
                await _lock.WaitAsync();

                var ledgerManager = LedgerManagers.FirstOrDefault(t =>
                {
                    var ledgerManagerTransport = t.RequestHandler as LedgerManagerTransport;
                    return ReferenceEquals(ledgerManagerTransport?.LedgerHidDevice, e.Device);
                });

                if (ledgerManager != null)
                {
                    LedgerDisconnected?.Invoke(this, new LedgerManagerConnectionEventArgs(ledgerManager));

                    ledgerManager.Dispose();

                    var tempList = new List<IManagesLedger>(LedgerManagers);

                    tempList.Remove(ledgerManager);

                    LedgerManagers = new ReadOnlyCollection<IManagesLedger>(tempList);
                }
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Starts the device listener that manages the connection and disconnection of devices
        /// </summary>
        public void Start()
        {
            Start(false);
        }

        /// <summary>
        /// Starts the device listener that manages the connection and disconnection of devices
        /// </summary>
        public void Start(bool restart)
        {
            if (restart && _deviceListener != null)
            {
                LedgerManagers = new ReadOnlyCollection<IManagesLedger>(new List<IManagesLedger>());
                _deviceListener.DeviceDisconnected -= DevicePoller_DeviceDisconnected;
                _deviceListener.DeviceInitialized -= DevicePoller_DeviceInitialized;
                _deviceListener.Dispose();
                _deviceListener = null;
            }

            if (_deviceListener == null)
            {
                _deviceListener = new DeviceListener(DeviceDefinitions, PollInterval)
                {
                    Logger = new DebugLogger()
                };

                _deviceListener.DeviceDisconnected += DevicePoller_DeviceDisconnected;
                _deviceListener.DeviceInitialized += DevicePoller_DeviceInitialized;
                _deviceListener.Start();
            }
        }

        public void Stop()
        {
            _deviceListener?.Stop();
        }

        /// <summary>
        /// Check to see if there are any devices connected
        /// </summary>
        public async Task CheckForDevicesAsync()
        {
            try
            {
                await _deviceListener.CheckForDevicesAsync();
            }
            catch
            {
                // skip
            }
        }

        /// <summary>
        /// Starts the device listener and waits for the first connected Ledger to be initialized
        /// </summary>
        /// <returns></returns>
        public async Task<IManagesLedger> WaitForFirstDeviceAsync()
        {
            if (_deviceListener == null) Start();
            await _deviceListener.CheckForDevicesAsync();
            return await _firstLedgerTaskCompletionSource.Task;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            _lock.Dispose();
            _deviceListener?.Stop();
            _deviceListener?.Dispose();

            foreach (var ledgerManager in LedgerManagers)
            {
                ledgerManager.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        ~LedgerManagerBroker()
        {
            Dispose();
        }
    }
}




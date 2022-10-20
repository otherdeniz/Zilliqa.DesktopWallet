using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class KnownAddressService
    {
        public static readonly KnownAddressService Instance = new();

        private readonly object _initializationLock = new();
        private Task? _initializationTask;
        private bool _isInitialized;

        private KnownAddressService()
        {
        }

        public Dictionary<string, KnownAddressViewModel> Bech32AddressNames { get; } = new();

        public KnownAddressViewModel? GetName(string? addressBech32)
        {
            if (addressBech32 != null 
                && Bech32AddressNames.TryGetValue(addressBech32, out var addressName))
            {
                return addressName;
            }
            return null;
        }
        public void EnsureInitialized(bool wait = false)
        {
            if (_isInitialized) return;
            if (!wait && _initializationTask != null) return;
            _initializationTask = Task.Run(() =>
            {
                lock (_initializationLock)
                {
                    if (_isInitialized) return;
                    var startTime = DateTime.Now;
                    var dbTable = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>();
                    dbTable.EnumerateAllRecords().ForEach(AddSmartContract);
                    dbTable.AddEventNotificator(_ => true, AddSmartContract);
                    Logging.LogInfo($"Initializing Known Address names: adding all Smart Contracts took {(DateTime.Now - startTime).TotalSeconds:0} seconds");
                    _isInitialized = true;
                }
            });
            try
            {
                if (wait && !_initializationTask.IsCompleted)
                {
                    _initializationTask.GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                // Task is canceled or failed
            }
        }

        public void AddUnique(string bech32, string category, string name)
        {
            if (!Bech32AddressNames.ContainsKey(bech32))
            {
                Bech32AddressNames.Add(bech32, new KnownAddressViewModel
                {
                    Address = bech32,
                    Category = category,
                    Name = name
                });
            }
        }

        private void AddSmartContract(SmartContract smartContract)
        {
            if (smartContract.ContractAddress != null)
            {
                AddUnique(smartContract.ContractAddress.FromBase16ToBech32Address(),
                    "Smart Contract",
                    smartContract.DisplayName());
            }
        }

    }
}

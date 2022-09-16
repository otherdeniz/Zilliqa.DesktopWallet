using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class KnownAddressService
    {
        public static readonly KnownAddressService Instance = new();

        private readonly object _initialisationLock = new();
        private Task? _initialisationTask;
        private bool _isInitialised;

        private KnownAddressService()
        {
        }

        public Dictionary<string, string> Bech32AddressNames { get; } = new();

        public string? GetName(string? addressBech32)
        {
            if (addressBech32 != null 
                && Bech32AddressNames.TryGetValue(addressBech32, out var addressName))
            {
                return addressName;
            }
            return null;
        }
        public void EnsureInitialised(bool wait = false)
        {
            if (_isInitialised) return;
            if (!wait && _initialisationTask != null) return;
            _initialisationTask = Task.Run(() =>
            {
                lock (_initialisationLock)
                {
                    if (_isInitialised) return;
                    var dbTable = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>();
                    dbTable.AllRecords().ForEach(AddSmartContract);
                    dbTable.AddEventNotificator(_ => true, AddSmartContract);
                    _isInitialised = true;
                }
            });
            try
            {
                if (wait && !_initialisationTask.IsCompleted)
                {
                    _initialisationTask.GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {
                // Task is canceled or failed
            }
        }

        public void AddUnique(string bech32, string name)
        {
            if (!Bech32AddressNames.ContainsKey(bech32))
            {
                Bech32AddressNames.Add(bech32, name);
            }
        }

        private void AddSmartContract(SmartContract smartContract)
        {
            if (smartContract.ContractAddress != null)
            {
                AddUnique(smartContract.ContractAddress.FromBase16ToBech32Address(),
                    smartContract.ContractTitle());
            }
        }

    }
}

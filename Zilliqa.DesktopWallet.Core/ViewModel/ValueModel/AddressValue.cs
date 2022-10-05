using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class AddressValue
    {
        public static bool TryParse(string value, out AddressValue? result)
        {
            try
            {
                if (MusBech32.IsValidZilAddress(value))
                {
                    result = new AddressValue(value);
                    return true;
                }
            }
            catch (Exception)
            {
                // failed parsing
            }

            result = null;
            return false;
        }

        public static AddressValue? Create(string? address)
        {
            if (address == null)
            {
                return null;
            }
            return new AddressValue(address);
        }
        public static AddressValue? Create(Address? address)
        {
            if (address == null)
            {
                return null;
            }
            return new AddressValue(address);
        }

        private (bool, SmartContract?)? _smartContract;

        public AddressValue(string address)
        {
            Address = new Address(address);
        }
        public AddressValue(Address address)
        {
            Address = address;
        }

        public Address Address { get; }

        public SmartContract? SmartContract
        {
            get
            {
                if (_smartContract == null)
                {
                    var smartContract = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<SmartContract>()
                        .FindRecord(nameof(SmartContract.ContractAddress), Address.GetBase16(false));
                    _smartContract = (true, smartContract);
                }
                return _smartContract.Value.Item2;
            }
        }
        public string GetAddressHexWithCheckSum()
        {
            return Account.ToCheckSumAddress(Address.GetBase16(false));
        }

        public override string ToString()
        {
            if (KnownAddressService.Instance.Bech32AddressNames.TryGetValue(Address.GetBech32(), out var addressName))
            {
                if (addressName.Length > 20)
                {
                    addressName = addressName.Substring(0, 20);
                }
                return $"{addressName} ({Address})";
            }
            return Address.ToString();
        }
    }
}

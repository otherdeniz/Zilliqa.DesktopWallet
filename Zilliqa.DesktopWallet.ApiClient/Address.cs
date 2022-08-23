using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient
{
    public class Address
    {
        public enum AddressEncoding
        {
            Bech32,
            Base16,
            Base16WithLeading0x
        }

        public static bool Equals(string address1, string address2)
        {
            if (string.IsNullOrEmpty(address1))
            {
                return false;
            }
            return new Address(address1).Equals(address2);
        }

        private string _rawAddress;

        public Address()
        {
        }
        public Address(string rawAddress)
        {
            _rawAddress = rawAddress;
            ParseRawAddress(rawAddress);
        }

        [JsonIgnore]
        public string Bech32 { get; private set; }

        [JsonIgnore]
        public string Base16WithLeading0x { get; private set; }

        [JsonProperty("Raw")]
        public string RawAddress
        {
            get => _rawAddress;
            set
            {
                _rawAddress = value;
                ParseRawAddress(value);
            }
        }

        [JsonIgnore]
        public AddressEncoding RawEncoding { get; private set; }

        public override string ToString()
        {
            return _rawAddress;
        }

        public string GetBech32()
        {
            if (Bech32 == null)
            {
                Bech32 = MusBech32.FromBase16ToBech32Address(Base16WithLeading0x);
            }
            return Bech32;
        }

        public string GetBase16(bool withLeading0x)
        {
            if (Base16WithLeading0x == null)
            {
                Base16WithLeading0x = MusBech32.FromBech32ToBase16Address(Bech32);
            }

            return withLeading0x ? Base16WithLeading0x : Base16WithLeading0x.Substring(2);
        }

        public bool Equals(string otherAddress)
        {
            if (string.IsNullOrEmpty(otherAddress))
            {
                return false;
            }
            return Equals(new Address(otherAddress));
        }

        public bool Equals(Address otherAddress)
        {
            return GetBase16(true) == otherAddress.GetBase16(true);
        }

        private void ParseRawAddress(string rawAddress)
        {
            if (rawAddress.StartsWith("zil"))
            {
                RawEncoding = AddressEncoding.Bech32;
                Bech32 = rawAddress;
            }
            else if (rawAddress.StartsWith("0x"))
            {
                RawEncoding = AddressEncoding.Base16WithLeading0x;
                Base16WithLeading0x = rawAddress;
            }
            else
            {
                RawEncoding = AddressEncoding.Base16;
                Base16WithLeading0x = $"0x{rawAddress}";
            }
        }
    }
}

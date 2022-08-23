using System;

namespace Zilliqa.DesktopWallet.ApiClient
{
    public class Bech32
    {
        private readonly string _address;

        public Bech32(string address, byte[] data, string hrp)
        {
            if (!address.StartsWith(hrp))
                throw new ArgumentException($"HRP is not {hrp}");

            _address = address;
            Hrp = hrp;
            Data = data;
        }

        public string Hrp { get; }

        public byte[] Data { get; }

        public override string ToString()
        {
            return _address;
        }
    }
}

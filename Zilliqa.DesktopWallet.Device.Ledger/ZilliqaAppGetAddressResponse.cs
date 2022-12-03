using System.Text;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppGetAddressResponse : ResponseBase
    {
        const int Bech32AddrLen = 4 + 32 + 6;
        const int PubKeyByteLen = 33;

        public ZilliqaAppGetAddressResponse(byte[] data) : base(data)
        {
            ReadData(data);
        }

        public string AddressBech32 { get; private set; }

        public string PublicKey { get; private set; }

        private void ReadData(byte[] data)
        {
            using (var memoryStream = new MemoryStream(Data))
            {
                var publicKeyData = memoryStream.ReadAllBytes(PubKeyByteLen);
                var sb = new StringBuilder();
                foreach (var @byte in publicKeyData)
                {
                    sb.Append(@byte.ToString("X2").ToUpperInvariant());
                }
                PublicKey = sb.ToString();

                var addressData = memoryStream.ReadAllBytes(Bech32AddrLen);
                AddressBech32 = Encoding.ASCII.GetString(addressData).ToLower();
            }
        }

    }
}
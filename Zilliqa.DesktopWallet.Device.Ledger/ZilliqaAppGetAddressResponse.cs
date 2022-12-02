using System.Text;

namespace Ledger.Net.Responses
{
    public class ZilliqaAppGetAddressResponse : ResponseBase
    {
        const int Bech32AddrLen = 4 + 32 + 6;
        const int PubKeyByteLen = 33;

        public ZilliqaAppGetAddressResponse(byte[] data) : base(data)
        {

        }

        public string ReadAddressBech32()
        {
            using (var memoryStream = new MemoryStream(Data))
            {
                memoryStream.Seek(PubKeyByteLen, SeekOrigin.Begin);
                var addressData = memoryStream.ReadAllBytes(Bech32AddrLen);
                return Encoding.ASCII.GetString(addressData).ToLower();
            }
        }

        public string ReadPublicKey()
        {
            using (var memoryStream = new MemoryStream(Data))
            {
                var publicKeyData = memoryStream.ReadAllBytes(PubKeyByteLen);
                var sb = new StringBuilder();
                foreach (var @byte in publicKeyData)
                {
                    sb.Append(@byte.ToString("X").ToLower());
                }

                return $"0x{sb}";
            }
        }

    }
}
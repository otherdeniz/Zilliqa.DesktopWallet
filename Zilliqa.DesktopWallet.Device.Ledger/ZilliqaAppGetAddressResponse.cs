using System.IO;
using System.Text;

namespace Ledger.Net.Responses
{
    public class ZilliqaAppGetAddressResponse : ResponseBase
    {
        public ZilliqaAppGetAddressResponse(byte[] data) : base(data)
        {

        }

        public string ReadAddress()
        {
            using (var memoryStream = new MemoryStream(Data))
            {
                var addressLength = memoryStream.ReadByte();
                var addressData = memoryStream.ReadAllBytes(addressLength);
                return "0x" + Encoding.ASCII.GetString(addressData).ToLower();
            }
        }

        public string ReadPublicKey()
        {
            using (var memoryStream = new MemoryStream(Data))
            {
                var publicKeyLength = memoryStream.ReadByte();
                var publicKeyData = memoryStream.ReadAllBytes(publicKeyLength);
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
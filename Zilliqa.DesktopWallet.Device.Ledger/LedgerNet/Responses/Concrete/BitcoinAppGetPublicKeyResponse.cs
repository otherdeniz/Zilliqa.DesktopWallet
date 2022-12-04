using System.Text;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Concrete
{
    public class BitcoinAppGetPublicKeyResponse : GetPublicKeyResponseBase
    {
        public BitcoinAppGetPublicKeyResponse(byte[] data) : base(data)
        {
        }

        protected override string GetAddressString(byte[] addressData)
        {
            return Encoding.ASCII.GetString(addressData);
        }

        protected override string GetPublicKeyString(byte[] publicKeyData)
        {
            if (publicKeyData == null) throw new ArgumentNullException(nameof(publicKeyData));

            var sb = new StringBuilder();
            foreach (var @byte in publicKeyData)
            {
                sb.Append(@byte.ToString("X2").ToLower());
            }

            return sb.ToString();
        }
    }
}

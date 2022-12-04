using System.Text;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppSignatureResponse : ResponseBase
    {
        const int SigByteLen = 64;

        public ZilliqaAppSignatureResponse(byte[] data) : base(data)
        {
            ReadData(data);
        }

        public string Signature { get; private set; }

        private void ReadData(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                var publicKeyData = memoryStream.ReadAllBytes(SigByteLen);
                var sb = new StringBuilder();
                foreach (var @byte in publicKeyData)
                {
                    sb.Append(@byte.ToString("X2").ToUpperInvariant());
                }
                Signature = sb.ToString();
            }
        }

    }
}
using System.Linq;
using System.Text;

namespace Ledger.Net.Responses
{
    public class ZilliqaAppGetPublicKeyResponse : ResponseBase
    {
        private string _addressBech32;

        public ZilliqaAppGetPublicKeyResponse(byte[] data) : base(data)
        {
            _addressBech32 = Encoding.ASCII.GetString(data.Skip(data.Length - 44).Take(42).ToArray());
        }

        public string AddressBech32 => _addressBech32;
    }
}
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;

namespace Zilliqa.DesktopWallet.ApiClient.Crypto
{
    public class KDFParams
    {
        public KDFParams()
        {
        }

        [JsonProperty("salt")]
        public virtual string Salt { get; set; }
        public int n { get; set; } = 8192;
        public int c { get; set; } = 262144;
        public int r { get; set; } = 8;
        public int p { get; set; } = 1;
        public int dklen { get; set; } = 32;

    }

    public class PBKDF2Params : KDFParams
    {
        public override string Salt { get; set; }
        public int DkLen { get; set; }
        public int Count { get; set; }

        public byte[] GetDerivedKey(string password)
        {
            var pdb = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(Salt));
            return pdb.GetBytes(DkLen * 8);
            //Pkcs5S2ParametersGenerator generator = new Pkcs5S2ParametersGenerator(new Sha256Digest());
            //generator.Init(password, Encoding.UTF8.GetBytes(Salt), Count);
            //return ((KeyParameter)generator.GenerateDerivedParameters("pbkdf2", DkLen * 8)).GetKey();
        }
    }


}

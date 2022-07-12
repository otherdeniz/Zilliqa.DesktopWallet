using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zilliqa.DesktopWallet.Core.Data
{
    public class ZilWallet
    {
        public string PublicKey { get; set; }

        public string PrivateKeyEncrypted { get; set; }

        public decimal Balance { get; set; }

        public List<object> Transactions { get; set; }
    }
}

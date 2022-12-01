using System;
using System.Linq;
using Hardwarewallets.Net.AddressManagement;
using Hardwarewallets.Net.Model;

namespace Ledger.Net.Tests
{
    public class ZilliqaBIP32AddressPath : AddressPathBase, IBIP44AddressPath, IAddressPath
    {
        public ZilliqaBIP32AddressPath()
        {
        }

        public ZilliqaBIP32AddressPath(
            bool isSegwit,
            uint coinType,
            uint account,
            bool isChange,
            uint addressIndex)
        {
            this.AddressPathElements.Add((IAddressPathElement)new AddressPathElement()
            {
                Value = 44U,
                Harden = true
            });
            this.AddressPathElements.Add((IAddressPathElement)new AddressPathElement()
            {
                Value = coinType,
                Harden = true
            });
            this.AddressPathElements.Add((IAddressPathElement)new AddressPathElement()
            {
                Value = account,
                Harden = true
            });
            this.AddressPathElements.Add((IAddressPathElement)new AddressPathElement()
            {
                Value = (isChange ? 1U : 0U),
                Harden = true
            });
            this.AddressPathElements.Add((IAddressPathElement)new AddressPathElement()
            {
                Value = addressIndex,
                Harden = true
            });
        }

        public uint Purpose => this.AddressPathElements[0].Value;

        public uint CoinType => this.AddressPathElements[1].Value;

        public uint Account => this.AddressPathElements[2].Value;

        public uint Change => this.AddressPathElements[3].Value;

        public uint AddressIndex => this.AddressPathElements[4].Value;

        //public bool Validate()
        //{
        //    string str = "The address path is not a valid BIP44 Address Path.";
        //    if (this.AddressPathElements.Count != 5)
        //        throw new Exception(string.Format("{0} 5 Elements are required but {1} were found.", (object)str, (object)this.AddressPathElements.Count));
        //    if (!this.AddressPathElements[0].Harden)
        //        throw new Exception(str + " Purpose must be hardened");
        //    if (this.AddressPathElements[0].Value != 44U && this.AddressPathElements[0].Value != 49U)
        //        throw new Exception(str + " Purpose must 44 or 49");
        //    if (!this.AddressPathElements[1].Harden)
        //        throw new Exception(str + " Coint Type must be hardened");
        //    if (!this.AddressPathElements[2].Harden)
        //        throw new Exception(str + " Account must be hardened");
        //    if (this.AddressPathElements[3].Harden)
        //        throw new Exception(str + " Change must not be hardened");
        //    if (this.AddressPathElements[3].Value != 0U && this.AddressPathElements[0].Value != 1U)
        //        throw new Exception(str + " Change must 0 or 1");
        //    if (this.AddressPathElements[4].Harden)
        //        throw new Exception(str + " Address Index must not be hardened");
        //    return true;
        //}

        public uint[] ToByteData()
        {
            return this.AddressPathElements.Select(a => !a.Harden ? a.Value : a.Value | 0x80000000).ToArray();
        }

    }
}

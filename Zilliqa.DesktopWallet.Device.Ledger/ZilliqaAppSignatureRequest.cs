namespace Ledger.Net.Requests
{
    public class ZilliqaAppSignatureRequest : RequestBase
    {
        public override byte Argument1 => 0;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins =>  Constants.TRON_SIGN_TX;

        public ZilliqaAppSignatureRequest(byte[] data) : base(data)
        {
        }
    }
}
namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract
{
    public abstract class RequestBase
    {
        //TODO: This is wrong! This needs a rethink. This parameter is used to tell the ledger whether more data is coming or not. This probably needs to be removed from the base class
        public abstract byte Argument1 { get; }
        public abstract byte Argument2 { get; }
        public abstract byte Cla { get; }
        public abstract byte Ins { get; }

        public byte[] Data { get; }

        protected RequestBase(byte[] data)
        {
            Data = data;
        }

        protected byte[] GetNextApduCommand(ref int offset)
        {
            var chunkSize = offset + Constants.LEDGER_STREAM_DATA_SIZE > Data.Length ? Data.Length - offset : Constants.LEDGER_STREAM_DATA_SIZE;

            var buffer = new byte[4 + chunkSize];
            buffer[0] = Cla;
            buffer[1] = Ins;
            buffer[2] = Argument1;
            // buffer[2] will be updated in later when we know how many chunks there are ....
            buffer[3] = Argument2;
            Array.Copy(Data, offset, buffer, 4, chunkSize);

            offset += chunkSize;
            return buffer;
        }

        public virtual List<byte[]> ToAPDUChunks()
        {
            var offset = 0;

            if (Data.Length > 0)
            {
                var retVal = new List<byte[]>();

                while (offset < Data.Length - 1)
                {
                    retVal.Add(GetNextApduCommand(ref offset));
                }

                return retVal;
            }
            return new List<byte[]> { GetNextApduCommand(ref offset) };
        }
    }
}

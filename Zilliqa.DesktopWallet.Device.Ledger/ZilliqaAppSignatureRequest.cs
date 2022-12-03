using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppSignatureRequest : RequestBase
    {
        public override byte Argument1 => 0; //Constants.P1_SIGN;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins =>  Constants.COMMAND_SIGN_TX;

        public uint AccountIndex { get; }

        public ZilliqaAppSignatureRequest(uint accountIndex, byte[] transactionData) : base(transactionData)
        {
            AccountIndex = accountIndex;
        }

        public override List<byte[]> ToAPDUChunks()
        {
            var chunks = new List<byte[]>();

            var header = new byte[4];
            header[0] = Cla;
            header[1] = Ins;
            header[2] = Argument1;
            header[3] = Argument2;

            // FIRST CHUNK Payload
            // See signTxn.c:handleSignTxn() for sequence details of payload.
            // 1. 4 bytes for indexBytes.
            // 2. 4 bytes for hostBytesLeftBytes.
            // 3. 4 bytes for txn1SizeBytes (number of bytes being sent now).
            // 4. txn1Bytes of actual data.
            var firstDataByteCount = Data.Length > Constants.LEDGER_STREAM_DATA_SIZE
                ? Constants.LEDGER_STREAM_DATA_SIZE
                : Data.Length;
            var firstChunk = header
                .Concat(BitConverter.GetBytes(AccountIndex))
                .Concat(BitConverter.GetBytes(Convert.ToUInt32(Data.Length)))
                .Concat(BitConverter.GetBytes(Convert.ToUInt32(firstDataByteCount)))
                .Concat(Data.Take(firstDataByteCount))
                .ToArray();
            chunks.Add(firstChunk);

            // MORE CHUNKS Payload
            // Keep streaming data into the device till we run out of it.
            // See signTxn.c:istream_callback() for how this is used.
            // Each time the bytes sent consists of:
            //  1. 4-bytes of hostBytesLeftBytes.
            //  2. 4-bytes of txnNSizeBytes (number of bytes being sent now).
            //  3. txnNBytes of actual data.
            var dataStartIndex = firstDataByteCount;
            while (dataStartIndex < Data.Length)
            {
                var dataBytesLeft = Data.Length - dataStartIndex;
                var nextDataByteCount = dataBytesLeft > Constants.LEDGER_STREAM_DATA_SIZE
                    ? Constants.LEDGER_STREAM_DATA_SIZE
                    : dataBytesLeft;
                var nextChunk = header
                    .Concat(BitConverter.GetBytes(Convert.ToUInt32(dataBytesLeft)))
                    .Concat(BitConverter.GetBytes(Convert.ToUInt32(nextDataByteCount)))
                    .Concat(Data.Skip(dataStartIndex).Take(nextDataByteCount))
                    .ToArray();
                chunks.Add(nextChunk);
                dataStartIndex += nextDataByteCount;
            }

            return chunks;
        }
    }
}
using Zilligraph.Database.Storage.Extensions;

namespace Zilligraph.Database.Storage.StorageModel.DataStructure
{
    public class StorageTableRowBinary
    {
        public long RowPosition { get; private set; }

        public int RowLength { get; private set; }

        public byte[] CompressedRow { get; private set; }

        public static StorageTableRowBinary ReadFromStream(Stream readableStream)
        {
            var rowBinary = new StorageTableRowBinary
            {
                RowPosition = readableStream.Position
            };
            var lengthBuffer = new byte[4];
            _ = readableStream.Read(lengthBuffer, 0, 4);
            rowBinary.RowLength = BitConverter.ToInt32(lengthBuffer);
            rowBinary.CompressedRow = readableStream.ReadExactly(rowBinary.RowLength);
            return rowBinary;
        }

        public void WriteToStream(Stream writableStream)
        {
            writableStream.Write(BitConverter.GetBytes(RowLength));
            writableStream.Write(CompressedRow);
        }

        public TResult DecompressRowObject<TResult>()
        {
            using (var memoryStream = new MemoryStream(CompressedRow))
            {
                return memoryStream.DecompressObjectFromStream<TResult>();
            }
        }
    }
}

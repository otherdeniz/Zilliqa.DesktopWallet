using Zilligraph.Database.Storage.Extensions;

namespace Zilligraph.Database.Storage.Table;

public class MutableDataRowBinary
{
    public long RowPosition { get; private set; } = -1;

    public int RowLength { get; private set; }

    public byte[] CompressedRow { get; private set; } = null!;

    public static MutableDataRowBinary? ReadFromStream(Stream readableStream)
    {
        try
        {
            var rowBinary = new MutableDataRowBinary
            {
                RowPosition = readableStream.Position
            };
            var lengthBuffer = new byte[4];
            _ = readableStream.Read(lengthBuffer, 0, 4);
            rowBinary.RowLength = Convert.ToInt32(BitConverter.ToUInt32(lengthBuffer));
            rowBinary.CompressedRow = readableStream.ReadExactly(rowBinary.RowLength);
            return rowBinary;
        }
        catch (EndOfStreamException)
        {
            return null;
        }
    }

    public static MutableDataRowBinary CreateNew(object record)
    {
        using (var memoryStream = new MemoryStream())
        {
            record.CompressObjectToStream(memoryStream);
            var rowBinary = new MutableDataRowBinary
            {
                CompressedRow = memoryStream.ToArray(),
                RowLength = Convert.ToInt32(memoryStream.Length)
            };
            return rowBinary;
        }
    }

    public void WriteToStream(Stream writableStream)
    {
        writableStream.Write(BitConverter.GetBytes(Convert.ToUInt32(RowLength)));
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
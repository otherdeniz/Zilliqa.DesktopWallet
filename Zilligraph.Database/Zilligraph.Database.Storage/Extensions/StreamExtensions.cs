namespace Zilligraph.Database.Storage.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ReadExactly(this Stream stream, int count)
        {
            byte[] buffer = new byte[count];
            int offset = 0;
            while (offset < count)
            {
                int read = stream.Read(buffer, offset, count - offset);
                if (read == 0)
                    throw new System.IO.EndOfStreamException();
                offset += read;
            }
            return buffer;
        }
    }
}

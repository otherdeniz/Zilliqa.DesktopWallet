namespace Zilligraph.Database.Storage.Table
{
    public class DataFile : IDisposable
    {
        private object _streamLock = new();
        private FileStream? _stream;

        public DataFile(IZilligraphTable table, int fileNumber)
        {
            Table = table;
            FileNumber = fileNumber;
            FilePath = table.PathBuilder.GetFilePath($"data{fileNumber:000}.bin");
        }

        public IZilligraphTable Table { get; }

        public int FileNumber { get; }

        public string FilePath { get; }

        public ulong Append(DataRowBinary row)
        {
            lock (_streamLock)
            {
                var stream = GetStream();
                stream.Seek(0, SeekOrigin.End);
                ulong recordPoint = Convert.ToUInt64(stream.Position + 1);
                row.WriteToStream(stream);
                return recordPoint;
            }
        }

        public DataRowBinary Read(ulong recordPoint)
        {
            lock (_streamLock)
            {
                var stream = GetStream();
                stream.Seek(Convert.ToInt64(recordPoint - 1), SeekOrigin.Begin);
                return DataRowBinary.ReadFromStream(stream);
            }
        }

        public void Dispose()
        {
            if (_stream != null)
            {
                lock (_streamLock)
                {
                    _stream.Flush();
                    _stream.Dispose();
                }
                _stream = null;
            }
        }

        private FileStream GetStream()
        {
            return _stream ??= File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}

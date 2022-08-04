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

        public void Append(DataRowBinary row)
        {
            lock (_streamLock)
            {
                var stream = GetStream();
                stream.Seek(0, SeekOrigin.End);
                row.WriteToStream(stream);
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

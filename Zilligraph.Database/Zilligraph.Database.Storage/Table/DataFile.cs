namespace Zilligraph.Database.Storage.Table
{
    public class DataFile : IDisposable
    {
        private object _streamLock = new();

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
                using (var stream = GetStream())
                {
                    stream.Seek(0, SeekOrigin.End);
                    ulong recordPoint = Convert.ToUInt64(stream.Position + 1);
                    row.WriteToStream(stream);
                    return recordPoint;
                }
            }
        }

        public DataRowBinary Read(ulong recordPoint)
        {
            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    stream.Seek(Convert.ToInt64(recordPoint - 1), SeekOrigin.Begin);
                    return DataRowBinary.ReadFromStream(stream);
                }
            }
        }

        public void Dispose()
        {
            lock (_streamLock)
            {
                // just wait to unlock
            }
        }

        private FileStream GetStream()
        {
            return File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}

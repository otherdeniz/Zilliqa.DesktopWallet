namespace Zilligraph.Database.Storage.Index
{
    public class IndexRecord
    {
        public IndexRecord(byte[] indexHash, ulong recordPosition)
        {
            IndexHash = indexHash;
            RecordPosition = recordPosition;
        }

        public byte[] IndexHash { get; }

        public ulong RecordPosition { get; }
    }
}

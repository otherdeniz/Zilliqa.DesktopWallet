namespace Zilligraph.Database.Storage.Index
{
    public class IndexItem
    {
        public IndexItem(byte[] indexHash, ulong recordPosition)
        {
            IndexHash = indexHash;
            RecordPosition = recordPosition;
        }

        public byte[] IndexHash { get; }

        public ulong RecordPosition { get; }
    }
}

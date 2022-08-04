namespace Zilligraph.Database.Storage.Index
{
    public class IndexRecord
    {
        public IndexRecord(byte[] indexHash, ulong recordPosition, ulong entryPoint, ulong nextEntryPoint)
        {
            IndexHash = indexHash;
            RecordPosition = recordPosition;
            EntryPoint = entryPoint;
            NextEntryPoint = nextEntryPoint;
        }

        //start of the record in the file position (first position is 1)
        public ulong EntryPoint { get; }

        public ulong NextEntryPoint { get; }

        public byte[] IndexHash { get; }

        public ulong RecordPosition { get; }
    }
}

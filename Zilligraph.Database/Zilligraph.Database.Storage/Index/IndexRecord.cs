namespace Zilligraph.Database.Storage.Index
{
    public class IndexRecord
    {
        public IndexRecord(byte[] indexHash, ulong recordPoint, ulong entryPoint, ulong nextEntryPoint)
        {
            IndexHash = indexHash;
            RecordPoint = recordPoint;
            EntryPoint = entryPoint;
            NextEntryPoint = nextEntryPoint;
        }

        public byte[] IndexHash { get; }

        /// <summary>
        /// position of the data-record in the data-file (first position is 1)
        /// </summary>
        public ulong RecordPoint { get; }

        /// <summary>
        /// start of this index in the index-content-file (first position is 1)
        /// </summary>
        public ulong EntryPoint { get; }

        public ulong NextEntryPoint { get; }
    }
}

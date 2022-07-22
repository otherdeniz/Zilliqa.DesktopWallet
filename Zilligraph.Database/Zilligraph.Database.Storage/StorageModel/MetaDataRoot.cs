namespace Zilligraph.Database.Storage.StorageModel
{
    public class MetaDataRoot
    {
        public string? RecordModelTypeName { get; set; }

        public Dictionary<long, long> RecordStreamPositions { get; set; } = new Dictionary<long, long>();

        public long RecordCount { get; set; }
    }
}

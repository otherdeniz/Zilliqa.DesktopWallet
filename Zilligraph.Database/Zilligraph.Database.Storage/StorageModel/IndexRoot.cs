namespace Zilligraph.Database.Storage.StorageModel
{
    public class IndexRoot
    {
        public int HashDepth { get; set; } = 8;

        public List<IndexCollectionModel> Fields { get; set; } = new List<IndexCollectionModel>();
    }
}

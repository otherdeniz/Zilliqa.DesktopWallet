using Newtonsoft.Json;

namespace Zilligraph.Database.Storage.StorageModel
{
    public class IndexCollectionModel
    {
        [JsonProperty("f")]
        public string FieldId { get; set; }

        [JsonProperty("idxs")]
        public Dictionary<string, List<long>> FieldValueHashRecordIndexes { get; set;}
    }
}

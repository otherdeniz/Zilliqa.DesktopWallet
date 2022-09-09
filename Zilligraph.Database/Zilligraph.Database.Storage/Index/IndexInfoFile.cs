using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexInfoFile : DatFileBase
    {
        public static IndexInfoFile Load(ZilligraphTableIndexBase tableFieldIndex)
        {
            return Load<IndexInfoFile>(tableFieldIndex.PathBuilder.GetFilePath("index-info.json"), false);
        }

        public string? ConfigurationState { get; set; }
    }
}

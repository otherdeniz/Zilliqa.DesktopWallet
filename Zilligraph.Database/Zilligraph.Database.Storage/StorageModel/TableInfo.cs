using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.StorageModel
{
    public class TableInfo : DatFileBase
    {
        public int DataFileCount { get; set; }

        public static TableInfo Load(IZilligraphTable table)
        {
            return Load<TableInfo>(table.PathBuilder.GetFilePath("tableinfo.dat"));
        }
    }
}

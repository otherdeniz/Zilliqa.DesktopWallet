using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Table
{
    public class TableInfoFile : DatFileBase
    {
        public List<DataFileInfo> DataFileInfos { get; set; } = new List<DataFileInfo>();

        public static TableInfoFile Load(IZilligraphTable table)
        {
            return Load<TableInfoFile>(table.PathBuilder.GetFilePath("tableinfo.dat"));
        }

        public class DataFileInfo
        {
            public long FirstRecordNumber { get; set; }

            public long LastRecordNumber { get; set; }
        }
    }

}

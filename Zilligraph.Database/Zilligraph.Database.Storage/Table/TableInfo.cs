using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Table
{
    public class TableInfo : DatFileBase
    {
        public List<DataFileInfo> DataFileInfos { get; set; } = new List<DataFileInfo>();

        public static TableInfo Load(IZilligraphTable table)
        {
            return Load<TableInfo>(table.PathBuilder.GetFilePath("tableinfo.dat"));
        }

        public class DataFileInfo
        {
            public long FirstRecordNumber { get; set; }

            public long LastRecordNumber { get; set; }
        }
    }

}

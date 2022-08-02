using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public interface IZilligraphTable
    {
        ZilligraphDatabase Database { get; }

        string TableName { get; }

        string StoragePath { get; }

        Type RecordType { get; }

        DataPathBuilder PathBuilder { get; }

        ZilligraphFieldIndex GetFieldIndex(string propertyName);
    }
}

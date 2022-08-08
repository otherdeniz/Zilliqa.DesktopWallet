using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public interface IZilligraphTable : IDisposable
    {
        ZilligraphDatabase Database { get; }

        string TableName { get; }

        string StoragePath { get; }

        Type RecordType { get; }

        DataPathBuilder PathBuilder { get; }

        Dictionary<string, ZilligraphFieldIndex> FieldIndexes { get; }
    }
}

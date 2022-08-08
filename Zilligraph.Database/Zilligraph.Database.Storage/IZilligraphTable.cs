using System.Collections;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;

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

        void AddRecord(object record);

        IEnumerable FindRecords(IFilterQuery queryFilter);
    }
}

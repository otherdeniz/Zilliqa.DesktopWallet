using System.Collections;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.Table;

namespace Zilligraph.Database.Storage
{
    public interface IZilligraphTable : IDisposable
    {
        ZilligraphDatabase Database { get; }

        Type RecordType { get; }

        string StoragePath { get; }

        string TableName { get; }

        TableInfo TableInfo { get; }

        long RecordCount { get; }

        DataPathBuilder PathBuilder { get; }

        Dictionary<string, ZilligraphTableIndexBase> Indexes { get; }
        bool InitialisationCompleted { get; }
        decimal InitialisationCompletedPercent { get; }

        void AddRecord(object record);

        IEnumerable FindRecords(IFilterQuery queryFilter, bool resolveReferences = true);

        object? FindRecord(string propertyName, object value, bool resolveReferences = true);

        object? ReadRecord(ulong recordPoint, bool resolveReferences = true);

        void EnsureInitialisationIsStarted();
    }
}

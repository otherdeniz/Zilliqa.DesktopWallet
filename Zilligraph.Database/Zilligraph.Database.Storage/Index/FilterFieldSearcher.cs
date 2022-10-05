using System.Runtime.Caching;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage.Index
{
    public class FilterFieldSearcher : IFilterSearcher
    {
        private static readonly MemoryCache Cache = new MemoryCache("FilterFieldSearcher");
        private readonly IZilligraphTable _table;
        private readonly ZilligraphTableIndexBase _tableFieldIndex;
        private IEnumerator<IndexRecord>? _indexRecordsEnumerator;
        private IEnumerator<ulong>? _cachedRecordsEnumerator;
        private readonly FilterQueryField _fieldFilter;

        public FilterFieldSearcher(IZilligraphTable table, FilterQueryField fieldFilter)
        {
            _table = table;
            _fieldFilter = fieldFilter;
            if (!_table.Indexes.TryGetValue(fieldFilter.PropertyName, out var fieldIndex))
            {
                throw new RuntimeException(
                    $"missing FieldIndex for Property {fieldFilter.PropertyName} on Table {table.TableName}");
            }
            _tableFieldIndex = fieldIndex;
            _fieldFilter = fieldFilter;
        }

        public ulong? GetNextRecordPoint()
        {
            if (_fieldFilter.Cache)
            {
                if (_cachedRecordsEnumerator == null)
                {
                    _cachedRecordsEnumerator = Cache.GetOrAdd(
                               $"{_table.RecordType.Name}.{_fieldFilter.PropertyName}[{_fieldFilter.Compare}]{_fieldFilter.Value?.ToString()}",
                               TimeSpan.FromMinutes(5),
                               () => _tableFieldIndex.SearchIndexes(_fieldFilter).Select(i => i.RecordPoint).ToList())
                           ?.GetEnumerator()
                       ?? Enumerable.Empty<ulong>().GetEnumerator();
                }
                if (!NoMoreRecords 
                    && !_cachedRecordsEnumerator.MoveNext())
                {
                    NoMoreRecords = true;
                }
                return NoMoreRecords 
                    ? null 
                    : _cachedRecordsEnumerator.Current;
            }

            if (_indexRecordsEnumerator == null)
            {
                _indexRecordsEnumerator = _tableFieldIndex.SearchIndexes(_fieldFilter).GetEnumerator();
            }
            if (!NoMoreRecords)
            {
                _indexRecordsEnumerator.MoveNext();
                NoMoreRecords = _indexRecordsEnumerator.Current == null;
            }
            return _indexRecordsEnumerator.Current?.RecordPoint;
        }

        public bool NoMoreRecords { get; private set; }
    }
}

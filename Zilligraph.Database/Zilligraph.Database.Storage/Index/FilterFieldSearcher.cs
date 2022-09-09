using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage.Index
{
    public class FilterFieldSearcher : IFilterSearcher
    {
        private readonly IZilligraphTable _table;
        private readonly ZilligraphTableIndexBase _tableFieldIndex;
        private IEnumerator<IndexRecord>? _indexRecordsEnumerator;
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

﻿using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage.Index
{
    public class FilterFieldSearcher : IFilterSearcher
    {
        private readonly IZilligraphTable _table;
        private readonly ZilligraphTableIndexBase _tableFieldIndex;
        private IEnumerator<IndexRecord>? _indexRecordsEnumerator;
        private readonly object? _filterValue;

        public FilterFieldSearcher(IZilligraphTable table, FilterQueryField filterQueryField)
        {
            _table = table;
            if (!_table.Indexes.TryGetValue(filterQueryField.PropertyName, out var fieldIndex))
            {
                throw new RuntimeException(
                    $"missing FieldIndex for Property {filterQueryField.PropertyName} on Table {table.TableName}");
            }
            _tableFieldIndex = fieldIndex;
            _filterValue = filterQueryField.Value;
        }

        public ulong? GetNextRecordPoint()
        {
            if (_indexRecordsEnumerator == null)
            {
                _indexRecordsEnumerator = _tableFieldIndex.SearchIndexes(_filterValue).GetEnumerator();
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

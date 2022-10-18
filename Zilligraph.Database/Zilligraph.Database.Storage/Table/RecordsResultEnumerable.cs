using System.Collections;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage.Table
{
    public class RecordsResultEnumerable<TRecordModel> : IEnumerable<TRecordModel> where TRecordModel : class, new()
    {
        private readonly ZilligraphTable<TRecordModel> _table;
        private readonly IFilterSearcher _filterSearcher;
        private readonly Func<TRecordModel, bool>? _additionalFilter;
        private readonly bool _resolveReferences;

        public RecordsResultEnumerable(ZilligraphTable<TRecordModel> table, 
            IFilterSearcher filterSearcher, 
            Func<TRecordModel, bool>? additionalFilter, 
            bool resolveReferences)
        {
            _table = table;
            _filterSearcher = filterSearcher;
            _additionalFilter = additionalFilter;
            _resolveReferences = resolveReferences;
        }

        public IEnumerator<TRecordModel> GetEnumerator()
        {
            return new RecordsResultEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class RecordsResultEnumerator : IEnumerator<TRecordModel>
        {
            private readonly RecordsResultEnumerable<TRecordModel> _enumerable;
            private bool _firstRecordReturned;
            private Queue<TRecordModel> _resultQueue;

            internal RecordsResultEnumerator(RecordsResultEnumerable<TRecordModel> enumerable)
            {
                _enumerable = enumerable;
            }

            public bool MoveNext()
            {
                while (true)
                {
                    if (!_firstRecordReturned)
                    {
                        var nextRecordPoint = _enumerable._filterSearcher.GetNextRecordPoint();
                        if (nextRecordPoint == null)
                        {
                            Current = null;
                            return false;
                        }
                        var record = _enumerable._table.ReadRecord(nextRecordPoint.Value, _enumerable._resolveReferences);
                        if (_enumerable._additionalFilter == null
                            || _enumerable._additionalFilter(record))
                        {
                            _firstRecordReturned = true;
                            Current = record;
                            return true;
                        }
                    }
                    else
                    {
                        if (_resultQueue?.Count > 0)
                        {
                            Current = _resultQueue.Dequeue();
                            return true;
                        }
                        var nextRecordPoints = GetNextRecordPoints(999);
                        if (nextRecordPoints.Count == 0)
                        {
                            Current = null;
                            return false;
                        }
                        var nextRecords = _enumerable._table.ReadRecords(nextRecordPoints, _enumerable._resolveReferences);
                        if (_enumerable._additionalFilter != null)
                        {
                            nextRecords = nextRecords.Where(r => _enumerable._additionalFilter(r)).ToList();
                        }
                        if (nextRecords.Count == 0)
                        {
                            Current = null;
                            return false;
                        }
                        _resultQueue = new Queue<TRecordModel>(nextRecords);
                        Current = _resultQueue.Dequeue();
                        return true;
                    }
                }
            }

            private List<ulong> GetNextRecordPoints(int count)
            {
                var resultPoints = new List<ulong>(count);
                do
                {
                    var nextRecordPoint = _enumerable._filterSearcher.GetNextRecordPoint();
                    if (nextRecordPoint == null)
                    {
                        break;
                    }
                    resultPoints.Add(nextRecordPoint.Value);
                } while (resultPoints.Count < count);
                return resultPoints;
            }

            public void Reset()
            {
                throw new NotSupportedException("RecordsResultEnumerable can not restart");
            }

#pragma warning disable CS8766 //Nullability
            public TRecordModel? Current { get; private set; }
#pragma warning restore CS8766

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }
}

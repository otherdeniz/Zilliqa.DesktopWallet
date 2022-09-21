namespace Zilligraph.Database.Storage.Index
{
    internal class AllRecordsFilterSearcher : IFilterSearcher
    {
        private readonly IZilligraphTable _table;
        private int _position = -1;
        private IList<long>? _recordPositions;

        public AllRecordsFilterSearcher(IZilligraphTable table)
        {
            _table = table;
        }

        public ulong? GetNextRecordPoint()
        {
            if (_recordPositions == null)
            {
                _recordPositions = _table.GetAllRecordPositions();
            }

            if (NoMoreRecords) return null;

            if (_recordPositions.Count > _position + 1)
            {
                _position++;
                return Convert.ToUInt64(_recordPositions[_position] + 1);
            }

            NoMoreRecords = true;
            return null;
        }

        public bool NoMoreRecords { get; private set; }
    }
}

using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class FilterAndCombinationSearcher : IFilterSearcher
    {
        private readonly IZilligraphTable _table;
        private readonly List<IFilterSearcher> _childSearcher;
        private readonly ulong[] _currentChildPoints;

        public FilterAndCombinationSearcher(IZilligraphTable table, IEnumerable<IFilterSearcher> childSearcher)
        {
            _table = table;
            _childSearcher = childSearcher.AsList();
            if (_childSearcher.Count < 2)
            {
                throw new RuntimeException("Minimum 2 arguments are required for AND filter combination");
            }
            _currentChildPoints = new ulong[_childSearcher.Count];
        }

        public bool NoMoreRecords { get; private set; }

        public ulong? GetNextRecordPoint()
        {
            if (NoMoreRecords)
            {
                return null;
            }

            do
            {
                NoMoreRecords = !GetNextPointOnLowerSearcher() 
                                || _childSearcher.Any(s => s.NoMoreRecords);

                if (!NoMoreRecords 
                    && _currentChildPoints.All(p => p == _currentChildPoints[0]))
                {
                    return _currentChildPoints[0];
                }
            } while (!NoMoreRecords);

            return null;
        }

        private bool GetNextPointOnLowerSearcher()
        {
            var lowestIndex = 0;
            ulong lowestPoint = _currentChildPoints[0];
            for (int i = 1; i < _currentChildPoints.Length; i++)
            {
                if (_currentChildPoints[i] < lowestPoint)
                {
                    lowestIndex = i;
                    break;
                }
            }
            _currentChildPoints[lowestIndex] = _childSearcher[lowestIndex].GetNextRecordPoint() ?? 0;
            return _currentChildPoints[lowestIndex] > 0;
        }
    }
}

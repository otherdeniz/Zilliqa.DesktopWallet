using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index;

public class FilterOrCombinationSearcher : IFilterSearcher
{
    private readonly IZilligraphTable _table;
    private readonly List<IFilterSearcher> _childSearcher;
    private int _currentChildSearcher;
    private readonly HashSet<ulong> _foundRecords = new();

    public FilterOrCombinationSearcher(IZilligraphTable table, IEnumerable<IFilterSearcher> childSearcher)
    {
        _table = table;
        _childSearcher = childSearcher.AsList();
    }

    public bool NoMoreRecords { get; private set; }

    public ulong? GetNextRecordPoint()
    {
        if (NoMoreRecords)
        {
            return null;
        }
        ulong? result;
        bool toNextChild;
        do
        {
            toNextChild = false;
            result = _childSearcher[_currentChildSearcher].GetNextRecordPoint();
            if (result != null 
                && !_foundRecords.Contains(result.Value))
            {
                _foundRecords.Add(result.Value);
            }
            if (result == null && _childSearcher.Count > _currentChildSearcher + 1)
            {
                _currentChildSearcher++;
                toNextChild = true;
            }
        } while (toNextChild);

        NoMoreRecords = result == null;
        return result;
    }

}
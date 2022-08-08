namespace Zilligraph.Database.Storage.Index;

public interface IFilterSearcher
{
    ulong? GetNextRecordPoint();

    bool NoMoreRecords { get; }
}
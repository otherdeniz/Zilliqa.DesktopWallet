using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public interface IZilligraphTable
    {
        ZilligraphDatabase Database { get; }

        string TableName { get; }

        string StoragePath { get; }

        DataPathBuilder PathBuilder { get; }
    }
}

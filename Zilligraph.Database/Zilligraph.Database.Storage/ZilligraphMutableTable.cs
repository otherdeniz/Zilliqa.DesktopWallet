using Zilligraph.Database.Storage.Table;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphMutableTable<TRecordModel> 
        : ZilligraphTable<TRecordModel> where TRecordModel : class, new()
    {
        public ZilligraphMutableTable(ZilligraphDatabase database)
            : base(database)
        {
        }

        public override List<DataFile> CompressedDataFiles { get; } = new();

        protected override void AddRecordInternal(TRecordModel record)
        {
            throw new NotImplementedException();
        }
    }
}

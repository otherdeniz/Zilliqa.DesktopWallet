namespace Zilligraph.Database.GenericModel
{
    public class DatabaseModel<TRecordModel> where TRecordModel : class
    {
        public string DatabaseName { get; set; }

        public long RecordCount { get; set; }
    }
}
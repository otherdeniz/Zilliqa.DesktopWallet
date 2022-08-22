namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableEventNotificator<TRecord>
    {
        internal ZilligraphTableEventNotificator(Func<TRecord, bool> recordMatch, Action<TRecord> onRecordAdded)
        {
            RecordMatch = recordMatch;
            OnRecordAdded = onRecordAdded;
        }

        public Func<TRecord, bool> RecordMatch { get; }

        public Action<TRecord> OnRecordAdded { get; }
    }

}

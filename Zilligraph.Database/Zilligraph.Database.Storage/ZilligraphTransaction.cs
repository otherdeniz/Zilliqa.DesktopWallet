namespace Zilligraph.Database.Storage
{
    public class ZilligraphTransaction
    {
        public ZilligraphTransaction(IZilligraphTable table)
        {
            Table = table;
        }

        public IZilligraphTable Table { get; }

        public void Commit()
        {

        }

        public void Rollback()
        {

        }

        private void RollbackUnfinishedTransaction()
        {

        }
    }
}

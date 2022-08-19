namespace Zilligraph.Database.Contract
{
    public abstract class LazyReference<TRecord> where TRecord : class, new()
    {
        public abstract TRecord? Value { get; }

        public virtual LazyReferenceState State => LazyReferenceState.NotResolved;
    }

    public enum LazyReferenceState
    {
        NotResolved = 0,
        Exists = 1,
        NotExists = 2
    }
}

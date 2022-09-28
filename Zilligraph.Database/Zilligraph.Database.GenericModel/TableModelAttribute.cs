namespace Zilligraph.Database.Contract
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableModelAttribute : Attribute
    {
        public TableModelAttribute(TableKind tableKind)
        {
            TableKind = tableKind;
        }

        public TableKind TableKind { get; }

    }

    public enum TableKind
    {
        NotMutable = 1,
        Mutable = 2
    }
}

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
        /// <summary>
        /// - data is compressed
        /// - record can not be modified
        /// - schema can be changed
        /// </summary>
        NotMutable = 1,

        /// <summary>
        /// - data is not compressed
        /// - records can be modified
        /// - schema can not be changed
        /// - table must have a primary key
        /// - strings must have max length, null-terminated
        /// </summary>
        Mutable = 2
    }
}

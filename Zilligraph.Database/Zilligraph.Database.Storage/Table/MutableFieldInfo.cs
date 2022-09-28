namespace Zilligraph.Database.Storage.Table
{
    public class MutableFieldInfo
    {
        public int FieldPosition { get; set; }

        public int Length { get; set; }

        public string PropertyName { get; set; }

        public Type ValueType { get; set; }

    }
}

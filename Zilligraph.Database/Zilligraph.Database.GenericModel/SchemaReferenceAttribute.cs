namespace Zilligraph.Database.Contract
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SchemaReferenceAttribute : Attribute
    {
        public SchemaReferenceAttribute(string keyProperty, string foreignKeyProperty)
        {
            KeyProperty = keyProperty;
            ForeignKeyProperty = foreignKeyProperty;
        }

        public string KeyProperty { get; }

        public string ForeignKeyProperty { get; }
    }
}

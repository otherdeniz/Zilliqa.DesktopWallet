namespace Zilligraph.Database.Definition
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SchemaReferenceAttribute : Attribute
    {
        public SchemaReferenceAttribute(string keyProperty, Type foreignType, string foreignKeyProperty)
        {
            KeyProperty = keyProperty;
            ForeignType = foreignType;
            ForeignKeyProperty = foreignKeyProperty;
        }

        public string KeyProperty { get; }

        public Type ForeignType { get; }

        public string ForeignKeyProperty { get; }
    }
}

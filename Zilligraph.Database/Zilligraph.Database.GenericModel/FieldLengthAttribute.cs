namespace Zilligraph.Database.Contract
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldLengthAttribute : Attribute
    {
        public FieldLengthAttribute(int length)
        {
            Length = length;
        }
        public int Length { get; }


    }
}

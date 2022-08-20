namespace Zilligraph.Database.Contract
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredValueAttribute : Attribute
    {
        public RequiredValueAttribute()
        {
        }
    }
}

namespace Zilligraph.Database.Definition
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredValueAttribute : Attribute
    {
        public RequiredValueAttribute()
        {
        }
    }
}

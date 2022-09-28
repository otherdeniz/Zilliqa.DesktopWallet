namespace Zilligraph.Database.Contract;

[AttributeUsage(AttributeTargets.Property)]
public class PrimaryKeyAttribute : Attribute
{
    public PrimaryKeyAttribute()
    {
    }
}
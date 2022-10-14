namespace Zilliqa.DesktopWallet.ViewModelAttributes;

[AttributeUsage(AttributeTargets.Class)]
public class GridSearchableAttribute: Attribute
{
    public GridSearchableAttribute(string searchTermProperty)
    {
        SearchTermProperty = searchTermProperty;
    }

    public string SearchTermProperty { get; }

}
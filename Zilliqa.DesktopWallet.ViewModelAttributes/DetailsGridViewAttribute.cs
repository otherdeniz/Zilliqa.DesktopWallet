namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailsGridViewAttribute : Attribute
    {
        public DetailsGridViewAttribute(string displayName, string? isVisibleProperty = null)
        {
            DisplayName = displayName;
            IsVisibleProperty = isVisibleProperty;
        }

        public string DisplayName { get; }

        public string? IsVisibleProperty { get; }
    }
}

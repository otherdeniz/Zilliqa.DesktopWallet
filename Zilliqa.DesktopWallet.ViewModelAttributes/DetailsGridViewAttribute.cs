namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DetailsGridViewAttribute : Attribute
    {
        public DetailsGridViewAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }
}

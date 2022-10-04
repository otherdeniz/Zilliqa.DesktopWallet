namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DetailsChildObjectAttribute : Attribute
    {
        public DetailsChildObjectAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }
    }
}

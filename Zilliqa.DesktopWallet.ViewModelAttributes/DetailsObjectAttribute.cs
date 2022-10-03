namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DetailsObjectAttribute : Attribute
    {
        public DetailsObjectAttribute(string? groupName)
        {
            GroupName = groupName;
        }

        public string? GroupName { get; }
    }
}

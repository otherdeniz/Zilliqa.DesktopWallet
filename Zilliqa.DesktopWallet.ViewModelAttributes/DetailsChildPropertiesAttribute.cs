namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DetailsChildPropertiesAttribute : Attribute
    {
        public DetailsChildPropertiesAttribute(string? groupName)
        {
            GroupName = groupName;
        }

        public string? GroupName { get; }
    }
}

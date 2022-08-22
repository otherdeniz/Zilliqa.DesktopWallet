namespace Zilliqa.DesktopWallet.Core.ViewModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridViewFormatAttribute : Attribute
    {
        public string Format { get; }

        public GridViewFormatAttribute(string format)
        {
            Format = format;
        }
    }
}

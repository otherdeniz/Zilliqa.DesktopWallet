namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridViewFormatAttribute : Attribute
    {
        public GridViewFormatAttribute(string? format)
        {
            Format = format;
        }

        public string? Format { get; }

        public bool UseGreenOrRedNumbers { get; set; }
    }
}

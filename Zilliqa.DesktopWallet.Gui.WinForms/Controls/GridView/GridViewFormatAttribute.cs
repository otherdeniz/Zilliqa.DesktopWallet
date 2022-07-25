namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
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

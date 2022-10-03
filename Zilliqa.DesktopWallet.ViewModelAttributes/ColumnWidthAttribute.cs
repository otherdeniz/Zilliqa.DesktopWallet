namespace Zilliqa.DesktopWallet.ViewModelAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class ColumnWidthAttribute : Attribute
{
    public ColumnWidthAttribute(int width)
    {
        Width = width;
    }

    public int Width { get; }
}
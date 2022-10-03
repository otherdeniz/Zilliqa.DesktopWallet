using System.Drawing;

namespace Zilliqa.DesktopWallet.ViewModelAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class GridViewBackgroundAttribute : Attribute
{
    public GridViewBackgroundAttribute(int red, int green, int blue)
    {
        BackColor = Color.FromArgb(red, green, blue);
    }

    public GridViewBackgroundAttribute(KnownColor knownColor)
    {
        BackColor = Color.FromKnownColor(knownColor);
    }

    public Color BackColor { get; }

}
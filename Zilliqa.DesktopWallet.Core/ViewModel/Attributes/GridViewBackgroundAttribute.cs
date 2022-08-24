using System.Drawing;

namespace Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class GridViewBackgroundAttribute : Attribute
{
    public GridViewBackgroundAttribute(KnownColor backColor)
    {
        BackColor = backColor;
    }

    public KnownColor BackColor { get; }

}
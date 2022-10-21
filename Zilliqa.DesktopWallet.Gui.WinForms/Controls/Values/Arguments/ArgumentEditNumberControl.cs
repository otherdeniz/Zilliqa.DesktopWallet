namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditNumberControl : ArgumentEditBaseControl
    {
        public ArgumentEditNumberControl()
        {
            InitializeComponent();
        }

        public EditNumberType NumberType { get; set; } = EditNumberType.UInt32;
    }

    public enum EditNumberType
    {
        UInt32 = 1,
        UInt128 = 2,
        UInt256 = 3
    }
}

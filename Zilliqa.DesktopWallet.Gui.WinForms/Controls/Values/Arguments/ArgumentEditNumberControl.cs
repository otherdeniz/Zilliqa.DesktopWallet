using Org.BouncyCastle.Math;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditNumberControl : ArgumentEditBaseControl
    {
        public ArgumentEditNumberControl()
        {
            InitializeComponent();
        }

        public override string ArgumentValue
        {
            get => textValue.Text;
            set => textValue.Text = value;
        }

        public EditNumberType NumberType { get; set; } = EditNumberType.UInt128;

        private void textValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textValue.Text))
            {
                IsValid = IsOptional;
            }
            else
            {
                try
                {
                    var bigNumber = new BigInteger(textValue.Text);
                    IsValid = (NumberType == EditNumberType.UInt32 && bigNumber.BitCount <= 32)
                              || (NumberType == EditNumberType.UInt128 && bigNumber.BitCount <= 128)
                              || (NumberType == EditNumberType.UInt256 && bigNumber.BitCount <= 256);
                }
                catch (Exception)
                {
                    IsInvalid = true;
                }
            }
            RaiseArgumentValueChanged();
        }
    }

    public enum EditNumberType
    {
        UInt32 = 1,
        UInt128 = 2,
        UInt256 = 3
    }
}

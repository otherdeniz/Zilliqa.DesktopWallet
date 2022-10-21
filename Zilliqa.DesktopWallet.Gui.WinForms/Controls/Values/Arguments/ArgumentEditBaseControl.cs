using System.ComponentModel;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditBaseControl : DesignableUserControl
    {
        public static ArgumentEditBaseControl CreateControl(string argumentType)
        {
            ArgumentEditBaseControl? control;
            if (argumentType == ParamTypes.ByStr20)
            {
                control = new ArgumentEditAddressControl();
            }
            else if (argumentType == ParamTypes.Uint32)
            {
                control = new ArgumentEditNumberControl { NumberType = EditNumberType.UInt32 };
            }
            else if (argumentType == ParamTypes.Uint128)
            {
                control = new ArgumentEditNumberControl { NumberType = EditNumberType.UInt128 };
            }
            else if (argumentType == ParamTypes.Uint256)
            {
                control = new ArgumentEditNumberControl { NumberType = EditNumberType.UInt256 };
            }
            else
            {
                control = new ArgumentEditStringControl();
            }
            control.ArgumentType = argumentType;
            return control;
        }

        private string _argumentType = "";
        private bool _isValid;
        private bool _isInvalid;

        public ArgumentEditBaseControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? ArgumentValueChanged;

        [DefaultValue(0)]
        public int NameMinWidth { get; set; }

        [DefaultValue(0)]
        public int TypeMinWidth { get; set; }

        [DefaultValue("")]
        public string ArgumentName
        {
            get => labelName.Text;
            set => labelName.Text = value;
        }

        [DefaultValue("")]
        public string ArgumentType
        {
            get => _argumentType;
            set
            {
                _argumentType = value;
                labelType.Text = $"[{value}]";
                IsValid = IsOptional;
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOptional => _argumentType.ToLower().StartsWith("option ");

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string ArgumentValue { get; set; }

        [DefaultValue(false)]
        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                pictureCheck.Image = value ? ImageResources.Check_16 : null;
                _isInvalid = false;
            }
        }

        [DefaultValue(false)]
        public bool IsInvalid
        {
            get => _isInvalid;
            set
            {
                _isInvalid = value;
                pictureCheck.Image = value ? ImageResources.Warning_16 : null;
                _isValid = false;
            }
        }

        protected void RaiseArgumentValueChanged()
        {
            ArgumentValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ArgumentEditBaseControl_Load(object sender, EventArgs e)
        {
            if (!InDesignMode())
            {
                if (panelLeft.Width < NameMinWidth)
                {
                    panelLeft.AutoSize = false;
                    panelLeft.Width = NameMinWidth;
                }
                if (panelType.Width < TypeMinWidth)
                {
                    panelType.AutoSize = false;
                    panelType.Width = TypeMinWidth;
                }
            }
        }
    }
}

using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditBaseControl : DesignableUserControl
    {
        public ArgumentEditBaseControl()
        {
            InitializeComponent();
        }

        [DefaultValue(0)]
        public int NameMinWidth { get; set; }

        [DefaultValue(0)]
        public int TypeMinWidth { get; set; }

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

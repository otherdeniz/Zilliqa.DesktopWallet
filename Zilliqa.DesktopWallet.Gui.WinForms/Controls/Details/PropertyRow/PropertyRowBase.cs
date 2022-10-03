using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowBase : DesignableUserControl
    {
        public PropertyRowBase()
        {
            InitializeComponent();
        }

        [DefaultValue(0)]
        public int NameMinWidth { get; set; }

        private void PropertyRowBase_Load(object sender, EventArgs e)
        {
            if (!InDesignMode())
            {
                if (panelLeft.Width < NameMinWidth)
                {
                    panelLeft.AutoSize = false;
                    panelLeft.Width = NameMinWidth;
                }
            }
        }
    }
}

using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class GenericDetailsControl : DetailsBaseControl
    {
        public GenericDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadViewModel(object valueViewModel)
        {
            AddObjectControls(this, valueViewModel);
        }

        private void AddObjectControls(Control parentControl, object item)
        {

        }

    }
}

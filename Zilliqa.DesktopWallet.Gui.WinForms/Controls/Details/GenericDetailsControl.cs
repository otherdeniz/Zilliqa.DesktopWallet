using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class GenericDetailsControl : DrillDownBaseControl
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

        private void gridView_IsItemSelectable(object sender, GridView.GridViewControl.IsItemSelectableEventArgs e)
        {
            if (e.SelectedItem?.Value != null)
            {
                e.IsSelectable = CanDrillDownToObject(e.SelectedItem.Value);
            }
        }

        private void gridView_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value != null
                && sender is GridViewControl gridView)
            {
                DrillDownToObject(e.SelectedItem.Value, o =>
                {
                    if (o != gridView)
                    {
                        gridView.ClearSelection();
                    }
                }, gridView);
            }
        }

    }
}

using System.ComponentModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown.PropertyRow;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public partial class GenericObjectControl : DrillDownBaseControl
    {
        private object? _viewModel;

        public GenericObjectControl()
        {
            InitializeComponent();
        }

        public void LoadGenericViewModel(object viewModel)
        {
            _viewModel = viewModel;
            AddControls(this, _viewModel);
        }

        private void AddControls(Control toPanel, object viewModelObject)
        {
            var vmType = viewModelObject.GetType();
            var vmBaseType = vmType.BaseType;
            foreach (var propertyInfo in vmType.GetProperties().Reverse())
            {
                var parentPropertyInfo = vmBaseType?.GetProperty(propertyInfo.Name);
                var propertyTitle = propertyInfo.Name;
                if ((propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault()
                     ?? parentPropertyInfo?.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault())
                    is DisplayNameAttribute displayNameAttribute)
                {
                    propertyTitle = displayNameAttribute.DisplayName;
                }

                var propertyValue = propertyInfo.GetValue(viewModelObject);
                if (propertyValue is string stringValue)
                {
                    AddTextControl(toPanel, propertyTitle, stringValue);
                }
            }
        }

        private void AddTextControl(Control toPanel, string title, string value)
        {
            var control = new PropertyTextRowControl
            {
                Dock = DockStyle.Top
            };
            control.labelProperty.Text = $"{title}:";
            control.labelValue.Text = value;
            toPanel.Controls.Add(control);
        }
    }
}

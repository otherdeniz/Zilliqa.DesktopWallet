using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class ContractFieldsControl : UserControl
    {
        private ContractFieldsValues? _contractFieldsValues;

        public ContractFieldsControl()
        {
            InitializeComponent();
        }

        public ContractFieldsValues? ContractFieldsValues
        {
            get => _contractFieldsValues;
            set
            {
                _contractFieldsValues = value;
                if (_contractFieldsValues != null)
                {
                    LoadDeploymentParams(_contractFieldsValues.ConstructorArguments);
                    LoadFields(_contractFieldsValues.Fields);
                    LoadTransitions(_contractFieldsValues.CodeTransitions);
                }
            }
        }

        private void LoadDeploymentParams(IList<DataParam> deploymentParams)
        {
            var height = 0;
            foreach (var param in deploymentParams.Reverse())
            {
                var textControl = new PropertyRowText();
                textControl.LoadValue(param.Vname, $"{param.ResolvedValue} [{param.Type}]");
                textControl.Dock = DockStyle.Top;
                textControl.Font = new Font(Font, FontStyle.Regular);
                textControl.NameMinWidth = 120;
                groupConstructorArguments.Controls.Add(textControl);
                height += textControl.Height;
            }
            if (height == 0)
            {
                groupConstructorArguments.Visible = false;
            }
            else
            {
                groupConstructorArguments.Height = height + 20;
            }
        }

        private void LoadFields(string[] fields)
        {
            var height = 0;
            foreach (var field in fields.Reverse())
            {
                var buttonControl = new PropertyRowButton();
                buttonControl.LoadValue(field, "Query current State", () =>
                {
                    ContractStateQueryForm.ExecuteShow(this.ParentForm!, _contractFieldsValues!.SmartContract, field); 
                });
                buttonControl.Dock = DockStyle.Top;
                buttonControl.Font = new Font(Font, FontStyle.Regular);
                buttonControl.NameMinWidth = 120;
                groupStateFields.Controls.Add(buttonControl);
                height += buttonControl.Height;
            }
            if (height == 0)
            {
                groupStateFields.Visible = false;
            }
            else
            {
                groupStateFields.Height = height + 20;
            }
        }

        private void LoadTransitions(IList<CodeTransition> codeTransitions)
        {
            var height = 0;
            foreach (var transition in codeTransitions.Reverse())
            {
                var textControl = new PropertyRowTextList();
                var arguments = transition.ParseArguments().Select(a => $"{a.Name} [{a.Type}]").ToArray();
                textControl.LoadValue(transition.Name, arguments);
                textControl.Dock = DockStyle.Top;
                textControl.Font = new Font(Font, FontStyle.Regular);
                textControl.NameMinWidth = 120;
                groupMethods.Controls.Add(textControl);
                height += textControl.Height;
            }
            if (height == 0)
            {
                groupMethods.Visible = false;
            }
            else
            {
                groupMethods.Height = height + 20;
            }
        }
    }
}

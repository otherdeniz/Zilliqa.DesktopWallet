namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditStringControl : ArgumentEditBaseControl
    {
        public ArgumentEditStringControl()
        {
            InitializeComponent();
        }

        public override string ArgumentValue
        {
            get => textValue.Text; 
            set => textValue.Text = value;
        }

        private void textValue_TextChanged(object sender, EventArgs e)
        {
            IsValid = IsOptional || !string.IsNullOrEmpty(textValue.Text);
            RaiseArgumentValueChanged();
        }
    }
}

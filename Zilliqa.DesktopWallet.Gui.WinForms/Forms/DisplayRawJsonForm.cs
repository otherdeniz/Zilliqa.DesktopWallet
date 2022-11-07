using System.Resources;
using Alsing.SourceCode;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class DisplayRawJsonForm : Form
    {
        private static readonly Lazy<string> SyntaxDefinitionXml = new Lazy<string>(GetSyntaxDefinitionXml);

        public static void ExecuteShow(Form parentForm, string rawJson)
        {
            var form = new DisplayRawJsonForm();
            form.LoadText(rawJson);
            form.Show(parentForm);
        }

        public DisplayRawJsonForm()
        {
            InitializeComponent();
        }

        private void LoadText(string rawJson)
        {
            var syntaxDefinition = new SyntaxDefinitionLoader().LoadXML(SyntaxDefinitionXml.Value);
            var doc = new SyntaxDocument();
            doc.Text = rawJson;
            doc.Parser.Init(syntaxDefinition);
            rawTextBox.Document = doc;
        }

        private static string GetSyntaxDefinitionXml()
        {
            using (var resourceStream =
                   typeof(ScillaCodeTextBox).Assembly.GetManifestResourceStream(typeof(ScillaCodeTextBox),
                       "SyntaxFiles.JavaScript.xml")
                   ?? throw new MissingManifestResourceException("The Ressource 'SyntaxFiles\\JavaScript.xml' was not found"))
            {
                using var reader = new StreamReader(resourceStream);
                return reader.ReadToEnd();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

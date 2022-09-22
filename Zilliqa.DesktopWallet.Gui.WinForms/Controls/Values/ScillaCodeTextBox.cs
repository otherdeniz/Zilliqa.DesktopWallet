using System.ComponentModel;
using System.Resources;
using Alsing.SourceCode;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class ScillaCodeTextBox : UserControl
    {
        private static readonly Lazy<string> SyntaxDefinitionXml = new Lazy<string>(GetSyntaxDefinitionXml);

        private string? _text;

        public ScillaCodeTextBox()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string? Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                LoadText();
            }
        }

        private void LoadText()
        {
            var syntaxDefinition = new SyntaxDefinitionLoader().LoadXML(SyntaxDefinitionXml.Value);
            var doc = new SyntaxDocument();
            doc.Text = _text ?? string.Empty;
            doc.Parser.Init(syntaxDefinition);
            syntaxBox.Document = doc;
        }

        private static string GetSyntaxDefinitionXml()
        {
            using (var resourceStream =
                   typeof(ScillaCodeTextBox).Assembly.GetManifestResourceStream(typeof(ScillaCodeTextBox),
                       "SyntaxFiles.Scilla.xml")
                   ?? throw new MissingManifestResourceException("The Ressource 'SyntaxFiles\\Scilla.xml' was not found"))
            {
                using var reader = new StreamReader(resourceStream);
                return reader.ReadToEnd();
            }
        }
    }
}

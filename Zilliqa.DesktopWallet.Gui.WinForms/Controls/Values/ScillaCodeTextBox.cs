using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alsing.SourceCode;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class ScillaCodeTextBox : UserControl
    {
        private string? _text;

        public ScillaCodeTextBox()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
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
            var doc = new SyntaxDocument();
            doc.Text = _text;
            Alsing.SourceCode.SyntaxDefinition sl = new SyntaxDefinition();
            sl.SpanDefinitions = new SpanDefinition[]
            {
                new SpanDefinition()
                {
                    Style = new TextStyle() { ForeColor = Color.Blue }
                }
            };
            //var keywordRow = new Row();
            //keywordRow.Add("contract");
            //keywordRow.
            //doc.KeywordQueue.Add(new Row{});

            syntaxBox.Document = doc;
        }
    }
}

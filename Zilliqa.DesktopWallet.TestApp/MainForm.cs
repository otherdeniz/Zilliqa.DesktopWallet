using System.Text;
using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.TestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new DatabaseStorageTestForm();
            form.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var zilClient = new ZilliqaClient(false);
            var blockData = Task.Run(async () => await zilClient.GetTxnBodiesForTxBlock(Convert.ToInt32(numericBlock.Value))).GetAwaiter().GetResult();
            if (saveFileJson.ShowDialog(this) == DialogResult.OK)
            {
                using (var saveFile = File.OpenWrite(saveFileJson.FileName))
                {
                    using (var writer = new StreamWriter(saveFile, Encoding.UTF8))
                    {
                        writer.Write(JsonConvert.SerializeObject(blockData, Formatting.Indented, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Include,
                            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                            TypeNameHandling = TypeNameHandling.Objects
                        }));
                    }
                }
                
            }
        }
    }
}
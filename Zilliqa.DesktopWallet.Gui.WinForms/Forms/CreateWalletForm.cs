using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class CreateWalletForm : Form
    {
        public CreateWalletForm()
        {
            InitializeComponent();
            panelPage1.Dock = DockStyle.Fill;
        }

        private void buttonPage1Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

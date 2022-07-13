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
    public partial class DialogBaseForm : Form
    {
        public DialogBaseForm()
        {
            InitializeComponent();
        }

        protected virtual bool OnCancel()
        {
            return true;
        }

        protected virtual bool OnOk()
        {
            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel())
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (OnOk())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class AddressBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressBookForm));
            this.toolStripTabs = new System.Windows.Forms.ToolStrip();
            this.buttonTabAddressBook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonTabKnownAddresses = new System.Windows.Forms.ToolStripButton();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.panelAddressBook = new System.Windows.Forms.Panel();
            this.gridViewAddressBook = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.toolStripAddressbook = new System.Windows.Forms.ToolStrip();
            this.buttonAddressAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonAddressRemove = new System.Windows.Forms.ToolStripButton();
            this.gridViewKnownAddresses = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.toolStripTabs.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.panelAddressBook.SuspendLayout();
            this.toolStripAddressbook.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(462, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(570, 6);
            // 
            // toolStripTabs
            // 
            this.toolStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonTabAddressBook,
            this.toolStripSeparator1,
            this.buttonTabKnownAddresses});
            this.toolStripTabs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTabs.Location = new System.Drawing.Point(8, 8);
            this.toolStripTabs.Name = "toolStripTabs";
            this.toolStripTabs.Size = new System.Drawing.Size(676, 23);
            this.toolStripTabs.TabIndex = 100;
            // 
            // buttonTabAddressBook
            // 
            this.buttonTabAddressBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonTabAddressBook.Image = ((System.Drawing.Image)(resources.GetObject("buttonTabAddressBook.Image")));
            this.buttonTabAddressBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTabAddressBook.Name = "buttonTabAddressBook";
            this.buttonTabAddressBook.Size = new System.Drawing.Size(128, 19);
            this.buttonTabAddressBook.Text = "Custom Address Book";
            this.buttonTabAddressBook.Click += new System.EventHandler(this.buttonTabAddressBook_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonTabKnownAddresses
            // 
            this.buttonTabKnownAddresses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonTabKnownAddresses.Image = ((System.Drawing.Image)(resources.GetObject("buttonTabKnownAddresses.Image")));
            this.buttonTabKnownAddresses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTabKnownAddresses.Name = "buttonTabKnownAddresses";
            this.buttonTabKnownAddresses.Size = new System.Drawing.Size(104, 19);
            this.buttonTabKnownAddresses.Text = "Known Addresses";
            this.buttonTabKnownAddresses.Click += new System.EventHandler(this.buttonTabKnownAddresses_Click);
            // 
            // panelTabs
            // 
            this.panelTabs.BackColor = System.Drawing.Color.White;
            this.panelTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTabs.Controls.Add(this.panelAddressBook);
            this.panelTabs.Controls.Add(this.gridViewKnownAddresses);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(8, 31);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(676, 289);
            this.panelTabs.TabIndex = 0;
            // 
            // panelAddressBook
            // 
            this.panelAddressBook.Controls.Add(this.gridViewAddressBook);
            this.panelAddressBook.Controls.Add(this.toolStripAddressbook);
            this.panelAddressBook.Location = new System.Drawing.Point(76, 53);
            this.panelAddressBook.Name = "panelAddressBook";
            this.panelAddressBook.Size = new System.Drawing.Size(253, 127);
            this.panelAddressBook.TabIndex = 2;
            // 
            // gridViewAddressBook
            // 
            this.gridViewAddressBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewAddressBook.Location = new System.Drawing.Point(0, 25);
            this.gridViewAddressBook.Name = "gridViewAddressBook";
            this.gridViewAddressBook.Size = new System.Drawing.Size(253, 102);
            this.gridViewAddressBook.TabIndex = 0;
            this.gridViewAddressBook.SelectionChanged += new System.EventHandler<Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl.SelectedItemEventArgs>(this.gridViewAddressBook_SelectionChanged);
            // 
            // toolStripAddressbook
            // 
            this.toolStripAddressbook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddressAdd,
            this.buttonAddressRemove});
            this.toolStripAddressbook.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripAddressbook.Location = new System.Drawing.Point(0, 0);
            this.toolStripAddressbook.Name = "toolStripAddressbook";
            this.toolStripAddressbook.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripAddressbook.Size = new System.Drawing.Size(253, 25);
            this.toolStripAddressbook.TabIndex = 1;
            this.toolStripAddressbook.Text = "toolStrip1";
            // 
            // buttonAddressAdd
            // 
            this.buttonAddressAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddressAdd.Image")));
            this.buttonAddressAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddressAdd.Name = "buttonAddressAdd";
            this.buttonAddressAdd.Size = new System.Drawing.Size(94, 20);
            this.buttonAddressAdd.Text = "Add Address";
            this.buttonAddressAdd.Click += new System.EventHandler(this.buttonAddressAdd_Click);
            // 
            // buttonAddressRemove
            // 
            this.buttonAddressRemove.Enabled = false;
            this.buttonAddressRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddressRemove.Image")));
            this.buttonAddressRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddressRemove.Name = "buttonAddressRemove";
            this.buttonAddressRemove.Size = new System.Drawing.Size(70, 20);
            this.buttonAddressRemove.Text = "Remove";
            this.buttonAddressRemove.Click += new System.EventHandler(this.buttonAddressRemove_Click);
            // 
            // gridViewKnownAddresses
            // 
            this.gridViewKnownAddresses.Location = new System.Drawing.Point(335, 64);
            this.gridViewKnownAddresses.Name = "gridViewKnownAddresses";
            this.gridViewKnownAddresses.Size = new System.Drawing.Size(185, 99);
            this.gridViewKnownAddresses.TabIndex = 1;
            this.gridViewKnownAddresses.SelectionChanged += new System.EventHandler<Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl.SelectedItemEventArgs>(this.gridViewKnownAddresses_SelectionChanged);
            // 
            // AddressBookForm
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 365);
            this.Controls.Add(this.panelTabs);
            this.Controls.Add(this.toolStripTabs);
            this.Name = "AddressBookForm";
            this.Text = "Select Address from Address Book";
            this.Load += new System.EventHandler(this.AddressBookForm_Load);
            this.Controls.SetChildIndex(this.toolStripTabs, 0);
            this.Controls.SetChildIndex(this.panelTabs, 0);
            this.toolStripTabs.ResumeLayout(false);
            this.toolStripTabs.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.panelAddressBook.ResumeLayout(false);
            this.panelAddressBook.PerformLayout();
            this.toolStripAddressbook.ResumeLayout(false);
            this.toolStripAddressbook.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStripTabs;
        private ToolStripButton buttonTabAddressBook;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonTabKnownAddresses;
        private Panel panelTabs;
        private Controls.GridView.GridViewControl gridViewKnownAddresses;
        private Controls.GridView.GridViewControl gridViewAddressBook;
        private Panel panelAddressBook;
        private ToolStrip toolStripAddressbook;
        private ToolStripButton buttonAddressAdd;
        private ToolStripButton buttonAddressRemove;
    }
}
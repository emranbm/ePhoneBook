using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ePhoneBook
{
    public partial class MainForm : RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            DatabaseEntities entities = new DatabaseEntities();
            foreach (var contact in entities.Contacts)
            {
                ContactsLV.Items.Add(contact);
            }
        }

        private void contactsLV_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            Contact contact = (Contact)e.Item.Value;
            MessageBox.Show(contact.FirstName);
        }
    }
}

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
            SetItems();

            contactsLV.FilterPredicate = Filter;
        }

        private void SetItems()
        {
            DatabaseEntities entities = new DatabaseEntities();
            foreach (var contact in entities.Contacts.OrderBy((contact) => contact.LastName).ThenBy((contact) => contact.FirstName))
            {
                contactsLV.Items.Add(contact);
            }
        }

        private void contactsLV_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            Contact contact = (Contact)e.Item.Value;
            var form = new ContactForm(contact);
            form.ShowDialog(this);
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            contactsLV.EnableFiltering = false;
            contactsLV.EnableFiltering = true;
        }

        private bool Filter(ListViewDataItem item)
        {
            Contact contact = (Contact)item.Value;

            if (searchTB.Text.Length == 0)
                return true;
            else
                return ((contact.LastName + contact.FirstName).ToUpper().Contains(searchTB.Text.ToUpper()));
        }

        private void newContactBtn_Click(object sender, EventArgs e)
        {
            var form = new NewContactForm();
            form.ShowDialog(this);
        }
    }
}

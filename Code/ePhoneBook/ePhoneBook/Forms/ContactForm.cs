using ePhoneBook.Helpers;
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
    public partial class ContactForm : RadForm
    {
        private readonly int _contactId;

        public ContactForm(int contactId)
        {
            InitializeComponent();

            _contactId = contactId;

            SetData();
        }

        private void SetData()
        {
            using (var entities = new DatabaseEntities())
            {
                Contact contact = entities.GetContactById(_contactId);

                if (contact == null)
                {
                    Close();
                    return;
                }

                firstNameLbl.Text = Text = contact.FirstName;
                lastNameLbl.Text = contact.LastName;
                phoneNumbersLV.Items.Clear();
                foreach (var phoneNum in contact.PhoneNumbers)
                {
                    phoneNumbersLV.Items.Add(phoneNum.Title, phoneNum.Number);
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                string.Format("Are you sure you want to delete {0}?", firstNameLbl.Text),
                "Delete contact",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                var contact = new Contact() { Id = _contactId };
                using (var entities = new DatabaseEntities())
                {
                    entities.Entry(contact).State = System.Data.Entity.EntityState.Deleted;
                    entities.SaveChanges();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var form = new EditContactForm(_contactId);
            var result = form.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                DialogResult = DialogResult.OK;
                SetData();
            }
        }
    }
}

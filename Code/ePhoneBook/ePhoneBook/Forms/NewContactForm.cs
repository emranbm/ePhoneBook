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
    public partial class NewContactForm : EditableContactForm
    {
        public NewContactForm() : base ("New Contact")
        {
            InitializeComponent();
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            bool isFormValid = ValidateForm();
            if (!isFormValid)
                return;

            using (DatabaseEntities entities = new DatabaseEntities())
            {
                Contact contact = new Contact()
                {
                    FirstName = firstNameTB.Text,
                    LastName = lastNameTB.Text
                };

                var sameContacts = from c in entities.Contacts
                                   where c.FirstName == contact.FirstName
                                   && c.LastName == contact.LastName
                                   select c;

                if (sameContacts.Any())
                {
                    MessageBox.Show("A contact with the given name already exists", "Contact already exists");
                    // TODO merge contacts
                    return;
                }

                var phoneNumbers = GetPhoneNumbers();
                var arePhonesValid = ValidatePhoneNumbers(entities, phoneNumbers);
                if (!arePhonesValid)
                    return;
                contact.PhoneNumbers = phoneNumbers;

                entities.Contacts.Add(contact);
                entities.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidatePhoneNumbers(DatabaseEntities entities, IEnumerable<PhoneNumber> phoneNumbers)
        {
            foreach (var phoneNum in phoneNumbers)
            {
                var samePhones = from p in entities.PhoneNumbers
                                 where p.Number == phoneNum.Number
                                 select p;
                if (samePhones.Any())
                {
                    MessageBox.Show(
                        string.Format(
                            "A contact with the phone number {0} already exists.",
                            phoneNum.Number),
                        "Phone number already exists");
                    // TODO merge contacts
                    return false;
                }
            }

            return true;
        }
    }
}

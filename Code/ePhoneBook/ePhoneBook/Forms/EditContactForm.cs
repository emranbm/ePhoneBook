using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePhoneBook
{
    class EditContactForm : EditableContactForm
    {
        private readonly int _contactId;

        public EditContactForm(int contactId)
        {
            _contactId = contactId;

            using (var entities = new DatabaseEntities())
            {
                var contact = entities.GetContactById(contactId);
                SetData(contact);
            }
        }

        private void SetData(Contact contact)
        {
            Text = "Edit " + contact.FirstName;
            firstNameTB.Text = contact.FirstName;
            lastNameTB.Text = contact.LastName;
            foreach (var phoneNum in contact.PhoneNumbers)
            {
                phoneNumbersLV.Items.Add(phoneNum.Title, phoneNum.Number);
            }
        }

        protected override void saveBtn_Click(object sender, EventArgs e)
        {
            bool isFormValid = ValidateForm();
            if (!isFormValid)
                return;

            using (var entities = new DatabaseEntities())
            {
                var contact = entities.GetContactById(_contactId);
                bool succeeded = UpdateContact(entities, contact);
                if (!succeeded)
                    return;
                entities.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool UpdateContact(DatabaseEntities entities, Contact contact)
        {
            contact.FirstName = firstNameTB.Text;
            contact.LastName = lastNameTB.Text;
            var newPhoneNumbers = GetNewPhoneNumbers(contact);
            var arePhonesValid = ValidatePhoneNumbers(entities.PhoneNumbers, newPhoneNumbers);
            if (!arePhonesValid)
                return false;
            foreach (var num in newPhoneNumbers)
                contact.PhoneNumbers.Add(num);

            var removedPhoneNumbers = GetRemovedPhoneNumbers(contact);

            entities.PhoneNumbers.RemoveRange(removedPhoneNumbers);

            return true;
        }
        private bool ValidatePhoneNumbers(DbSet<PhoneNumber> allPhoneNumbers, IEnumerable<PhoneNumber> phoneNumbers)
        {
            foreach (var phoneNum in phoneNumbers)
            {
                var samePhones = from p in allPhoneNumbers
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

using ePhoneBook.Helpers;
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
            var repetitivePhone = EntityHelper.GetRepetitivePhoneNumber(entities.PhoneNumbers, newPhoneNumbers);
            if (repetitivePhone != null)
            {
                if (HandleRepetitivePhone(contact, repetitivePhone))
                {
                    entities.PhoneNumbers.RemoveRange(contact.PhoneNumbers);
                    entities.Contacts.Remove(contact);
                }
                else
                    return false;
            }
            else
            {
                var repetitiveContact = EntityHelper.GetRepetitiveContact(entities.Contacts, contact);

                if (repetitiveContact != null)
                {
                    if (HandleRepetitiveContact(repetitiveContact))
                    {
                        entities.PhoneNumbers.RemoveRange(contact.PhoneNumbers);
                        entities.Contacts.Remove(contact);
                    }
                    else
                        return false;
                }
                else
                {
                    foreach (var num in newPhoneNumbers)
                        contact.PhoneNumbers.Add(num);

                    var removedPhoneNumbers = GetRemovedPhoneNumbers(contact);

                    entities.PhoneNumbers.RemoveRange(removedPhoneNumbers);
                }
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ePhoneBook
{
    class NewContactForm : EditableContactForm
    {
        public NewContactForm()
        {
            Text = "New Contact";
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

                var repetitiveContact = GetRepetitiveContact(entities.Contacts, contact);

                if (repetitiveContact == null)
                {
                    var phoneNumbers = GetPhoneNumbers();
                    var repetitivePhone = GetRepetitivePhoneNumber(entities.PhoneNumbers, phoneNumbers);
                    if (repetitivePhone == null)
                    {
                        contact.PhoneNumbers = phoneNumbers;
                        entities.Contacts.Add(contact);
                    }
                    else
                    {
                        if (!HandleRepetitivePhone(contact, repetitivePhone))
                            return;
                    }
                }
                else
                {
                    if(!HandleRepetitiveContact(repetitiveContact))
                        return;
                }

                entities.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool HandleRepetitivePhone(Contact contact, PhoneNumber repetitivePhone)
        {
            var repetitiveContact = repetitivePhone.Contact;
            var result = MessageBox.Show(
                string.Format(
                    "A contact with the phone number {0} and the name \"{1} {2}\" already exists. Do you want to merge with that contact?",
                    repetitivePhone.Number,
                    repetitiveContact.FirstName,
                    repetitiveContact.LastName),
                "Phone number already exists",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return false;
            else
            {
                MergeContact(repetitiveContact);
                if (!contact.Equals(repetitiveContact))
                {
                    result = MessageBox.Show(
                        string.Format(
                            "Do you want to update the merged contact with the new name?{0}Old Name: {1} {2}{0}New Name: {3} {4}",
                            Environment.NewLine,
                            repetitiveContact.FirstName, repetitiveContact.LastName,
                            contact.FirstName, contact.LastName),
                        "Update contact name",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        repetitiveContact.FirstName = firstNameTB.Text;
                        repetitiveContact.LastName = lastNameTB.Text;
                    }
                }
                return true;
            }
        }

        private bool HandleRepetitiveContact(Contact repetitiveContact)
        {
            var result = MessageBox.Show("A contact with the given name already exists. Do you want to merge it?", "Contact already exists", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return false;
            else
                MergeContact(repetitiveContact);
            return true;
        }

        private void MergeContact(Contact contact)
        {
            var newPhones = GetNewPhoneNumbers(contact);

            foreach (var phoneNum in newPhones)
                contact.PhoneNumbers.Add(phoneNum);
        }

        private PhoneNumber GetRepetitivePhoneNumber(DbSet<PhoneNumber> allPhoneNumbers, IEnumerable<PhoneNumber> phoneNumbers)
        {
            foreach (var phoneNum in phoneNumbers)
            {
                var samePhones = from p in allPhoneNumbers
                                 where p.Number == phoneNum.Number
                                 select p;
                if (samePhones.Any())
                {
                    return samePhones.First();
                }
            }

            return null;
        }

        private Contact GetRepetitiveContact(DbSet<Contact> allContacts, Contact contact)
        {
            var sameContacts = from c in allContacts
                               where c.FirstName == contact.FirstName
                               && c.LastName == contact.LastName
                               select c;

            return sameContacts.FirstOrDefault();
        }
    }
}

using ePhoneBook.Helpers;
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

                var repetitiveContact = EntityHelper.GetRepetitiveContact(entities.Contacts, contact);

                if (repetitiveContact == null)
                {
                    var phoneNumbers = GetPhoneNumbers();
                    var repetitivePhone = EntityHelper.GetRepetitivePhoneNumber(entities.PhoneNumbers, phoneNumbers);
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

        
    }
}

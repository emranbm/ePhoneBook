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
    public partial class EditableContactForm : RadForm
    {
        public EditableContactForm()
        {
            InitializeComponent();
        }

        protected virtual void addBtn_Click(object sender, EventArgs e)
        {
            if (numberTB.Text == string.Empty || titleDD.Text == string.Empty)
                return;

            phoneNumbersLV.Items.Add(titleDD.Text, numberTB.Text);

            numberTB.Text = string.Empty;
        }

        private void phoneNumbersLV_SelectedItemChanged(object sender, EventArgs e)
        {
            removeBtn.Enabled = phoneNumbersLV.SelectedItem != null;
        }

        protected virtual void removeBtn_Click(object sender, EventArgs e)
        {
            int index = phoneNumbersLV.SelectedIndex;
            if (index < 0)
                return;

            phoneNumbersLV.Items.RemoveAt(index);
        }

        private void numberTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addBtn_Click(sender, e);
        }

        private void phoneNumbersLV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeBtn_Click(sender, e);
        }

        protected virtual void saveBtn_Click(object sender, EventArgs e) { }
        

        protected List<PhoneNumber> GetPhoneNumbers()
        {
            var list = new List<PhoneNumber>();

            foreach (var p in phoneNumbersLV.Items)
            {
                list.Add(new PhoneNumber()
                {
                    Title = p[0].ToString(),
                    Number = p[1].ToString()
                });
            }

            return list;
        }

        protected bool ValidateForm()
        {
            if (firstNameTB.Text == string.Empty)
            {
                MessageBox.Show("First Name field is empty", "Incomplete fields");
                return false;
            }
            if (lastNameTB.Text == string.Empty)
            {
                MessageBox.Show("Last Name field is empty", "Incomplete fields");
                return false;
            }
            if (phoneNumbersLV.Items.Count == 0)
            {
                MessageBox.Show("At least 1 phone number is required", "Incomplete fields");
                return false;
            }

            return true;
        }
        
        protected List<PhoneNumber> GetNewPhoneNumbers(Contact contact)
        {
            var newPhoneNums = GetPhoneNumbers().FindAll((phoneNum) =>
            {
                return
                !(from p in contact.PhoneNumbers
                  where p.Number == phoneNum.Number
                  select p).Any();
            });

            return newPhoneNums;
        }

        protected List<PhoneNumber> GetRemovedPhoneNumbers(Contact contact)
        {
            var phonesInForm = GetPhoneNumbers();
            var removedPhoneNums = (from p in contact.PhoneNumbers
                                    where !(from pif in phonesInForm where pif.Number == p.Number select pif).Any()
                                    select p).ToList();

            return removedPhoneNums;
        }

        protected bool HandleRepetitivePhone(Contact contact, PhoneNumber repetitivePhone)
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

        protected bool HandleRepetitiveContact(Contact repetitiveContact)
        {
            var result = MessageBox.Show("A contact with the given name already exists. Do you want to merge it?", "Contact already exists", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return false;
            else
                MergeContact(repetitiveContact);
            return true;
        }

        protected void MergeContact(Contact contact)
        {
            var newPhones = GetNewPhoneNumbers(contact);

            foreach (var phoneNum in newPhones)
                contact.PhoneNumbers.Add(phoneNum);
        }
    }
}

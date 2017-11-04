using System;
using System.Collections.Generic;
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

        private List<PhoneNumber> GetNewPhoneNumbers(DatabaseEntities entities)
        {
            var contact = entities.GetContactById(_contactId);
            var newPhoneNums = GetPhoneNumbers().FindAll((phoneNum) =>
            {
                return
                !(from p in contact.PhoneNumbers
                  where p.Number == phoneNum.Number
                  select p).Any();
            });

            return newPhoneNums;
        }

        private List<PhoneNumber> GetRemovedPhoneNumbers(DatabaseEntities entities)
        {
            var phonesInForm = GetPhoneNumbers();
            var contact = entities.GetContactById(_contactId);
            var removedPhoneNums = (from p in contact.PhoneNumbers
                                    where !(from pif in phonesInForm where pif.Number == p.Number select pif).Any()
                                    select p).ToList();

            return removedPhoneNums;
        }

        private bool UpdateContact(DatabaseEntities entities, Contact contact)
        {
            contact.FirstName = firstNameTB.Text;
            contact.LastName = lastNameTB.Text;
            var newPhoneNumbers = GetNewPhoneNumbers(entities);
            var arePhonesValid = ValidatePhoneNumbers(entities, newPhoneNumbers);
            if (!arePhonesValid)
                return false;
            foreach (var num in newPhoneNumbers)
                contact.PhoneNumbers.Add(num);

            var removedPhoneNumbers = GetRemovedPhoneNumbers(entities);

            //foreach (var removedPhone in removedPhoneNumbers)
            {
                //    contact.PhoneNumbers.Remove(removedPhone);
            }

            entities.PhoneNumbers.RemoveRange(removedPhoneNumbers);

            return true;
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

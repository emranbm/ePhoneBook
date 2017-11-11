using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook.Helpers
{
    static class EntityHelper
    {
        public static Contact GetContactById(this DatabaseEntities entities, int id)
        {
            return (from c in entities.Contacts
                    where c.Id == id
                    select c).Single();
        }

        public static Contact GetRepetitiveContact(DbSet<Contact> allContacts, Contact contact)
        {
            var sameContacts = from c in allContacts
                               where c.FirstName == contact.FirstName
                               && c.LastName == contact.LastName
                               && (contact.Id == 0 || c.Id != contact.Id)
                               select c;

            if (sameContacts.Any())
                return sameContacts.Single();
            return null;
        }

        public static PhoneNumber GetRepetitivePhoneNumber(DbSet<PhoneNumber> allPhoneNumbers, IEnumerable<PhoneNumber> phoneNumbers)
        {
            foreach (var phoneNum in phoneNumbers)
            {
                var samePhones = from p in allPhoneNumbers
                                 where p.Number == phoneNum.Number
                                 && (phoneNum.ContactId == 0 || p.ContactId != phoneNum.ContactId)
                                 select p;

                if (samePhones.Any())
                    return samePhones.Single();
            }

            return null;
        }
    }
}

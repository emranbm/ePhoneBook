using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook
{
    public partial class Contact
    {
        public override bool Equals(Object other)
        {
            Contact otherContact = other as Contact;
            return otherContact != null && FirstName == otherContact.FirstName && LastName == otherContact.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("<html><b>{0}</b>, {1}", LastName, FirstName);
        }
    }
}

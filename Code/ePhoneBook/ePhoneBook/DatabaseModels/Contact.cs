using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook
{
    public partial class Contact : IEquatable<Contact>
    {
        bool IEquatable<Contact>.Equals(Contact other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
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

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook
{
    public partial class PhoneNumber : IEquatable<PhoneNumber>
    {
        bool IEquatable<PhoneNumber>.Equals(PhoneNumber other)
        {
            return Number == other.Number;
        }
    }
}

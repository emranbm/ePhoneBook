using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook
{
    public partial class PhoneNumber
    {
        public override bool Equals(Object other)
        {
            var otherPhone = other as PhoneNumber;
            return otherPhone != null && Number == otherPhone.Number;
        }

        public override int GetHashCode()
        {
            return Number?.GetHashCode() ?? 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePhoneBook
{
    public static class ContextHelper
    {
        public static Contact GetContactById(this DatabaseEntities entities, int id)
        {
            return (from c in entities.Contacts
                    where c.Id == id
                    select c).First();
        }
    }
}

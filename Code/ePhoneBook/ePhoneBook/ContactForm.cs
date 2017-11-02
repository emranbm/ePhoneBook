using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ePhoneBook
{
    public partial class ContactForm : RadForm
    {
        private readonly Contact _contact;

        public ContactForm(Contact contact)
        {
            InitializeComponent();
            _contact = contact;

            SetData();
        }

        private void SetData()
        {
            firstNameLbl.Text = Text = _contact.FirstName;
            lastNameLbl.Text = _contact.LastName;
            foreach (var phoneNum in _contact.PhoneNumbers)
            {
                phoneNumbersLV.Items.Add(phoneNum.Title, phoneNum.Number);
            }
        }
    }
}

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
    }
}

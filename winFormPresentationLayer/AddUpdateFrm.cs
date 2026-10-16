using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormPresentationLayer
{
    public partial class AddUpdateFrm : Form
    {
        private void _FillCountriesInComboBox()
        {
            // افترضي أن لديكِ دالة في الـ BLL تجلب قائمة البلدان
            cbCountry.DataSource = clsCountries.GetCountries();
            cbCountry.DisplayMember = "CountryName"; // الاسم الذي يظهر للمستخدم
  cbCountry.ValueMember = "CountryID";     // القيمة المخفية التي نريدها (ID)
        }
        private void AddUpdateFrm_Load(object sender, EventArgs e)
        {
            _FillCountriesInComboBox();
        }
        public AddUpdateFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsContact contact = new clsContact();
            contact.FirstName = tbFname.Text;
            contact.LastName = tbLname.Text;
            contact.Email = tbEmail.Text;
            contact.Phone = tbPhone.Text;
            contact.Address = tbAddress.Text;
            contact.DateOfBirth = dateTime.Value;
            if(cbCountry.SelectedValue != null)
            {
                contact.CountryID = (int)cbCountry.SelectedValue;
                
            }
            else MessageBox.Show("Please select a country.", "add contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (contact.save())
            {
                tbID.Text = contact.ContactID.ToString();
                MessageBox.Show("Contact saved successfully.", "add contact", MessageBoxButtons.OK);
                this.Close();
            }
            else MessageBox.Show("Contact not saved.", "add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

       
    }
}

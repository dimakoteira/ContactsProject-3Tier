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
       public  enum enMode { add, update };
       private  enMode _mode = enMode.add;
       private clsContact _contact;
        private int _contactID;
        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountries.GetCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _loadData()
        {
            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 0;
            if (_mode == enMode.add)
            {
                _contact = new clsContact();
                titleLbl.Text = "Add Contact";
                return;
            }
            _contact = clsContact.GetContact(_contactID);
            if (_contact == null) { 
                MessageBox.Show("this contact is not found in the database");
                this.Close();
                return;
        }
            tbFname.Text = _contact.FirstName;
            tbLname.Text = _contact.LastName;
            tbEmail.Text = _contact.Email;
            tbPhone.Text = _contact.Phone;
            tbAddress.Text = _contact.Address;
            dateTime.Value = _contact.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.GetCountry(_contact.CountryID).CountryName);
        }
        private void AddUpdateFrm_Load(object sender, EventArgs e)
        {
            _loadData();
        }

        public AddUpdateFrm(int id)
        {
            InitializeComponent();
            _contactID = id;
            if(_contactID==-1)
                _mode=enMode.add;
            else _mode=enMode.update;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int countryid = clsCountries.GetCountry(cbCountry.Text).CountryID;
            _contact.FirstName = tbFname.Text;
            _contact.LastName = tbLname.Text;
            _contact.Email = tbEmail.Text;
            _contact.Phone = tbPhone.Text;
            _contact.Address = tbAddress.Text;
            _contact.DateOfBirth = dateTime.Value;
           
                _contact.CountryID = countryid;
            if (_contact.save())
            {
                tbID.Text = _contact.ContactID.ToString();
                MessageBox.Show("Contact saved successfully.", "add/update contact", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Contact not saved.", "add/update contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _mode = enMode.update;
            titleLbl.Text = "Update Contact";



        }


    }
}

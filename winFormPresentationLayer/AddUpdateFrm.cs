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
        public enum enMode { add, update };
        private enMode _mode = enMode.add;
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
            if (_contact == null)
            {
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
            if (_contactID == -1)
                _mode = enMode.add;
            else _mode = enMode.update;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int countryid = clsCountries.GetCountry(cbCountry.Text).CountryID;
            if (string.IsNullOrWhiteSpace(tbFname.Text))
            {
                MessageBox.Show("First name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFname.Focus();
                return;
            }
            _contact.FirstName=tbFname.Text;
            if (string.IsNullOrWhiteSpace(tbLname.Text))
            {
                MessageBox.Show("Last name cannot be empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFname.Focus();
                return;
            }
            _contact.LastName = tbLname.Text;
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Email cannot be empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFname.Focus();
                return;
            }
            _contact.Email = tbEmail.Text;
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFname.Focus();
                return;
            }
            _contact.Phone = tbPhone.Text;
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Address cannot be empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFname.Focus();
                return;
            }
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

        private void validateNotNull(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                e.Cancel = true;
                tb.Focus();
                errorProvider1.SetError(tb, "this field cannot be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, "");
            }
        }

       
    }
}

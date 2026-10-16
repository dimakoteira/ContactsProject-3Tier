using ContactsBusinessLayer;

namespace winFormPresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvListContacts.DataSource = clsContact.GetContacts();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddUpdateFrm frm=new AddUpdateFrm();
            frm.ShowDialog();
            Form1_Load(sender, e);
        }
    }
}

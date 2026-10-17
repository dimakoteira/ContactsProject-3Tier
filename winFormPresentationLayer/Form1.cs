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
            AddUpdateFrm frm = new AddUpdateFrm(-1);
            frm.ShowDialog();
            Form1_Load(sender, e);
        }

        private void dgv_mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = dgvListContacts.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    dgvListContacts.ClearSelection();
                    dgvListContacts.Rows[hit.RowIndex].Selected = true;
                }
                else
                {
                    dgvListContacts.ContextMenuStrip = null;
                    return;
                }
                dgvListContacts.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dgvListContacts.SelectedRows[0];
            AddUpdateFrm frm = new AddUpdateFrm((int)dgvListContacts.SelectedRows[0].Cells["ContactID"].Value);
            frm.ShowDialog();
            Form1_Load(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        { 

            var result = MessageBox.Show(
                "Are you sure you want to delete this contact?",
                "Delete contact",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
            {
                return;
            }

            else
            {
                int id = (int)dgvListContacts.SelectedRows[0].Cells["ContactID"].Value;
                if (clsContact.deleteContact(id))
                    MessageBox.Show("contact deleted successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("contact not deleted ", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1_Load(sender,e);

            }
        }
    }
}

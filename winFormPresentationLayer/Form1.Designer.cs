namespace winFormPresentationLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dgvListContacts = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            btnAddContact = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListContacts).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(379, 41);
            label1.Name = "label1";
            label1.Size = new Size(511, 54);
            label1.TabIndex = 0;
            label1.Text = "Contacts Managment Menu";
            // 
            // dgvListContacts
            // 
            dgvListContacts.AllowUserToAddRows = false;
            dgvListContacts.AllowUserToDeleteRows = false;
            dgvListContacts.AllowUserToOrderColumns = true;
            dgvListContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListContacts.ContextMenuStrip = contextMenuStrip1;
            dgvListContacts.Location = new Point(44, 139);
            dgvListContacts.Name = "dgvListContacts";
            dgvListContacts.ReadOnly = true;
            dgvListContacts.RowHeadersWidth = 51;
            dgvListContacts.Size = new Size(1069, 433);
            dgvListContacts.TabIndex = 1;
            dgvListContacts.MouseDown += dgv_mouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { updateToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(126, 52);
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(125, 24);
            updateToolStripMenuItem.Text = "update";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(125, 24);
            deleteToolStripMenuItem.Text = "delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(1179, 139);
            label2.Name = "label2";
            label2.Size = new Size(122, 28);
            label2.TabIndex = 2;
            label2.Text = "Add Contact";
            // 
            // btnAddContact
            // 
            btnAddContact.FlatStyle = FlatStyle.Flat;
            btnAddContact.ForeColor = Color.Crimson;
            btnAddContact.Location = new Point(1194, 187);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(94, 29);
            btnAddContact.TabIndex = 3;
            btnAddContact.Text = "Add";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1352, 607);
            Controls.Add(btnAddContact);
            Controls.Add(label2);
            Controls.Add(dgvListContacts);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListContacts).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvListContacts;
        private Label label2;
        private Button btnAddContact;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}

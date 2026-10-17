namespace winFormPresentationLayer
{
    partial class AddUpdateFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            titleLbl = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbID = new TextBox();
            tbFname = new TextBox();
            tbPhone = new TextBox();
            tbEmail = new TextBox();
            tbLname = new TextBox();
            dateTime = new DateTimePicker();
            cbCountry = new ComboBox();
            btnClose = new Button();
            btnSave = new Button();
            errorProvider1 = new ErrorProvider(components);
            tbAddress = new TextBox();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLbl.ForeColor = Color.PaleVioletRed;
            titleLbl.Location = new Point(526, 23);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(188, 39);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Add Contact";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(64, 107);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 1;
            label2.Text = "Contact ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(64, 185);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 2;
            label3.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(62, 270);
            label4.Name = "label4";
            label4.Size = new Size(104, 25);
            label4.TabIndex = 3;
            label4.Text = "Last Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(50, 546);
            label5.Name = "label5";
            label5.Size = new Size(118, 25);
            label5.TabIndex = 4;
            label5.Text = "Date of Birth";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(62, 401);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 5;
            label6.Text = "Phone:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.ForeColor = Color.Crimson;
            label7.Location = new Point(50, 618);
            label7.Name = "label7";
            label7.Size = new Size(83, 25);
            label7.TabIndex = 6;
            label7.Text = "Address:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(62, 337);
            label8.Name = "label8";
            label8.Size = new Size(62, 25);
            label8.TabIndex = 7;
            label8.Text = "Email:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.ForeColor = Color.Crimson;
            label9.Location = new Point(62, 481);
            label9.Name = "label9";
            label9.Size = new Size(79, 25);
            label9.TabIndex = 8;
            label9.Text = "Country";
            // 
            // tbID
            // 
            tbID.BackColor = Color.LavenderBlush;
            tbID.Enabled = false;
            tbID.Location = new Point(186, 108);
            tbID.Name = "tbID";
            tbID.Size = new Size(175, 27);
            tbID.TabIndex = 9;
            tbID.Text = "??";
            // 
            // tbFname
            // 
            tbFname.BackColor = Color.LavenderBlush;
            tbFname.Location = new Point(186, 183);
            tbFname.Name = "tbFname";
            tbFname.Size = new Size(175, 27);
            tbFname.TabIndex = 1;
            tbFname.Validating += validateNotNull;
            // 
            // tbPhone
            // 
            tbPhone.BackColor = Color.LavenderBlush;
            tbPhone.Location = new Point(186, 399);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(175, 27);
            tbPhone.TabIndex = 4;
            tbPhone.Validating += validateNotNull;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.LavenderBlush;
            tbEmail.Location = new Point(186, 335);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(175, 27);
            tbEmail.TabIndex = 3;
            tbEmail.Validating += validateNotNull;
            // 
            // tbLname
            // 
            tbLname.BackColor = Color.LavenderBlush;
            tbLname.Location = new Point(186, 268);
            tbLname.Name = "tbLname";
            tbLname.Size = new Size(175, 27);
            tbLname.TabIndex = 2;
            tbLname.Validating += validateNotNull;
            // 
            // dateTime
            // 
            dateTime.CalendarMonthBackground = Color.LavenderBlush;
            dateTime.CalendarTitleBackColor = Color.HotPink;
            dateTime.Location = new Point(186, 546);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(250, 27);
            dateTime.TabIndex = 6;
            // 
            // cbCountry
            // 
            cbCountry.BackColor = Color.LavenderBlush;
            cbCountry.ForeColor = Color.Crimson;
            cbCountry.FormattingEnabled = true;
            cbCountry.Location = new Point(186, 478);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new Size(151, 28);
            cbCountry.TabIndex = 5;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.LavenderBlush;
            btnClose.ForeColor = Color.Crimson;
            btnClose.Location = new Point(653, 678);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 19;
            btnClose.Text = "close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LavenderBlush;
            btnSave.Cursor = Cursors.Hand;
            btnSave.ForeColor = Color.Crimson;
            btnSave.Location = new Point(816, 678);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 20;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // tbAddress
            // 
            tbAddress.BackColor = Color.LavenderBlush;
            tbAddress.Location = new Point(186, 619);
            tbAddress.Multiline = true;
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(175, 79);
            tbAddress.TabIndex = 7;
            tbAddress.Validating += validateNotNull;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(847, 141);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 240);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(845, 105);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(81, 20);
            linkLabel1.TabIndex = 22;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "add image";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(966, 107);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(105, 20);
            linkLabel2.TabIndex = 23;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "remove image";
            linkLabel2.Visible = false;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // AddUpdateFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 764);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
            Controls.Add(tbAddress);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(cbCountry);
            Controls.Add(dateTime);
            Controls.Add(tbLname);
            Controls.Add(tbEmail);
            Controls.Add(tbPhone);
            Controls.Add(tbFname);
            Controls.Add(tbID);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(titleLbl);
            ForeColor = Color.LavenderBlush;
            Name = "AddUpdateFrm";
            Text = "AddUpdateFrm";
            Load += AddUpdateFrm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbID;
        private TextBox tbFname;
        private TextBox tbPhone;
        private TextBox tbEmail;
        private TextBox tbLname;
        private DateTimePicker dateTime;
        private ComboBox cbCountry;
        private Button btnClose;
        private Button btnSave;
        private ErrorProvider errorProvider1;
        private TextBox tbAddress;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private LinkLabel linkLabel2;
    }
}
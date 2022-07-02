namespace MyStoreWinApp
{
    partial class frmMemberDetails
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtEmailDetail = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtPasswordDetail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtMemberNameDetail = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMemberIDDetail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(316, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmailDetail
            // 
            this.txtEmailDetail.Location = new System.Drawing.Point(314, 67);
            this.txtEmailDetail.MaxLength = 50;
            this.txtEmailDetail.Name = "txtEmailDetail";
            this.txtEmailDetail.Size = new System.Drawing.Size(229, 23);
            this.txtEmailDetail.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Location = new System.Drawing.Point(234, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(36, 15);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "Email";
            // 
            // txtPasswordDetail
            // 
            this.txtPasswordDetail.Location = new System.Drawing.Point(314, 106);
            this.txtPasswordDetail.MaxLength = 50;
            this.txtPasswordDetail.Name = "txtPasswordDetail";
            this.txtPasswordDetail.Size = new System.Drawing.Size(229, 23);
            this.txtPasswordDetail.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(234, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(57, 15);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Password";
            // 
            // txtMemberNameDetail
            // 
            this.txtMemberNameDetail.Location = new System.Drawing.Point(314, 145);
            this.txtMemberNameDetail.MaxLength = 50;
            this.txtMemberNameDetail.Name = "txtMemberNameDetail";
            this.txtMemberNameDetail.Size = new System.Drawing.Size(229, 23);
            this.txtMemberNameDetail.TabIndex = 8;
            // 
            // txtMemberName
            // 
            this.txtMemberName.AutoSize = true;
            this.txtMemberName.Location = new System.Drawing.Point(204, 148);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(87, 15);
            this.txtMemberName.TabIndex = 7;
            this.txtMemberName.Text = "Member Name";
            // 
            // txtCity
            // 
            this.txtCity.AutoSize = true;
            this.txtCity.Location = new System.Drawing.Point(242, 196);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(28, 15);
            this.txtCity.TabIndex = 9;
            this.txtCity.Text = "City";
            // 
            // txtCountry
            // 
            this.txtCountry.AutoSize = true;
            this.txtCountry.Location = new System.Drawing.Point(234, 233);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(50, 15);
            this.txtCountry.TabIndex = 11;
            this.txtCountry.Text = "Country";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(456, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMemberIDDetail
            // 
            this.txtMemberIDDetail.Location = new System.Drawing.Point(314, 29);
            this.txtMemberIDDetail.MaxLength = 50;
            this.txtMemberIDDetail.Name = "txtMemberIDDetail";
            this.txtMemberIDDetail.Size = new System.Drawing.Size(229, 23);
            this.txtMemberIDDetail.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "MemberID";
            // 
            // cboCity
            // 
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Items.AddRange(new object[] {
            "Ho Chi Minh",
            "Ha Noi",
            "Hai Phong",
            "Da Nang",
            "Vinh",
            "Can Tho",
            "Binh Phuoc"});
            this.cboCity.Location = new System.Drawing.Point(314, 193);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(229, 23);
            this.cboCity.TabIndex = 16;
            // 
            // cboCountry
            // 
            this.cboCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "Viet Nam",
            "Laos",
            "Thailand",
            "Malaysia",
            "China",
            "Japan",
            "Korea"});
            this.cboCountry.Location = new System.Drawing.Point(314, 230);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(229, 23);
            this.cboCountry.TabIndex = 17;
            // 
            // frmMemberDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.cboCity);
            this.Controls.Add(this.txtMemberIDDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtMemberNameDetail);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.txtPasswordDetail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmailDetail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmMemberDetails";
            this.Text = "frmMemberDetails";
            this.Load += new System.EventHandler(this.frmMemberDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancel;
        private TextBox txtEmailDetail;
        private Label txtEmail;
        private TextBox txtPasswordDetail;
        private Label txtPassword;
        private TextBox txtMemberNameDetail;
        private Label txtMemberName;
        private Label txtCity;
        private Label txtCountry;
        private Button btnSave;
        private TextBox txtMemberIDDetail;
        private Label label1;
        private ComboBox cboCity;
        private ComboBox cboCountry;
    }
}
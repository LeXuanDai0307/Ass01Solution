﻿using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {


        public frmLogin()
        {
            InitializeComponent();
        }

        public IMemberRepository MemberRepository { get; set; }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                IMemberRepository memberRepository = new MemberRepository();
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                MemberObject member = memberRepository.Login(email, password);
                MessageBox.Show("Login successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
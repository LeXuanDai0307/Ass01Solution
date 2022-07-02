using Ass01Solution.BusinessObject;
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
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                IMemberRepository memberRepository = new MemberRepository();
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                MemberObject member = memberRepository.Login(email, password);
                if (member != null)
                {
                    this.Hide();
                    if (("admin").Equals(member.Email))
                    {
                        frmMemberManagements frmManagements = new frmMemberManagements();
                        DialogResult result = frmManagements.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            this.Close();
                        }
                        if (result == DialogResult.TryAgain)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        frmMemberDetails frmMemberDetails = new frmMemberDetails
                        {
                            Text = "Update Profile",
                            Action = "UPDATE",
                            Member = member,
                            MemberRepository = memberRepository,
                        };
                        if (frmMemberDetails.ShowDialog() == DialogResult.OK)
                        {
                            this.Show();
                        }
                    }
                } else
                {
                    MessageBox.Show("Wrong your's email or password. Try again!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

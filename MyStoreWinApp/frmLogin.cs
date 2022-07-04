using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;
using Microsoft.Extensions.Configuration;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        private readonly string _adminMail = "admin@fstore.com";

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
                    if ((_adminMail).Equals(member.Email))
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
            string defaultEmail;
            string defaultPassword;
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            defaultEmail = config["UserSettings:Email"];
            defaultPassword = config["UserSettings:Password"];

            txtEmail.Text = defaultEmail;
            txtPassword.Text = defaultPassword;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

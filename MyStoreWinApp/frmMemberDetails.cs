using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;


namespace MyStoreWinApp
{
    public partial class frmMemberDetails : Form
    {
        public frmMemberDetails()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public string Action { get; set; }

        public MemberObject Member { get; set; }

        private bool WithErrors()
        {
            if (txtEmailDetail.Text.Trim() == String.Empty)
                return true;
            if (txtPasswordDetail.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                MessageBox.Show("Email and Password do not allow empty.");
            }
            else
            {
                try
                {
                    var member = new MemberObject
                    {
                        MemberID = int.Parse(txtMemberIDDetail.Text),
                        MemberName = txtMemberNameDetail.Text,
                        Email = txtEmailDetail.Text,
                        Password = txtPasswordDetail.Text,
                        City = cboCity.Text,
                        Country = cboCountry.Text,
                    };
                    if ("UPDATE".Equals(Action))
                    {

                        MemberRepository.UpdateMember(member);
                        MessageBox.Show("Update a member successfully.");
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    if ("CREATE".Equals(Action))
                    {
                        MemberRepository.CreateMember(member);
                        MessageBox.Show("Create a new member successfully.");
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + Action + " member.");
                }
            }

        }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberIDDetail.Enabled = false;
            if ("UPDATE".Equals(Action))
            {
                txtMemberIDDetail.Text = Member.MemberID.ToString();
                txtMemberNameDetail.Text = Member.MemberName;
                txtEmailDetail.Text = Member.Email;
                txtPasswordDetail.Text = Member.Password;
                cboCity.Text = Member.City;
                cboCountry.Text = Member.Country;

                if ("admin".Equals(Member.Email))
                {
                    txtEmailDetail.Enabled = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

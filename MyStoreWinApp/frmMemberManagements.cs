using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmMemberManagements : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;

        public frmMemberManagements()
        {
            InitializeComponent();
        }

        private void frmMemberManagements_Load(object sender, EventArgs e)
        {
            LoadMemberList();
            dgvMemberList.CellDoubleClick += DvgMemberList_CellDoubleClick;
        }

        private void DvgMemberList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Update Member",
                Action = "UPDATE",
                Member = GetMemberObject(),
                MemberRepository = memberRepository,
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject()
                {
                    MemberID = int.Parse(txtMemberID.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GetMemberObject");
            }
            return member;
        }

        private void LoadMemberList()
        {
            var memberList = memberRepository.GetMembers();
            try
            {
                source = new BindingSource();
                source.DataSource = memberList;

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();

                txtMemberID.DataBindings.Add("Text", source, "MemberID");
                txtMemberName.DataBindings.Add("Text", source, "MemberName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (memberList.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    btnFilter.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                    btnSearch.Enabled = true;
                    btnFilter.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " LoadMemberList");
            }
        }

        private void ClearText()
        {
            txtMemberID.Text = "";
            txtMemberName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetails frmMemberDetails = new frmMemberDetails
            {
                Text = "Create New Member",
                Action = "CREATE",
                MemberRepository = memberRepository,
            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                if ("admin".Equals(member.Email))
                {
                    MessageBox.Show("Delete failed! You are Admin.");
                } else
                {
                    memberRepository.DeleteMember(member.MemberID);
                    LoadMemberList();
                    source.Position = source.Count - 1;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Delete member");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

       
    }
}

using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmMemberManagements : Form
    {
        private readonly string _adminMail = "admin@fstore.com";

        IMemberRepository memberRepository = new MemberRepository();
        BindingSource source;

        public frmMemberManagements()
        {
            InitializeComponent();
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

        private IEnumerable<MemberObject> SortMembersByName(IEnumerable<MemberObject> memberList)
        {
            var result = memberList;
            if (memberList.Count() != 0)
            {
                result = memberList.OrderByDescending(x => x.MemberName).ToList();
            }
            return result;
        }

        private void BindingDataGridViewSource(IEnumerable<MemberObject> memberList)
        {
            try
            {
                source = new BindingSource();
                source.DataSource = SortMembersByName(memberList);
                dgvMemberList.DataSource = null;

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                if (memberList.Count() != 0)
                {
                    txtMemberID.DataBindings.Add("Text", source, "MemberID");
                    txtMemberName.DataBindings.Add("Text", source, "MemberName");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtPassword.DataBindings.Add("Text", source, "Password");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtCountry.DataBindings.Add("Text", source, "Country");

                    dgvMemberList.DataSource = source;
                    btnDelete.Enabled = true;
                    btnSearch.Enabled = true;
                    btnFilter.Enabled = true;
                }
                else
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    btnSearch.Enabled = false;
                    btnFilter.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " LoadMemberList");
            }
        }

        private void LoadMemberList()
        {
            var memberList = memberRepository.GetMembers();
            BindingDataGridViewSource(memberList);
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

        private void frmMemberManagements_Load(object sender, EventArgs e)
        {
            cboCityFilter.SelectedIndex = 0;
            cboCountryFilter.SelectedIndex = 0;
            LoadMemberList();
            dgvMemberList.CellDoubleClick += DvgMemberList_CellDoubleClick;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            cboCityFilter.SelectedIndex = 0;
            cboCountryFilter.SelectedIndex = 0;
            txtSearch.Text = String.Empty;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                if (_adminMail.Equals(member.Email))
                {
                    MessageBox.Show("Delete failed! You are Admin.");
                }
                else
                {
                    memberRepository.DeleteMember(member.MemberID);
                    LoadMemberList();
                    source.Position = source.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Delete member");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.TryAgain;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var memberList = memberRepository.GetMembers();
            // Search
            string keyWord = txtSearch.Text;
            var result = memberList.Where(q => q.MemberID.ToString().Contains(keyWord) || q.MemberName.ToLower().Contains(keyWord.ToLower()));
            // Filter
            string cityFilter = cboCityFilter.Text.Equals("All Cities") ? String.Empty : cboCityFilter.Text;
            string countryFilter = cboCountryFilter.Text.Equals("All Countries") ? String.Empty : cboCountryFilter.Text;
            if (cityFilter != String.Empty || countryFilter != String.Empty)
            {
                result = result.Where(q => q.City.Contains(cityFilter) && q.Country.Contains(countryFilter));
            }

            BindingDataGridViewSource(result);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var memberList = memberRepository.GetMembers();
            // Filter
            string cityFilter = cboCityFilter.Text.Equals("All Cities") ? String.Empty : cboCityFilter.Text;
            string countryFilter = cboCountryFilter.Text.Equals("All Countries") ? String.Empty : cboCountryFilter.Text;
            var result = memberList.Where(q => q.City.Contains(cityFilter) && q.Country.Contains(countryFilter));
            // Search
            string keyWord = txtSearch.Text;
            if (keyWord != String.Empty)
            {
                result = result.Where(q => q.MemberID.ToString().Contains(keyWord) || q.MemberName.ToLower().Contains(keyWord.ToLower()));
            }

            BindingDataGridViewSource(result);
        }
    }
}

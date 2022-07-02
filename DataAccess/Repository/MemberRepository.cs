using Ass01Solution.BusinessObject;
using Ass01Solution.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01Solution.DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject Login(string email, string password) => MemberDAO.Instance.Login(email, password);

        public MemberObject GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();

        public void CreateMember(MemberObject member) => MemberDAO.Instance.Create(member);

        public void UpdateMember(MemberObject member) => MemberDAO.Instance.Update(member);

        public void DeleteMember(int memberID) => MemberDAO.Instance.Remove(memberID);
    }
}

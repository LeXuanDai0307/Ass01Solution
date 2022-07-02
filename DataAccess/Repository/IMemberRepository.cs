

using Ass01Solution.BusinessObject;

namespace Ass01Solution.DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject Login(string email, string password);
        MemberObject GetMemberByID(int memberID);
        void CreateMember(MemberObject member);
        void UpdateMember(MemberObject member);
        void DeleteMember(int memberID);

    }
}

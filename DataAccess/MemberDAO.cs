using Ass01Solution.BusinessObject;
using Microsoft.Data.SqlClient;

using System.Data;


namespace Ass01Solution.DataAccess
{
    public class MemberDAO : BaseDAL
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<MemberObject> GetMemberList()
        {
            IDataReader? dataReader = null;
            var members = new List<MemberObject>();
            try
            {
                string SQLSelect = "SELECT MemberID, MemberName, Email, Password, City, Country from Members";
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    members.Add(new MemberObject
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),

                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Get Member List");
            }
            finally
            {
                dataReader.Close();
                dataProvider.CloseConnecttion(connection);
            }
            return members;
        }

        public MemberObject Login(string email, string password)
        {
            MemberObject member = null;
            IDataReader dataReader = null;
            try
            {
                string SQLSelect = "SELECT MemberID, MemberName, Email, Password, City, Country FROM Members WHERE Email=@Email AND Password=@Password";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@Email", 50, email, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@Password", 50, password, DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    member = new MemberObject
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Get Member By ID");
            }
            finally
            {
                dataReader?.Close();
                dataProvider.CloseConnecttion(connection);
            }
            return member;

        }

        public MemberObject GetMemberByID(int memberID)
        {
            MemberObject member = null;
            IDataReader dataReader = null;
            try
            {
                string SQLSelect = "SELECT MemberID, MemberName, Email, Password, City, Country FROM Members WHERE MemberID = @MemberID";
                var param = dataProvider.CreateParameter("@MemberID", 4, memberID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    member = new MemberObject
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Login failed");
            }
            finally
            {
                dataReader?.Close();
                dataProvider.CloseConnecttion(connection);
            }
            return member;
        }

        public void Create(MemberObject newMember)
        {
            try
            {
                MemberObject member = GetMemberByID(newMember.MemberID);
                string defaultPassword = "123456";
                if (member == null)
                {
                    string SQLInsert = "INSERT Members VALUES(@MemberID, @MemberName, @Email, @Password, @City, @Country)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 4, newMember.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberName", 50, newMember.MemberName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, newMember.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, defaultPassword, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, newMember.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, newMember.Country, DbType.String));
                    dataProvider.ExcuteQuerry(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The member already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Create new member");
            }
            finally
            {
                dataProvider.CloseConnecttion(connection);
            }
        }

        public void Update(MemberObject member)
        {
            try
            {
                MemberObject mem = GetMemberByID(member.MemberID);
                if (member != null)
                {
                    string SQLUpdate = "UPDATE Members SET MemberName=@MemberName, Email=@Email, Password=@Password, City=@City, Country=@Country WHERE MemberID=@MemberID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberName", 50, member.MemberName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Email", 50, member.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, member.Password, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, member.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, member.Country, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 4, member.MemberID, DbType.Int32));
                    dataProvider.ExcuteQuerry(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Update a member");
            }
            finally
            {
                dataProvider.CloseConnecttion(connection);
            }
        }

        public void Remove(int memberID)
        {
            try
            {
                MemberObject member = GetMemberByID(memberID);
                if (member != null)
                {
                    string SQLDelete = "DELETE Members WHERE MemberID=@MemberID";
                    var param = dataProvider.CreateParameter("@MemberID", 4, memberID, DbType.Int32);
                    dataProvider.ExcuteQuerry(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Remove a member");
            }
            finally
            {
                dataProvider.CloseConnecttion(connection);
            }
        }


    }
}

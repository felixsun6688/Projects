using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AorangiPeak.Infrastructure.ADORepository
{
    /// <summary>
    /// User Repository Class
    /// </summary>
    public class AdoUserRepository : IUserRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoUserRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        #region query methods
        public IQueryable<User> FindAll()
        {
            List<User> users = new List<User>();

            string sql = "SELECT RowID, UserName, UserPwd, Email, RoleRowID, CreateTime, Status "
                           + "FROM [AP_Users]";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                User user = new User(new Guid(sdr["RowID"].ToString()),
                                          new Guid(sdr["RoleRowID"].ToString()),
                                          sdr["UserName"].ToString(),
                                          sdr["UserPwd"].ToString(),
                                          sdr["Email"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (UserStatus)Convert.ToInt32(sdr["Status"]));
                users.Add(user);
            }
            sdr.Close();
            return users.AsQueryable();
        }

        public IQueryable<User> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public User FindBy(Guid key)
        {
            User user = null;

            string sql = "SELECT TOP 1  UserName, UserPwd, Email, RoleRowID, CreateTime, Status "
                           + "FROM [AP_Users] "
                           + "WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", key) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                user = new User(key,
                                          new Guid(sdr["RoleRowID"].ToString()),
                                          sdr["UserName"].ToString(),
                                          sdr["UserPwd"].ToString(),
                                          sdr["Email"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (UserStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return user;
        }

        public User FindBy(string name)
        {
            User user = null;

            string sql = "SELECT TOP 1  RowID, UserPwd, Email, RoleRowID, CreateTime, Status "
                           + "FROM [AP_Users] "
                           + "WHERE UserName = @name";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@name", name) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                user = new User(new Guid(sdr["RowID"].ToString()),
                                          new Guid(sdr["RoleRowID"].ToString()),
                                          name,
                                          sdr["UserPwd"].ToString(),
                                          sdr["Email"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (UserStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return user;
        }

        #endregion

        #region modify methods
        public void Add(User user)
        {
            _context.RegisterNew(user, this);
        }

        public void Save(User user)
        {
            _context.RegisterAmended(user, this);
        }

        public void Remove(User user)
        {
            _context.RegisterRemoved(user, this);
        }
        #endregion

        #region persist methods
        public void PersistCreationOf(IAggregateRoot aggregateRoot)
        {
            User user = aggregateRoot as User;

            string sql = "INSERT INTO [AP_Users] (UserName, UserPwd, Email, RoleRowID, CreateTime, Status, RowID) "
                + "VALUES (@uname, @pwd, @email, @rid, @createtime, @status, @id)";

            SqlParameter[] sp = new SqlParameter[] {
                                            new SqlParameter("@uname", user.Username),
                                            new SqlParameter("@pwd", user.Userpwd),
                                            new SqlParameter("@email", user.Email),
                                            new SqlParameter("@rid", user.RoleId),
                                            new SqlParameter("@createtime", user.Createtime),
                                            new SqlParameter("@status", user.Status),
                                            new SqlParameter("@id", user.Id)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistDeletionOf(IAggregateRoot aggregateRoot)
        {
            User user = aggregateRoot as User;

            string sql = "UPDATE [AP_Users] SET Status = 2 WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@id", user.Id)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistUpdateOf(IAggregateRoot aggregateRoot)
        {
            User user = aggregateRoot as User;

            string sql = "UPDATE [AP_Users] SET UserName = @name, UserPwd=@pwd, Email=@email, "
                            + "RoleRowID = @rid, Status = @status WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@name", user.Username),
                new SqlParameter("@pwd", user.Userpwd),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@id", user.Id),
                new SqlParameter("@rid", user.RoleId),
                new SqlParameter("@status", user.Status)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }
        #endregion      
    }
}

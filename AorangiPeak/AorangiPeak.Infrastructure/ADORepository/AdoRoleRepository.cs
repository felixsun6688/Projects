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
    /// Role Repository Class
    /// </summary>
    public class AdoRoleRepository : IRoleRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoRoleRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        #region query methods
        public IQueryable<Role> FindAll()
        {
            List<Role> roles = new List<Role>();
            string sql = "SELECT RoleName, CreateTime, Status, RowID FROM [AP_Roles]";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                Role role = new Role(new Guid(sdr["RowID"].ToString()),
                                                sdr["RoleName"].ToString(),
                                                Convert.ToDateTime(sdr["CreateTime"]),
                                                (RoleStatus)Convert.ToInt32(sdr["Status"]));

                roles.Add(role);
            }
            sdr.Close();
            return roles.AsQueryable();
        }

        public IQueryable<Role> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public Role FindBy(Guid key)
        {
            Role role = null;

            string sql = "SELECT TOP 1  RoleName,  CreateTime, Status "
                           + "FROM [AP_Roles] "
                           + "WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", key) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                role = new Role(key,
                                          sdr["RoleName"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (RoleStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return role;
        }

        public Role FindBy(string name)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region modify methods
        public void Add(Role role)
        {
            _context.RegisterNew(role, this);
        }

        public void Save(Role role)
        {
            _context.RegisterAmended(role, this);
        }

        public void Remove(Role role)
        {
            _context.RegisterRemoved(role, this);
        }
        #endregion

        #region persist methods
        public void PersistCreationOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

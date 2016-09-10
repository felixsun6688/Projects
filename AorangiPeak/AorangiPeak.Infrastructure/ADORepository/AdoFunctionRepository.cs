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
    public class AdoFunctionRepository : IFunctionRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoFunctionRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        public IQueryable<Function> FindAll()
        {
            List<Function> functions = new List<Function>();
            string sql = "SELECT * FROM [AP_Functions] WHERE Status<>2";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                Function function = new Function(new Guid(sdr["RowID"].ToString()),
                                                sdr["Name"].ToString(),
                                                sdr["Img1"].ToString(),
                                                sdr["Intro"].ToString(),
                                                sdr["Content"].ToString(),
                                                (FunctionStatus)Convert.ToInt32(sdr["Status"]));

                functions.Add(function);
            }
            sdr.Close();
            return functions.AsQueryable();
        }

        public IQueryable<Function> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public Function FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public Function FindBy(Guid key)
        {
            Function function = null;

            string sql = "SELECT TOP 1  Name, Img1, Intro, Content, Status "
                           + "FROM [AP_Functions] "
                           + "WHERE RowID = @id";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", key) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                function = new Function(key,
                                                sdr["Name"].ToString(),
                                                sdr["Img1"].ToString(),
                                                sdr["Intro"].ToString(),
                                                sdr["Content"].ToString(),
                                                (FunctionStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return function;
        }

        public void Add(Function aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(Function aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(Function aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void PersistCreationOf(IAggregateRoot root)
        {
            Function func = root as Function;
            string sql = "INSERT INTO [AP_Functions] (Name, Img1, Intro, Content, Status, RowID) "
                            + "VALUES (@name,@img1,@intro,@content,@status,@rid)";
            SqlParameter[] sp = new SqlParameter[]
                                                  {
                                                      new SqlParameter("@name", func.Functionname),
                                                      new SqlParameter("@img1", func.Firstimg),
                                                      new SqlParameter("@intro", func.Introduction),
                                                      new SqlParameter("@content", func.Content),
                                                      new SqlParameter("@status", func.Status),
                                                      new SqlParameter("@rid", func.Id)
                                                  };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            Function func = root as Function;
            string sql = "UPDATE [AP_Functions]  SET Name = @name, Img1 = @img1, "
                             + "Intro = @intro, Content = @content, Status = @status "
                             + "WHERE RowID = @rid";
            SqlParameter[] sp = new SqlParameter[]
                                                  {
                                                      new SqlParameter("@name", func.Functionname),
                                                      new SqlParameter("@img1", func.Firstimg),
                                                      new SqlParameter("@intro", func.Introduction),
                                                      new SqlParameter("@content", func.Content),
                                                      new SqlParameter("@status", func.Status),
                                                      new SqlParameter("@rid", func.Id)
                                                  };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            Function func = root as Function;
            string sql = "UPDATE [AP_Functions] SET Status = 2 WHERE RowID = @rid";
            SqlParameter[] sp = new SqlParameter[] {
                   new SqlParameter("@rid", func.Id)
            };
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }
    }
}

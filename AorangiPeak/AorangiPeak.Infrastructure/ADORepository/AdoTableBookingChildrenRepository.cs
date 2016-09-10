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
    public class AdoTableBookingChildrenRepository : ITableBookingChildrenRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        public AdoTableBookingChildrenRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }

        public void Add(TableBookingChildren aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(TableBookingChildren aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(TableBookingChildren aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TableBookingChildren> FindAll()
        {
            List<TableBookingChildren> children = new List<TableBookingChildren>();

            string sql = "SELECT RowID, Value, [Text], [Order] "
                           + "FROM [AP_TableBookingChildren]";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                TableBookingChildren child = new TableBookingChildren(new Guid(sdr["RowID"].ToString()),
                                          sdr["Value"].ToString(),
                                          sdr["Text"].ToString(),
                                          Convert.ToInt32(sdr["Order"]));
                children.Add(child);
            }
            sdr.Close();
            return children.AsQueryable();
        }

        public IQueryable<TableBookingChildren> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public TableBookingChildren FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public TableBookingChildren FindBy(Guid key)
        {
            throw new NotImplementedException();
        }

        public void PersistCreationOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            throw new NotImplementedException();
        }
    }
}

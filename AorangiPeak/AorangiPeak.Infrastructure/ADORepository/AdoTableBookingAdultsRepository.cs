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
    public class AdoTableBookingAdultsRepository : ITableBookingAdultsRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        public AdoTableBookingAdultsRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }

        public void Add(TableBookingAdults aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(TableBookingAdults aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(TableBookingAdults aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TableBookingAdults> FindAll()
        {
            List<TableBookingAdults> adults = new List<TableBookingAdults>();

            string sql = "SELECT RowID, Value, [Text], [Order] "
                           + "FROM [AP_TableBookingAdults]";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                TableBookingAdults adult = new TableBookingAdults(new Guid(sdr["RowID"].ToString()),
                                          sdr["Value"].ToString(),
                                          sdr["Text"].ToString(),
                                          Convert.ToInt32(sdr["Order"]));
                adults.Add(adult);
            }
            sdr.Close();
            return adults.AsQueryable();
        }

        public IQueryable<TableBookingAdults> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public TableBookingAdults FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public TableBookingAdults FindBy(Guid key)
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

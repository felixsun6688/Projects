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
    public class AdoTableBookingTimeRepository : ITableBookingTimeRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        public AdoTableBookingTimeRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }

        public void Add(TableBookingTime aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Remove(TableBookingTime aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Save(TableBookingTime aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TableBookingTime> FindAll()
        {
            List<TableBookingTime> times = new List<TableBookingTime>();

            string sql = "SELECT RowID, TimeValue, TimeText, Season, TimeOrder "
                           + "FROM [AP_TableBookingTime]";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                TableBookingTime time = new TableBookingTime(new Guid(sdr["RowID"].ToString()),
                                          sdr["TimeValue"].ToString(),
                                          sdr["TimeText"].ToString(),
                                          sdr["Season"].ToString(),
                                          Convert.ToInt32(sdr["TimeOrder"]));
                times.Add(time);
            }
            sdr.Close();
            return times.AsQueryable();
        }

        public IQueryable<TableBookingTime> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public TableBookingTime FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public TableBookingTime FindBy(Guid key)
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

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
    public class AdoTableBookingRepository : ITableBookingRepository, IUnitOfWorkRepository
    {
        #region private fields
        private readonly IAdoRepositoryContext _context;
        private readonly SqlConnection _connection;
        #endregion

        #region constructor
        public AdoTableBookingRepository(IAdoRepositoryContext context)
        {
            _context = context;
            _connection = context.CreateConnection();
        }
        #endregion

        public void Add(TableBooking booking)
        {
            _context.RegisterNew(booking, this);
        }

        public void Save(TableBooking booking)
        {
            _context.RegisterAmended(booking, this);
        }

        public void Remove(TableBooking booking)
        {
            _context.RegisterRemoved(booking, this);
        }

        public IQueryable<TableBooking> FindAll()
        {
            List<TableBooking> bookings = new List<TableBooking>();

            string sql = "SELECT RowID, BookingNumber, NumberOfAdults, NumberOfChildren, BookingDate, FirstName, "
                            + "LastName, PhoneNumber, Email, Request, CreateTime, Status "
                            +"FROM [AP_TableBookings] "
                            + "WHERE Status<>99";
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql);
            while (sdr.Read())
            {
                TableBooking booking = new TableBooking(new Guid(sdr["RowID"].ToString()),
                                          sdr["BookingNumber"].ToString(),
                                          sdr["NumberOfAdults"].ToString(),
                                          sdr["NumberOfChildren"].ToString(),
                                          Convert.ToDateTime(sdr["BookingDate"]),
                                          sdr["FirstName"].ToString(),
                                          sdr["LastName"].ToString(),
                                          sdr["PhoneNumber"].ToString(),
                                          sdr["Email"].ToString(),
                                          sdr["Request"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (TableBookingStatus)Convert.ToInt32(sdr["Status"]));
                bookings.Add(booking);
            }
            sdr.Close();
            return bookings.AsQueryable();
        }

        public IQueryable<TableBooking> FindAll(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public TableBooking FindBy(string name)
        {
            throw new NotImplementedException();
        }

        public TableBooking FindBy(Guid key)
        {
            TableBooking booking = null;

            string sql = "SELECT TOP 1  BookingDate, FirstName, LastName, PhoneNumber, Email, Request, "
                           + "CreateTime, Status, BookingNumber, NumberOfAdults, NumberOfChildren "
                           + "FROM [AP_TableBookings] "
                           + "WHERE RowID = @id AND Status<>99";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@id", key) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql, sp);
            while (sdr.Read())
            {
                booking = new TableBooking(key,
                                          sdr["BookingNumber"].ToString(),
                                          sdr["NumberOfAdults"].ToString(),
                                          sdr["NumberOfChildren"].ToString(),
                                          Convert.ToDateTime(sdr["BookingDate"]),
                                          sdr["FirstName"].ToString(),
                                          sdr["LastName"].ToString(),
                                          sdr["PhoneNumber"].ToString(),
                                          sdr["Email"].ToString(),
                                          sdr["Request"].ToString(),
                                          Convert.ToDateTime(sdr["CreateTime"]),
                                          (TableBookingStatus)Convert.ToInt32(sdr["Status"]));
            }
            sdr.Close();

            return booking;
        }

        public void PersistCreationOf(IAggregateRoot root)
        {
            TableBooking booking = root as TableBooking;

            string sql = "INSERT INTO [AP_TableBookings] (NumberOfAdults, NumberOfChildren, BookingDate, FirstName, "
                + "LastName, PhoneNumber, Email, Request, CreateTime, BookingNumber, Status, RowID) "
                + "VALUES (@numofadults, @numofchildren, @bookingdate, @firstname, @lastname, @phonenum, @email,"
                + " @request, @createtime, @bookingnum, @status, @rid)";

            SqlParameter[] sp = new SqlParameter[] {
                                            new SqlParameter("@numofadults", booking.Numberofadults),
                                            new SqlParameter("@numofchildren", booking.Numberofchildren),
                                            new SqlParameter("@bookingdate", booking.Bookingdate),
                                            new SqlParameter("@firstname", booking.Firstname),
                                            new SqlParameter("@lastname", booking.Lastname),
                                            new SqlParameter("@phonenum", booking.Phonenumber),
                                            new SqlParameter("@email", booking.Email),
                                            new SqlParameter("@request", booking.Request),
                                            new SqlParameter("@createtime", booking.Createtime),
                                            new SqlParameter("@bookingnum", booking.Bookingnumber),
                                            new SqlParameter("@status", booking.Status),
                                            new SqlParameter("@rid", booking.Id)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistUpdateOf(IAggregateRoot root)
        {
            TableBooking booking = root as TableBooking;

            string sql = "UPDATE [AP_TableBookings] SET NumberOfAdults = @numofadults, NumberOfChildren = @numofchildren, BookingDate = @bookingdate, "
                + "FirstName = @firstname, LastName = @lastname, PhoneNumber = @phonenum, Email = @email, Request = @request, "
                + "Status = @status WHERE RowID =  @rid";

            SqlParameter[] sp = new SqlParameter[] {
                                            new SqlParameter("@numofadults", booking.Numberofadults),
                                            new SqlParameter("@numofchildren", booking.Numberofchildren),
                                            new SqlParameter("@bookingdate", booking.Bookingdate),
                                            new SqlParameter("@firstname", booking.Firstname),
                                            new SqlParameter("@lastname", booking.Lastname),
                                            new SqlParameter("@phonenum", booking.Phonenumber),
                                            new SqlParameter("@email", booking.Email),
                                            new SqlParameter("@request", booking.Request),
                                            new SqlParameter("@status", booking.Status),
                                            new SqlParameter("@rid", booking.Id)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }

        public void PersistDeletionOf(IAggregateRoot root)
        {
            TableBooking booking = root as TableBooking;
            string sql = "UPDATE [AP_TableBookings] SET Status = 99 WHERE RowID =  @rid";

            SqlParameter[] sp = new SqlParameter[] {
                                            new SqlParameter("@rid", booking.Id)
            };

            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql, sp);
        }
    }
}

using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class TableBooking : AggregateRootBase
    {
        public string Bookingnumber { get; private set; }
        public string Numberofadults { get; private set; }
        public string Numberofchildren { get; private set; }
        public DateTime Bookingdate { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Phonenumber { get; private set; }
        public string Email { get; private set; }
        public string Request { get; private set; }
        public DateTime Createtime { get; private set; }
        public TableBookingStatus Status { get; set; }

        public TableBooking(Guid id, string bookingnumber, string numberofadults, string numberofchildren, DateTime bookingdate, 
            string firstname, string lastname, string phonenumber,string email, string request,
            DateTime createtime, TableBookingStatus status)
        {
            this.Id = id;
            this.Bookingnumber = bookingnumber;
            this.Numberofadults = numberofadults;
            this.Numberofchildren = numberofchildren;
            this.Bookingdate = bookingdate;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Phonenumber = phonenumber;
            this.Email = email;
            this.Request = request;
            this.Createtime = createtime;
            this.Status = status;
        }

        public TableBooking(Guid id)
        {
            this.Id = id;
        }

        #region override methods
        public override bool Equals(Object obj)
        {
            bool equalObjects = false;
            if (obj != null && this.GetType() == obj.GetType())
            {
                TableBooking booking = (TableBooking)obj;
                equalObjects = this.Id.Equals(booking.Id);
            }

            return equalObjects;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}

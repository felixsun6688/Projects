using System;

namespace AorangiPeak.Dto.TableBookingDto
{
    public class TableBookingBriefDto : IOutputDto
    {
        public string Bookingnumber { get; set; }
        public string Numberofadults { get; set; }
        public string Numberofchildren { get; set; }
        public string Bookingdate { get; set; }
        public string Bookingtime { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Request { get; set; }
        public string Status { get; set; }
        public Guid Id { get; set; }
    }
}

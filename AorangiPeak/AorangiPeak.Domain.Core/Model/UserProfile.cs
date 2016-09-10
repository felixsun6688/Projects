using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.ValueObjct;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    /// <summary>
    /// User Profile Model
    /// </summary>
    public class UserProfile : AggregateRootBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime Birthday { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public string PhotoUrl { get; private set; }
        public UserStatus Status { get; private set; }
        public Guid UserId { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <param name="phonenumber"></param>
        /// <param name="address"></param>
        /// <param name="photourl"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        public UserProfile(string firstname, string lastname, 
                                   Gender gender, DateTime birthday,
                                   string phonenumber, Address address, 
                                   string photourl, UserStatus status, Guid userid)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Birthday = birthday;
            this.PhoneNumber = phonenumber;
            this.Address = address;
            this.PhotoUrl = photourl;
            this.Status = status;
            this.UserId = userid;
        }
    }
}

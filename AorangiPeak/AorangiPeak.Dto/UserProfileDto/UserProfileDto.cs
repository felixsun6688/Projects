using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.ValueObjct;
using System;

namespace AorangiPeak.Dto.UserProfileDto
{
    public class UserProfileDto : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set;}
        public string Phonenumber { get; set; }
        public Address Address { get; set; }
        public string Photourl { get; set; }
        public UserStatus Status { get; set; }

        public Guid Userid { get; set; }
    }
}

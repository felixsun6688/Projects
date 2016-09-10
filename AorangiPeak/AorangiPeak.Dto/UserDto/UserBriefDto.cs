using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Dto.UserDto
{
    /// <summary>
    /// UserBriefDto for list of users
    /// </summary>
    public class UserBriefDto : IOutputDto
    {
        public string Username { get; set; }
        public DateTime Createtime { get; set; }
        public string Userpwd { get; set; }
        public string Email { get; set; }
        public string Rolename { get; set; }
        public UserStatus Status { get; set; }

        public Guid Id { get; set; }
    }
}

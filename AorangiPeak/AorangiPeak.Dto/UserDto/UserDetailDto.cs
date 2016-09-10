using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Dto.UserDto
{
    /// <summary>
    /// UserDetailDto for displaying and editing details of user
    /// </summary>
    public class UserDetailDto : IDto
    {
        public string Username { get; set; }
        public string Createtime { get; set; }
        public string Email { get; set; }
        public string Rolename { get; set; }
        public UserStatus Status { get; set; }
        public string Userpwd { get; set; }
        public string Confirmpwd { get; set; }

        public Guid Id { get; set; }
        public Guid Roleid { get; set; }
    }
}

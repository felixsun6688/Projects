using System;

namespace AorangiPeak.Dto.UserDto
{
    /// <summary>
    /// NewUserDto for creating a new user
    /// </summary>
    public class NewUserDto : IInputDto
    {
        public string Username { get; set; }
        public string Userpwd { get; set; }
        public string Confirmpwd { get; set; }
        public string Email { get; set; }
        public Guid Roleid { get; set; }
    }
}

using FluentValidation.Attributes;

namespace AorangiPeak.Dto.UserDto
{
    /// <summary>
    /// LoginUserDto for login of user
    /// </summary>
    [Validator(typeof(LoginUserValidator))]
    public class LoginUserDto : IInputDto
    {
        public string Username { get; set; }
        public string Userpwd { get; set; }
    }
}

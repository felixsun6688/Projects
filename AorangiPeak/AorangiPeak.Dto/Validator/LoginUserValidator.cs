using FluentValidation;

namespace AorangiPeak.Dto.UserDto
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(user=>user.Username).NotEmpty().WithMessage("Please enter user name"); 
            RuleFor(user=>user.Userpwd).NotEmpty().WithMessage("Please enter password");
            //RuleFor(user => user.Userpwd).Length(6).WithMessage("Password is at least 6 characters");
        }
    }
}

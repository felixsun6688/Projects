using AorangiPeak.Dto.UserDto;
using FluentValidation;

namespace AorangiPeak.Dto.Validator
{
    public class NewUserValidator : AbstractValidator<NewUserDto>
    {
        public NewUserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("This field is required.");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(user => user.Username).NotEmpty().WithMessage("This field is required.");
            RuleFor(user => user.Username).Length(6,10).WithMessage("Please enter a value between 6 and 20 characters long.");
            //RuleFor(user => user.Username).Matches(@"/^[\u0391-\uFFE5\w]+$/").WithMessage("User name can contain only letters, numbers, or the underscore character.");

            RuleFor(user => user.Userpwd).NotEmpty().WithMessage("This field is required.");
            RuleFor(user => user.Userpwd).Length(6).WithMessage("Please enter at least 6 characters.");

            RuleFor(user=>user.Confirmpwd).NotEmpty().WithMessage("This field is required.");
            RuleFor(user => user.Confirmpwd).Equal(user => user.Userpwd).WithMessage("Please enter the same value again.");
        }
    }
}

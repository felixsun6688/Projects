using AorangiPeak.Dto.TableBookingDto;
using FluentValidation;

namespace AorangiPeak.Dto.Validator
{
    public class NewTableBookingValidator : AbstractValidator<NewTableBookingDto>
    {
        public NewTableBookingValidator()
        {
            RuleFor(booking => booking.Firstname).NotEmpty().WithMessage("This field is required.");
            //RuleFor(booking => booking.Firstname).Matches(@"`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）&mdash;—|{}【】‘；：”“'。，、？").WithMessage("Please do not enter special character.");

            RuleFor(booking => booking.Lastname).NotEmpty().WithMessage("This field is required.");
            //RuleFor(booking => booking.Lastname).Matches(@"`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）&mdash;—|{}【】‘；：”“'。，、？").WithMessage("Please do not enter special character.");

            RuleFor(booking => booking.Phonenumber).NotEmpty().WithMessage("This field is required.");
            RuleFor(booking => booking.Phonenumber).Matches(@"^[0-9]*$").WithMessage("Please enter a valid phone number.");

            RuleFor(booking => booking.Email).NotEmpty().WithMessage("This field is required.");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Please enter a valid email address.");
        }
    }
}

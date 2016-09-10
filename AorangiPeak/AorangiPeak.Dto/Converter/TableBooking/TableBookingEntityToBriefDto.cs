using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;
using System;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingEntityToBriefDto : ITypeConverter<Domain.Core.Model.TableBooking, TableBookingBriefDto>
    {
        public TableBookingBriefDto Convert(Domain.Core.Model.TableBooking source, TableBookingBriefDto destination, ResolutionContext context)
        {
            return new TableBookingBriefDto()
            {
                Bookingnumber = source.Bookingnumber,
                Numberofadults = source.Numberofadults,
                Numberofchildren = source.Numberofchildren,
                Bookingdate = source.Bookingdate.ToString("ddd, MMM dd, yyyy"),
                Bookingtime = source.Bookingdate.ToShortTimeString(),
                Firstname = source.Firstname,
                Lastname = source.Lastname,
                Phonenumber = source.Phonenumber,
                Email = source.Email,
                Request = source.Request,
                Status = Enum.GetNames(typeof(TableBookingStatus))[(int)source.Status],
                Id = source.Id
            };
        }
    }
}

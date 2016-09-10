using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingEntityToDetailDto : ITypeConverter<Domain.Core.Model.TableBooking, TableBookingDetailDto>
    {
        public TableBookingDetailDto Convert(Domain.Core.Model.TableBooking source, TableBookingDetailDto destination, ResolutionContext context)
        {
            return new TableBookingDetailDto() {
                Bookingnumber = source.Bookingnumber,
                Numberofadults = source.Numberofadults,
                Numberofchildren = source.Numberofchildren,
                Bookingdate = source.Bookingdate.ToString("dd MMMM yyyy"),
                Bookingtime = source.Bookingdate.ToString("HH:mm"),
                Firstname = source.Firstname,
                Lastname = source.Lastname,
                Phonenumber = source.Phonenumber,
                Email = source.Email,
                Request = source.Request,
                Status = source.Status,
                Createtime = source.Createtime,
                Id = source.Id
            };
        }
    }
}

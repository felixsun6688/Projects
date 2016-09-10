using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;
using System;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingDetailDtoToEntity : ITypeConverter<TableBookingDetailDto, Domain.Core.Model.TableBooking>
    {
        public Domain.Core.Model.TableBooking Convert(TableBookingDetailDto source, Domain.Core.Model.TableBooking destination, ResolutionContext context)
        {
            DateTime date = System.Convert.ToDateTime(source.Bookingdate);
            DateTime time = System.Convert.ToDateTime(source.Bookingtime);

            DateTime bookingDate = new DateTime(date.Year, date.Month, date.Day,
                                                                           time.Hour, time.Minute, 0, DateTimeKind.Local);

            return new Domain.Core.Model.TableBooking(source.Id,
                                                                                   source.Bookingnumber,
                                                                                   source.Numberofadults,
                                                                                   source.Numberofchildren,
                                                                                   bookingDate,
                                                                                   source.Firstname,
                                                                                   source.Lastname,
                                                                                   source.Phonenumber,
                                                                                   source.Email,
                                                                                   source.Request,
                                                                                   DateTime.Now,
                                                                                   source.Status);
        }
    }
}

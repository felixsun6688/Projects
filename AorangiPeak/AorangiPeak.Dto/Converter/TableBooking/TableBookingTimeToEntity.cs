using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingTimeToEntity : ITypeConverter<TableBookingTimeDto, TableBookingTime>
    {
        public TableBookingTime Convert(TableBookingTimeDto source, TableBookingTime destination, ResolutionContext context)
        {
            return new TableBookingTime(source.Id, source.TimeValue, source.TimeText, source.Season, source.TimeOrder);
        }
    }
}

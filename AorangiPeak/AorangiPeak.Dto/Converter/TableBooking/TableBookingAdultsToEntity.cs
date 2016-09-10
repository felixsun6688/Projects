using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;
namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingAdultsToEntity : ITypeConverter<TableBookingAdultsDto, TableBookingAdults>
    {
        public TableBookingAdults Convert(TableBookingAdultsDto source, TableBookingAdults destination, ResolutionContext context)
        {
            return new TableBookingAdults(source.Id,source.Value,source.Text,source.Order);
        }
    }
}

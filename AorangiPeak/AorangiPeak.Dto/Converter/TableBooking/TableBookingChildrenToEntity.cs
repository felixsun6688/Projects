using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.TableBooking
{
    public class TableBookingChildrenToEntity : ITypeConverter<TableBookingChildrenDto, TableBookingChildren>
    {
        public TableBookingChildren Convert(TableBookingChildrenDto source, TableBookingChildren destination, ResolutionContext context)
        {
            return new TableBookingChildren(source.Id, source.Value, source.Text, source.Order);
        }
    }
}

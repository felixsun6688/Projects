using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.Converter.TableBooking;
using AorangiPeak.Dto.TableBookingDto;
using AutoMapper;

namespace AorangiPeak.Dto.MappingProfile
{
    public class TableBookingMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<TableBooking, TableBookingBriefDto>().ConvertUsing<TableBookingEntityToBriefDto>();
            CreateMap<TableBooking, TableBookingDetailDto>().ConvertUsing<TableBookingEntityToDetailDto>();

            CreateMap<TableBookingTime, TableBookingTimeDto>();
            CreateMap<TableBookingAdults, TableBookingAdultsDto>();
            CreateMap<TableBookingChildren, TableBookingChildrenDto>();

            CreateMap<NewTableBookingDto, TableBooking>().ConvertUsing<NewTableBookingToEntity>();
            CreateMap<TableBookingDetailDto, TableBooking>().ConvertUsing<TableBookingDetailDtoToEntity>();

            CreateMap<TableBookingTimeDto, TableBookingTime>().ConvertUsing<TableBookingTimeToEntity>();
            CreateMap<TableBookingAdultsDto, TableBookingAdults>().ConvertUsing<TableBookingAdultsToEntity>();
            CreateMap<TableBookingChildrenDto, TableBookingChildren>().ConvertUsing<TableBookingChildrenToEntity>();
        }
    }
}

using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.Converter.Menu;
using AorangiPeak.Dto.MenuDto;
using AutoMapper;

namespace AorangiPeak.Dto.MappingProfile
{
    public class MenuMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Menu, MenuBriefDto>();
            CreateMap<Menu, MenuDetailDto>();

            CreateMap<NewMenuDto, Menu>().ConvertUsing<NewMenuDtoToMenuEntity>(); 
            CreateMap<MenuDetailDto, Menu>().ConvertUsing<MenuDetailDtoToMenuEntity>();
            CreateMap<MenuDeleteDto, Menu>().ConvertUsing<MenuDeleteDtoToMenuEntity>();
        }
    }
}

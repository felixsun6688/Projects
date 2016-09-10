using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.RoleDto;
using AutoMapper;

namespace AorangiPeak.Dto.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, RoleBriefDto>();
            CreateMap<Role, RoleDetailDto>();

            CreateMap<NewRoleDto, Role>();
            CreateMap<RoleDetailDto, Role>();
        }
    }
}

using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Dto.Converter.User;
using AorangiPeak.Dto.UserDto;
using AutoMapper;

namespace AorangiPeak.Dto.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserBriefDto>();
            CreateMap<User, UserDetailDto>().ConvertUsing<UserEntityToUserDetailDto>(); 

            CreateMap<NewUserDto, User>().ConvertUsing<NewUserDtoToUserEntity>();
            CreateMap<LoginUserDto, User>();
            CreateMap<UserDetailDto, User>().ConvertUsing<UserDetailDtoToUserEntity>();
        }
    }
}

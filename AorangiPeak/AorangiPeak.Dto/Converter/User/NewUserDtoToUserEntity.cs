using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.UserDto;
using AutoMapper;
using System;

namespace AorangiPeak.Dto.Converter.User
{
    public class NewUserDtoToUserEntity : ITypeConverter<NewUserDto, Domain.Core.Model.User>
    {
        public Domain.Core.Model.User Convert(NewUserDto source, Domain.Core.Model.User destination, ResolutionContext context)
        {
            return new Domain.Core.Model.User(Guid.NewGuid(),
                                                                      source.Roleid,
                                                                      source.Username,
                                                                      source.Userpwd,
                                                                      source.Email,
                                                                      DateTime.Now,
                                                                     UserStatus.Active);
        }
    }
}

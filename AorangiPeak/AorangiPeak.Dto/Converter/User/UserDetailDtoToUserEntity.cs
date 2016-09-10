using AorangiPeak.Dto.UserDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.User
{
    public class UserDetailDtoToUserEntity : ITypeConverter<UserDetailDto, Domain.Core.Model.User>
    {
        public Domain.Core.Model.User Convert(UserDetailDto source, Domain.Core.Model.User destination, ResolutionContext context)
        {
            return new Domain.Core.Model.User(source.Id,
                                                                      source.Roleid,
                                                                      source.Username,
                                                                      source.Userpwd,
                                                                      source.Email,
                                                                      System.Convert.ToDateTime(source.Createtime),
                                                                      source.Status);
        }
    }
}

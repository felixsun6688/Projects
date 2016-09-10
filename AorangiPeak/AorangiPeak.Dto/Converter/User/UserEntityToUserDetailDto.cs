using AorangiPeak.Dto.UserDto;
using AutoMapper;

namespace AorangiPeak.Dto.Converter.User
{
    public class UserEntityToUserDetailDto : ITypeConverter<Domain.Core.Model.User, UserDetailDto>
    {
        public UserDetailDto Convert(Domain.Core.Model.User source, UserDetailDto destination, ResolutionContext context)
        {
            return new UserDetailDto() {
                Username = source.Username,
                Createtime = source.Createtime.ToString(),
                Email = source.Email,
                Roleid = source.RoleId,
                Userpwd = source.Userpwd,
                Id= source.Id,
                Status = source.Status
            };
        }
    }
}

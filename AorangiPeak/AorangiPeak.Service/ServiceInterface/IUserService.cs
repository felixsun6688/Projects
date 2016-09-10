using AorangiPeak.Dto.UserDto;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface IUserService
    {
        void Add(NewUserDto dto);
        void Save(UserDetailDto dto);
        void Remove(UserDetailDto udto);

        UserDetailDto GetByKey(string uid);
        UserBriefDto GetLoginUserByName(string username);
        UserBriefDto GetLoginUserById(string uid);
        IQueryable<UserDetailDto> GetAll();
        IQueryable<UserBriefDto> GetBriefAll();

        bool IsExist(string username);
    }
}

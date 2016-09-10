using AorangiPeak.Dto.RoleDto;
using System.Linq;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface IRoleService
    {
        void Add(NewRoleDto dto);
        void Save(RoleDetailDto dto);
        void Remove(RoleBriefDto udto);

        RoleDetailDto GetByKey(string uid);
        IQueryable<RoleDetailDto> GetAll();
        IQueryable<RoleBriefDto> GetBriefAll();
    }
}

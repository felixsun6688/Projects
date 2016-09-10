using AorangiPeak.Dto.MenuDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface IMenuService
    {
        void Add(NewMenuDto dto);
        void Save(MenuDetailDto dto);
        void Remove(MenuDeleteDto dto);

        MenuDetailDto GetByKey(string mid);
        IQueryable<MenuDetailDto> GetAll();
        IQueryable<MenuBriefDto> GetBriefAll();
    }
}

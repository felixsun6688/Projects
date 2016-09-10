using AorangiPeak.Dto.MenuDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AorangiPeak.Web.IOC;
using Autofac;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Web.Areas.APManage.Models
{
    public class MealViewModel
    {
        public IList<MenuBriefDto> MenuBriefDtos { get; set; }
        private IMenuService _ms;

        public MealViewModel()
        {
            CreateService();
            MenuBriefDtos = _ms.GetBriefAll().ToList();
        }

        public MenuDetailDto GetMenuDetail(string mid)
        {
            return _ms.GetByKey(mid);
        }

        public void AddNewMenu(NewMenuDto dto)
        {
            _ms.Add(dto);
        }

        public void UpdateMenu(MenuDetailDto dto)
        {
            _ms.Save(dto);
        }

        public void DeleteMenu(string mid)
        {
            MenuDeleteDto dto = new MenuDeleteDto() { Id = new System.Guid(mid) };
            _ms.Remove(dto);
        }

        private void CreateService()
        {
            using (IContainer container = AutofacContainer.GetContainer())
            {
                _ms = container.Resolve<IMenuService>(new TypedParameter(typeof(IRepositoryContext), new AdoRepositoryContext()));
            }
        }
    }
}
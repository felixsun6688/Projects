using AorangiPeak.Dto.MenuDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AorangiPeak.Web.IOC;
using Autofac;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Web.Models
{
    public class RestaurantModel
    {
        public IList<MenuBriefDto> MenuBriefDtos { get; set; }
        private IMenuService _ms;

        public RestaurantModel()
        {
            CreateService();
            MenuBriefDtos = _ms.GetBriefAll().ToList();
        }

        public MenuDetailDto GetMenuDetail(string mid)
        {
            return _ms.GetByKey(mid);
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
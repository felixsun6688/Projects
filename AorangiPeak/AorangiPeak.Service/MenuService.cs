using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Dto.MenuDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Service
{
    public class MenuService : IMenuService
    {
        #region private fields
        private IRepositoryContext _context;
        #endregion

        #region constructor
        public MenuService(IRepositoryContext context)
        {
            _context = context;
        }
        #endregion

        public void Add(NewMenuDto dto)
        {
            using (_context)
            {
                Menu menu = Mapper.Map<NewMenuDto, Menu>(dto);
                IRepository<Menu> userRep = _context.GetRepository<Menu>();
                userRep.Add(menu);
                _context.SaveChanges();
            }
        }

        public void Remove(MenuDeleteDto dto)
        {
            using (_context)
            {
                Menu menu = Mapper.Map<MenuDeleteDto, Menu>(dto);
                IRepository<Menu> userRep = _context.GetRepository<Menu>();
                userRep.Remove(menu);
                _context.SaveChanges();
            }
        }

        public void Save(MenuDetailDto dto)
        {
            using (_context)
            {
                Menu menu = Mapper.Map<MenuDetailDto, Menu>(dto);
                IRepository<Menu> userRep = _context.GetRepository<Menu>();
                userRep.Save(menu);
                _context.SaveChanges();
            }
        }
        public IQueryable<MenuDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MenuBriefDto> GetBriefAll()
        {
            List<MenuBriefDto> dtos = new List<MenuBriefDto>();
            using (_context)
            {
                IRepository<Menu> menuRep = _context.GetRepository<Menu>();
                IQueryable<Menu> menus = menuRep.FindAll();

                foreach (var menu in menus)
                {
                    MenuBriefDto dto = Mapper.Map<Menu, MenuBriefDto>(menu);
                    dtos.Add(dto);
                }
            }

            return dtos.AsQueryable();
        }

        public MenuDetailDto GetByKey(string mid)
        {
            if (string.IsNullOrEmpty(mid)) return null;

            using (_context)
            {
                IRepository<Menu> menuRep = _context.GetRepository<Menu>();
                Menu menu = menuRep.FindBy(new Guid(mid));
                return Mapper.Map<Menu, MenuDetailDto>(menu);
            }
        }
    }
}

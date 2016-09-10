using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Dto.RoleDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Service
{
    public class RoleService : IRoleService
    {
        #region private fields
        private IRepositoryContext _context;
        #endregion

        #region constructor
        public RoleService(IRepositoryContext context)
        {
            _context = context;
        }
        #endregion

        public void Add(NewRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public void Remove(RoleBriefDto udto)
        {
            throw new NotImplementedException();
        }

        public void Save(RoleDetailDto dto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoleDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoleBriefDto> GetBriefAll()
        {
            List<RoleBriefDto> dtos = new List<RoleBriefDto>();
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                IRepository<Role> roleRep = _context.GetRepository<Role>();

                IQueryable<User> users = userRep.FindAll();
                IQueryable<Role> roles = roleRep.FindAll();

                foreach (var role in roles)
                {
                    RoleBriefDto dto = Mapper.Map<Role, RoleBriefDto>(role);
                    dto.Useramount = roles.Count();

                    dtos.Add(dto);
                }
            }

            return dtos.AsQueryable();
        }

        public RoleDetailDto GetByKey(string uid)
        {
            throw new NotImplementedException();
        }
    }
}

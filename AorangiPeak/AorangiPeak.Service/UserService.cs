using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AorangiPeak.Service
{
    /// <summary>
    /// User Service Class
    /// </summary>
    public class UserService : IUserService
    {
        #region private fields
        private IRepositoryContext _context;
        #endregion

        #region constructor
        public UserService(IRepositoryContext context)
        {
            _context = context;
        }
        #endregion

        #region query methods
        public IQueryable<UserDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserBriefDto> GetBriefAll()
        {
            List<UserBriefDto> dtos = new List<UserBriefDto>();
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                IRepository<Role> roleRep = _context.GetRepository<Role>();

                IQueryable<User> users = userRep.FindAll();
                IQueryable<Role> roles = roleRep.FindAll();

                foreach (var user in users)
                {
                    UserBriefDto dto = Mapper.Map<User, UserBriefDto>(user);
                    Role role = roles.FirstOrDefault(r => r.Id.Equals(user.RoleId));
                    if (role != null)
                        dto.Rolename = role.Rolename;

                    dtos.Add(dto); 
                }
            }

            return dtos.AsQueryable();
        }

        public UserDetailDto GetByKey(string uid)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = ((IUserRepository)userRep).FindBy(new Guid(uid));
                if (user != null)
                {
                    return Mapper.Map<User, UserDetailDto>(user);
                }

                return null;
            }
        }
        public UserBriefDto GetLoginUserByName(string username)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = ((IUserRepository)userRep).FindBy(username);

                if (user != null)
                {
                    return Mapper.Map<User, UserBriefDto>(user);
                }
            }

            return null;
        }

        public UserBriefDto GetLoginUserById(string uid)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                IRepository<Role> roleRep = _context.GetRepository<Role>();

                User user = ((IUserRepository)userRep).FindBy(new Guid(uid));
                Role role = ((IRoleRepository)roleRep).FindBy(user.RoleId);

                if (user != null && role !=null)
                {
                    UserBriefDto dto = Mapper.Map<User, UserBriefDto>(user);
                    dto.Rolename = role.Rolename;
                    return dto;
                }
            }

            return null;
        }
        #endregion

        #region modify methods
        public void Add(NewUserDto dto)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = Mapper.Map<NewUserDto, User>(dto);
                userRep.Add(user);
                _context.SaveChanges();
            }
        }

        public void Save(UserDetailDto dto)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = Mapper.Map<UserDetailDto, User>(dto);
                userRep.Save(user);
                _context.SaveChanges();
            }
        }

        public void Remove(UserDetailDto dto)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = Mapper.Map<UserDetailDto, User>(dto);
                userRep.Remove(user);
                _context.SaveChanges();
            }
        }
        #endregion

        public bool IsExist(string username)
        {
            using (_context)
            {
                IRepository<User> userRep = _context.GetRepository<User>();
                User user = ((IUserRepository)userRep).FindBy(username);

                return user != null;
            }
        }
    }
}

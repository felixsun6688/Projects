using AorangiPeak.Common.Utility;
using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AorangiPeak.Web.IOC;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Models
{
    public class UserViewModel
    {
        public LoginUserDto LoginUserDto { get; set; }
        public IList<UserBriefDto> Users { get; set; }
        public NewUserDto NewUserDto { get; set; }
        public UserDetailDto CurrentUserDto { get; set; }
        public SelectList RoleList { get; set; }

        private  IUserService _us;
        private IRoleService _rs;

        public UserViewModel()
        {
            CreateService();
            Users = _us.GetBriefAll().Where(user => user.Status != UserStatus.Deleted).ToList();
            RoleList = new SelectList(_rs.GetBriefAll(), "Id", "Rolename");
        }

        public UserBriefDto FindUserByNameAndPwd(string name, string pwd)
        {
            UserBriefDto dto = _us.GetLoginUserByName(name);

            if (dto != null)
            {
                if (dto.Username.Trim().ToLower().Equals(name)
                    && dto.Userpwd.Equals(EncryptUtils.MD5Encrypt(pwd)))
                    return dto;
            }

            return null;
        }

        public void GetCurrentUser(string uid)
        {
            CurrentUserDto =  _us.GetByKey(uid);
        }

        public void DeleteCurrentUser(string uid)
        {
            _us.Remove(new UserDetailDto() { Id = new System.Guid(uid)});
        }

        public bool IsExist(string username)
        {
            return _us.IsExist(username);
        }

        public void AddNewUser(NewUserDto dto)
        {
            if (dto != null)
            {
                _us.Add(dto);
            }
        }

        public void UpdateUser(UserDetailDto dto)
        {
            if (dto != null)
            {
                _us.Save(dto);
            }
        }

        private void CreateService()
        {
            using (IContainer container = AutofacContainer.GetContainer())
            {
                _us = container.Resolve<IUserService>(new TypedParameter(typeof(IRepositoryContext), 
                    new AdoRepositoryContext()));
                _rs = container.Resolve<IRoleService>(new TypedParameter(typeof(IRepositoryContext),
                   new AdoRepositoryContext()));
            }
        }
    }
}
using AorangiPeak.Common.Utility;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AorangiPeak.Web.IOC;
using Autofac;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = Request.Cookies["AP_Guid"];

            List<string> ActionNameList = new List<string>();
            ActionNameList.Add("Login");

            UserBriefDto dto = GetLoginUser(cookie);

            if ((dto == null || string.IsNullOrEmpty(dto.Username))
                && !ActionNameList.Contains(filterContext.ActionDescriptor.ActionName))
                filterContext.Result = RedirectToAction("Login", "Default");

            base.OnActionExecuting(filterContext);
        }

        protected UserBriefDto GetCurrentUser()
        {
            HttpCookie cookie = Request.Cookies["AP_Guid"];
            if (cookie != null)
                return GetLoginUser(cookie);

            return null;
        }

        protected UserBriefDto GetLoginUser(HttpCookie cookie)
        {
            string uid = CookieService.ReadCookies(cookie);
            if (string.IsNullOrEmpty(uid))
                return null;

            using (IContainer container = AutofacContainer.GetContainer())
            {
                var us = container.Resolve<IUserService>(new TypedParameter(typeof(IRepositoryContext), new AdoRepositoryContext()));
                return us.GetLoginUserById(uid);
            }
        }
    }
}
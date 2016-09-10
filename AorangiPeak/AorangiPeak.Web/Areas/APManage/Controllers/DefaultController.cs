using AorangiPeak.Common.Utility;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Web.Areas.APManage.Models;
using FluentValidation.Results;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Controllers
{
    public class DefaultController : BaseController
    {
        public ActionResult Index()
        {
            UserBriefDto dto = GetCurrentUser();
            ViewBag.LoginUser = dto.Username;
            ViewBag.LoginRole = dto.Rolename;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel uvm)
        {
            LoginUserValidator validator = new LoginUserValidator();
            ValidationResult result = validator.Validate(uvm.LoginUserDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
            }
            else
            {
                   UserBriefDto dto = uvm.FindUserByNameAndPwd(uvm.LoginUserDto.Username, uvm.LoginUserDto.Userpwd);
                    if (dto == null) return View();

                    Response.Cookies.Add(CookieService.SaveCookies(dto.Id.ToString()));
                    return Redirect("~/APManage/Default/Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["AP_Guid"];
            if (cookie == null)
                return RedirectToAction("Login");

            Response.AppendCookie(CookieService.DeleteCookies(cookie));
            return RedirectToAction("Login");
        }
    }
}
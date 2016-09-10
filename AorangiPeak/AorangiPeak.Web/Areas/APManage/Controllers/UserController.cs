using AorangiPeak.Dto.UserDto;
using AorangiPeak.Dto.Validator;
using AorangiPeak.Web.Areas.APManage.Models;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            UserBriefDto dto = GetCurrentUser();
            ViewBag.LoginUser = dto.Username;
            ViewBag.LoginRole = dto.Rolename;
            return View(new UserViewModel());
        }

        [HttpGet]
        public string Exist(string u)
        {
            UserViewModel uvm = new UserViewModel();
            return (uvm.IsExist(u)).ToString();
        }

        public ActionResult Add()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Add(UserViewModel uvm)
        {
            if (uvm.NewUserDto== null) return Redirect("Index");

            NewUserValidator validator = new NewUserValidator();
            ValidationResult result = validator.Validate(uvm.NewUserDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });

                return View(uvm);
            }
            else if (uvm.IsExist(uvm.NewUserDto.Username))
            {
                ModelState.AddModelError("UserName", "User name has existed.");
                return View(uvm);
            }
            else
            {
                uvm.NewUserDto.Userpwd = Common.Utility.EncryptUtils.MD5Encrypt(uvm.NewUserDto.Userpwd);
                uvm.AddNewUser(uvm.NewUserDto);
                return Redirect("Index");
            }
        }

        public JsonResult Update(string uid)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.GetCurrentUser(uid);

            return  Json(uvm.CurrentUserDto,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string uid)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.DeleteCurrentUser(uid);

            return Json("True", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel uvm)
        {
            if (uvm.CurrentUserDto == null) return Redirect("Index");

            UpdateUserValidator validator = new UpdateUserValidator();
            ValidationResult result = validator.Validate(uvm.CurrentUserDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });

                return View(uvm);
            }
            else
            {
                uvm.CurrentUserDto.Userpwd = Common.Utility.EncryptUtils.MD5Encrypt(uvm.CurrentUserDto.Userpwd);
                uvm.UpdateUser(uvm.CurrentUserDto);
                return Redirect("Index");
            }
        }
    }
}
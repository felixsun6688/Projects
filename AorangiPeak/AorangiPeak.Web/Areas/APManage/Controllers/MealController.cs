using AorangiPeak.Dto.MenuDto;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Web.Areas.APManage.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Controllers
{
    public class MealController : BaseController
    {
        private MealViewModel model;

        public MealController()
        {
            model = new MealViewModel();
        }

        public ActionResult Index()
        {
            UserBriefDto dto = GetCurrentUser();
            ViewBag.LoginUser = dto.Username;
            ViewBag.LoginRole = dto.Rolename;
            return View(model);
        }

        public ActionResult AddMenu()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMenu(NewMenuDto dto, HttpPostedFileBase[] files)
        {
            string pathForSaving = Server.MapPath("~/Upload");
            HttpPostedFileBase[] imgs = files.Where(file=>file!=null && file.ContentLength > 0).ToArray();

            string[] paths = new string[2];

            if (this.CreateFolderIfNeeded(pathForSaving))
            {
                for (int i = 0; i < imgs.Length; i++)
                {
                    var newname = GetNewName(imgs[i].FileName);
                    var path = Path.Combine(pathForSaving, newname);
                    imgs[i].SaveAs(path);
                    paths[i] = "/Upload/"+ newname;
                }               
           }

            dto.Firstimg = paths[0];
            dto.Secondimg = paths[1];

            model.AddNewMenu(dto);
            return Redirect("~/APManage/Meal/"); 
        }

        private string GetNewName(string imgname)
        {
            Random rand = new Random();
            string[] filename = imgname.Split('.');
            string filetype = imgname.Substring(imgname.LastIndexOf(".") + 1);

            string newfilename = DateTime.Now.Year.ToString() 
                + DateTime.Now.Month.ToString() 
                + DateTime.Now.Day.ToString() 
                + DateTime.Now.Hour.ToString() 
                + DateTime.Now.Minute.ToString() 
                + DateTime.Now.Second.ToString() 
                + rand.Next(10000).ToString() + "." + filetype;

            return newfilename;
        }

        private bool CreateFolderIfNeeded(string path)
        {
                bool result = true;
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
                return result;
            }

        public ActionResult UpdateMenu(string mid)
        {
            if (!string.IsNullOrEmpty(mid))
            {
                return View(model.GetMenuDetail(mid));
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateMenu(MenuDetailDto dto)
        {
            if (dto != null)
            {
                model.UpdateMenu(dto);
            }
            return Redirect("~/APManage/Meal/");
        }

        public ActionResult DeleteMenu(string mid)
        {
            model.DeleteMenu(mid);
            return Redirect("~/APManage/Meal/");
        }
    }
}
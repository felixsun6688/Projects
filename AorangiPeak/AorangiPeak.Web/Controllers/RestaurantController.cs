using AorangiPeak.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantModel model;

        public RestaurantController()
        {
            model = new RestaurantModel();
        }

        public ActionResult Index()
        {
            ViewBag.Description = "Aorangi Peak";
            ViewBag.Keywords = "Restaurant, Accommodation";
            ViewBag.Title = "Aorangi Peak";
            ViewBag.ActiveItem = "#restaurant";

            return View(model);
        }

        public ActionResult Menu(string mid)
        {
            ViewBag.ActiveItem = "#restaurant";

            if (!string.IsNullOrEmpty(mid))
            {
                return View(model.GetMenuDetail(mid));
            }

            return View();
        }
    }
}
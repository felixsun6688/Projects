using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Controllers
{
    public class FunctionsController : Controller
    {
        // GET: Functions
        public ActionResult Index()
        {
            ViewBag.Description = "Aorangi Peak";
            ViewBag.Keywords = "Restaurant, Accommodation";
            ViewBag.Title = "Aorangi Peak";
            ViewBag.ActiveItem = "#functions";
            return View();
        }
    }
}
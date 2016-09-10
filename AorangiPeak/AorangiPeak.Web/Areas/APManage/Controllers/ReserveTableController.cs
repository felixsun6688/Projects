using AorangiPeak.Common.Pagination;
using AorangiPeak.Dto.UserDto;
using AorangiPeak.Dto.Validator;
using AorangiPeak.Web.Areas.APManage.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Controllers
{
    public class ReserveTableController : BaseController
    {
        public ReserveTableController()
        {
            
        }
        
        /// <summary>
        /// List Bookings
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="result">return result ( 0 : ignore, 1 : seccess, 2: fail ) </param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, int result = 0)
        {
            GetBasicInfo();
            if (result == 1)
            {
                ViewBag.Alert = "<div class='alert alert-success' role='alert' id='alert'>"
                                        + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>"
                                        +"<span aria-hidden = 'true'> &times;</span>"
                                        +"</button>"
                                        + "<strong>Sucessful!</strong> You have made a new reservation.</div>";
            }
            else if (result == 2)
            {
                ViewBag.Alert = "<div class='alert alert-danger' role='alert' id='alert'>"
                                        + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'>"
                                        + "<span aria-hidden = 'true'> &times;</span>"
                                        + "</button>"
                                        + "<strong>Sorry!</strong>You failed to make a new reservation.</div>";
            }

            TableReserveViewModel trvm = new TableReserveViewModel();
            trvm.GetBookingsByPageNumber(page);
            ViewBag.PageInfo = Pagination.GetAdminPageInfo(page, trvm.TotalOfBookings, "ReserveTable", "Index", "");
            ViewBag.TotalInfo = GetTatolInfo(page, trvm.TotalOfBookings);
            return View(trvm);
        }

        /// <summary>
        /// Add new booking
        /// </summary>
        /// <param name="trvm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(TableReserveViewModel trvm)
        {
            if (trvm == null) return Redirect("Index");

            NewTableBookingValidator validator = new NewTableBookingValidator();
            ValidationResult result = validator.Validate(trvm.NewTableBookingDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
                return View(trvm);
            }

            Guid gid = Guid.NewGuid();
            trvm.NewTableBookingDto.Id = gid;
            trvm.AddNewTableBooking(trvm.NewTableBookingDto);
            return RedirectToAction("Index", new { page = 1, result = 1 });
        }

        /// <summary>
        /// Update booking
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public JsonResult Update(string bid)
        {
            TableReserveViewModel trvm = new TableReserveViewModel();
            trvm.GetCurrentBookingInfo(bid);
            return Json(trvm.TableBookingDetailDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(TableReserveViewModel trvm)
        {
            if (trvm == null) return Redirect("Index");

            ModifyTableBookingValidator validator = new ModifyTableBookingValidator();
            ValidationResult result = validator.Validate(trvm.TableBookingDetailDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
                return View(trvm);
            }

            trvm.ModifyTableBooking(trvm.TableBookingDetailDto);
            return RedirectToAction("Index", new { page = 1, result = 1 });
        }

        /// <summary>
        /// Delete booking
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(IList<string> bookings)
        {
            if (bookings==null || bookings.Count==0)
            {
                return Json("Fail");
            }

            TableReserveViewModel trvm = new TableReserveViewModel();
            trvm.RemoveSelectedBookings(bookings);

            return Json("Success");
        }

        public ActionResult Search(int page=1, string num="")
        {
            GetBasicInfo();
            if (string.IsNullOrEmpty(num))
            {
                return RedirectToAction("Index", new { page = 1});
            }
            
            TableReserveViewModel trvm = new TableReserveViewModel();
            trvm.GetBookingsByBookingNumber(page, num.Trim());
            ViewBag.PageInfo = Pagination.GetAdminPageInfo(page, trvm.TotalOfBookings, "ReserveTable", "Search", "num="+num);
            ViewBag.TotalInfo = GetTatolInfo(page, trvm.TotalOfBookings);
            return View("Index",trvm);
        }

        public ActionResult AdvancedSearch(int page=1,
                                                                 string from="",
                                                                 string to= "",
                                                                 string name="",
                                                                 string email="",
                                                                 string phone="",
                                                                 int num=0,
                                                                 string status = "-1")
        {
            GetBasicInfo();
            TableReserveViewModel trvm = new TableReserveViewModel();

            DateTime fromDate = from == "" ? DateTime.MinValue : Convert.ToDateTime(from);
            DateTime toDate = to == "" ? DateTime.MaxValue : Convert.ToDateTime(to);

            trvm.GetBookingsByAdvancedConditions(page, fromDate, toDate,name,email, phone, num, Convert.ToInt32(status));

            string option = "from=" + from + "&to=" + to + "&name=" + name + "&email=" + email + "&phone=" + phone + "&num=" + num;
            ViewBag.PageInfo = Pagination.GetAdminPageInfo(page, trvm.TotalOfBookings, "ReserveTable", "AdvancedSearch", option);
            ViewBag.TotalInfo = GetTatolInfo(page, trvm.TotalOfBookings);
            return View("Index", trvm);
        }

        private string GetTatolInfo(int page, int total)
        {
            return "Showing: " + (Pagination.AdminPagSize * (page - 1) + 1)
                                        + " - " + Pagination.AdminPagSize * page 
                                        + " of " + total + " Records";
        }

        private void GetBasicInfo()
        {
            UserBriefDto dto = GetCurrentUser();
            ViewBag.LoginUser = dto.Username;
            ViewBag.LoginRole = dto.Rolename;
            //ViewBag.DefaultDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
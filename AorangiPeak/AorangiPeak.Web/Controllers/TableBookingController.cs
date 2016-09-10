using AorangiPeak.Dto.TableBookingDto;
using AorangiPeak.Dto.Validator;
using AorangiPeak.Web.Models;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AorangiPeak.Web.Controllers
{
    public class TableBookingController : Controller
    {
        private TableBookingModel _tbm;

        public TableBookingController()
        {
            _tbm = new TableBookingModel();
        }

        public ActionResult Index()
        {
            ViewBag.DefaultDate = DateTime.Now.ToShortDateString();
            return View(_tbm);
        }

        [HttpPost]
        public ActionResult Add(TableBookingModel tbm)
        {
            if (tbm == null)  return Redirect("Index");

            NewTableBookingValidator validator = new NewTableBookingValidator();
            ValidationResult result = validator.Validate(tbm.NewTableBookingDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
                return View(tbm);
            }

            Guid gid = Guid.NewGuid();
            tbm.NewTableBookingDto.Id = gid;
            tbm.AddNewTableBooking(tbm.NewTableBookingDto);
            return RedirectToAction("BookResult", new { bookid = gid.ToString() });
        }

        public ActionResult BookResult(string bookid)
        {
            if (string.IsNullOrEmpty(bookid)) return View("Error");

            TableBookingDetailDto dto =_tbm.ShowBookingInfo(bookid);
            if (dto == null)  return View("Error");

            return View(dto);
        }

        public ActionResult Modify(string bookid)
        {
            if (string.IsNullOrEmpty(bookid)) return View("Error");

            TableBookingDetailDto dto = _tbm.ShowBookingInfo(bookid);
            if (dto == null) return View("Error");

            _tbm.TableBookingDetailDto = dto;
            return View(_tbm);
        }

        [HttpPost]
        public ActionResult Modify(TableBookingModel tbm)
        {
            if (tbm == null) return Redirect("Index");

            ModifyTableBookingValidator validator = new ModifyTableBookingValidator();
            ValidationResult result = validator.Validate(tbm.TableBookingDetailDto);

            if (!result.IsValid)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });
                return View(tbm);
            }

            tbm.ModifyTableBooking(tbm.TableBookingDetailDto);
            return RedirectToAction("BookResult", new { bookid = tbm.TableBookingDetailDto.Id.ToString() });
        }

    }
}
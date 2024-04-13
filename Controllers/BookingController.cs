using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using System.Configuration;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.Validation;

namespace WebBanHangOnline.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Booking
        [HttpPost]
        public ActionResult Index(Booking a)
        {
            return View(a);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.Services.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Booking model)
        {
            model.Status = "Chờ xác nhận";
            model.ModifiedBy = "Khách hàng";
            model.CreatedDate = DateTime.Now;
            db.Bookings.Add(model);
            db.SaveChanges();
            return PartialView("index");
        }

    }
}
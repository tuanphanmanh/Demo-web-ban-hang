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

namespace WebBanHangOnline.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Booking
        public ActionResult Index()
        {
            return View();
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
            model.CreatedDate = DateTime.Now;
            db.Bookings.Add(model);
            db.SaveChanges();
            return PartialView("index");
        }

    }
}
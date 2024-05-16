using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Service
        public ActionResult Index()
        {
            ViewBag.ProductCategory = new SelectList(db.Services.ToList(), "Id", "Title");
            return View();
        }

        public ActionResult GetAllServiceCustomer()
        {
            ViewBag.ProductCategory = new SelectList(db.Services.ToList(), "Id", "Title");
            var items = db.Services.ToList();
            return PartialView(items);
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
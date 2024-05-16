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
            string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/content/template/send3.html"));
            contentCustomer = contentCustomer.Replace("{{NgayDat}}", model.CreatedDate.ToString("dd/MM/yyyy"));
            //contentCustomer = contentCustomer.Replace("{{DichVu}}", model.Service.Title);
            contentCustomer = contentCustomer.Replace("{{ThoiGianToi}}", model.CustomerTime);
            contentCustomer = contentCustomer.Replace("{{NgayToi}}", model.ModifiedDate.ToString("dd/MM/yyyy"));
            contentCustomer = contentCustomer.Replace("{{TenKhachhang}}", model.CreatedBy);
            contentCustomer = contentCustomer.Replace("{{DiaChiLienHe}}", model.Address);
            contentCustomer = contentCustomer.Replace("{{Email}}", model.Email);
            contentCustomer = contentCustomer.Replace("{{Phone}}", model.PhoneNumber);
            contentCustomer = contentCustomer.Replace("{{Xe}}", model.CarName);
            WebBanHangOnline.Common.Common.SendMail("noreply@tuyquyauto.com.vn", "Lịch hẹn dịch vụ", contentCustomer.ToString(), model.Email);
            return PartialView("index");
        }

    }
}
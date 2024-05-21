using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class SignUpForTestDriveController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.product = new SelectList(db.Products.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SignUpForTestDrive model)
        {
            model.CreatedDate = DateTime.Now;
            db.SignUpForTestDrives.Add(model);
            db.SaveChanges();
            string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/content/template/send22.html"));
            contentCustomer = contentCustomer.Replace("{{NgayDat}}", model.CreatedDate.ToString("dd/MM/yyyy"));
            contentCustomer = contentCustomer.Replace("{{DiaDiemLaiThu}}", model.DiaDiemLaiThu);
            //contentCustomer = contentCustomer.Replace("{{XeDangKy}}", model.Product.Title);
            contentCustomer = contentCustomer.Replace("{{ThoiGianLaiThu}}", model.ModifiedDate.ToString("dd/MM/yyyy"));
            contentCustomer = contentCustomer.Replace("{{TenKhachhang}}", model.CustomerName);
            contentCustomer = contentCustomer.Replace("{{DiaChiLienHe}}", model.DiaChiLienHe);
            contentCustomer = contentCustomer.Replace("{{Email}}", model.Email);
            contentCustomer = contentCustomer.Replace("{{Phone}}", model.Phone);
            contentCustomer = contentCustomer.Replace("{{DuKienMuaXe}}", model.BuyCarTime);

            WebBanHangOnline.Common.Common.SendMail("noreply@tuyquyauto.com.vn", "Lịch hẹn đăng ký lái thử" , contentCustomer.ToString(), model.Email);
            return RedirectToAction("Index");
        }

    }
}
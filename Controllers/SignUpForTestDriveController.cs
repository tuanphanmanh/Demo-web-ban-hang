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

        // GET: SignUpForTestDrive
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
            return RedirectToAction("Index");
        }

    }
}
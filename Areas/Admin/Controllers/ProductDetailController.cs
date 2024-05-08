using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var abc = db.ProductDetails.ToList();
            return View(abc);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.Products.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductDetail productdetail)
        {
            db.ProductDetails.Add(productdetail);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
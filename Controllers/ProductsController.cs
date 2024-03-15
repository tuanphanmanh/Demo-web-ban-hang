using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    //[Authorize(Roles = "Customermer")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var items = db.Products.ToList();
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(a=>a.ViewCount).IsModified = true;
                db.SaveChanges();
            }
            return View(item);
        }

        public ActionResult ProductCategory(string alias, int id)
        {
            var items = db.Products.ToList();
            if (id > 0)
            {
                items = items.Where(a => a.ProductCategoryId == id).ToList();
            }
            var cate = db.ProductCategorys.Find(id);
            if(cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }
        public ActionResult Partial_ItemByCateId()
        {
            var items = db.Products.Where(a => a.IsHome && a.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductSale()
        {
            var items = db.Products.Where(a=>a.IsSale && a.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}
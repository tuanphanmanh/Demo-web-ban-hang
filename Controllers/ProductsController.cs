using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    //[Authorize(Roles = "Customermer")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(string SearchText)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(a => a.Alias.Contains(SearchText) || a.Title.Contains(SearchText));
            }
            return View(items.ToList());
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
            var countReview = db.ReviewProducts.Where(a=>a.ProductId == id).Count();
            ViewBag.CountReview = countReview;
            return View(item);
        }
        
        public ActionResult DetailProduct()
        {
            var items = db.Products.ToList();
            return PartialView(items);
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
            var items = db.Products.ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductSale()
        {
            var items = db.News.ToList();
            return PartialView(items);
        }
    }
}
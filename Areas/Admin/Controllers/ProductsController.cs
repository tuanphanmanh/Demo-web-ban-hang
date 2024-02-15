using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(a => a.Id);
            var pageSize = 7;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategorys.ToList(), "Id", "Title");
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Add(Product model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.CreatedDate = DateTime.Now;
        //        model.ModifiedDate = DateTime.Now;
        //        model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
        //        db.Products.Add(model);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }
}
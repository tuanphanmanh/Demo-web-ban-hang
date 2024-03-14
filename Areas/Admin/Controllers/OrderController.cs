using Microsoft.AspNetCore.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var item = db.Orders.OrderByDescending(a=>a.CreatedDate).ToList();
            if (page == null)
            {
                page = 1;
            }
            var pagenNumber = page ?? 1;
            var pageSize = 10;
            return View(item.ToPagedList(pagenNumber, pageSize));
        }
        public ActionResult View(int id)
        {
            var items = db.Orders.Find(id);
            return View(items);

        }
        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(a=>a.OrderId == id);
            return PartialView(items);

        }


        [HttpPost]
        public ActionResult UpdateTT(int fid, int trangthaivanchuyen)
        {
            var item = db.Orders.Find(fid);
            if (item != null)
            {
                db.Orders.Attach(item);
                item.ShippingStatus = trangthaivanchuyen;
                db.Entry(item).Property(a => a.ShippingStatus).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }


    }
}
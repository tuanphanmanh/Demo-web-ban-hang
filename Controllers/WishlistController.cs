﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;
using PagedList;
using System.Web.UI;

namespace WebBanHangOnline.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        // GET: Wishlist
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Wishlist> items = db.Wishlists.Where(x => x.UserName == User.Identity.Name).OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishlist(int ProductId)
        {
            if (Request.IsAuthenticated == false)
            {
                return Json(new { Success = false, Message = "Bạn chưa đăng nhập." });
            }
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                return Json(new { Success = false, Message = "Đã thêm sản phẩm vào mục quan tâm." });
            }
            var item = new Wishlist();
            item.ProductId = ProductId;
            item.UserName = User.Identity.Name;
            item.CreatedDate = DateTime.Now;
            db.Wishlists.Add(item);
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostDeleteWishlist(int ProductId)
        {
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                var item = db.Wishlists.Find(checkItem.Id);
                db.Set<Wishlist>().Remove(item);
                var i = db.SaveChanges();
                return Json(new { Success = true, Message = "Ko xóa được khỏi danh sách quan tâm." });
            }
            return Json(new { Success = false, Message = "Xóa khỏi danh sách quan tâm." });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Wishlists.Find(id);
            if (item != null)
            {
                db.Wishlists.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
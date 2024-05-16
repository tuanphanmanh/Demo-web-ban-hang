﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    //[Authorize(Roles = "Customermer")]

    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(a=>a.Position).ToList();
            return PartialView("MenuTop", items);
        }

        public ActionResult MenuLeft(int? id)
        {
            if( id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.ProductCategorys.OrderBy(a => a.Position).ToList();
            return PartialView(items);
        }
        public ActionResult MenuProductCategory()
        {
            var items = db.ProductCategorys.ToList();
            return PartialView("MenuProductCategory", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = db.ProductCategorys.ToList();
            return PartialView("MenuArrivals", items);
        }
    }
}
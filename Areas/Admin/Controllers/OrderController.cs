using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var items = db.Orders;
            return View(items);
        }
        public ActionResult details()
        {
            var items = db.Orders;
            return PartialView(items);
        }

        //public ActionResult Partial_Item_Thanhtoan()
        //{
        //    ShoppingCart cart = (ShoppingCart)Session["Cart"];
        //    if (cart != null)
        //    {
        //        return PartialView(cart.Items);
        //    }
        //    return PartialView();
        //}

        public ActionResult Partial_Item_Thanhtoan()
        {
            var items = db.OrderDetails;
            return View(items);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Employee")]

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.ngayhomnay = DateTime.Now.ToString("dd/MM/yyyy"); 
            ViewBag.bamuoingayhomnay = DateTime.Now.Date;
            
            var item = db.Orders.ToList();
            return View(item);

            
        }
    }
} 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Service
        public ActionResult Index()
        {
            var items = db.Services.ToList();
            return PartialView(items);
        }
    }
}
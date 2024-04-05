using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string id)
        {
            var item = db.Posts.FirstOrDefault(a => a.Alias == id);
            return View(item);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
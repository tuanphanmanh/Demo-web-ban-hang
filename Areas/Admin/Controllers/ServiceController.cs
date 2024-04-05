using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Service
        public ActionResult Index()
        {
            var items = db.Services;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Service model)
        {
            if (ModelState.IsValid)
            {
                model.Image = "";
                var f = Request.Files["ImageFile"];
                if(f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath( "~/content/images/" + FileName);
                    f.SaveAs(UploadPath);
                    model.Image = FileName;
                }
                model.ModifiedDate = DateTime.Now;
                model.CreatedDate = DateTime.Now;
                model.ProductId = 41;
                db.Services.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
using iTextSharp.text;
using iTextSharp.text.pdf;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.News.OrderByDescending(x => x.Id);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult DetailNewInHome()
        {
            var item = db.News.OrderByDescending(a => a.CreatedDate).Take(1).ToList();
            return PartialView(item);
        }
        public ActionResult Detail(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        public ActionResult Partial_News_Home()
        {
            var items = db.Services.Take(5).ToList();
            return PartialView(items);
        }
        public ActionResult ExportPdf()
        {
            var data = db.News.ToList();

            Document document = new Document();

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            foreach (var item in data)
            {
                // Thêm các trường dữ liệu từ model vào tài liệu
                document.Add(new Paragraph(item.Detail));
            }

            // Đóng tài liệu
            document.Close();

            // Lấy byte array từ MemoryStream
            byte[] bytes = memoryStream.ToArray();

            // Trả về file PDF
            return File(bytes, "application/pdf", "example.pdf");
        }
    }
}
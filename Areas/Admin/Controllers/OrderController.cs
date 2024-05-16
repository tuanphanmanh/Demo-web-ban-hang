using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using System.Drawing;
using System.Globalization;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page, DateTime? SearchText)
        {
            IEnumerable<Order> item = db.Orders.OrderByDescending(x => x.CreatedDate);
            if (page == null)
            {
                page = 1;
            }
            var pagenNumber = page ?? 1;
            var pageSize = 13;
            if (!string.IsNullOrEmpty(SearchText?.ToString("dd/MM/yyyy")))
            {
                item = item.Where(p => p.CreatedDate.ToString("dd/MM/yyyy").Equals(SearchText?.ToString("dd/MM/yyyy")));
            }

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

        public ActionResult Export()
        {
            var data = db.Orders.ToList();

            using (var package = new ExcelPackage())
            {
                // Create a new worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // Add data to the worksheet
                worksheet.Cells["A1"].Value = "STT";
                worksheet.Cells["B1"].Value = "Code";
                worksheet.Cells["C1"].Value = "Name";
                worksheet.Cells["D1"].Value = "Phone";
                worksheet.Cells["E1"].Value = "Email";
                worksheet.Cells["F1"].Value = "Amount";
                worksheet.Cells["G1"].Value = "Date";
                worksheet.Cells["H1"].Value = "Address";
                worksheet.Cells["I1"].Value = "Shipper";
                worksheet.Cells["J1"].Value = "Type Payment";

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells["A" + (i + 2)].Value = i + 1;
                    worksheet.Cells["B" + (i + 2)].Value = data[i].Code;
                    worksheet.Cells["C" + (i + 2)].Value = data[i].CustomerName;
                    worksheet.Cells["D" + (i + 2)].Value = data[i].Phone;
                    worksheet.Cells["E" + (i + 2)].Value = data[i].Email;
                    worksheet.Cells["F" + (i + 2)].Value = data[i].TotalAmount;
                    worksheet.Cells["G" + (i + 2)].Value = data[i].CreatedDate.ToString("dd/MM/yyyy");
                    worksheet.Cells["H" + (i + 2)].Value = data[i].Address;
                    worksheet.Cells["I" + (i + 2)].Value = data[i].ShippingStatus;
                    worksheet.Cells["J" + (i + 2)].Value = data[i].TypePayment;
                    worksheet.Column(i+2).AutoFit();
                }

                

                var dataRange = worksheet.Cells[1, 1, data.Count +1, data.Count +1 ];
                var borderStyle = dataRange.Style.Border;
                borderStyle.BorderAround(ExcelBorderStyle.Thin);

                // Thiết lập viền cho các cạnh của ô dữ liệu    
                borderStyle.Left.Style = ExcelBorderStyle.Thin;
                borderStyle.Right.Style = ExcelBorderStyle.Thin;
                borderStyle.Top.Style = ExcelBorderStyle.Thin;
                borderStyle.Bottom.Style = ExcelBorderStyle.Thin;

                // Thiết lập định dạng cho header
                var headerRange = worksheet.Cells[1, 1, 1, data.Count + 1];
                var headerStyle = headerRange.Style;

                // Định dạng màu nền cho header
                headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                headerStyle.Fill.BackgroundColor.SetColor(Color.LightGreen);

                // Định dạng căn giữa cho header
                headerStyle.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerStyle.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Set the content type and file name for the response
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Order_Export_ForAdmin.xlsx");

                // Write the Excel package to the response stream
                Response.BinaryWrite(package.GetAsByteArray());
                Response.Flush();
                Response.End();
            }

            return View();
        }


    }
}
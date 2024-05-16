using OfficeOpenXml.Style;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using System.Drawing;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Booking
        public ActionResult Index(int? page)
        {
            IEnumerable<Booking> items = db.Bookings.OrderByDescending(a => a.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        [HttpPost]
        public ActionResult UpdateTT(int fid, string trangthaivanchuyen)
        {
            var item = db.Bookings.Find(fid);
            if (item != null)
            {
                db.Bookings.Attach(item);
                item.Status = trangthaivanchuyen;
                db.Entry(item).Property(a => a.Status).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }

        public ActionResult Export()
        {
            var data = db.Bookings.ToList();

            using (var package = new ExcelPackage())
            {
                // Create a new worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // Add data to the worksheet
                var a = data.Count();
                worksheet.Cells["A1"].Value = "Ngày:";
                worksheet.Cells["B1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                worksheet.Cells["D1"].Value = "Báo cáo lịch hẹn của khách đến ngày " +DateTime.Now.ToString("dd/MM/yyyy");

                worksheet.Cells["A2"].Value = "STT";
                worksheet.Cells["B2"].Value = "Name";
                worksheet.Cells["C2"].Value = "Phone";
                worksheet.Cells["D2"].Value = "Email";
                worksheet.Cells["E2"].Value = "Addres";
                worksheet.Cells["F2"].Value = "Car Name";
                worksheet.Cells["G2"].Value = "Time";
                worksheet.Cells["H2"].Value = "Date";
                worksheet.Cells["I2"].Value = "Status";

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells["A" + (i + 3)].Value = i + 1;
                    worksheet.Cells["B" + (i + 3)].Value = data[i].CreatedBy;
                    worksheet.Cells["C" + (i + 3)].Value = data[i].PhoneNumber;
                    worksheet.Cells["D" + (i + 3)].Value = data[i].Email;
                    worksheet.Cells["E" + (i + 3)].Value = data[i].Address;
                    worksheet.Cells["F" + (i + 3)].Value = data[i].CarName;
                    worksheet.Cells["G" + (i + 3)].Value = data[i].CustomerTime;
                    worksheet.Cells["H" + (i + 3)].Value = data[i].ModifiedDate.ToString("dd/MM/yyyy");
                    worksheet.Cells["I" + (i + 3)].Value = data[i].Status;
                    worksheet.Column(i + 3).AutoFit();
                }

                var dataRange = worksheet.Cells[1, 1, data.Count +2, data.Count +3];
                var borderStyle = dataRange.Style.Border;
                borderStyle.BorderAround(ExcelBorderStyle.Thin);

                // Thiết lập viền cho các cạnh của ô dữ liệu
                borderStyle.Left.Style = ExcelBorderStyle.Thin;
                borderStyle.Right.Style = ExcelBorderStyle.Thin;
                borderStyle.Top.Style = ExcelBorderStyle.Thin;
                borderStyle.Bottom.Style = ExcelBorderStyle.Thin;

                // Thiết lập định dạng cho header
                var headerRange = worksheet.Cells[1, 1, 1, data.Count + 2];
                var headerStyle = headerRange.Style;

                // Định dạng màu nền cho header
                headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                headerStyle.Fill.BackgroundColor.SetColor(Color.LightGreen);

                //header chữ đậm
                headerStyle.Font.Bold = true;

                // Định dạng căn giữa cho header
                headerStyle.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerStyle.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Set the content type and file name for the response
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Export_Booking_Service.xlsx");

                // Write the Excel package to the response stream
                Response.BinaryWrite(package.GetAsByteArray());
                Response.Flush();
                Response.End();
            }

            return View();
        }
    }
}
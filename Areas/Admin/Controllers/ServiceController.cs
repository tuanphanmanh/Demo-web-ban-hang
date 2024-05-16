using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                model.ModifiedDate = DateTime.Now;
                model.CreatedDate = DateTime.Now;
                db.Services.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Export()
        {
            var data = db.Services.ToList();

            using (var package = new ExcelPackage())
            {
                // Create a new worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // Add data to the worksheet
                worksheet.Cells["A1"].Value = "Id";
                worksheet.Cells["B1"].Value = "Title";
                worksheet.Cells["C1"].Value = "Price";
                worksheet.Cells["D1"].Value = "Created Date";
                worksheet.Cells["E1"].Value = "Modify By";
                worksheet.Cells["F1"].Value = "Description";

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells["A" + (i + 2)].Value = i +1 ;
                    worksheet.Cells["B" + (i + 2)].Value = data[i].Title;
                    worksheet.Cells["C" + (i + 2)].Value = data[i].PriceOfSerVice;
                    worksheet.Cells["D" + (i + 2)].Value = data[i].CreatedDate;
                    worksheet.Cells["E" + (i + 2)].Value = data[i].ModifiedBy;
                    worksheet.Cells["F" + (i + 2)].Value = data[i].Description;
                    worksheet.Column(i + 2).AutoFit();
                }

                var dataRange = worksheet.Cells[1,1, data.Count +1, data.Count+1];
                var borderStyle = dataRange.Style.Border;
                borderStyle.BorderAround(ExcelBorderStyle.Thin);

                // Thiết lập viền cho các cạnh của ô dữ liệu
                borderStyle.Left.Style = ExcelBorderStyle.Thin;
                borderStyle.Right.Style = ExcelBorderStyle.Thin;
                borderStyle.Top.Style = ExcelBorderStyle.Thin;
                borderStyle.Bottom.Style = ExcelBorderStyle.Thin;

                // Thiết lập định dạng cho header
                var headerRange = worksheet.Cells[1, 1, 1, data.Count+1];
                var headerStyle = headerRange.Style;

                // Định dạng màu nền cho header
                headerStyle.Fill.PatternType = ExcelFillStyle.Solid;
                headerStyle.Fill.BackgroundColor.SetColor(Color.LightGreen);

                // Định dạng căn giữa cho header
                headerStyle.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerStyle.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Set the content type and file name for the response
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Service-Export-Excel.xlsx");

                // Write the Excel package to the response stream
                Response.BinaryWrite(package.GetAsByteArray());
                Response.Flush();
                Response.End();
            }

            return View();
        }

        //public void ExportToExcel()
        //{
        //    List<ServiceViewModel> products = db.Services.Select(a => new ServiceViewModel
        //    {
        //        Id = a.Id,
        //        Title = a.Title,
        //        Quantity = a.Quantity,
        //        Price = a.Price,
        //        PriceSale = a.PriceSale,
        //    });
        //    ExcelPackage abcde = new ExcelPackage();
        //    ExcelWorksheet Sheet = abcde.Workbook.Worksheets.Add("Report");

        //    Sheet.Cells["A1"].Value = "STT";
        //    Sheet.Cells["B1"].Value = "Title";
        //    Sheet.Cells["C1"].Value = "Quantity";
        //    Sheet.Cells["D1"].Value = "Price";
        //    Sheet.Cells["E1"].Value = "PriceSale";

        //    int rowStart = 7;
        //    foreach (var item in products)
        //    {
        //        //Sheet.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //        //Sheet.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("blue")));
        //        Sheet.Cells[string.Format("A{0}", rowStart)].Value = item.Id;
        //        Sheet.Cells[string.Format("B{0}", rowStart)].Value = item.Title;
        //        Sheet.Cells[string.Format("C{0}", rowStart)].Value = item.Quantity;
        //        Sheet.Cells[string.Format("D{0}", rowStart)].Value = item.Price;
        //        Sheet.Cells[string.Format("E{0}", rowStart)].Value = item.PriceSale;
        //        rowStart++;
        //    }
        //    Sheet.Cells["A:AZ"].AutoFitColumns();
        //    Response.Clear();
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.AddHeader("content-disposition", "attachment; filename=" + "ExcelReport.xlsx");
        //    Response.BinaryWrite(abcde.GetAsByteArray());
        //    Response.End();
        //}


    }
}
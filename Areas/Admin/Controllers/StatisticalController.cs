using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
using static iTextSharp.text.pdf.AcroFields;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class StatisticalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Statistical


        public ActionResult Index(string theohangxe, string theotenxe, DateTime? theongay)
        {
            var mostOrderedProduct = db.OrderDetails
                    .GroupBy(od => od.ProductId)
                    .OrderByDescending(group => group.Sum(od => od.Quantity))
                    .Select(group => new { ProductId = group.Key, TotalQuantity = group.Sum(od => od.Quantity) })
                    .FirstOrDefault();

            if (mostOrderedProduct != null)
            {
                int productId = mostOrderedProduct.ProductId;
                int totalQuantity = mostOrderedProduct.TotalQuantity;

                var product = db.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    string productName = product.Title;
                    string productImage = product.Image;
                    decimal productMoney = product.Price;
                    string productXuatxu = product.Origin;
                    DateTime productDate = product.CreatedDate;

                    ViewBag.Anh = productImage;
                    ViewBag.XeBanNhieuNhat = productName;
                    ViewBag.tien = productMoney;
                    ViewBag.SoLuongLa = totalQuantity;
                    ViewBag.soluongconlai = product.Quantity - totalQuantity;
                    ViewBag.xuatxu = productXuatxu;
                    ViewBag.ngaynhap = productDate;
                }
            }
            ViewBag.hangxe = new SelectList(db.ProductCategorys.ToList(), "Id", "Title");
            ViewBag.tenxe = new SelectList(db.Products.ToList(), "Id", "Title");
            IEnumerable<OrderDetail> items = db.OrderDetails.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(theohangxe))
            {
                items = items.Where( p => p.Product.ProductCategoryId.ToString().Equals(theohangxe) );
            }
            if (!string.IsNullOrEmpty(theotenxe))
            {
                items = items.Where(p => p.ProductId.ToString().Equals(theotenxe));
            }
            if (!string.IsNullOrEmpty(theongay?.ToString("dd/MM/yyyy")))
            {
                items = items.Where(p => p.Order.CreatedDate.ToString("dd/MM/yyyy").Equals(theongay?.ToString("dd/MM/yyyy")));
            }

            return View(items);
        }
        public ActionResult TopFive()
        {
            var mostOrderedProducts = db.OrderDetails
                .GroupBy(od => od.ProductId)
                .OrderByDescending(group => group.Sum(od => od.Quantity))
                .Select(group => new { ProductId = group.Key, TotalQuantity = group.Sum(od => od.Quantity),
                    ProductName = group.FirstOrDefault().Product.Title
                })
                .Take(5)
                .ToList();

            var orderDetails = mostOrderedProducts.Select(product => new OrderDetail
            {
                ProductId = product.ProductId,
                Quantity = product.TotalQuantity,
                Name = product.ProductName,

            }).ToList();
            return PartialView(orderDetails);
        }

        public ActionResult TopFiveLastest()
        {
            var lastOrderedProducts = db.OrderDetails
               .GroupBy(od => od.ProductId)
                .OrderBy(group => group.Min(od => od.Product.CreatedDate))
               .Select(group => new {
                   ProductId = group.Key,
                   TotalQuantity = group.Sum(od => od.Quantity),
                   ProductName = group.FirstOrDefault().Product.Title,
                   productdate = group.FirstOrDefault().Product.CreatedDate,
               })
               .Take(5)
               .ToList();

            var orderDetails = lastOrderedProducts.Select(product => new OrderDetail
            {
                ProductId = product.ProductId,
                Quantity = product.TotalQuantity,
                Name = product.ProductName,
                SelectedDate = product.productdate,

            }).ToList();
            return PartialView(orderDetails);
        }
        [HttpGet]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            var query = from o in db.Orders
                        join od in db.OrderDetails
                        on o.Id equals od.OrderId
                        join p in db.Products
                        on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy + 1000000000
            });
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}




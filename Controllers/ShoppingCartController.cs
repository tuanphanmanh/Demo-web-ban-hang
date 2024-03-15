using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    //[Authorize(Roles = "Customermer")]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbEntityValidationException context = new DbEntityValidationException();
        
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        
        public ActionResult CheckOutSuccess(Order o)
        {
            var check = db.Orders.Where(a=>a.Id == o.Id).ToList();
            return View(o);
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var code = new { Success = true, Code = -1 };
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                    Order order = new Order();
                    order.CustomerName = req.CustomerName;
                    order.ShippingStatus = req.ShippingStatus;
                    order.Phone = req.Phone;
                    order.Address = req.Address;
                    order.Email = req.Email;
                    order.AddressType = req.AddressType;
                    order.MessegesForBuyer = req.MessegesForBuyer;
                    order.ShippingUnit = req.ShippingUnit;
                    order.Voucher = req.Voucher;
                    order.TypePayment = req.TypePayment;
                    cart.Items.ForEach(a => order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = a.ProductId,
                        Quantity = a.Quantity,
                        Price = a.Price,
                    }));
                    order.TotalAmount = cart.Items.Sum(x => (x.Price * x.Quantity));
                    order.CreatedDate = DateTime.Now;
                    order.ModifiedDate = DateTime.Now;
                    order.CreatedBy = req.Phone;
                    Random rd = new Random();
                    order.Code = "DH" + rd.Next(0,9) + rd.Next(0, 9) + rd.Next(0, 9)  ;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    // gửi email cho khách hàng
                    var strSanPham = "";
                    var thanhtien = decimal.Zero;
                    var TongTien = decimal.Zero;
                    foreach (var sp in cart.Items)
                    {
                        strSanPham += "<tr>";       
                        strSanPham += "<td width=\"200\" style=\"font-family:'SF Pro Text',Arial,sans-serif;text-align:center;border-collapse:collapse;word-break:break-word;font-size:14px;border-top:1px solid #c5c5c5;border-right:1px solid #c5c5c5;border-bottom:1px solid #c5c5c5;border-left:1px solid #c5c5c5;padding:5px 10px 5px 10px\">" + sp.ProductName + "</td>";
                        strSanPham += "<td width=\"100\" style=\"font-family:'SF Pro Text',Arial,sans-serif;text-align:center;border-collapse:collapse;word-break:break-word;font-size:14px;border-top:1px solid #c5c5c5;border-right:1px solid #c5c5c5;border-bottom:1px solid #c5c5c5;border-left:1px solid #c5c5c5;padding:5px 10px 5px 10px\">" + sp.Quantity + "</td>";
                        strSanPham += "<td width=\"200\" style=\"font-family:'SF Pro Text',Arial,sans-serif;text-align:center;border-collapse:collapse;word-break:break-word;font-size:14px;border-top:1px solid #c5c5c5;border-right:1px solid #c5c5c5;border-bottom:1px solid #c5c5c5;border-left:1px solid #c5c5c5;padding:5px 10px 5px 10px\">" + WebBanHangOnline.Common.Common.FormatNumber(sp.TotalPrice,0) + "</td>";
                        strSanPham += "</tr>";
                        thanhtien += sp.Price * sp.Quantity;
                    }
                    TongTien = thanhtien;
                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/content/template/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{MaDon}}", order.Code);
                    contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
                    contentCustomer = contentCustomer.Replace("{{TenKhachhang}}", order.CustomerName);
                    contentCustomer = contentCustomer.Replace("{{Email}}", order.Email);
                    contentCustomer = contentCustomer.Replace("{{Phone}}", order.Phone);
                    contentCustomer = contentCustomer.Replace("{{DiaChiNhanHang}}", order.Address);
                    contentCustomer = contentCustomer.Replace("{{PhuongThucThanhToan}}", order.TypePayment);
                    contentCustomer = contentCustomer.Replace("{{HinhThucVanChuyen}}", order.ShippingUnit);
                    contentCustomer = contentCustomer.Replace("{{LoaiDiaChi}}", order.AddressType);
                    contentCustomer = contentCustomer.Replace("{{NgayDat}}", order.CreatedDate.ToString("dd/MM/yyyy"));
                    contentCustomer = contentCustomer.Replace("{{ThanhTien}}", WebBanHangOnline.Common.Common.FormatNumber(thanhtien, 0));
                    contentCustomer = contentCustomer.Replace("{{TongTien}}", WebBanHangOnline.Common.Common.FormatNumber(TongTien, 0));

                    WebBanHangOnline.Common.Common.SendMail("XEĐẸP", "Đơn hàng #"+order.Code, contentCustomer.ToString(), order.Email);


                    string contentAdmin = System.IO.File.ReadAllText(Server.MapPath("~/content/template/send1.html"));
                    contentAdmin = contentAdmin.Replace("{{MaDon}}", order.Code);
                    contentCustomer = contentCustomer.Replace("{{TenKhachhang}}", order.CustomerName);
                    contentAdmin = contentAdmin.Replace("{{SanPham}}", strSanPham);
                    contentAdmin = contentAdmin.Replace("{{Voucher}}", order.Voucher);
                    contentAdmin = contentAdmin.Replace("{{Email}}", order.Email);
                    contentAdmin = contentAdmin.Replace("{{Phone}}", order.Phone);
                    contentAdmin = contentAdmin.Replace("{{DiaChiNhanHang}}", order.Address);
                    contentAdmin = contentAdmin.Replace("{{PhuongThucThanhToan}}", order.TypePayment);
                    contentAdmin = contentAdmin.Replace("{{HinhThucVanChuyen}}", order.ShippingUnit);
                    contentAdmin = contentAdmin.Replace("{{LoaiDiaChi}}", order.AddressType);
                    contentAdmin = contentAdmin.Replace("{{NgayDat}}", order.CreatedDate.ToString("dd/MM/yyyy"));
                    contentAdmin = contentAdmin.Replace("{{ThanhTien}}", WebBanHangOnline.Common.Common.FormatNumber(thanhtien, 0));
                    contentAdmin = contentAdmin.Replace("{{LoiNhan}}", order.MessegesForBuyer);

                    WebBanHangOnline.Common.Common.SendMail("XEĐẸP", "Đơn hàng mới#" + order.Code, contentAdmin.ToString(), ConfigurationManager.AppSettings["EmailAdmin"]);

                    cart.ClearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
            }
            return Json(code);
        }


        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }
        public ActionResult Partial_Item_Thanhtoan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                return Json(new { Count = cart.Items.Count, JsonRequestBehavior.AllowGet });
            }
            return Json(new {  Count = 0, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(a=>a.ProductId == id);
                if(checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            var db = new ApplicationDbContext();
            var checkProduct = db.Products.FirstOrDefault(a => a.Id == id);
            if(checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.Id,
                    ProductName = checkProduct.Title,
                    Alias = checkProduct.Alias,
                    CategoryName = checkProduct.ProductCategory.Title,
                    Quantity = quantity
                };
                if (checkProduct.ProductImage.FirstOrDefault(a => a.IsDefault) != null)
                {
                    item.ProductImg = checkProduct.ProductImage.FirstOrDefault(a => a.IsDefault).Image;
                }
                item.Price = checkProduct.Price;
                if (checkProduct.PriceSale > 0)
                {
                    item.Price = (decimal)checkProduct.PriceSale;
                }
                item.TotalPrice = item.Quantity * item.Price;              
                cart.AddToCard(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }
    }
}
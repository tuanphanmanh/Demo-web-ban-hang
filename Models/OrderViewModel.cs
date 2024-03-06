using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Tên khách hàng không được bỏ trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống")]
        public string Email { get; set; }
        public string TypePayment { get; set; }

        [Required(ErrorMessage = "Loại địa chỉ không được bỏ trống")]
        public string AddressType { get; set; }
        public string MessegesForBuyer { get; set; }
        public string ShippingUnit { get; set; }
        public string Voucher { get; set; }
    }
}
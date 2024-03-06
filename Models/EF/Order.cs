using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được bỏ trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "không được bỏ trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Loại địa chỉ không được bỏ trống")]
        public string AddressType { get; set; }
        public string MessegesForBuyer { get; set; }
        public string ShippingUnit { get; set; }
        public string Voucher { get; set; }
        public string TypePayment { get; set; }  
        public int Quantity { get; set; }  
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
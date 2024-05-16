using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product() { 
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Wishlists = new HashSet<Wishlist>();
            this.ReviewProducts = new HashSet<ReviewProduct>();
            this.ProductDetail = new HashSet<ProductDetail>();
            this.SignUpForTestDrive = new HashSet<SignUpForTestDrive>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public int NumberOfSeats { get; set; }
        public string Design { get; set; }
        public string Fuel { get; set; }
        public string Origin { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantity { get; set; }
        public int NhapThemVao { get; set; }
        [NotMapped]
        public int SoHangTon
        {
            get
            {
                int daBan = OrderDetails.Sum(od => od.Quantity); // Tính tổng số hàng đã bán từ bảng OrderDetail
                return Quantity + NhapThemVao - daBan;
            }
        }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductDetail> ProductDetail { get; set; }
        public virtual ICollection<SignUpForTestDrive> SignUpForTestDrive { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
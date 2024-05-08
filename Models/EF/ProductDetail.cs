using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_ProductDetail")]

    public class ProductDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string KichThuoc { get; set; }
        public string DoiXe { get; set; }
        public int KhoangSangGamXe { get; set; }
        public float BanKinhVongQUay { get; set; }
        public int WeightKhongTai { get; set; }
        public int WeightToanTai { get; set; }
        public string ChieuRongCoSo { get; set; }
        public string LoaiDongCo { get; set; }
        public string LoaiSo { get; set; }
        public string KichThuocLopXe { get; set; }
        public string CongSuatToiDa { get; set; }
        public string HeThongNhienLieu { get; set; }
        public int SoXyLanh { get; set; }
        public string DungTichXyLanh { get; set; }
        public string BoTriXyLanh { get; set; }
        public string HeThongTruyenDong { get; set; }
        public string HopSo { get; set; }
        public string LoaiVanh { get; set; }
        public string PhanhTruoc { get; set; }
        public string PhanhSau { get; set; }
        public string TieuChuanKhiThai { get; set; }
        public string MucTieuThuTrong { get; set; }
        public string MucTieuThuNgoai { get; set; }
        public string MucTieuThuHonHop { get; set; }
        public virtual Product Product { get; set; }
    }
} 
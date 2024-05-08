using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_SignUpForTestDrive")]
    public class SignUpForTestDrive : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DiaChiLienHe { get; set; }
        public string DiaDiemLaiThu { get; set; }
        public string HinhThucMuaXe { get; set; }
        public string SoHuuXe { get; set; }
        public string KhuVuc { get; set; }
        public string BuyCarTime { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }

}
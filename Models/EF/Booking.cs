using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Booking")]
    public class Booking : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        [Required(ErrorMessage ="Không được để trống SĐT")]
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string CarName { get; set; }
        public string CustomerTime { get; set; }
        public virtual Service Service { get; set; }

    }
}
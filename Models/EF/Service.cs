﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Service")]
    public class Service : CommonAbstract
    {
        public Service()
        {
            this.Bookings = new HashSet<Booking>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }     
        public string Description { get; set; }     
        public decimal PriceOfSerVice { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
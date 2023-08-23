﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ecommerceWebMvc.Models.Classes
{
    public class mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Gonderici { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Alici { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string İcerik { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime tarih { get; set; }
    }
}
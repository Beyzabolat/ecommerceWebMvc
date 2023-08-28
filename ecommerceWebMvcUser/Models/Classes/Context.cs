using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ecommerceWebMvcUser.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        //public DbSet<Detay> Detays { get; set; }

    }
}
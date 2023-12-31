﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ecommerceWebMvc.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Kategori> Kategoris { get; set; }

     
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        //public DbSet<Kategori> kate { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareketi> SatisHareketis { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Detay> Detays { get; set; }
       
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<mesajlar> mesajlars { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Classes
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
     
        public string UrunAdi { get; set; }

       
        public string Marka { get; set; }
       
      
        
        public string UrunGorsel { get; set; }
     
        public string Renk { get; set; }
       
        public string Beden { get; set; }
       
        public int Numara { get; set; }
     
       
    }
}

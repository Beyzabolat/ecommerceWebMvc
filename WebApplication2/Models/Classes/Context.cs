using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.Classes
{
    public class Context : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Urunler> Urunlers { get; set; }
    }
}

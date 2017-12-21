using ClothApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClothApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClothType> ClothTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cloth> Clothes { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
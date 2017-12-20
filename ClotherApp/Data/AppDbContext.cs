using ClotherApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClotherApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClotherType> ClotherTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Clother> Clothers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
namespace ClothApp.Migrations
{
    using ClothApp.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClothApp.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClothApp.Data.AppDbContext context)
        {
            context.Brands.AddOrUpdate(_ => _.Name, new Brand { Name = "KetayMade" });
            context.Brands.AddOrUpdate(_ => _.Name, new Brand { Name = "Reebok" });

            context.ClothTypes.AddOrUpdate(_ => _.Name, new ClothType { Name = "Sneakers" });
            context.ClothTypes.AddOrUpdate(_ => _.Name, new ClothType { Name = "T-shirt" });
        }
    }
}

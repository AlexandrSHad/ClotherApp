namespace ClotherApp.Migrations
{
    using ClotherApp.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClotherApp.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClotherApp.Data.AppDbContext context)
        {
            context.Brands.AddOrUpdate(_ => _.Name, new Brand { Name = "KetayMade" });
            context.Brands.AddOrUpdate(_ => _.Name, new Brand { Name = "Reebok" });

            context.ClotherTypes.AddOrUpdate(_ => _.Name, new ClotherType { Name = "Sneakers" });
            context.ClotherTypes.AddOrUpdate(_ => _.Name, new ClotherType { Name = "T-shirt" });
        }
    }
}

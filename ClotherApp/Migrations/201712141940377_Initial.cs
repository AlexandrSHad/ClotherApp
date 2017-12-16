namespace ClotherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clothers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ClotherTypeId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.ClotherTypes", t => t.ClotherTypeId, cascadeDelete: true)
                .Index(t => t.ClotherTypeId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.ClotherTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothers", "ClotherTypeId", "dbo.ClotherTypes");
            DropForeignKey("dbo.Clothers", "BrandId", "dbo.Brands");
            DropIndex("dbo.Clothers", new[] { "BrandId" });
            DropIndex("dbo.Clothers", new[] { "ClotherTypeId" });
            DropTable("dbo.ClotherTypes");
            DropTable("dbo.Clothers");
            DropTable("dbo.Brands");
        }
    }
}

namespace ClothApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameToCloth : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClotherTypes", newName: "ClothTypes");
            DropForeignKey("dbo.Clothers", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Clothers", "ClotherTypeId", "dbo.ClotherTypes");
            DropForeignKey("dbo.Pictures", "ClotherId", "dbo.Clothers");
            DropIndex("dbo.Clothers", new[] { "ClotherTypeId" });
            DropIndex("dbo.Clothers", new[] { "BrandId" });
            DropIndex("dbo.Pictures", new[] { "ClotherId" });
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClothTypeId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.ClothTypes", t => t.ClothTypeId, cascadeDelete: true)
                .Index(t => t.ClothTypeId)
                .Index(t => t.BrandId);
            
            AddColumn("dbo.Pictures", "ClothId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "ClothId");
            AddForeignKey("dbo.Pictures", "ClothId", "dbo.Clothes", "Id", cascadeDelete: true);
            DropColumn("dbo.Pictures", "ClotherId");
            DropTable("dbo.Clothers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clothers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClotherTypeId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pictures", "ClotherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Pictures", "ClothId", "dbo.Clothes");
            DropForeignKey("dbo.Clothes", "ClothTypeId", "dbo.ClothTypes");
            DropForeignKey("dbo.Clothes", "BrandId", "dbo.Brands");
            DropIndex("dbo.Pictures", new[] { "ClothId" });
            DropIndex("dbo.Clothes", new[] { "BrandId" });
            DropIndex("dbo.Clothes", new[] { "ClothTypeId" });
            DropColumn("dbo.Pictures", "ClothId");
            DropTable("dbo.Clothes");
            CreateIndex("dbo.Pictures", "ClotherId");
            CreateIndex("dbo.Clothers", "BrandId");
            CreateIndex("dbo.Clothers", "ClotherTypeId");
            AddForeignKey("dbo.Pictures", "ClotherId", "dbo.Clothers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clothers", "ClotherTypeId", "dbo.ClotherTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clothers", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ClothTypes", newName: "ClotherTypes");
        }
    }
}

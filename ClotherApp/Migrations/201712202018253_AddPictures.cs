namespace ClothApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                        ClotherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clothers", t => t.ClotherId, cascadeDelete: true)
                .Index(t => t.ClotherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "ClotherId", "dbo.Clothers");
            DropIndex("dbo.Pictures", new[] { "ClotherId" });
            DropTable("dbo.Pictures");
        }
    }
}

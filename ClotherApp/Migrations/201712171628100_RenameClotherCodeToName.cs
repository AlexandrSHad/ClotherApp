namespace ClotherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameClotherCodeToName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clothers", "Name", c => c.String());
            DropColumn("dbo.Clothers", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clothers", "Code", c => c.String());
            DropColumn("dbo.Clothers", "Name");
        }
    }
}

namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Category");
        }
    }
}

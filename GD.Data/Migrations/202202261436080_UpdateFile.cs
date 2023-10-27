namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Path", c => c.String(maxLength: 4000));
            DropColumn("dbo.Files", "Patch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "Patch", c => c.String(maxLength: 4000));
            DropColumn("dbo.Files", "Path");
        }
    }
}

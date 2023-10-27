namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Author");
        }
    }
}

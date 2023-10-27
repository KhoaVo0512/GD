namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePreviewImageFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "PreviewImage", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "PreviewImage");
        }
    }
}

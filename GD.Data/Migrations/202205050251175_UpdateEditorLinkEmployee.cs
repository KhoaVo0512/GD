namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEditorLinkEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EditorLink", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EditorLink");
        }
    }
}

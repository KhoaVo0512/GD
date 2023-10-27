namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LevelQuestions", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.TypeQuestions", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeQuestions", "DisplayOrder");
            DropColumn("dbo.LevelQuestions", "DisplayOrder");
        }
    }
}

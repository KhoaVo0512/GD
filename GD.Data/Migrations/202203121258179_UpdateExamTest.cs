namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExamTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.Exams", "View", c => c.String());
            AddColumn("dbo.Tests", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "View", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "View");
            DropColumn("dbo.Tests", "Time");
            DropColumn("dbo.Exams", "View");
            DropColumn("dbo.Exams", "Time");
        }
    }
}

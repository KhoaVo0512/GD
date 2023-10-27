namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyFile : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Files", "CourseId");
            CreateIndex("dbo.Files", "TopicId");
            AddForeignKey("dbo.Files", "CourseId", "dbo.Courses", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Files", "TopicId", "dbo.Topics", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Files", "CourseId", "dbo.Courses");
            DropIndex("dbo.Files", new[] { "TopicId" });
            DropIndex("dbo.Files", new[] { "CourseId" });
        }
    }
}

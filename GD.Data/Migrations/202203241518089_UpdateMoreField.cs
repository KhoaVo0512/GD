namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoreField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradeGroups", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Grades", "Prefix", c => c.String());
            AddColumn("dbo.StudentGrades", "ScholasticId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentGrades", "ScholasticId");
            AddForeignKey("dbo.StudentGrades", "ScholasticId", "dbo.Scholastics", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "ScholasticId", "dbo.Scholastics");
            DropIndex("dbo.StudentGrades", new[] { "ScholasticId" });
            DropColumn("dbo.StudentGrades", "ScholasticId");
            DropColumn("dbo.Grades", "Prefix");
            DropColumn("dbo.Grades", "Number");
            DropColumn("dbo.GradeGroups", "Number");
        }
    }
}

namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentGrade : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StudentGrades");
            AddColumn("dbo.StudentGrades", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentGrades", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StudentGrades");
            DropColumn("dbo.StudentGrades", "ID");
            AddPrimaryKey("dbo.StudentGrades", new[] { "StudentId", "GradeId" });
        }
    }
}

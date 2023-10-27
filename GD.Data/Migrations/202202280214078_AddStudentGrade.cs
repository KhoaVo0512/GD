namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentGrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 256),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 256),
                        ActiveDate = c.DateTime(),
                        ActiveBy = c.String(maxLength: 256),
                        Active = c.Boolean(nullable: false),
                        ApproveDate = c.DateTime(),
                        ApproveBy = c.String(maxLength: 256),
                        Approve = c.Int(),
                        ApproveLevel = c.Int(),
                    })
                .PrimaryKey(t => new { t.StudentId, t.GradeId })
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentGrades", "GradeId", "dbo.Grades");
            DropIndex("dbo.StudentGrades", new[] { "GradeId" });
            DropIndex("dbo.StudentGrades", new[] { "StudentId" });
            DropTable("dbo.StudentGrades");
        }
    }
}

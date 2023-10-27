namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserGrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGrades",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
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
                .PrimaryKey(t => new { t.UserId, t.GradeId })
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGrades", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.UserGrades", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.UserGrades", new[] { "GradeId" });
            DropIndex("dbo.UserGrades", new[] { "UserId" });
            DropTable("dbo.UserGrades");
        }
    }
}

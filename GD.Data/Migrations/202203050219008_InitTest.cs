namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 4000),
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
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.ExamTests", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestQuestions", "TestId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamTests", "TestId");
            CreateIndex("dbo.TestQuestions", "TestId");
            AddForeignKey("dbo.ExamTests", "TestId", "dbo.Tests", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests", "ID", cascadeDelete: true);
            DropColumn("dbo.ExamTests", "TestName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamTests", "TestName", c => c.String());
            DropForeignKey("dbo.TestQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.ExamTests", "TestId", "dbo.Tests");
            DropIndex("dbo.TestQuestions", new[] { "TestId" });
            DropIndex("dbo.ExamTests", new[] { "TestId" });
            AlterColumn("dbo.TestQuestions", "TestId", c => c.String(nullable: false));
            AlterColumn("dbo.ExamTests", "TestId", c => c.String(nullable: false));
            DropTable("dbo.Tests");
        }
    }
}

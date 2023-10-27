namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPuzzle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Puzzles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Suggest = c.String(maxLength: 4000),
                        Answer = c.String(maxLength: 4000),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Puzzles");
        }
    }
}

namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeLevelQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamLevels", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamLevels", "Type");
        }
    }
}

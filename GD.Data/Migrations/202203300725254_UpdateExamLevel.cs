namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExamLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamLevels", "TypePoint", c => c.Int(nullable: false));
            AddColumn("dbo.ExamLevels", "SumPoint", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamLevels", "SumPoint");
            DropColumn("dbo.ExamLevels", "TypePoint");
        }
    }
}

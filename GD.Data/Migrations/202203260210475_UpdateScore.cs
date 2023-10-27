namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateScore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "TypeScoreId", "dbo.TypeScores");
            DropIndex("dbo.Scores", new[] { "TypeScoreId" });
            AddColumn("dbo.Scores", "GradeId", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "Code", c => c.String());
            AddColumn("dbo.Scores", "FullName", c => c.String());
            AddColumn("dbo.Scores", "PointDDGTXOne", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGTXTwo", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGTXThree", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGTXFour", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGTXFive", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGGK", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDDGCK", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "PointDTBMHK", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Scores", "Type", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "GradeId");
            AddForeignKey("dbo.Scores", "GradeId", "dbo.Grades", "ID", cascadeDelete: false);
            DropColumn("dbo.Scores", "Point");
            DropColumn("dbo.Scores", "TypeScoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "TypeScoreId", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "Point", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Scores", "GradeId", "dbo.Grades");
            DropIndex("dbo.Scores", new[] { "GradeId" });
            DropColumn("dbo.Scores", "Type");
            DropColumn("dbo.Scores", "PointDTBMHK");
            DropColumn("dbo.Scores", "PointDDGCK");
            DropColumn("dbo.Scores", "PointDDGGK");
            DropColumn("dbo.Scores", "PointDDGTXFive");
            DropColumn("dbo.Scores", "PointDDGTXFour");
            DropColumn("dbo.Scores", "PointDDGTXThree");
            DropColumn("dbo.Scores", "PointDDGTXTwo");
            DropColumn("dbo.Scores", "PointDDGTXOne");
            DropColumn("dbo.Scores", "FullName");
            DropColumn("dbo.Scores", "Code");
            DropColumn("dbo.Scores", "GradeId");
            CreateIndex("dbo.Scores", "TypeScoreId");
            AddForeignKey("dbo.Scores", "TypeScoreId", "dbo.TypeScores", "ID", cascadeDelete: true);
        }
    }
}

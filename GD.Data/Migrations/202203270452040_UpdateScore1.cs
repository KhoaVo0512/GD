namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateScore1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "BirthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "BirthDay");
        }
    }
}

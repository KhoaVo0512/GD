﻿namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "ManageBy", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "ManageBy");
        }
    }
}

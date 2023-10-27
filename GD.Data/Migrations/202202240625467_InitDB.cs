namespace GD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Content = c.String(storeType: "ntext"),
                        Correct = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Content = c.String(storeType: "ntext"),
                        TypeId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        ManyAnswer = c.Boolean(nullable: false),
                        LineNumber = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        Point = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LevelQuestions", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.TypeQuestions", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.LevelId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.LevelQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        TypeId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TypeQuestions", t => t.TypeId, cascadeDelete: false)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.TypeQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Choice = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        CourseId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        GradeGroupId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        Point = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GradeGroups", t => t.GradeGroupId, cascadeDelete: true)
                .Index(t => t.GradeGroupId);
            
            CreateTable(
                "dbo.GradeGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        SchoolId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
                        Address = c.String(maxLength: 500),
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
            
            CreateTable(
                "dbo.ApplicationGroupMenus",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.MenuId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Caption = c.String(nullable: false, maxLength: 256),
                        URL = c.String(nullable: false, maxLength: 4000),
                        DisplayOrder = c.Int(),
                        GroupId = c.Int(nullable: false),
                        Icon = c.String(maxLength: 4000),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Caption = c.String(nullable: false, maxLength: 256),
                        ClassIcon = c.String(maxLength: 4000),
                        DisplayOrder = c.Int(nullable: false),
                        DisplayPosition = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.ApplicationGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 256),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Male = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        PhoneNumber = c.String(maxLength: 256),
                        Email = c.String(maxLength: 256),
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
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Value = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
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
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Code = c.String(maxLength: 256),
                        ProvinceId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Code = c.String(maxLength: 256),
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
            
            CreateTable(
                "dbo.ExamLevels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.LevelQuestions", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 256),
                        NumberTest = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.ExamTests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        TestId = c.String(nullable: false),
                        TestName = c.String(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Size = c.Double(nullable: false),
                        Patch = c.String(maxLength: 4000),
                        Type = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ScholasticId = c.Int(nullable: false),
                        GradeGroupId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GradeGroups", t => t.GradeGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Scholastics", t => t.ScholasticId, cascadeDelete: true)
                .Index(t => t.ScholasticId)
                .Index(t => t.GradeGroupId);
            
            CreateTable(
                "dbo.Scholastics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 500),
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
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Point = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                        TypeScoreId = c.Int(nullable: false),
                        ScholasticId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Scholastics", t => t.ScholasticId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TypeScores", t => t.TypeScoreId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TypeScoreId)
                .Index(t => t.ScholasticId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 256),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Male = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        PhoneNumber = c.String(maxLength: 256),
                        ProvinceId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                        Street = c.String(maxLength: 256),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: false)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.ProvinceId)
                .Index(t => t.DistrictId)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Code = c.String(maxLength: 256),
                        DistrictId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.TypeScores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
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
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TestId = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
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
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserGradeGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GradeGroupId = c.Int(nullable: false),
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
                .PrimaryKey(t => new { t.UserId, t.GradeGroupId })
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.GradeGroups", t => t.GradeGroupId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GradeGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGradeGroups", "GradeGroupId", "dbo.GradeGroups");
            DropForeignKey("dbo.UserGradeGroups", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.UserCourses", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.TestQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Scores", "TypeScoreId", "dbo.TypeScores");
            DropForeignKey("dbo.Scores", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Wards", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Students", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Students", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Scores", "ScholasticId", "dbo.Scholastics");
            DropForeignKey("dbo.Scores", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.Grades", "ScholasticId", "dbo.Scholastics");
            DropForeignKey("dbo.Grades", "GradeGroupId", "dbo.GradeGroups");
            DropForeignKey("dbo.ExamTests", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ExamLevels", "LevelId", "dbo.LevelQuestions");
            DropForeignKey("dbo.ExamLevels", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUsers", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.ApplicationUsers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationGroupMenus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups");
            DropForeignKey("dbo.ApplicationGroupMenus", "GroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TypeId", "dbo.TypeQuestions");
            DropForeignKey("dbo.Questions", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "GradeGroupId", "dbo.GradeGroups");
            DropForeignKey("dbo.GradeGroups", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Questions", "LevelId", "dbo.LevelQuestions");
            DropForeignKey("dbo.LevelQuestions", "TypeId", "dbo.TypeQuestions");
            DropIndex("dbo.UserGradeGroups", new[] { "GradeGroupId" });
            DropIndex("dbo.UserGradeGroups", new[] { "UserId" });
            DropIndex("dbo.UserCourses", new[] { "CourseId" });
            DropIndex("dbo.UserCourses", new[] { "UserId" });
            DropIndex("dbo.TestQuestions", new[] { "QuestionId" });
            DropIndex("dbo.Wards", new[] { "DistrictId" });
            DropIndex("dbo.Students", new[] { "WardId" });
            DropIndex("dbo.Students", new[] { "DistrictId" });
            DropIndex("dbo.Students", new[] { "ProvinceId" });
            DropIndex("dbo.Scores", new[] { "StudentId" });
            DropIndex("dbo.Scores", new[] { "ScholasticId" });
            DropIndex("dbo.Scores", new[] { "TypeScoreId" });
            DropIndex("dbo.Scores", new[] { "CourseId" });
            DropIndex("dbo.Grades", new[] { "GradeGroupId" });
            DropIndex("dbo.Grades", new[] { "ScholasticId" });
            DropIndex("dbo.ExamTests", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "TopicId" });
            DropIndex("dbo.ExamLevels", new[] { "LevelId" });
            DropIndex("dbo.ExamLevels", new[] { "ExamId" });
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropIndex("dbo.ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUsers", new[] { "LevelId" });
            DropIndex("dbo.ApplicationUsers", new[] { "EmployeeId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.Menus", new[] { "GroupId" });
            DropIndex("dbo.ApplicationGroupMenus", new[] { "MenuId" });
            DropIndex("dbo.ApplicationGroupMenus", new[] { "GroupId" });
            DropIndex("dbo.GradeGroups", new[] { "SchoolId" });
            DropIndex("dbo.Courses", new[] { "GradeGroupId" });
            DropIndex("dbo.Topics", new[] { "CourseId" });
            DropIndex("dbo.LevelQuestions", new[] { "TypeId" });
            DropIndex("dbo.Questions", new[] { "TopicId" });
            DropIndex("dbo.Questions", new[] { "LevelId" });
            DropIndex("dbo.Questions", new[] { "TypeId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.UserGradeGroups");
            DropTable("dbo.UserCourses");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.TypeScores");
            DropTable("dbo.Wards");
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.Scholastics");
            DropTable("dbo.Grades");
            DropTable("dbo.Files");
            DropTable("dbo.ExamTests");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamLevels");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.Levels");
            DropTable("dbo.Employees");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Menus");
            DropTable("dbo.ApplicationGroups");
            DropTable("dbo.ApplicationGroupMenus");
            DropTable("dbo.Schools");
            DropTable("dbo.GradeGroups");
            DropTable("dbo.Courses");
            DropTable("dbo.Topics");
            DropTable("dbo.TypeQuestions");
            DropTable("dbo.LevelQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}

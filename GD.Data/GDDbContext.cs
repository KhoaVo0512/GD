using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GD.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using GD.Model.Abstract;

namespace GD.Data
{
    public class GDDbContext: IdentityDbContext<ApplicationUser>
    {
        public GDDbContext() : base("GDConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        // system
        public DbSet<Level> Levels { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }
        public DbSet<ApplicationGroupMenu> ApplicationGroupMenus { set; get; }
        public DbSet<UserCourse> UserCourses { set; get; }
        public DbSet<UserGradeGroup> UserGradeGroups { set; get; }
        public DbSet<UserGrade> UserGrades { set; get; }
        // category
        public DbSet<Answer> Answers { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<Exam> Exams { set; get; }
        public DbSet<ExamLevel> ExamLevels { set; get; }
        public DbSet<ExamTest> ExamTests { set; get; }
        public DbSet<File> Files { set; get; }
        public DbSet<Grade> Grades { set; get; }
        public DbSet<GradeGroup> GradeGroups { set; get; }
        public DbSet<LevelQuestion> LevelQuestions { set; get; }
        public DbSet<Province> Provinces { set; get; }
        public DbSet<Question> Questions { set; get; }
        public DbSet<Scholastic> Scholastics { set; get; }
        public DbSet<School> Schools { set; get; }
        public DbSet<Score> Scores { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<TestQuestion> TestQuestions { set; get; }
        public DbSet<Topic> Topics { set; get; }
        public DbSet<TypeQuestion> TypeQuestions { set; get; }
        public DbSet<TypeScore> TypeScores { set; get; }
        public DbSet<Ward> Wards { set; get; }
        public DbSet<StudentGrade> StudentGrades { set; get; }
        public DbSet<Test> Tests { set; get; }
        public DbSet<Puzzle> Puzzles { set; get; }

        public static GDDbContext Create()
        {
            return new GDDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
    }
}

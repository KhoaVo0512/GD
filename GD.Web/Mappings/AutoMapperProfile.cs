using AutoMapper;
using GD.Model.Models;
using GD.Web.Models;

namespace GD.Web.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ApplicationGroup, ApplicationGroupViewModel>();
            CreateMap<ApplicationRole, ApplicationRoleViewModel>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Level, LevelViewModel>();
            CreateMap<Menu, MenuViewModel>();
            CreateMap<MenuGroup, MenuGroupViewModel>();

            CreateMap<School, SchoolViewModel>();
            CreateMap<Scholastic, ScholasticViewModel>();
            CreateMap<GradeGroup, GradeGroupViewModel>();
            CreateMap<Grade, GradeViewModel>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<Topic, TopicViewModel>();
            CreateMap<File, FileViewModel>();
            CreateMap<Province, ProvinceViewModel>();
            CreateMap<District, DistrictViewModel>();
            CreateMap<Ward, WardViewModel>();
            CreateMap<TypeQuestion, TypeQuestionViewModel>();
            CreateMap<LevelQuestion, LevelQuestionViewModel>();
            CreateMap<TypeScore, TypeScoreViewModel>();
            CreateMap<Student, StudentViewModel>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<Answer, AnswerViewModel>();
            CreateMap<Exam, ExamViewModel>();
            CreateMap<ExamLevel, ExamLevelViewModel>();
            CreateMap<Test, TestViewModel>();
            CreateMap<StudentGrade, StudentGradeViewModel>();
            CreateMap<Score, ScoreViewModel>();
            CreateMap<Puzzle, PuzzleViewModel>();
        }
    }
}
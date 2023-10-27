using GD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GD.Web
{

    public class EmployeeGlobal
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string FullName { set; get; }
        public bool Male { set; get; }
        public DateTime BirthDay { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { get; set; }
        public string EditorLink { get; set; }

        public List<GradeGroupViewModel> GradeGroups { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public List<GradeViewModel> Grades { get; set; }
    }

    public class TypeQuestionGlobal
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public bool Choice { set; get; }

        public decimal Point { set; get; }

        public int DisplayOrder { set; get; }

        public List<QuestionViewModel> Questions { get; set; }
    }

    public class LevelQuestionGlobal
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public int TypeId { set; get; }

        public string TypeName { set; get; }

        public decimal Point { set; get; }

        public int DisplayOrder { set; get; }

        public int TypeScore { set; get; }

        public List<QuestionViewModel> Questions { get; set; }
    }

    public class TitleScore
    {
        public string ManageBy { set; get; }

        public string School { set; get; }

        public string Course { set; get; }

        public string Grade { set; get; }
    }

    public class DataReport
    {
        public string Name { set; get; }

        public int Number { set; get; }
    }
}
using GD.Model.Models;
using GD.Web.Models;
using System;

namespace GD.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        
        public static void UpdateLevel(this Level level, LevelViewModel levelViewModel)
        {
            level.ID = levelViewModel.ID;
            level.Name = levelViewModel.Name;
            level.Value = levelViewModel.Value;
            level.Description = levelViewModel.Description;
            
        }
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }
        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateApplicationUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
           
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.LevelId = appUserViewModel.LevelId;
            appUser.EmployeeId = appUserViewModel.EmployeeId;
            appUser.LockoutEnabled = appUserViewModel.LockoutEnabled;
            appUser.LockoutEndDateUtc = appUserViewModel.LockoutEndDateUtc;


        }
        public static void UpdateMenu(this Menu menu, MenuViewModel menuViewModel)
        {
            menu.ID = menuViewModel.ID;
            menu.Name = menuViewModel.Name;
            menu.Caption = menuViewModel.Caption;
            menu.URL = menuViewModel.URL;
            menu.DisplayOrder = menuViewModel.DisplayOrder;
            menu.GroupId = menuViewModel.GroupId;
            menu.Icon = menuViewModel.Icon;
            menu.Description = menuViewModel.Description;
        }

        public static void UpdateMenuGroup(this MenuGroup menuGroup, MenuGroupViewModel menuGroupViewModel)
        {
            menuGroup.ID = menuGroupViewModel.ID;
            menuGroup.Name = menuGroupViewModel.Name;
            menuGroup.Caption = menuGroupViewModel.Caption;
            menuGroup.ClassIcon = menuGroupViewModel.ClassIcon;
            menuGroup.DisplayOrder = menuGroupViewModel.DisplayOrder;
            menuGroup.DisplayPosition = menuGroupViewModel.DisplayPosition;
        }

        public static void UpdateSchool(this School school, SchoolViewModel schoolViewModel)
        {
            school.ID = schoolViewModel.ID;
            school.Code = schoolViewModel.Code;
            school.Name = schoolViewModel.Name;
            school.Address = schoolViewModel.Address;
            school.Description = schoolViewModel.Description;
            school.ManageBy = schoolViewModel.ManageBy;
        }

        public static void UpdateScholastic(this Scholastic scholastic, ScholasticViewModel scholasticViewModel)
        {
            scholastic.ID = scholasticViewModel.ID;
            scholastic.Name = scholasticViewModel.Name;
            scholastic.FromTime = scholasticViewModel.FromTime;
            scholastic.ToTime = scholasticViewModel.ToTime;
            scholastic.Description = scholasticViewModel.Description;
        }

        public static void UpdateGradeGroup(this GradeGroup gradeGroup, GradeGroupViewModel gradeGroupViewModel)
        {
            gradeGroup.ID = gradeGroupViewModel.ID;
            gradeGroup.Name = gradeGroupViewModel.Name;
            gradeGroup.Number = gradeGroupViewModel.Number;
            gradeGroup.SchoolId = gradeGroupViewModel.SchoolId;
            gradeGroup.Description = gradeGroupViewModel.Description;
        }

        public static void UpdateGrade(this Grade grade, GradeViewModel gradeViewModel)
        {
            grade.ID = gradeViewModel.ID;
            grade.Name = gradeViewModel.Name;
            grade.Number = gradeViewModel.Number;
            grade.Prefix = gradeViewModel.Prefix;
            grade.ScholasticId = gradeViewModel.ScholasticId;
            grade.GradeGroupId = gradeViewModel.GradeGroupId;
            grade.Description = gradeViewModel.Description;
        }

        public static void UpdateCourse(this Course course, CourseViewModel courseViewModel)
        {
            course.ID = courseViewModel.ID;
            course.Name = courseViewModel.Name;
            course.GradeGroupId = courseViewModel.GradeGroupId;
            course.Point = courseViewModel.Point;
            course.Description = courseViewModel.Description;
        }

        public static void UpdateTopic(this Topic topic, TopicViewModel topicViewModel)
        {
            topic.ID = topicViewModel.ID;
            topic.Name = topicViewModel.Name;
            topic.CourseId = topicViewModel.CourseId;
            topic.Description = topicViewModel.Description;
        }

        public static void UpdateFile(this File file, FileViewModel fileViewModel)
        {
            file.ID = fileViewModel.ID;
            file.Name = fileViewModel.Name;
            file.Size = fileViewModel.Size;
            file.Path = fileViewModel.Path;
            file.PreviewImage = fileViewModel.PreviewImage;
            file.Type = fileViewModel.Type;
            file.Category = fileViewModel.Category;
            file.Author = fileViewModel.Author;
            file.CourseId = fileViewModel.CourseId;
            file.TopicId = fileViewModel.TopicId;
            file.Description = fileViewModel.Description;
            file.ApproveBy = fileViewModel.ApproveBy;
        }

        public static void UpdateEmployee(this Employee employee, EmployeeViewModel employeeViewModel)
        {
            employee.ID = employeeViewModel.ID;
            employee.Code = employeeViewModel.Code;
            employee.FullName = employeeViewModel.FullName;
            employee.Male = employeeViewModel.Male;
            employee.BirthDay = employeeViewModel.BirthDay;
            employee.PhoneNumber = employeeViewModel.PhoneNumber;
            employee.Email = employeeViewModel.Email;
            employee.EditorLink = employeeViewModel.EditorLink;
        }

        public static void UpdateProvince(this Province province, ProvinceViewModel provinceViewModel)
        {
            province.ID = provinceViewModel.ID;
            province.Code = provinceViewModel.Code;
            province.Name = provinceViewModel.Name;
        }

        public static void UpdateDistrict(this District district, DistrictViewModel districtViewModel)
        {
            district.ID = districtViewModel.ID;
            district.Code = districtViewModel.Code;
            district.Name = districtViewModel.Name;
            district.ProvinceId = districtViewModel.ProvinceId;
        }

        public static void UpdateWard(this Ward ward, WardViewModel wardViewModel)
        {
            ward.ID = wardViewModel.ID;
            ward.Code = wardViewModel.Code;
            ward.Name = wardViewModel.Name;
            ward.DistrictId = wardViewModel.DistrictId;
        }

        public static void UpdateTypeQuestion(this TypeQuestion typeQuestion, TypeQuestionViewModel typeQuestionViewModel)
        {
            typeQuestion.ID = typeQuestionViewModel.ID;
            typeQuestion.Name = typeQuestionViewModel.Name;
            typeQuestion.Choice = typeQuestionViewModel.Choice;
            typeQuestion.DisplayOrder = typeQuestionViewModel.DisplayOrder;
        }

        public static void UpdateLevelQuestion(this LevelQuestion levelQuestion, LevelQuestionViewModel levelQuestionViewModel)
        {
            levelQuestion.ID = levelQuestionViewModel.ID;
            levelQuestion.Name = levelQuestionViewModel.Name;
            levelQuestion.TypeId = levelQuestionViewModel.TypeId;
            levelQuestion.DisplayOrder = levelQuestionViewModel.DisplayOrder;
        }

        public static void UpdateTypeScore(this TypeScore typeScore, TypeScoreViewModel typeScoreViewModel)
        {
            typeScore.ID = typeScoreViewModel.ID;
            typeScore.Name = typeScoreViewModel.Name;
            typeScore.Point = typeScoreViewModel.Point;
            typeScore.Description = typeScoreViewModel.Description;
        }

        public static void UpdateStudent(this Student student, StudentViewModel studentViewModel)
        {
            student.ID = studentViewModel.ID;
            student.Code = studentViewModel.Code;
            student.FullName = studentViewModel.FullName;
            student.Male = studentViewModel.Male;
            student.BirthDay = studentViewModel.BirthDay;
            student.PhoneNumber = studentViewModel.PhoneNumber;
            student.ProvinceId = studentViewModel.ProvinceId;
            student.DistrictId = studentViewModel.DistrictId;
            student.WardId = studentViewModel.WardId;
            student.Street = studentViewModel.Street;
        }

        public static void UpdateQuestion(this Question question, QuestionViewModel questionViewModel)
        {
            question.ID = questionViewModel.ID;
            question.Name = questionViewModel.Name;
            question.Content = questionViewModel.Content;
            question.TypeId = questionViewModel.TypeId;
            question.LevelId = questionViewModel.LevelId;
            question.ManyAnswer = questionViewModel.ManyAnswer;
            question.LineNumber = questionViewModel.LineNumber;
            question.TopicId = questionViewModel.TopicId;
            question.Point = questionViewModel.Point;
        }

        public static void UpdateAnswer(this Answer answer, AnswerViewModel answerViewModel)
        {
            answer.ID = answerViewModel.ID;
            answer.Name = answerViewModel.Name;
            answer.Content = answerViewModel.Content;
            answer.QuestionId = answerViewModel.QuestionId;
            answer.Correct = answerViewModel.Correct;
        }

        public static void UpdateExam(this Exam exam, ExamViewModel examViewModel)
        {
            exam.ID = examViewModel.ID;
            exam.Name = examViewModel.Name;
            exam.Code = examViewModel.Code;
            exam.NumberTest = examViewModel.NumberTest;
            exam.TopicId = examViewModel.TopicId;
            exam.Time = examViewModel.Time;
            exam.View = examViewModel.View;
        }

        public static void UpdateExamLevel(this ExamLevel examLevel, ExamLevelViewModel examLevelViewModel)
        {
            examLevel.ID = examLevelViewModel.ID;
            examLevel.ExamId = examLevelViewModel.ExamId;
            examLevel.LevelId = examLevelViewModel.LevelId;
            examLevel.Number = examLevelViewModel.Number;
            examLevel.Type = examLevelViewModel.Type;
            examLevel.TypePoint = examLevelViewModel.TypePoint;
            examLevel.SumPoint = (decimal)examLevelViewModel.SumPoint;

        }

        public static void UpdateTest(this Test test, TestViewModel testViewModel)
        {
            test.ID = testViewModel.ID;
            test.Name = testViewModel.Name;
            test.Description = testViewModel.Description;
            test.Time = testViewModel.Time;
            test.View = testViewModel.View;
        }

        public static void UpdateStudentGrade(this StudentGrade studentGrade, StudentGradeViewModel studentGradeViewModel)
        {
            studentGrade.ID = studentGradeViewModel.ID;
            studentGrade.StudentId = studentGradeViewModel.StudentId;
            studentGrade.GradeId = studentGradeViewModel.GradeId;
            studentGrade.ScholasticId = studentGradeViewModel.ScholasticId;
        }

        public static void UpdateScore(this Score score, ScoreViewModel scoreViewModel)
        {
            score.ID = scoreViewModel.ID;
            score.ScholasticId = scoreViewModel.ScholasticId;
            score.CourseId = scoreViewModel.CourseId;
            score.GradeId = scoreViewModel.GradeId;
            score.StudentId = scoreViewModel.StudentId;
            score.Code = scoreViewModel.Code;
            score.FullName = scoreViewModel.FullName;
            score.BirthDay = scoreViewModel.BirthDay;
            score.PointDDGTXOne = scoreViewModel.PointDDGTXOne;
            score.PointDDGTXTwo = scoreViewModel.PointDDGTXTwo;
            score.PointDDGTXThree = scoreViewModel.PointDDGTXThree;
            score.PointDDGTXFour = scoreViewModel.PointDDGTXFour;
            score.PointDDGTXFive = scoreViewModel.PointDDGTXFive;
            score.PointDDGGK = scoreViewModel.PointDDGGK;
            score.PointDDGCK = scoreViewModel.PointDDGCK;
            score.PointDTBMHK = scoreViewModel.PointDTBMHK;
            score.Type = scoreViewModel.Type;
        }

        public static void UpdatePuzzle(this Puzzle puzzle, PuzzleViewModel puzzleViewModel)
        {
            puzzle.ID = puzzleViewModel.ID;
            puzzle.Suggest = puzzleViewModel.Suggest;
            puzzle.Answer = puzzleViewModel.Answer;
            puzzle.Description = puzzleViewModel.Description;
        }
    }
}
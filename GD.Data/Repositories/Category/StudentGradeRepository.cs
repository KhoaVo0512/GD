using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IStudentGradeRepository : IRepository<StudentGrade>
    {
        IEnumerable<Student> GetStudentByGrade(int grade, bool active);

        IEnumerable<Student> GetAllByListStudentAndScholastic(List<int> student, int scholastic);
    }

    public class StudentGradeRepository : RepositoryBase<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<Student> GetStudentByGrade(int grade, bool active)
        {
            var query = from g in DbContext.Students
                        join ug in DbContext.StudentGrades
                        on g.ID equals ug.StudentId
                        where ug.GradeId == grade && ug.Active == active
                        select g;
            return query;
        }

        public IEnumerable<Student> GetAllByListStudentAndScholastic(List<int> student, int scholastic)
        {
            var queryStudentGrades = from g in DbContext.StudentGrades
                                     join st in DbContext.Students
                                     on g.StudentId equals st.ID
                                     where g.ID == scholastic && g.Active == true && student.Contains(g.StudentId)
                                     select st;
            return queryStudentGrades;
        }
    }
}

using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetByOtherGrade(int scholastic, int grade);
    }

    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Student> GetByOtherGrade(int scholastic, int grade)
        {
            var queryStudentGrades = from g in DbContext.StudentGrades
                        where g.ScholasticId == scholastic && g.Active == true
                        select g;

            var listIdStudent = queryStudentGrades.Select(x => x.StudentId).ToList();

            var queryStudentOther = from g in DbContext.Students
                                    where !listIdStudent.Contains(g.ID)
                                    select g;

            return queryStudentOther;
        }
    }
}

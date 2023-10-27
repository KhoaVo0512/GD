using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IScoreRepository : IRepository<Score>
    {
        IEnumerable<Student> GetExistByListStudent(List<int> student, int scholastic, int grade, int course, int type);
    }

    public class ScoreRepository : RepositoryBase<Score>, IScoreRepository
    {
        public ScoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Student> GetExistByListStudent(List<int> student, int scholastic, int grade, int course, int type)
        {
            var query = from g in DbContext.Students
                                     join s in DbContext.Scores
                                     on g.ID equals s.StudentId
                                     where s.ScholasticId == scholastic && s.Active == true && student.Contains(s.StudentId) && s.GradeId == grade && s.CourseId == course && s.Type == type
                                     select g;
            return query;
        }
    }
}

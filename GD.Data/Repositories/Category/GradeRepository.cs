using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IGradeRepository : IRepository<Grade>
    {
        IEnumerable<Grade> GetListGradeUserId(string userId);

        IEnumerable<Grade> GetListGradeNotSubClass(int scholastic);
    }

    public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
    {
        public GradeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Grade> GetListGradeUserId(string userId)
        {
            var query = from g in DbContext.Grades
                        join ug in DbContext.UserGrades
                        on g.ID equals ug.GradeId
                        where ug.UserId == userId
                        select g;
            return query;
        }
        public IEnumerable<Grade> GetListGradeNotSubClass(int scholastic)
        {
            var queryStudentGrades = from g in DbContext.StudentGrades
                                     join ug in DbContext.Grades
                                     on g.GradeId equals ug.ID
                                     join us in DbContext.GradeGroups
                                     on ug.GradeGroupId equals us.ID
                                     join sch in DbContext.Scholastics
                                     on us.SchoolId equals sch.ID
                                     where sch.ID == scholastic && ug.Active == true
                                     select g;

            var listIdGrade = queryStudentGrades.Select(x => x.GradeId).ToList();

            var queryGradeOther = from g in DbContext.Grades
                                    where !listIdGrade.Contains(g.ID)
                                    select g;

            return queryGradeOther;
        }
    }

    
}

using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface ISchoolRepository : IRepository<School>
    {
        School GetByCourse(int course);
    }

    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public School GetByCourse(int course)
        {
            var query = from g in DbContext.Schools
                        join ug in DbContext.GradeGroups
                        on g.ID equals ug.SchoolId
                        join cs in DbContext.Courses
                        on ug.ID equals cs.GradeGroupId
                        where cs.ID == course && g.Active == true
                        select g;
            return query.FirstOrDefault();
        }
    }
}

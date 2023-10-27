using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetListCourseByUserId(string userId);
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Course> GetListCourseByUserId(string userId)
        {
            var query = from g in DbContext.Courses
                        join ug in DbContext.UserCourses
                        on g.ID equals ug.CourseId
                        where ug.UserId == userId
                        select g;
            return query;
        }
    }
}

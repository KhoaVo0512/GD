using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IUserCourseRepository : IRepository<UserCourse>
    {
    }

    public class UserCourseRepository : RepositoryBase<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

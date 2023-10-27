using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IUserGradeRepository : IRepository<UserGrade>
    {
    }

    public class UserGradeRepository : RepositoryBase<UserGrade>, IUserGradeRepository
    {
        public UserGradeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

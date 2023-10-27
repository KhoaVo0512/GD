using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IUserGradeGroupRepository : IRepository<UserGradeGroup>
    {
    }

    public class UserGradeGroupRepository : RepositoryBase<UserGradeGroup>, IUserGradeGroupRepository
    {
        public UserGradeGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IScholasticRepository : IRepository<Scholastic>
    {
    }

    public class ScholasticRepository : RepositoryBase<Scholastic>, IScholasticRepository
    {
        public ScholasticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

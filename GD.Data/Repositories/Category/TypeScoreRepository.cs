using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface ITypeScoreRepository : IRepository<TypeScore>
    {
    }

    public class TypeScoreRepository : RepositoryBase<TypeScore>, ITypeScoreRepository
    {
        public TypeScoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

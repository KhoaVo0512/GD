using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface ITypeQuestionRepository : IRepository<TypeQuestion>
    {
    }

    public class TypeQuestionRepository : RepositoryBase<TypeQuestion>, ITypeQuestionRepository
    {
        public TypeQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

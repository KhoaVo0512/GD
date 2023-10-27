using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface ILevelQuestionRepository : IRepository<LevelQuestion>
    {
    }

    public class LevelQuestionRepository : RepositoryBase<LevelQuestion>, ILevelQuestionRepository
    {
        public LevelQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

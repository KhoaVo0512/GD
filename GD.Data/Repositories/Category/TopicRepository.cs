using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface ITopicRepository : IRepository<Topic>
    {
    }

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

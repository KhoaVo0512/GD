using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface ITestQuestionRepository : IRepository<TestQuestion>
    {
    }

    public class TestQuestionRepository : RepositoryBase<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

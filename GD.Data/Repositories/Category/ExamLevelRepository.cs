using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IExamLevelRepository : IRepository<ExamLevel>
    {
    }

    public class ExamLevelRepository : RepositoryBase<ExamLevel>, IExamLevelRepository
    {
        public ExamLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

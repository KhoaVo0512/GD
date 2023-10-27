using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IExamTestRepository : IRepository<ExamTest>
    {
    }

    public class ExamTestRepository : RepositoryBase<ExamTest>, IExamTestRepository
    {
        public ExamTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

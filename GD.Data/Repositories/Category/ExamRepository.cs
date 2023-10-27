using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
    }

    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

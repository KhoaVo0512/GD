using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IErrorLogRepository : IRepository<ErrorLog>
    {
    }

    public class ErrorLogRepository : RepositoryBase<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

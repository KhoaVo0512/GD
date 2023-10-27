using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IApplicationGroupMenuRepository : IRepository<ApplicationGroupMenu>
    {

    }
    public class ApplicationGroupMenuRepository : RepositoryBase<ApplicationGroupMenu>, IApplicationGroupMenuRepository
    {
        public ApplicationGroupMenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

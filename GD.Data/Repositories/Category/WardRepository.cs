using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IWardRepository : IRepository<Ward>
    {
    }

    public class WardRepository : RepositoryBase<Ward>, IWardRepository
    {
        public WardRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

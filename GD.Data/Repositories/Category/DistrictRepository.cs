using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> GetByActive(bool active);
    }

    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<District> GetByActive(bool active)
        {
            var query = from g in DbContext.Districts.Include("Province")
                        where g.Active == active
                        select g;
            return query;
        }
    }
}

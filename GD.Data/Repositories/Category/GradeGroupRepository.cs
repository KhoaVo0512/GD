using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IGradeGroupRepository : IRepository<GradeGroup>
    {
        IEnumerable<GradeGroup> GetListGradeGroupUserId(string userId);
    }

    public class GradeGroupRepository : RepositoryBase<GradeGroup>, IGradeGroupRepository
    {
        public GradeGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<GradeGroup> GetListGradeGroupUserId(string userId)
        {
            var query = from g in DbContext.GradeGroups
                        join ug in DbContext.UserGradeGroups
                        on g.ID equals ug.GradeGroupId
                        where ug.UserId == userId
                        select g;
            return query;
        }
    }
}

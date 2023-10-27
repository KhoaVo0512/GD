using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface ILevelRepository : IRepository<Level>
    {
        Level GetMinValue();

        Level GetByValue(int value);

        Level GetByName(string name);
    }

    public class LevelRepository : RepositoryBase<Level>, ILevelRepository
    {
        public LevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Level GetMinValue()
        {
            var min = (from g in DbContext.Levels
                       select g.Value).Min();
            var query = from g in DbContext.Levels
                        where g.Value == min
                        select g;
            return query.FirstOrDefault();
        }

        public Level GetByValue(int value)
        {
            var query = from g in DbContext.Levels
                        where g.Value == value
                        select g;
            return query.FirstOrDefault();
        }

        public Level GetByName(string name)
        {
            var query = from g in DbContext.Levels
                        where g.Name == name
                        select g;
            return query.FirstOrDefault();
        }
    }
}

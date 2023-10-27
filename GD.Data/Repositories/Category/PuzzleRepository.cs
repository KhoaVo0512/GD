using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IPuzzleRepository : IRepository<Puzzle>
    {

    }

    public class PuzzleRepository : RepositoryBase<Puzzle>, IPuzzleRepository
    {
        public PuzzleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

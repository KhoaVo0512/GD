using GD.Data.Infrastructure;
using GD.Model.Models;

namespace GD.Data.Repositories
{
    public interface IFileRepository : IRepository<File>
    {
    }

    public class FileRepository : RepositoryBase<File>, IFileRepository
    {
        public FileRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

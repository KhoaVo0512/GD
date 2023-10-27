using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        IEnumerable<Test> GetTestByExam(int exam);
    }

    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Test> GetTestByExam(int exam)
        {
            var query = from g in DbContext.Tests
                        join ug in DbContext.ExamTests
                        on g.ID equals ug.TestId
                        where ug.ExamId == exam && g.Active == true
                        select g;
            return query;
        }

    }
}

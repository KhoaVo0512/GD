using GD.Data.Infrastructure;
using GD.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionByTest(int test);
    }

    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


        public IEnumerable<Question> GetQuestionByTest(int test)
        {
            var query = from g in DbContext.Questions
                        join ug in DbContext.TestQuestions
                        on g.ID equals ug.QuestionId
                        where ug.TestId == test && g.Active == true
                        select g;
            return query;
        }
    }
}

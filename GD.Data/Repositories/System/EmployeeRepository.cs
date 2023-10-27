using GD.Data.Infrastructure;
using GD.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GD.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

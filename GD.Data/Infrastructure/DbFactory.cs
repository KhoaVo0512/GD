using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private GDDbContext dbContext;

        public GDDbContext Init()
        {
            return dbContext ?? (dbContext = new GDDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

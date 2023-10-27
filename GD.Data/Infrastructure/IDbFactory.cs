using System;

namespace GD.Data.Infrastructure
{
    public interface IDbFactory: IDisposable
    {
        GDDbContext Init();
    }
}

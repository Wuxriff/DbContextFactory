using DbContextFactoryLib.Models;

namespace DbContextFactoryLib.Interfaces
{
    public interface IDbContextFactory
    {
        TDbContext CreateDbContext<TDbContext>() where TDbContext : BaseDbContext;
        TDbContext CreateReadonlyDbContext<TDbContext>() where TDbContext : BaseDbContext;
    }
}

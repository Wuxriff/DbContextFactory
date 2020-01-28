using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DbContextFactoryLib.Models
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext() { }

        protected BaseDbContext(DbContextOptions options) : base(options) { }

        public bool IsReadOnlyContext { get; set; } = false;

        public override int SaveChanges() => SaveChanges(acceptAllChangesOnSuccess: true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return IsReadOnlyContext ? 0 : base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return IsReadOnlyContext ? Task.FromResult(0) : base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactoryTests.Fakes
{
    internal class FakeDbContext4 : BaseDbContext
    {
        public FakeDbContext4(DbContextOptions<FakeDbContext4> options) : base(options) { }

        public DbSet<FakeEntity> FakeEntities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FakeDbContext4).Assembly);
        }
    }
}

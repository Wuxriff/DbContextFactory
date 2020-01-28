using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactoryTests.Fakes
{
    internal class FakeDbContext3 : BaseDbContext
    {
        public FakeDbContext3(DbContextOptions<FakeDbContext3> options) : base(options) { }

        public DbSet<FakeEntity> FakeEntities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FakeDbContext1).Assembly);
        }
    }
}

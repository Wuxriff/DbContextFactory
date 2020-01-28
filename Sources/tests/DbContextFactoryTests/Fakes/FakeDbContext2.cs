using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactoryTests.Fakes
{
    internal class FakeDbContext2 : BaseDbContext
    {
        public FakeDbContext2(DbContextOptions<FakeDbContext2> options) : base(options) { }

        public DbSet<FakeEntity> FakeEntities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FakeDbContext1).Assembly);
        }
    }
}

using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactoryTests.Fakes
{
    internal class FakeDbContext1 : BaseDbContext
    {
        public FakeDbContext1(DbContextOptions<FakeDbContext1> options) : base(options) { }
    }
}

using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextFactoryTests.Fakes
{
    internal class FakeDbContext3 : BaseDbContext
    {
        public FakeDbContext3(DbContextOptions<FakeDbContext3> options) : base(options) { }
    }
}

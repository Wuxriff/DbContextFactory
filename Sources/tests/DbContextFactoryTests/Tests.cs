using DbContextFactoryLib.Interfaces;
using DbContextFactoryTests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace DbContextFactoryTests
{
    public class Tests : BaseTest
    {
        [Fact]
        public void CreateDbContextsTest()
        {
            var scope = ServiceScopeFactory.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory>();

            var fakeDbContext1 = contextFactory.CreateDbContext<FakeDbContext1>();
            var fakeDbContext2 = contextFactory.CreateDbContext<FakeDbContext2>();
            var fakeDbContext3 = contextFactory.CreateDbContext<FakeDbContext3>();

            Assert.NotNull(fakeDbContext1);
            Assert.NotNull(fakeDbContext2);
            Assert.NotNull(fakeDbContext3);
        }

        [Fact]
        public void CreateReadonlyDbContextsTest()
        {
            var scope = ServiceScopeFactory.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory>();

            var fakeDbContext1 = contextFactory.CreateReadonlyDbContext<FakeDbContext1>();
            var fakeDbContext2 = contextFactory.CreateReadonlyDbContext<FakeDbContext2>();
            var fakeDbContext3 = contextFactory.CreateReadonlyDbContext<FakeDbContext3>();

            Assert.NotNull(fakeDbContext1);
            Assert.NotNull(fakeDbContext2);
            Assert.NotNull(fakeDbContext3);
        }

        [Fact]
        public void EqualityTest()
        {
            var scope = ServiceScopeFactory.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory>();

            var fakeDbContext1 = contextFactory.CreateDbContext<FakeDbContext1>();
            var readonlyFakeDbContext2 = contextFactory.CreateReadonlyDbContext<FakeDbContext1>();

            Assert.NotEqual(fakeDbContext1, readonlyFakeDbContext2);
        }

        [Fact]
        public void GcCleanupDbFactoryTest()
        {
            var scope = ServiceScopeFactory.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory>();

            var weak = CallInItsOwnScope(() =>
            {
                var ctx = contextFactory.CreateDbContext<FakeDbContext1>();
                ctx.Dispose();
                var wRef = new WeakReference(ctx);

                Assert.True(wRef.IsAlive);
                GC.Collect();

                Assert.True(wRef.IsAlive);
                return wRef;
            });

            GC.Collect();
            Assert.False(weak.IsAlive);
        }
    }
}

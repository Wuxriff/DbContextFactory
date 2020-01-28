using DbContextFactoryLib;
using DbContextFactoryLib.Interfaces;
using DbContextFactoryTests.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbContextFactoryTests
{
    public abstract class BaseTest
    {
        protected IServiceScopeFactory ServiceScopeFactory;

        protected BaseTest()
        {
            var services = new ServiceCollection();

            services.AddDbContext<FakeDbContext1, FakeDbContext1>(options => options.UseInMemoryDatabase(nameof(FakeDbContext1)));
            services.AddDbContext<FakeDbContext2, FakeDbContext2>(options => options.UseInMemoryDatabase(nameof(FakeDbContext2)));
            services.AddDbContext<FakeDbContext3, FakeDbContext3>(options => options.UseInMemoryDatabase(nameof(FakeDbContext3)));

            services.AddTransient<IDbContextFactory, DbContextFactory>();

            var serviceProvider = services.BuildServiceProvider();
            ServiceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        public static T CallInItsOwnScope<T>(Func<T> getter)
        {
            return getter();
        }
    }
}

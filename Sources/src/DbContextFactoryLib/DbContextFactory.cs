﻿using DbContextFactoryLib.Interfaces;
using DbContextFactoryLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbContextFactoryLib
{
    public sealed class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TDbContext CreateDbContext<TDbContext>() where TDbContext : BaseDbContext
        {
            return GetScopedContext<TDbContext>();
        }

        public TDbContext CreateReadonlyDbContext<TDbContext>() where TDbContext : BaseDbContext
        {
            var context = GetScopedContext<TDbContext>();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            context.IsReadOnlyContext = true;

            return context;
        }

        private TDbContext GetScopedContext<TDbContext>() where TDbContext : BaseDbContext
        {
            return _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<TDbContext>();
        }
    }
}

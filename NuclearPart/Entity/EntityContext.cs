﻿using Entity.MangerSection;
using Entity.SiteSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public partial class EntityContext : DbContext
    {
        private static DbContextOptions GetOptions(string connectionString)
           => SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        public EntityContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MangerSectionRelation.Apply(modelBuilder);
        }

        #region MangerSection
        public DbSet<Manger> Mangers { get; set; } = default!;
        #endregion

        #region SiteSection
        public DbSet<Site> Sites { get; set; } = default!;
        #endregion

    }
}


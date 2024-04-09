using Entity.AdminSection;
using Entity.ContentSection;
using Entity.MangerSection;
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
            AdminSectionRelation.Apply(modelBuilder);
            SiteSectionRelation.Apply(modelBuilder);
            ContentSectionRelation.Apply(modelBuilder);
            HasIndexRelation.Apply(modelBuilder);
        }

        #region MangerSection
        public DbSet<Manger> Mangers { get; set; } = default!;
        public DbSet<MangerRefreshToken> MangerRefreshTokens { get; set; } = default!;
        #endregion

        #region SiteSection
        public DbSet<Site> Sites { get; set; } = default!;
        public DbSet<SiteConfiguration> SiteConfigurations { get; set; } = default!;
        public DbSet<SiteLanguage> SiteLanguages { get; set; } = default!;
        public DbSet<SitePage> SitePages { get; set; } = default!;
        public DbSet<SitePageLanguage> SitePageLanguages { get; set; } = default!;
        #endregion

        #region AdminSection
        public DbSet<Admin> Admins { get; set; } = default!;
        public DbSet<AdminRefreshToken> AdminRefreshTokens { get; set; } = default!;
        #endregion

        #region ContentSection
        public DbSet<Content> Contents { get; set; } = default!;
        public DbSet<ContentLanguage> ContentLanguages { get; set; } = default!;
        public DbSet<ContentCategory> ContentCategories { get; set; } = default!;
        public DbSet<ContentCategoryLanguage> ContentCategoryLanguages { get; set; } = default!;
        #endregion

    }
}


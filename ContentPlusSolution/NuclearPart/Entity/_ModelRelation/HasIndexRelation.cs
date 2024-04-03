using Entity.ContentSection;
using Entity.SiteSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class HasIndexRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            #region SiteSection
            modelBuilder.Entity<SitePage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<SiteConfiguration>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            #endregion
            #region ContentSection
            modelBuilder.Entity<Content>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            #endregion
        }
    }
}


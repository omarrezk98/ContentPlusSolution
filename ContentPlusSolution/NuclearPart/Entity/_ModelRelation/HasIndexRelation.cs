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
            modelBuilder.Entity<SitePageLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<SiteConfiguration>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            #endregion
            #region ContentSection
            modelBuilder.Entity<Content>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<ContentLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<ContentLanguage>().HasIndex(u => new { u.ContentId, u.LanguageId }).IsUnique();
            modelBuilder.Entity<ContentCategory>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<ContentCategoryLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<ContentCategoryLanguage>().HasIndex(u => new { u.ContentCategoryId, u.LanguageId }).IsUnique();
            #endregion
        }
    }
}


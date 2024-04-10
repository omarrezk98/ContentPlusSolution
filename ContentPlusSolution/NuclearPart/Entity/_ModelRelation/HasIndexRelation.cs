using Entity.AdminSection;
using Entity.ContentSection;
using Entity.DynamicFormSection;
using Entity.MangerSection;
using Entity.SiteSection;
using Entity.VisitorSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class HasIndexRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            #region MangerSection
            modelBuilder.Entity<Manger>().HasIndex(u => new { u.Email }).IsUnique();
            modelBuilder.Entity<Manger>().HasIndex(u => new { u.UserName }).IsUnique();
            #endregion
            #region AdminSection
            modelBuilder.Entity<Admin>().HasIndex(u => new { u.Email }).IsUnique();
            modelBuilder.Entity<Admin>().HasIndex(u => new { u.UserName }).IsUnique();
            #endregion
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
            #region DynamicFormSection
            modelBuilder.Entity<DynamicForm>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormData>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormElement>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormElementLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormElementLanguage>().HasIndex(u => new { u.DynamicFormElementId, u.LanguageId }).IsUnique();
            modelBuilder.Entity<DynamicFormElementOption>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormElementOptionLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormElementOptionLanguage>().HasIndex(u => new { u.DynamicFormElementOptionId, u.LanguageId }).IsUnique();
            modelBuilder.Entity<DynamicFormLanguage>().HasIndex(u => new { u.SiteId, u.Code }).IsUnique();
            modelBuilder.Entity<DynamicFormLanguage>().HasIndex(u => new { u.DynamicFormId, u.LanguageId }).IsUnique();
            #endregion
            #region VisitorSection
            modelBuilder.Entity<Visitor>().HasIndex(u => new { u.SiteId, u.Email }).IsUnique();
            modelBuilder.Entity<Visitor>().HasIndex(u => new { u.SiteId, u.UserName }).IsUnique();
            #endregion
        }
    }
}


﻿using Entity.SiteSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class SiteSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasMany(u => u.Admin).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            #region ContentSection
            modelBuilder.Entity<Site>().HasMany(u => u.Content).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.ContentLanguage).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.ContentCategory).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.ContentCategoryLanguage).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region SiteSection
            modelBuilder.Entity<Site>().HasMany(u => u.SitePage).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.SiteConfiguration).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.SiteLanguage).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Site>().HasMany(u => u.SitePageLanguage).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}

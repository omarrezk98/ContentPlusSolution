using Entity.MangerSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class MangerSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manger>().HasMany(u => u.MangerRefreshToken).WithOne(u => u.Manger).OnDelete(DeleteBehavior.Restrict);
            #region SiteSection
            modelBuilder.Entity<Manger>().HasMany(u => u.Site).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Manger>().HasMany(u => u.Site1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Manger>().HasMany(u => u.Site2).WithOne(u => u.Deactivate).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Manger>().HasMany(u => u.SitePage).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Manger>().HasMany(u => u.SitePage1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}

using Entity.AdminSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal class AdminSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasMany(u => u.AdminRefreshToken).WithOne(u => u.Admin).OnDelete(DeleteBehavior.Restrict);
            #region ContentSection
            modelBuilder.Entity<Admin>().HasMany(u => u.Content).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.Content1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentLanguage).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentLanguage1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentCategory).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentCategory1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentCategoryLanguage).WithOne(u => u.Created).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Admin>().HasMany(u => u.ContentCategoryLanguage1).WithOne(u => u.Modified).OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}

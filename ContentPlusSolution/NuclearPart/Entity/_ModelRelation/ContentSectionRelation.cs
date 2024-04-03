using Entity.ContentSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class ContentSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentCategory>().HasMany(u => u.Content).WithOne(u => u.ContentCategory).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ContentCategory>().HasMany(u => u.Children).WithOne(u => u.Parent).OnDelete(DeleteBehavior.Restrict);
        }
    }
}


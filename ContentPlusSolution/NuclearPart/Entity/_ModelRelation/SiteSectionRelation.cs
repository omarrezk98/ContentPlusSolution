using Entity.SiteSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class SiteSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasMany(u => u.Admin).WithOne(u => u.Site).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

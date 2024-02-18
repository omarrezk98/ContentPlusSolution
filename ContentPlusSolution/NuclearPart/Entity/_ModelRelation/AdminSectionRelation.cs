using Entity.AdminSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal class AdminSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasMany(u => u.AdminRefreshToken).WithOne(u => u.Admin).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

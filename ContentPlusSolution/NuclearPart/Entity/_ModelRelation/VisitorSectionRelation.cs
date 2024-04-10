using Entity.VisitorSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal class VisitorSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().HasMany(u => u.VisitorRefreshToken).WithOne(u => u.Visitor).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

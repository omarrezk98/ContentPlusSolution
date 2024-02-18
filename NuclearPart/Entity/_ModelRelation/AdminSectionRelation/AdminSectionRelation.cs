using Entity.AdminSection;
using Entity.MangerSection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity._ModelRelation.AdminSectionRelation
{
    internal class AdminSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasMany(u => u.AdminRefreshToken).WithOne(u => u.Admin).OnDelete(DeleteBehavior.Restrict);
        }

    }
}

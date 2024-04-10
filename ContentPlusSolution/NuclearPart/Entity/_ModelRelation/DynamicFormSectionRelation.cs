using Entity.DynamicFormSection;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    internal static class DynamicFormSectionRelation
    {
        internal static void Apply(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DynamicForm>().HasMany(u => u.DynamicFormLanguage).WithOne(u => u.DynamicForm).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicForm>().HasMany(u => u.DynamicFormElement).WithOne(u => u.DynamicForm).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicForm>().HasMany(u => u.DynamicFormData).WithOne(u => u.DynamicForm).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormData>().HasMany(u => u.DynamicFormElementData).WithOne(u => u.DynamicFormData).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormElement>().HasMany(u => u.DynamicFormElementOption).WithOne(u => u.DynamicFormElement).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormElement>().HasMany(u => u.DynamicFormElementData).WithOne(u => u.DynamicFormElement).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormElement>().HasMany(u => u.DynamicFormElementLanguage).WithOne(u => u.DynamicFormElement).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormElementOption>().HasMany(u => u.DynamicFormElementOptionLanguage).WithOne(u => u.DynamicFormElementOption).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DynamicFormElementOption>().HasMany(u => u.DynamicFormElementData).WithOne(u => u.DynamicFormElementOption).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Department"/> entity.
    /// <para>Each <see cref="Department"/> has one <see cref="OperatingLocation"/>s.</para>
    /// <para>Each <see cref="Department"/> has many <see cref="Phone"/>s.</para>
    /// </summary>
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> dep)
        {
            dep.HasOne(d => d.OperatingLocation)
               .WithMany(ol => ol.Departments)
               .HasForeignKey(d => d.OperatingLocationId)
               .OnDelete(DeleteBehavior.Restrict);

            dep.HasMany(d => d.Phones)
               .WithOne(p => p.Department)
               .HasForeignKey(p => p.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

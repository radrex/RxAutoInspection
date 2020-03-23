namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Employee"/> entity.
    /// <para>Each <see cref="Employee"/> has one <see cref="JobPosition"/>.</para>
    /// <para>Each <see cref="Employee"/> has one <see cref="OperatingLocation"/>.</para>
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> emp)
        {
            emp.HasOne(e => e.JobPosition)
               .WithMany(jp => jp.Employees)
               .HasForeignKey(e => e.JobPositionId)
               .OnDelete(DeleteBehavior.Restrict);

            emp.HasOne(e => e.OperatingLocation)
               .WithMany(ol => ol.Employees)
               .HasForeignKey(e => e.OperatingLocationId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

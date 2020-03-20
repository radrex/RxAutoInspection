namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            emp.HasMany(e => e.Qualifications)
               .WithOne(q => q.Employee)
               .HasForeignKey(q => q.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

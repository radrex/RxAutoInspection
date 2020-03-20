namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeQualificationConfiguration : IEntityTypeConfiguration<EmployeeQualification>
    {
        public void Configure(EntityTypeBuilder<EmployeeQualification> builder)
        {
            builder.HasKey(eq => new { eq.EmployeeId, eq.QualificationId });

            builder.HasOne(eq => eq.Employee)
                   .WithMany(e => e.Qualifications)
                   .HasForeignKey(eq => eq.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(eq => eq.Qualification)
                   .WithMany(q => q.Employees)
                   .HasForeignKey(eq => eq.QualificationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

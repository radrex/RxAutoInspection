namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> qualification)
        {
            qualification.Property(q => q.Id)
                         .UseIdentityColumn(10, 1);

            qualification.HasMany(q => q.JobPositions)
                         .WithOne(jp => jp.Qualification)
                         .HasForeignKey(jp => jp.QualificationId)
                         .OnDelete(DeleteBehavior.Restrict);

            qualification.HasMany(q => q.Employees)
                         .WithOne(e => e.Qualification)
                         .HasForeignKey(e => e.QualificationId)
                         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

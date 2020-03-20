namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JobPositionQualificationConfiguration : IEntityTypeConfiguration<JobPositionQualification>
    {
        public void Configure(EntityTypeBuilder<JobPositionQualification> builder)
        {
            builder.HasKey(jpq => new { jpq.JobPositionId, jpq.QualificationId });

            builder.HasOne(jpq => jpq.JobPosition)
                   .WithMany(jp => jp.Qualifications)
                   .HasForeignKey(jpq => jpq.JobPositionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(jpq => jpq.Qualification)
                   .WithMany(q => q.JobPositions)
                   .HasForeignKey(jpq => jpq.QualificationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

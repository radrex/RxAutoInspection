namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="JobPositionQualification"/> many-to-many mapping entity.
    /// <para>Each <see cref="JobPositionQualification"/> has one <see cref="JobPosition"/> with many <see cref="Qualification"/>s.</para>
    /// <para>Each <see cref="JobPositionQualification"/> has one <see cref="Qualification"/> with many <see cref="JobPosition"/>s.</para>
    /// </summary>
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

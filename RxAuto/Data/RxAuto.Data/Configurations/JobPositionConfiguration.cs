namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="JobPosition"/> entity.
    /// <para>Each <see cref="JobPosition"/> has many <see cref="Qualification"/>s.</para>
    /// <para>Each <see cref="JobPosition"/> has many <see cref="Employee"/>s.</para>
    /// </summary>
    public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> jobPos)
        {
            jobPos.Property(jp => jp.Id)
                  .UseIdentityColumn(101, 1);

            jobPos.HasMany(jp => jp.Qualifications)
                  .WithOne(q => q.JobPosition)
                  .HasForeignKey(q => q.JobPositionId)
                  .OnDelete(DeleteBehavior.Restrict);

            jobPos.HasMany(jp => jp.Employees)
                  .WithOne(e => e.JobPosition)
                  .HasForeignKey(e => e.JobPositionId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

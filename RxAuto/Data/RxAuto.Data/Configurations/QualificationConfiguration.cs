namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Qualification"/> entity.
    /// <para>Each <see cref="Qualification"/> has many <see cref="JobPosition"/>s.</para>
    /// </summary>
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
        }
    }
}

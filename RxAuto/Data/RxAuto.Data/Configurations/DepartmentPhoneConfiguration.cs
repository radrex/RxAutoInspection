namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="DepartmentPhone"/> many-to-many mapping entity.
    /// <para>Each <see cref="DepartmentPhone"/> has one <see cref="Phone"/> with many <see cref="Department"/>s.</para>
    /// <para>Each <see cref="DepartmentPhone"/> has one <see cref="Department"/> with many <see cref="Phone"/>s.</para>
    /// </summary>
    public class DepartmentPhoneConfiguration : IEntityTypeConfiguration<DepartmentPhone>
    {
        public void Configure(EntityTypeBuilder<DepartmentPhone> builder)
        {
            builder.HasKey(dp => new { dp.DepartmentId, dp.PhoneId });

            builder.HasOne(dp => dp.Phone)
                   .WithMany(p => p.Departments)
                   .HasForeignKey(dp => dp.PhoneId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dp => dp.Department)
                   .WithMany(d => d.Phones)
                   .HasForeignKey(dp => dp.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

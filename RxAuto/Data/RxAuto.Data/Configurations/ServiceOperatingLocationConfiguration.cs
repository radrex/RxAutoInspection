namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ServiceOperatingLocation"/> many-to-many mapping entity.
    /// <para>Each <see cref="ServiceOperatingLocation"/> has one <see cref="Service"/> with many <see cref="OperatingLocation"/>s.</para>
    /// <para>Each <see cref="ServiceOperatingLocation"/> has one <see cref="OperatingLocation"/> with many <see cref="Service"/>s.</para>
    /// </summary>
    public class ServiceOperatingLocationConfiguration : IEntityTypeConfiguration<ServiceOperatingLocation>
    {
        public void Configure(EntityTypeBuilder<ServiceOperatingLocation> builder)
        {
            builder.HasKey(sol => new { sol.ServiceId, sol.OperatingLocationId });

            builder.HasOne(sol => sol.Service)
                   .WithMany(s => s.OperatingLocations)
                   .HasForeignKey(sol => sol.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sol => sol.OperatingLocation)
                   .WithMany(ol => ol.Services)
                   .HasForeignKey(sol => sol.OperatingLocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

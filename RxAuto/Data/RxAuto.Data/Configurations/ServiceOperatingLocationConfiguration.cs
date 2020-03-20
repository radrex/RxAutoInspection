namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

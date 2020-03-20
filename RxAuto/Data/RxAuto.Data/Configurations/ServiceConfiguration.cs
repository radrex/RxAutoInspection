namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> service)
        {
            service.HasOne(s => s.ServiceType)
                   .WithMany(st => st.Services)
                   .HasForeignKey(s => s.ServiceTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            service.HasMany(s => s.OperatingLocations)
                   .WithOne(ol => ol.Service)
                   .HasForeignKey(ol => ol.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            service.HasMany(s => s.VehicleTypes)
                   .WithOne(vt => vt.Service)
                   .HasForeignKey(vt => vt.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            service.HasMany(s => s.Documents)
                   .WithOne(d => d.Service)
                   .HasForeignKey(d => d.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            service.HasMany(s => s.Reservations)
                   .WithOne(r => r.Service)
                   .HasForeignKey(r => r.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

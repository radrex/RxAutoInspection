namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ServiceVehicleTypeConfiguration : IEntityTypeConfiguration<ServiceVehicleType>
    {
        public void Configure(EntityTypeBuilder<ServiceVehicleType> builder)
        {
            builder.HasKey(svt => new { svt.ServiceId, svt.VehicleTypeId });

            builder.HasOne(svt => svt.Service)
                   .WithMany(s => s.VehicleTypes)
                   .HasForeignKey(svt => svt.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(svt => svt.VehicleType)
                   .WithMany(vt => vt.Services)
                   .HasForeignKey(svt => svt.VehicleTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

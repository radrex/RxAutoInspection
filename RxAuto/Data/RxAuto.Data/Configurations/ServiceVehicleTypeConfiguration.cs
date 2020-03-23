namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ServiceVehicleType"/> many-to-many mapping entity.
    /// <para>Each <see cref="ServiceVehicleType"/> has one <see cref="Service"/> with many <see cref="VehicleType"/>s.</para>
    /// <para>Each <see cref="ServiceVehicleType"/> has one <see cref="VehicleType"/> with many <see cref="Service"/>s.</para>
    /// </summary>
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

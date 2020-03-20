namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> vType)
        {
            vType.HasMany(vt => vt.Services)
                 .WithOne(s => s.VehicleType)
                 .HasForeignKey(s => s.VehicleTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

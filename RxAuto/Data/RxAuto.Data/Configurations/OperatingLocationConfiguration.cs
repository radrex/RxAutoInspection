namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OperatingLocationConfiguration : IEntityTypeConfiguration<OperatingLocation>
    {
        public void Configure(EntityTypeBuilder<OperatingLocation> opLocation)
        {
            opLocation.Property(ol => ol.Id)
                      .UseIdentityColumn(10, 1);

            opLocation.HasMany(ol => ol.Contacts)
                      .WithOne(c => c.OperatingLocation)
                      .HasForeignKey(c => c.OperatingLocationId)
                      .OnDelete(DeleteBehavior.Restrict);

            opLocation.HasMany(ol => ol.Employees)
                      .WithOne(e => e.OperatingLocation)
                      .HasForeignKey(e => e.OperatingLocationId)
                      .OnDelete(DeleteBehavior.Restrict);

            opLocation.HasMany(ol => ol.Services)
                      .WithOne(s => s.OperatingLocation)
                      .HasForeignKey(s => s.OperatingLocationId)
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

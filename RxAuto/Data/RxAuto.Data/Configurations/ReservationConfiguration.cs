namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Reservation"/> entity.
    /// <para>Each <see cref="Reservation"/> has one <see cref="ApplicationUser"/>.</para>
    /// <para>Each <see cref="Reservation"/> has one <see cref="Service"/>.</para>
    /// <para>Each <see cref="Reservation"/> has one <see cref="OperatingLocation"/>.</para>
    /// </summary>
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> res)
        {
            res.HasOne(r => r.User)
               .WithMany(u => u.Reservations)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            res.HasOne(r => r.Service)
               .WithMany(s => s.Reservations)
               .HasForeignKey(r => r.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);

            res.HasOne(r => r.OperatingLocation)
               .WithMany(ol => ol.Reservations)
               .HasForeignKey(r => r.OperatingLocationId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

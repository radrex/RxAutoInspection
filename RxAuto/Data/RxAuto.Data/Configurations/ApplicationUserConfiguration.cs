namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;
    using Microsoft.AspNetCore.Identity;


    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ApplicationUser"/> entity.
    /// <para>Each <see cref="ApplicationUser"/> has many <see cref="IdentityUserClaim{TKey}"/>.</para>
    /// <para>Each <see cref="ApplicationUser"/> has many <see cref="IdentityUserLogin{TKey}"/>.</para>
    /// <para>Each <see cref="ApplicationUser"/> has many <see cref="IdentityUserRole{TKey}"/>.</para>
    /// <para>Each <see cref="ApplicationUser"/> has many <see cref="Reservation"/>s.</para>
    /// </summary>
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
        {
            appUser.HasMany(u => u.Claims)
                   .WithOne()
                   .HasForeignKey(c => c.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            appUser.HasMany(u => u.Logins)
                   .WithOne()
                   .HasForeignKey(l => l.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            appUser.HasMany(u => u.Roles)
                   .WithOne()
                   .HasForeignKey(r => r.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            appUser.HasMany(u => u.Reservations)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

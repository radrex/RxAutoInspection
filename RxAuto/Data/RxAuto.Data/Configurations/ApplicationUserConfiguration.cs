namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

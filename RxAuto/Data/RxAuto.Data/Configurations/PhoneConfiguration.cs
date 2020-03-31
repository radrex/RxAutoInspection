namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Phone"/> entity.
    /// <para>Each <see cref="Phone"/> has many <see cref="Department"/>s.</para>
    /// </summary>
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> phone)
        {
            phone.HasMany(p => p.Departments)
                 .WithOne(d => d.Phone)
                 .HasForeignKey(d => d.PhoneId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Contact"/> entity.
    /// <para>Each <see cref="Contact"/> has one <see cref="OperatingLocation"/>.</para>
    /// </summary>
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> contact)
        {
            contact.HasOne(c => c.OperatingLocation)
                   .WithMany(ol => ol.Contacts)
                   .HasForeignKey(c => c.OperatingLocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

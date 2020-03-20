namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ServiceDocumentConfiguration : IEntityTypeConfiguration<ServiceDocument>
    {
        public void Configure(EntityTypeBuilder<ServiceDocument> builder)
        {
            builder.HasKey(sd => new { sd.ServiceId, sd.DocumentId });

            builder.HasOne(sd => sd.Service)
                   .WithMany(s => s.Documents)
                   .HasForeignKey(sd => sd.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sd => sd.Document)
                   .WithMany(d => d.Services)
                   .HasForeignKey(sd => sd.DocumentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

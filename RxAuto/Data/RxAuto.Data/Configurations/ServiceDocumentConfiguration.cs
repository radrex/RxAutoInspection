namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="ServiceDocument"/> many-to-many mapping entity.
    /// <para>Each <see cref="ServiceDocument"/> has one <see cref="Service"/> with many <see cref="Document"/>s.</para>
    /// <para>Each <see cref="ServiceDocument"/> has one <see cref="Document"/> with many <see cref="Service"/>s.</para>
    /// </summary>
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

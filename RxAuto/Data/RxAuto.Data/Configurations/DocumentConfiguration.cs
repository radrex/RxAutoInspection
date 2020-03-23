namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Applies configuration for <see cref="Document"/> entity.
    /// <para>Each <see cref="Document"/> has many <see cref="Service"/>s.</para>
    /// </summary>
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> doc)
        {
            doc.Property(d => d.Id)
               .UseIdentityColumn(10, 1);

            doc.HasMany(d => d.Services)
               .WithOne(s => s.Document)
               .HasForeignKey(s => s.DocumentId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

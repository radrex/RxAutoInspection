namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

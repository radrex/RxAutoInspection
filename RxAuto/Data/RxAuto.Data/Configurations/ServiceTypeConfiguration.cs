namespace RxAuto.Data.Configurations
{
    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> sType)
        {
            sType.HasMany(st => st.Services)
                 .WithOne(s => s.ServiceType)
                 .HasForeignKey(s => s.ServiceTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

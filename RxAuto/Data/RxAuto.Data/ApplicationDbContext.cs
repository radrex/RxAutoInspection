namespace RxAuto.Data
{
    using Configurations;

    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        //------------- CONSTRUCTORS --------------
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        //-------------- PROPERTIES ---------------
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobPositionQualification> JobPositionQualifications { get; set; }
        public DbSet<OperatingLocation> OperatingLocations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDocument> ServiceDocument { get; set; }
        public DbSet<ServiceOperatingLocation> ServiceOperatingLocations { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceVehicleType> ServiceVehicleTypes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        //--------------- METHODS -----------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new JobPositionConfiguration());
            builder.ApplyConfiguration(new JobPositionQualificationConfiguration());
            builder.ApplyConfiguration(new OperatingLocationConfiguration());
            builder.ApplyConfiguration(new QualificationConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new ServiceDocumentConfiguration());
            builder.ApplyConfiguration(new ServiceOperatingLocationConfiguration());
            builder.ApplyConfiguration(new ServiceTypeConfiguration());
            builder.ApplyConfiguration(new ServiceVehicleTypeConfiguration());
            builder.ApplyConfiguration(new VehicleTypeConfiguration());
        }
    }
}

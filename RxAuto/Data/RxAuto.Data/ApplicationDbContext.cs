namespace RxAuto.Data
{
    using Configurations;

    using RxAuto.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// Base class responsible for managing database connections, providing all sorts of DB related functionality like data access methods to interact with Database. 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        //------------- CONSTRUCTORS --------------
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        //-------------- PROPERTIES ---------------
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobPositionQualification> JobPositionQualifications { get; set; }
        public DbSet<OperatingLocation> OperatingLocations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDocument> ServiceDocuments { get; set; }
        public DbSet<ServiceOperatingLocation> ServiceOperatingLocations { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentPhone> DepartmentPhones { get; set; }

        //--------------- METHODS -----------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
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
            builder.ApplyConfiguration(new VehicleTypeConfiguration());
            builder.ApplyConfiguration(new PhoneConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new DepartmentPhoneConfiguration());
        }
    }
}

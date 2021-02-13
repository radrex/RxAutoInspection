namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Seeding.JSONSeed;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// Base class responsible for managing database connections, providing seeding methods for initial database seeding. 
    /// </summary>
    public class ApplicationDbContextSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly string path = @"../../Data/RxAuto.Data/Seeding/JSONSeed/initialSeed.json";

        //------------- CONSTRUCTORS --------------
        public ApplicationDbContextSeeder()
        {
            this.JSONData = JsonConvert.DeserializeObject<JSONData>(File.ReadAllText(this.path));
        }

        //-------------- PROPERTIES ---------------
        private JSONData JSONData { get; set; }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            ILogger logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            List<ISeeder> seeders = new List<ISeeder>
                                    {
                                        new RolesSeeder(),
                                        new UsersSeeder(),
                                        new QualificationsSeeder(this.JSONData.Qualifications),
                                        new JobPositionsSeeder(this.JSONData.JobPositions),
                                        new OperatingLocationsSeeder(this.JSONData.OperatingLocations),
                                        new EmployeesSeeder(this.JSONData.Employees),
                                        new PhonesSeeder(this.JSONData.Phones),
                                        new DepartmentsSeeder(this.JSONData.Departments),
                                        new DocumentsSeeder(this.JSONData.Documents),
                                        new VehicleTypesSeeder(this.JSONData.VehicleTypes),
                                        new ServiceTypesSeeder(this.JSONData.ServiceTypes),
                                        new ServicesSeeder(this.JSONData.Services),
                                        new ReservationsSeeder(this.JSONData.Reservations),
                                    };

            foreach (ISeeder seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync(); // SaveChanges in SeedAsync on each step in order to preserve insertion order
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}

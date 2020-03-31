namespace RxAuto.Data.Seeding
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Base class responsible for managing database connections, providing seeding methods for initial database seeding. 
    /// </summary>
    public class ApplicationDbContextSeeder : ISeeder
    {
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
                                        new QualificationsSeeder(),
                                        new JobPositionsSeeder(),
                                        new DocumentsSeeder(),
                                        new VehicleTypesSeeder(),
                                        new OperatingLocationsSeeder(),
                                        new EmployeesSeeder(),
                                        new ServiceTypesSeeder(),
                                        new ServicesSeeder(),
                                        new ReservationsSeeder(),
                                        new PhonesSeeder(),
                                        new DepartmentsSeeder(),
                                    };

            foreach (ISeeder seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}

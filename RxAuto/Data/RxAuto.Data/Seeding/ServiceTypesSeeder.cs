namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ServiceTypesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JServiceType> serviceTypes;

        //------------- CONSTRUCTORS --------------
        public ServiceTypesSeeder(List<JServiceType> serviceTypes)
        {
            this.serviceTypes = serviceTypes;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ServiceTypes.Any())
            {
                return;
            }

            foreach (JServiceType serviceType in this.serviceTypes)
            {
                await dbContext.ServiceTypes.AddAsync(new ServiceType
                {
                    Name = serviceType.Name,
                    Description = serviceType.Description,
                    IsShownInMainMenu = serviceType.IsShownInMainMenu,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}

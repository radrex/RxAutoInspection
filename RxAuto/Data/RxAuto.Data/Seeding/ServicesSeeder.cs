namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ServicesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JService> services;

        //------------- CONSTRUCTORS --------------
        public ServicesSeeder(List<JService> services)
        {
            this.services = services;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Services.Any())
            {
                return;
            }

            foreach (JService service in this.services)
            {
                await dbContext.Services.AddAsync(new Service
                {
                    Name = service.Name,
                    Price = service.Price,
                    ServiceTypeId = service.ServiceTypeId,
                    Description = service.Description,
                    VehicleTypeId = service.VehicleTypeId,
                    IsShownInSubMenu = service.IsShownInSubMenu,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(

                foreach (int documentId in service.DocumentIds)
                {
                    await dbContext.ServiceDocuments.AddAsync(new ServiceDocument
                    {
                        ServiceId = service.Id,
                        DocumentId = documentId,
                    });
                }
                await dbContext.SaveChangesAsync();


                foreach (int operatingLocationId in service.OperatingLocationIds)
                {
                    await dbContext.ServiceOperatingLocations.AddAsync(new ServiceOperatingLocation
                    {
                        ServiceId = service.Id,
                        OperatingLocationId = operatingLocationId,
                    });
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class OperatingLocationsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JOperatingLocation> operatingLocations;

        //------------- CONSTRUCTORS --------------
        public OperatingLocationsSeeder(List<JOperatingLocation> operatingLocations)
        {
            this.operatingLocations = operatingLocations;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.OperatingLocations.Any())
            {
                return;
            }

            foreach (JOperatingLocation operatingLocation in this.operatingLocations)
            {
                await dbContext.OperatingLocations.AddAsync(new OperatingLocation
                {
                    Town = operatingLocation.Town,
                    Address = operatingLocation.Address,
                    ImageUrl = operatingLocation.ImageUrl,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}

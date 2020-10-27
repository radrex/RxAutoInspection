namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class OperatingLocationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.OperatingLocations.Any())
            {
                return;
            }

            var operatingLocations = new List<(string Town, string Address, string ImageUrl)>
            {
                ("София", "ул. Васил Левски 10", "https://files.porsche.com/filestore/image/multimedia/none/porscheservice-psp-l-02/normal/63c63e76-2d1e-11e8-bbc5-0019999cd470/porsche-normal.jpg"),
                ("Благоевград", "ул. Патриарх Евтимий 23", "https://lh3.googleusercontent.com/proxy/mGuXrhajAcu_z2BeWHg0648LotYnGxmkSMpunrlF0iSxFggYNSl9UE7n4aabPRR9_cezZ7KyGM8c-xRbgmuIXfoub6wkOm3yHEu8LuQaKeWh8vVebhCEuLZDrk-jGXN3452468Tev2gTn-98HAXBM28s"),
            };

            foreach (var operatingLocation in operatingLocations)
            {
                await dbContext.OperatingLocations.AddAsync(new OperatingLocation
                {
                    Town = operatingLocation.Town,
                    Address = operatingLocation.Address,
                    ImageUrl = operatingLocation.ImageUrl,
                });
            }
        }
    }
}

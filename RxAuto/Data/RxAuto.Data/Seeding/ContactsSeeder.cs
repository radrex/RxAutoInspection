namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ContactsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Contacts.Any())
            {
                return;
            }

            var contacts = new List<(string PhoneNumber, string Email, string Location)>()
            {
                ("0897567698", "blg_inspection@gmail.com", "Благоевград"),
                ("0897482301", "sofia_inspection@gmail.com", "София"),
            };

            foreach (var contact in contacts)
            {
                OperatingLocation operatingLocation = dbContext.OperatingLocations.FirstOrDefault(ol => ol.Town == contact.Location);

                await dbContext.Contacts.AddAsync(new Contact
                {
                    PhoneNumber = contact.PhoneNumber,
                    Email = contact.Email,
                    OperatingLocation = operatingLocation,
                });
            }
        }
    }
}

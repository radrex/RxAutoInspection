namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>phones</c> to <see cref="Phone"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class PhonesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Phones.Any())
            {
                return;
            }

            List<string> phones = new List<string>
            {
                "0897571823", 
                "0898391232", 
                "0897931421",
                "0897391431",
                "0898391953",
                "0897572942",
            };

            foreach (string phone in phones)
            {
                await dbContext.Phones.AddAsync(new Phone
                {
                    PhoneNumber = phone,
                });
            }
        }
    }
}

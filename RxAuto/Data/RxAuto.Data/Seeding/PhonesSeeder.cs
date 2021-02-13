namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class PhonesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JPhone> phones;

        //------------- CONSTRUCTORS --------------
        public PhonesSeeder(List<JPhone> phones)
        {
            this.phones = phones;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Phones.Any())
            {
                return;
            }

            foreach (JPhone phone in this.phones)
            {
                await dbContext.Phones.AddAsync(new Phone
                {
                    PhoneNumber = phone.PhoneNumber,
                    IsInternal = phone.IsInternal,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}

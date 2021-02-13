namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class QualificationsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JQualification> qualifications;

        //------------- CONSTRUCTORS --------------
        public QualificationsSeeder(List<JQualification> qualifications)
        {
            this.qualifications = qualifications;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Qualifications.Any())
            {
                return;
            }

            foreach (JQualification qualification in this.qualifications)
            {
                await dbContext.Qualifications.AddAsync(new Qualification
                {
                    Name = qualification.Name,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}

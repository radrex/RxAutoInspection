namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class JobPositionsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JJobPosition> jobPositions;

        //------------- CONSTRUCTORS --------------
        public JobPositionsSeeder(List<JJobPosition> jobPositions)
        {
            this.jobPositions = jobPositions;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobPositions.Any())
            {
                return;
            }

            foreach (JJobPosition jobPosition in this.jobPositions)
            {
                await dbContext.JobPositions.AddAsync(new JobPosition
                {
                    Name = jobPosition.Name,
                });
                await dbContext.SaveChangesAsync();  // Do it on each step to preserve insertion order. :(

                foreach (int qualificationId in jobPosition.QualificationIds)
                {
                    await dbContext.JobPositionQualifications.AddAsync(new JobPositionQualification
                    {
                        JobPositionId = jobPosition.Id,
                        QualificationId = qualificationId,
                    });
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

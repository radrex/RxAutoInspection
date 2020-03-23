namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>job positions</c> to <see cref="JobPosition"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class JobPositionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobPositions.Any())
            {
                return;
            }

            Dictionary<string, List<Qualification>> jobPositions = new Dictionary<string, List<Qualification>>
            {
                { "Председател на комисия", new List<Qualification>(dbContext.Qualifications
                                                                             .Where(q => q.Name == "Правоспособни водачи на МПС, най-малко категория B, L" || 
                                                                                         q.Name == "Висше образование" ||
                                                                                         q.Name == "Удостоверение за преминато допълнително обучение" ||
                                                                                         q.Name == "Компютърна грамотност" ||
                                                                                         q.Name == "Над 3 години трудов стаж по специалността")
                                                                             .ToList()) 
                },
                { "Технически специалист", new List<Qualification>(dbContext.Qualifications
                                                                            .Where(q => q.Name == "Правоспособни водачи на МПС, най-малко категория B, L" ||
                                                                                        q.Name == "Удостоверение за преминато допълнително обучение" ||
                                                                                        q.Name == "Компютърна грамотност" ||
                                                                                        q.Name == "Над 3 години трудов стаж по специалността")
                                                                            .ToList()) 
                },
                { "Ръководител КТП", new List<Qualification>(dbContext.Qualifications
                                                                      .Where(q => q.Name == "Правоспособни водачи на МПС, най-малко категория B, L" ||
                                                                                  q.Name == "Висше образование" ||
                                                                                  q.Name == "Удостоверение за преминато допълнително обучение" ||
                                                                                  q.Name == "Компютърна грамотност" ||
                                                                                  q.Name == "Над 3 години трудов стаж по специалността")
                                                                      .ToList())
                },
            };

            foreach (var jobPosition in jobPositions)
            {
                JobPosition jobPositionEntity = new JobPosition { Name = jobPosition.Key };

                foreach (var qualification in jobPosition.Value)
                {
                    await dbContext.JobPositionQualifications.AddAsync(new JobPositionQualification
                    {
                        JobPosition = jobPositionEntity,
                        Qualification = qualification,
                    });
                }
            }
        }
    }
}

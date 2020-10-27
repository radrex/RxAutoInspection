namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class QualificationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Qualifications.Any())
            {
                return;
            }

            List<string> qualifications = new List<string>
            {
                "Правоспособни водачи на МПС, най-малко категория B, L",
                "Висше образование",
                "Удостоверение за преминато допълнително обучение",
                "Компютърна грамотност",
                "Над 3 години трудов стаж по специалността",
            };

            foreach (string qualification in qualifications)
            {
                await dbContext.Qualifications.AddAsync(new Qualification
                {
                    Name = qualification,
                });
            }
        }
    }
}

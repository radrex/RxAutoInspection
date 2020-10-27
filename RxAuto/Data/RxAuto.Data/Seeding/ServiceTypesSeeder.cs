namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ServiceTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ServiceTypes.Any())
            {
                return;
            }

            var serviceTypes = new List<(string Name, string Description, bool IsInDevelopment)>
            {
                ("ГТП", "Периодичен преглед за проверка на техническата изправност на ППС регистрирани в Република България.", false),
                ("Автомивка", "Почистването с гореща пара дезинфекцира, достига до труднодостъпните места и ниши на автомобила, убива микроби, плесени и паразите, премахва миризми и др.", true),
            };

            foreach (var serviceType in serviceTypes)
            {
                await dbContext.ServiceTypes.AddAsync(new ServiceType
                {
                    Name = serviceType.Name,
                    Description = serviceType.Description,
                    IsShownInMainMenu = serviceType.IsInDevelopment,
                });
            }
        }
    }
}

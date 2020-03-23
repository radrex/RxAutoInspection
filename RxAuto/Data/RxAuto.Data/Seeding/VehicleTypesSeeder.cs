namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Models.Enums;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class VehicleTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.VehicleTypes.Any())
            {
                return;
            }

            var vehicleTypes = new List<(string Name, VehicleCategory Category, string Description)>
            {
                ("Лек автомобил", VehicleCategory.M1, "Превозни средства от категория M с не повече от 8 места за сядане, без място за сядане на водача; в превозните средства от категория M1 няма място за стоящи пътници; броят на местата за сядане може да бъде ограничен до едно (мястото за сядане на водача);"),
                ("Автобус", VehicleCategory.M2, "Превозни средства от категория M с повече от 8 места за сядане, без мястото за сядане на водача, с технически допустима максимална маса не повече от 5 t; в превозните средства от категория M2, освен местата за сядане, може да има място за стоящи пътници;"),
                ("Автобус", VehicleCategory.M3, "Превозни средства от категория M с повече от 8 места за сядане, без мястото за сядане на водача, с технически допустима максимална маса над 5 t; в превозните средства от категория M3 може да има място за стоящи пътници;"),
                ("Товарен автомобил", VehicleCategory.N1, "Превозни средства от категория N с технически допустима максимална маса не повече от 3,5 t;"),
                ("Товарен автомобил", VehicleCategory.N2, "Превозни средства от категория N с технически допустима максимална маса над 3,5 t, но не повече от 12 t;"),
            };

            foreach (var vehicleType in vehicleTypes)
            {
                await dbContext.VehicleTypes.AddAsync(new VehicleType
                {
                    Name = vehicleType.Name,
                    VehicleCategory = vehicleType.Category,
                    Description = vehicleType.Description,
                });
            }
        }
    }
}

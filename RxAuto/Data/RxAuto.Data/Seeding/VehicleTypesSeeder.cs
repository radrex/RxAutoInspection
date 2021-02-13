namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Models.Enums;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class VehicleTypesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JVehicleType> vehicleTypes;

        //------------- CONSTRUCTORS --------------
        public VehicleTypesSeeder(List<JVehicleType> vehicleTypes)
        {
            this.vehicleTypes = vehicleTypes;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.VehicleTypes.Any())
            {
                return;
            }

            foreach (JVehicleType vehicleType in this.vehicleTypes)
            {
                await dbContext.VehicleTypes.AddAsync(new VehicleType
                {
                    Name = vehicleType.Name,
                    VehicleCategory = Enum.Parse<VehicleCategory>(vehicleType.VehicleCategory),
                    Description = vehicleType.Description,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}

namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Data.Models.Enums;
    using RxAuto.Services.Models.VehicleTypes;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="VehicleType"/> entity and it's database relations.
    /// </summary>
    public class VehicleTypesService : IVehicleTypesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="VehicleTypesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public VehicleTypesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="VehicleType"/> using the <see cref="CreateVehicleTypeServiceModel"/>.
        /// If such <see cref="VehicleType"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="VehicleType"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c></param>
        /// <returns>VehicleType ID</returns>
        public async Task<int> CreateAsync(CreateVehicleTypeServiceModel model)
        {
            VehicleCategory vehicleCategory = (VehicleCategory)model.VehicleCategoryId;
            int vehicleTypeId = this.dbContext.VehicleTypes.Where(x => x.Name == model.Name &&
                                                                       x.VehicleCategory == vehicleCategory)
                                                           .Select(x => x.Id)
                                                           .FirstOrDefault();

            if (vehicleTypeId != 0)   // If vehicleTypeId is different than 0 (int default value), vehicleType with such name already exists, so return it's id.
            {
                return vehicleTypeId;
            }

            VehicleType vehicleType = new VehicleType
            {
                Name = model.Name,
                VehicleCategory = vehicleCategory,
                Description = model.Description,
            };

            await this.dbContext.VehicleTypes.AddAsync(vehicleType);
            await this.dbContext.SaveChangesAsync();

            return vehicleType.Id;
        }

        /// <summary>
        /// Gets every <see cref="ServiceType"/>'s <c>Id</c>, <c>Category</c> and <c>Name</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of VehicleTypes</returns>
        public IEnumerable<VehicleTypesDropdownServiceModel> GetAll()
        {
            return this.dbContext.VehicleTypes.Select(vt => new VehicleTypesDropdownServiceModel
            {
                Id = vt.Id,
                Category = vt.VehicleCategory.ToString(),
                Name = vt.Name,
            }).ToList().OrderBy(x => x.Category);
        }
    }
}

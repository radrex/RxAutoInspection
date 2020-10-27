namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Data.Models.Enums;
    using RxAuto.Services.Models.VehicleTypes;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class VehicleTypesService : IVehicleTypesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IServicesService servicesService;

        //------------- CONSTRUCTORS --------------
        public VehicleTypesService(ApplicationDbContext dbContext, IServicesService servicesService)
        {
            this.dbContext = dbContext;
            this.servicesService = servicesService;
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

        /// <summary>
        /// Gets every <see cref="VehicleType"/>'s <c>Id</c>, <c>Name</c> and <c>VehicleCategory</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of VehicleTypes</returns>
        public IEnumerable<VehicleTypesListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.VehicleTypes.Select(x => new VehicleTypesListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                VehicleCategory = x.VehicleCategory.ToString(),
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>VehicleTypes</c> count.
        /// </summary>
        /// <returns>VehicleTypes Count</returns>
        public int Count()
        {
            return this.dbContext.VehicleTypes.Count();
        }

        /// <summary>
        /// Gets the first <see cref="VehicleType"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c> as a service model.
        /// <para> If there is no such <see cref="VehicleType"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>A single VehicleType</returns>
        public VehicleTypeServiceModel GetById(int id)
        {
            return this.dbContext.VehicleTypes.Where(x => x.Id == id)
                                              .Select(x => new VehicleTypeServiceModel
                                              {
                                                  Id = x.Id,
                                                  Name = x.Name,
                                                  VehicleCategoryId = (int)x.VehicleCategory,
                                                  VehicleCategory = x.VehicleCategory,
                                                  Description = x.Description,
                                              }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="VehicleType"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="vehicleTypeId">VehicleType ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int vehicleTypeId)
        {
            return this.dbContext.VehicleTypes.Any(x => x.Id == vehicleTypeId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="VehicleType"/> using <see cref="EditVehicleTypeServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>VehicleCategoryId</c>.</returns>
        public async Task<int> EditAsync(EditVehicleTypeServiceModel model)
        {
            VehicleType vehicleType = this.dbContext.VehicleTypes.Find(model.Id);
            vehicleType.Name = model.Name;
            vehicleType.Description = model.Description;

            VehicleCategory vehicleCategory = (VehicleCategory)model.VehicleCategoryId;
            vehicleType.VehicleCategory = vehicleCategory;

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="VehicleType"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            VehicleType vehicleType = this.dbContext.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return false;
            }

            // First Delete cascade all Services with that VehicleType
            for (int i = 0; i < vehicleType.Services.Count; i++)
            {
                await this.servicesService.RemoveAsync(vehicleType.Services.ToArray()[i].Id);
                i--;
            }

            // And lastly Delete the VehicleType itself
            this.dbContext.VehicleTypes.Remove(vehicleType);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.ServiceTypes;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="ServiceType"/> entity and it's database relations.
    /// </summary>
    public class ServiceTypesService : IServiceTypesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IServicesService servicesService;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="ServiceTypesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public ServiceTypesService(ApplicationDbContext dbContext, IServicesService servicesService)
        {
            this.dbContext = dbContext;
            this.servicesService = servicesService;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="ServiceType"/> using the <see cref="CreateServiceTypeServiceModel"/>.
        /// If such <see cref="ServiceType"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="ServiceType"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>ServiceType ID</returns>
        public async Task<int> CreateAsync(CreateServiceTypeServiceModel model)
        {
            int serviceTypeId = this.dbContext.ServiceTypes.Where(d => d.Name == model.Name)
                                                           .Select(x => x.Id)
                                                           .FirstOrDefault();

            if (serviceTypeId != 0)   // If serviceTypeId is different than 0 (int default value), serviceType with such name already exists, so return it's id.
            {
                return serviceTypeId;
            }

            ServiceType serviceType = new ServiceType
            {
                Name = model.Name,
                Description = model.Description,
                IsShownInMainMenu = model.IsInDevelopment,
            };

            await this.dbContext.ServiceTypes.AddAsync(serviceType);
            await this.dbContext.SaveChangesAsync();

            return serviceType.Id;
        }

        /// <summary>
        /// Gets every <see cref="ServiceType"/>'s <c>Id</c> and <c>Name</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of ServiceTypes</returns>
        public IEnumerable<ServiceTypesDropdownServiceModel> GetAll()
        {
            return this.dbContext.ServiceTypes.Select(st => new ServiceTypesDropdownServiceModel
            {
                Id = st.Id,
                Name = st.Name,
            }).ToList();
        }

        /// <summary>
        /// Gets every <see cref="ServiceType"/>'s <c>Id</c>, <c>Name</c> and <c>IsShownInMainMenu</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of ServiceTypes</returns>
        public IEnumerable<ServiceTypesListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.ServiceTypes.Select(x => new ServiceTypesListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                IsShownInMainMenu = x.IsShownInMainMenu == true ? "IsShownInMainMenu" : "NotShownInMainMenu",
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>ServiceTypes</c> count.
        /// </summary>
        /// <returns>ServiceTypes Count</returns>
        public int Count()
        {
            return this.dbContext.ServiceTypes.Count();
        }

        /// <summary>
        /// Gets the first <see cref="ServiceType"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c> and <c>IsShownInMainMenu</c> as a service model.
        /// <para> If there is no such <see cref="ServiceType"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>A single ServiceType</returns>
        public ServiceTypeServiceModel GetById(int id)
        {
            return this.dbContext.ServiceTypes.Where(x => x.Id == id)
                                              .Select(x => new ServiceTypeServiceModel
                                              {
                                                  Id = x.Id,
                                                  Name = x.Name,
                                                  Description = x.Description,
                                                  IsShownInMainMenu = x.IsShownInMainMenu,
                                              }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="ServiceType"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="serviceTypeId">ServiceType ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int serviceTypeId)
        {
            return this.dbContext.ServiceTypes.Any(x => x.Id == serviceTypeId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="ServiceType"/> using <see cref="EditServiceTypeServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.</returns>
        public async Task<int> EditAsync(EditServiceTypeServiceModel model)
        {
            ServiceType serviceType = this.dbContext.ServiceTypes.Find(model.Id);
            serviceType.Name = model.Name;
            serviceType.Description = model.Description;
            serviceType.IsShownInMainMenu = model.IsShownInMainMenu;

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="ServiceType"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            ServiceType serviceType = this.dbContext.ServiceTypes.Find(id);
            if (serviceType == null)
            {
                return false;
            }

            // TODO: UNCOMMENT THIS WHEN RESERVATIONS REMOVE METHOD IS READY
            // First Delete cascade all services with that serviceType
            //for (int i = 0; i < serviceType.Services.Count; i++)
            //{
            //    await this.servicesService.RemoveAsync(serviceType.Services.ToArray()[i].Id);
            //    i--;
            //}

            // And lastly Delete the serviceType itself
            this.dbContext.ServiceTypes.Remove(serviceType);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

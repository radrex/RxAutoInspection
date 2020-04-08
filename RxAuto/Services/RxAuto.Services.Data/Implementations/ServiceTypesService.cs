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

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="ServiceTypesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public ServiceTypesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}

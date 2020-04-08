namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Services;

    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains method implementations for <see cref="Service"/> entity and it's database relations.
    /// </summary>
    public class ServicesService : IServicesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="ServicesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public ServicesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Service"/> using the <see cref="CreateServiceServiceModel"/>.
        /// If such <see cref="Service"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="Service"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>ServiceTypeId</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMenu</c></param>
        /// <returns>Service ID</returns>
        public async Task<int> CreateAsync(CreateServiceServiceModel model)
        {
            int serviceId = this.dbContext.Services.Where(x => x.Name == model.ServiceName && x.VehicleTypeId == model.VehicleTypeId)
                                                   .Select(x => x.Id)
                                                   .FirstOrDefault();

            if (serviceId != 0)   // If serviceId is different than 0 (default int value), service with such name and vehicleType already exists, so return it's id.
            {
                return serviceId;
            }

            Service service = new Service
            {
                ServiceTypeId = model.ServiceTypeId,
                VehicleTypeId = model.VehicleTypeId,
                Name = model.ServiceName,
                Description = model.ServiceDescription,
                IsShownInSubMenu = model.IsShownInSubMenu,
                Price = model.Price,
            };

            foreach (var operatingLocationDropdown in model.OperatingLocations)
            {
                OperatingLocation operatingLocation = this.dbContext.OperatingLocations.FirstOrDefault(x => x.Id == operatingLocationDropdown.Id);
                await this.dbContext.ServiceOperatingLocations.AddAsync(new ServiceOperatingLocation
                {
                    Service = service,
                    OperatingLocation = operatingLocation,
                });
            }

            foreach (var documentDropdown in model.Documents)
            {
                Document document = this.dbContext.Documents.FirstOrDefault(x => x.Id == documentDropdown.Id);
                await this.dbContext.ServiceDocuments.AddAsync(new ServiceDocument
                {
                    Service = service,
                    Document = document,
                });
            }

            await this.dbContext.Services.AddAsync(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }
    }
}

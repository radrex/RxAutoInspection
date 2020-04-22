namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Services;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

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

        /// <summary>
        /// Gets every <see cref="Service"/>'s <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>Price</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Services</returns>
        public IEnumerable<ServicesListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Services.Select(x => new ServicesListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                IsShownInSubMenu = x.IsShownInSubMenu == true ? "IsShownInSubMenu" : "NotShownInSubMenu",
                ServiceType = x.ServiceType.Name,
                VehicleType = x.VehicleType.Name,
                Price = x.Price,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>Services</c> count.
        /// </summary>
        /// <returns>Services Count</returns>
        public int Count()
        {
            return this.dbContext.Services.Count();
        }

        /// <summary>
        /// Gets the first <see cref="Service"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c>, <c>Description</c> and <c>Price</c> as a service model.
        /// <para> If there is no such <see cref="Service"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>A single Service</returns>
        public ServiceServiceModel GetById(int id)
        {
            return this.dbContext.Services.Where(x => x.Id == id)
                                          .Select(x => new ServiceServiceModel
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              IsShownInSubMenu = x.IsShownInSubMenu,
                                              Description = x.Description,
                                              Price = x.Price,

                                              ServiceType = x.ServiceType.Name,
                                              ServiceTypeId = x.ServiceTypeId,

                                              VehicleType = x.VehicleType.Name,
                                              VehicleTypeId = x.VehicleTypeId,

                                              OperatingLocationIds = x.OperatingLocations.Select(x => x.OperatingLocationId).ToArray(),
                                              DocumentIds = x.Documents.Select(x => x.DocumentId).ToArray(),
                                          }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="Service"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="serviceId">Service ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int serviceId)
        {
            return this.dbContext.Services.Any(x => x.Id == serviceId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Service"/> using <see cref="EditServiceServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c>, <c>Description</c>, <c>IsShownInSubMenu</c>, <c>ServiceTypeId</c>, <c>VehicleTypeId</c> and collections of <c>OperatingLocationIds</c> and <c>DocumentIds</c>.</returns>
        public async Task<int> EditAsync(EditServiceServiceModel model)
        {
            Service service = this.dbContext.Services.Find(model.Id);
            service.Name = model.Name;
            service.Price = model.Price;
            service.Description = model.Description;
            service.IsShownInSubMenu = model.IsShownInSubMenu;
            service.VehicleTypeId = model.VehicleTypeId;
            service.ServiceTypeId = model.ServiceTypeId;

            //---------------------------------- OPERATING LOCATIONS ----------------------------------
            // First Remove serviceOperatingLocation related entity (Mapping table) for that service
            for (int i = 0; i < service.OperatingLocations.Count; i++)
            {
                this.dbContext.ServiceOperatingLocations.Remove(service.OperatingLocations.ToArray()[i]);
                await this.dbContext.SaveChangesAsync();
                i--;
            }

            // Then Add the new serviceOperatingLocation related entities (Mapping table) for that service with the new OperatingLocations
            foreach (var operatingLocationId in model.OperatingLocationIds)
            {
                await this.dbContext.ServiceOperatingLocations.AddAsync(new ServiceOperatingLocation
                {
                    Service = service,
                    OperatingLocationId = operatingLocationId,
                });
            }

            //--------------------------------------- DOCUMENTS ---------------------------------------
            // First Remove serviceDocument related entity (Mapping table) for that service
            for (int i = 0; i < service.Documents.Count; i++)
            {
                this.dbContext.ServiceDocuments.Remove(service.Documents.ToArray()[i]);
                await this.dbContext.SaveChangesAsync();
                i--;
            }

            // Then Add the new serviceOperatingLocation related entities (Mapping table) for that service with the new OperatingLocations
            foreach (var documentId in model.DocumentIds)
            {
                await this.dbContext.ServiceDocuments.AddAsync(new ServiceDocument
                {
                    Service = service,
                    DocumentId = documentId,
                });
            }

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="Service"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            Service service = this.dbContext.Services.Find(id);
            if (service == null)
            {
                return false;
            }

            // TODO: UNCOMMENT THIS WHEN RESERVATIONS REMOVE METHOD IS READY
            // First Delete cascade all reservations with that service
            //for (int i = 0; i < service.Reservations.Count; i++)
            //{
            //    await this.reservationsService.RemoveAsync(service.Reservations.ToArray()[i].Id);
            //    i--;
            //}

            // Then Delete all serviceOperatingLocation related entities (Mapping table)
            this.dbContext.ServiceOperatingLocations.RemoveRange(service.OperatingLocations);

            // Then Delete all serviceDocument related entities (Mapping table)
            this.dbContext.ServiceDocuments.RemoveRange(service.Documents);

            // And lastly Delete the service itself
            this.dbContext.Services.Remove(service);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

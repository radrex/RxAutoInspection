namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="OperatingLocation"/> entity and it's database relations.
    /// </summary>
    public class OperatingLocationsService : IOperatingLocationsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="OperatingLocationsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public OperatingLocationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="OperatingLocation"/> using the <see cref="CreateOperatingLocationServiceModel"/>.
        /// If such <see cref="OperatingLocation"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="OperatingLocation"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and a collection <c>Departments</c></param>
        /// <returns>OperatingLocation ID</returns>
        public async Task<int> CreateAsync(CreateOperatingLocationServiceModel model)
        {
            int operatingLocationId = this.dbContext.OperatingLocations.Where(x => x.Town == model.Town && x.Address == model.Address)
                                                                       .Select(x => x.Id)
                                                                       .FirstOrDefault();

            if (operatingLocationId != 0) // If operatingLocationId is different than 0 (default int value), operatingLocation with such town and address already exists, so return it's id.
            {
                return operatingLocationId;
            }

            OperatingLocation operatingLocation = new OperatingLocation
            {
                Town = model.Town,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };
            await this.dbContext.OperatingLocations.AddAsync(operatingLocation);
            await this.dbContext.SaveChangesAsync();

            foreach (var departmentFromModel in model.Departments)
            {
                // Set Department's OperatingLocationId, because it is null by default
                Department department = this.dbContext.Departments.FirstOrDefault(x => x.Id == departmentFromModel.Id);
                department.OperatingLocation = operatingLocation;

                // Set Department's selected phones from the user to public phones (IsInternal = false)
                foreach (var phoneFromModel in departmentFromModel.Phones)
                {
                    department.Phones.Where(p => p.PhoneId == phoneFromModel.Id).FirstOrDefault().Phone.IsInternal = false;
                }

                await this.dbContext.SaveChangesAsync();
            }

            return operatingLocation.Id;
        }

        /// <summary>
        /// Gets every <see cref="OperatingLocation"/>'s <c>Id</c>, <c>Town</c> and <c>Address</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of OperatingLocations</returns>
        public IEnumerable<OperatingLocationsDropdownServiceModel> GetAll()
        {
            return this.dbContext.OperatingLocations.Select(x => new OperatingLocationsDropdownServiceModel
            {
                Id = x.Id,
                Town = x.Town,
                Address = x.Address,
            }).ToList();
        }
    }
}

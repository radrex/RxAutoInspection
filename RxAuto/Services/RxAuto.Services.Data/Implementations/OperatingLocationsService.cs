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
        private readonly IDepartmentsService departmentsService;
        private readonly IPhonesService phonesService;
        private readonly IEmployeesService employeesService;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="OperatingLocationsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public OperatingLocationsService(ApplicationDbContext dbContext, IDepartmentsService departmentsService, IPhonesService phonesService, IEmployeesService employeesService)
        {
            this.dbContext = dbContext;
            this.departmentsService = departmentsService;
            this.phonesService = phonesService;
            this.employeesService = employeesService;
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

        /// <summary>
        /// Gets every <see cref="OperatingLocation"/>'s <c>Id</c>, <c>Town</c> and <c>Address</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of OperatingLocation</returns>
        public IEnumerable<OperatingLocationsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.OperatingLocations.Select(x => new OperatingLocationsListingServiceModel
            {
                Id = x.Id,
                Town = x.Town,
                Address = x.Address,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>OperatingLocations</c> count.
        /// </summary>
        /// <returns>OperatingLocations Count</returns>
        public int Count()
        {
            return this.dbContext.OperatingLocations.Count();
        }

        /// <summary>
        /// Gets the first <see cref="OperatingLocation"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Town</c>and <c>Address</c> as a service model.
        /// <para> If there is no such <see cref="OperatingLocation"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>A single OperatingLocation</returns>
        public OperatingLocationServiceModel GetById(int id)
        {
            List<string> departmentIds = new List<string>(); // depId - phoneId (pairs)

            foreach (var operatingLocation in this.dbContext.OperatingLocations.Where(x => x.Id == id))
            {
                foreach (var department in operatingLocation.Departments)
                {
                    foreach (var phone in department.Phones.Where(x => x.Phone.IsInternal == false))
                    {
                        departmentIds.Add($"{department.Id} {phone.PhoneId}");
                    }
                }
            }

            return this.dbContext.OperatingLocations.Where(x => x.Id == id)
                                              .Select(x => new OperatingLocationServiceModel
                                              {
                                                  Id = x.Id,
                                                  Town = x.Town,
                                                  Address = x.Address,
                                                  Description = x.Description,
                                                  ImageUrl = x.ImageUrl,
                                                  DepartmentIds = departmentIds.ToArray(),
                                              }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="OperatingLocation"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="operatingLocationId">OperatingLocation ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int operatingLocationId)
        {
            return this.dbContext.OperatingLocations.Any(x => x.Id == operatingLocationId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="OperatingLocation"/> using <see cref="EditOperatingLocationServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and <c>DepartmentsIds</c> with associated <c>PhoneIds</c>.</returns>
        public async Task<int> EditAsync(EditOperatingLocationServiceModel model)
        {
            int modifiedEntities = 0;

            OperatingLocation operatingLocation = this.dbContext.OperatingLocations.Find(model.Id);
            operatingLocation.Town = model.Town;
            operatingLocation.Address = model.Address;
            operatingLocation.Description = model.Description;
            operatingLocation.ImageUrl = model.ImageUrl;

            // Clear the operatingLocation departments
            operatingLocation.Departments.Clear();

            // First set each Department's OperatingLocationId with this OperatingLocation to null and make corresponding phones internal
            var deps = this.dbContext.Departments.Where(x => x.OperatingLocationId == operatingLocation.Id).ToList();
            for (int i = 0; i < deps.Count; i++)
            {
                deps[i].OperatingLocationId = null;
                foreach (var phone in deps[i].Phones)
                {
                    bool result = this.phonesService.IsPhoneContainedInOtherDepartments(phone.Phone.PhoneNumber);

                    // Only if the Phone is not contained within other Departments and is Public -> Set Phone to Internal
                    // Just in One Department and is Public -> set Phone to Internal
                    if (result == false && phone.Phone.IsInternal == false)
                    {
                        this.dbContext.Phones.FirstOrDefault(x => x.Id == phone.PhoneId).IsInternal = true;
                    }
                    // In Many Departments and is Internal -> set Phone to Public
                    else if (result == true && phone.Phone.IsInternal == false)
                    {
                        this.dbContext.Phones.FirstOrDefault(x => x.Id == phone.PhoneId).IsInternal = true;
                    }
                }
            }

            modifiedEntities += await this.dbContext.SaveChangesAsync();

            var departments = this.departmentsService.GetAllDepartmentsWithSelectedPhones(model.DepartmentIds);
            foreach (var departmentFromModel in departments)
            {
                // Set Department's OperatingLocationId, because it is null
                Department department = this.dbContext.Departments.FirstOrDefault(x => x.Id == departmentFromModel.Id);
                department.OperatingLocation = operatingLocation;

                // Set Department's selected phones from the user to public phones (IsInternal = false)
                foreach (var phoneFromModel in departmentFromModel.Phones)
                {
                    department.Phones.Where(p => p.PhoneId == phoneFromModel.Id).FirstOrDefault().Phone.IsInternal = false;
                }
            }

            modifiedEntities += await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="OperatingLocation"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            OperatingLocation operatingLocation = this.dbContext.OperatingLocations.Find(id);
            if (operatingLocation == null)
            {
                return false;
            }

            // First Set each Department's OperatingLocationId to null for that Operating Location
            foreach (var department in this.dbContext.Departments.Where(x => x.OperatingLocationId == operatingLocation.Id))
            {
                department.OperatingLocationId = null;
            }

            // Then Delete cascade all employees with that operatingLocation
            for (int i = 0; i < operatingLocation.Employees.Count; i++)
            {
                await this.employeesService.RemoveAsync(operatingLocation.Employees.ToArray()[i].Id);
                i--;
            }

            // Then Delete all serviceOperatingLocation related entities (Mapping table)
            this.dbContext.ServiceOperatingLocations.RemoveRange(operatingLocation.Services);

            // And lastly Delete the operatingLocation itself
            this.dbContext.OperatingLocations.Remove(operatingLocation);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

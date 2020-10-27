namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Employees;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesService : IEmployeesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        public EmployeesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Employee"/> using the <see cref="CreateEmployeeServiceModel"/>.
        /// If such <see cref="Employee"/> already exists in the database, fetches it's (string)<c>Id</c> and returns it.
        /// If such <see cref="Employee"/> doesn't exist in the database, adds it and return it's (string)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c></param>
        /// <returns>Employee ID</returns>
        public async Task<string> CreateAsync(CreateEmployeeServiceModel model)
        {
            // TODO: Add EGN/Social Security Number to Employee table in Database and get employeeId by checking that number, not the names.
            string employeeId = this.dbContext.Employees.Where(x => x.FirstName == model.FirstName &&
                                                                    x.MiddleName == model.MiddleName &&
                                                                    x.LastName == model.LastName)
                                                        .Select(x => x.Id)
                                                        .FirstOrDefault();

            if (employeeId != null)   // If employeeId is different than null (string default value), employee with such name already exists, so return it's id.
            {
                return employeeId;
            }

            Employee employee = new Employee
            {
                JobPositionId = model.JobPositionId,
                OperatingLocationId = model.OperatingLocationId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Email = model.Email,
                Town = model.Town,
                Address = model.Address,
                ImageUrl = model.ImageUrl,
            };

            await this.dbContext.Employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();

            return employee.Id;
        }

        /// <summary>
        /// Gets every <see cref="Employee"/>'s <c>Id</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>OperatingLocationTown</c>, <c>OperatingLocationAddress</c> and <c>JobPosition</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Employees</returns>
        public IEnumerable<EmployeesListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Employees.Select(e => new EmployeesListingServiceModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email,
                OperatingLocationTown = e.OperatingLocation.Town,
                OperatingLocationAddress = e.OperatingLocation.Address,
                JobPosition = e.JobPosition.Name,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>Employees</c> count.
        /// </summary>
        /// <returns>Employees Count</returns>
        public int Count()
        {
            return this.dbContext.Employees.Count();
        }

        /// <summary>
        /// Gets information for the <see cref="Employee"/> with given Id.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Service Model with FirstName, MiddleName, LastName, Full Name, Phone, Email, Town, Address, ImageUrl, Operating Location and Job Position</returns>
        public EmployeeServiceModel GetById(string id)
        {
            return this.dbContext.Employees.Where(x => x.Id == id)
                                           .Select(x => new EmployeeServiceModel
                                           {
                                               Id = x.Id,
                                               FirstName = x.FirstName,
                                               MiddleName = x.MiddleName,
                                               LastName = x.LastName,
                                               FullName = $"{x.FirstName} {x.MiddleName} {x.LastName}",
                                               PhoneNumber = x.PhoneNumber,
                                               Email = x.Email,
                                               Town = x.Town,
                                               Address = x.Address,
                                               HomeAddress = $"{x.Town} {x.Address}",
                                               ImageUrl = x.ImageUrl,
                                               OperatingLocationId = x.OperatingLocationId,
                                               OperatingLocation = $"{x.OperatingLocation.Town} {x.OperatingLocation.Address}",
                                               JobPositionId = x.JobPositionId,
                                               JobPosition = x.JobPosition.Name,
                                           })
                                           .FirstOrDefault();
        }

        /// <summary>
        /// Removes an <see cref="Employee"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(string id)
        {
            Employee employee = this.dbContext.Employees.Find(id); // TODO: Use FindAsync ?

            if (employee == null)
            {
                return false;
            }

            this.dbContext.Employees.Remove(employee);

            int deletedEntities = await this.dbContext.SaveChangesAsync();
            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Searches the database for an <see cref="Employee"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="employeeId">Employe ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(string employeeId)
        {
            return this.dbContext.Employees.Any(x => x.Id == employeeId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Employee"/> using <see cref="EditEmployeeServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c>.</returns>
        public async Task<int> EditAsync(EditEmployeeServiceModel model)
        {
            Employee employee = this.dbContext.Employees.Find(model.Id);

            employee.JobPositionId = model.JobPositionId;
            employee.OperatingLocationId = model.OperatingLocationId;
            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.PhoneNumber = model.Phone;
            employee.Email = model.Email;
            employee.Town = model.Town;
            employee.Address = model.Address;
            employee.ImageUrl = model.ImageUrl;

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }
    }
}

namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Employees;

    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains method implementations for <see cref="Employee"/> entity and it's database relations.
    /// </summary>
    public class EmployeesService : IEmployeesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="EmployeesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public EmployeesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Employee"/> and adds it to the database if it doesn't already exist, then returns it's Id.
        /// <para> If such <see cref="Employee"/> already exists, returns it's Id.</para>
        /// </summary>
        /// <param name="model">Service model with JobPositionId, OperatingLocationId and Employee credentials.</param>
        /// <returns>Employee ID</returns>
        public async Task<string> CreateAsync(CreateEmployeeServiceModel model)
        {
            // TODO: Add EGN/Social Security Number to Employee table in Database and get employeeId by checking that number, not the names.
            string employeeId = this.dbContext.Employees.Where(x => x.FirstName == model.FirstName &&
                                                                    x.MiddleName == model.MiddleName &&
                                                                    x.LastName == model.LastName)
                                                        .Select(x => x.Id)
                                                        .FirstOrDefault();

            if (employeeId != null)   // If employeeId is different than null, employee with such name already exists, so return it's id.
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
    }
}

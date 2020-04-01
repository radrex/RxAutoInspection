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
    }
}

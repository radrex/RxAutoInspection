namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Departments;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains method implementations for <see cref="Department"/> entity and it's database relations.
    /// </summary>
    public class DepartmentsService : IDepartmentsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="DepartmentsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public DepartmentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        public async Task<int> CreateAsync(CreateDepartmentServiceModel model)
        {
            int departmentId = this.dbContext.Departments.Where(x => x.Name == model.Name && x.Email == model.Email)
                                                         .Select(x => x.Id)
                                                         .FirstOrDefault();

            if (departmentId != 0)   // If departmentId is different than 0, department with such name and email already exists, so return it's id.
            {
                return departmentId;
            }

            Department department = new Department
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
            };

            foreach (var phone in model.PhoneNumbers)
            {
                await this.dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                {
                    Department = department,
                    PhoneId = phone.Id,
                });
            }

            // Add job position without any qualifications
            if (model.PhoneNumbers.Count() == 0)
            {
                await this.dbContext.Departments.AddAsync(department);
            }

            await this.dbContext.Departments.AddAsync(department);
            await this.dbContext.SaveChangesAsync();

            return department.Id;
        }
    }
}

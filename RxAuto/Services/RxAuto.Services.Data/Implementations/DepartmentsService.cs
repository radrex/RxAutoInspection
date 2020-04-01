namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;
    using RxAuto.Services.Models.Departments;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

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
        /// <summary>
        /// Creates a new <see cref="Department"/> using the <see cref="CreateDepartmentServiceModel"/>. 
        /// If such <see cref="Department"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="Department"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c>, <c>Email</c>, <c>Description</c> and a collection of <c>Phones</c></param>
        /// <returns>Department ID</returns>
        public async Task<int> CreateAsync(CreateDepartmentServiceModel model)
        {
            int departmentId = this.dbContext.Departments.Where(x => x.Name == model.Name && x.Email == model.Email)
                                                         .Select(x => x.Id)
                                                         .FirstOrDefault();

            if (departmentId != 0)   // If departmentId is different than 0 (default int value), department with such name and email already exists, so return it's id.
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

            // Adds department without any qualifications
            if (model.PhoneNumbers.Count() == 0)
            {
                await this.dbContext.Departments.AddAsync(department);
            }

            await this.dbContext.Departments.AddAsync(department);
            await this.dbContext.SaveChangesAsync();

            return department.Id;
        }

        /// <summary>
        /// Gets every <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Phones</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of Departments</returns>
        public IEnumerable<DepartmentsDropdownServiceModel> GetAll()
        {
            return this.dbContext.Departments.Select(d => new DepartmentsDropdownServiceModel
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                Phones = d.Phones.Select(d => new PhonesDropdownServiceModel
                {
                    Id = d.PhoneId,
                    PhoneNumber = d.Phone.PhoneNumber
                })
            }).ToList();
        }
    }
}

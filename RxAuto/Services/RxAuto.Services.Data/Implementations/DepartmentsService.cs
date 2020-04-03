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

            foreach (var phoneDropdown in model.PhoneNumbers)
            {
                Phone phone = this.dbContext.Phones.FirstOrDefault(x => x.Id == phoneDropdown.Id);
                await this.dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                {
                    Department = department,
                    Phone = phone,
                });
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
                    PhoneNumber = d.Phone.PhoneNumber,
                })
            }).ToList();
        }


        /// <summary>
        /// Gets every <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Phones</c> that doesn't have an <see cref="OperatingLocation"/> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of Departments</returns>
        public IEnumerable<DepartmentsDropdownServiceModel> GetAllWithoutOperatingLocation()
        {
            return this.dbContext.Departments.Where(d => d.OperatingLocationId == null)
                                             .Select(d => new DepartmentsDropdownServiceModel
                                             {
                                                 Id = d.Id,
                                                 Name = d.Name,
                                                 Email = d.Email,
                                                 Phones = d.Phones.Select(d => new PhonesDropdownServiceModel
                                                 {
                                                     Id = d.PhoneId,
                                                     PhoneNumber = d.Phone.PhoneNumber,
                                                 })
                                             }).ToList();
        }

        /// <summary>
        /// Gets all selected <see cref="Department"/>s and their <see cref="Phone"/>s from the database, using the given string[] parameter and returns it as a service model collection.
        /// </summary>
        /// <param name="departmentIds">First element is <c>Department</c> ID, second element is <c>Phone</c> ID for that <c>Department</c></param>
        /// <returns></returns>
        public IEnumerable<DepartmentsDropdownServiceModel> GetAllDepartmentsWithSelectedPhones(string[] departmentIds)
        {
            List<DepartmentsDropdownServiceModel> departments = new List<DepartmentsDropdownServiceModel>();

            // Return empty service model - Create Operating Location without any Departments
            if (departmentIds == null)
            {
                return departments;
            }

            // Dictionary<DepartmentId, HashSet<PhoneId>>  - summarize information - data comes from user input
            Dictionary<int, HashSet<int>> departmentPhonesIds = new Dictionary<int, HashSet<int>>();
            foreach (string departmentId in departmentIds)
            {
                int[] tokens = departmentId.Split(' ').Select(int.Parse).ToArray();
                int depId = tokens[0];
                if (!departmentPhonesIds.ContainsKey(depId))
                {
                    departmentPhonesIds[depId] = new HashSet<int>(tokens[1]);
                }

                departmentPhonesIds[depId].Add(tokens[1]);
            }

            foreach (var department in departmentPhonesIds)
            {
                var phones = new List<PhonesDropdownServiceModel>();
                foreach (int phoneId in department.Value)
                {
                    var phone = this.dbContext.Phones.Where(p => p.Id == phoneId)
                                                     .Select(p => new PhonesDropdownServiceModel
                                                     {
                                                         Id = p.Id,
                                                         PhoneNumber = p.PhoneNumber,
                                                     }).FirstOrDefault();
                    phones.Add(phone);
                }

                var dep = this.dbContext.Departments.Where(d => d.Id == department.Key)
                                                    .Select(d => new DepartmentsDropdownServiceModel
                                                    {
                                                        Id = d.Id,
                                                        Name = d.Name,
                                                        Email = d.Email,
                                                        Phones = phones,
                                                    }).FirstOrDefault();
                departments.Add(dep);
            }

            return departments;
        }
    }
}

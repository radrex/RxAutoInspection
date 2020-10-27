namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;
    using RxAuto.Services.Models.Departments;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RxAuto.Services.Models.OperatingLocations;

    public class DepartmentsService : IDepartmentsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IPhonesService phonesService;

        //------------- CONSTRUCTORS --------------
        public DepartmentsService(ApplicationDbContext dbContext, IPhonesService phonesService)
        {
            this.dbContext = dbContext;
            this.phonesService = phonesService;
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

        /// <summary>
        /// Gets and returns the total <c>Departments</c> count.
        /// </summary>
        /// <returns>Departments Count</returns>
        public int Count()
        {
            return this.dbContext.Departments.Count();
        }

        /// <summary>
        /// Gets every <see cref="Department"/>'s <c>Id</c>, <c>Name</c> and <c>Email</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Departments</returns>
        public IEnumerable<DepartmentsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Departments.Select(x => new DepartmentsListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets the first <see cref="Department"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Description</c> as a service model.
        /// <para> If there is no such <see cref="Department"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>A single Department</returns>
        public DepartmentServiceModel GetById(int id)
        {
            return this.dbContext.Departments.Where(x => x.Id == id)
                                             .Select(x => new DepartmentServiceModel
                                             {
                                                 Id = x.Id,
                                                 Name = x.Name,
                                                 Email = x.Email,
                                                 Description = x.Description,
                                                 PhoneNumberIds = x.Phones.Select(p => p.PhoneId).ToArray(),
                                             }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="Department"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="departmentId">Department ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int departmentId)
        {
            return this.dbContext.Departments.Any(x => x.Id == departmentId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Department"/> using <see cref="EditDepartmentServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c>, <c>Email</c>, <c>Description</c> and <c>PhoneNumberIds</c>.</returns>
        public async Task<int> EditAsync(EditDepartmentServiceModel model)
        {
            Department department = this.dbContext.Departments.Find(model.Id);
            department.Name = model.Name;
            department.Email = model.Email;
            department.Description = model.Description;

            // First Remove departmentPhone related entity (Mapping table) for that department
            for (int i = 0; i < department.Phones.Count; i++)
            {
                this.dbContext.DepartmentPhones.Remove(department.Phones.ToArray()[i]);
                await this.dbContext.SaveChangesAsync();
                i--;
            }

            // Then Add the new departmentPhone related entities (Mapping table) for that department with the new Phones
            foreach (var phoneNumberId in model.PhoneNumberIds)
            {
                await this.dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                {
                    Department = department,
                    PhoneId = phoneNumberId,
                });
            }

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="Department"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            Department department = this.dbContext.Departments.Find(id);
            if (department == null)
            {
                return false;
            }

            // If we delete a department we need to set each of its phones to Internal, 
            // but do not touch the phones that are used in other departments
            foreach (var phone in department.Phones)
            {
                bool result = this.phonesService.IsPhoneContainedInOtherDepartments(phone.Phone.PhoneNumber);
                // IS CONTAINED IN ONLY 1 DEPARTMENT
                if (result == false)
                {
                    phone.Phone.IsInternal = true;
                }
                // BUG: IF Phone is contained in more than 1 department, and is selected in 2 OpLoc as Public, but we delete one of the departments -> the phone should stay public and not change to internal
            }

            // First Delete all departmentPhone related entities (Mapping table)
            this.dbContext.DepartmentPhones.RemoveRange(department.Phones);

            // And lastly Delete the jobPosition itself
            this.dbContext.Departments.Remove(department);

            int deletedEntities = await this.dbContext.SaveChangesAsync();
            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

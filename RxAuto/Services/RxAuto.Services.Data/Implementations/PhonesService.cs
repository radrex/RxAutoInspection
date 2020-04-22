namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="Phone"/> entity and it's database relations.
    /// </summary>
    public class PhonesService : IPhonesService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="PhonesService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public PhonesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Phone"/> using the <see cref="CreatePhoneServiceModel"/>.
        /// If such <see cref="Phone"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="Phone"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>PhoneNumber</c></param>
        /// <returns>PhoneNumber ID</returns>
        public async Task<int> CreateAsync(CreatePhoneServiceModel model)
        {
            int phoneNumberId = this.dbContext.Phones.Where(x => x.PhoneNumber == model.PhoneNumber)
                                                     .Select(x => x.Id)
                                                     .FirstOrDefault();

            if (phoneNumberId != 0)   // If phoneNumberId is different than 0 (int default value), phone with such phoneNumber already exists, so return it's id.
            {
                return phoneNumberId;
            }

            Phone phone = new Phone
            {
                PhoneNumber = model.PhoneNumber,
            };

            await this.dbContext.Phones.AddAsync(phone);
            await this.dbContext.SaveChangesAsync();

            return phone.Id;
        }

        /// <summary>
        /// Gets every <see cref="Phone"/>'s <c>Id</c> and <c>PhoneNumber</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of Phones</returns>
        public IEnumerable<PhonesDropdownServiceModel> GetAll()
        {
            return this.dbContext.Phones.Select(p => new PhonesDropdownServiceModel
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
            }).ToList();
        }

        /// <summary>
        /// Checks if the passed <c>Phone</c> is contained in more than 1 <c>Department</c>.
        /// </summary>
        /// <param name="phone">Phone Number</param>
        /// <returns>True - phone is used in many departments. False - phone is used in one department.</returns>
        public bool IsPhoneContainedInOtherDepartments(string phone)
        {
            int count = 0;
            foreach (var department in this.dbContext.Departments)
            {
                foreach (var depPhone in department.Phones.Where(x => x.Phone.PhoneNumber == phone))
                {
                    count++;
                }
            }

            return count > 1 ? true : false;
        }

        /// <summary>
        /// Gets and returns the total <c>Phones</c> count.
        /// </summary>
        /// <returns>Phones Count</returns>
        public int Count()
        {
            return this.dbContext.Phones.Count();
        }

        /// <summary>
        /// Gets every <see cref="Phone"/>'s <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Phones</returns>
        public IEnumerable<PhonesListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Phones.Select(x => new PhonesListingServiceModel
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                IsInternal = x.IsInternal == true ? "Internal" : "Public",
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets the first <see cref="Phone"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c> and <c>IsInternal</c> as a service model.
        /// <para> If there is no such <see cref="Phone"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>A single Phone</returns>
        public PhoneServiceModel GetById(int id)
        {
            return this.dbContext.Phones.Where(x => x.Id == id)
                                        .Select(x => new PhoneServiceModel
                                        {
                                            Id = x.Id,
                                            PhoneNumber = x.PhoneNumber,
                                            IsInternal = x.IsInternal.ToString(),
                                        }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="Phone"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="phoneId">Employe ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int phoneId)
        {
            return this.dbContext.Phones.Any(x => x.Id == phoneId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Phone"/> using <see cref="EditPhoneServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c> and <c>PhoneNumber</c></returns>
        public async Task<int> EditAsync(EditPhoneServiceModel model)
        {
            Phone phone = this.dbContext.Phones.Find(model.Id);
            phone.PhoneNumber = model.PhoneNumber;

            // TODO: check for duplicates

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="Phone"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            Phone phone = this.dbContext.Phones.Find(id);
            if (phone == null)
            {
                return false;
            }

            // First Delete all DepartmentPhone related entities (Mapping table)
            this.dbContext.DepartmentPhones.RemoveRange(phone.Departments);

            // And lastly Delete the Phone itself
            this.dbContext.Phones.Remove(phone);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

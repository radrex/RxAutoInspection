namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;

    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
    }
}

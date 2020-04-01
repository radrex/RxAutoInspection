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
        /// Creates a new <see cref="Phone"/> and adds it to the database if it doesn't already exist, then returns it's Id.
        /// <para> If such <see cref="Phone"/> already exists, returns it's Id.</para>
        /// </summary>
        /// <param name="model">Service model with <c>PhoneNumber</c></param>
        /// <returns>PhoneNumber ID</returns>
        public async Task<int> CreateAsync(CreatePhoneServiceModel model)
        {
            int phoneNumberId = this.dbContext.Phones.Where(x => x.PhoneNumber == model.PhoneNumber)
                                                     .Select(x => x.Id)
                                                     .FirstOrDefault();

            if (phoneNumberId != 0)   // If phoneNumberId is different than 0, phone with such phoneNumber already exists, so return it's id.
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
        /// <returns>IEnumerable<see cref="PhonesDropdownServiceModel"/></returns>
        public IEnumerable<PhonesDropdownServiceModel> GetAll()
        {
            return this.dbContext.Phones.Select(p => new PhonesDropdownServiceModel
            {
                Id = p.Id,
                PhoneNumber = p.PhoneNumber,
            }).ToList();
        }
    }
}

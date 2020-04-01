namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains method implementations for <see cref="OperatingLocation"/> entity and it's database relations.
    /// </summary>
    public class OperatingLocationsService : IOperatingLocationsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="OperatingLocationsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public OperatingLocationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Gets every <see cref="OperatingLocation"/>'s <c>Id</c>, <c>Town</c> and <c>Address</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of OperatingLocations</returns>
        public IEnumerable<OperatingLocationsDropdownServiceModel> GetAll()
        {
            return this.dbContext.OperatingLocations.Select(x => new OperatingLocationsDropdownServiceModel
            {
                Id = x.Id,
                Town = x.Town,
                Address = x.Address,
            }).ToList();
        }
    }
}

namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Reservations;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="Reservation"/> entity and it's database relations.
    /// </summary>
    public class ReservationsService : IReservationsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        public ReservationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Gets every <see cref="Reservation"/>'s <c>Id</c>, <c>Service</c>, <c>VehicleMake</c>, <c>VehicleModel</c>, <c>IsActive</c>, <c>LicenseNumber</c>, <c>PhoneNumber</c> and <c>ReservationDateTime</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Reservations</returns>
        public IEnumerable<ReservationsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Reservations.Select(x => new ReservationsListingServiceModel
            {
                Id = x.Id,
                ServiceType = x.Service.ServiceType.Name,
                Service = x.Service.Name,
                VehicleMake = x.VehicleMake,
                VehicleModel = x.VehicleModel,
                IsActive = x.IsActive ? "Активна" : "Отменена",
                LicenseNumber = x.LicenseNumber,
                PhoneNumber = x.PhoneNumber,
                ReservationDateTime = x.ReservationDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>Reservations</c> count.
        /// </summary>
        /// <returns>Reservations Count</returns>
        public int Count()
        {
            return this.dbContext.Reservations.Count();
        }

        /// <summary>
        /// Removes a <see cref="Reservation"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Reservation ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(string id)
        {
            Reservation reservation = this.dbContext.Reservations.Find(id);
            if (reservation == null)
            {
                return false;
            }

            this.dbContext.Reservations.Remove(reservation);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}

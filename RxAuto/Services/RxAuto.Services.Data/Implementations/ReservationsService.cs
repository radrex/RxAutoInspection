namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Reservations;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Security.Claims;

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
                Town = x.Service.OperatingLocations.Select(x => x.OperatingLocation.Town).FirstOrDefault(),
                Address = x.Service.OperatingLocations.Select(x => x.OperatingLocation.Address).FirstOrDefault(),
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

        //TODO: Add docs
        public IEnumerable<ReservationsListingServiceModel> AllForUser(string username, int? take = null, int skip = 0)
        {
            var query = this.dbContext.Reservations.Where(x => x.User.UserName == username)
                                                   .Select(x => new ReservationsListingServiceModel
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
                                                       Town = x.Service.OperatingLocations.Select(x => x.OperatingLocation.Town).FirstOrDefault(),
                                                       Address = x.Service.OperatingLocations.Select(x => x.OperatingLocation.Address).FirstOrDefault(),
                                                   })
                                                   .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        //TODO:Add docs
        public int CountForUser(string username)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == username);
            return user.Reservations.Count();
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

        //TODO:Add docs
        public bool Exists(string reservationId)
        {
            return this.dbContext.Reservations.Any(x => x.Id == reservationId); // TODO: Use AnyAsync ?
        }

        //TODO: Add docs
        public async Task<int> EditAsync(string reservationId)
        {
            Reservation reservation = this.dbContext.Reservations.Find(reservationId);
            reservation.IsActive = false;

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        //TODO: Add docs
        public async Task<string> CreateAsync(CreateReservationServiceModel model)
        {
            string userId = this.dbContext.Users.Where(x => x.UserName == model.Username)
                                             .Select(x => x.Id)
                                             .FirstOrDefault();

            //If no such user, assign userId to GUEST USER (people that want to do reservations without having an account)
            if (userId == null)
            {
                var test = this.dbContext.Users.FirstOrDefault(x => x.UserName == "GuestUser").Id;
                userId = test;
            }

            Reservation reservation = new Reservation
            {
                IsActive = true,
                VehicleMake = model.VehicleMake,
                VehicleModel = model.VehicleModel,
                LicenseNumber = model.LicenseNumber,
                PhoneNumber = model.PhoneNumber,
                ReservationDateTime = model.ReservationDateTime,

                ServiceId = model.ServiceId,
                OperatingLocationId = model.OperatingLocationId,

                UserId = userId, 
            };

            //reservation.Service.OperatingLocations.Add

            await this.dbContext.Reservations.AddAsync(reservation);
            await this.dbContext.SaveChangesAsync();

            return reservation.Id;
        }
    }
}

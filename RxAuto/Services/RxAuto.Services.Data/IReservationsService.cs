namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Reservations;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IReservationsService
    {
        /// <summary>
        /// Describes a method for getting all the <see cref="Reservation"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="ReservationsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Service, IsActive, VehicleMake, VehicleModel, PhoneNumber and ReservationDateTime</returns>
        IEnumerable<ReservationsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Reservation"/>s from the database.
        /// <para>Should return the number of <see cref="Reservation"/>s</para>
        /// </summary>
        /// <returns>Reservations Count</returns>
        int Count();

        //TODO: Add docs
        IEnumerable<ReservationsListingServiceModel> AllForUser(string username, int? take = null, int skip = 0);

        //TODO: Add docs
        int CountForUser(string username);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="Reservation"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Reservation ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(string id);

        //TODO:Add docs
        bool Exists(string reservationId);

        //TODO:Add docs
        Task<int> EditAsync(string reservationId);

        //TODO: Add docs
        Task<string> CreateAsync(CreateReservationServiceModel model);
    }
}

namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Services;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IServicesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Service"/> in the database using <see cref="CreateServiceServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Service"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Department ID</returns>
        Task<int> CreateAsync(CreateServiceServiceModel model);

        /// <summary>
        /// Describes a method for getting all the <see cref="Service"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="ServicesListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Name, IsShownInSubMenu, ServiceType, VehicleType and Price</returns>
        IEnumerable<ServicesListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Service"/>s from the database.
        /// <para>Should return the number of <see cref="Service"/>s</para>
        /// </summary>
        /// <returns>Service Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="Service"/> from the database using the given (int) id.
        /// <para>Should return <see cref="ServiceServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Service"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>A single Service</returns>
        ServiceServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="Service"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="serviceId">Service ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int serviceId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="Service"/> using <see cref="EditServiceServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c>, <c>Description</c>, <c>IsShownInSubMenu</c>, <c>ServiceTypeId</c>, <c>VehicleTypeId</c> and collections of <c>OperatingLocationIds</c> and <c>DocumentIds</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditServiceServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="Service"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}

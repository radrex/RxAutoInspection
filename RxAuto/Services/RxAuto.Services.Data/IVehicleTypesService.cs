namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.VehicleTypes;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IVehicleTypesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="VehicleType"/> in the database using <see cref="CreateVehicleTypeServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="VehicleType"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c></param>
        /// <returns>Qualification ID</returns>
        Task<int> CreateAsync(CreateVehicleTypeServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="VehicleType"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="VehicleTypesDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="VehicleType"/>'s <c>Id</c>, <c>Category</c> and <c>Name</c>.</para>
        /// </summary>
        /// <returns>Collection of Departments</returns>
        IEnumerable<VehicleTypesDropdownServiceModel> GetAll();

        /// <summary>
        /// Describes a method for getting all the <see cref="VehicleType"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="VehicleTypesListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Name and VehicleCategory</returns>
        IEnumerable<VehicleTypesListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="VehicleType"/>s from the database.
        /// <para>Should return the number of <see cref="VehicleType"/>s</para>
        /// </summary>
        /// <returns>VehicleTypes Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="VehicleType"/> from the database using the given (int) id.
        /// <para>Should return <see cref="VehicleTypeServiceModel"/>.</para>
        /// <para>Each service model has <see cref="VehicleType"/>'s <c>Id</c>, <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c>.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>A single JobPosition</returns>
        VehicleTypeServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="VehicleType"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="vehicleTypeId">VehicleType ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int vehicleTypeId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="VehicleType"/> using <see cref="EditVehicleTypeServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>VehicleCategory</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditVehicleTypeServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="VehicleType"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}

namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.ServiceTypes;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="ServiceType"/> entity.
    /// </summary>
    public interface IServiceTypesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="ServiceType"/> in the database using <see cref="CreateServiceTypeServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="ServiceType"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Qualification ID</returns>
        Task<int> CreateAsync(CreateServiceTypeServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="ServiceType"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="ServiceTypesDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="ServiceType"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <returns>Collection of ServiceTypes</returns>
        IEnumerable<ServiceTypesDropdownServiceModel> GetAll();

        /// <summary>
        /// Describes a method for getting all the <see cref="ServiceType"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="ServiceTypesListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Name and IsShownInMainMenu</returns>
        IEnumerable<ServiceTypesListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="ServiceType"/>s from the database.
        /// <para>Should return the number of <see cref="ServiceType"/>s</para>
        /// </summary>
        /// <returns>ServiceTypes Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="ServiceType"/> from the database using the given (int) id.
        /// <para>Should return <see cref="ServiceTypeServiceModel"/>.</para>
        /// <para>Each service model has <see cref="ServiceType"/>'s <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.</para>
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>A single ServiceType</returns>
        ServiceTypeServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="ServiceType"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="serviceTypenId">ServiceType ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int serviceTypenId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="ServiceType"/> using <see cref="EditServiceTypeServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditServiceTypeServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="ServiceType"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}

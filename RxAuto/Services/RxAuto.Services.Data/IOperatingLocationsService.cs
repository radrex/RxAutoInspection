namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOperatingLocationsService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding an <see cref="OperatingLocation"/> in the database using <see cref="CreateOperatingLocationServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="OperatingLocation"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and a collection of <c>Departments</c></param>
        /// <returns>OperatingLocation ID</returns>
        Task<int> CreateAsync(CreateOperatingLocationServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="OperatingLocation"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="OperatingLocationsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="OperatingLocation"/>'s <c>Id</c> and <c>Town</c>.</para>
        /// </summary>
        /// <returns>Collection of OperatingLocations</returns>
        IEnumerable<OperatingLocationsDropdownServiceModel> GetAll();

        /// <summary>
        /// Describes a method for getting all the <see cref="OperatingLocation"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="OperatingLocationsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Town and Address</returns>
        IEnumerable<OperatingLocationsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting all the <see cref="OperatingLocation"/>s, their <see cref="Department"/>s and Department's <see cref="Phone"/>s.
        /// </summary>
        /// <returns></returns>
        IEnumerable<OperatingLocationInfoServiceModel> AllInfo();

        /// <summary>
        /// Describes a method for getting the total number of <see cref="OperatingLocation"/>s from the database.
        /// <para>Should return the number of <see cref="OperatingLocation"/>s</para>
        /// </summary>
        /// <returns>OperatingLocation Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="OperatingLocation"/> from the database using the given (int) id.
        /// <para>Should return <see cref="OperatingLocationServiceModel"/>.</para>
        /// <para>Each service model has <see cref="OperatingLocation"/>'s <c>Id</c>, <c>Town</c> and <c>Address</c>.</para>
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>A single OperatingLocation</returns>
        OperatingLocationServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="OperatingLocation"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="operatingLocationId">OperatingLocation ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int operatingLocationId);

        /// <summary>
        /// Describes an asynchronous method for editing an <see cref="OperatingLocation"/> using <see cref="EditOperatingLocationServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and a collection of <c>DepartmentIds</c>  with associated <c>PhoneIds</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditOperatingLocationServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="OperatingLocation"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);

        //TODO: Add docs
        IEnumerable<OperatingLocationMediaServiceModel> GetMedia();
    }
}

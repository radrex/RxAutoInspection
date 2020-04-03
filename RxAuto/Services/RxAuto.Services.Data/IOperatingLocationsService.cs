namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes functionality methods concering <see cref="OperatingLocation"/> entity.
    /// </summary>
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
    }
}

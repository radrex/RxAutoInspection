namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="OperatingLocation"/> entity.
    /// </summary>
    public interface IOperatingLocationsService
    {
        /// <summary>
        /// Describes a method which gets all <see cref="OperatingLocation"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="OperatingLocationsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="OperatingLocation"/>'s <c>Id</c> and <c>Town</c>.</para>
        /// </summary>
        /// <returns>Collection of OperatingLocations</returns>
        IEnumerable<OperatingLocationsDropdownServiceModel> GetAll();
    }
}

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
    }
}

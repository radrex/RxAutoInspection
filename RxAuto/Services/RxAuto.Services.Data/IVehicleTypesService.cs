namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.VehicleTypes;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="VehicleType"/> entity.
    /// </summary>
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
    }
}

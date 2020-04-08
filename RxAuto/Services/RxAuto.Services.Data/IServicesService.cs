namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Services;

    using System.Threading.Tasks;

    /// <summary>
    /// Describes functionality methods concering <see cref="Service"/> entity.
    /// </summary>
    public interface IServicesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Service"/> in the database using <see cref="CreateServiceServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Service"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Department ID</returns>
        Task<int> CreateAsync(CreateServiceServiceModel model);
    }
}

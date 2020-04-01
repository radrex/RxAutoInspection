namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.JobPositions;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes functionality methods concering <see cref="JobPosition"/> entity.
    /// </summary>
    public interface IJobPositionsService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="JobPosition"/> in the database using <see cref="CreateJobPositionServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="JobPosition"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and a collection of <c>Qualifications</c></param>
        /// <returns>JobPosition ID</returns>
        Task<int> CreateAsync(CreateJobPositionServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="JobPosition"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="JobPositionsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="JobPosition"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <returns>Collection of JobPositions</returns>
        IEnumerable<JobPositionsDropdownServiceModel> GetAll();
    }
}

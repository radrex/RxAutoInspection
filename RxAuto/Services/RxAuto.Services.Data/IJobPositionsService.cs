namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.JobPositions;

    using System.Collections.Generic;
    using System.Threading.Tasks;

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

        /// <summary>
        /// Describes a method for getting all the <see cref="JobPosition"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="JobPositionsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id and Name</returns>
        IEnumerable<JobPositionsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="JobPosition"/>s from the database.
        /// <para>Should return the number of <see cref="JobPosition"/>s</para>
        /// </summary>
        /// <returns>JobPositions Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="JobPosition"/> from the database using the given (int) id.
        /// <para>Should return <see cref="JobPositionServiceModel"/>.</para>
        /// <para>Each service model has <see cref="JobPosition"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>A single JobPosition</returns>
        JobPositionServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="JobPosition"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="jobPositionId">JobPosition ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int jobPositionId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="JobPosition"/> using <see cref="EditJobPositionServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c> and a collection of <c>QualificationIds</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditJobPositionServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="JobPosition"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}

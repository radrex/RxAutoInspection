namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Departments;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="Department"/> entity.
    /// </summary>
    public interface IDepartmentsService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Department"/> in the database using <see cref="CreateDepartmentServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Department"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c>, <c>Email</c>, <c>Description</c> and a collection of <c>Phones</c></param>
        /// <returns>Department ID</returns>
        Task<int> CreateAsync(CreateDepartmentServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="Department"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="DepartmentsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c>.</para>
        /// </summary>
        /// <returns>Collection of Departments</returns>
        IEnumerable<DepartmentsDropdownServiceModel> GetAll();
    }
}

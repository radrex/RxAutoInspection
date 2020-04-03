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

        /// <summary>
        /// Describes a method which gets all <see cref="Department"/>'s from the database that doesn't have an <see cref="OperatingLocation"/>.
        /// <para>Should return IEnumerable&lt;<see cref="DepartmentsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c>.</para>
        /// </summary>
        /// <returns>Collection of Departments</returns>
        IEnumerable<DepartmentsDropdownServiceModel> GetAllWithoutOperatingLocation();

        /// <summary>
        /// Describes a method which gets all selected <see cref="Department"/>s and their <see cref="Phone"/>s from the database, using the given string[] parameter.
        /// <para>The first element should be the <see cref="Department"/>'s <c>Id</c> and the second element - <see cref="Phone"/> <c>Id</c> for that <see cref="Department"/>.</para>
        /// <para>Should return IEnumerable&lt;<see cref="DepartmentsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c>.</para>
        /// </summary>
        /// <param name="departmentIds">First element is <c>Department</c> ID, second element is <c>Phone</c> ID for that <c>Department</c></param>
        /// <returns></returns>
        IEnumerable<DepartmentsDropdownServiceModel> GetAllDepartmentsWithSelectedPhones(string[] departmentIds);
    }
}

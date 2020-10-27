namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Departments;

    using System.Threading.Tasks;
    using System.Collections.Generic;

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

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Department"/>s from the database.
        /// <para>Should return the number of <see cref="Department"/>s</para>
        /// </summary>
        /// <returns>Department Count</returns>
        int Count();

        /// <summary>
        /// Describes a method for getting all the <see cref="Department"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="DepartmentsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Name and Email</returns>
        IEnumerable<DepartmentsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method which gets a <see cref="Department"/> from the database using the given (int) id.
        /// <para>Should return <see cref="DepartmentServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Department"/>'s <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Description</c>.</para>
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>A single Department</returns>
        DepartmentServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="Department"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="departmentId">Department ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int departmentId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="Department"/> using <see cref="EditDepartmentServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c>, <c>Email</c>, <c>Description</c> and a collection of <c>PhoneNumberIds</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditDepartmentServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="Department"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}

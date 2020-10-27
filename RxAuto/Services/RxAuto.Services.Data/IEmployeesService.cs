namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Employees;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IEmployeesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Employee"/> in the database using <see cref="CreateEmployeeServiceModel"/>.
        /// <para>Should return the ID (string) of the <see cref="Employee"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c></param>
        /// <returns>Employee ID</returns>
        Task<string> CreateAsync(CreateEmployeeServiceModel model);

        /// <summary>
        /// Describes a method for getting all the <see cref="Employee"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="EmployeesListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, FirstName, MiddleName, LastName, PhoneNumber, Email, OperatingLocationTown, OperatingLocationAddress and JobPosition</returns>
        IEnumerable<EmployeesListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Employee"/>s from the database.
        /// <para>Should return the number of <see cref="Employee"/>s</para>
        /// </summary>
        /// <returns>Employee Count</returns>
        int Count();

        /// <summary>
        /// Describes a method for getting information of the <see cref="Employee"/> with the given Id.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Service Model with Full Name, Phone, Email, Address, ImageUrl, Operating Location and Job Position</returns>
        EmployeeServiceModel GetById(string id);

        /// <summary>
        /// Describes an asynchronous method for removing an <see cref="Employee"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Describes a method for searching an <see cref="Employee"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="employeeId">Employee ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(string employeeId);

        /// <summary>
        /// Describes an asynchronous method for editing an <see cref="Employee"/> using <see cref="EditEmployeeServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditEmployeeServiceModel model);
    }
}

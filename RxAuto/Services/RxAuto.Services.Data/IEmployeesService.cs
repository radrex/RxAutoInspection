namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Employees;

    using System.Threading.Tasks;

    /// <summary>
    /// Describes functionality methods concering <see cref="Employee"/> entity.
    /// </summary>
    public interface IEmployeesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Employee"/> in the database using <see cref="CreateEmployeeServiceModel"/>.
        /// <para>Should return the ID (string) of the <see cref="Employee"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c></param>
        /// <returns>Employee ID</returns>
        Task<string> CreateAsync(CreateEmployeeServiceModel model);
    }
}

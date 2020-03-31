namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Employees;

    using System.Threading.Tasks;

    /// <summary>
    /// Contains functionality methods concering <see cref="Employee"/> entity.
    /// </summary>
    public interface IEmployeesService
    {
        Task<string> CreateAsync(CreateEmployeeServiceModel model);
    }
}
